<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TVFolderBrowser
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
        Me.TVWindow = New System.Windows.Forms.TreeView()
        Me.BtnTVOk = New System.Windows.Forms.Button()
        Me.BtnTVCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TVWindow
        '
        Me.TVWindow.Location = New System.Drawing.Point(12, 12)
        Me.TVWindow.Name = "TVWindow"
        Me.TVWindow.Size = New System.Drawing.Size(348, 390)
        Me.TVWindow.TabIndex = 0
        '
        'BtnTVOk
        '
        Me.BtnTVOk.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTVOk.Location = New System.Drawing.Point(204, 415)
        Me.BtnTVOk.Name = "BtnTVOk"
        Me.BtnTVOk.Size = New System.Drawing.Size(75, 23)
        Me.BtnTVOk.TabIndex = 1
        Me.BtnTVOk.Text = "Ok"
        Me.BtnTVOk.UseVisualStyleBackColor = True
        '
        'BtnTVCancel
        '
        Me.BtnTVCancel.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTVCancel.Location = New System.Drawing.Point(285, 415)
        Me.BtnTVCancel.Name = "BtnTVCancel"
        Me.BtnTVCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnTVCancel.TabIndex = 2
        Me.BtnTVCancel.Text = "Cancel"
        Me.BtnTVCancel.UseVisualStyleBackColor = True
        '
        'TVFolderBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 450)
        Me.Controls.Add(Me.BtnTVCancel)
        Me.Controls.Add(Me.BtnTVOk)
        Me.Controls.Add(Me.TVWindow)
        Me.Name = "TVFolderBrowser"
        Me.Text = "Laserfiche Folder Structure"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TVWindow As TreeView
    Friend WithEvents BtnTVOk As Button
    Friend WithEvents BtnTVCancel As Button
End Class
