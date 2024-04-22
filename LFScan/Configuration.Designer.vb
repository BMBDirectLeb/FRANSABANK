<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuration
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblconnectionStatus = New System.Windows.Forms.Label()
        Me.lblConnectedTo = New System.Windows.Forms.Label()
        Me.btnValidateConnection = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbRepository = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtserverName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.CmbBranchField = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CmbDateField = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CmbTypeField = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CmbScanningDatefld = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbScannedBy = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTemplateName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnQFBrowse = New System.Windows.Forms.Button()
        Me.txtNoneQfPath = New System.Windows.Forms.TextBox()
        Me.txtQFPath = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.closeButton = New System.Windows.Forms.Button()
        Me.loadScanningInterfaceButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addScannerButton = New System.Windows.Forms.Button()
        Me.scannerName = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.documentType = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(516, 212)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblconnectionStatus)
        Me.TabPage1.Controls.Add(Me.lblConnectedTo)
        Me.TabPage1.Controls.Add(Me.btnValidateConnection)
        Me.TabPage1.Controls.Add(Me.txtPassword)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.cmbRepository)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtUserName)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtserverName)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(508, 186)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Connection Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblconnectionStatus
        '
        Me.lblconnectionStatus.AutoSize = True
        Me.lblconnectionStatus.Location = New System.Drawing.Point(6, 119)
        Me.lblconnectionStatus.Name = "lblconnectionStatus"
        Me.lblconnectionStatus.Size = New System.Drawing.Size(94, 13)
        Me.lblconnectionStatus.TabIndex = 10
        Me.lblconnectionStatus.Text = "Connection Status"
        '
        'lblConnectedTo
        '
        Me.lblConnectedTo.AutoSize = True
        Me.lblConnectedTo.Location = New System.Drawing.Point(6, 138)
        Me.lblConnectedTo.Name = "lblConnectedTo"
        Me.lblConnectedTo.Size = New System.Drawing.Size(78, 13)
        Me.lblConnectedTo.TabIndex = 9
        Me.lblConnectedTo.Text = "Connected To:"
        '
        'btnValidateConnection
        '
        Me.btnValidateConnection.Location = New System.Drawing.Point(416, 119)
        Me.btnValidateConnection.Name = "btnValidateConnection"
        Me.btnValidateConnection.Size = New System.Drawing.Size(75, 23)
        Me.btnValidateConnection.TabIndex = 8
        Me.btnValidateConnection.Text = "Connect"
        Me.btnValidateConnection.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(352, 80)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(139, 20)
        Me.txtPassword.TabIndex = 7
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(289, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Password:"
        '
        'cmbRepository
        '
        Me.cmbRepository.FormattingEnabled = True
        Me.cmbRepository.Location = New System.Drawing.Point(352, 39)
        Me.cmbRepository.Name = "cmbRepository"
        Me.cmbRepository.Size = New System.Drawing.Size(139, 21)
        Me.cmbRepository.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(289, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Repository:"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(95, 80)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(139, 20)
        Me.txtUserName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "User Name:"
        '
        'txtserverName
        '
        Me.txtserverName.Location = New System.Drawing.Point(95, 39)
        Me.txtserverName.Name = "txtserverName"
        Me.txtserverName.Size = New System.Drawing.Size(139, 20)
        Me.txtserverName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server Name:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.CmbBranchField)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.CmbDateField)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.CmbTypeField)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.CmbScanningDatefld)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.cmbScannedBy)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.cmbTemplateName)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(508, 186)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Metadata Settings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'CmbBranchField
        '
        Me.CmbBranchField.FormattingEnabled = True
        Me.CmbBranchField.Location = New System.Drawing.Point(359, 29)
        Me.CmbBranchField.Name = "CmbBranchField"
        Me.CmbBranchField.Size = New System.Drawing.Size(139, 21)
        Me.CmbBranchField.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(249, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Branch Field"
        '
        'CmbDateField
        '
        Me.CmbDateField.FormattingEnabled = True
        Me.CmbDateField.Location = New System.Drawing.Point(359, 69)
        Me.CmbDateField.Name = "CmbDateField"
        Me.CmbDateField.Size = New System.Drawing.Size(139, 21)
        Me.CmbDateField.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(249, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Date Field:"
        '
        'CmbTypeField
        '
        Me.CmbTypeField.FormattingEnabled = True
        Me.CmbTypeField.Location = New System.Drawing.Point(97, 69)
        Me.CmbTypeField.Name = "CmbTypeField"
        Me.CmbTypeField.Size = New System.Drawing.Size(139, 21)
        Me.CmbTypeField.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Type Field:"
        '
        'CmbScanningDatefld
        '
        Me.CmbScanningDatefld.FormattingEnabled = True
        Me.CmbScanningDatefld.Location = New System.Drawing.Point(359, 105)
        Me.CmbScanningDatefld.Name = "CmbScanningDatefld"
        Me.CmbScanningDatefld.Size = New System.Drawing.Size(139, 21)
        Me.CmbScanningDatefld.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(249, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Scanning Date Field:"
        '
        'cmbScannedBy
        '
        Me.cmbScannedBy.FormattingEnabled = True
        Me.cmbScannedBy.Location = New System.Drawing.Point(97, 105)
        Me.cmbScannedBy.Name = "cmbScannedBy"
        Me.cmbScannedBy.Size = New System.Drawing.Size(139, 21)
        Me.cmbScannedBy.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Scanned By Field:"
        '
        'cmbTemplateName
        '
        Me.cmbTemplateName.FormattingEnabled = True
        Me.cmbTemplateName.Location = New System.Drawing.Point(97, 29)
        Me.cmbTemplateName.Name = "cmbTemplateName"
        Me.cmbTemplateName.Size = New System.Drawing.Size(139, 21)
        Me.cmbTemplateName.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Template Name:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.ComboBox6)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.ListBox2)
        Me.TabPage3.Controls.Add(Me.Button4)
        Me.TabPage3.Controls.Add(Me.btnQFBrowse)
        Me.TabPage3.Controls.Add(Me.txtNoneQfPath)
        Me.TabPage3.Controls.Add(Me.txtQFPath)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(508, 186)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Documents settings"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(352, 13)
        Me.Label19.TabIndex = 11
        Me.Label19.Text = "Replace the Branch Name by *Branch* and Scanner Name by *Scanner*"
        '
        'ComboBox6
        '
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(352, 101)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(139, 21)
        Me.ComboBox6.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(301, 103)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 13)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Volume:"
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(129, 101)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(140, 69)
        Me.ListBox2.TabIndex = 8
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(466, 62)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(25, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'btnQFBrowse
        '
        Me.btnQFBrowse.Location = New System.Drawing.Point(466, 30)
        Me.btnQFBrowse.Name = "btnQFBrowse"
        Me.btnQFBrowse.Size = New System.Drawing.Size(25, 23)
        Me.btnQFBrowse.TabIndex = 6
        Me.btnQFBrowse.Text = "..."
        Me.btnQFBrowse.UseVisualStyleBackColor = True
        '
        'txtNoneQfPath
        '
        Me.txtNoneQfPath.Location = New System.Drawing.Point(129, 64)
        Me.txtNoneQfPath.Name = "txtNoneQfPath"
        Me.txtNoneQfPath.Size = New System.Drawing.Size(331, 20)
        Me.txtNoneQfPath.TabIndex = 5
        '
        'txtQFPath
        '
        Me.txtQFPath.Location = New System.Drawing.Point(129, 32)
        Me.txtQFPath.Name = "txtQFPath"
        Me.txtQFPath.Size = New System.Drawing.Size(331, 20)
        Me.txtQFPath.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 13)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "QucickFields Types:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(121, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "None QuickFiellds Path:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "QuickFiellds Path:"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Label17)
        Me.TabPage4.Controls.Add(Me.CheckBox1)
        Me.TabPage4.Controls.Add(Me.TextBox6)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.TextBox7)
        Me.TabPage4.Controls.Add(Me.Label15)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(508, 186)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Machine Settings"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 100)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 13)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Branch Name:"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(95, 67)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(95, 97)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(139, 20)
        Me.TextBox6.TabIndex = 11
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "All Branches:"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(95, 29)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(139, 20)
        Me.TextBox7.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 32)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 13)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Scanner Name:"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.closeButton)
        Me.TabPage5.Controls.Add(Me.loadScanningInterfaceButton)
        Me.TabPage5.Controls.Add(Me.saveButton)
        Me.TabPage5.Controls.Add(Me.addScannerButton)
        Me.TabPage5.Controls.Add(Me.scannerName)
        Me.TabPage5.Controls.Add(Me.Label20)
        Me.TabPage5.Controls.Add(Me.documentType)
        Me.TabPage5.Controls.Add(Me.Label18)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(508, 186)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Scanning Settings"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(405, 137)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 3
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'loadScanningInterfaceButton
        '
        Me.loadScanningInterfaceButton.Location = New System.Drawing.Point(14, 137)
        Me.loadScanningInterfaceButton.Name = "loadScanningInterfaceButton"
        Me.loadScanningInterfaceButton.Size = New System.Drawing.Size(147, 23)
        Me.loadScanningInterfaceButton.TabIndex = 22
        Me.loadScanningInterfaceButton.Text = "Load Scanning Interface"
        Me.loadScanningInterfaceButton.UseVisualStyleBackColor = True
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(167, 137)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 23)
        Me.saveButton.TabIndex = 1
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'addScannerButton
        '
        Me.addScannerButton.Location = New System.Drawing.Point(248, 30)
        Me.addScannerButton.Name = "addScannerButton"
        Me.addScannerButton.Size = New System.Drawing.Size(19, 21)
        Me.addScannerButton.TabIndex = 21
        Me.addScannerButton.Text = "+"
        Me.addScannerButton.UseVisualStyleBackColor = True
        '
        'scannerName
        '
        Me.scannerName.FormattingEnabled = True
        Me.scannerName.Location = New System.Drawing.Point(103, 31)
        Me.scannerName.Name = "scannerName"
        Me.scannerName.Size = New System.Drawing.Size(139, 21)
        Me.scannerName.TabIndex = 20
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 34)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 13)
        Me.Label20.TabIndex = 19
        Me.Label20.Text = "Scanner Name:"
        '
        'documentType
        '
        Me.documentType.FormattingEnabled = True
        Me.documentType.Location = New System.Drawing.Point(103, 84)
        Me.documentType.Name = "documentType"
        Me.documentType.Size = New System.Drawing.Size(139, 21)
        Me.documentType.TabIndex = 15
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(16, 87)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(86, 13)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Document Type:"
        '
        'Configuration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 268)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Configuration"
        Me.ShowIcon = False
        Me.Text = "Configuration"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btnValidateConnection As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbRepository As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtserverName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label10 As Label
    Friend WithEvents CmbDateField As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CmbTypeField As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents CmbScanningDatefld As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbScannedBy As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbTemplateName As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Button4 As Button
    Friend WithEvents btnQFBrowse As Button
    Friend WithEvents txtNoneQfPath As TextBox
    Friend WithEvents txtQFPath As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents saveButton As Button
    Friend WithEvents closeButton As Button
    Friend WithEvents ComboBox6 As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents documentType As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblConnectedTo As Label
    Friend WithEvents lblconnectionStatus As Label
    Public WithEvents CmbBranchField As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents addScannerButton As Button
    Friend WithEvents scannerName As ComboBox
    Friend WithEvents loadScanningInterfaceButton As Button
End Class
