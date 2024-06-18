using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LicentaTest1
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Form12_Load_1(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = 0;
            listBox3.SelectedIndex = 0;
            listBox4.SelectedIndex = 0;

            string connect = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            cnn.Open();
            string tabel_date = "select * from Situatie_Studenti";
            SqlDataAdapter da = new SqlDataAdapter(tabel_date, connect);
            DataSet ds = new DataSet();
            da.Fill(ds, "Situatie_Studenti");
            dataGridView1.DataSource = ds.Tables["Situatie_Studenti"].DefaultView;
            cnn.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "Info")
            {
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();


                listBox2.Items.Add("0");
                listBox2.Items.Add("1");
                listBox2.Items.Add("2");
                listBox2.Items.Add("3");

                listBox3.Items.Add("1");

                listBox4.Items.Add("toate");
                listBox4.Items.Add("1.1");
                listBox4.Items.Add("1.2");
                listBox4.Items.Add("2.1");
                listBox4.Items.Add("2.2");
                listBox4.Items.Add("3.1");
                listBox4.Items.Add("3.2");
            }
            else
            {
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                listBox4.Items.Clear();

                listBox2.Items.Add("0");
                listBox2.Items.Add("1");
                listBox2.Items.Add("2");
                listBox2.Items.Add("3");
                listBox2.Items.Add("4");

                listBox3.Items.Add("0");
                listBox3.Items.Add("1");
                listBox3.Items.Add("2");

                listBox4.Items.Add("TOATE");
                listBox4.Items.Add("1.1");
                listBox4.Items.Add("1.2");
                listBox4.Items.Add("2.1");
                listBox4.Items.Add("2.2");
                listBox4.Items.Add("3.1");
                listBox4.Items.Add("3.2");
                listBox4.Items.Add("4.1");
                listBox4.Items.Add("4.2");
                listBox4.Items.Add("5.1");
                listBox4.Items.Add("5.2");
                listBox4.Items.Add("6.1");
                listBox4.Items.Add("6.2");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string specializare = listBox1.SelectedItem.ToString();
            string anul = listBox2.SelectedItem.ToString();
            string seria = listBox3.SelectedItem.ToString();
            string grupa = listBox4.SelectedItem.ToString();
            string rol = "student";

            bool flag_selected = false;

            string comanda = "select * from Situatie_Studenti";

            if ((textBox1.Text != "") || (textBox2.Text != "") || (listBox1.SelectedIndex != 0) || (listBox2.SelectedIndex != 0) || (listBox3.SelectedIndex != 0) || (listBox4.SelectedIndex != 0))
                flag_selected = true;

            if (flag_selected)
            {
                comanda = comanda + " where";
            }

            if (textBox1.Text != "")
            {
                comanda = comanda + " nume='" + textBox1.Text  + "' and";
            }
            if (textBox2.Text != "")
            {
                comanda = comanda + " prenume='" + textBox2.Text + "' and";
            }
            if (listBox1.SelectedIndex != 0)
            {
                comanda = comanda + " specializare='" + specializare + "' and";
            }
            if (listBox2.SelectedIndex != 0)
            {
                comanda = comanda + " an='" + anul + "' and";
            }
            if (listBox3.SelectedIndex != 0)
            {
                comanda = comanda + " serie='" + seria + "' and";
            }
            if (listBox4.SelectedIndex != 0)
            {
                comanda = comanda + " grupa='" + grupa + "' and";
            }
            if (comanda.EndsWith(" and"))
            {
                int Text_length = comanda.Length;
                string comand_modified = comanda.Substring(0, Text_length - 4);
                comanda = string.Copy(comand_modified);
            }

            string connect2 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
            SqlConnection cnn2 = new SqlConnection(connect2);
            cnn2.Open();
            SqlDataAdapter da2 = new SqlDataAdapter(comanda, connect2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "Situatie_Studenti");
            dataGridView1.DataSource = ds2.Tables["Situatie_Studenti"].DefaultView;
            cnn2.Close();

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
