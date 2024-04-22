Imports Laserfiche.RepositoryAccess

Public Class Browse_Folders
    Dim btnokXDef As String = 0
    Dim btnokYDef As String = 0
    Dim btnCancelXDef As String = 0
    Dim btnCancelYDef As String = 0
    Dim treeviewWidthDef As String = 0
    Dim treeviewHeightDef As String = 0
    'Public parentForm As Form1
    Public parentTxt As TextBox
    Private Sub Browse_Folders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnokXDef = Me.Size.Width - BtnOK.Location.X
        btnokYDef = Me.Size.Height - BtnOK.Location.Y
        btnCancelXDef = Me.Size.Width - BtnCancel.Location.X
        btnCancelYDef = Me.Size.Height - BtnCancel.Location.Y

        treeviewWidthDef = Me.Size.Width - TreeView1.Size.Width
        treeviewHeightDef = Me.Size.Height - TreeView1.Size.Height

        Dim myImageList As ImageList = New ImageList()
        myImageList.Images.Add(Image.FromFile("Folder.ico"))
        myImageList.Images.Add(Image.FromFile("folderOpen.ico"))
        TreeView1.ImageList = myImageList
        Dim basenode As System.Windows.Forms.TreeNode
        basenode = TreeView1.Nodes.Add("1", rep, 0, 1)
        basenode.Tag = "\"
        loadDir(Folder.GetFolderInfo(1, session), basenode)
    End Sub

    Sub loadDir(ByVal MainFolder As FolderInfo, MainNode As TreeNode)

        Dim settings As EntryListingSettings = New EntryListingSettings()

        settings.AddColumn(SystemColumn.Name)

        settings.AddColumn(SystemColumn.Id)

        settings.EntryFilter = EntryTypeFilter.Folders

        settings.SetSortColumn(SystemColumn.Name, SortDirection.Ascending)

        Dim subfolders As List(Of Integer) = New List(Of Integer)
        Dim subnode As TreeNode

        Using listing As FolderListing = MainFolder.OpenFolderListing(settings)
            For Each row In listing
                Dim entryID As Integer = row(SystemColumn.Id)
                Dim subfolder As FolderInfo = Folder.GetFolderInfo(entryID, session)
                subnode = MainNode.Nodes.Add(entryID.ToString, subfolder.Name, 0, 1)
                subnode.Tag = subfolder.Path & "\" & subfolder.Name
                loadDir(subfolder, subnode)
            Next
        End Using

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        parentTxt.FindForm.Activate()
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        NewScanner.TxtChosenScannerFolder.Text = TreeView1.SelectedNode.Tag.ToString
        'parentTxt.FindForm.Activate()
        Me.Close()

    End Sub

    Private Sub Browse_Folders_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If btnokXDef = 0 Then
            btnokXDef = Me.Size.Width - BtnOK.Location.X
            btnokYDef = Me.Size.Height - BtnOK.Location.Y
            btnCancelXDef = Me.Size.Width - BtnCancel.Location.X
            btnCancelYDef = Me.Size.Height - BtnCancel.Location.Y

            treeviewWidthDef = Me.Size.Width - TreeView1.Size.Width
            treeviewHeightDef = Me.Size.Height - TreeView1.Size.Height
        End If
        BtnOK.Location = New Point(Me.Size.Width - btnokXDef, Me.Size.Height - btnokYDef)
        BtnCancel.Location = New Point(Me.Size.Width - btnCancelXDef, Me.Size.Height - btnCancelYDef)
        TreeView1.Width = Me.Size.Width - treeviewWidthDef
        TreeView1.Height = Me.Size.Height - treeviewHeightDef

    End Sub

    'Private Sub Browse_Folders_Activated(sender As Object, e As EventArgs) Handles Me.Activated
    '    MsgBox(Me.Size.Width)
    '    btnokXDef = Me.Size.Width - BtnOK.Location.X
    '    btnokYDef = Me.Size.Height - BtnOK.Location.Y
    '    btnCancelXDef = Me.Size.Width - BtnCancel.Location.X
    '    btnCancelYDef = Me.Size.Height - BtnCancel.Location.Y

    '    treeviewWidthDef = Me.Size.Width - TreeView1.Size.Width
    '    treeviewHeightDef = Me.Size.Height - TreeView1.Size.Height
    '    MsgBox(btnokXDef)
    'End Sub
End Class