using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace PostgresApp
{
    public partial class Form1 : Form
    {
        string connString = "Host=localhost;Username=admin@example.com;Password=216175yh;Database=postgres";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPersons();
        }

        private void LoadPersons()
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT * FROM person", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MessageBox.Show(reader["full_name"].ToString());
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            peopleGrid.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var row = peopleGrid.Rows[e.RowIndex];
                    nameTextBox.Text = row.Cells["full_name"].Value.ToString();
                    ageUpDown.Value = Convert.ToDecimal(row.Cells["age"].Value);
                }
            };

        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            using var conn = new Npgsql.NpgsqlConnection(connString);
            try
            {
                conn.Open();
                using var cmd = new Npgsql.NpgsqlCommand("INSERT INTO person (full_name, age) VALUES (@name, @age)", conn);
                cmd.Parameters.AddWithValue("name", nameTextBox.Text);
                cmd.Parameters.AddWithValue("age", (int)ageUpDown.Value);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Inserted successfully!");
                LoadPeople(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void LoadPeople()
        {
            using var conn = new Npgsql.NpgsqlConnection(connString);
            try
            {
                conn.Open();
                using var da = new Npgsql.NpgsqlDataAdapter("SELECT * FROM person", conn);
                var dt = new DataTable();
                da.Fill(dt);
                peopleGrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Load error: {ex.Message}");
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (peopleGrid.CurrentRow == null) return;

            var id = peopleGrid.CurrentRow.Cells["id"].Value;
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            var cmd = new NpgsqlCommand("UPDATE person SET full_name=@name, age=@age WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("name", nameTextBox.Text);
            cmd.Parameters.AddWithValue("age", (int)ageUpDown.Value);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();

            LoadPeople();
            MessageBox.Show("Updated!");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (peopleGrid.CurrentRow == null) return;

            var id = peopleGrid.CurrentRow.Cells["id"].Value;
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            var cmd = new NpgsqlCommand("DELETE FROM person WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();

            LoadPeople();
            MessageBox.Show("Deleted!");
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadPeople();
        }

    }
}
