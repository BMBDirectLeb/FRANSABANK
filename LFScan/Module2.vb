Imports Laserfiche.DocumentServices
Imports Laserfiche.RepositoryAccess
Imports System.IO
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports System.Diagnostics.Eventing

Module Module2

  connectionString = "Data Source=FC12-VM\SQLEXPRESS;Initial Catalog=GeneralTest;Integrated Security=True"


        Using connection As New SqlConnection(connectionString)
            ' Open the connection
            connection.Open()

            ' SQL query
            Dim query As String = "SELECT * FROM dbo.Fransabank_Branches"

    ' Create a SqlCommand object with the query and connection
    Using command As New SqlCommand(query, connection)
    Using reader As SqlDataReader = command.ExecuteReader()
    While reader.Read()
    Dim BranchCode = Reader.GetString(Reader.GetOrdinal("Branch_Code"))
    Dim branchName = Reader.GetString(Reader.GetOrdinal("Branch_Name"))

                        MsgBox("Branch ID: " & BranchCode)

                        MsgBox("Branch Name: " & branchName)
                    End While
    End Using
    End Using
            connection.Close()

        End Using


End Module
