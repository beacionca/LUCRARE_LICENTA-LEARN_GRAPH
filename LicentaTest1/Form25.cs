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
    public partial class Form25 : Form
    {
        int NumberofQuestion = 1;

        const int MAX_NODES = 100;

        const int INF = int.MaxValue;

        private static int[,] graph = new int[MAX_NODES, MAX_NODES];

        private List<string> caiImagini;
        private Random generatorAleator;

        List<RadioButton> dynamicRadioButtonsList = new List<RadioButton>();

        private Label dynamicLabel;
        private PictureBox dynamicpictureBox;

        private int opt1, opt2, opt3;
        private int RadioButton1State = 0;
        private int RadioButton2State = 0;
        private int RadioButton3State = 0;
        private int PozitieRaspunsCorectAnterior = -1;

        private int RaspunsCorectAnterior = 0;


        private static void InitializeGraph()
        {
            for (int i = 1; i < MAX_NODES; i++)
            {
                for (int j = 1; j < MAX_NODES; j++)
                {
                    graph[i, j] = INF;
                }
            }
        }

        private static void ConstructGraph(int a, int b, int c)
        {
            graph[a, b] = c;
        }

        private static int Dijkstra(int startNode, int endNode)
        {
            int[] distance = new int[MAX_NODES];

            for (int i = 1; i < MAX_NODES; i++)
            {
                distance[i] = INF;
            }
            distance[startNode] = 0;

            bool[] visited = new bool[MAX_NODES];

            for (int count = 1; count < MAX_NODES - 1; count++)
            {

                int minDistance = INF;
                int minIndex = 0;
                for (int i = 1; i < MAX_NODES; i++)
                {
                    if (!visited[i] && distance[i] < minDistance)
                    {
                        minDistance = distance[i];
                        minIndex = i;
                    }
                }

                visited[minIndex] = true;

                for (int i = 1; i < MAX_NODES; i++)
                {
                    if (!visited[i] && graph[minIndex, i] != INF && distance[minIndex] != INF && distance[minIndex] + graph[minIndex, i] < distance[i])
                    {
                        distance[i] = distance[minIndex] + graph[minIndex, i];
                    }
                }
            }
            return distance[endNode];
        }

        private void ClearDynamicRadioButtons()
        {
            foreach (RadioButton radioButton in dynamicRadioButtonsList)
            {
                this.Controls.Remove(radioButton);
            }
            dynamicRadioButtonsList.Clear();
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

        private void ClearRadioButtons()
        {
            foreach (Control control in Controls)
            {
                if (control is RadioButton radioButton)
                {
                    Controls.Remove(radioButton);
                    radioButton.Dispose();
                }
            }
        }

        private int regasit(int x, List<int> listaDistincte)
        {
            int flag = 0;
            foreach (int element in listaDistincte)
            {
                if (x == element) flag = 1;
            }
            return flag;
        }

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

        private void Form25_Load(object sender, EventArgs e)
        {
            button1.Text = "INCEPE";
            string text = " Apasati pe butonul INCEPE pentru generarea intrebarilor.\n";
            GenerateDynamicLabel(text, 180, 150);
        }

        public Form25()
        {
            InitializeComponent();
            generatorAleator = new Random();
            caiImagini = new List<string>();
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
            InitializeGraph();

            string caleFolderImagini = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_IMAGINI_ORIENTATE\";
            string caleFolderText = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\GRAF_VALORI_ORIENTATE\";

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


            string[] Edges;
            string line;
            int nod1, nod2;
            int min = int.MaxValue, max = 0;
            List<int> listaElemente = new List<int>();

            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains("orientat")) break;
                Edges = line.Split(' ');
                nod1 = int.Parse(Edges[0]);
                nod2 = int.Parse(Edges[1]);
                ConstructGraph(int.Parse(Edges[0]), int.Parse(Edges[1]), int.Parse(Edges[2]));
                Console.WriteLine(Edges[0] + " " + Edges[1] + " " + Edges[2]);
                listaElemente.Add(nod1);
                listaElemente.Add(nod2);
                if (nod1 > max)
                {
                    max = nod1;
                }
                if (nod1 < min)
                {
                    min = nod1;
                }
                if (nod2 > max)
                {
                    max = nod2;
                }
                if (nod2 < min)
                {
                    min = nod2;
                }
            }

            int[] vector = listaElemente.ToArray();

            HashSet<int> distincte = new HashSet<int>(vector);

            List<int> listaDistincte = distincte.ToList();


            int startNode;
            int endNode;
            do
            {
                do
                {
                    startNode = generatorAleator.Next(min, max + 1);
                    endNode = generatorAleator.Next(min, max + 1);
                } while (startNode == endNode);
            }while ((regasit(startNode, listaDistincte) == 0) || (regasit(endNode, listaDistincte) == 0)) ;



            caiImagini.RemoveAt(indexAleatoriu);


            int rezultat = Dijkstra(startNode, endNode);

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
            string text = " " + NumberofQuestion.ToString() + ". Aplicand algoritmul Dijkstra, alegeti care este \nlungimea celui mai scurt drum din nodul " + startNode.ToString() + " \npana in nodul " + endNode.ToString() + " :";
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
