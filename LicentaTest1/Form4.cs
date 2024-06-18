using IronPython.Runtime;
using Microsoft.Scripting.Hosting.Shell;
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
using static IronPython.Modules._ast;

namespace LicentaTest1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void GenerarePrimaPagina()
        {
           string continut = File.ReadAllText(@"C:\\Users\\Beatrice\\Desktop\\AN III\\semestru 2\\LICENTA\\TEORIE_GRAFURI\FACULTATE.txt");
           richTextBox1.Text = continut;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string aux = comboBox1.Text;
            string folder = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\TEORIE_GRAFURI\";
            List<string> vectorFisiere = ListaFisiere(folder);
            foreach (string fisier in vectorFisiere)
            {
                int l = fisier.Length;
                string fis = fisier.Substring(67, l - 71);
                if(flag == 1)
                {
                    string continut = File.ReadAllText(fisier);
                    richTextBox1.Text = continut;
                    comboBox1.Text = fis;
                    flag = 0;
                }
                if (aux.Equals(fis))
                {
                    flag = 1;
                }
            }

            Button dynamicButton = new Button();
            dynamicButton.Location = new System.Drawing.Point(217, 309);
            dynamicButton.Size = new System.Drawing.Size(140, 27);
            dynamicButton.Text = "PAGINA ANTERIOARA";
            dynamicButton.ForeColor = Color.Black;
            dynamicButton.BackColor = Color.SteelBlue;
            dynamicButton.Font = new Font("Microsoft Sans Serif", 7, FontStyle.Bold); 

            // Adaugă un eveniment click pentru buton
            dynamicButton.Click += new EventHandler(DynamicButton_Click);

            // Adaugă butonul la formular
            this.Controls.Add(dynamicButton);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string folder = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\TEORIE_GRAFURI\";
            List<string> vectorFisiere = ListaFisiere(folder);

            // Afișează fișierele în ListBox
            comboBox1.Items.Clear();
            foreach (string fisier in vectorFisiere)
            {
                int l = fisier.Length;
                string fis = fisier.Substring(67, l - 71);
                comboBox1.Items.Add(fis);
            }

            GenerarePrimaPagina();
            comboBox1.Text = "FACULTATE";
        }

        private List<string> ListaFisiere(string folder)
        {
            List<string> fisiere = new List<string>();
            try
            {
                foreach (string file in Directory.GetFiles(folder, "*", SearchOption.AllDirectories))
                {
                    fisiere.Add(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare: " + ex.Message);
            }
            return fisiere;
        }

        private void DynamicButton_Click(object sender, EventArgs e)
        {
            int flag = 0;
            string aux = comboBox1.Text;
            string folder = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\TEORIE_GRAFURI\";
            List<string> vectorFisiere = ListaFisiere(folder);
            for (int i = comboBox1.Items.Count - 1; i >= 0; i--)
            {
                if(i==0)
                {

                }
                string item = comboBox1.Items[i].ToString();
                if (flag == 1)
                {
                    string fisier = folder + item + ".txt";
                    string continut = File.ReadAllText(fisier);
                    richTextBox1.Text = continut;
                    comboBox1.Text = item;
                    flag = 0;
                }
                if (item.Equals(aux))
                {
                    flag = 1;

                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string aux = comboBox1.Text;
            string folder = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\TEORIE_GRAFURI\";
            List<string> vectorFisiere = ListaFisiere(folder);
            foreach (string fisier in vectorFisiere)
            {
                int l = fisier.Length;
                string fis = fisier.Substring(67, l - 71);
                if (aux.Equals(fis))
                {
                    string continut = File.ReadAllText(fisier);
                    richTextBox1.Text = continut;
                }
            }
        }
    }
}
