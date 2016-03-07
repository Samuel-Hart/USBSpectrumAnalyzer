using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TSA_DLL_TEST
{
    public partial class frmTEST : Form
    {
        IntPtr hDongle;
        Thread Read_Data;

        public frmTEST()
        {
            InitializeComponent();
        }

        void Label_Initialize()
        {
            lblFREQ.Text = "Center Frequency(MHz)";
            lblSTEP.Text = "Step(kHz)";
            lblRBW.Text = "RBW";
            lblPOINTS.Text = "Point Number";
            lblAMP.Text = "Amplitude";
            lblSWEEPTIME.Text = "Sweep Time";
        }

        void ComboBox_Initialize()
        {
            cboRBW.Items.Add("50M");
            cboRBW.Items.Add("100M");
            cboRBW.Items.Add("200M");
            cboRBW.Items.Add("500M");

            cboRBW.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRBW.SelectedIndex = 0;

            for (int i = -60; i <= 0; i = i + 10)
            { cboAMP.Items.Add(i); }

            cboAMP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAMP.SelectedIndex = 6;

            cboSWEEPTIME.Items.Add("x1  (CW Mode)");
            cboSWEEPTIME.Items.Add("x1.5  (Burst Mode)");
            cboSWEEPTIME.Items.Add("x2  (Burst Mode)");
            cboSWEEPTIME.Items.Add("x4  (Burst Mode)");
            cboSWEEPTIME.Items.Add("x8  (Burst Mode)");
            cboSWEEPTIME.Items.Add("x16  (Burst Mode)");
            cboSWEEPTIME.Items.Add("x32  (Burst Mode)");

            cboSWEEPTIME.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSWEEPTIME.SelectedIndex = 0;

        }

        void CheckBox_Initialize()
        {
            chkEXTATT.Text = "30dB External Attenuator";
            chkEXTATT.AutoSize = true;
            chkEXTATT.ThreeState = false;
            chkEXTATT.Checked = false;
        }

        void Button_Initialize()
        {
            btnFINDHID.Text = "Find HID";
            btnSTART.Text = "Start";
            btnSTOP.Text = "Stop";
            btnEXIT.Text = "Exit";
            btnGETSN.Text = "Get SN";
        }

        void TextBox_Initialize()
        {
            txtFREQ.Text = "1000";
            txtSTEP.Text = "10000";
            txtPOINTS.Text = "201";
        }

        void Controls_Font_Initialize()
        {
            lblFREQ.Font = new Font("Times New Roman", 12);
            lblSTEP.Font = lblFREQ.Font;
            lblRBW.Font = lblFREQ.Font;
            lblPOINTS.Font = lblFREQ.Font;
            lblAMP.Font = lblFREQ.Font;
            lblSWEEPTIME.Font = lblFREQ.Font;

            chkEXTATT.Font = lblFREQ.Font;

            txtFREQ.Font = lblFREQ.Font;
            txtSTEP.Font = lblFREQ.Font;
            txtPOINTS.Font = lblFREQ.Font;
            txtRESULT.Font = lblFREQ.Font;

            cboAMP.Font = lblFREQ.Font;
            cboRBW.Font = lblFREQ.Font;
            cboSWEEPTIME.Font = lblFREQ.Font;

            btnFINDHID.Font = lblFREQ.Font;
            btnSTART.Font = lblFREQ.Font;
            btnSTOP.Font = lblFREQ.Font;
            btnEXIT.Font = lblFREQ.Font;
            btnGETSN.Font = lblFREQ.Font;
        }

        void Controls_Location_Initialize()
        {
            btnFINDHID.Height = 30;
            btnFINDHID.Width = 100;
            btnSTART.Size = btnFINDHID.Size;
            btnSTOP.Size = btnFINDHID.Size;
            btnEXIT.Size = btnFINDHID.Size;
            btnGETSN.Size = btnFINDHID.Size;

            int span = (txtRESULT.Size.Width - btnFINDHID.Size.Width * 5) / 4;

            btnFINDHID.Location = new Point(txtRESULT.Location.X, 500);
            btnGETSN.Location = new Point(btnFINDHID.Location.X + btnFINDHID.Size.Width + span, 500);
            btnSTART.Location = new Point(btnGETSN.Location.X + btnGETSN.Size.Width + span, 500);
            btnSTOP.Location = new Point(btnSTART.Location.X + btnSTART.Size.Width + span, 500);
            btnEXIT.Location = new Point(btnSTOP.Location.X + btnSTOP.Size.Width + span, 500);
        }

        String Return_Error_Description(Byte err)
        {
            String Err__Description = "Unknown Error";

            if (0 == err)
            { Err__Description = "Everything is OK!"; }
            else if (1 == err)
            { Err__Description = "To send command fail!"; }
            else if (2 == err)
            { Err__Description = "File is missing!"; }
            else if (3 == err)
            { Err__Description = "File's format is wrong!"; }
            else if (4 == err)
            { Err__Description = "Frequency is wrong!"; }
            else if (5 == err)
            { Err__Description = "Step is wrong!"; }
            else if (6 == err)
            { Err__Description = "RBW is wrong!"; }
            else if (7 == err)
            { Err__Description = "Points number is wrong!"; }
            else if (8 == err)
            { Err__Description = "Amplitude is wrong!"; }
            else if (9 == err)
            { Err__Description = "Sweep Time is wrong!"; }
            else if (10 == err)
            { Err__Description = "External Attenuator is wrong!"; }
            else if (11 == err)
            { Err__Description = "Frequency limit is wrong!"; }
            else if (12 == err)
            { Err__Description = "850MHz frequency is wrong!"; }

            return Err__Description;
        }

        private void frmTEST_Load(object sender, EventArgs e)
        {
            this.Text = "TSA DLL TEST";

            Label_Initialize();
            ComboBox_Initialize();
            CheckBox_Initialize();
            Button_Initialize();
            TextBox_Initialize();
            Controls_Font_Initialize();
            Controls_Location_Initialize();

            CheckForIllegalCrossThreadCalls = false;

        }

        private void btnFINDHID_Click(object sender, EventArgs e)
        {
            hDongle = TSA.Get_Hid_Handle();

            if ((IntPtr)0 == hDongle)
            { txtRESULT.Text = "Can't find USB Dongle!"; }
            else
            { txtRESULT.Text = "Find USB Dongle! The handle is " + hDongle.ToString(); }
        }

        private void btnGETSN_Click(object sender, EventArgs e)
        {
            string DIR_PATH = Application.StartupPath;

            byte[] bytDIR_PATH = System.Text.Encoding.ASCII.GetBytes(DIR_PATH);

            byte[] bytSN = new byte[10];

            Byte x = TSA.Output_Serial_Number(ref bytDIR_PATH[0], ref bytSN[0]);

            if (0 == x)
            { txtRESULT.Text = "Can't find Serial Number!"; }
            else
            {
                string SN = (System.Text.Encoding.ASCII.GetString(bytSN, 0, bytSN.Length)).TrimEnd();
                txtRESULT.Text = "Serial Number is " + SN;
            }
        }

        private void btnSTART_Click(object sender, EventArgs e)
        {
            if ((IntPtr)0 == hDongle)
            { txtRESULT.Text = "Handle is Null"; }
            else
            {
                Double C_FREQ = double.Parse(txtFREQ.Text);
                UInt32 STEP = UInt32.Parse(txtSTEP.Text);
                Byte iRBW = (Byte)(cboRBW.SelectedIndex + 1);
                UInt16 POINTS = UInt16.Parse(txtPOINTS.Text);
                Byte AMP = (Byte)cboAMP.SelectedIndex;
                Byte SWEEP_TIME = (Byte)cboSWEEPTIME.SelectedIndex;
                Byte EXT_ATT = 0;
                if (true == chkEXTATT.Checked)
                { EXT_ATT = 1; }

                string DIR_PATH = Application.StartupPath;

                byte[] bytDIR_PATH = System.Text.Encoding.ASCII.GetBytes(DIR_PATH);

                Byte result = TSA.Start_Dongle(hDongle, C_FREQ, STEP, iRBW, POINTS, AMP, SWEEP_TIME, EXT_ATT, ref bytDIR_PATH[0]);

                if (0 == result)
                {
                    txtRESULT.Text = "Start Dongle";

                    bool Flag;
                    Flag = false;

                    if  ((Read_Data ==null)||(Read_Data.IsAlive == false))
                    {
                        Read_Data = new Thread(new ThreadStart(Read_Data_Thread_Start));
                        Read_Data.IsBackground = true;
                        Flag = true;
                    }
                    else
                    {
                        if (Read_Data.ThreadState == ThreadState.Aborted )
                        {Flag = true;}
                    }

                    if (Flag == true) { Read_Data.Start(); }

                    
                }
                else
                { txtRESULT.Text = Return_Error_Description(result); }
            }
        }

        void Read_Data_Thread_Start()
        {
            do
            {
                Read_Data_From_Dongle();
            } while (true);
        }

        void Read_Data_From_Dongle()
        {
            Int32 ID = 0;
            Int32 Data_Length = 0;
            Double[] data = new Double[61];

            Byte result = TSA.Receive_Data_From_Dongle(hDongle, ref ID, ref data[0], ref Data_Length);

            txtRESULT.Text = txtRESULT.Text + Environment.NewLine + "ID:" + ID.ToString();
            txtRESULT.Text = txtRESULT.Text + Environment.NewLine + "Data_Length:" + Data_Length.ToString();
            txtRESULT.Text = txtRESULT.Text + Environment.NewLine + "Data:" + Environment.NewLine;

            for (Byte i = 0; i < Data_Length; i++)
            { txtRESULT.Text = txtRESULT.Text + data[i] + "   "; }

            Write_To_File(ID, Data_Length, data);
        }

        private void Write_To_File(Int32 ID, Int32 Data_Length, Double[] data)
        {
            string FILE_PATH = Application.StartupPath + "\\data.txt";

            if (!File.Exists(FILE_PATH))
            {
                FileStream FS = new FileStream(FILE_PATH, FileMode.Create);

                FS.Close();
                FS.Dispose();
            }

            {
                FileInfo FS = new FileInfo(FILE_PATH);
                StreamWriter SW = FS.AppendText();
                SW.WriteLine("ID:" + ID);
                SW.WriteLine("Data Length:" + Data_Length);
                for (Byte i = 0; i < Data_Length; i++)
                { SW.WriteLine(data[i]); }
                SW.Close();
            }
        }

        private void btnSTOP_Click(object sender, EventArgs e)
        {
            if ((IntPtr)0 == hDongle)
            { txtRESULT.Text = "Handle is Null"; }
            else
            {
                Byte result = TSA.Stop_Dongle(hDongle);
                Read_Data_Thread_Abort();

                if (0 == result)
                { txtRESULT.Text = txtRESULT.Text + Environment.NewLine + "Stop dongle!"; }
                else
                { txtRESULT.Text = Return_Error_Description(result); }
            }
        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {
            Read_Data_Thread_Abort();
            Dispose();
        }

        private void frmTEST_FormClosing(object sender, FormClosingEventArgs e)
        {
            Read_Data_Thread_Abort();
            Dispose();
        }

        private void Read_Data_Thread_Abort()
        {
            if (Read_Data != null)
            {
                if (Read_Data.ThreadState != ThreadState.Aborted)
                { Read_Data.Abort(); }

            }
 
        }

    }
}
