Imports System
Imports System.Data
Imports System.Linq
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Configuration


Public Class Contexto
    Implements IDisposable

    Private ReadOnly dbConexao As SqlConnection

    Sub New()

        dbConexao = New SqlConnection(ConfigurationManager.ConnectionStrings("dbHandsOn").ConnectionString)
        dbConexao.Open()

    End Sub

    Public Sub executarComando(ByVal strQuery As String)

        Dim cmdComando As New SqlCommand

        Try
            Dim Trans As SqlTransaction = dbConexao.BeginTransaction()
            cmdComando.CommandType = CommandType.Text

            Try
                cmdComando = New SqlCommand(strQuery, dbConexao, Trans)
                Trans.Commit()

            Catch ex As Exception
                Trans.Rollback()
                Throw New System.Exception("Erro de execução na intrução SQL")
            End Try

        Catch ex As Exception
            Throw New System.Exception("Erro de conexão no banco de dados")

        Finally

            If dbConexao.State = ConnectionState.Open Then
                dbConexao.Close()
            End If

        End Try

    End Sub

    Public Function gerarDataHeader(ByVal strQuery As String) As List(Of Suspeito)

        Try
            Dim cmdComando = New SqlCommand(strQuery, dbConexao)
            Dim retornoDataReader = cmdComando.ExecuteReader

            Return gerarListaDeObjetos(retornoDataReader)

        Catch ex As Exception
            Throw New System.Exception("Erro na geração do dataReader ")

        Finally

            If dbConexao.State = ConnectionState.Open Then
                dbConexao.Close()
            End If

        End Try

    End Function

    Private Function gerarListaDeObjetos(ByVal dReader As SqlDataReader) As List(Of Suspeito)
        Dim oSuspeitos As New List(Of Suspeito)

        Try
            While (dReader.Read())
                Dim oSuspeito As New Suspeito

                With oSuspeito
                    .IdSuspeito = CInt(dReader("IdSuspeito").ToString)
                    .Nome = dReader("Nome").ToString
                End With

                oSuspeitos.Add(oSuspeito)

            End While

        Catch ex As Exception
            Throw New Exception("Erro ao carrregar lista de suspeitos (dataReader)")

        Finally
            dReader.Close()

        End Try

        Return oSuspeitos

    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
