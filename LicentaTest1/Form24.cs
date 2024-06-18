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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Form14();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form25();
            f.ShowDialog();
        }
    }
}
