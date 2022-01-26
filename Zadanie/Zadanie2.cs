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
    public partial class Zadanie2 : Form
    {
        public Zadanie2()
        {
            InitializeComponent();
        }
        class Connect
        {
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
        }
        MySqlConnection conn = new MySqlConnection(Connect.C());


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                MessageBox.Show("Подключено");
            }
            catch
            {
                MessageBox.Show("Ошибка подключения");
            }
        }
    }
}
