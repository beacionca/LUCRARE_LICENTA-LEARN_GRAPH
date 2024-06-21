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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LicentaTest1
{
    public partial class Form2 : Form
    {

        public string UserEmail { get; private set; }
        public string UserNume { get; private set; }
        public string UserPrenume { get; private set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connect = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            cnn.Open();

            string mail = textBox1.Text;
            string parola = textBox2.Text;

            string sql1 = "select COUNT(*) from Informatii_Utilizatori where [e-mail]= @mail and parola= @parola";
            SqlCommand sc = new SqlCommand(sql1, cnn);
            sc.Parameters.AddWithValue("@mail", mail);
            sc.Parameters.AddWithValue("@parola", parola);
            int rezultatInterogare = Convert.ToInt32(sc.ExecuteScalar());
            sc.ExecuteNonQuery();
            cnn.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();


            if (rezultatInterogare > 0)
            {
                string connect2 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                SqlConnection cnn2 = new SqlConnection(connect2);
                cnn2.Open();
                string sql2 = "select rol from Informatii_Utilizatori where [e-mail]= @mail and parola= @parola";
                SqlCommand sc2 = new SqlCommand(sql2, cnn2);
                sc2.Parameters.AddWithValue("@mail", mail);
                sc2.Parameters.AddWithValue("@parola", parola);
                string rol_utilizator = sc2.ExecuteScalar()?.ToString();
                sc2.ExecuteNonQuery();
                cnn2.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();

                string connect4 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                SqlConnection cnn4 = new SqlConnection(connect4);
                cnn4.Open();
                string sql4 = "select nume from Informatii_Utilizatori where [e-mail]= @mail and parola= @parola";
                string sql5 = "select prenume from Informatii_Utilizatori where [e-mail]= @mail and parola= @parola";
                SqlCommand sc4 = new SqlCommand(sql4, cnn4);
                SqlCommand sc5 = new SqlCommand(sql5, cnn4);
                sc4.Parameters.AddWithValue("@mail", mail);
                sc4.Parameters.AddWithValue("@parola", parola);
                sc5.Parameters.AddWithValue("@mail", mail);
                sc5.Parameters.AddWithValue("@parola", parola);
                string nume = sc4.ExecuteScalar()?.ToString().Replace(" ", "");
                string prenume = sc5.ExecuteScalar()?.ToString().Replace(" ", "");
                sc4.ExecuteNonQuery();
                sc5.ExecuteNonQuery();
                cnn4.Close();

                if ((rol_utilizator.Replace(" ","")).Equals("student"))
                {
                    timer1.Start();
                    this.UserEmail = mail;
                    Form f = new Form3(mail);
                    f.ShowDialog();
                }
                else
                {
                    timer1.Start();
                    this.UserNume = nume;
                    this.UserPrenume = prenume;
                    Form f = new Form15(nume,prenume);
                    f.ShowDialog();
                }
            }
            else
            {
                string connect3 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                SqlConnection cnn3 = new SqlConnection(connect3);
                cnn3.Open();

                string sql3 = "select COUNT(*) from Informatii_Utilizatori where [e-mail]= @mail";
                SqlCommand sc3 = new SqlCommand(sql3, cnn3);
                sc3.Parameters.AddWithValue("@mail", mail);
                int rezultatInterogare_mail = Convert.ToInt32(sc3.ExecuteScalar());
                sc3.ExecuteNonQuery();
                cnn3.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();

                if (rezultatInterogare_mail > 0)
                {
                    MessageBox.Show("Parola incorecta!\n", "Atentionare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Nu exista un cont creat cu acest e-mail!\n", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
