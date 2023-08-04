Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Public Class MainPanel

    Public Server As New Process()
    Public Server_Properties As New ProcessStartInfo()

    Public temp_WorkDir = ""
    Public temp_MainJS = ""

    Public IsServerActive As Boolean = False

    Public AllowClose As Boolean = False

    <DllImport("kernel32")>
    Private Shared Function GetPrivateProfileString(ByVal section As String, ByVal key As String, ByVal def As String, ByVal retVal As StringBuilder, ByVal size As Integer, ByVal filePath As String) As Integer
    End Function

    Public Function GetIniValue(section As String, key As String, filename As String, Optional defaultValue As String = "") As String
        Dim sb As New StringBuilder(500)
        If GetPrivateProfileString(section, key, defaultValue, sb, sb.Capacity, filename) > 0 Then
            Return sb.ToString
        Else
            Return defaultValue
        End If
    End Function

    Public Function GETRequest(ByVal url)
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString(url)
        Return result
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' !!! get server start settings from settings

        temp_WorkDir = GetIniValue("settings", "wrkDirectory", Application.StartupPath + "\.settings")
        temp_WorkDir = temp_WorkDir.ToString.Replace("%d%", Application.StartupPath)

        temp_MainJS = GetIniValue("settings", "JS", Application.StartupPath + "\.settings")

        ' !!! server starting settings

        Server_Properties.CreateNoWindow = True
        Server_Properties.WindowStyle = ProcessWindowStyle.Hidden

        Server_Properties.WorkingDirectory = temp_WorkDir
        Server_Properties.FileName = temp_WorkDir + temp_MainJS

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ' !!! Check deps

        If Not Directory.Exists(temp_WorkDir + "\node_modules") Then
            Dim temp_startS As New ProcessStartInfo
            temp_startS.WorkingDirectory = temp_WorkDir
            temp_startS.FileName = temp_WorkDir + "\install-modules.bat"
            Process.Start(temp_startS)
            MsgBox("Modules needs to be installed. Wait until the window that popped up is closed, then try again.", MsgBoxStyle.Information, "AppLink")
            Exit Sub
        End If

        If IsServerActive = False Then
            Server_Properties.FileName = temp_WorkDir + temp_MainJS
            Server.Start(Server_Properties)
            IsServerActive = True
        Else
            Process.Start(Application.StartupPath + "\force_stop_server.bat")
            Server_Properties.FileName = temp_WorkDir + temp_MainJS
            Server.Start(Server_Properties)
            IsServerActive = True
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Server_Properties.CreateNoWindow = False
            Server_Properties.WindowStyle = ProcessWindowStyle.Normal
        Else
            Server_Properties.CreateNoWindow = True
            Server_Properties.WindowStyle = ProcessWindowStyle.Hidden
        End If

    End Sub

    Private Sub MainPanel_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not AllowClose Then
            e.Cancel = True
            Me.Hide()
            NotifyIcon1.ShowBalloonTip(2000, "AppLink active", "AppLink is running in the background. The app is available in the icon tray.", ToolTipIcon.Info)
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
    End Sub

    Private Sub NotifyIcon1_Click(sender As Object, e As EventArgs) Handles NotifyIcon1.Click
        Me.Show()
    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(sender As Object, e As EventArgs) Handles NotifyIcon1.BalloonTipClicked
        Me.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AllowClose = True
        ConnectToServer.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Apps.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.Enabled = False
        Try
            Dim PingServerResult = GETRequest("http://localhost:9989/ping")
            active.Show()
            inactive.Hide()
            IsServerActive = True
            Button5.Enabled = True
        Catch ex As Exception
            active.Hide()
            inactive.Show()
            IsServerActive = False
            Button5.Enabled = True
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("Manage Commands feature is still in beta. To create / edit cmd commands, please refer to the wiki on the github page.")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Process.Start("https://github.com/SelyanSel/AppLink")
    End Sub
End Class
