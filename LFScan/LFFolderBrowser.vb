Imports System.Windows.Forms
Imports Laserfiche.DocumentServices
Imports Laserfiche.RepositoryAccess

Public Class TVFolderBrowser
    Dim newScannerForm As New NewScanner
    Private myLFSession As Session = Nothing
    '*********************************
    '*********************************
#Region "Public Properties for Browser"
    Private _EntryId As Integer
    Public ReadOnly Property EntryId() As Integer
        Get
            Return _EntryId
        End Get
    End Property

    Private _Path As String
    Public ReadOnly Property Path() As String
        Get
            Return _Path
        End Get
    End Property

    Private _EntryName As String
    Public ReadOnly Property EntryName() As String
        Get
            Return _EntryName
        End Get
    End Property

    Private _sServerName As String
    Public WriteOnly Property LFServerName() As String
        Set(value As String)
            _sServerName = value
        End Set
    End Property

    Private _sRepositoryName As String
    Public WriteOnly Property LFRepositoryName() As String
        Set(value As String)
            _sRepositoryName = value
        End Set
    End Property

    Private _sUserName As String
    Public WriteOnly Property LFUserName() As String
        Set(value As String)
            _sUserName = value
        End Set
    End Property

    Private _sPassword As String
    Public WriteOnly Property LFPassword() As String
        Set(value As String)
            _sPassword = value
        End Set
    End Property

    Private _bWinAuth As Boolean
    Public WriteOnly Property bLFWinAuth() As Boolean
        Set(value As Boolean)
            _bWinAuth = value
        End Set
    End Property



#End Region
    '*********************************
    '*********************************
#Region "Private LF Log In/Out"

    Private Sub LFLogout()
        ' Only process if LFDatabase object is not nothing 
        If (myLFSession IsNot Nothing) Then
            Try
                ' Log Out 
                myLFSession.LogOut()
                myLFSession.Discard()
                ' Log Errors Here 

            Catch ex As Exception
            End Try
            ' Ensure LFDatabse object is nothing 
            myLFSession = Nothing
        End If
    End Sub

    Private Sub LFLogin(sServer As String, sRepo As String, bWinAuth As Boolean, Optional sUser As String = "admin", Optional sPW As String = "admin")
        ' Only process if LFDatabase object is nothing 
        If myLFSession Is Nothing Then
            Try
                ' Create LFServer object for server 
                Dim lfserv As New Server(sServer)
                ' Set LFRepository object 
                Dim LFRepo As New RepositoryRegistration(lfserv, sRepo)
                myLFSession = New Session()
                myLFSession.ApplicationName = Application.ProductName
                ' Process Authentication 
                If bWinAuth Then
                    ' Use blank User and Password for WinAuth 
                    myLFSession.LogIn(LFRepo)
                Else
                    'Do not use empty user name for LF Auth (if that is what was passed) 
                    If String.IsNullOrEmpty(sUser) Then
                        ' Try using admin with blank password 
                        sUser = "admin"
                        sPW = "admin"
                    End If
                    myLFSession.LogIn(sUser, sPW, LFRepo)
                End If
            Catch ex As Exception
                ' Log Errors Here 
                log("Error while logging in to Laserfiche Repository. Error Message: " & ex.Message)
                MsgBox("Error while logging in to Laserfiche Repository. Error Message: " & ex.Message)
                ' Ensure Session object is nothing 
                myLFSession = Nothing
            End Try
        End If
    End Sub

#End Region
    '*********************************
    '*********************************
#Region "Form Actions for Browser"

    'Public Sub New(ByVal LFServerName As String, ByVal LFRepositoryName As String, ByVal UseWindowsAuthentication As Boolean, ByVal LFUserName As String, ByVal LFPassword As String)
    '    'MyBase.New()
    '    'InitializeComponent()
    '     LFLogin(LFServerName, LFRepositoryName, UseWindowsAuthentication, LFUserName, LFPassword)
    'End Sub

    Public Sub startConnection(ByVal LFServerName As String, ByVal LFRepositoryName As String, ByVal UseWindowsAuthentication As Boolean, ByVal LFUserName As String, ByVal LFPassword As String)
        'MyBase.New()
        'InitializeComponent()
        LFLogin(LFServerName, LFRepositoryName, UseWindowsAuthentication, LFUserName, LFPassword)
    End Sub

    Private Sub TVWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Make TreeView fill panel1
        Me.TVWindow.Dock = DockStyle.Fill
        ' Initialize TreeView
        InitTV()
    End Sub

    Private Sub TVWindow_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        ' Cleanup
        LFLogout()
    End Sub

