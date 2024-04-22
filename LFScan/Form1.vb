Imports Laserfiche.RepositoryAccess
Imports Laserfiche.ClientAutomation
Imports Laserfiche.DocumentServices
'Imports LFIMAGEENABLE80Lib
Imports System.IO
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class Form1
    'Public img As New ImageEnable
    Public version As String = 1.0
    ' Dim searchSyntaxStatic As String = "{LF: LOOKIN=" & doubleQuotes & "DemoRepository\Settings" & doubleQuotes & ", SUBFOLDERS=0}"

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            'CleanFolderStruct()
            clearattribute()

            resetattributes(userAttributesBackUpDocument)
            File.Copy(".\CurrentSetscan.ini", scannerSettingsWindowsPath, True)
            File.Delete(userAttributesBackUpDocument)

            If session.IsConnected = False Then
                session.LogOut()
            End If
            SQLCon.Close()
        Catch ex As Exception
        End Try

    End Sub

    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            frm.FormBorderStyle = FormBorderStyle.FixedSingle
            frm.MaximizeBox = False
            frm.MinimizeBox = False
            PictureBox1.ImageLocation = "./" & picname

            lblversion.Text = version

            GBoxConfiguration.Enabled = False
            Dim dtcategories = GetSqlData(SQLGetCategoriesQuery)
            CmbCategory.Items.Clear()
            For i = 0 To dtcategories.Rows.Count - 1
                CmbCategory.Items.Add(dtcategories.Rows(i).Item(SQLDocCategoryColumn))
            Next
            If CmbCategory.Items.Count = 1 Then
                CmbCategory.SelectedIndex = 0
            End If

            lblExpiryDateRequired.Visible = False

            frm.Height = 575
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnScan.Click
        If CmbType.Text <> "" Then
            If docExpiryFlag And DtpExpiryDate.Value.Date = Date.Now.Date Then

                'MsgBox("Please fill in the Document Expiry Date")
                Dim msg As MsgBoxResult = MsgBox("Expiry Date is required and it is set as today's date, do you want to proceed", MsgBoxStyle.YesNo, "Expiry Date is Required")
                If msg = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            transactiondate = DTPDate.Value
            createentry()

            LoadScanSettings(CmbCategory.Text, CmbType.Text, False)
            clearattribute()
            loadAttributes(CmbCategory.Text, CmbType.Text, tempUserAttributesDocument, False)
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
                    If doc.PageCount = 0 Then
                        doc.Delete()
                        doc.Save()
                        lfclient.Dispose()
                    Else
                        doc.Dispose()
                        lfclient.Dispose()
                    End If
                End Using
            Catch ex As Exception
                log("Error while loading scanning interface. error message: " & ex.Message)
                MsgBox("Error while loading scanning interface. error message: " & ex.Message)
                MsgBox($"The tool be closed.")
                Me.Close()
            End Try
        End If
    End Sub
    Private Sub CmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbType.SelectedIndexChanged
        If CmbType.SelectedIndex <> -1 And txtCustomerName.Text <> "" Then

            Dim dtExpiryDate As DataTable = GetSqlData(SQLGetexpiryFlagQuery)
            docExpiryFlag = dtExpiryDate.Rows(0).Item(SQLDocExpiryFlagColumn)
            If docExpiryFlag Then
                lblExpiryDateRequired.Visible = True
            Else
                lblExpiryDateRequired.Visible = False
            End If

            BtnScan.Enabled = True
        Else
            BtnScan.Enabled = False
        End If

    End Sub

    Private Sub BtnConfiguration_Click(sender As Object, e As EventArgs) Handles BtnConfiguration.Click

        'If configuration button is NOT clicked... 
        If (frm.Height = 575) Then
            GBoxInformation.Enabled = False
            GBoxConfiguration.Enabled = True
            frm.Height = 800

            BtnConfigLoad.Enabled = False
            BtnConfigSave.Enabled = False

            Dim dtcategories = GetSqlData(SQLGetCategoriesQuery)
            cmbConfigDocCategory.Items.Clear()
            For i = 0 To dtcategories.Rows.Count - 1
                cmbConfigDocCategory.Items.Add(dtcategories.Rows(i).Item(SQLDocCategoryColumn))
            Next
            If cmbConfigDocCategory.Items.Count = 1 Then
                cmbConfigDocCategory.SelectedIndex = 0
            End If


            'Fill the scanner name fields in the configuration tab 
            ConfigScannerName.Items.Clear()
            Dim folderSearch As New Search(session, searchSyntax)
            Dim searchListingSettings As New SearchListingSettings()
            Try
                folderSearch.BeginRun(True)
                Dim searchResultsListing = folderSearch.GetResultListing(searchListingSettings)
                For Each item As EntryListingRow In searchResultsListing
                    Dim docId As Int32 = CType(item(SystemColumn.Id), Int32)
                    Dim docName As String = item(SystemColumn.Name)
                    ConfigScannerName.Items.Add(docName)
                Next
                folderSearch.Close()
            Catch ex As Exception
                log("Error while retrieving settings folder content. Error message: " & ex.Message)
                MsgBox("Error while retrieving settings folder content. Error message: " & ex.Message)
                folderSearch.Close()
            End Try

            'If configuration button is ALREADY clicked... 
        Else
            clearattribute()
            resetattributes(userAttributesBackUpDocument)
            cmbConfigDocCategory.SelectedIndex = -1
            cmbConfigDocumentType.SelectedIndex = -1
            ConfigScannerName.SelectedIndex = -1

            GBoxInformation.Enabled = True
            GBoxConfiguration.Enabled = False

            frm.Height = 575
        End If

    End Sub

    Private Sub BtnConfigLoad_Click(sender As Object, e As EventArgs) Handles BtnConfigLoad.Click
        createTempEntry()
        clearattribute()
        LoadScanSettings(cmbConfigDocCategory.Text, cmbConfigDocumentType.Text, True)
        loadAttributes(cmbConfigDocCategory.Text, cmbConfigDocumentType.Text, tempUserAttributesDocument, True)

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
            MsgBox("The tool be closed.")
            Me.Close()
            End
        End Try
    End Sub

    Private Sub BtnConfigSave_Click(sender As Object, e As EventArgs) Handles BtnConfigSave.Click
        File.Delete(tempScannerSettingsDocument)
        copyattribute(tempUserAttributesDocument)
        File.Copy(scannerSettingsWindowsPath, tempScannerSettingsDocument, True)
        clearattribute()
        resetattributes(userAttributesBackUpDocument)

        Dim userAttributesDocInfo As New DocumentInfo(session)
        Dim scannerSettingsDocInfo As New DocumentInfo(session)

        Try
            userAttributesDocInfo = Document.GetDocumentInfo(ReplaceTokens(settingpath) & "\" & cmbConfigDocCategory.Text & "\" & cmbConfigDocumentType.Text & "\" & "attributes", session)

        Catch ex As Exception
            Dim fol As FolderInfo = createfolderbypath(ReplaceTokens(settingpath) & "\" & cmbConfigDocCategory.Text & "\" & cmbConfigDocumentType.Text)
            Dim docID As Integer = Document.Create(fol, "attributes", False, session)
            userAttributesDocInfo = Document.GetDocumentInfo(docID, session)
        End Try
        Try
            scannerSettingsDocInfo = Document.GetDocumentInfo(ReplaceTokens(settingpath) & "\" & cmbConfigDocCategory.Text & "\" & cmbConfigDocumentType.Text & "\" & "SETSCAN", session)
        Catch ex As Exception

            Dim fol As FolderInfo = createfolderbypath(ReplaceTokens(settingpath) & "\" & cmbConfigDocCategory.Text & "\" & cmbConfigDocumentType.Text)
            Dim docID As Integer = Document.Create(fol, "SETSCAN", False, session)
            scannerSettingsDocInfo = Document.GetDocumentInfo(docID, session)
        End Try

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

        GBoxInformation.Enabled = True
        GBoxConfiguration.Enabled = False

        frm.Height = 575

        MsgBox("Settings Saved")
    End Sub

    Private Sub BtnConfigCancel_Click(sender As Object, e As EventArgs) Handles BtnConfigCancel.Click
        clearattribute()
        resetattributes(userAttributesBackUpDocument)

        cmbConfigDocumentType.SelectedIndex = -1
        ConfigScannerName.SelectedIndex = -1

        GBoxInformation.Enabled = True
        GBoxConfiguration.Enabled = False

        frm.Height = 575
    End Sub

    Private Sub BtnConfigAddScanner_Click(sender As Object, e As EventArgs) Handles BtnConfigAddScanner.Click
        Dim newScanner As New NewScanner
        newScanner.ShowDialog()
        newScanner.Activate()
    End Sub

    Private Sub ConfigDocumentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConfigDocumentType.SelectedIndexChanged, ConfigScannerName.SelectedIndexChanged
        If ConfigScannerName.SelectedIndex <> -1 And cmbConfigDocumentType.SelectedIndex <> -1 Then
            BtnConfigLoad.Enabled = True
            BtnConfigSave.Enabled = True
        Else
            BtnConfigLoad.Enabled = False
            BtnConfigSave.Enabled = False
        End If
    End Sub

    Private Sub txtCustomerID_TextChanged(sender As Object, e As EventArgs) Handles txtCustomerID.LostFocus
        If txtCustomerID.Text <> "" Then

            Dim customerData As DataTable = GetSqlData(SQLGetCustomerInfoQuery)
            If customerData.Rows.Count > 0 Then
                ' Assuming you want to retrieve a specific value from the first row and first column

                txtCustomerName.Text = customerData.Rows(0).Item(SQLCustomerNAmeColumn).ToString()
                Branch = customerData.Rows(0).Item(SQLBranchColumn).ToString()
                If CmbType.SelectedIndex <> -1 Then
                    BtnScan.Enabled = True
                End If
            Else
                BtnScan.Enabled = False
                txtCustomerName.Text = "" ' No data found, clear the textbox or handle accordingly
                MsgBox("Customer Not Found")
            End If

        End If
    End Sub

    Private Sub CmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCategory.SelectedIndexChanged
        Dim dtTypes As DataTable = GetSqlData(SQLGetTypesQuery)
        CmbType.Items.Clear()
        For i = 0 To dtTypes.Rows.Count - 1
            CmbType.Items.Add(dtTypes.Rows(i).Item(SQLDocTypeColumn))
        Next
        If CmbType.Items.Count = 1 Then
            CmbType.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbConfigDocCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConfigDocCategory.SelectedIndexChanged

        Dim dtTypes As DataTable = GetSqlData(SQLGetTypesQuery.Replace("*Category*", cmbConfigDocCategory.Text))
        cmbConfigDocumentType.Items.Clear()
        cmbConfigDocumentType.Text = ""
        For i = 0 To dtTypes.Rows.Count - 1
            cmbConfigDocumentType.Items.Add(dtTypes.Rows(i).Item(SQLDocTypeColumn))
        Next
        If cmbConfigDocumentType.Items.Count = 1 Then
            cmbConfigDocumentType.SelectedIndex = 0
        End If
    End Sub

    Private Sub txtCustomerID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustomerID.KeyPress
        If Asc(e.KeyChar) = 13 Then
            frm.CmbCategory.Focus()
        End If
    End Sub
End Class
