Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.SqlServer

Public Class ConnectToServer

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

    Public AutoStart As Boolean = False
    Public SilentStart As Boolean = False

    Public Function GETRequest(ByVal url)
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString(url)
        Return result
    End Function

    Public Sub ResponsiveSleep(ByRef iMilliSeconds As Integer)
        Dim i As Integer, iHalfSeconds As Integer = iMilliSeconds / 500
        For i = 1 To iHalfSeconds
            Threading.Thread.Sleep(500) : Application.DoEvents()
        Next i
    End Sub

    Private Sub ConnectToServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(Application.StartupPath + "/.settings") Then

            ' !! SETTINGS (AutoStart, SilentStart)

            If GetIniValue("settings", "autoStart", Application.StartupPath + "/.settings", "false") = "true" Then
                AutoStart = True
            Else
                AutoStart = False
            End If

            If GetIniValue("settings", "silentStart", Application.StartupPath + "/.settings", "false") = "true" Then
                SilentStart = True
            Else
                SilentStart = False
            End If

        Else
            Dim fs As FileStream = File.Create(Application.StartupPath + "/.settings")
            Dim info As Byte() = New UTF8Encoding(True).GetBytes("[settings]" + vbNewLine + "; do not touch JS or wrkDirectory unless you know what you are doing." + vbNewLine + "autoStart=false" + vbNewLine + "silentStart=false" + vbNewLine + "wrkDirectory=%d%\server\" + vbNewLine + "JS=start.bat")
            fs.Write(info, 0, info.Length)
            fs.Close()
        End If

        act.Start()

    End Sub

    Private Sub act_Tick(sender As Object, e As EventArgs) Handles act.Tick
        act.Stop()
        ResponsiveSleep(1000)
        Try
            Dim PingServerResult = GETRequest("http://localhost:9989/ping")
            MainPanel.Show()
            Me.Hide()
        Catch ex As Exception
            If AutoStart Then
                MainPanel.Show()
                If SilentStart Then
                    MainPanel.Server_Properties.CreateNoWindow = True
                    MainPanel.Server_Properties.WindowStyle = ProcessWindowStyle.Hidden
                    Me.Hide()
                    MainPanel.IsServerActive = False
                    MainPanel.Server_Properties.FileName = MainPanel.temp_WorkDir + MainPanel.temp_MainJS
                    MainPanel.Server.Start(MainPanel.Server_Properties)
                    MainPanel.IsServerActive = True
                    MainPanel.Close()
                Else
                    MainPanel.Server_Properties.CreateNoWindow = True
                    MainPanel.Server_Properties.WindowStyle = ProcessWindowStyle.Hidden
                    MainPanel.IsServerActive = False
                    MainPanel.Server_Properties.FileName = MainPanel.temp_WorkDir + MainPanel.temp_MainJS
                    MainPanel.Server.Start(MainPanel.Server_Properties)
                    MainPanel.IsServerActive = True
                End If
            Else
                CreateServer.Show()
                CreateServer.ACTIVESERV = False
                Me.Hide()
            End If
        End Try
    End Sub

    Private Sub ConnectToServer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Process.Start(Application.StartupPath + "\force_stop_server.bat")
    End Sub
End Class