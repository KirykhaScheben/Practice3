using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Airport
{
    public partial class Authorize : Form
    {
        public Authorize()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            using (SQLiteConnection connection = new SQLiteConnection("Data Source=airport.db"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM AdminData WHERE login = @login AND password = @password";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        this.Hide(); // Скрыть текущую форму
                        AirplanesForm airForm = new AirplanesForm();
                        airForm.ShowDialog(); // Открыть новую форму как модальную
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
