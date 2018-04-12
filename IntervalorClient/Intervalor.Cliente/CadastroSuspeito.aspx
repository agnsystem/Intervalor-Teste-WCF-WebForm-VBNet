<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CadastroSuspeito.aspx.vb" Inherits="Intervalor.Cliente.CadastroSuspeito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <br />
            <fieldset>
                <legend>Cadastro de Suspeitos</legend>
                <div class="well">
<%--                    <div class="row">
                        <asp:Label ID="lblIdAluno" runat="server" Text="ID: "></asp:Label>
                        <asp:TextBox ID="txtIdAluno" runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <div class="row">
                        <asp:Label ID="lblNome" runat="server" Text="Nome: "></asp:Label>
                        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                    </div>--%>
                    <div>
                        <asp:GridView ID="gvSuspeitos" runat="server">
                            <Columns>
                                <asp:BoundField DataField="IdSuspeito" HeaderText="Id" />
                                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
