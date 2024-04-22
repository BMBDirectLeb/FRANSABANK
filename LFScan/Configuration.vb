Imports Laserfiche.RepositoryAccess
Imports Laserfiche.ClientAutomation
Imports Laserfiche.DocumentServices
Imports System.IO
Public Class Configuration
    Dim txtcurrentsrvName As String
    Dim currentSession As Session
    Dim searchSyntaxStatic As String = "{LF: LOOKIN=" & doubleQuotes & "DemoRepository\Settings" & doubleQuotes & ", SUBFOLDERS=0}"


    Private Sub Configuration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        copyattribute(userAttributesBackUpDocument)
        txtserverName.Text = server
        txtcurrentsrvName = server
        txtUserName.Text = user
        txtPassword.Text = pass
        Dim srv As Server = New Server(session)
        For Each repo In srv.GetRepositories()
            cmbRepository.Items.Add(repo.Name)
        Next
        cmbRepository.SelectedIndex = cmbRepository.FindString(rep)
        currentSession = session
        lblconnectionStatus.ForeColor = Color.Green
        lblconnectionStatus.Text = "Connected"
        lblConnectedTo.Text = currentSession.Repository.ServerName & ": " & currentSession.UserName & "@" & currentSession.Repository.Name
        LoadMetadataTabInfo()
    End Sub

    Sub LoadMetadataTabInfo()

        loadScanningInterfaceButton.Enabled = False
        saveButton.Enabled = False

        cmbTemplateName.Items.Clear()
        For Each LFTemplate In Laserfiche.RepositoryAccess.Template.EnumAll(currentSession)
            cmbTemplateName.Items.Add(LFTemplate.Name)
            cmbTemplateName.SelectedIndex = cmbTemplateName.FindString(Module1.template)
        Next
        For Each fld In Laserfiche.RepositoryAccess.Field.EnumAll(session)
            CmbBranchField.Items.Add(fld.Name)
            CmbDateField.Items.Add(fld.Name)
            cmbScannedBy.Items.Add(fld.Name)
            CmbScanningDatefld.Items.Add(fld.Name)
            CmbTypeField.Items.Add(fld.Name)

            CmbBranchField.SelectedIndex = CmbBranchField.FindString(fldBranch)
            CmbDateField.SelectedIndex = CmbDateField.FindString(flddate)
            cmbScannedBy.SelectedIndex = cmbScannedBy.FindString(fldScannedBy)
            CmbScanningDatefld.SelectedIndex = CmbScanningDatefld.FindString(fldScanningDate)
            CmbTypeField.SelectedIndex = CmbTypeField.FindString(fldtype)
        Next

        'After deciding to only use the configuration page for now
        'Configuration Tab
        'Fill the document type field in the configuration tab
        documentType.Items.Clear()
        For i As Integer = 0 To FieldObj.GetItemList.Count - 1
            documentType.Items.Add(FieldObj.GetItemList(i))
        Next

        'Fill the scanner name fields in the configuration tab 
        scannerName.Items.Clear()
        Dim folderSearch As New Search(currentSession, searchSyntaxStatic)
        Dim searchListingSettings As New SearchListingSettings()
        Try
            folderSearch.BeginRun(True)
            Dim searchResultsListing = folderSearch.GetResultListing(searchListingSettings)
            For Each item As EntryListingRow In searchResultsListing
                Dim docId As Int32 = CType(item(SystemColumn.Id), Int32)
                Dim docName As String = item(SystemColumn.Name)
                scannerName.Items.Add(docName)
            Next
            folderSearch.Close()
        Catch ex As Exception
            log("Error while retrieving settings folder content. Error message: " & ex.Message)
            MsgBox("Error while retrieving settings folder content. Error message: " & ex.Message)
            folderSearch.Close()
        End Try

    End Sub

    Private Sub btnQFBrowse_Click(sender As Object, e As EventArgs) Handles btnQFBrowse.Click
        Dim BrowseForm As New Browse_Folders
        BrowseForm.parentTxt = txtQFPath
        BrowseForm.ShowDialog()
        BrowseForm.Activate()
    End Sub

    Private Sub txtserverName_LostFocus(sender As Object, e As EventArgs) Handles txtserverName.LostFocus
        If txtcurrentsrvName <> txtserverName.Text Then

            txtcurrentsrvName = txtserverName.Text
            Try
                Dim currentRep As String = cmbRepository.SelectedValue
                cmbRepository.Items.Clear()
                Dim srv As Server = New Server(txtserverName.Text)
                For Each repo In srv.GetRepositories()
                    cmbRepository.Items.Add(repo.Name)
                Next
                cmbRepository.SelectedIndex = cmbRepository.FindString(currentRep)

            Catch ex As Exception
                MsgBox("Could not Connect to Laserfiche Server")
            End Try
        End If
    End Sub

    Private Sub btnValidateConnection_Click(sender As Object, e As EventArgs) Handles btnValidateConnection.Click
        Try
            If currentSession.Guid <> session.Guid And currentSession.IsConnected Then

                currentSession.LogOut()
            End If
            Dim repository As New RepositoryRegistration(txtserverName.Text, cmbRepository.SelectedItem.ToString)
            Dim s As New Session
            s.Connect(repository)
            s.LogIn(txtUserName.Text, txtPassword.Text)
            currentSession = s
            lblconnectionStatus.ForeColor = Color.Green
            lblconnectionStatus.Text = "Connected"
            LoadMetadataTabInfo()
            TabPage2.Enabled = True
            TabPage3.Enabled = True
            TabPage4.Enabled = True
            TabPage5.Enabled = True
            lblConnectedTo.Text = currentSession.Repository.ServerName & ": " & currentSession.UserName & "@" & currentSession.Repository.Name

        Catch ex As Exception
            lblconnectionStatus.ForeColor = Color.Red
            lblconnectionStatus.Text = "Disconnected"
            lblConnectedTo.Text = ""
            TabPage2.Enabled = False
            TabPage3.Enabled = False
            TabPage4.Enabled = False
            TabPage5.Enabled = False
            MsgBox("Could not connect to Laserfiche: " & ex.Message)

        End Try
    End Sub


    'Trying to use part of the configuration page to configure the scanner settings without the need for the LFSCANConfig tool
    Private Sub loadScanningInterfaceButton_Click(sender As Object, e As EventArgs) Handles loadScanningInterfaceButton.Click
        createTempEntry()
        clearattribute()
        '  LoadScanSettings(settingpath & "\" & documentType.Text & "\SETSCAN")
        ' loadAttributes(settingpath & "\" & documentType.Text & "\attributes", tempUserAttributesDocument)

        'while using the scanning interface, the attributes will be saving in the user attributes in lf
        'the scanner settings, if changed, will be saved in C:\windows\SETSCAN.ini
        Try
            Using lfclient As New ClientManager()
                Dim scanoptions As New ScanOptions()
                scanoptions.RepositoryName = rep
                scanoptions.ServerName = server

                scanoptions.WaitForExit = True
                scanoptions.CloseAfterStoring = True
                scanoptions.ScanMode = ScanMode.Standard

                scanoptions.EntryId = ID
                scanoptions.IsDocument = True
                scanoptions.InsertPagesAt = InsertAt.End

                lfclient.LaunchScanning(scanoptions)
                Dim doc As DocumentInfo = Document.GetDocumentInfo(ID, session)
                doc.Delete()
                doc.Save()
            End Using
        Catch ex As Exception
            log("Error while loading scanning interface. Error message: " & ex.Message)
            MsgBox("Error while loading scanning interface. Error message: " & ex.Message)
            End
        End Try
    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
        File.Delete(tempScannerSettingsDocument)
        copyattribute(tempUserAttributesDocument)
        File.Copy(scannerSettingsWindowsPath, tempScannerSettingsDocument, True)
        clearattribute()
        resetattributes(userAttributesBackUpDocument)

        Dim userAttributesDocInfo As New DocumentInfo(session)
        Dim scannerSettingsDocInfo As New DocumentInfo(session)

        userAttributesDocInfo = Document.GetDocumentInfo(settingpath & "\" & documentType.Text & "\" & "attributes", session)
        scannerSettingsDocInfo = Document.GetDocumentInfo(settingpath & "\" & documentType.Text & "\" & "SETSCAN", session)

        Dim userAttributesDocImporter = New DocumentImporter
        userAttributesDocImporter.Document = userAttributesDocInfo
        userAttributesDocImporter.ImportEdoc("text\plain", tempUserAttributesDocument)

        Dim scannerSettingsDocImporter = New DocumentImporter
        scannerSettingsDocImporter.Document = scannerSettingsDocInfo
        scannerSettingsDocImporter.ImportEdoc("text\plain", tempScannerSettingsDocument)

        userAttributesDocInfo.Save()
        userAttributesDocInfo.Dispose()

        scannerSettingsDocInfo.Save()
        scannerSettingsDocInfo.Dispose()

        MsgBox("Settings Saved")

        Me.Close()
    End Sub

    Private Sub close_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        clearattribute()
        resetattributes(userAttributesBackUpDocument)
        MsgBox("Settings Cancelled")
        Me.Close()
    End Sub

    Private Sub addScannerButton_Click(sender As Object, e As EventArgs) Handles addScannerButton.Click

        'Fill the scanner name fields in the configuration tab one more time, assuming that the user might delete a scanner name folder
        'from the repository itself
        scannerName.Items.Clear()
        Dim folderSearch As New Search(currentSession, searchSyntaxStatic)
        Dim searchListingSettings As New SearchListingSettings()
        Try
            folderSearch.BeginRun(True)
            Dim searchResultsListing = folderSearch.GetResultListing(searchListingSettings)
            For Each item As EntryListingRow In searchResultsListing
                Dim docId As Int32 = CType(item(SystemColumn.Id), Int32)
                Dim docName As String = item(SystemColumn.Name)
                scannerName.Items.Add(docName)
            Next
            folderSearch.Close()
        Catch ex As Exception
            log("Error while retrieving settings folder content. Error message: " & ex.Message)
            MsgBox("Error while retrieving settings folder content. Error message: " & ex.Message)
            folderSearch.Close()
        End Try

        'Receive new scanner name and add it to the combobox'
        Dim newScannerName As String = InputBox("Please enter the exact name of your new scanner in the below input:", "New Scanner Window")
        scannerName.Items.Add(newScannerName)

        'Create new folder in Laserfiche all the necessary Files for the new scanner'
        Try
            'get the id of the first scanner folder entry in Laserfiche
            folderSearch.BeginRun(True)
            Dim searchResultsListing = folderSearch.GetResultListing(searchListingSettings)
            Dim entryId As Int32 = 0
            For Each item As EntryListingRow In searchResultsListing
                entryId = CType(item(SystemColumn.Id), Int32) 'return first folder's id 
                Exit For
            Next
            folderSearch.Close()
            'Copy the scanner folder into the same directory And get the id of the New created folder
            Dim docInfo = New DocumentInfo(entryId, session)
            Dim copiedEntryID As Int32 = docInfo.CopyTo("\\Settings\\" + newScannerName, EntryNameOption.AutoRename)

            MsgBox("Scanner Added")
            'Disposed opened connectinos with Laserfiche
            folderSearch.Close()
            docInfo.Dispose()

        Catch ex As Exception
            log("Error while retrieving settings folder content. Error message: " & ex.Message)
            MsgBox("Error while retrieving settings folder content. Error message: " & ex.Message)
            folderSearch.Close()
        End Try

    End Sub

    Private Sub scannerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles scannerName.SelectedIndexChanged
        If scannerName.Text.ToString.Equals("") Or documentType.Text.ToString.Equals("") Then
            loadScanningInterfaceButton.Enabled = False
            saveButton.Enabled = False
        Else
            loadScanningInterfaceButton.Enabled = True
            saveButton.Enabled = True
        End If

    End Sub

    Private Sub documentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles documentType.SelectedIndexChanged
        If documentType.Text.ToString.Equals("") Or scannerName.Text.ToString.Equals("") Then
            loadScanningInterfaceButton.Enabled = False
            saveButton.Enabled = False
        Else
            loadScanningInterfaceButton.Enabled = True
            saveButton.Enabled = True
        End If
    End Sub
End Class