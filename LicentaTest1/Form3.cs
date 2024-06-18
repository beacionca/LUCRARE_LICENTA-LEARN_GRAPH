using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LicentaTest1
{
    public partial class Form3 : Form
    {
        private string userEmail;
        public Form3(string mail)
        {
            InitializeComponent();
            userEmail = mail;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form4();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Form6();
            f.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string PhotoPath = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\background.jpg";
            pictureBox1.ImageLocation = PhotoPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f = new Form13(userEmail);
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Form5();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form f = new Form7(userEmail);
            f.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
