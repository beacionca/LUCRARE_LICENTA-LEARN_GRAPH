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
    public partial class Form20 : Form
    {
        private string userPicture;
        private PictureBox dynamicpictureBox;
        public Form20(string filePath)
        {
            InitializeComponent();
            userPicture = filePath;
            PictureBox pictureBox = new PictureBox();
            
            pictureBox.ImageLocation = userPicture;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
           
            this.Controls.Add(pictureBox);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Text = System.IO.Path.GetFileName(filePath);

        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }
    }
}