#End Region
    '*********************************
    '*********************************
#Region "Private Subs & Functions"

    Private Sub InitTV()
        ' Create new Node
        Dim RootTreeNode As New TreeNode
        ' Set Node Text = Repository name
        RootTreeNode.Text = myLFSession.Repository.Name
        ' Make new Node expandable
        RootTreeNode.Nodes.Add("")
        ' Add new Node to TreeView
        TVWindow.Nodes.Add(RootTreeNode)
        ' Expand new Node
        TVWindow.Nodes.Item(0).Expand()
    End Sub

    Private Sub tvFolderTree_AfterExpand(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TVWindow.AfterExpand
        ' Clear any existing child nodes
        e.Node.Nodes.Clear()
        ' Get full path from node
        Dim sFullPath As String = e.Node.FullPath
        ' Remove repository name from path for LF use
        If sFullPath.Contains("\") Then
            sFullPath = sFullPath.Replace(sFullPath.Substring(0, sFullPath.IndexOf("\")), "")
        Else
            sFullPath = "\"
        End If
        Try
            'Create FolderInfo object fron Node path
            Dim LFFold As FolderInfo = Folder.GetFolderInfo(sFullPath, myLFSession)
            ' configure which columns to retrieve
            Dim entrySetting As New EntryListingSettings()
            ' Only get folders
            entrySetting.EntryFilter = EntryTypeFilter.Folders
            ' Include Entry Type
            entrySetting.AddColumn(SystemColumn.EntryType)
            ' Include Entry Name
            entrySetting.AddColumn(SystemColumn.DisplayName)
            ' get the contents of the lf folder
            Using listing As FolderListing = LFFold.OpenFolderListing(entrySetting, 1000)
                ' the listing is 1-based, 
                Dim rowCount As Integer = listing.RowsCount
                For i As Integer = 1 To rowCount
                    ' Process only folders
                    ' Listing should never get anything other than folder, but will check anyway
                    If listing.GetDatumAsString(i, SystemColumn.EntryType).ToLower = "folder" Then
                        ' Create new Node
                        Dim NewTreeNode As New TreeNode
                        ' Set Node Text = folder name
                        NewTreeNode.Text = listing.GetDatumAsString(i, SystemColumn.DisplayName)
                        ' Make new Node expandable
                        NewTreeNode.Nodes.Add("")
                        ' Add new Node to TreeView
                        e.Node.Nodes.Add(NewTreeNode)
                    End If
                Next
            End Using
            ' Cleanup
            LFFold.Dispose()
            LFFold = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Public Sub tvFolderTree_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TVWindow.AfterSelect
        ' Get full path from node
        Dim sFullPath As String = e.Node.FullPath
        ' Remove repository name from path for LF use
        If sFullPath.Contains("\") Then
            sFullPath = sFullPath.Replace(sFullPath.Substring(0, sFullPath.IndexOf("\")), "")
        Else
            sFullPath = "\"
        End If
        Try

            'Create FolderInfo object from Node path
            Dim LFFold As FolderInfo = Folder.GetFolderInfo(sFullPath, myLFSession)
            ' Get Entry ID of selected Node
            _EntryId = LFFold.Id
            referenceFolderID = LFFold.Id

            ' Get full path of folder
            _Path = LFFold.Path
            referenceFolderPath = LFFold.Path

            ' Get Entry Name of Selected Node
            _EntryName = LFFold.Name
            referenceFolderName = LFFold.Name

            'changeScannerNameText(LFFold.Name)

            ' Cleanup
            LFFold.Dispose()
            LFFold = Nothing
        Catch ex As Exception

        End Try
    End Sub

#End Region
    '*********************************
    '*********************************
#Region "Button Actions for Browser"
    Private Sub BtnTVOk_Click(sender As Object, e As EventArgs) Handles BtnTVOk.Click
        copyFromChoice = True
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnTVCancel_Click(sender As Object, e As EventArgs) Handles BtnTVCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class

#End Region