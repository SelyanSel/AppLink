Public Class Apps

    Dim glb_password As String = Nothing

    Dim tmp_id_id As String

    Public Function GETRequest(ByVal url)
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString(url)
        Return result
    End Function

    Private Sub Apps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim t1_result = GETRequest("http://localhost:9989/api/isUsingPassword")
        If t1_result.ToString = "true" Then
            Password.Show()
            Password.returnint = 0
        Else
            Dim t2_result = GETRequest("http://localhost:9989/api/getApps")
            RichTextBox1.Text = t2_result.ToString
        End If
    End Sub

    Private Sub Apps_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MainPanel.Show()
    End Sub

    Public Sub RefreshApps()
        RichTextBox1.Text = Nothing
        Dim t1_result = GETRequest("http://localhost:9989/api/isUsingPassword")
        If t1_result.ToString = "true" Then
            Try
                Dim t2_result = GETRequest("http://localhost:9989/api/getApps?pass=" + glb_password)
                RichTextBox1.Text = t2_result.ToString
                glb_password = glb_password
            Catch ex As Exception
                MsgBox("Error occured. Server is offline, or password is incorrect.", MsgBoxStyle.Critical)
                Password.Show()
                Password.returnint = 0
            End Try
        Else
            Dim t2_result = GETRequest("http://localhost:9989/api/getApps")
            RichTextBox1.Text = t2_result.ToString
        End If
    End Sub

    Public Sub PassReturn(ByVal passwor, ByVal int)
        If int = 0 Then
            Try
                Dim t2_result = GETRequest("http://localhost:9989/api/getApps?pass=" + passwor)
                RichTextBox1.Text = t2_result.ToString
                glb_password = passwor
            Catch ex As Exception
                MsgBox("Error occured. Server is offline, or password is incorrect.", MsgBoxStyle.Critical)
                Password.Show()
                Password.returnint = int
            End Try
        ElseIf int = 1 Then
            Try
                Dim t2_result = GETRequest("http://localhost:9989/api/removeAppFromID?id=" + tmp_id_id + "&pass=" + passwor)
                RefreshApps()
            Catch ex As Exception
                MsgBox("Error occured. Server is offline, or password is incorrect.", MsgBoxStyle.Critical)
                Password.Show()
                Password.returnint = 1
            End Try
        ElseIf int = 2 Then
            Dim id = TextBox3.Text
            Dim name = TextBox2.Text
            Dim path = TextBox1.Text

            Dim t1_result = GETRequest("http://localhost:9989/api/createApp?id=" + id + "&name=" + name + "&path=" + path + "&pass=" + passwor)
            RefreshApps()

            Panel1.Visible = False

        End If

        glb_password = passwor
    End Sub

    Public Sub DestroyIDReturn(ByVal id)
        Try
            tmp_id_id = id
            Dim t1_result = GETRequest("http://localhost:9989/api/isUsingPassword")
            If t1_result.ToString = "false" Then
                Try
                    Dim t2_result = GETRequest("http://localhost:9989/api/removeAppFromID?id=" + id)
                    RefreshApps()

                    Panel1.Visible = False

                Catch ex As Exception
                    MsgBox("Error occured. Server is offline, or password is incorrect.", MsgBoxStyle.Critical)
                    Password.Show()
                    Password.returnint = 1
                End Try
            Else
                Password.Show()
                Password.returnint = 1
            End If
        Catch ex As Exception
            MsgBox("Error occured. Server is offline, or password is incorrect.", MsgBoxStyle.Critical)
            Password.Show()
            Password.returnint = 1
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RemoveAppId.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim id = TextBox3.Text
            Dim name = TextBox2.Text
            Dim path = TextBox1.Text

            Dim t1_result = GETRequest("http://localhost:9989/api/createApp?id=" + id + "&name=" + name + "&path=" + path + "&pass=" + glb_password)
            RefreshApps()

        Catch ex As Exception
            MsgBox("Error occured. Server is offline, or password is incorrect.", MsgBoxStyle.Critical)
            Password.Show()
            Password.returnint = 2
        End Try
    End Sub
End Class