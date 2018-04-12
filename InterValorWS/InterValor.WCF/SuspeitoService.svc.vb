Imports System.Data.SqlClient

' NOTE: You can use the "Rename" command on the context menu to change the class name "SuspeitoService" in code, svc and config file together.
' NOTE: In order to launch WCF Test Client for testing this service, please select SuspeitoService.svc or SuspeitoService.svc.vb at the Solution Explorer and start debugging.
Public Class SuspeitoService
    Implements ISuspeitoService

    Public Function ListarTodos() As IEnumerable(Of Suspeito) Implements ISuspeitoService.ListarTodos
        Dim oContexto As New Contexto
        Dim strQuery = " SELECT * from Suspeito "
        'Dim retornoDataReader = oContexto.gerarDataHeader(strQuery)

        Return oContexto.gerarDataHeader(strQuery)

    End Function

End Class
