using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using Library;




namespace Zadanie
{
    public partial class Zadanie4 : Form
    {
        public Zadanie4()
        {
            InitializeComponent();
        }
        class Connection_DB
        {
            public static string Conn()
            {
                const string host = "caseum.ru";
                const int port = 33333;
                const string user = "test_user";
                const string db = "db_test";
                const string pass = "test_pass";
                string connStr = $"server={host};port={port};user={user};" +
                $"database={db};password={pass};";
                return connStr;
            }
        }
        MySqlConnection conn = new MySqlConnection(Connection_DB.Conn());

        string id_rows5;



        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT idStud, fioStud, drStud FROM t_datetime";
            try
            {
                conn.Open();

                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, conn);

                DataSet dataset = new DataSet();

                IDataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться!!!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];

                dataGridView1.CurrentRow.Selected = true;

                string index_rows5;

                index_rows5 = dataGridView1.SelectedCells[0].RowIndex.ToString();

                id_rows5 = dataGridView1.Rows[Convert.ToInt32(index_rows5)].Cells[2].Value.ToString();
                DateTime todays_date = DateTime.Today;
                DateTime Date_of_Birth = Convert.ToDateTime(dataGridView1.Rows[Convert.ToInt32(index_rows5)].Cells[2].Value.ToString());
                string result = (todays_date - Date_of_Birth).ToString();
                MessageBox.Show("Со дня рождения прошло " + result.Substring(0, result.Length - 9) + " дней");
            }
        }

        private void Zadanie4_Load(object sender, EventArgs e)
        {
            MySqlConnection connect = new MySqlConnection(Connection_DB.Conn());
            string sql = $"SELECT idStud, fioStud, drStud FROM t_datetime";
            try
            {
                connect.Open();
                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, connect);
                DataSet dataset = new DataSet();
                IDataAdapter.Fill(dataset);
                dataGridView1.DataSource = dataset.Tables[0];
            }
            finally
            {
                connect.Close();
            }
        }
    }
}