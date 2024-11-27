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
    }
}