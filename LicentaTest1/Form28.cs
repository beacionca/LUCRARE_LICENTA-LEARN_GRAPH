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
    public partial class Form28 : Form
    {
        private string userNume;
        private string userPrenume;
        public Form28(string nume, string prenume)
        {
            InitializeComponent();
            userNume = nume;
            userPrenume = prenume;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form29(userNume, userPrenume);
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Form16(userNume, userPrenume);
            f.Show();
        }
    }
}
