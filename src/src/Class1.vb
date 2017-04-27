Imports Newtonsoft.Json
Imports System.Net

Public Class Inegi
#Region "Actions"
    Function buscar(ByVal token As String, Optional search As String = "todos", Optional range As Integer = 250, Optional coords As String = "25.669234,-100.312108") As DataTable
        Dim url As String = String.Format("http://www3.inegi.org.mx/sistemas/api/denue/v1/consulta/buscar/{1}/{2}/{3}/{0}/", token, search, coords, range)
        Dim json = New WebClient().DownloadString(url)
        Return DirectCast(JsonConvert.DeserializeObject(json, (GetType(DataTable))), DataTable)
    End Function

    Function ficha(ByVal id As Integer, token As String) As DataTable
        Dim url As String = String.Format("http://www3.inegi.org.mx/sistemas/api/denue/v1/consulta/ficha/{0}/{1}/", id, token)
        Dim json As String = New WebClient().DownloadString(url)
        Return DirectCast(JsonConvert.DeserializeObject(json, (GetType(DataTable))), DataTable)
    End Function
#End Region
End Class
