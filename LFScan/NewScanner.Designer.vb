<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewScanner
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
        Me.LblNewScannerName = New System.Windows.Forms.Label()
        Me.TxtNewScanner = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtChosenScannerFolder = New System.Windows.Forms.Label()
        Me.BtnChoose = New System.Windows.Forms.Button()
        Me.BtnOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LblNewScannerName
        '
        Me.LblNewScannerName.AutoSize = True
        Me.LblNewScannerName.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewScannerName.Location = New System.Drawing.Point(24, 48)
        Me.LblNewScannerName.Name = "LblNewScannerName"
        Me.LblNewScannerName.Size = New System.Drawing.Size(216, 17)
        Me.LblNewScannerName.TabIndex = 0
        Me.LblNewScannerName.Text = "Kindly enter your new scanner name:"
        Me.LblNewScannerName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtNewScanner
        '
        Me.TxtNewScanner.Location = New System.Drawing.Point(27, 82)
        Me.TxtNewScanner.Name = "TxtNewScanner"
        Me.TxtNewScanner.Size = New System.Drawing.Size(221, 20)
        Me.TxtNewScanner.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AllowDrop = True
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Kindly Copy settings from:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AllowDrop = True
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(49, 141)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "(Choose the scanner's folder)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtChosenScannerFolder
        '
        Me.TxtChosenScannerFolder.AutoSize = True
        Me.TxtChosenScannerFolder.Location = New System.Drawing.Point(49, 209)
        Me.TxtChosenScannerFolder.Name = "TxtChosenScannerFolder"
        Me.TxtChosenScannerFolder.Size = New System.Drawing.Size(162, 13)
        Me.TxtChosenScannerFolder.TabIndex = 4
        Me.TxtChosenScannerFolder.Text = "*Your choice will be shown here*"
        '
        'BtnChoose
        '
        Me.BtnChoose.BackColor = System.Drawing.Color.White
        Me.BtnChoose.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnChoose.Location = New System.Drawing.Point(52, 172)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(64, 23)
        Me.BtnChoose.TabIndex = 5
        Me.BtnChoose.Text = "Choose"
        Me.BtnChoose.UseVisualStyleBackColor = False
        '
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.Color.White
        Me.BtnOk.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.Location = New System.Drawing.Point(145, 172)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(64, 23)
        Me.BtnOk.TabIndex = 6
        Me.BtnOk.Text = "Ok"
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'NewScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(278, 275)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.BtnChoose)
        Me.Controls.Add(Me.TxtChosenScannerFolder)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNewScanner)
        Me.Controls.Add(Me.LblNewScannerName)
        Me.Name = "NewScanner"
        Me.Text = "Scanner Choice"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblNewScannerName As Label
    Friend WithEvents TxtNewScanner As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtChosenScannerFolder As Label
    Friend WithEvents BtnChoose As Button
    Friend WithEvents BtnOk As Button
End Class
