Public Class RemoveAppId
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Apps.DestroyIDReturn(TextBox1.Text)
        Me.Hide()
    End Sub
End Class