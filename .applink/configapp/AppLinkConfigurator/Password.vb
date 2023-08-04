Public Class Password

    Public returnint As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Apps.PassReturn(TextBox1.Text, returnint)
    End Sub

    Private Sub Password_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Apps.Close()
    End Sub
End Class