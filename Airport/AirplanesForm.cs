using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Airport
{
    public partial class AirplanesForm : Form
    {
        public AirplanesForm()
        {
            InitializeComponent();
            LoadAirplanesData();
        }

        private void LoadAirplanesData()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=airport.db"))
            {
                connection.Open();
                string selectSql = "SELECT PlaneNumber, Type, Seats, FlightSpeed FROM Airplanes";
                using (SQLiteCommand command = new SQLiteCommand(selectSql, connection))
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void LoadRoutesData()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=airport.db"))
            {
                connection.Open();
                string selectSql = "SELECT RouteNumber, Distance, DeparturePoint, DestinationPoint FROM Routes";
                using (SQLiteCommand command = new SQLiteCommand(selectSql, connection))
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void LoadFlightsData()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=airport.db"))
            {
                connection.Open();
                string selectSql = "SELECT FlightID, PlaneNumber, RouteNumber, DepartureDateTime, ArrivalDateTime, TicketsSold FROM Flights";
                using (SQLiteCommand command = new SQLiteCommand(selectSql, connection))
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        // Запрос 1: Определить среднее расчетное время полета для самолета 'ТУ-154' по маршруту 'Чугуев' - 'Мерефа'
        private void LoadAverageFlightTime()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=airport.db"))
            {
                connection.Open();
                string selectSql = @"
        SELECT 
            Flights.PlaneNumber, 
            Airplanes.FlightSpeed, 
            Routes.Distance,
            AVG(strftime('%s', Flights.ArrivalDateTime) - strftime('%s', Flights.DepartureDateTime)) / 60 AS AverageFlightTime
        FROM Flights 
        JOIN Routes ON Flights.RouteNumber = Routes.RouteNumber 
        JOIN Airplanes ON Flights.PlaneNumber = Airplanes.PlaneNumber
        WHERE Flights.PlaneNumber = 'TU-154' 
          AND Routes.DeparturePoint = 'Чугуев' 
          AND Routes.DestinationPoint = 'Мерефа'
        GROUP BY Flights.PlaneNumber, Airplanes.FlightSpeed, Routes.Distance";

                using (SQLiteCommand command = new SQLiteCommand(selectSql, connection))
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());

                    // Проверка на наличие данных
                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Нет данных для расчета среднего времени полета для самолета 'ТУ-154' по маршруту 'Чугуев' - 'Мерефа'.");
                    }
                }
            }
        }

        // Запрос 2: Выбрать марку самолета, которая чаще всего летает по тому же маршруту
        private void LoadMostFrequentPlane()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=airport.db"))
            {
                connection.Open();

                // 1. Найти самолет, который чаще всего летает по маршруту Чугуев - Мерефа
                string mostFrequentPlaneSql = @"
            SELECT 
                Flights.PlaneNumber
            FROM Flights 
            JOIN Routes ON Flights.RouteNumber = Routes.RouteNumber
            WHERE Routes.DeparturePoint = 'Чугуев' AND Routes.DestinationPoint = 'Мерефа'
            GROUP BY Flights.PlaneNumber
            ORDER BY COUNT(*) DESC 
            LIMIT 1";

                string mostFrequentPlane;

                using (SQLiteCommand command = new SQLiteCommand(mostFrequentPlaneSql, connection))
                {
                    mostFrequentPlane = command.ExecuteScalar()?.ToString();
                }

                // 2. Если самолет найден, получить все его рейсы
                if (!string.IsNullOrEmpty(mostFrequentPlane))
                {
                    string flightsSql = @"
                SELECT 
                    Flights.PlaneNumber,
                    Flights.DepartureDateTime,
                    Flights.ArrivalDateTime,
                    Routes.DeparturePoint,
                    Routes.DestinationPoint
                FROM Flights 
                JOIN Routes ON Flights.RouteNumber = Routes.RouteNumber
                WHERE Flights.PlaneNumber = @PlaneNumber";

                    using (SQLiteCommand command = new SQLiteCommand(flightsSql, connection))
                    {
                        command.Parameters.AddWithValue("@PlaneNumber", mostFrequentPlane);
                        DataTable dataTable = new DataTable();
                        dataTable.Load(command.ExecuteReader());
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void LoadUnderbookedRoutes()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=airport.db"))
            {
                connection.Open();
                string selectSql = @"
        SELECT 
            Routes.RouteNumber, 
            Routes.DeparturePoint, 
            Routes.DestinationPoint,
            COUNT(Flights.FlightID) AS FlightCount
        FROM Flights 
        JOIN Airplanes ON Flights.PlaneNumber = Airplanes.PlaneNumber
        JOIN Routes ON Flights.RouteNumber = Routes.RouteNumber
        WHERE Flights.TicketsSold < (Airplanes.Seats * 0.7)
        GROUP BY Routes.RouteNumber, Routes.DeparturePoint, Routes.DestinationPoint
        ORDER BY FlightCount DESC
        LIMIT 1";  // Ограничение на одну запись

                using (SQLiteCommand command = new SQLiteCommand(selectSql, connection))
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dataTable;
                }
            }
        }
        // Запрос 4: Определить наличие свободных мест на рейс №870 от 31 декабря 2000 г.
        private void LoadFreeSeatsForFlight870()
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=airport.db"))
            {
                connection.Open();
                string selectSql = @"
            SELECT 
                Flights.FlightID,
                Flights.PlaneNumber,
                Flights.RouteNumber,
                Flights.DepartureDateTime,
                Flights.ArrivalDateTime,
                Airplanes.Seats,
                Flights.TicketsSold,
                (Airplanes.Seats - Flights.TicketsSold) AS FreeSeats 
            FROM Flights 
            JOIN Airplanes ON Flights.PlaneNumber = Airplanes.PlaneNumber 
            WHERE FlightID = 870 AND DepartureDateTime = '2000-12-31 10:00:00'"; // Убедитесь, что время указано правильно

                using (SQLiteCommand command = new SQLiteCommand(selectSql, connection))
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dataTable;

                    // Проверка на пустую таблицу
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Нет доступных мест для рейса №870 на указанную дату.");
                    }
                }
            }
        }

        private void btnLoadAirplanes_Click(object sender, EventArgs e)
        {
            LoadAirplanesData();
        }

        private void btnLoadRoutes_Click(object sender, EventArgs e)
        {
            LoadRoutesData();
        }

        private void btnLoadFlights_Click(object sender, EventArgs e)
        {
            LoadFlightsData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadAverageFlightTime();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadMostFrequentPlane();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            LoadUnderbookedRoutes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadFreeSeatsForFlight870();
        }
    }
}