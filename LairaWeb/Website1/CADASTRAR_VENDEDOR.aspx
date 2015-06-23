<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_VENDEDOR.aspx.cs" Inherits="CADASTRAR_VENDEDOR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Cadastrar Vendedor</legend>
            <form id="Form1" class="form-horizontal col-md-7" runat="server">
            <div class="form-group">
                <label for="txtCodigo" class="control-label col-md-2">
                    Cod. Vendedor</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtNome" class="control-label col-md-2">
                    Nome</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtNome" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtTelefone" class="control-label col-md-2">
                    Telefone</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtTelefone" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtCelular" class="control-label col-md-2">
                    Celular</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCelular" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 col-md-offset-2">
                <div class="btn-group btn-group-justified">
                    <asp:LinkButton ID="lnkVendedor" runat="server" OnClick="lnkVendedor_Click" class="btn btn-primary">Adicionar Vendedor</asp:LinkButton>
                    <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
                </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
