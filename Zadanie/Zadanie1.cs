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
    public partial class Zadanie1 : Form
    {
        public Zadanie1()
        {
            InitializeComponent();
        }
        abstract class Complektyuyshie<A>
        {
            public string Price;
            public string data_vipuska;
            public A Artikul;

            public Complektyuyshie(string Price, string data_vipuska, A Artikul)
            {
                this.Price = Price;
                this.data_vipuska = data_vipuska;
                this.Artikul = Artikul;
            }
            public abstract void DisplayInfo(ListBox lb);
        }

        class CPU<C> : Complektyuyshie<string>
        {
            string Chastota { get; set; }
            string kol_vo_core { get; set; }
            string Kol_vo_streams { get; set; }

            public CPU(string Price, string data_vipuska, string Artikul, string Chastota, string kol_vo_core, string Kol_vo_streams) : base(Price, data_vipuska, Artikul)
            {
                this.Chastota = Chastota;
                this.kol_vo_core = kol_vo_core;
                this.Kol_vo_streams = Kol_vo_streams;
            }

            public override void DisplayInfo(ListBox lb)
            {
                lb.Items.Add($"Артикул:{Artikul}, Год выпуска:{data_vipuska}, Цена:{Price}, Частота процессора:{Chastota}, Количество ядер:{kol_vo_core}, Количество потоков:{Kol_vo_streams}");
            }
        }

        class Videocard<V> : Complektyuyshie<string>
        {
            string GPU { get; set; }
            string Firma { get; set; }
            string Memory { get; set; }

            public Videocard(string Price, string data_vipuska, string Artikul, string GPU, string Firma, string Memory) : base(Price, data_vipuska, Artikul)
            {
                this.GPU = GPU;
                this.Firma = Firma;
                this.Memory = Memory;
            }
            public override void DisplayInfo(ListBox lb)
            {
                lb.Items.Add($"Артикул:{Artikul}, Год выпуска:{data_vipuska}, Цена:{Price}, Частота GPU:{GPU}, Производитель:{Firma}, Количество памяти:{Memory}");
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            CPU<string> cpu1 = new CPU<string>(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);

            cpu1.DisplayInfo(listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Videocard<string> vc1 = new Videocard<string>(textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text);

            vc1.DisplayInfo(listBox2);
        }

        
    }
}
