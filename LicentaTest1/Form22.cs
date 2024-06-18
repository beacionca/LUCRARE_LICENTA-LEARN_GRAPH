using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LicentaTest1
{
    public partial class Form22 : Form
    {
        private string userNume, userPrenume;
        public Form22(string nume, string prenume)
        {
            InitializeComponent();
            userNume = nume;
            userPrenume = prenume;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folder = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\TEORIE_GRAFURI\";
            string fisier = userNume + " " + userPrenume + ".txt";
            string FilePath = folder + fisier;

            string continut = richTextBox1.Text;

            File.WriteAllText(FilePath, continut);
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            string folder = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\TEORIE_GRAFURI\";
            string fisier = userNume + " " + userPrenume + ".txt";
            string FilePath = folder + fisier;

            string[] fisiere = Directory.GetFiles(folder, fisier);

            if (!(fisiere.Length > 0))
            {
                File.Create(FilePath).Dispose();
            }

            richTextBox1.Text = File.ReadAllText(FilePath);

        }
    }
}
