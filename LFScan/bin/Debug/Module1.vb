Imports Laserfiche.DocumentServices
Imports Laserfiche.RepositoryAccess
Imports System.IO
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging

Module Module1

    ''''''''Public db As LFDatabase
    Public session As New Session
    Public user, pass, server, rep,
        template, fldScanningDate, fldScannedBy, fldBranch, fldCsutomerID, flddate, fldtype, fldExpiryDate,
        path, volume,
        sep1, sep2, replace, replace2,
        ManageSettingsGroup, searchSyntaxString,
        searchSyntax As String
    'Public validator, fldvalidator As string
    Public CurrentBranch, username As String
    Public transactiondate As Date
    Public account As TrusteeInfo
    Public accountName As String

    Public flag As String = False
    Public ID As Integer = 0
    Public doubleQuotes As String = """"
    Public QFTypes As String
    Public settingpath As String
    Public SettingDocTempPath As String
    Public traceflag As Boolean
    Public scanner As String
    Public LFTemp As TemplateInfo
    Public FieldObj As FieldInfo
    Public types() As String
    Public frm As New Form1
    Public TempScan As String
    Public DocsWithExpiry As String
    Public picname As String
    Public allbranches As String

    Public stationScannerDocument As String = ".\Scanner.ini"
    Public tempUserAttributesDocument As String = ".\TempAttributes.ini"
    Public tempScannerSettingsDocument As String = ".\TempSETSCAN.ini"
    Public userAttributesBackUpDocument As String = ".\CurrentAttributes.ini"
    Public scannerSettingsWindowsPath As String = Environment.GetEnvironmentVariable("windir") & "\SETSCAN.INI"

    Public referenceFolderID As Integer = 0
    Public referenceFolderPath As String = ""
    Public referenceFolderName As String = ""
    Public newScannerName As String = ""

    Public copyFromChoice = False

    Public Sub readparam()
        Try
            Using scnreader As StreamReader = New StreamReader(stationScannerDocument)
                scanner = Trim(scnreader.ReadLine())
            End Using
            Using read As StreamReader = New StreamReader(".\settings.ini")
                server = Trim(read.ReadLine().Split("=")(1))
                rep = Trim(read.ReadLine().Split("=")(1))
                user = Trim(read.ReadLine().Split("=")(1))
                'pass = Decrypt(Trim(read.ReadLine))
                pass = Trim(read.ReadLine().Split("=")(1))
                template = Trim(read.ReadLine().Split("=")(1))
                fldScanningDate = Trim(read.ReadLine().Split("=")(1))
                fldScannedBy = Trim(read.ReadLine().Split("=")(1))
                fldBranch = Trim(read.ReadLine().Split("=")(1))
                fldCsutomerID = Trim(read.ReadLine().Split("=")(1))
                flddate = Trim(read.ReadLine().Split("=")(1))
                fldtype = Trim(read.ReadLine().Split("=")(1))
                fldExpiryDate = Trim(read.ReadLine().Split("=")(1))
                path = Trim(read.ReadLine().Split("=")(1))
                settingpath = Trim(read.ReadLine().Split("=")(1)).Replace("*Scanner*", scanner)
                SettingDocTempPath = Trim(read.ReadLine().Split("=")(1)).Replace("*Scanner*", scanner)
                volume = Trim(read.ReadLine().Split("=")(1))
                sep1 = Trim(read.ReadLine().Split("=")(1))
                sep2 = Trim(read.ReadLine().Split("=")(1))
                replace = Trim(read.ReadLine().Split("=")(1))
                replace2 = Trim(read.ReadLine().Split("=")(1))
                picname = Trim(read.ReadLine().Split("=")(1))
                allbranches = Trim(read.ReadLine().Split("=")(1))
                ManageSettingsGroup = Trim(read.ReadLine().Split("=")(1))
                searchSyntaxString = Trim(read.ReadLine())
                searchSyntax = searchSyntaxString.Split("=")(1) + "=" + searchSyntaxString.Split("=")(2) + "=" + searchSyntaxString.Split("=")(3)
                TempScan = Trim(read.ReadLine().Split("=")(1))
                DocsWithExpiry = Trim(read.ReadLine().Split("=")(1))
            End Using
            Using brreader As StreamReader = New StreamReader(".\branch.ini")
                CurrentBranch = Trim(brreader.ReadLine())
            End Using
            If CurrentBranch = "" And allbranches = 0 Then
                MsgBox("Branch File Settings is Empty")
                End

            End If
            If TempScan = "" Then
                MsgBox("Temp Scan folder is empty, Please check the settings.ini file")
                End

            End If

        Catch ex As Exception
            log("Error Reading Settings File. Error Message: " & ex.Message)
            MsgBox("Error Reading Settings File. Error Message: " & ex.Message)
            End
        End Try
    End Sub





    Function Decrypt(ByVal pass As String) As String
        Dim myDelims As String() = New String() {pass.Split("=")(0) & "="}
        pass = Trim(pass.Split(myDelims, StringSplitOptions.None)(1))
        Return DecryptPassword(pass)
    End Function

    Public Function DecryptPassword(ByVal sdata As String) As String
        Dim encoder As New System.Text.UTF8Encoding()
        Dim utf8Decode As System.Text.Decoder = encoder.GetDecoder()
        Dim todecode_byte As Byte() = Convert.FromBase64String(sdata)
        Dim charCount As Integer = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)
        Dim decoded_char As Char() = New Char(charCount - 1) {}
        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)
        Dim result As String = New [String](decoded_char)
        Return result
    End Function

    Sub CleanFolderStruct()

        Try
            Dim fol As FolderInfo = createfolderbypath(path.Replace("*Branch*", CurrentBranch))
            Dim settings As New EntryListingSettings
            settings.EntryFilter = EntryTypeFilter.Folders
            For Each record As EntryListingRow In fol.OpenFolderListing(settings)
                Dim subfol As FolderInfo = Folder.GetFolderInfo(record.Item(SystemColumn.Id), session)
                If subfol.OpenFolderListing(New EntryListingSettings).Count = 0 Then
                    subfol.Delete()
                Else

                    subfol.Dispose()
                End If
            Next
            fol.Dispose()
        Catch ex As Exception
            MsgBox("Error While cleaning folder structure, Error Message: " & ex.Message)
        End Try

    End Sub

    Public Sub createentry()

        Try
            Dim doc As DocumentInfo

            doc = New DocumentInfo(session)
            Dim parentfol As FolderInfo = createfolderbypath(path.Replace("*Branch*", CurrentBranch)) '& "\" & transactiondate.ToString("yyyyMMdd"))
            Dim match = Regex.Match(frm.cmbBranch.Text, "(\d+)-\w+", RegexOptions.IgnoreCase)
            doc.Create(parentfol, frm.txtCustomerID.Text & " - " & frm.CmbType.Text & " - " & Form1.DTPDate.Value.ToString("yyyy/MM/dd"), volume, EntryNameOption.AutoRename)
            parentfol.Dispose()

            doc.SetTemplate(template)
            Dim fielddata As FieldValueCollection = doc.GetFieldValues()

            fielddata(fldBranch) = frm.cmbBranch.Text
            fielddata(flddate) = transactiondate
            fielddata(fldtype) = frm.CmbType.Text
            fielddata(fldScannedBy) = username
            fielddata(fldScanningDate) = Now.Date()
            If frm.DTPDate.Value.Date = Date.Now.Date Then
                If DocsWithExpiry.Split(",").Contains(frm.CmbType.Text) Then
                    fielddata(fldExpiryDate) = frm.DtpExpiryDate.Value
                End If
            Else
                fielddata(fldExpiryDate) = frm.DtpExpiryDate.Value
            End If


            fielddata(fldCsutomerID) = frm.txtCustomerID.Text
            'fielddata(fldvalidator) = validator

            doc.SetFieldValues(fielddata)
            doc.Save()
            ID = doc.Id
            doc.Dispose()
        Catch ex As Exception
            log("Error while creating document. Error message: " & ex.Message)
            MsgBox("Error while creating document. Error message: " & ex.Message)
            End
        End Try
    End Sub

    'This function is created to hold the extra document in which the scanning interface will be openned upon
    'while configuring new scanning settings (scan settings and user attributes configuration).
    Public Sub createTempEntry()
        'Dim parentFolder = "\\Configuration Settings"
        'Dim tempChildDocument = "Temporary Configuration Document"
        'Dim parentfol As FolderInfo = New FolderInfo(session)
        'Dim doc As DocumentInfo

        'parentfol.Create(parentFolder, EntryNameOption.Overwrite)
        'doc = New DocumentInfo(session)
        'doc.Create(parentfol, tempChildDocument, volume, EntryNameOption.Overwrite)
        'ID = doc.Id

        'parentfol.Dispose()
        'doc.Dispose()
        Dim tempFolderName = SettingDocTempPath
        Dim tempChildDocument = "TempDoc"
        Dim doc As DocumentInfo
        Dim parentfol As FolderInfo
        Try
            parentfol = Folder.GetFolderInfo(tempFolderName, session)
            doc = New DocumentInfo(session)
            doc.Create(parentfol, tempChildDocument, volume, EntryNameOption.None)
            ID = doc.Id
            parentfol.Dispose()

            doc.Save()
            doc.Dispose()
        Catch ex As ObjectNotFoundException
            parentfol = New FolderInfo(session)
            parentfol.Create(tempFolderName, EntryNameOption.None)
            doc = New DocumentInfo(session)
            doc.Create(parentfol, tempChildDocument, volume, EntryNameOption.None)
            ID = doc.Id
            parentfol.Dispose()
            doc.Save()
            doc.Dispose()
        Catch ex As DuplicateObjectException
            doc = Entry.GetEntryInfo(tempFolderName + "\\" + tempChildDocument, session)
            ID = doc.Id
            doc.Save()
            doc.Dispose()
        End Try

    End Sub

    'move scan settings from laserfiche settings path to .\TempSETSCAN.ini
    'then we copy the scan settings from .\TempSETSCAN.ini to C:\windows\SETSCAN.ini
    'the laserfiche scanning interface automatically read from this location.
    Public Sub LoadScanSettings(ByVal type As String)


        Try
            Dim fol As FolderInfo
            Try
                fol = Folder.GetFolderInfo(settingpath & "\" & type, session)
            Catch ex As Exception
                fol = Folder.GetFolderInfo(settingpath & "\Default", session)
            End Try
            'MsgBox("trying to load scanners parameters")
            Dim docEx As New DocumentExporter()
            ' Sets SourceDocument property.
            Dim doc As DocumentInfo = Document.GetDocumentInfo(fol.Path & "\SETSCAN", session)
            docEx.ExportElecDoc(doc, tempScannerSettingsDocument)
            File.Copy(tempScannerSettingsDocument, scannerSettingsWindowsPath, True)
        Catch ex As Exception
            log("Cannot apply scanner parameters. Error message: " & ex.Message)
            MsgBox("Cannot apply scanner parameters. Error message: " & ex.Message)
        End Try

    End Sub

    'move attributes from laserfiche settings path to .\TempAttributes.ini.
    'and then read the content of the attributes and set them to the current user session
    Public Sub loadAttributes(ByVal Type As String, ByVal path As String)


        Try
            Dim fol As FolderInfo
            Try
                fol = Folder.GetFolderInfo(settingpath & "\" & Type, session)
            Catch ex As Exception
                fol = Folder.GetFolderInfo(settingpath & "\Default", session)
            End Try
            Try
                Dim docEx As New DocumentExporter()
                ' Sets SourceDocument property.
                Dim doc As DocumentInfo = Document.GetDocumentInfo(fol.Path & "\attributes", session)
                docEx.ExportElecDoc(doc, path)
            Catch ex As Exception
                log("Cannot expport scanning attributes. Error message: " & ex.Message)
                MsgBox("Cannot apply scanning attributes. Error message: " & ex.Message)
            End Try

            Dim read As StreamReader = New StreamReader(path)
            Dim attributes As String = read.ReadToEnd
            Dim accountattr As TrusteeAttributeCollection = account.GetAttributes

            For Each userattribute As String In Trim(attributes).Split({sep2}, StringSplitOptions.None)

                If userattribute.Split({sep1}, StringSplitOptions.None).Count > 1 Then
                    Try
                        If userattribute.Split({sep1}, StringSplitOptions.None)(0) = "[Scanning-xxxxxx]TempDirectory" Then

                            accountattr.Add(userattribute.Split({sep1}, StringSplitOptions.None)(0).Replace(replace, System.Environment.UserName.ToUpper).Replace(replace2, System.Environment.MachineName), TempScan)
                        Else
                            accountattr.Add(userattribute.Split({sep1}, StringSplitOptions.None)(0).Replace(replace, System.Environment.UserName.ToUpper).Replace(replace2, System.Environment.MachineName), userattribute.Split({sep1}, StringSplitOptions.None)(1))

                        End If
                    Catch ex As Exception

                    End Try
                End If

            Next

            accountattr.Save()
            read.Close()
        Catch ex As Exception
            log("Error while setting up the user attributes. Error message: " & ex.Message)
            MsgBox("Error while setting up the user attributes. Error message: " & ex.Message)
        End Try

    End Sub

    'Copy scan settings from the logged in windows user account to .\currentSETSCAN.ini for future restore
    'This function is not used because the general scanning settings will be done only once for each machine
    'at least it will be done a lot less time than changing user attributes.
    Public Sub savescansettings()
        Try
            File.Copy(scannerSettingsWindowsPath, ".\CurrentSetscan.ini", True)
        Catch ex As Exception
        End Try
    End Sub

    'Copy attributes from user current session to .\currentAttributes.ini
    'they will be usde after all changes are done and restore original user's scanning settings
    Public Sub copyattribute(ByVal path As String)
        Try
            Dim writer As StreamWriter = New StreamWriter(path)
            Dim attributes As TrusteeAttributeCollection = account.GetAttributes()
            For Each attr In attributes
                If attr.Key.StartsWith("[Scanning-" & System.Environment.UserName.ToUpper & "]") Then
                    writer.Write(attr.Key.Replace(System.Environment.UserName.ToUpper, replace) & sep1 & attr.Value)
                    writer.Write(sep2)
                End If
            Next
            writer.Close()
        Catch ex As Exception
            log("Error while getting user attributes. Error message: " & ex.Message)
            MsgBox("Error while getting user attributes. Error message: " & ex.Message)
        End Try

    End Sub

    'Clearing attributes from user session after we copied them to the .\currentAttributes.ini location
    'this allows us to recreate the necessary attributes settings that will be used for the daily journal scan
    Public Sub clearattribute()
        Try
            Dim attributes As TrusteeAttributeCollection = account.GetAttributes()
            For Each attr In attributes
                If attr.Key.StartsWith("[Scanning-" & System.Environment.UserName.ToUpper & "]") Then
                    attributes.Remove(attr.Key)
                End If
            Next

            attributes.Save()
        Catch ex As Exception
            log("Error while clearing user Attributes. Error message: " & ex.Message)
            MsgBox("Error while clearing user Attributes. Error message: " & ex.Message)
        End Try
    End Sub

    'rewriting the attributes originally copied before configuring the attributes realated to the daily journal scan after we are done from
    'our configuration.
    Public Sub resetattributes(ByVal path As String)

        Dim read As StreamReader = New StreamReader(path)
        Dim attributes As String = read.ReadToEnd
        Dim accountattr As TrusteeAttributeCollection = account.GetAttributes
        For Each userattribute As String In Trim(attributes).Split({sep2}, StringSplitOptions.None)

            If userattribute.Split({sep1}, StringSplitOptions.None).Count > 1 Then
                accountattr.Add(userattribute.Split({sep1}, StringSplitOptions.None)(0).Replace(replace, System.Environment.UserName.ToUpper).Replace(replace2, System.Environment.MachineName), userattribute.Split({sep1}, StringSplitOptions.None)(1))
            End If

        Next
        accountattr.Save()
        read.Close()
    End Sub

    Public Function getsummary(ByVal docid As Integer) As Integer
        Try
            Dim pagescount As Integer = 0
            Dim doc As DocumentInfo
            doc = Document.GetDocumentInfo(docid, session)
            pagescount = doc.PageCount
            doc.Dispose()
            Return pagescount
        Catch ex As Exception
            log("Error while getting summary of scanned documents. Error message: " & ex.Message)
            MsgBox("Error while getting summary of scanned documents. Error message: " & ex.Message)
            Return 0
        End Try

    End Function

    Sub log(ByVal str As String)
        Try
            If Directory.Exists(".\Logs") = False Then
                Directory.CreateDirectory(".\Logs")
            End If
            Dim write As StreamWriter = New StreamWriter(".\Logs\Log-" & Now.Year & Now.Month & Now.Day & ".txt", True)
            write.WriteLine(Now.Date & " " & Now.Hour & ":" & Now.Minute & ":" & Now.Second & " :    " & str)
            write.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Function createfolderbypath(ByVal folderpath As String) As FolderInfo
        Dim f As FolderInfo

        Try
            f = Folder.GetFolderInfo(folderpath, session)
        Catch ex As Exception
            Dim lastindex As Integer = folderpath.LastIndexOf("\"c)
            f = New FolderInfo(session)
            Dim parentfol As FolderInfo = createfolderbypath(folderpath.Substring(0, lastindex))
            f.Create(folderpath, EntryNameOption.None)
            parentfol.Dispose()
            f.Save()
        End Try
        Return f
    End Function

    Sub loaddata()
        Dim hostname As String
        Try
            username = System.Environment.UserName
        Catch ex As Exception
            log("Error while retreiving current windows user name. Error Massege: " & ex.Message)
            MsgBox("Error while retreiving current windows user name. Error Massege: " & ex.Message)
            End
        End Try
        readparam()


        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim repository As New RepositoryRegistration(server, rep)
            session.Connect(repository)
            session.LogIn()

            accountName = session.UserName
            hostname = session.RawHostName.Split(".")(0)
            session.LogOut()
        Catch ex As Exception
            log("Unable to connect using windows authentication for user {" & Environment.UserName & "}. Error message :" & ex.Message)
            MsgBox("Unable to connect using windows authentication for user {" & Environment.UserName & "}. Error message :" & ex.Message)
            End
        End Try
        Try

            session.LogIn(user, pass)
            Try
                account = Trustee.GetInfo(accountName, session)
            Catch ex As Exception
                account = Trustee.GetInfo(hostname + "\" + accountName, session)
            End Try


        Catch ex As Exception
            log("Unable to connect to Laserfiche. Error message :" & ex.Message)
            MsgBox("Unable to connect to Laserfiche. Error message :" & ex.Message)
            End
        End Try
        Try
            LFTemp = Laserfiche.RepositoryAccess.Template.GetInfo(template, session)
            FieldObj = Field.GetInfo(fldtype, session)
            Dim types(FieldObj.GetItemList.Count - 1) As String
            For i As Integer = 0 To FieldObj.GetItemList.Count - 1
                types(i) = FieldObj.GetItemList(i)
            Next
            frm.BtnScan.Enabled = False
            frm.Text += " - """ & username & """"

            frm.CmbType.Items.Clear()
            For i As Integer = 0 To FieldObj.GetItemList.Count - 1
                frm.CmbType.Items.Add(FieldObj.GetItemList(i))
            Next

            Dim fldBranches As FieldInfo = Field.GetInfo(fldBranch, session)
            frm.cmbBranch.Items.Clear()
            For i As Integer = 0 To fldBranches.GetItemList.Count - 1
                frm.cmbBranch.Items.Add(fldBranches.GetItemList(i))
            Next
            frm.cmbBranch.SelectedIndex = frm.cmbBranch.FindString(CurrentBranch)
            If allbranches = 0 Then
                frm.cmbBranch.Enabled = False
            Else
                frm.cmbBranch.Enabled = True
            End If
        Catch ex As Exception
            log("Unable to read from the Types field. Error message :" & ex.Message)
            MsgBox("Unable to read from the Types field. Error message :" & ex.Message)
            End
        End Try
        copyattribute(userAttributesBackUpDocument)

        CleanFolderStruct()

        frm.DTPDate.MaxDate = Date.Now


        'Dim d As New Admin.ServerManagement(server)
        'If d.CheckHasAdministratorAccess() = True Then
        '    MsgBox(d.DefaultRepository)
        '    frm.BtnConfiguration.Visible = True
        '    frm.BtnConfiguration.Enabled = True
        '    MsgBox("System Manager")
        'Else
        '    frm.BtnConfiguration.Visible = False
        '    frm.BtnConfiguration.Enabled = False
        '    MsgBox("Not System Manager")
        'End If
        Dim accref As AccountReference = New AccountReference(accountName, session)
        frm.BtnConfiguration.Enabled = False
        For Each t In Trustee.EnumGroups(accref, session)
            If t.AccountName = ManageSettingsGroup Then
                frm.BtnConfiguration.Enabled = True
            End If
        Next

        frm.Show()
        frm.Activate()
    End Sub

    Public Function gettable(ByVal strsql As String, ByVal connString As String) As DataTable
        Dim Con As New SqlConnection
        Dim ds As New DataSet
        Dim da As SqlDataAdapter
        Dim dt As DataTable

        Con = New SqlConnection(connString)
        Con.Open()
        da = New SqlDataAdapter(strsql, Con)
        da.Fill(ds, strsql)
        dt = ds.Tables(strsql)
        Con.Close()
        Return dt
    End Function

    Public Sub updateScannerList(entryId As Integer, newScannerName As String)
        'Receive new scanner name and add it to the combobox'
        frm.ConfigScannerName.Items.Add(newScannerName)
        'Create new folder in Laserfiche all the necessary Files for the new scanner'
        Try
            'Copy the scanner folder into the same directory And get the id of the New created folder
            Dim referenceFolder As FolderInfo = Folder.GetFolderInfo(entryId, session)
            Dim copiedEntryID As Int32 = referenceFolder.CopyTo("\\Settings\\" + newScannerName, EntryNameOption.None)

            'Disposed opened connections with Laserfiche
            referenceFolder.Dispose()

            Dim sw As StreamWriter = New StreamWriter(stationScannerDocument, False)
            sw.Write(newScannerName)
            sw.Close()

            Using scnreader As StreamReader = New StreamReader(stationScannerDocument)
                scanner = Trim(scnreader.ReadLine())
            End Using

            settingpath = settingpath.Replace(settingpath.Split("\").Last(), newScannerName)

        Catch ex As FileNotFoundException
            log("Error while reading the scanner name. Error Massege: " & ex.Message)
            MsgBox("Error while reading the scanner name. Error Massege: " & ex.Message)
        Catch ex As DirectoryNotFoundException
            log("Error while reading the scanner name. Error Massege: " & ex.Message)
            MsgBox("Error while reading the scanner name. Error Massege: " & ex.Message)
        Catch ex As IOException
            log("Error while reading the scanner name. Error Massege: " & ex.Message)
            MsgBox("Error while reading the scanner name. Error Massege: " & ex.Message)
        Catch ex As Exception
            log("Error while copying settings folder content. Error message: " & ex.Message)
            MsgBox("Error while copying settings folder content. Error message: " & ex.Message)
        End Try
    End Sub

End Module
