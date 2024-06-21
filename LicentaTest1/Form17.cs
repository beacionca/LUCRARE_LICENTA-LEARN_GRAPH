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

namespace LicentaTest1
{
    
    public partial class Form17 : Form
    {

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

        private int RaspunsCorectAnterior = 0;

        private void VerificareRaspunsCorect(int rezultat)
        {

            if (PozitieRaspunsCorectAnterior == 0)
            {
                if (RadioButton1State == 1)
                {
                    MessageBox.Show("Ati raspuns corect !");
                }
                else
                {
                    MessageBox.Show("Raspuns incorect! \n\nRaspunsul corect este : " + rezultat.ToString());
                }
            }
            else if (PozitieRaspunsCorectAnterior == 1)
            {
                if (RadioButton2State == 1)
                {
                    MessageBox.Show("Ati raspuns corect !");
                }
                else
                {
                    MessageBox.Show("Raspuns incorect! \n\nRaspunsul corect este : " + rezultat.ToString());
                }
            }
            else if (PozitieRaspunsCorectAnterior == 2)
            {
                if (RadioButton3State == 1)
                {
                    MessageBox.Show("Ati raspuns corect !");
                }
                else
                {
                    MessageBox.Show("Raspuns incorect! \n\nRaspunsul corect este : " + rezultat.ToString());
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

        private int PrimMST(int[,] graph)
        {
            int vertices = graph.GetLength(0);
            int[] parent = new int[vertices]; 
            int[] key = new int[vertices]; 
            bool[] mstSet = new bool[vertices]; 

            
            for (int i = 0; i < vertices; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            
            key[0] = 0; 
            parent[0] = -1; 

           
            for (int count = 0; count < vertices - 1; count++)
            {
                
                int u = MinKey(key, mstSet, vertices);

                mstSet[u] = true;

                for (int v = 0; v < vertices; v++)
                {
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }

            int total = CalculateMST(parent, graph, vertices);
            return total;
        }

        private int MinKey(int[] key, bool[] mstSet, int vertices)
        {
            
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < vertices; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }

            return minIndex;
        }

        private void DisplayMST(int[] parent, int[,] graph, int vertices)
        {
            MessageBox.Show("Edge \tWeight\n");
            for (int i = 1; i < vertices; i++)
                MessageBox.Show($"{parent[i] + 1} - {i + 1} \t{graph[i, parent[i]]}\n");
        }

        private int CalculateMST(int[] parent, int[,] graph, int vertices)
        {
            int sum = 0;
            for (int i = 1; i < vertices; i++)
                sum = sum + graph[i, parent[i]];
            return sum;
        }
        public Form17()
        {
            InitializeComponent();
            generatorAleator = new Random();
            caiImagini = new List<string>();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            button1.Text = "INCEPE";
            string text = " Apasati pe butonul INCEPE pentru generarea intrebarilor.\n";
            GenerateDynamicLabel(text, 180, 150);
        }

        private void button1_Click(object sender, EventArgs e)
        {
                button1.Text = "INAINTE";
                if (NumberofQuestion > 1)
                {
                VerificareRaspunsCorect(RaspunsCorectAnterior);
                RadioButton1State = 0;
                RadioButton2State = 0;
                RadioButton3State = 0;
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
                int nod1, nod2, muchie;

                while ((line = sr2.ReadLine()) != null)
                {
                    Edges = line.Split(' ');
                    nod1 = int.Parse(Edges[0]);
                    nod2 = int.Parse(Edges[1]);
                    muchie = int.Parse(Edges[2]);
                    graph2[int.Parse(Edges[0]) - 1, int.Parse(Edges[1]) - 1] = int.Parse(Edges[2]);
                    graph2[int.Parse(Edges[1]) - 1, int.Parse(Edges[0]) - 1] = int.Parse(Edges[2]);
                }

                caiImagini.RemoveAt(indexAleatoriu);
                int rezultat = PrimMST(graph2);

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

                //MessageBox.Show("Pozitie raspuns corect : " + pozitieRaspunsCorect.ToString());
                PozitieRaspunsCorectAnterior = pozitieRaspunsCorect;
                RaspunsCorectAnterior = rezultat;
                NumberofQuestion++;
        }
    }
}
