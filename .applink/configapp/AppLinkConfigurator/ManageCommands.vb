Public Class ManageCommands
    Dim glb_password As String = Nothing

    Dim tmp_id_id As String

    Public Function GETRequest(ByVal url)
        Dim webClient As New System.Net.WebClient
        Dim result As String = webClient.DownloadString(url)
        Return result
    End Function


End Class