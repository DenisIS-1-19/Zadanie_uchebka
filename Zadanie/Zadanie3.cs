using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Zadanie
{
    public partial class Zadanie3 : Form
    {
        public Zadanie3()
        {
            InitializeComponent();
        }
        public static string C()
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

        string id_selected_rows = "0";

        MySqlConnection conn = new MySqlConnection(Zadanie3.C());
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        private BindingSource bSource = new BindingSource();
        private DataTable table = new DataTable();

        public void GetSelectedIDString()
        {
            string index_selected_rows;
            index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[1].Value.ToString();
            MessageBox.Show(id_selected_rows);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = $"SELECT id, fio, theme_kurs FROM t_stud";
                MyDA.SelectCommand = new MySqlCommand(sql, conn);
                MyDA.Fill(table);
                bSource.DataSource = table;
                dataGridView1.DataSource = bSource;
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка подключения");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            dataGridView1.CurrentRow.Selected = true;
            GetSelectedIDString();
        }
    }
}
