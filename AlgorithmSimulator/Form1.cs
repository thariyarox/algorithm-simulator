using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlgorithmSimulator
{
    public partial class AlgorithmSimulator : Form
    {
        public OutlookBar outlookBar;
        public Random rnd;

        //--------------------------------
        //Variables for Insertion Sort
        double[] IdataArray;
        Label[] ImyLabels;
        int Ilength;
        int Itimer1count = 0;
        int Itimer2count = 0;
        int Itimer3count = 0;
        int Ij = 1;
        int IcurrentIndex = 1;
        int IupElementInitialX;
        int IupElementInitialY;
        int IdownElementInitialX;
        int IdownElementInitialY;
        int ImovingLength = 0;
        bool leftMoved = false;

        //--------------------------------
        //Variables for Bubble Sort
        double[] BdataArray;
        Label[] BmyLabels;
        int Blength = 10;
        int Btimer1count = 0;
        int Btimer2count = 0;
        int BEndingIndex = 9;
        int BcurrentIndex = 0;
        int BupElementInitialX;
        int BupElementInitialY;
        int BdownElementInitialX;
        int BdownElementInitialY;
        int BmovingLength = 0;

        //--------------------------------
        //Variables for Selection Sort
        double[] SdataArray;
        Label[] SmyLabels;
        int Slength;
        //int Stimer1count = 0;
        int Stimer2count = 0;
        int SstartingIndex = 0;
        int ScurrentIndex = 0;
        int SupElementInitialX;
        int SupElementInitialY;
        int SdownElementInitialX;
        int SdownElementInitialY;
        int SmovingLength = 0;
        int SkeyIndex = 0;
        int SpreviousKeyIndex = 0;
        int ScurrentKeyIndex = 0; 

        //********************************************************
        public AlgorithmSimulator()
        {
            InitializeComponent();
            outlookBar = new OutlookBar(tabControlAll);
            outlookBar.Location = new Point(0, 0);
            outlookBar.Size = new Size(100, this.ClientSize.Height);
            outlookBar.BorderStyle = BorderStyle.None;
            Controls.Add(outlookBar);
            outlookBar.Initialize();

            IconPanel iconPanelFile = new IconPanel();
            IconPanel iconPanelInsertionSort = new IconPanel();
            IconPanel iconPanelBubbleSort = new IconPanel();
            IconPanel iconPanelSelectionSort = new IconPanel();
                        
            outlookBar.AddBand("File", iconPanelFile);
            outlookBar.AddBand("Insertion Sort", iconPanelInsertionSort);
            outlookBar.AddBand("Bubble Sort", iconPanelBubbleSort);
            outlookBar.AddBand("Selection Sort", iconPanelSelectionSort);
            
            iconPanelFile.AddIcon("Information", Image.FromFile("information.ico"), new EventHandler(ShowInformation));
            iconPanelFile.AddIcon("Developer", Image.FromFile("about.ico"), new EventHandler(ShowDeveloper));
           
            //adding image icons inside insertion sort algorignm button
            iconPanelInsertionSort.AddIcon("Algorithm", Image.FromFile("algorithm.ico"), new EventHandler(ShowInsertionSortAlgorithm));
            iconPanelInsertionSort.AddIcon("Animation", Image.FromFile("animation.ico"), new EventHandler(ShowInsertionSortAnimationPanel));
            iconPanelInsertionSort.AddIcon("Dry Run", Image.FromFile("dryrun.ico"), new EventHandler(ShowInsertionSortDryRun));

            //adding image icons inside Bubble sort algorignm button
            iconPanelBubbleSort.AddIcon("Algorithm", Image.FromFile("algorithm.ico"), new EventHandler(ShowBubbleSortAlgorithm));
            iconPanelBubbleSort.AddIcon("Animation", Image.FromFile("animation.ico"), new EventHandler(ShowBubbleSortAnimationPanel));
            iconPanelBubbleSort.AddIcon("Dry Run", Image.FromFile("dryrun.ico"), new EventHandler(ShowBubbleSortDryRun));

            //adding image icons inside Selection sort algorignm button
            iconPanelSelectionSort.AddIcon("Algorithm", Image.FromFile("algorithm.ico"), new EventHandler(ShowSelectionSortAlgorithm));
            iconPanelSelectionSort.AddIcon("Animation", Image.FromFile("animation.ico"), new EventHandler(ShowSelectionSortAnimationPanel));
            iconPanelSelectionSort.AddIcon("Dry Run", Image.FromFile("dryrun.ico"), new EventHandler(ShowSelectionSortDryRun));


            outlookBar.SelectBand(0); //Initially Display icons inside File button

            tabControlAll.Visible = true;
            tabControlAll.SendToBack(); //This will send the tab control to back so that outlook bar comes to front. 



        }

        private void AlgorithmSimulator_Load(object sender, EventArgs e)
        {

            rnd = new Random();

            //-----------------------------------------------------------------
            //Insertion Sort Variable Initialization

            Ilength = 10;
            Itimer1count = 0;
            Itimer2count = 0;
            Itimer3count = 0;
            Ij = 1;
            IcurrentIndex = 1;
            ImovingLength = 0;
            leftMoved = false;

            //+++++++++++++++++++++++++++++
            ImyLabels = new Label[] { Ilabel1, Ilabel2, Ilabel3, Ilabel4, Ilabel5, Ilabel6, Ilabel7, Ilabel8, Ilabel9, Ilabel10 };
            Ilength = 10;
            IdataArray = new double[Ilength];

            this.txtIData.Text = "";//clear the textbox


            ImyLabels[0].Text = rnd.Next(0, 100).ToString();
            this.txtIData.AppendText(ImyLabels[0].Text);
            for (int i = 1; i < Ilength; i++)
            {
                ImyLabels[i].Text = rnd.Next(0, 100).ToString();
                this.txtIData.AppendText("," + ImyLabels[i].Text);
            }

            //++++++++++++++++++++++++++++++
            //-----------------------------------------------------------------
            //Bubble Sort Variable Initialization

            Blength = 10;
            Btimer1count = 0;
            Btimer2count = 0;
            BEndingIndex = Blength - 9;
            BcurrentIndex = 0;
            BmovingLength = 0;

            //+++++++++++++++++++++++++++++
            BmyLabels = new Label[] { Blabel1, Blabel2, Blabel3, Blabel4, Blabel5, Blabel6, Blabel7, Blabel8, Blabel9, Blabel10 };
            Blength = 10;
            BdataArray = new double[Blength];

            this.txtBData.Text = "";//clear the textbox


            BmyLabels[0].Text = rnd.Next(0, 100).ToString();
            this.txtBData.AppendText(BmyLabels[0].Text);
            for (int i = 1; i < Blength; i++)
            {
                BmyLabels[i].Text = rnd.Next(0, 100).ToString();
                this.txtBData.AppendText("," + BmyLabels[i].Text);
            }
            //----------------------------------------------------------------
            //Selection Sort Variable Initialization

            Slength = 10;
            //Stimer1count = 0;
            Stimer2count = 0;
            SstartingIndex = 0;
            SmovingLength = 0;
            SkeyIndex = 0;
            SpreviousKeyIndex = 0;
            ScurrentKeyIndex = 0;
            //+++++++++++++++++++++++++++++
            SmyLabels = new Label[] { Slabel1, Slabel2, Slabel3, Slabel4, Slabel5, Slabel6, Slabel7, Slabel8, Slabel9, Slabel10 };
            Slength = 10;
            SdataArray = new double[Slength];

            this.txtSData.Text = "";//clear the textbox


            SmyLabels[0].Text = rnd.Next(0, 100).ToString();
            this.txtSData.AppendText(BmyLabels[0].Text);
            for (int i = 1; i < Slength; i++)
            {
                SmyLabels[i].Text = rnd.Next(0, 100).ToString();
                this.txtSData.AppendText("," + SmyLabels[i].Text);
            }

        }

        //----------------------------------------------------------------------
        // TabControlAll
        //index 0 = tabAlgorithmSimulatorBanner
        //index 1 = tabISAnimation
        //index 2 = tabBSAnimation
        //index 3 = tabSSAnimation
        //index 4 = tabShowAlgorithm
        //index 5 = tabISDryRun
        //index 6 = tabBSDryRun
        //index 7 = tabSSDryRun

        //---------------------------------------------------------------------
        public void ShowInformation(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }
        public void ShowDeveloper(object sender, EventArgs e)
        {
            Developer dv = new Developer();
            dv.Show();
        }
        public void ShowInsertionSortAnimationPanel(object sender, EventArgs e)
        {
            tabControlAll.SelectedIndex = 1; //This will display the Insertion sort animation panel (tabISAnimaiton)
            if (txtIData.Enabled == true)
                txtIData.Focus();
        }
        public void ShowBubbleSortAnimationPanel(object sender, EventArgs e)
        {
            tabControlAll.SelectedIndex = 2; //This will display the Insertion sort animation panel (tabISAnimaiton)
            if (txtBData.Enabled == true)
                txtBData.Focus();
        }
        public void ShowSelectionSortAnimationPanel(object sender, EventArgs e)
        {
            tabControlAll.SelectedIndex = 3; //This will display the Insertion sort animation panel (tabISAnimaiton)
            if (txtSData.Enabled == true)
                txtSData.Focus();
        }
          public void ShowInsertionSortAlgorithm(object sender, EventArgs e)
        {
            
            this.rtbAlgorithmShow.Text = "";//clear the rich text box
            this.rtbAlgorithmShow.AppendText("\n Insertion Sort Algorithm\n");
            this.rtbAlgorithmShow.AppendText(" ------------------------------\n\n");
            this.rtbAlgorithmShow.AppendText(" for j  <--  2 to length(A)\n\n");
            this.rtbAlgorithmShow.AppendText("     do key  <--  A[ j ]\n\n");
            this.rtbAlgorithmShow.AppendText("        i  <--  j - 1\n\n");
            this.rtbAlgorithmShow.AppendText("        while i > 0 and A [ i ] > key\n\n");
            this.rtbAlgorithmShow.AppendText("            do A[ i + 1 ]  <--  A[ i ]\n\n");
            this.rtbAlgorithmShow.AppendText("               i  <--  i -1\n\n");
            this.rtbAlgorithmShow.AppendText("        A [i + 1]  <--  key\n");
            
            tabControlAll.SelectedIndex = 4; //This will display the Insertion sort animation panel (tabISAnimaiton)
            
        }
          public void ShowBubbleSortAlgorithm(object sender, EventArgs e)
          {
              
              this.rtbAlgorithmShow.Text = "";//clear the rich text box
              this.rtbAlgorithmShow.AppendText("\n Bubble Sort Algorithm\n");
              this.rtbAlgorithmShow.AppendText(" ----------------------------\n\n");
              this.rtbAlgorithmShow.AppendText(" size  <--  length(A)\n\n");
              this.rtbAlgorithmShow.AppendText(" for j  <-- 2 to size\n\n");
              this.rtbAlgorithmShow.AppendText("     for i  <-- 1  to size-j\n\n");
              this.rtbAlgorithmShow.AppendText("	  if A[i] > A[i+1]\n\n");
              this.rtbAlgorithmShow.AppendText("		exchange A[i]<-->A[i+1]");
              this.rtbAlgorithmShow.AppendText("\n");
              tabControlAll.SelectedIndex = 4; //This will display the Bubble sort algorithm panel

          }
          public void ShowSelectionSortAlgorithm(object sender, EventArgs e)
          {
              
              this.rtbAlgorithmShow.Text = "";//clear the rich text box
              this.rtbAlgorithmShow.AppendText("\n Selection Sort Algorithm\n");
              this.rtbAlgorithmShow.AppendText(" ------------------------------\n\n");
              this.rtbAlgorithmShow.AppendText(" size  <--  length(A)\n\n");
              this.rtbAlgorithmShow.AppendText(" for j  <--  1 to size\n\n");
              this.rtbAlgorithmShow.AppendText("    minIndex  <--  j\n\n");
              this.rtbAlgorithmShow.AppendText("    for i  <-- j+1 to size\n\n");
              this.rtbAlgorithmShow.AppendText("	   if A[minIndex] > A[i]\n\n");
              this.rtbAlgorithmShow.AppendText("		   minIndex  <--  i\n\n");
              this.rtbAlgorithmShow.AppendText("    exchange A[j]<-->A[minIndex]");
              this.rtbAlgorithmShow.AppendText("\n");
              tabControlAll.SelectedIndex = 4; //This will display the Insertion sort algorithm panel

          }
          public void ShowInsertionSortDryRun(object sender, EventArgs e)
          {
              if (this.txtDataISDR.Text.Equals(""))
              {
                  btnRandomISDR_Click(sender, e);
              }
              tabControlAll.SelectedIndex = 5;
              txtDataISDR.Focus();
          }
          public void ShowBubbleSortDryRun(object sender, EventArgs e)
          {
              if (this.txtDataBSDR.Text.Equals(""))
              {
                  btnRandomBSDR_Click(sender, e);
              }
              tabControlAll.SelectedIndex = 6;
              txtDataBSDR.Focus();
          }
          public void ShowSelectionSortDryRun(object sender, EventArgs e)
          {
              if (this.txtDataSSDR.Text.Equals(""))
              {
                  btnRandomSSDR_Click(sender, e);
              }
              tabControlAll.SelectedIndex = 7;
              txtDataSSDR.Focus();
          }
       
        //**********************************************************
        //INSERTION SORT CODING
        //**********************************************************
        private void btnISort_Click(object sender, EventArgs e)
        {
            //------------------------
            //disabling buttons

            this.btnIRandom.Enabled = false;
            this.btnISort.Enabled = false;
            this.txtIData.Enabled = false;
            this.rdbIAscending.Enabled = false;
            this.rdbIDescending.Enabled = false;

            //--------------------------
            //Resetting the variables for the new sorting
            Itimer1count = 0;
            Itimer2count = 0;
            Itimer3count = 0;
            Ij = 1;
            IcurrentIndex = 1;
            ImovingLength = 0;
            Ilength = 10;
            leftMoved = false;
            ImyLabels = new Label[] { Ilabel1, Ilabel2, Ilabel3, Ilabel4, Ilabel5, Ilabel6, Ilabel7, Ilabel8, Ilabel9, Ilabel10 };

            ImyLabels[0].Location = new Point(92, 50);

            for (int i = 1; i < Ilength; i++)
            {
                ImyLabels[i].Location = new Point(ImyLabels[i - 1].Location.X, ImyLabels[i - 1].Location.Y + 30);
            }

            //--------------------------------------
            string str = this.txtIData.Text;
            string[] strArr = null;


            char[] splitchar = { ',' };
            strArr = str.Split(splitchar);
            Ilength = strArr.Length;

            if (Ilength != 10)
            {
                //Terminate Program
                MessageBox.Show("Please Enter 10 Integers separated by commas", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnIRandom.Enabled = true;
                this.btnISort.Enabled = true;
                this.txtIData.Enabled = true;
                this.rdbIAscending.Enabled = true;
                this.rdbIDescending.Enabled = true;
                Ilength = 10;
                this.txtIData.Focus();
                return;
            }

            IdataArray = new double[Ilength];
            
            for (int i = 0; i < strArr.Length; i++)
            {
                try
                {
                    IdataArray[i] = Int32.Parse(strArr[i].ToString());

                }
                catch (Exception esw)
                {
                    MessageBox.Show("Please Enter 10 Integers separated by commas", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnISort.Enabled = true;
                    btnIRandom.Enabled = true;
                    txtIData.Enabled = true;
                    this.rdbIAscending.Enabled = true;
                    this.rdbIDescending.Enabled = true;
                    this.txtIData.Focus();
                    return; //if the data are not according to the given format exit

                }
            }


            //----------------------------------------
            //setting the speed of the animation
            if (Itimer2Speeder.Value == 0)
                timerI2.Interval = 50;
            else if (Itimer2Speeder.Value == 10)
                timerI2.Interval = 1;
            else
                timerI2.Interval = 20 / Itimer2Speeder.Value;
            //-------------------------------------

            this.lblIStatus.Text = "Sorting Data";


            for (int i = 0; i < Ilength; i++)
            {
                ImyLabels[i].Text = IdataArray[i].ToString();
                ImyLabels[i].BackColor = Color.White;
            }

            lblIJ.Location = new Point(ImyLabels[IcurrentIndex].Location.X - 75, ImyLabels[IcurrentIndex].Location.Y);
            lblII.Location = new Point(ImyLabels[IcurrentIndex - 1].Location.X - 75, ImyLabels[IcurrentIndex - 1].Location.Y);
            this.lblIJ.Visible = true;
            this.lblII.Visible = true;
            timerI1.Start();
        }

        private void timerI1_Tick(object sender, EventArgs e)
        {
            if (Itimer1count == 0) //initially in a round
            {
                if (IcurrentIndex == 0)
                {
                    Ij++;
                    if (Ij == Ilength)//sorting complete. Terminate program
                    {
                        this.lblIJ.Visible = false;
                        this.lblII.Visible = false;
                        this.lblIStatus.Text = "Sorting Complete";
                        this.btnISort.Enabled = true;

                        this.btnIRandom.Enabled = true;
                        this.txtIData.Enabled = true;
                        this.rdbIAscending.Enabled = true;
                        this.rdbIDescending.Enabled = true;
                        ImyLabels[IcurrentIndex].BackColor = Color.White;

                        for (int i = 0; i < Ilength; i++)
                        {

                            ImyLabels[i].BackColor = Color.LightGreen;
                        }
                        timerI1.Stop();
                    }
                    else
                    {

                        IcurrentIndex = Ij;
                        lblIJ.Location = new Point(ImyLabels[IcurrentIndex].Location.X - 75, ImyLabels[IcurrentIndex].Location.Y);
                        lblII.Location = new Point(ImyLabels[IcurrentIndex - 1].Location.X - 75, ImyLabels[IcurrentIndex - 1].Location.Y);

                    }
                }

                if (IcurrentIndex > 0)
                {
                    lblII.Location = new Point(ImyLabels[IcurrentIndex - 1].Location.X - 75, ImyLabels[IcurrentIndex - 1].Location.Y); ;
                    ImyLabels[IcurrentIndex].BackColor = Color.LightPink;
                    ImyLabels[IcurrentIndex - 1].BackColor = Color.Yellow;
                }
            }
            else if (Itimer1count == 1)
            {
                //Acending order
                if (rdbIAscending.Checked == true)
                {
                    if (IdataArray[IcurrentIndex] >= IdataArray[IcurrentIndex - 1])
                    {
                        //No need to swap. Display OK label
                        ImyLabels[IcurrentIndex].BackColor = Color.LightPink;
                        lblIOK.Location = new Point(ImyLabels[IcurrentIndex-1].Location.X + 30, (ImyLabels[IcurrentIndex].Location.Y + ImyLabels[IcurrentIndex - 1].Location.Y) / 2);
                        lblIOK.Visible = true;
                    }
                }
                else //Descending order 
                {
                    if (IdataArray[IcurrentIndex] < IdataArray[IcurrentIndex - 1])
                    {
                        //No need to swap. Display OK label
                        ImyLabels[IcurrentIndex].BackColor = Color.LightPink;
                        lblIOK.Location = new Point(ImyLabels[IcurrentIndex-1].Location.X + 30, (ImyLabels[IcurrentIndex].Location.Y + ImyLabels[IcurrentIndex - 1].Location.Y) / 2);
                        lblIOK.Visible = true;
                    }
                }
            }


            else if (Itimer1count == 3)
            {
                lblIOK.Visible = false;
                //Ascending order sorting
                if (rdbIAscending.Checked == true)
                {
                    if (IdataArray[IcurrentIndex] < IdataArray[IcurrentIndex - 1])
                    {
                        //ImyLabels[IcurrentIndex].BackColor = Color.Red;
                        //now we have to swap these two elements
                        Itimer2count = 0;
                        timerI2.Start();
                        timerI1.Stop();
                    }
                    else
                    {
                        //ImyLabels[IcurrentIndex - 1].BackColor = Color.Red;
                        //self call

                        ImyLabels[IcurrentIndex].BackColor = Color.White;
                        ImyLabels[IcurrentIndex - 1].BackColor = Color.White;
                        //Itimer1count = -1;
                        //IcurrentIndex = 0;
                        //-------------
                        Itimer3count = 0;
                        timerI3.Start();
                        timerI1.Stop();
                        return;

                    }
                }
                else //descending order sorting
                {
                    if (IdataArray[IcurrentIndex] >= IdataArray[IcurrentIndex - 1])
                    {
                        //ImyLabels[IcurrentIndex].BackColor = Color.Red;
                        //now we have to swap these two elements
                        Itimer2count = 0;
                        timerI2.Start();
                        timerI1.Stop();
                    }
                    else
                    {
                        //ImyLabels[IcurrentIndex - 1].BackColor = Color.Red;
                        //self call

                        ImyLabels[IcurrentIndex].BackColor = Color.White;
                        ImyLabels[IcurrentIndex - 1].BackColor = Color.White;
                        //Itimer1count = -1;
                        //IcurrentIndex = 0;
                        //-----------------
                        Itimer3count = 0;
                        timerI3.Start();
                        timerI1.Stop();
                        return;
                    }
                }
            }



            Itimer1count++;
        }

        private void timerI2_Tick(object sender, EventArgs e)
        {
            if (Itimer2count == 0)
            {
                IupElementInitialX = ImyLabels[IcurrentIndex - 1].Location.X;
                IupElementInitialY = ImyLabels[IcurrentIndex - 1].Location.Y;
                IdownElementInitialX = ImyLabels[IcurrentIndex].Location.X;
                IdownElementInitialY = ImyLabels[IcurrentIndex].Location.Y;

                ImovingLength = 50 + (IdownElementInitialY - IupElementInitialY) + 50;
            }
            if (Itimer2count < 50) //move upelement to right, move down element to left
            {

                ImyLabels[IcurrentIndex - 1].Location = new Point(ImyLabels[IcurrentIndex - 1].Location.X + 1, ImyLabels[IcurrentIndex - 1].Location.Y);
                if (leftMoved == false)
                {
                    ImyLabels[IcurrentIndex].Location = new Point(ImyLabels[IcurrentIndex].Location.X - 1, ImyLabels[IcurrentIndex].Location.Y);
                    
                }
            }
            else if (Itimer2count < (50 + IdownElementInitialY - IupElementInitialY)) //move up element down, down element up
            {
                leftMoved = true;
                ImyLabels[IcurrentIndex - 1].Location = new Point(ImyLabels[IcurrentIndex - 1].Location.X, ImyLabels[IcurrentIndex - 1].Location.Y + 1);
                ImyLabels[IcurrentIndex].Location = new Point(ImyLabels[IcurrentIndex].Location.X, ImyLabels[IcurrentIndex].Location.Y - 1);
            }
            else if (Itimer2count < ImovingLength)
            {
                ImyLabels[IcurrentIndex - 1].Location = new Point(ImyLabels[IcurrentIndex - 1].Location.X - 1, ImyLabels[IcurrentIndex - 1].Location.Y);
            }
            else if (Itimer2count == ImovingLength + 2)
            {
                //-------------------------------------------------
                Label temp = ImyLabels[IcurrentIndex];
                ImyLabels[IcurrentIndex] = ImyLabels[IcurrentIndex - 1];
                ImyLabels[IcurrentIndex - 1] = temp;
                //-------------------------------------------------
                double tempdata = IdataArray[IcurrentIndex];
                IdataArray[IcurrentIndex] = IdataArray[IcurrentIndex - 1];
                IdataArray[IcurrentIndex - 1] = tempdata;

                //-------------------------------------------------
                ImyLabels[IcurrentIndex].BackColor = Color.White;

                if (IcurrentIndex == 1)
                    ImyLabels[IcurrentIndex - 1].BackColor = Color.White;
                //call timer 1
                Itimer1count = 0;
                IcurrentIndex--;
                if(IcurrentIndex== 0)
                {
                    Itimer3count = 0;
                    timerI3.Start();
                }
                else
                    timerI1.Start();

                timerI2.Stop();
            }




            Itimer2count++;
        }

        private void btnIRandom_Click(object sender, EventArgs e)
        {
            this.txtIData.Text = "";//clear the textbox

            
            ImyLabels[0].Text = rnd.Next(0, 100).ToString();
            ImyLabels[0].BackColor = Color.White;
            this.txtIData.AppendText(ImyLabels[0].Text);
            for (int i = 1; i < Ilength; i++)
            {
                ImyLabels[i].Text = rnd.Next(0, 100).ToString();
                ImyLabels[i].BackColor = Color.White;
                this.txtIData.AppendText("," + ImyLabels[i].Text);
            }
            txtIData.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            timerI1.Stop();
            timerI2.Stop();
            Ilength = 10;


            this.txtIData.Enabled = true;
            this.txtIData.Text = "";
            ImyLabels = new Label[] { Ilabel1, Ilabel2, Ilabel3, Ilabel4, Ilabel5, Ilabel6, Ilabel7, Ilabel8, Ilabel9, Ilabel10 };
            ImyLabels[0].Location = new Point(92, 50);
            ImyLabels[0].Text = "?";
            ImyLabels[0].BackColor = Color.White;

            for (int i = 1; i < Ilength; i++)
            {
                ImyLabels[i].Text = "?";
                ImyLabels[i].Location = new Point(ImyLabels[i - 1].Location.X, ImyLabels[i - 1].Location.Y + 30);
                ImyLabels[i].BackColor = Color.White;
            }
            lblIStatus.Text = "Sorting";
            lblII.Visible = false;
            lblIJ.Visible = false;
            lblIOK.Visible = false;

            btnIRandom.Enabled = true;
            btnISort.Enabled = true;
            this.rdbIAscending.Enabled = true;
            this.rdbIDescending.Enabled = true;

            //Resetting the variables for the new sorting
            Itimer1count = 0;
            Itimer2count = 0;
            Ij = 1;
            IcurrentIndex = 1;
            ImovingLength = 0;

            txtIData.Focus();
        }

        private void txtIData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnISort_Click(sender, e);
            }
        }

        private void Itimer2Speeder_Scroll(object sender, EventArgs e)
        {
            if (Itimer2Speeder.Value == 0)
                timerI2.Interval = 50;
            else if (Itimer2Speeder.Value == 10)
                timerI2.Interval = 1;
            else
                timerI2.Interval = 20 / Itimer2Speeder.Value;
                            
        }
        private void timerI3_Tick(object sender, EventArgs e)
        {
            if (leftMoved == false)
            {
                Itimer1count = -1;
                IcurrentIndex = 0;
                timerI1.Start();
                timerI3.Stop();
                return;
            }
            if (Itimer3count < 50) //move
            {
                ImyLabels[IcurrentIndex].Location = new Point(ImyLabels[IcurrentIndex].Location.X+1, ImyLabels[IcurrentIndex].Location.Y);
            }
            else if (Itimer3count == 51)
            {
                Itimer1count = -1;
                IcurrentIndex = 0;
                leftMoved = false;
                timerI1.Start();
                timerI3.Stop();
            }
            Itimer3count++;
        }

        //**********************************************************
        //BUBBLE SORT CODING
        //**********************************************************

        private void btnBSort_Click(object sender, EventArgs e)
        {
            //------------------------
            //disabling buttons

            this.btnBRandom.Enabled = false;
            this.btnBSort.Enabled = false;
            this.txtBData.Enabled = false;
            this.rdbBAscending.Enabled = false;
            this.rdbBDescending.Enabled = false;

            //--------------------------
            //Resetting the variables for the new sorting
            Btimer1count = 0;
            Btimer2count = 0;
            BEndingIndex = Blength - 1;
            BcurrentIndex = 0;
            BmovingLength = 0;


            //--------------------------------------
            string str = this.txtBData.Text;
            string[] strArr = null;


            char[] splitchar = { ',' };
            strArr = str.Split(splitchar);
            Blength = strArr.Length;

            if (Blength != 10)
            {
                //Terminate Program
                MessageBox.Show("Please Enter 10 Integers separated by commas", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnBRandom.Enabled = true;
                this.btnBSort.Enabled = true;
                this.txtBData.Enabled = true;
                this.rdbBAscending.Enabled = true;
                this.rdbBDescending.Enabled = true;
                Blength = 10;
                this.txtBData.Focus();
                return;
            }

            BdataArray = new double[Blength];
            BdataArray = new double[Blength];
            for (int i = 0; i < strArr.Length; i++)
            {
                try
                {
                    BdataArray[i] = Int32.Parse(strArr[i].ToString());

                }
                catch (Exception esw)
                {
                    MessageBox.Show("Please Enter 10 Integers separated by commas", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnBSort.Enabled = true;
                    btnBRandom.Enabled = true;
                    txtBData.Enabled = true;
                    this.rdbBAscending.Enabled = true;
                    this.rdbBDescending.Enabled = true;
                    this.txtBData.Focus();
                    return; //if the data are not according to the given format exit

                }
            }


            //----------------------------------------
            //setting the speed of animation
            if (timerB2Speeder.Value == 0)
                timerB2.Interval = 50;
            else if (timerB2Speeder.Value == 10)
                timerB2.Interval = 1;
            else
                timerB2.Interval = 20 / timerB2Speeder.Value;
            //--------------------------------------------------
            this.lblBStatus.Text = "Sorting Data";


            for (int i = 0; i < Blength; i++)
            {
                BmyLabels[i].Text = BdataArray[i].ToString();
                BmyLabels[i].BackColor = Color.White;
            }

            lblBJ.Location = new Point(BmyLabels[BEndingIndex].Location.X - 30, BmyLabels[BEndingIndex].Location.Y);
            lblBI.Location = new Point(BmyLabels[BcurrentIndex].Location.X - 30, BmyLabels[BcurrentIndex].Location.Y);
            this.lblBJ.Visible = true;
            this.lblBI.Visible = true;
            timerB1.Start();    
        }

        private void timerB1_Tick(object sender, EventArgs e)
        {            
            if (Btimer1count == 0) //initially in a round
            {
                if (BcurrentIndex == BEndingIndex)
                {
                    BEndingIndex--;
                    if (BEndingIndex == 0)//sorting complete. Terminate program
                    {
                        this.lblBJ.Visible = false;
                        this.lblBI.Visible = false;
                        this.lblBStatus.Text = "Sorting Complete";
                        this.btnBSort.Enabled = true;

                        this.btnBRandom.Enabled = true;
                        this.txtBData.Enabled = true;
                        this.rdbBAscending.Enabled = true;
                        this.rdbBDescending.Enabled = true;
                        BmyLabels[BcurrentIndex].BackColor = Color.White;

                        for (int i = 0; i < Blength; i++)
                        {

                            BmyLabels[i].BackColor = Color.LightGreen;
                        }
                        timerB1.Stop();
                        return;
                    }
                    else
                    {
                        BcurrentIndex = 0;
                        BmyLabels[BEndingIndex + 1].BackColor = Color.LightGreen;

                        //BcurrentIndex = BEndingIndex;
                        lblBJ.Location = new Point(BmyLabels[BEndingIndex].Location.X - 30, BmyLabels[BEndingIndex].Location.Y);
                        lblBI.Location = new Point(BmyLabels[BcurrentIndex].Location.X - 30, BmyLabels[BcurrentIndex].Location.Y);

                    }
                }

                if (BcurrentIndex >= 0)
                {
                    lblBI.Location = new Point(BmyLabels[BcurrentIndex].Location.X - 30, BmyLabels[BcurrentIndex].Location.Y);
                    BmyLabels[BcurrentIndex].BackColor = Color.LightPink;
                    BmyLabels[BcurrentIndex + 1].BackColor = Color.Yellow;
                }
            }
            else if (Btimer1count == 1)
            {
                //Acending order
                if (rdbBAscending.Checked == true)
                {
                    if (BdataArray[BcurrentIndex] <= BdataArray[BcurrentIndex + 1])
                    {
                        //No need to swap. Display OK label
                        BmyLabels[BcurrentIndex].BackColor = Color.LightPink;
                        lblBOK.Location = new Point(BmyLabels[BcurrentIndex].Location.X + 30, (BmyLabels[BcurrentIndex].Location.Y + BmyLabels[BcurrentIndex + 1].Location.Y) / 2);
                        lblBOK.Visible = true;
                    }
                }
                else //Descending order 
                {
                    if (BdataArray[BcurrentIndex] > BdataArray[BcurrentIndex + 1])
                    {
                        //No need to swap. Display OK label
                        BmyLabels[BcurrentIndex].BackColor = Color.LightPink;
                        lblBOK.Location = new Point(BmyLabels[BcurrentIndex].Location.X + 30, (BmyLabels[BcurrentIndex].Location.Y + BmyLabels[BcurrentIndex + 1].Location.Y) / 2);
                        lblBOK.Visible = true;
                    }
                }
            }


            else if (Btimer1count == 3)
            {
                lblBOK.Visible = false;
                //Ascending order sorting
                if (rdbBAscending.Checked == true)
                {
                    if (BdataArray[BcurrentIndex] > BdataArray[BcurrentIndex + 1])
                    {
                        //BmyLabels[BcurrentIndex].BackColor = Color.Red;
                        //now we have to swap these two elements
                        Btimer2count = 0;
                        timerB2.Start();
                        timerB1.Stop();
                    }
                    else
                    {
                        //BmyLabels[BcurrentIndex - 1].BackColor = Color.Red;
                        //self call

                        BmyLabels[BcurrentIndex].BackColor = Color.White;
                        BmyLabels[BcurrentIndex + 1].BackColor = Color.White;
                        Btimer1count = -1;
                        BcurrentIndex++;
                    }
                }
                else //descending order sorting
                {
                    if (BdataArray[BcurrentIndex] <= BdataArray[BcurrentIndex + 1])
                    {
                        //BmyLabels[BcurrentIndex].BackColor = Color.Red;
                        //now we have to swap these two elements
                        Btimer2count = 0;
                        timerB2.Start();
                        timerB1.Stop();
                    }
                    else
                    {
                        //BmyLabels[BcurrentIndex - 1].BackColor = Color.Red;
                        //self call

                        BmyLabels[BcurrentIndex].BackColor = Color.White;
                        BmyLabels[BcurrentIndex + 1].BackColor = Color.White;
                        Btimer1count = -1;
                        BcurrentIndex++;

                    }
                }
            }



            Btimer1count++;
        }

        private void timerB2_Tick(object sender, EventArgs e)
        {
            if (Btimer2count == 0)
            {
                BupElementInitialX = BmyLabels[BcurrentIndex].Location.X;
                BupElementInitialY = BmyLabels[BcurrentIndex].Location.Y;
                BdownElementInitialX = BmyLabels[BcurrentIndex + 1].Location.X;
                BdownElementInitialY = BmyLabels[BcurrentIndex + 1].Location.Y;

                BmovingLength = 50 + (BdownElementInitialY - BupElementInitialY) + 50;
            }
            if (Btimer2count < 50) //move upelement to right
            {

                BmyLabels[BcurrentIndex].Location = new Point(BmyLabels[BcurrentIndex].Location.X + 1, BmyLabels[BcurrentIndex].Location.Y);
            }
            else if (Btimer2count < (50 + BdownElementInitialY - BupElementInitialY))
            {
                BmyLabels[BcurrentIndex].Location = new Point(BmyLabels[BcurrentIndex].Location.X, BmyLabels[BcurrentIndex].Location.Y + 1);
                BmyLabels[BcurrentIndex + 1].Location = new Point(BmyLabels[BcurrentIndex + 1].Location.X, BmyLabels[BcurrentIndex + 1].Location.Y - 1);
            }
            else if (Btimer2count < BmovingLength)
            {
                BmyLabels[BcurrentIndex].Location = new Point(BmyLabels[BcurrentIndex].Location.X - 1, BmyLabels[BcurrentIndex].Location.Y);
            }
            else if (Btimer2count == BmovingLength + 2)
            {
                //-------------------------------------------------
                Label temp = BmyLabels[BcurrentIndex + 1];
                BmyLabels[BcurrentIndex + 1] = BmyLabels[BcurrentIndex];
                BmyLabels[BcurrentIndex] = temp;
                //-------------------------------------------------
                double tempdata = BdataArray[BcurrentIndex + 1];
                BdataArray[BcurrentIndex + 1] = BdataArray[BcurrentIndex];
                BdataArray[BcurrentIndex] = tempdata;

                //-------------------------------------------------
                BmyLabels[BcurrentIndex].BackColor = Color.White;

                if (BcurrentIndex == BEndingIndex - 1)
                    BmyLabels[BcurrentIndex + 1].BackColor = Color.LightGreen;
                //call timer 1
                Btimer1count = 0;
                BcurrentIndex++;
                timerB1.Start();
                timerB2.Stop();
            }




            Btimer2count++;
        }

        private void btnBRandom_Click(object sender, EventArgs e)
        {
            this.txtBData.Text = "";//clear the textbox

            
            BmyLabels[0].Text = rnd.Next(0, 100).ToString();
            BmyLabels[0].BackColor = Color.White;
            this.txtBData.AppendText(BmyLabels[0].Text);
            for (int i = 1; i < Blength; i++)
            {
                BmyLabels[i].Text = rnd.Next(0, 100).ToString();
                BmyLabels[i].BackColor = Color.White;
                this.txtBData.AppendText("," + BmyLabels[i].Text);
            }
            txtBData.Focus();
        }

        private void btnBClear_Click(object sender, EventArgs e)
        {
            timerB1.Stop();
            timerB2.Stop();

            this.txtBData.Enabled = true;
            this.txtBData.Text = "";
            BmyLabels = new Label[] { Blabel1, Blabel2, Blabel3, Blabel4, Blabel5, Blabel6, Blabel7, Blabel8, Blabel9, Blabel10 };
            BmyLabels[0].Location = new Point(92, 50);
            BmyLabels[0].Text = "?";
            BmyLabels[0].BackColor = Color.White;

            for (int i = 1; i < Blength; i++)
            {
                BmyLabels[i].Text = "?";
                BmyLabels[i].Location = new Point(BmyLabels[i - 1].Location.X, BmyLabels[i - 1].Location.Y + 30);
                BmyLabels[i].BackColor = Color.White;
            }
            lblBStatus.Text = "Sorting";
            lblBI.Visible = false;
            lblBJ.Visible = false;
            lblBOK.Visible = false;

            btnBRandom.Enabled = true;
            btnBSort.Enabled = true;
            this.rdbBAscending.Enabled = true;
            this.rdbBDescending.Enabled = true;

            //Resetting the variables for the new sorting
            Btimer1count = 0;
            Btimer2count = 0;
            BEndingIndex = Blength - 1;
            BcurrentIndex = 0;
            BmovingLength = 0;
            Blength = 10;
            txtBData.Focus();
        }

        private void txtBData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnBSort_Click(sender, e);
            }
        }

        private void timerB2Speeder_Scroll(object sender, EventArgs e)
        {
            if (timerB2Speeder.Value == 0)
                timerB2.Interval = 50;
            else if (timerB2Speeder.Value == 10)
                timerB2.Interval = 1;
            else
                timerB2.Interval = 20 / timerB2Speeder.Value;
        }

        //**********************************************************
        //SELECTION SORT CODING
        //**********************************************************

        private void btnSSort_Click(object sender, EventArgs e)
        {
            if (this.rdbSAscending.Checked == true)
                this.lblSKey.Text = "<- Min";
            else
                this.lblSKey.Text = "<- Max";

            this.lblSStatus.Text = "Sorting Data";
            //------------------------
            //disabling buttons

            this.btnSRandom.Enabled = false;
            this.btnSSort.Enabled = false;
            this.txtSData.Enabled = false;
            this.rdbSAscending.Enabled = false;
            this.rdbSDescending.Enabled = false;

            //--------------------------
            //Resetting the variables for the new sorting
            //Stimer1count = 0;
            Stimer2count = 0;
            SstartingIndex = 0;
            ScurrentIndex = 0;
            SmovingLength = 0;
            SkeyIndex = 0;
            SpreviousKeyIndex = 0;
            ScurrentKeyIndex = 0;

            //--------------------------------------
            string str = this.txtSData.Text;
            string[] strArr = null;


            char[] splitchar = { ',' };
            strArr = str.Split(splitchar);
            Slength = strArr.Length;

            if (Slength != 10)
            {
                //Terminate Program
                MessageBox.Show("Please Enter 10 Integers separated by commas", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnSRandom.Enabled = true;
                this.btnSSort.Enabled = true;
                this.txtSData.Enabled = true;
                this.rdbSAscending.Enabled = true;
                this.rdbSDescending.Enabled = true;
                Slength = 10;
                this.txtSData.Focus();
                return;
            }

            SdataArray = new double[Slength];
            SdataArray = new double[Slength];
            for (int i = 0; i < strArr.Length; i++)
            {
                try
                {
                    SdataArray[i] = Int32.Parse(strArr[i].ToString());

                }
                catch (Exception esw)
                {
                    MessageBox.Show("Please Enter 10 Integers separated by commas", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSSort.Enabled = true;
                    btnSRandom.Enabled = true;
                    txtSData.Enabled = true;
                    this.rdbSAscending.Enabled = true;
                    this.rdbSDescending.Enabled = true;
                    this.txtSData.Focus();
                    return; //if the data are not according to the given format exit

                }
            }


            //----------------------------------------
            if (timerS2Speeder.Value != 0)
                timerS2.Interval = 20 / timerS2Speeder.Value;
            else
                timerS2.Interval = 20;

            this.lblSStatus.Text = "Sorting Data";


            for (int i = 0; i < Slength; i++)
            {
                SmyLabels[i].Text = SdataArray[i].ToString();
                SmyLabels[i].BackColor = Color.White;
            }

            lblSJ.Location = new Point(SmyLabels[SstartingIndex].Location.X - 80, SmyLabels[SstartingIndex].Location.Y);
            //lblII.Location = new Point(SmyLabels[ScurrentIndex].Location.X - 30, SmyLabels[ScurrentIndex].Location.Y);
            this.lblSJ.Visible = true;
            //this.lblII.Visible = true;
            timerS1.Start();
        }

        public int findSKeyIndex(double[] myarray, int startIndex, int endIndex)
        {
            int keyIndexNow = startIndex;

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (this.rdbSAscending.Checked == true) //ascending order sorting
                {
                    if (myarray[i] < myarray[keyIndexNow])
                    {
                        keyIndexNow = i;
                    }
                }
                else //descending order sorting
                {
                    if (myarray[i] > myarray[keyIndexNow])
                    {
                        keyIndexNow = i;
                    }
                }

            }
            return keyIndexNow;

        }

        private void timerS1_Tick(object sender, EventArgs e)
        {
            //Initially starting value is the minimum
            //change the element background to red.
            //move the min label to this element.
            if (ScurrentIndex == SstartingIndex && SstartingIndex == Slength - 1) //sorting complete
            {
                SmyLabels[ScurrentIndex].BackColor = Color.LightGreen;
                //lblSKey.Location = new Point(SmyLabels[ScurrentIndex].Location.X + 100, SmyLabels[ScurrentIndex].Location.Y);
                //lblSJ.Location = new Point(SmyLabels[SstartingIndex].Location.X -50, SmyLabels[ScurrentIndex].Location.Y);
                lblSStatus.Text = "Sorting Complete";
                lblSJ.Visible = false;
                this.rdbSAscending.Enabled = true;
                this.rdbSDescending.Enabled = true;
                this.txtSData.Enabled = true;
                this.btnSRandom.Enabled = true;
                this.btnSSort.Enabled = true;
                this.txtSData.Focus();
                return;
                //lblSKey.Visible = true;
                //lblMinimum.Location = p2;
                //lblMinimum.Visible = true;
            }

            else if (ScurrentIndex == SstartingIndex && SstartingIndex < Slength)
            {
                SpreviousKeyIndex = ScurrentIndex;
                ScurrentKeyIndex = ScurrentIndex;

                SmyLabels[ScurrentIndex].BackColor = Color.Pink;
                lblSKey.Location = new Point(SmyLabels[ScurrentIndex].Location.X + 100, SmyLabels[ScurrentIndex].Location.Y);
                lblSJ.Location = new Point(SmyLabels[SstartingIndex].Location.X - 80, SmyLabels[ScurrentIndex].Location.Y);

                lblSKey.Visible = true;
                //lblMinimum.Location = p2;
                //lblMinimum.Visible = true;
            }
            //------------------------------------------------------------------------------------
            else if (ScurrentIndex < Slength)
            {
                //show the current element with yellow color
                SmyLabels[ScurrentIndex].BackColor = Color.Yellow;

                //find the minimum from the starting index to current index.
                SkeyIndex = findSKeyIndex(SdataArray, SstartingIndex, ScurrentIndex);

                if (SkeyIndex == ScurrentIndex) //current element is the minimum
                {
                    SpreviousKeyIndex = ScurrentKeyIndex;
                    ScurrentKeyIndex = ScurrentIndex;
                    SmyLabels[SpreviousKeyIndex].BackColor = Color.White;
                    SmyLabels[ScurrentIndex].BackColor = Color.Pink;
                    lblSKey.Location = new Point(SmyLabels[ScurrentIndex].Location.X + 100, SmyLabels[ScurrentIndex].Location.Y);

                    lblSKey.Visible = true;
                    //lblMinimum.Location = p2;
                    //lblMinimum.Visible = true;
                }

                if (ScurrentIndex > 1 && (ScurrentIndex - 1) != SkeyIndex)
                    SmyLabels[ScurrentIndex - 1].BackColor = Color.White;


            }
            if (ScurrentIndex == Slength)
            {

                SmyLabels[ScurrentIndex - 1].BackColor = Color.White;
                SmyLabels[SkeyIndex].BackColor = Color.Pink;

                lblSKey.Location = new Point(SmyLabels[SkeyIndex].Location.X + 100, SmyLabels[SkeyIndex].Location.Y);

                lblSKey.Visible = true;
                //lblMinimum.Location = p2;
                //lblMinimum.Visible = true;

            }
            if (ScurrentIndex == Slength + 3)
            {
                Stimer2count = 0;
                if (SstartingIndex == SkeyIndex)//no need to swap
                {
                    lblSOK.Location = new Point(SmyLabels[SstartingIndex].Location.X + 50, SmyLabels[SstartingIndex].Location.Y);
                    lblSOK.Visible = true;
                    SmovingLength = 0;
                }

                if (SstartingIndex < Slength)
                    timerS2.Start();
                lblSKey.Visible = false;
                //this.lblMinimum.Visible = false;
                timerS1.Stop();
                return;
            }
            ScurrentIndex++;
        }

        private void timerS2_Tick(object sender, EventArgs e)
        {
            if (Stimer2count == 0)
            {
                SupElementInitialX = SmyLabels[SstartingIndex].Location.X;
                SupElementInitialY = SmyLabels[SstartingIndex].Location.Y;
                SdownElementInitialX = SmyLabels[SkeyIndex].Location.X;
                SdownElementInitialY = SmyLabels[SkeyIndex].Location.Y;

                SmovingLength = 50 + (SdownElementInitialY - SupElementInitialY) + 50;

            }
            if (SstartingIndex != SkeyIndex)
            {
                if (Stimer2count < 50) //move upelement to right
                {

                    SmyLabels[SstartingIndex].Location = new Point(SmyLabels[SstartingIndex].Location.X + 1, SmyLabels[SstartingIndex].Location.Y);
                    SmyLabels[SkeyIndex].Location = new Point(SmyLabels[SkeyIndex].Location.X - 1, SmyLabels[SkeyIndex].Location.Y);
                }
                else if (Stimer2count < (50 + SdownElementInitialY - SupElementInitialY))
                {
                    SmyLabels[SstartingIndex].Location = new Point(SmyLabels[SstartingIndex].Location.X, SmyLabels[SstartingIndex].Location.Y + 1);
                    SmyLabels[SkeyIndex].Location = new Point(SmyLabels[SkeyIndex].Location.X, SmyLabels[SkeyIndex].Location.Y - 1);
                }
                else if (Stimer2count < SmovingLength)
                {
                    SmyLabels[SstartingIndex].Location = new Point(SmyLabels[SstartingIndex].Location.X - 1, SmyLabels[SstartingIndex].Location.Y);
                    SmyLabels[SkeyIndex].Location = new Point(SmyLabels[SkeyIndex].Location.X + 1, SmyLabels[SkeyIndex].Location.Y);
                }
            }

            if (Stimer2count == SmovingLength + 2)
            {
                lblSOK.Visible = false;
                //-------------------------------------------------
                Label temp = SmyLabels[SstartingIndex];
                SmyLabels[SstartingIndex] = SmyLabels[SkeyIndex];
                SmyLabels[SkeyIndex] = temp;
                //-------------------------------------------------
                double tempdata = SdataArray[SstartingIndex];
                SdataArray[SstartingIndex] = SdataArray[SkeyIndex];
                SdataArray[SkeyIndex] = tempdata;

                //-------------------------------------------------
                SmyLabels[SstartingIndex].BackColor = Color.LightGreen;

                //if (ScurrentIndex == Slength)
                //    SmyLabels[ScurrentIndex - 1].BackColor = Color.LightGreen;
                //call timer 1
                //Stimer1count = 0;
                SstartingIndex++;
                ScurrentIndex = SstartingIndex;
                timerS1.Start();
                timerS2.Stop();
            }




            Stimer2count++;
        }

        private void btnSRandom_Click(object sender, EventArgs e)
        {            
            this.txtSData.Text = "";//clear the textbox
            btnSClear_Click(sender, e);
                        
            SmyLabels[0].Text = rnd.Next(0, 100).ToString();
            SmyLabels[0].BackColor = Color.White;
            this.txtSData.AppendText(SmyLabels[0].Text);
            for (int i = 1; i < Slength; i++)
            {
                SmyLabels[i].Text = rnd.Next(0, 100).ToString();
                SmyLabels[i].BackColor = Color.White;
                this.txtSData.AppendText("," + SmyLabels[i].Text);
            }
            
            txtSData.Focus(); 
        }

        private void btnSClear_Click(object sender, EventArgs e)
        {
            timerS1.Stop();
            timerS2.Stop();

            this.txtSData.Enabled = true;
            this.txtSData.Text = "";
            SmyLabels = new Label[] { Slabel1, Slabel2, Slabel3, Slabel4, Slabel5, Slabel6, Slabel7, Slabel8, Slabel9, Slabel10 };
            SmyLabels[0].Location = new Point(92, 50);
            SmyLabels[0].Text = "?";
            SmyLabels[0].BackColor = Color.White;

            for (int i = 1; i < Slength; i++)
            {
                SmyLabels[i].Text = "?";
                SmyLabels[i].Location = new Point(SmyLabels[i - 1].Location.X, SmyLabels[i - 1].Location.Y + 30);
                SmyLabels[i].BackColor = Color.White;
            }
            lblSStatus.Text = "Sorting Data";
            //lblII.Visible = false;
            lblSJ.Visible = false;
            lblSOK.Visible = false;

            btnSRandom.Enabled = true;
            btnSSort.Enabled = true;
            this.rdbSAscending.Enabled = true;
            this.rdbSDescending.Enabled = true;

            //Resetting the variables for the new sorting
            //Stimer1count = 0;
            Stimer2count = 0;
            SstartingIndex = 0;
            ScurrentIndex = 0;
            SmovingLength = 0;
            Slength = 10;
            txtSData.Focus();
        }

        private void txtSData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnSSort_Click(sender, e);
            }
        }

        private void timerS2Speeder_Scroll(object sender, EventArgs e)
        {
            if (timerS2Speeder.Value == 0)
                timerS2.Interval = 50;
            else if (timerS2Speeder.Value == 10)
                timerS2.Interval = 1;
            else
                timerS2.Interval = 20 / timerS2Speeder.Value;
        }
        //--------------------------------------------------
        //Insertion Sort DRY RUN coding

        private void btnClearISDR_Click(object sender, EventArgs e)
        {
            this.txtDataISDR.Text = "";
            this.rtbISDR.Text = "";
            this.txtDataISDR.Focus();      
        }

        private void btnRandomISDR_Click(object sender, EventArgs e)
        {
            this.txtDataISDR.Text = "";//clear the textbox
            this.txtDataISDR.Text = rnd.Next(1, 100).ToString();            
            for (int i = 1; i < 5; i++)
            {
                this.txtDataISDR.AppendText("," + rnd.Next(1,100).ToString());
            }
            txtDataISDR.Focus();
        }
        private void btnRunISDR_Click(object sender, EventArgs e)
        {
            int lengthISDR = 0;
            double []isdrarray;
            this.rtbISDR.Text = "";//clear the rich text box

            string str = this.txtDataISDR.Text;
            string[] strArr = null;


            char[] splitchar = { ',' };
            strArr = str.Split(splitchar);
            lengthISDR = strArr.Length;

            if (lengthISDR < 5 || lengthISDR > 10)
            {
                MessageBox.Show("Please Enter atleast 5 values separated by commas.\nMaximum number of values is 10.", "Error in Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            isdrarray = new double[lengthISDR]; //creating a double array to hold data
            for (int isdrx = 0; isdrx < lengthISDR; isdrx++)
            {
                try
                {
                    isdrarray[isdrx] = Convert.ToDouble(strArr[isdrx].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Enter atleast 5 values separated by commas.\nMaximum number of values is 10.", "Error in Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            } 
           
            insertionSortDryRunFunction(isdrarray); //call the insertion sorting function
               

        }
        private void insertionSortDryRunFunction(double[] arrayisdr)
        {
            double isdrKey;
            int isdrI;

            rtbISDR.Text = ""; //clear the text in the richtextbox

            rtbISDR.AppendText("----------------------------------------\n");        
            for (int isdrx = 0; isdrx < arrayisdr.Length; isdrx++)
            {
                this.rtbISDR.AppendText(arrayisdr[isdrx].ToString() + " ");            
            }
        
            rtbISDR.AppendText("\n----------------------------------------\n");

            rtbISDR.AppendText(" for j  <-- 2 to " + arrayisdr.Length.ToString() + "\n");            
            for( int isdrJ=1; isdrJ<arrayisdr.Length; isdrJ++)
            {
                isdrKey = arrayisdr[isdrJ];
                rtbISDR.AppendText("     key  <--  " + isdrKey.ToString() + "\n");

                    isdrI = isdrJ-1;
                    rtbISDR.AppendText("     i  <--  " + (isdrI+1).ToString() + "\n");
                    if (this.rdbAscISDR.Checked == true) //Ascending order sorting
                    {
                        rtbISDR.AppendText("     while " + (isdrI + 1).ToString() + " > 0 and " + arrayisdr[isdrI].ToString() + " > " + isdrKey.ToString() + "\n");
                        while (isdrI > -1 && arrayisdr[isdrI] > isdrKey)
                        {
                            arrayisdr[isdrI + 1] = arrayisdr[isdrI];
                            rtbISDR.AppendText("         A[" + (isdrI + 2).ToString() + "]  <--  " + arrayisdr[isdrI].ToString() + "\n");
                            isdrI--;
                            rtbISDR.AppendText("         i  <--  " + (isdrI + 1).ToString() + "\n");

                            try
                            {
                                rtbISDR.AppendText("     while " + (isdrI + 1).ToString() + " > 0 and " + arrayisdr[isdrI].ToString() + " > " + isdrKey.ToString() + "\n");
                            }
                            catch (Exception ex)
                            {
                                rtbISDR.AppendText("     while 0 > 0\n");
                            }

                        }
                    }
                    else //Descending order sorting
                    {                        
                        rtbISDR.AppendText("     while " + (isdrI + 1).ToString() + " > 0 and " + arrayisdr[isdrI].ToString() + " < " + isdrKey.ToString() + "\n");
                        while (isdrI > -1 && arrayisdr[isdrI] < isdrKey)
                        {
                            arrayisdr[isdrI + 1] = arrayisdr[isdrI];
                            rtbISDR.AppendText("         A[" + (isdrI + 2).ToString() + "]  <--  " + arrayisdr[isdrI].ToString() + "\n");
                            isdrI--;
                            rtbISDR.AppendText("         i  <--  " + (isdrI + 1).ToString() + "\n");

                            try
                            {
                                rtbISDR.AppendText("     while " + (isdrI + 1).ToString() + " > 0 and " + arrayisdr[isdrI].ToString() + " < " + isdrKey.ToString() + "\n");
                            }
                            catch (Exception ex)
                            {
                                rtbISDR.AppendText("     while 0 > 0\n");
                            }

                        }
                    }
                    
                    rtbISDR.AppendText("\n");
                    arrayisdr[isdrI+1] = isdrKey;
                    rtbISDR.AppendText("     A[" + (isdrI + 2).ToString() + "]  <-- " + isdrKey.ToString() + "\n\n");

                    rtbISDR.AppendText("----------------------------------------\n");
                    for (int isdrx = 0; isdrx < arrayisdr.Length; isdrx++)
                    {
                        this.rtbISDR.AppendText(arrayisdr[isdrx].ToString() + "  ");
                    }

                    rtbISDR.AppendText("----------------------------------------\n");
                    rtbISDR.AppendText(" for j  <-- "+(isdrJ+2).ToString()+" to " + arrayisdr.Length.ToString() + "\n");
            }
            rtbISDR.AppendText("\n----------------------------------------\n");
            rtbISDR.AppendText(" Sorted Data\n");
                rtbISDR.AppendText("----------------------------------------\n");
            for(int isdrx=0; isdrx<arrayisdr.Length; isdrx++)
            {
                this.rtbISDR.AppendText(arrayisdr[isdrx].ToString() + "  ");
            }
            rtbISDR.AppendText("\n\n");

        }
        private void txtDataISDR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnRunISDR_Click(sender, e);
            }
        }        

        //-------------------------------------------------------------
        //Selection Sort DRY RUN coding
        private void btnClearSSDR_Click(object sender, EventArgs e)
        {
            this.txtDataSSDR.Text = "";
            this.rtbSSDR.Text = "";
            this.txtDataSSDR.Focus();
        }

        private void btnRandomSSDR_Click(object sender, EventArgs e)
        {
            this.txtDataSSDR.Text = "";//clear the textbox
            this.txtDataSSDR.Text = rnd.Next(1, 100).ToString();
            for (int i = 1; i < 5; i++)
            {
                this.txtDataSSDR.AppendText("," + rnd.Next(1, 100).ToString());
            }
            txtDataSSDR.Focus();
        }
        private void btnRunSSDR_Click(object sender, EventArgs e)
        {
            int lengthSSDR = 0;
            double[] ssdrarray;
            this.rtbSSDR.Text = "";//clear the rich text box

            string str = this.txtDataSSDR.Text;
            string[] strArr = null;


            char[] splitchar = { ',' };
            strArr = str.Split(splitchar);
            lengthSSDR = strArr.Length;

            if (lengthSSDR < 5 || lengthSSDR > 10)
            {
                MessageBox.Show("Please Enter atleast 5 values separated by commas.\nMaximum number of values is 10.", "Error in Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ssdrarray = new double[lengthSSDR]; //creating a double array to hold data
            for (int ssdrx = 0; ssdrx < lengthSSDR; ssdrx++)
            {
                try
                {
                    ssdrarray[ssdrx] = Convert.ToDouble(strArr[ssdrx].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Enter atleast 5 values separated by commas.\nMaximum number of values is 10.", "Error in Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            selectionSortDryRunFunction(ssdrarray); //call the selection sorting function
               
        }

        public void selectionSortDryRunFunction(double[] arrayssdr)
        {
            rtbSSDR.Text = ""; //clear the text in the richtextbox

            rtbSSDR.AppendText("----------------------------------------\n");
            for (int ssdrx = 0; ssdrx < arrayssdr.Length; ssdrx++)
            {
                this.rtbSSDR.AppendText(arrayssdr[ssdrx].ToString() + " ");
            }
            rtbSSDR.AppendText("\n----------------------------------------\n");

            rtbSSDR.AppendText(" for j  <-- 1 to " + arrayssdr.Length.ToString() + "\n");
            for (int step = 0; step < arrayssdr.Length - 1; step++)
            {
                if (this.rdbAscSSDR.Checked == true)
                {
                    this.rtbSSDR.AppendText("    minValueIndex  <--  " + (step + 1).ToString() + "\n");
                }
                else
                {
                    this.rtbSSDR.AppendText("    maxValueIndex  <--  " + (step + 1).ToString() + "\n");
                }
                int sminIndex = step;

                this.rtbSSDR.AppendText("     for i  <--  " + (step + 2).ToString() + " to " + arrayssdr.Length.ToString() + "\n");
                for (int sx = step + 1; sx < arrayssdr.Length; sx++)
                {
                    if (this.rdbAscSSDR.Checked == true) //ascending order sorting
                    {
                        this.rtbSSDR.AppendText("          if " + arrayssdr[sminIndex].ToString() + " > " + arrayssdr[sx].ToString() + "\n");
                        if (arrayssdr[sminIndex] > arrayssdr[sx])
                        {
                            this.rtbSSDR.AppendText("              minValueIndex  <--  " + (sx + 1).ToString() + "\n");
                            sminIndex = sx; 
                        }
                    }
                    else //descending order sorting
                    {
                        this.rtbSSDR.AppendText("          if " + arrayssdr[sminIndex].ToString() + " < " + arrayssdr[sx].ToString() + "\n");
                        if (arrayssdr[sminIndex] < arrayssdr[sx])
                        {
                            this.rtbSSDR.AppendText("              maxValueIndex  <--  " + (sx + 1).ToString() + "\n");
                            sminIndex = sx;
                        }
                    }

                    this.rtbSSDR.AppendText("     for i  <--  " + (sx+2).ToString() + " to " + arrayssdr.Length.ToString() + "\n");
                }
                this.rtbSSDR.AppendText("\n     exchange " + arrayssdr[step].ToString() + "  <-->  " + arrayssdr[sminIndex].ToString() + "\n"); 
                 //swap values
                double stemp = arrayssdr[step];
                arrayssdr[step] = arrayssdr[sminIndex];
                arrayssdr[sminIndex] = stemp;

                //print new order of array
                rtbSSDR.AppendText("----------------------------------------\n");
                for (int ssdrx = 0; ssdrx < arrayssdr.Length; ssdrx++)
                {
                    this.rtbSSDR.AppendText(arrayssdr[ssdrx].ToString() + " ");
                }
                rtbSSDR.AppendText("\n----------------------------------------\n");
                           
              

                rtbSSDR.AppendText("_____________________________\n\n");
                rtbSSDR.AppendText(" for j  <-- "+(step+2).ToString()+" to " + arrayssdr.Length.ToString() + "\n");
            }

            rtbSSDR.AppendText("_____________________________");
            rtbSSDR.AppendText("\n----------------------------------------\n");
            rtbSSDR.AppendText(" Sorted Data\n");
            rtbSSDR.AppendText("----------------------------------------\n");
            for (int ssdrx = 0; ssdrx < arrayssdr.Length; ssdrx++)
            {
                this.rtbSSDR.AppendText(arrayssdr[ssdrx].ToString() + "  ");
            }
            rtbSSDR.AppendText("\n\n");
        }
        private void txtDataSSDR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnRunSSDR_Click(sender, e);
            }
        }
        //-----------------------------------------------------------
        //Bubble Sort DRY RUN coding
        private void btnClearBSDR_Click(object sender, EventArgs e)
        {
            this.txtDataBSDR.Text = "";
            this.rtbBSDR.Text = "";
            this.txtDataBSDR.Focus();
        }

        private void btnRandomBSDR_Click(object sender, EventArgs e)
        {
            this.txtDataBSDR.Text = "";//clear the textbox
            this.txtDataBSDR.Text = rnd.Next(1, 100).ToString();
            for (int i = 1; i < 5; i++)
            {
                this.txtDataBSDR.AppendText("," + rnd.Next(1, 100).ToString());
            }
            txtDataBSDR.Focus();
        }

        private void btnRunBSDR_Click(object sender, EventArgs e)
        {
            int lengthBSDR = 0;
            double[] bsdrarray;
            this.rtbBSDR.Text = "";//clear the rich text box

            string str = this.txtDataBSDR.Text;
            string[] strArr = null;


            char[] splitchar = { ',' };
            strArr = str.Split(splitchar);
            lengthBSDR = strArr.Length;

            if (lengthBSDR < 5 || lengthBSDR > 10)
            {
                MessageBox.Show("Please Enter atleast 5 values separated by commas.\nMaximum number of values is 10.", "Error in Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bsdrarray = new double[lengthBSDR]; //creating a double array to hold data
            for (int bsdrx = 0; bsdrx < lengthBSDR; bsdrx++)
            {
                try
                {
                    bsdrarray[bsdrx] = Convert.ToDouble(strArr[bsdrx].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please Enter atleast 5 values separated by commas.\nMaximum number of values is 10.", "Error in Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            bubbleSortDryRunFunction(bsdrarray); //call the bubble sorting function
               
        }
        public void bubbleSortDryRunFunction(double [] arraybsdr)
        {
            rtbBSDR.Text = ""; //clear the text in the richtextbox

            rtbBSDR.AppendText("----------------------------------------\n");
            for (int bsdrx = 0; bsdrx < arraybsdr.Length; bsdrx++)
            {
                this.rtbBSDR.AppendText(arraybsdr[bsdrx].ToString() + " ");
            }

            rtbBSDR.AppendText("\n----------------------------------------\n");

            rtbBSDR.AppendText(" for j  <-- 2 to " + arraybsdr.Length.ToString() + "\n");
            
            for (int pass = 1; pass < arraybsdr.Length; pass++)
            {
                rtbBSDR.AppendText("    for i  <--  1 to " + (arraybsdr.Length - pass).ToString() + "\n");
                for (int bx = 0; bx < arraybsdr.Length - pass; bx++)
                {
                    if (this.rdbAscBSDR.Checked == true) //ascending order sorting
                    {
                        rtbBSDR.AppendText("        if " + arraybsdr[bx].ToString() + " > " + arraybsdr[bx + 1].ToString() + "\n");
                        if (arraybsdr[bx] > arraybsdr[bx + 1])
                        {
                            rtbBSDR.AppendText("            exchange " + arraybsdr[bx].ToString() + " <-->  " + arraybsdr[bx + 1].ToString() + "\n");
                            //swapping values
                            double btemp = arraybsdr[bx];
                            arraybsdr[bx] = arraybsdr[bx + 1];
                            arraybsdr[bx + 1] = btemp;

                            //print the new order of array
                            rtbBSDR.AppendText("\n----------------------------------------\n");
                            for (int bsdrx = 0; bsdrx < arraybsdr.Length; bsdrx++)
                            {
                                this.rtbBSDR.AppendText(arraybsdr[bsdrx].ToString() + " ");
                            }
                            rtbBSDR.AppendText("----------------------------------------\n\n");
                        }
                    }
                    else //descending order sorting
                    {
                        rtbBSDR.AppendText("        if " + arraybsdr[bx].ToString() + " < " + arraybsdr[bx + 1].ToString() + "\n");
                        if (arraybsdr[bx] < arraybsdr[bx + 1])
                        {
                            rtbBSDR.AppendText("            exchange " + arraybsdr[bx].ToString() + " <-->  " + arraybsdr[bx + 1].ToString() + "\n");
                            //swapping values
                            double btemp = arraybsdr[bx];
                            arraybsdr[bx] = arraybsdr[bx + 1];
                            arraybsdr[bx + 1] = btemp;

                            //print the new order of array
                            rtbBSDR.AppendText("\n----------------------------------------\n");
                            for (int bsdrx = 0; bsdrx < arraybsdr.Length; bsdrx++)
                            {
                                this.rtbBSDR.AppendText(arraybsdr[bsdrx].ToString() + " ");
                            }                            
                            rtbBSDR.AppendText("----------------------------------------\n\n");
                        }
                    }                   

                    rtbBSDR.AppendText("    for i  <--  "+(bx+2).ToString()+" to " + (arraybsdr.Length - pass).ToString() + "\n");
                }
                rtbBSDR.AppendText("_____________________________\n\n");
                //rtbBSDR.AppendText("----------------------------------------\n");
            }
            rtbBSDR.AppendText("----------------------------------------");
            rtbBSDR.AppendText(" Sorted Data\n");
            rtbBSDR.AppendText("----------------------------------------\n");
            for (int bsdrx = 0; bsdrx < arraybsdr.Length; bsdrx++)
            {
                this.rtbBSDR.AppendText(arraybsdr[bsdrx].ToString() + "  ");
            }
            rtbBSDR.AppendText("\n\n");
        }

        private void txtDataBSDR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnRunBSDR_Click(sender, e);
            }
        }
    }
}
