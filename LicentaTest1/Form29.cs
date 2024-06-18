using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicentaTest1
{
    public partial class Form29 : Form
    {
        private string userNume;
        private string userPrenume;

        string current_txt_file;

        static int GetPresentVariant(string TxtPath)
        {
            DirectoryInfo dir = new DirectoryInfo(TxtPath);
            int actual_number = 0;

            FileInfo[] files = dir.GetFiles("*.txt");

            if (files.Length == 0) actual_number = 0;
            else
            {

                foreach (var file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.Name);
                    int value = int.Parse(fileName);

                    if (value > actual_number) actual_number = value;

                }
            }
            return actual_number;
        }

        static int GetPresentVariant_Img(string ImgPath)
        {
            DirectoryInfo dir = new DirectoryInfo(ImgPath);
            int actual_number = 0;

            FileInfo[] files = dir.GetFiles("*.jpg");

            if (files.Length == 0) actual_number = 0;
            else
            {

                foreach (var file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file.Name);
                    int value = int.Parse(fileName);

                    if (value > actual_number) actual_number = value;

                }
            }
            return actual_number;
        }

        static string GetCurrentTxtFileName()
        {
            string Path = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_VALORI";
            string variant = GetPresentVariant(Path).ToString();
            string name = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_VALORI\" + variant + ".txt";
            return name;
        }
        public Form29(string nume, string prenume)
        {
            InitializeComponent();
            userNume = nume;
            userPrenume = prenume;
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string TxtPath = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_VALORI";
            string ImgPath = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_IMAGINI";

            string current_variant_aux = GetCurrentTxtFileName();
            int variant_txt = GetPresentVariant(TxtPath);
            int variant_img = GetPresentVariant_Img(ImgPath);

            if (variant_txt > variant_img)
            {
                File.Delete(current_variant_aux);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nod1 = textBox1.Text;
            string nod2 = textBox2.Text;
            string pondere = textBox3.Text;

            int valoare_nod1 = int.Parse(nod1);
            int valoare_nod2 = int.Parse(nod2);
            int valoare_pondere = int.Parse(pondere);

            string current_FileName = GetCurrentTxtFileName();
            string TextToBeAdded = nod1 + " " + nod2 + " " + pondere;

            File.AppendAllText(current_FileName, TextToBeAdded + Environment.NewLine);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void Form29_Load(object sender, EventArgs e)
        {
            string TxtPath = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_VALORI";

            int current_variant = GetPresentVariant(TxtPath) + 1;

            string current_FileName = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_VALORI\" + current_variant.ToString() + ".txt";

            current_txt_file = current_FileName;

            if (!File.Exists(current_FileName))
            {
                File.Create(current_FileName).Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            string TxtPath = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_VALORI";

            int current_variant = GetPresentVariant(TxtPath);

            string current_FileName = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_VALORI\" + current_variant.ToString() + ".txt";

            File.AppendAllText(current_FileName, "orientat" + Environment.NewLine);

            string TxtPath2 = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_VALORI_ORIENTATE";
            int var = GetPresentVariant(TxtPath2);
            int var_curenta = var + 1;
            string FileCompletePath = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_VALORI_ORIENTATE\" + var_curenta.ToString() + ".txt";

            if (!File.Exists(FileCompletePath))
            {
                File.Create(FileCompletePath).Dispose();
            }

            File.Copy(current_FileName, FileCompletePath, true);

            var psi = new ProcessStartInfo();
            psi.FileName = @"C:/Users/Beatrice/AppData/Local/Programs/Python/Python312/python.exe";
            var script = @"D:\wamp64\www\TEST_BEATRICE\gdfg\3.py";
            string argument = "By: " + userNume + " " + userPrenume;

            psi.Arguments = $"\"{script}\" \"{argument}\"";

            Process.Start(psi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            string current_FileName = GetCurrentTxtFileName();
            File.WriteAllText(current_FileName, string.Empty);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            string TxtPath = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_VALORI";

            string current_variant_aux = GetCurrentTxtFileName();

            if (File.Exists(current_variant_aux))
            {
                FileInfo fileInfo = new FileInfo(current_variant_aux);
                if (fileInfo.Length == 0)
                {
                    File.Delete(current_variant_aux);

                }
            }

            int current_variant = GetPresentVariant(TxtPath) + 1;

            string current_FileName = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_VALORI\" + current_variant.ToString() + ".txt";

            current_txt_file = current_FileName;

            if (!File.Exists(current_FileName))
            {
                File.Create(current_FileName).Dispose();
            }
        }

    }
}
