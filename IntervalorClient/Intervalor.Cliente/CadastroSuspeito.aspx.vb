Imports Intervalor.Cliente.SuspeitoServiceReference

Public Class CadastroSuspeito
    Inherits System.Web.UI.Page

    Private wcfSuspeito As New SuspeitoServiceClient

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Dim oSuspeitos As New List(Of Suspeito)

            oSuspeitos = wcfSuspeito.ListarTodos.ToList

            'Me.txtIdAluno.Text = oSuspeitos.Item(0).IdSuspeito
            'Me.txtNome.Text = oSuspeitos.Item(0).Nome

            Me.BindGrid(oSuspeitos)

        End If


    End Sub

    Private Sub BindGrid(ByVal oSuspeitos As List(Of Suspeito))
        gvSuspeitos.DataSource = oSuspeitos
        gvSuspeitos.DataBind()
    End Sub

End Class