Public Class frmTEST
    Declare Function Get_Hid_Handle Lib "TSA.dll" () As Int32
    Declare Function Output_Serial_Number Lib "TSA.dll" (ByRef bytDIR_PATH As Byte, ByRef bytSN As Byte) As Byte
    Declare Function Stop_Dongle Lib "TSA.dll" (hDongle As Int32) As Byte
    Declare Function Start_Dongle Lib "TSA.dll" (IhDongle As Int32, C_FREQ As Double, FSTEP As UInt32, iRBW As Byte, POINTS As UInt16, AMP As Byte, SWEEP_TIME As Byte, EXT_ATT As Byte, ByRef bytDIR_PATH As Byte) As Byte
    Declare Function Receive_Data_From_Dongle Lib "TSA.dll" (hDongle As Int32, ByRef ID As Int32, ByRef rev_data As Double, ByRef Data_Length As Int32) As Byte

    Dim hDongle As UInt32
    Dim Read_Data As Threading.Thread

    Private Sub frmTEST_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "TSA DLL TEST"
        Controls_Font_Initialize()
        Label_Initialize()
        TextBox_Initialize()
        Button_Initialize()
        CheckBox_Initialize()
        ComboBox_Initialize()
        Controls_Location_Initialize()

        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Controls_Location_Initialize()

        btnFINDHID.Height = 30
        btnFINDHID.Width = 100
        btnSTART.Size = btnFINDHID.Size
        btnSTOP.Size = btnFINDHID.Size
        btnEXIT.Size = btnFINDHID.Size
        btnGETSN.Size = btnFINDHID.Size

        Dim span As Integer

        span = (txtRESULT.Size.Width - btnFINDHID.Size.Width * 5) / 4

        btnFINDHID.Location = New Point(txtRESULT.Location.X, 500)
        btnGETSN.Location = New Point(btnFINDHID.Location.X + btnFINDHID.Size.Width + span, 500)
        btnSTART.Location = New Point(btnGETSN.Location.X + btnGETSN.Size.Width + span, 500)
        btnSTOP.Location = New Point(btnSTART.Location.X + btnSTART.Size.Width + span, 500)
        btnEXIT.Location = New Point(btnSTOP.Location.X + btnSTOP.Size.Width + span, 500)
    End Sub

    Private Sub Controls_Font_Initialize()
        lblFREQ.Font = New Font("Times New Roman", 12)
        lblSTEP.Font = lblFREQ.Font
        lblRBW.Font = lblFREQ.Font
        lblPOINTS.Font = lblFREQ.Font
        lblAMP.Font = lblFREQ.Font
        lblSWEEPTIME.Font = lblFREQ.Font

        chkEXTATT.Font = lblFREQ.Font

        txtFREQ.Font = lblFREQ.Font
        txtSTEP.Font = lblFREQ.Font
        txtPOINTS.Font = lblFREQ.Font
        txtRESULT.Font = lblFREQ.Font

        cboAMP.Font = lblFREQ.Font
        cboRBW.Font = lblFREQ.Font
        cboSWEEPTIME.Font = lblFREQ.Font

        btnFINDHID.Font = lblFREQ.Font
        btnSTART.Font = lblFREQ.Font
        btnSTOP.Font = lblFREQ.Font
        btnEXIT.Font = lblFREQ.Font
        btnGETSN.Font = lblFREQ.Font

    End Sub

    Private Sub Label_Initialize()
        lblFREQ.Text = "Center Freq(MHz)"
        lblSTEP.Text = "Step (kHz)"
        lblRBW.Text = "RBW"
        lblPOINTS.Text = "Points Number"
        lblAMP.Text = "Amplitude(dBm)"
        lblSWEEPTIME.Text = "Sweep Time"
    End Sub

    Private Sub TextBox_Initialize()
        txtFREQ.Text = "1000"
        txtSTEP.Text = "10000"
        txtPOINTS.Text = "201"
        txtRESULT.Multiline = True
    End Sub

    Private Sub Button_Initialize()
        btnFINDHID.Text = "Find HID"
        btnSTART.Text = "Start"
        btnSTOP.Text = "Stop"
        btnEXIT.Text = "Exit"
        btnGETSN.Text = "Get SN"
    End Sub

    Private Sub CheckBox_Initialize()
        chkEXTATT.ThreeState = False
        chkEXTATT.Checked = False
        chkEXTATT.AutoSize = True
        chkEXTATT.Text = "30dB External Attenuator"
    End Sub

    Private Sub ComboBox_Initialize()
        cboRBW.Items.Add("50M")
        cboRBW.Items.Add("100M")
        cboRBW.Items.Add("200M")
        cboRBW.Items.Add("500M")

        cboRBW.DropDownStyle = ComboBoxStyle.DropDownList
        cboRBW.SelectedIndex = 0

        Dim i As Integer

        For i = -60 To 0 Step 10
            cboAMP.Items.Add(i)
        Next i

        cboAMP.DropDownStyle = ComboBoxStyle.DropDownList
        cboAMP.SelectedIndex = 6

        cboSWEEPTIME.Items.Add("x1  (CW Mode)")
        cboSWEEPTIME.Items.Add("x1.5  (Burst Mode)")
        cboSWEEPTIME.Items.Add("x2  (Burst Mode)")
        cboSWEEPTIME.Items.Add("x4  (Burst Mode)")
        cboSWEEPTIME.Items.Add("x8  (Burst Mode)")
        cboSWEEPTIME.Items.Add("x16  (Burst Mode)")
        cboSWEEPTIME.Items.Add("x32  (Burst Mode)")

        cboSWEEPTIME.DropDownStyle = ComboBoxStyle.DropDownList
        cboSWEEPTIME.SelectedIndex = 0

    End Sub

    Private Function Return_Error_Description(err As Byte) As String

        Dim Err__Description As String

        If 0 = err Then
            Err__Description = "Everything is OK!"
        ElseIf 1 = err Then
            Err__Description = "To send command fail!"
        ElseIf 2 = err Then
            Err__Description = "File is missing!"
        ElseIf 3 = err Then
            Err__Description = "File's format is wrong!"
        ElseIf 4 = err Then
            Err__Description = "Frequency is wrong!"
        ElseIf 5 = err Then
            Err__Description = "Step is wrong!"
        ElseIf 6 = err Then
            Err__Description = "RBW is wrong!"
        ElseIf 7 = err Then
            Err__Description = "Points number is wrong!"
        ElseIf 8 = err Then
            Err__Description = "Amplitude is wrong!"
        ElseIf 9 = err Then
            Err__Description = "Sweep Time is wrong!"
        ElseIf 10 = err Then
            Err__Description = "External Attenuator is wrong!"
        ElseIf 11 = err Then
            Err__Description = "Frequency limit is wrong!"
        ElseIf 12 = err Then
            Err__Description = "850MHz frequency is wrong!"
        Else
            Err__Description = "Unknown Error"
        End If

        Return_Error_Description = Err__Description
    End Function

    Private Sub btnEXIT_Click(sender As Object, e As EventArgs) Handles btnEXIT.Click
        Me.Close()
        Dispose()
    End Sub

    Private Sub btnGETSN_Click(sender As Object, e As EventArgs) Handles btnGETSN.Click
        Dim DIR_PATH As String = Application.StartupPath
        Dim bytSN(9) As Byte
        Dim result As Byte

        Dim bytDIR_PATH() As Byte = System.Text.Encoding.ASCII.GetBytes(DIR_PATH)

        result = Output_Serial_Number(bytDIR_PATH(0), bytSN(0))

        If 0 = result Then
            txtRESULT.Text = "Can't find Serial Number!"
        Else

            Dim SN As String = (System.Text.Encoding.ASCII.GetString(bytSN, 0, bytSN.Length)).TrimEnd()
            txtRESULT.Text = "Serial Number is " + SN
        End If

    End Sub

    Private Sub btnSTART_Click(sender As Object, e As EventArgs) Handles btnSTART.Click
        Dim result As Byte

        If hDongle = 0 Then
            txtRESULT.Text = "The handle is null!"
        Else
            Dim C_FREQ As Double = CDbl(txtFREQ.Text)
            Dim FSTEP As Long= CInt( txtSTEP.Text)
            Dim iRBW As Byte = CByte(cboRBW.SelectedIndex + 1)
            Dim POINTS As UInt16 = UInt16.Parse(txtPOINTS.Text)
            Dim AMP As Byte = CByte(cboAMP.SelectedIndex)
            Dim SWEEP_TIME As Byte = CByte(cboSWEEPTIME.SelectedIndex)
            Dim EXT_ATT As Byte = 0
            If (True = chkEXTATT.Checked) Then
                EXT_ATT = 1
            End If

            Dim DIR_PATH As String = Application.StartupPath

            Dim bytDIR_PATH() As Byte = System.Text.Encoding.ASCII.GetBytes(DIR_PATH)

            result = Start_Dongle(hDongle, C_FREQ, FSTEP, iRBW, POINTS, AMP, SWEEP_TIME, EXT_ATT, bytDIR_PATH(0))

            If result = 0 Then
                txtRESULT.Text = "Start dongle!"
                Read_Data = New Threading.Thread(New Threading.ThreadStart(AddressOf Read_Data_Thread))
                Read_Data.IsBackground = True
                Read_Data.Start()
            Else
                txtRESULT.Text = Return_Error_Description(result)
            End If
        End If
    End Sub

    Private Sub Read_Data_Thread()
        Do
            Read_Data_From_Dongle()
        Loop While (True)

    End Sub


    Private Sub Read_Data_From_Dongle()
        Dim ID As Int32 = 0
        Dim Data_Length As Int32 = 0
        Dim data(60) As Double
        Dim result As Byte

        result = Receive_Data_From_Dongle(hDongle, ID, data(0), Data_Length)

        txtRESULT.Text = txtRESULT.Text + Environment.NewLine + "ID:" + CStr(ID)
        txtRESULT.Text = txtRESULT.Text + Environment.NewLine + "Data_Length:" + CStr(Data_Length)
        txtRESULT.Text = txtRESULT.Text + Environment.NewLine + "Data:" + Environment.NewLine

        Dim i As Integer
        For i = 0 To Data_Length - 1
            txtRESULT.Text = txtRESULT.Text + CStr(data(i)) + "   "
        Next i

    End Sub

    Private Sub btnSTOP_Click(sender As Object, e As EventArgs) Handles btnSTOP.Click
        Dim result As Byte

        If hDongle = 0 Then
            txtRESULT.Text = "The handle is null!"
        Else
            result = Stop_Dongle(hDongle)

            If result = 0 Then
                txtRESULT.Text = txtRESULT.Text + Environment.NewLine + "Stop dongle!"
                Read_Data.Abort()
            Else
                txtRESULT.Text = Return_Error_Description(result)
            End If
        End If
    End Sub

    Private Sub btnFINDHID_Click(sender As System.Object, e As System.EventArgs) Handles btnFINDHID.Click
        hDongle = Get_Hid_Handle()

        If hDongle = 0 Then
            txtRESULT.Text = "Can't find USB Dongle!"
        Else
            txtRESULT.Text = "Find USB Dongle! And the handle is" + CStr(hDongle)
        End If

    End Sub

End Class
