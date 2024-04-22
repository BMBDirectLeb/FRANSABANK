<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BtnScan = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.DTPDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GBoxInformation = New System.Windows.Forms.GroupBox()
        Me.CmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblExpiryDateRequired = New System.Windows.Forms.Label()
        Me.DtpExpiryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCustomerID = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnConfiguration = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblversion = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GBoxConfiguration = New System.Windows.Forms.GroupBox()
        Me.cmbConfigDocCategory = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.BtnConfigCancel = New System.Windows.Forms.Button()
        Me.BtnConfigSave = New System.Windows.Forms.Button()
        Me.BtnConfigLoad = New System.Windows.Forms.Button()
        Me.BtnConfigAddScanner = New System.Windows.Forms.Button()
        Me.cmbConfigDocumentType = New System.Windows.Forms.ComboBox()
        Me.ConfigScannerName = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GBoxInformation.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxConfiguration.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnScan
        '
        Me.BtnScan.BackColor = System.Drawing.Color.White
        Me.BtnScan.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnScan.ForeColor = System.Drawing.Color.Black
        Me.BtnScan.Location = New System.Drawing.Point(180, 494)
        Me.BtnScan.Name = "BtnScan"
        Me.BtnScan.Size = New System.Drawing.Size(137, 32)
        Me.BtnScan.TabIndex = 5
        Me.BtnScan.Text = "Scan"
        Me.BtnScan.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.White
        Me.BtnClose.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.Black
        Me.BtnClose.Location = New System.Drawing.Point(342, 494)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(142, 32)
        Me.BtnClose.TabIndex = 6
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'DTPDate
        '
        Me.DTPDate.Location = New System.Drawing.Point(153, 224)
        Me.DTPDate.Name = "DTPDate"
        Me.DTPDate.Size = New System.Drawing.Size(292, 24)
        Me.DTPDate.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 17)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Docuent Date:"
        '
        'CmbType
        '
        Me.CmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbType.FormattingEnabled = True
        Me.CmbType.Items.AddRange(New Object() {"Vouchers"})
        Me.CmbType.Location = New System.Drawing.Point(153, 178)
        Me.CmbType.Name = "CmbType"
        Me.CmbType.Size = New System.Drawing.Size(292, 23)
        Me.CmbType.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(18, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Document Type:"
        '
        'GBoxInformation
        '
        Me.GBoxInformation.Controls.Add(Me.CmbCategory)
        Me.GBoxInformation.Controls.Add(Me.Label8)
        Me.GBoxInformation.Controls.Add(Me.txtCustomerName)
        Me.GBoxInformation.Controls.Add(Me.Label1)
        Me.GBoxInformation.Controls.Add(Me.lblExpiryDateRequired)
        Me.GBoxInformation.Controls.Add(Me.DtpExpiryDate)
        Me.GBoxInformation.Controls.Add(Me.Label10)
        Me.GBoxInformation.Controls.Add(Me.txtCustomerID)
        Me.GBoxInformation.Controls.Add(Me.Label9)
        Me.GBoxInformation.Controls.Add(Me.Label3)
        Me.GBoxInformation.Controls.Add(Me.DTPDate)
        Me.GBoxInformation.Controls.Add(Me.Label2)
        Me.GBoxInformation.Controls.Add(Me.CmbType)
        Me.GBoxInformation.ForeColor = System.Drawing.Color.Chocolate
        Me.GBoxInformation.Location = New System.Drawing.Point(14, 124)
        Me.GBoxInformation.Name = "GBoxInformation"
        Me.GBoxInformation.Size = New System.Drawing.Size(468, 342)
        Me.GBoxInformation.TabIndex = 22
        Me.GBoxInformation.TabStop = False
        Me.GBoxInformation.Text = "Scanning Information"
        '
        'CmbCategory
        '
        Me.CmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategory.FormattingEnabled = True
        Me.CmbCategory.Items.AddRange(New Object() {"Vouchers"})
        Me.CmbCategory.Location = New System.Drawing.Point(155, 127)
        Me.CmbCategory.Name = "CmbCategory"
        Me.CmbCategory.Size = New System.Drawing.Size(292, 23)
        Me.CmbCategory.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(18, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(130, 17)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Document Category:"
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Enabled = False
        Me.txtCustomerName.Location = New System.Drawing.Point(155, 83)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(292, 24)
        Me.txtCustomerName.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 17)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Customer Name:"
        '
        'lblExpiryDateRequired
        '
        Me.lblExpiryDateRequired.AutoSize = True
        Me.lblExpiryDateRequired.ForeColor = System.Drawing.Color.Red
        Me.lblExpiryDateRequired.Location = New System.Drawing.Point(90, 282)
        Me.lblExpiryDateRequired.Name = "lblExpiryDateRequired"
        Me.lblExpiryDateRequired.Size = New System.Drawing.Size(15, 17)
        Me.lblExpiryDateRequired.TabIndex = 24
        Me.lblExpiryDateRequired.Text = "*"
        '
        'DtpExpiryDate
        '
        Me.DtpExpiryDate.Location = New System.Drawing.Point(153, 282)
        Me.DtpExpiryDate.Name = "DtpExpiryDate"
        Me.DtpExpiryDate.Size = New System.Drawing.Size(292, 24)
        Me.DtpExpiryDate.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(18, 287)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 17)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Expiry Date:"
        '
        'txtCustomerID
        '
        Me.txtCustomerID.Location = New System.Drawing.Point(155, 35)
        Me.txtCustomerID.Name = "txtCustomerID"
        Me.txtCustomerID.Size = New System.Drawing.Size(292, 24)
        Me.txtCustomerID.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(18, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Customer Id:"
        '
        'BtnConfiguration
        '
        Me.BtnConfiguration.BackColor = System.Drawing.Color.White
        Me.BtnConfiguration.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfiguration.ForeColor = System.Drawing.Color.Black
        Me.BtnConfiguration.Location = New System.Drawing.Point(16, 494)
        Me.BtnConfiguration.Name = "BtnConfiguration"
        Me.BtnConfiguration.Size = New System.Drawing.Size(145, 32)
        Me.BtnConfiguration.TabIndex = 4
        Me.BtnConfiguration.Text = "Configuration"
        Me.BtnConfiguration.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(383, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 17)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Version:"
        '
        'lblversion
        '
        Me.lblversion.AutoSize = True
        Me.lblversion.Location = New System.Drawing.Point(435, 101)
        Me.lblversion.Name = "lblversion"
        Me.lblversion.Size = New System.Drawing.Size(26, 17)
        Me.lblversion.TabIndex = 25
        Me.lblversion.Text = "1.0"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(14, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(253, 106)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'GBoxConfiguration
        '
        Me.GBoxConfiguration.Controls.Add(Me.cmbConfigDocCategory)
        Me.GBoxConfiguration.Controls.Add(Me.Label11)
        Me.GBoxConfiguration.Controls.Add(Me.Label7)
        Me.GBoxConfiguration.Controls.Add(Me.BtnConfigCancel)
        Me.GBoxConfiguration.Controls.Add(Me.BtnConfigSave)
        Me.GBoxConfiguration.Controls.Add(Me.BtnConfigLoad)
        Me.GBoxConfiguration.Controls.Add(Me.BtnConfigAddScanner)
        Me.GBoxConfiguration.Controls.Add(Me.cmbConfigDocumentType)
        Me.GBoxConfiguration.Controls.Add(Me.ConfigScannerName)
        Me.GBoxConfiguration.Controls.Add(Me.Label6)
        Me.GBoxConfiguration.Controls.Add(Me.Label5)
        Me.GBoxConfiguration.ForeColor = System.Drawing.Color.Chocolate
        Me.GBoxConfiguration.Location = New System.Drawing.Point(16, 545)
        Me.GBoxConfiguration.Name = "GBoxConfiguration"
        Me.GBoxConfiguration.Size = New System.Drawing.Size(468, 206)
        Me.GBoxConfiguration.TabIndex = 26
        Me.GBoxConfiguration.TabStop = False
        Me.GBoxConfiguration.Text = "Configuration"
        '
        'cmbConfigDocCategory
        '
        Me.cmbConfigDocCategory.FormattingEnabled = True
        Me.cmbConfigDocCategory.Location = New System.Drawing.Point(153, 71)
        Me.cmbConfigDocCategory.Name = "cmbConfigDocCategory"
        Me.cmbConfigDocCategory.Size = New System.Drawing.Size(292, 23)
        Me.cmbConfigDocCategory.TabIndex = 32
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(14, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(130, 17)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "Document Category:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(292, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 17)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Or"
        '
        'BtnConfigCancel
        '
        Me.BtnConfigCancel.BackColor = System.Drawing.Color.White
        Me.BtnConfigCancel.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfigCancel.ForeColor = System.Drawing.Color.Black
        Me.BtnConfigCancel.Location = New System.Drawing.Point(323, 168)
        Me.BtnConfigCancel.Name = "BtnConfigCancel"
        Me.BtnConfigCancel.Size = New System.Drawing.Size(122, 32)
        Me.BtnConfigCancel.TabIndex = 29
        Me.BtnConfigCancel.Text = "Cancel"
        Me.BtnConfigCancel.UseVisualStyleBackColor = False
        '
        'BtnConfigSave
        '
        Me.BtnConfigSave.BackColor = System.Drawing.Color.White
        Me.BtnConfigSave.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfigSave.ForeColor = System.Drawing.Color.Black
        Me.BtnConfigSave.Location = New System.Drawing.Point(164, 168)
        Me.BtnConfigSave.Name = "BtnConfigSave"
        Me.BtnConfigSave.Size = New System.Drawing.Size(137, 32)
        Me.BtnConfigSave.TabIndex = 28
        Me.BtnConfigSave.Text = "Save"
        Me.BtnConfigSave.UseVisualStyleBackColor = False
        '
        'BtnConfigLoad
        '
        Me.BtnConfigLoad.BackColor = System.Drawing.Color.White
        Me.BtnConfigLoad.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConfigLoad.ForeColor = System.Drawing.Color.Black
        Me.BtnConfigLoad.Location = New System.Drawing.Point(17, 168)
        Me.BtnConfigLoad.Name = "BtnConfigLoad"
        Me.BtnConfigLoad.Size = New System.Drawing.Size(125, 32)
        Me.BtnConfigLoad.TabIndex = 27
        Me.BtnConfigLoad.Text = "Load"
        Me.BtnConfigLoad.UseVisualStyleBackColor = False
        '
        'BtnConfigAddScanner
        '
        Me.BtnConfigAddScanner.BackColor = System.Drawing.Color.White
        Me.BtnConfigAddScanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnConfigAddScanner.ForeColor = System.Drawing.Color.Black
        Me.BtnConfigAddScanner.Location = New System.Drawing.Point(323, 30)
        Me.BtnConfigAddScanner.Name = "BtnConfigAddScanner"
        Me.BtnConfigAddScanner.Size = New System.Drawing.Size(122, 23)
        Me.BtnConfigAddScanner.TabIndex = 4
        Me.BtnConfigAddScanner.Text = "Add New Scanner"
        Me.BtnConfigAddScanner.UseVisualStyleBackColor = False
        '
        'cmbConfigDocumentType
        '
        Me.cmbConfigDocumentType.FormattingEnabled = True
        Me.cmbConfigDocumentType.Location = New System.Drawing.Point(153, 110)
        Me.cmbConfigDocumentType.Name = "cmbConfigDocumentType"
        Me.cmbConfigDocumentType.Size = New System.Drawing.Size(292, 23)
        Me.cmbConfigDocumentType.TabIndex = 3
        '
        'ConfigScannerName
        '
        Me.ConfigScannerName.FormattingEnabled = True
        Me.ConfigScannerName.Location = New System.Drawing.Point(153, 30)
        Me.ConfigScannerName.Name = "ConfigScannerName"
        Me.ConfigScannerName.Size = New System.Drawing.Size(126, 23)
        Me.ConfigScannerName.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(14, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 17)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Document Type:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(14, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Scanner Name:"
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(495, 761)
        Me.Controls.Add(Me.GBoxConfiguration)
        Me.Controls.Add(Me.BtnScan)
        Me.Controls.Add(Me.BtnConfiguration)
        Me.Controls.Add(Me.lblversion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GBoxInformation)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Journals Scanning"
        Me.GBoxInformation.ResumeLayout(False)
        Me.GBoxInformation.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxConfiguration.ResumeLayout(False)
        Me.GBoxConfiguration.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnScan As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents DTPDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GBoxInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblversion As System.Windows.Forms.Label
    Friend WithEvents BtnConfiguration As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GBoxConfiguration As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbConfigDocumentType As ComboBox
    Friend WithEvents ConfigScannerName As ComboBox
    Friend WithEvents BtnConfigAddScanner As Button
    Friend WithEvents BtnConfigCancel As Button
    Friend WithEvents BtnConfigSave As Button
    Friend WithEvents BtnConfigLoad As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCustomerID As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents DtpExpiryDate As DateTimePicker
    Friend WithEvents lblExpiryDateRequired As Label
    Friend WithEvents CmbCategory As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbConfigDocCategory As ComboBox
    Friend WithEvents Label11 As Label
End Class
