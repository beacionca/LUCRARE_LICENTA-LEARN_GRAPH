﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicentaTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Form9();
            f.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

    }
}
