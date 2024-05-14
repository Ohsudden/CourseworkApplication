using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseworkApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                using (NpgsqlConnection con = GetConnection())
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        label3.Text = "під'єднана";
                        label3.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {

                label3.Text = "Помилка з'єднання: " + ex.Message;
                label3.ForeColor = Color.Red;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

     
        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection("Server=localhost;Port=5432;Database=Online store;User Id=postgres;Password=admin;");
        }

        private void sendQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string query = queryBox.Text.Trim();

                using (NpgsqlConnection con = GetConnection())
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        if (ContainsUpdateOrDelete(query)) {
                            ExecuteChangingQuery(con, query);
                        }
                        else
                        {
                            DataTable dataTable = ExecuteQuery(con, query);
                            Form2 resultForm = new Form2(dataTable);
                            resultForm.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при виконанні запита: {ex.Message}",
                    "Помилка запиту", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool ContainsUpdateOrDelete(string queryString)
        {
            string lowerQueryString = queryString.ToLower();

            bool containsUpdate = lowerQueryString.Contains("update");
            bool containsDelete = lowerQueryString.Contains("delete from");
            bool containsInsert = lowerQueryString.Contains("insert into");

            return containsUpdate || containsDelete || containsInsert;
        }

        private DataTable ExecuteQuery(NpgsqlConnection connection, string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Помилка при виконанні запита: {ex.Message}");
            }

            return dataTable;
        }
        private void ExecuteChangingQuery(NpgsqlConnection connection, string query)
        {
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery(); 

                    MessageBox.Show($"{rowsAffected} строк додано.",
                        "Query Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
