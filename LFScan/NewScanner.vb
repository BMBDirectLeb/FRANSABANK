Imports Laserfiche.DocumentServices
Imports Laserfiche.RepositoryAccess
Public Class NewScanner

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        Dim tvFolderBrowser As New TVFolderBrowser
        tvFolderBrowser.startConnection(server, rep, 0, user, pass)
        tvFolderBrowser.ShowDialog()
        tvFolderBrowser.Activate()
    End Sub

    'When the user clicks okay, the content of the selected folder will be fetched and copied to a new folder under the name of the new scanner.
    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click
        If TxtNewScanner.Text = "" Then
            MsgBox("New scanner name cannot be empty.")
        ElseIf Not copyFromChoice Then
            MsgBox("No Folder was chosen.")
        Else
            newScannerName = TxtNewScanner.Text
            updateScannerList(referenceFolderID, newScannerName)

            Me.Close()
            MsgBox("Scanner Added")
        End If
    End Sub

    ' change the label that indicates the folder chosen by the user
    Public Sub changeScannerNameText(newName As String)
        TxtChosenScannerFolder.Text = newName
    End Sub

End Class