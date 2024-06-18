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
    public partial class Form27 : Form
    {
        // Dimensiunea maximă a grafului (numărul maxim de noduri)
        // const int MAX_NODES = 100;
        // Valoare specială pentru a reprezenta lipsa unei muchii între două noduri
        int NumberofQuestion = 1;
        const int INF = 0;

        // Matricea de adiacență pentru reprezentarea grafului
        // private static int[,] graph = new int[MAX_NODES, MAX_NODES];

        //private string[] caiImagini;
        private List<string> caiImagini;
        private Random generatorAleator;

        List<RadioButton> dynamicRadioButtonsList = new List<RadioButton>();
        //List<Label> dynamicLabelsList = new List<Label>();

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
                    //MessageBox.Show("punctaj_intrebare" + indexIndexare.ToString() + " = 1");
                    MessageBox.Show("Ati raspuns corect !");
                    //MessageBox.Show("Raspunsul corect a fost selectat");
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

            /*
            Label dynamicLabel = new Label();

            // Setează proprietățile label-ului
            dynamicLabel.Text = text;
            dynamicLabel.Location = new System.Drawing.Point(360, 110); // Setează poziția label-ului pe formă
            dynamicLabel.AutoSize = true; // Auto-ajustează dimensiunea label-ului
            */
            // Adaugă label-ul pe formă
            this.Controls.Add(dynamicLabel);
        }

        private void DeleteDynamicLabel()
        {

            this.Controls.Remove(dynamicLabel);
            /*
            foreach (Label label in dynamicLabelsList)
            {
                this.Controls.Remove(label);
            }
            // Clear the list
            dynamicLabelsList.Clear();
            */

            /*
            if (dynamicLabel != null)
            {
                this.Controls.Remove(dynamicLabel);
                dynamicLabel.Dispose();
                dynamicLabel = null;
            }
            */
        }

        private void GenerateDynamicRadioButtons2(string[] radioButtonLabels)
        {
            // Clear any previously created radio buttons
            ClearDynamicRadioButtons();

            int xPos = 450;
            int yPos = 175;

            for (int i = 0; i < radioButtonLabels.Length; i++)
            {
                /*
                dynamicRadioButton = new RadioButton();
                dynamicRadioButton.Text = radioButtonLabels[i];
                dynamicRadioButton.Location = new System.Drawing.Point(xPos, yPos);
                dynamicRadioButton.Size = new System.Drawing.Size(100, 20);
                */
                //dynamicRadioButton.CheckedChanged += DynamicRadioButton_CheckedChanged


                RadioButton radioButton = new RadioButton();
                radioButton.Text = radioButtonLabels[i];
                radioButton.Location = new System.Drawing.Point(xPos, yPos);
                radioButton.Size = new System.Drawing.Size(100, 20);
                radioButton.CheckedChanged += DynamicRadioButton_CheckedChanged;


                // Add the dynamically created radio button to the list
                dynamicRadioButtonsList.Add(radioButton);

                // Add the radio button to the form's controls
                this.Controls.Add(radioButton);

                yPos += 30; // Increment Y position for next radio button
            }
        }

        private void ClearDynamicRadioButtons()
        {
            // Iterate over the list and remove each radio button from the form's controls
            foreach (RadioButton radioButton in dynamicRadioButtonsList)
            {
                this.Controls.Remove(radioButton);
            }
            // Clear the list
            dynamicRadioButtonsList.Clear();
        }

        private void GenerateDynamicPictureBox(string path)
        {

            dynamicpictureBox = new PictureBox();

            dynamicpictureBox.Location = new System.Drawing.Point(25, 120);
            dynamicpictureBox.Size = new System.Drawing.Size(320, 252);
            this.Controls.Add(dynamicpictureBox);
            dynamicpictureBox.ImageLocation = path;

            /*
            Label dynamicLabel = new Label();

            // Setează proprietățile label-ului
            dynamicLabel.Text = text;
            dynamicLabel.Location = new System.Drawing.Point(360, 110); // Setează poziția label-ului pe formă
            dynamicLabel.AutoSize = true; // Auto-ajustează dimensiunea label-ului
            */
            // Adaugă label-ul pe formă
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
                    // MessageBox.Show("Butonul 1 a fost selectat");
                }
                else if (opt2.ToString() == radioButton.Text)
                {
                    RadioButton2State = 1;
                    //MessageBox.Show("Butonul 2 a fost selectat");
                }
                else if (opt3.ToString() == radioButton.Text)
                {
                    RadioButton3State = 1;
                    //MessageBox.Show("Butonul 3 a fost selectat");
                }

                //MessageBox.Show("RadioButton-ul " + radioButton.Text + " a fost bifat!");
            }
            else
            {
                //MessageBox.Show("RadioButton-ul " + radioButton.Text + " a fost deselectat!");
                if (opt1.ToString() == radioButton.Text)
                {
                    RadioButton1State = 0;
                    // MessageBox.Show("Butonul 1 a fost deselectat");
                }
                else if (opt2.ToString() == radioButton.Text)
                {

                    RadioButton2State = 0;
                    //MessageBox.Show("Butonul 2 a fost deselectat");
                }
                else if (opt3.ToString() == radioButton.Text)
                {

                    RadioButton3State = 0;
                    //MessageBox.Show("Butonul 3 a fost deselectat");
                }
            }
        }

        private int PrimMST(int[,] graph)
        {
            int vertices = graph.GetLength(0);
            int[] parent = new int[vertices]; // Array to store constructed MST
            int[] key = new int[vertices]; // Key values used to pick minimum weight edge
            bool[] mstSet = new bool[vertices]; // To represent set of vertices not yet included in MST

            // Initialize all keys as INFINITE
            for (int i = 0; i < vertices; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            // Always include first 1st vertex in MST.
            key[0] = 0; // Make key 0 so that this vertex is picked as first vertex
            parent[0] = -1; // First node is always root of MST

            // The MST will have V vertices
            for (int count = 0; count < vertices - 1; count++)
            {
                // Pick the minimum key vertex from the set of vertices
                // not yet included in MST
                int u = MinKey(key, mstSet, vertices);

                // Add the picked vertex to the MST Set
                mstSet[u] = true;

                // Update key value and parent index of the adjacent vertices
                // of the picked vertex. Consider only those vertices which are
                // not yet included in MST
                for (int v = 0; v < vertices; v++)
                {
                    // graph[u, v] is non-zero only for adjacent vertices of u
                    // mstSet[v] is false for vertices not yet included in MST
                    // Update the key only if graph[u, v] is smaller than key[v]
                    // For directed graph, we need to ensure that we only consider the edges going out from the current vertex
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }

            // Calculate the total weight of the MST
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
                sum = sum + graph[i, parent[i]];
            return sum;
        }


        public Form27()
        {
            InitializeComponent();
            generatorAleator = new Random();
            caiImagini = new List<string>();
        }

        private void Form27_Load(object sender, EventArgs e)
        {
            button1.Text = "INCEPE";
            string text = " Apasati pe butonul INCEPE pentru generarea intrebarilor.\n";
            GenerateDynamicLabel(text, 180, 150);
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            //InitializeGraph();

            string caleFolderImagini = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\ARBORI_IMAGINI_ORIENTAT\";
            string caleFolderText = @"C:\Users\Beatrice\Desktop\AN III\semestru 2\LICENTA\ARBORI_VALORI_ORIENTAT\";

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

            /*
            PictureBox pictureBox1 = new PictureBox();

            pictureBox1.Location = new System.Drawing.Point(25, 120);
            pictureBox1.Size = new System.Drawing.Size(320, 252);
            this.Controls.Add(pictureBox1);
            */
            DeleteDynamicPictureBox();
            GenerateDynamicPictureBox(caleImagineAleatorie);
            //pictureBox1.ImageLocation = caleImagineAleatorie;


            //pictureBox1.ImageLocation = caleImagineAleatorie;

            string PhotoName = Path.GetFileName(caiImagini[indexAleatoriu]);
            string indexpoza = PhotoName.Substring(0, PhotoName.Length - 4);
            //string indexpoza2 = indexpoza.Replace(".jpg", "");
            string caleFiserText = caleFolderText + indexpoza + ".txt";
            //MessageBox.Show(caleFiserText.ToString());
            StreamReader sr = new StreamReader(caleFiserText);
            StreamReader sr2 = new StreamReader(caleFiserText);
            //string content = File.ReadAllText(caleFolderText);
            //string[] Nodes = File.ReadLines(caleFolderText).First().Split();
            /*
            string FirstLine = sr.ReadLine();
            string[] Nodes = FirstLine.Split();
            */
            /*
            int startNode = int.Parse(Nodes[0]); - de continuat poate
            int endNode = int.Parse(Nodes[1]);
            */

            //string SecondLine = sr.ReadLine();
            //MessageBox.Show(SecondLine);


            string[] Edges_aux;
            string line_aux;
            int nod1_aux, nod2_aux;
            int max_aux = 0;


            while ((line_aux = sr.ReadLine()) != null)
            {
                Edges_aux = line_aux.Split(' ');
                nod1_aux = int.Parse(Edges_aux[0]);
                nod2_aux = int.Parse(Edges_aux[1]);
                //ConstructGraph(int.Parse(Edges_aux[0]), int.Parse(Edges_aux[1]), int.Parse(Edges_aux[2]));
                // Console.WriteLine(Edges[0] + " " + Edges[1] + " " + Edges[2]);
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
            int min = int.MaxValue, max = 0;

            while ((line = sr2.ReadLine()) != null)
            {
                Edges = line.Split(' ');
                nod1 = int.Parse(Edges[0]);
                nod2 = int.Parse(Edges[1]);
                muchie = int.Parse(Edges[2]);
                //ConstructGraph(int.Parse(Edges[0]), int.Parse(Edges[1]), int.Parse(Edges[2]));
                // Console.WriteLine(Edges[0] + " " + Edges[1] + " " + Edges[2]);
                graph2[int.Parse(Edges[0]) - 1, int.Parse(Edges[1]) - 1] = int.Parse(Edges[2]);
                //graph2[int.Parse(Edges[1]) - 1, int.Parse(Edges[0]) - 1] = int.Parse(Edges[2]);
                //MessageBox.Show(nod1.ToString() + " " + nod2.ToString() + " " + muchie.ToString()); 

            }

            caiImagini.RemoveAt(indexAleatoriu);
            int rezultat = PrimMST(graph2);
            //MessageBox.Show(rezultat.ToString());

            int pozitieRaspunsCorect = generatorAleator.Next(0, 3);

            int nrAleator1, nrAleator2;

            do
            {
                nrAleator1 = generatorAleator.Next(-5, 5);
                nrAleator2 = generatorAleator.Next(-5, 5);
            } while ((nrAleator1 == nrAleator2) || (nrAleator1 == 0) || (nrAleator2 == 0));
            //opt1=0, opt2=0, opt3=0;
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
                        if (introdus_aleator == 0) //nu s-a mai introdus o varianta gresita, introducem una cu -
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

            /*
            foreach (Control control in this.Controls)
            {
                if (control is RadioButton)
                {
                    this.Controls.Remove(control);
                    control.Dispose();
                }
            }
            */

            DeleteDynamicLabel();
            string text = " " + NumberofQuestion.ToString() + ". Aplicand algoritmul lui Prim, alegeti care este \nlungimea parcurgerii arborelui de acoperire minima :";
            GenerateDynamicLabel(text, 360, 110);

            //MessageBox.Show(opt1.ToString() + " " + opt2.ToString() + " " + opt3.ToString());
            string[] radioButtonLabels = { opt1.ToString(), opt2.ToString(), opt3.ToString() };
            //string[] radioButtonLabels = { rezultat.ToString(), (rezultat - 1).ToString(), (rezultat + 1).ToString() };
            //string[] radioButtonLabels = { (1* NumberofQuestion).ToString(), (2 * NumberofQuestion).ToString(), (3 * NumberofQuestion).ToString() };
            // GenerateDynamicRadioButtons(radioButtonLabels);

            GenerateDynamicRadioButtons2(radioButtonLabels);

            //CreateRadioButtons(radioButtonLabels);
            /*
                foreach (RadioButton radioButton in dynamicRadioButtonsList)
                {
                    //if (radioButton.Checked) //cand apesi butonul inainte, se creeaza toate forma curenta, ceea ce inseamna ca si butoanele raman deselectate, trebuie facuta ceva variabila globala
                    //{
                        MessageBox.Show("RadioButton-ul " + radioButton.Checked.ToString()+ " este selectat!");

                      //  break; // Oprim iterația după ce găsim un RadioButton selectat
                    //}
                }
            */
            MessageBox.Show("Pozitie raspuns corect : " + pozitieRaspunsCorect.ToString());
            PozitieRaspunsCorectAnterior = pozitieRaspunsCorect;
            RaspunsCorectAnterior = rezultat;
            NumberofQuestion++;
        }
    }
}
