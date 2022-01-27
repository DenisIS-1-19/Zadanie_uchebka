using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zadanie1 Zadanie1 = new Zadanie1();
            Zadanie1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Zadanie2 Zadanie2 = new Zadanie2();
            Zadanie2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Zadanie3 Zadanie3 = new Zadanie3();
            Zadanie3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Zadanie4 Zadanie4 = new Zadanie4();
            Zadanie4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
