Imports System.IO
Imports System.Text

Public Class CreateServer

    Public tmp_AutoStart As String = "false"
    Public tmp_SilentStart As String = "false"
    Public ACTIVESERV As Boolean

    Public Function GETRequest(ByVal url)
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString(url)
        Return result
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ' !!! SETTINGS set autoStart

        If CheckBox1.Checked = True Then
            tmp_AutoStart = "true"
        Else
            tmp_AutoStart = "false"
        End If

        ' !!! SETTINGS set silentStart

        If CheckBox2.Checked = True Then
            tmp_SilentStart = "true"
        Else
            tmp_SilentStart = "false"
        End If

        ' !!! SETTINGS write changes

        Dim fs As FileStream = File.Create(Application.StartupPath + "/.settings")
        Dim info As Byte() = New UTF8Encoding(True).GetBytes("[settings]" + vbNewLine + "; do not touch JS or wrkDirectory unless you know what you are doing." + vbNewLine + "autoStart=" + tmp_AutoStart + vbNewLine + "silentStart=" + tmp_SilentStart + vbNewLine + "wrkDirectory=%d%\server\" + vbNewLine + "JS=start.bat")
        fs.Write(info, 0, info.Length)
        fs.Close()

        ' !!! Start Main Panel

        MainPanel.Show()
        MainPanel.IsServerActive = ACTIVESERV

        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub
End Class