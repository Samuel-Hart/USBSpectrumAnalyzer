<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTEST
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnFINDHID = New System.Windows.Forms.Button()
        Me.btnGETSN = New System.Windows.Forms.Button()
        Me.btnSTART = New System.Windows.Forms.Button()
        Me.btnSTOP = New System.Windows.Forms.Button()
        Me.btnEXIT = New System.Windows.Forms.Button()
        Me.txtRESULT = New System.Windows.Forms.TextBox()
        Me.txtFREQ = New System.Windows.Forms.TextBox()
        Me.txtSTEP = New System.Windows.Forms.TextBox()
        Me.cboRBW = New System.Windows.Forms.ComboBox()
        Me.txtPOINTS = New System.Windows.Forms.TextBox()
        Me.cboAMP = New System.Windows.Forms.ComboBox()
        Me.cboSWEEPTIME = New System.Windows.Forms.ComboBox()
        Me.chkEXTATT = New System.Windows.Forms.CheckBox()
        Me.lblFREQ = New System.Windows.Forms.Label()
        Me.lblSTEP = New System.Windows.Forms.Label()
        Me.lblRBW = New System.Windows.Forms.Label()
        Me.lblPOINTS = New System.Windows.Forms.Label()
        Me.lblAMP = New System.Windows.Forms.Label()
        Me.lblSWEEPTIME = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnFINDHID
        '
        Me.btnFINDHID.Location = New System.Drawing.Point(72, 506)
        Me.btnFINDHID.Name = "btnFINDHID"
        Me.btnFINDHID.Size = New System.Drawing.Size(75, 23)
        Me.btnFINDHID.TabIndex = 0
        Me.btnFINDHID.Text = "Button1"
        Me.btnFINDHID.UseVisualStyleBackColor = True
        '
        'btnGETSN
        '
        Me.btnGETSN.Location = New System.Drawing.Point(175, 506)
        Me.btnGETSN.Name = "btnGETSN"
        Me.btnGETSN.Size = New System.Drawing.Size(75, 23)
        Me.btnGETSN.TabIndex = 1
        Me.btnGETSN.Text = "Button2"
        Me.btnGETSN.UseVisualStyleBackColor = True
        '
        'btnSTART
        '
        Me.btnSTART.Location = New System.Drawing.Point(280, 506)
        Me.btnSTART.Name = "btnSTART"
        Me.btnSTART.Size = New System.Drawing.Size(75, 23)
        Me.btnSTART.TabIndex = 2
        Me.btnSTART.Text = "Button3"
        Me.btnSTART.UseVisualStyleBackColor = True
        '
        'btnSTOP
        '
        Me.btnSTOP.Location = New System.Drawing.Point(382, 505)
        Me.btnSTOP.Name = "btnSTOP"
        Me.btnSTOP.Size = New System.Drawing.Size(75, 23)
        Me.btnSTOP.TabIndex = 3
        Me.btnSTOP.Text = "Button4"
        Me.btnSTOP.UseVisualStyleBackColor = True
        '
        'btnEXIT
        '
        Me.btnEXIT.Location = New System.Drawing.Point(480, 506)
        Me.btnEXIT.Name = "btnEXIT"
        Me.btnEXIT.Size = New System.Drawing.Size(75, 23)
        Me.btnEXIT.TabIndex = 4
        Me.btnEXIT.Text = "Button5"
        Me.btnEXIT.UseVisualStyleBackColor = True
        '
        'txtRESULT
        '
        Me.txtRESULT.Location = New System.Drawing.Point(17, 224)
        Me.txtRESULT.Multiline = True
        Me.txtRESULT.Name = "txtRESULT"
        Me.txtRESULT.Size = New System.Drawing.Size(728, 242)
        Me.txtRESULT.TabIndex = 5
        '
        'txtFREQ
        '
        Me.txtFREQ.Location = New System.Drawing.Point(30, 58)
        Me.txtFREQ.Name = "txtFREQ"
        Me.txtFREQ.Size = New System.Drawing.Size(100, 21)
        Me.txtFREQ.TabIndex = 6
        '
        'txtSTEP
        '
        Me.txtSTEP.Location = New System.Drawing.Point(205, 58)
        Me.txtSTEP.Name = "txtSTEP"
        Me.txtSTEP.Size = New System.Drawing.Size(100, 21)
        Me.txtSTEP.TabIndex = 7
        '
        'cboRBW
        '
        Me.cboRBW.FormattingEnabled = True
        Me.cboRBW.Location = New System.Drawing.Point(382, 59)
        Me.cboRBW.Name = "cboRBW"
        Me.cboRBW.Size = New System.Drawing.Size(121, 20)
        Me.cboRBW.TabIndex = 8
        '
        'txtPOINTS
        '
        Me.txtPOINTS.Location = New System.Drawing.Point(30, 141)
        Me.txtPOINTS.Name = "txtPOINTS"
        Me.txtPOINTS.Size = New System.Drawing.Size(100, 21)
        Me.txtPOINTS.TabIndex = 9
        '
        'cboAMP
        '
        Me.cboAMP.FormattingEnabled = True
        Me.cboAMP.Location = New System.Drawing.Point(205, 141)
        Me.cboAMP.Name = "cboAMP"
        Me.cboAMP.Size = New System.Drawing.Size(121, 20)
        Me.cboAMP.TabIndex = 10
        '
        'cboSWEEPTIME
        '
        Me.cboSWEEPTIME.FormattingEnabled = True
        Me.cboSWEEPTIME.Location = New System.Drawing.Point(382, 141)
        Me.cboSWEEPTIME.Name = "cboSWEEPTIME"
        Me.cboSWEEPTIME.Size = New System.Drawing.Size(155, 20)
        Me.cboSWEEPTIME.TabIndex = 11
        '
        'chkEXTATT
        '
        Me.chkEXTATT.AutoSize = True
        Me.chkEXTATT.Location = New System.Drawing.Point(567, 109)
        Me.chkEXTATT.Name = "chkEXTATT"
        Me.chkEXTATT.Size = New System.Drawing.Size(78, 16)
        Me.chkEXTATT.TabIndex = 12
        Me.chkEXTATT.Text = "CheckBox1"
        Me.chkEXTATT.UseVisualStyleBackColor = True
        '
        'lblFREQ
        '
        Me.lblFREQ.AutoSize = True
        Me.lblFREQ.Location = New System.Drawing.Point(28, 29)
        Me.lblFREQ.Name = "lblFREQ"
        Me.lblFREQ.Size = New System.Drawing.Size(41, 12)
        Me.lblFREQ.TabIndex = 13
        Me.lblFREQ.Text = "Label1"
        '
        'lblSTEP
        '
        Me.lblSTEP.AutoSize = True
        Me.lblSTEP.Location = New System.Drawing.Point(203, 29)
        Me.lblSTEP.Name = "lblSTEP"
        Me.lblSTEP.Size = New System.Drawing.Size(41, 12)
        Me.lblSTEP.TabIndex = 14
        Me.lblSTEP.Text = "Label2"
        '
        'lblRBW
        '
        Me.lblRBW.AutoSize = True
        Me.lblRBW.Location = New System.Drawing.Point(380, 29)
        Me.lblRBW.Name = "lblRBW"
        Me.lblRBW.Size = New System.Drawing.Size(41, 12)
        Me.lblRBW.TabIndex = 15
        Me.lblRBW.Text = "Label3"
        '
        'lblPOINTS
        '
        Me.lblPOINTS.AutoSize = True
        Me.lblPOINTS.Location = New System.Drawing.Point(28, 109)
        Me.lblPOINTS.Name = "lblPOINTS"
        Me.lblPOINTS.Size = New System.Drawing.Size(41, 12)
        Me.lblPOINTS.TabIndex = 16
        Me.lblPOINTS.Text = "Label4"
        '
        'lblAMP
        '
        Me.lblAMP.AutoSize = True
        Me.lblAMP.Location = New System.Drawing.Point(203, 109)
        Me.lblAMP.Name = "lblAMP"
        Me.lblAMP.Size = New System.Drawing.Size(41, 12)
        Me.lblAMP.TabIndex = 17
        Me.lblAMP.Text = "Label5"
        '
        'lblSWEEPTIME
        '
        Me.lblSWEEPTIME.AutoSize = True
        Me.lblSWEEPTIME.Location = New System.Drawing.Point(380, 110)
        Me.lblSWEEPTIME.Name = "lblSWEEPTIME"
        Me.lblSWEEPTIME.Size = New System.Drawing.Size(41, 12)
        Me.lblSWEEPTIME.TabIndex = 18
        Me.lblSWEEPTIME.Text = "Label6"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(72, 506)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmTEST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 564)
        Me.Controls.Add(Me.lblSWEEPTIME)
        Me.Controls.Add(Me.lblAMP)
        Me.Controls.Add(Me.lblPOINTS)
        Me.Controls.Add(Me.lblRBW)
        Me.Controls.Add(Me.lblSTEP)
        Me.Controls.Add(Me.lblFREQ)
        Me.Controls.Add(Me.chkEXTATT)
        Me.Controls.Add(Me.cboSWEEPTIME)
        Me.Controls.Add(Me.cboAMP)
        Me.Controls.Add(Me.txtPOINTS)
        Me.Controls.Add(Me.cboRBW)
        Me.Controls.Add(Me.txtSTEP)
        Me.Controls.Add(Me.txtFREQ)
        Me.Controls.Add(Me.txtRESULT)
        Me.Controls.Add(Me.btnEXIT)
        Me.Controls.Add(Me.btnSTOP)
        Me.Controls.Add(Me.btnSTART)
        Me.Controls.Add(Me.btnGETSN)
        Me.Controls.Add(Me.btnFINDHID)
        Me.Name = "frmTEST"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TSA DLL TEST"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFINDHID As System.Windows.Forms.Button
    Friend WithEvents btnGETSN As System.Windows.Forms.Button
    Friend WithEvents btnSTART As System.Windows.Forms.Button
    Friend WithEvents btnSTOP As System.Windows.Forms.Button
    Friend WithEvents btnEXIT As System.Windows.Forms.Button
    Friend WithEvents txtRESULT As System.Windows.Forms.TextBox
    Friend WithEvents txtFREQ As System.Windows.Forms.TextBox
    Friend WithEvents txtSTEP As System.Windows.Forms.TextBox
    Friend WithEvents cboRBW As System.Windows.Forms.ComboBox
    Friend WithEvents txtPOINTS As System.Windows.Forms.TextBox
    Friend WithEvents cboAMP As System.Windows.Forms.ComboBox
    Friend WithEvents cboSWEEPTIME As System.Windows.Forms.ComboBox
    Friend WithEvents chkEXTATT As System.Windows.Forms.CheckBox
    Friend WithEvents lblFREQ As System.Windows.Forms.Label
    Friend WithEvents lblSTEP As System.Windows.Forms.Label
    Friend WithEvents lblRBW As System.Windows.Forms.Label
    Friend WithEvents lblPOINTS As System.Windows.Forms.Label
    Friend WithEvents lblAMP As System.Windows.Forms.Label
    Friend WithEvents lblSWEEPTIME As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
