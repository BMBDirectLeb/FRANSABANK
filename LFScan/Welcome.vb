Public Class Welcome
    Public frm As New Form1

    Private Sub Welcome_Load(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        loaddata()
        Me.Close()
    End Sub

    Private Sub Welcome_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim X As Integer = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Dim Y As Integer = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New System.Drawing.Point(X, Y)
        Timer1.Interval = 2000
        Timer1.Start()

    End Sub

End Class