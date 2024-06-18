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

namespace LicentaTest1
{
    public partial class Form21 : Form
    {
        public string UserPicture { get; private set; }
        public Form21()
        {
            InitializeComponent();
            LoadImages(@"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\ARBORI_IMAGINI");
        }
        private void LoadImages(string folderPath)
        {
            try
            {
                string[] files = Directory.GetFiles(folderPath, "*.jpg"); 
                foreach (string file in files)
                {
                    // Creează un panel pentru fiecare imagine și etichetă
                    Panel panel = new Panel();
                    panel.Width = 100;
                    panel.Height = 120;

                    // Creează PictureBox pentru imagine
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(file);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Width = 100;
                    pictureBox.Height = 100;
                    pictureBox.Tag = file; // Salvează calea fișierului în Tag
                    pictureBox.Click += PictureBox_Click;

                    // Creează Label pentru numele imaginii
                    Label label = new Label();
                    label.Text = Path.GetFileName(file);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Dock = DockStyle.Bottom;

                    // Adaugă PictureBox și Label în Panel
                    panel.Controls.Add(pictureBox);
                    panel.Controls.Add(label);

                    // Adaugă Panel în FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(panel);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la încărcarea imaginilor: " + ex.Message);
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = sender as PictureBox;
            if (clickedPictureBox != null && clickedPictureBox.Tag != null)
            {
                string filePath = clickedPictureBox.Tag.ToString();
                this.UserPicture = filePath;
                MessageBox.Show(filePath);
                Form form20 = new Form20(filePath);
                form20.Show();
            }
        }

        private void Form21_Load(object sender, EventArgs e)
        {

        }
    }
}
