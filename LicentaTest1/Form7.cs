using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace LicentaTest1
{
    public partial class Form7 : Form
    {
        private string userEmail;

        int NumberofQuestion = 1;
        const int INF = 0;

        private List<string> caiImagini;
        private Random generatorAleator;

        List<RadioButton> dynamicRadioButtonsList = new List<RadioButton>();

        private PictureBox dynamicpictureBox;
        private Label dynamicLabel;

        private int opt1, opt2, opt3;
        private int RadioButton1State = 0;
        private int RadioButton2State = 0;
        private int RadioButton3State = 0;
        private int PozitieRaspunsCorectAnterior = -1;

        private int punctaj_test = 1; //punct din oficiu

        public Form7(string mail)
        {
            InitializeComponent();
            generatorAleator = new Random();
            caiImagini = new List<string>();
            userEmail = mail;
        }

        private void VerificareRaspunsCorect()
        {
            int indexIndexare = NumberofQuestion - 1;
            if (indexIndexare == 1)
            {
                if (PozitieRaspunsCorectAnterior == 0)
                {
                    if (RadioButton1State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare1] = @punctaj_intrebare1 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare1", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 1)
                {
                    if (RadioButton2State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare1] = @punctaj_intrebare1 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare1", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 2)
                {
                    if (RadioButton3State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare1] = @punctaj_intrebare1 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare1", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
            }
            else if (indexIndexare == 2)
            {
                if (PozitieRaspunsCorectAnterior == 0)
                {
                    if (RadioButton1State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare2] = @punctaj_intrebare2 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare2", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 1)
                {
                    if (RadioButton2State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare2] = @punctaj_intrebare2 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare2", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 2)
                {
                    if (RadioButton3State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare2] = @punctaj_intrebare2 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare2", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
            }
            else if (indexIndexare == 3)
            {
                if (PozitieRaspunsCorectAnterior == 0)
                {
                    if (RadioButton1State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare3] = @punctaj_intrebare3 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare3", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 1)
                {
                    if (RadioButton2State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare3] = @punctaj_intrebare3 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare3", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 2)
                {
                    if (RadioButton3State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare3] = @punctaj_intrebare3 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare3", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
            }
            else if (indexIndexare == 4)
            {
                if (PozitieRaspunsCorectAnterior == 0)
                {
                    if (RadioButton1State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare4] = @punctaj_intrebare4 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare4", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 1)
                {
                    if (RadioButton2State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare4] = @punctaj_intrebare4 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare4", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 2)
                {
                    if (RadioButton3State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare4] = @punctaj_intrebare4 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare4", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
            }
            else if (indexIndexare == 5)
            {
                if (PozitieRaspunsCorectAnterior == 0)
                {
                    if (RadioButton1State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare5] = @punctaj_intrebare5 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare5", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 1)
                {
                    if (RadioButton2State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare5] = @punctaj_intrebare5 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare5", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 2)
                {
                    if (RadioButton3State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare5] = @punctaj_intrebare5 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare5", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
            }
            else if (indexIndexare == 6)
            {
                if (PozitieRaspunsCorectAnterior == 0)
                {
                    if (RadioButton1State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare6] = @punctaj_intrebare6 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare6", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 1)
                {
                    if (RadioButton2State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare6] = @punctaj_intrebare6 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare6", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 2)
                {
                    if (RadioButton3State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare6] = @punctaj_intrebare6 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare6", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
            }
            else if (indexIndexare == 7)
            {
                if (PozitieRaspunsCorectAnterior == 0)
                {
                    if (RadioButton1State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare7] = @punctaj_intrebare7 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare7", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 1)
                {
                    if (RadioButton2State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare7] = @punctaj_intrebare7 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare7", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 2)
                {
                    if (RadioButton3State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare7] = @punctaj_intrebare7 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare7", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
            }
            else if (indexIndexare == 8)
            {
                if (PozitieRaspunsCorectAnterior == 0)
                {
                    if (RadioButton1State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare8] = @punctaj_intrebare8 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare8", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 1)
                {
                    if (RadioButton2State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare8] = @punctaj_intrebare8 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare8", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 2)
                {
                    if (RadioButton3State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare8] = @punctaj_intrebare8 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare8", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
            }
            else if (indexIndexare == 9)
            {
                if (PozitieRaspunsCorectAnterior == 0)
                {
                    if (RadioButton1State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare9] = @punctaj_intrebare9 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare9", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 1)
                {
                    if (RadioButton2State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare9] = @punctaj_intrebare9 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare9", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
                else if (PozitieRaspunsCorectAnterior == 2)
                {
                    if (RadioButton3State == 1)
                    {
                        punctaj_test += 1;
                        string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn1 = new SqlConnection(connect1);
                        cnn1.Open();
                        string sql1 = "update Situatie_Test_Arbori set [punctaj_intrebare9] = @punctaj_intrebare9 where [e-mail]= @mail";
                        SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                        sc1.Parameters.AddWithValue("@mail", userEmail);
                        sc1.Parameters.AddWithValue("@punctaj_intrebare9", 1);
                        sc1.ExecuteNonQuery();
                        cnn1.Close();
                    }
                }
            }
        }


            private void GenerateDynamicLabel(string text, int xPos, int yPos)
            {

             dynamicLabel = new Label();
             dynamicLabel.Text = text;
             dynamicLabel.AutoSize = true;
             dynamicLabel.Location = new System.Drawing.Point(xPos, yPos);

            this.Controls.Add(dynamicLabel);
            }

        private void DeleteDynamicLabel()
        {

            this.Controls.Remove(dynamicLabel);
    
        }

        private void GenerateDynamicRadioButtons2(string[] radioButtonLabels)
        {
 
            ClearDynamicRadioButtons();

            int xPos = 450;
            int yPos = 175;

            for (int i = 0; i < radioButtonLabels.Length; i++)
            {

                RadioButton radioButton = new RadioButton();
                radioButton.Text = radioButtonLabels[i];
                radioButton.Location = new System.Drawing.Point(xPos, yPos);
                radioButton.Size = new System.Drawing.Size(100, 20);
                radioButton.CheckedChanged += DynamicRadioButton_CheckedChanged;

                dynamicRadioButtonsList.Add(radioButton);

                this.Controls.Add(radioButton);

                yPos += 30; 
            }
        }

        private void ClearDynamicRadioButtons()
        {

            foreach (RadioButton radioButton in dynamicRadioButtonsList)
            {
                this.Controls.Remove(radioButton);
            }

            dynamicRadioButtonsList.Clear();
        }

        private void GenerateDynamicPictureBox(string path)
        {

            dynamicpictureBox = new PictureBox();

            dynamicpictureBox.Location = new System.Drawing.Point(25, 120);
            dynamicpictureBox.Size = new System.Drawing.Size(320, 252);
            this.Controls.Add(dynamicpictureBox);
            dynamicpictureBox.ImageLocation = path;

        }

        private void DeleteDynamicPictureBox()
        {

            this.Controls.Remove(dynamicpictureBox);
        }

        private void DynamicRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                if (opt1.ToString() == radioButton.Text)
                {
                    RadioButton1State = 1;
                }
                else if (opt2.ToString() == radioButton.Text)
                {
                    RadioButton2State = 1;
                }
                else if (opt3.ToString() == radioButton.Text)
                {
                    RadioButton3State = 1;
                }
            }
            else
            {
                if (opt1.ToString() == radioButton.Text)
                {
                    RadioButton1State = 0;
                }
                else if (opt2.ToString() == radioButton.Text)
                {

                    RadioButton2State = 0;
                }
                else if (opt3.ToString() == radioButton.Text)
                {

                    RadioButton3State = 0;
                }
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            button1.Text = "INCEPE";
            string text = " Testul consta din 9 intrebari grila din algoritmul Prim.\nUn singur raspuns este corect.\n Fiecare raspuns corect valoreaza 1 punct.\n Apasati pe butonul INCEPE pentru a porni testul.\nMULT SUCCES!\n";
            GenerateDynamicLabel(text, 180, 150);
        }

        private int Prim(int[,] graph)
        {
            int vertices = graph.GetLength(0); // Numărul de vârfuri din graf
            int[] parent = new int[vertices]; // Stochează părinții fiecărui vârf în MST
            int[] key = new int[vertices]; // Valorile cheie pentru a alege muchiile cu greutate minimă
            bool[] mstSet = new bool[vertices]; // Indică dacă un vârf este inclus în MST

            // Inițializează toate valorile cheie la infinit și mstSet la false
            for (int i = 0; i < vertices; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0; // Setează valoarea cheie a primului vârf la 0 pentru a fi ales primul
            parent[0] = -1; // Primul vârf este rădăcina MST

            // Construiește arborele de acoperire minima
            for (int count = 0; count < vertices - 1; count++)
            {
                // Alege vârful cu valoarea cheie minimă din cele care nu sunt încă incluse în MST
                int u = MinKey(key, mstSet, vertices);

                // Adaugă vârful ales în MST
                mstSet[u] = true;

                // Actualizează valorile cheie și părinții vârfurilor adiacente
                for (int v = 0; v < vertices; v++)
                {
                    // Actualizează valoarea cheie doar dacă există o muchie între 'u' și 'v' și este mai mică decât valoarea cheie actuală a lui 'v'
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }

            // Calculează greutatea totală a MST-ului folosind părinții fiecărui vârf
            int total = CalculateMST(parent, graph, vertices);
            return total;
        }

        private int MinKey(int[] key, bool[] mstSet, int vertices)
        {
            // Initialize min value
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < vertices; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }

            return minIndex;
        }

        private int CalculateMST(int[] parent, int[,] graph, int vertices)
        {
            int sum = 0;
            for (int i = 1; i < vertices; i++)
                sum = sum + graph[i,parent[i]];
            return sum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "INAINTE";
            if (NumberofQuestion > 9)
            {
                VerificareRaspunsCorect();
                RadioButton1State = 0;
                RadioButton2State = 0;
                RadioButton3State = 0;
                string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                SqlConnection cnn1 = new SqlConnection(connect1);
                cnn1.Open();
                string sql1 = "update Situatie_Test_Arbori set [nota] = @nota where [e-mail]= @mail";
                SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                sc1.Parameters.AddWithValue("@mail", userEmail);
                sc1.Parameters.AddWithValue("@nota", punctaj_test);
                sc1.ExecuteNonQuery();
                cnn1.Close();
                MessageBox.Show("Ati raspuns la toate cele 9 intrebari ale testului\nNota dumneavoastra este " + punctaj_test + "", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
               

                string connect2 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                SqlConnection cnn2 = new SqlConnection(connect2);
                cnn2.Open();
                string sql2 = "update Situatie_Studenti set [nota_arbori] = @nota_arbori where [e-mail]= @mail";
                SqlCommand sc2 = new SqlCommand(sql2, cnn2);
                sc2.Parameters.AddWithValue("@mail", userEmail);
                sc2.Parameters.AddWithValue("@nota_arbori", punctaj_test);
                sc2.ExecuteNonQuery();
                cnn2.Close();

                string connect3 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                SqlConnection cnn3 = new SqlConnection(connect3);
                cnn3.Open();
                string sql3 = "select nota_grafuri from Situatie_Studenti where [e-mail]= @mail";
                SqlCommand sc3 = new SqlCommand(sql3, cnn3);
                sc3.Parameters.AddWithValue("@mail", userEmail);
                string nota_grafuri = sc3.ExecuteScalar()?.ToString().Replace(" ", "");

                sc3.ExecuteNonQuery();
                cnn3.Close();

                if (int.Parse(nota_grafuri) > 0)
                {
                    float medie = (int.Parse(nota_grafuri) + punctaj_test) / 2;
                    string connect4 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                    SqlConnection cnn4 = new SqlConnection(connect4);
                    cnn4.Open();
                    string sql4 = "update Situatie_Studenti set [medie] = @medie where [e-mail]= @mail";
                    SqlCommand sc4 = new SqlCommand(sql4, cnn4);
                    sc4.Parameters.AddWithValue("@mail", userEmail);
                    sc4.Parameters.AddWithValue("@medie", medie);
                    sc4.ExecuteNonQuery();
                    cnn4.Close();
                }
                this.Close();
            }
            else
            {

                VerificareRaspunsCorect();
                RadioButton1State = 0;
                RadioButton2State = 0;
                RadioButton3State = 0;
                if (NumberofQuestion == 1)
                {
                    string connect1 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                    SqlConnection cnn1 = new SqlConnection(connect1);
                    cnn1.Open();
                    string sql1 = "select nume from Informatii_Utilizatori where [e-mail]= @mail";
                    string sql2 = "select prenume from Informatii_Utilizatori where [e-mail]= @mail";
                    SqlCommand sc1 = new SqlCommand(sql1, cnn1);
                    SqlCommand sc2 = new SqlCommand(sql2, cnn1);
                    sc1.Parameters.AddWithValue("@mail", userEmail);
                    sc2.Parameters.AddWithValue("@mail", userEmail);
                    string nume = sc1.ExecuteScalar()?.ToString().Replace(" ", "");
                    string prenume = sc2.ExecuteScalar()?.ToString().Replace(" ", "");
                    MessageBox.Show(nume + " " + prenume);
                    sc1.ExecuteNonQuery();
                    cnn1.Close();

                    string connect4 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                    SqlConnection cnn4 = new SqlConnection(connect4);
                    cnn4.Open();
                    string sql4 = "select nume from Situatie_Test_Arbori where [e-mail]= @mail";
                    SqlCommand sc4 = new SqlCommand(sql4, cnn4);
                    sc4.Parameters.AddWithValue("@mail", userEmail);
                    string nume_aux = sc4.ExecuteScalar()?.ToString().Replace(" ", "");
                    sc4.ExecuteNonQuery();
                    cnn4.Close();
                    if (!string.IsNullOrEmpty(nume_aux))
                    {
                        MessageBox.Show("Testul a fost deja sustinut!", "Atentionare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {

                        int default_value = 0;
                        DateTime today = DateTime.Today;


                        string connect3 = @"Data Source=DESKTOP-GEVNFAS;Initial Catalog=GRAPHIX;Integrated Security=True";
                        SqlConnection cnn3 = new SqlConnection(connect3);
                        cnn3.Open();
                        string sql3 = "insert into Situatie_Test_Arbori([e-mail], [nume], [prenume], [nota], [punctaj_intrebare1], [punctaj_intrebare2], [punctaj_intrebare3], [punctaj_intrebare4], [punctaj_intrebare5], [punctaj_intrebare6], [punctaj_intrebare7], [punctaj_intrebare8], [punctaj_intrebare9], [data_test]) values (@mail, @nume, @prenume, @nota, @punctaj_intrebare1, @punctaj_intrebare2, @punctaj_intrebare3, @punctaj_intrebare4, @punctaj_intrebare5, @punctaj_intrebare6, @punctaj_intrebare7, @punctaj_intrebare8, @punctaj_intrebare9, @data_test)";
                        SqlCommand sc3 = new SqlCommand(sql3, cnn3);
                        sc3.Parameters.AddWithValue("@mail", userEmail);
                        sc3.Parameters.AddWithValue("@nume", nume);
                        sc3.Parameters.AddWithValue("@prenume", prenume);
                        sc3.Parameters.AddWithValue("@nota", default_value);
                        sc3.Parameters.AddWithValue("@punctaj_intrebare1", default_value);
                        sc3.Parameters.AddWithValue("@punctaj_intrebare2", default_value);
                        sc3.Parameters.AddWithValue("@punctaj_intrebare3", default_value);
                        sc3.Parameters.AddWithValue("@punctaj_intrebare4", default_value);
                        sc3.Parameters.AddWithValue("@punctaj_intrebare5", default_value);
                        sc3.Parameters.AddWithValue("@punctaj_intrebare6", default_value);
                        sc3.Parameters.AddWithValue("@punctaj_intrebare7", default_value);
                        sc3.Parameters.AddWithValue("@punctaj_intrebare8", default_value);
                        sc3.Parameters.AddWithValue("@punctaj_intrebare9", default_value);
                        sc3.Parameters.AddWithValue("@data_test", today);
                        sc3.ExecuteNonQuery();
                        cnn3.Close();
                        MessageBox.Show("Inserare reusita!");
                    }
                }


                string caleFolderImagini = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\ARBORI_IMAGINI";
                string caleFolderText = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\ARBORI_VALORI\";

                if (caiImagini.Count == 0)
                {

                    string[] caiImaginiInitiale = Directory.GetFiles(caleFolderImagini, "*.jpg");
                    caiImagini.AddRange(caiImaginiInitiale);
                }


                if (caiImagini.Count == 0)
                {
                    MessageBox.Show("Nu s-au găsit imagini în folderul specificat.");
                    return;
                }

                int indexAleatoriu = generatorAleator.Next(caiImagini.Count);

                string caleImagineAleatorie = caiImagini[indexAleatoriu];

                DeleteDynamicPictureBox();
                GenerateDynamicPictureBox(caleImagineAleatorie);


                string PhotoName = Path.GetFileName(caiImagini[indexAleatoriu]);
                string indexpoza = PhotoName.Substring(0, PhotoName.Length - 4);
                string caleFiserText = caleFolderText + indexpoza + ".txt";
                StreamReader sr = new StreamReader(caleFiserText);
                StreamReader sr2 = new StreamReader(caleFiserText);


                string[] Edges_aux;
                string line_aux;
                int nod1_aux, nod2_aux;
                int max_aux = 0;


                while ((line_aux = sr.ReadLine()) != null)
                {
                    Edges_aux = line_aux.Split(' ');
                    nod1_aux = int.Parse(Edges_aux[0]);
                    nod2_aux = int.Parse(Edges_aux[1]);
                    if (nod1_aux > max_aux)
                    {
                        max_aux = nod1_aux;
                    }
                    if (nod2_aux > max_aux)
                    {
                        max_aux = nod2_aux;
                    }
                }

                int[,] graph2 = new int[max_aux, max_aux];

                for (int i = 0; i < max_aux; i++)
                {
                    for (int j = 0; j < max_aux; j++)
                    {
                        graph2[i, j] = INF;
                    }
                }


                string[] Edges;
                string line;

                while ((line = sr2.ReadLine()) != null)
                {
                    Edges = line.Split(' ');
                    graph2[int.Parse(Edges[0]) - 1, int.Parse(Edges[1]) - 1] = int.Parse(Edges[2]);
                    graph2[int.Parse(Edges[1]) - 1, int.Parse(Edges[0]) - 1] = int.Parse(Edges[2]);

                }

                caiImagini.RemoveAt(indexAleatoriu);
                int rezultat = Prim(graph2);

                int pozitieRaspunsCorect = generatorAleator.Next(0, 3);

                int nrAleator1, nrAleator2;

                do
                {
                    nrAleator1 = generatorAleator.Next(-5, 5);
                    nrAleator2 = generatorAleator.Next(-5, 5);
                } while ((nrAleator1 == nrAleator2) || (nrAleator1 == 0) || (nrAleator2 == 0));
               
                opt1 = 0;
                opt2 = 0;
                opt3 = 0;
                int introdus_aleator = 0;

                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                    {
                        if (i == pozitieRaspunsCorect)
                        {
                            opt1 = rezultat;
                        }
                        else
                        {
                            opt1 = rezultat + nrAleator1;
                            introdus_aleator++;
                        }
                    }
                    else if (i == 1)
                    {
                        if (i == pozitieRaspunsCorect)
                        {
                            opt2 = rezultat;
                        }
                        else
                        {
                            if (introdus_aleator == 0) 
                            {
                                opt2 = rezultat + nrAleator1;
                            }
                            else
                            {
                                opt2 = rezultat + nrAleator2;
                            }
                            introdus_aleator++;
                        }
                    }
                    else
                    {
                        if (i == pozitieRaspunsCorect)
                        {
                            opt3 = rezultat;
                        }
                        else
                        {
                            opt3 = rezultat + nrAleator2;
                            introdus_aleator++;
                        }
                    }
                }


                DeleteDynamicLabel();
                string text = " " + NumberofQuestion.ToString() + ". Aplicand algoritmul lui Prim, alegeti care este \nlungimea parcurgerii arborelui de acoperire minima :";
                GenerateDynamicLabel(text, 360, 110);

                string[] radioButtonLabels = { opt1.ToString(), opt2.ToString(), opt3.ToString() };


                GenerateDynamicRadioButtons2(radioButtonLabels);

                MessageBox.Show("Pozitie raspuns corect : " + pozitieRaspunsCorect.ToString());
                PozitieRaspunsCorectAnterior = pozitieRaspunsCorect;
                NumberofQuestion++;
            }
        }
    }
}