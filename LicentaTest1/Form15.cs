using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicentaTest1
{
    public partial class Form15 : Form
    {
        private string userNume;
        private string userPrenume;
        public Form15(string nume, string prenume)
        {
            InitializeComponent();
            userNume = nume;
            userPrenume = prenume;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Form12();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form28(userNume, userPrenume);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Form18(userNume,userPrenume);
            f.Show();
        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f = new Form19();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form f = new Form21();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form f = new Form22(userNume, userPrenume);
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form f = new Form22(userNume, userPrenume);
            f.Show();
        }
    }
}
