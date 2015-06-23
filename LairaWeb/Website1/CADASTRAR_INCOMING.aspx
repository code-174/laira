<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_INCOMING.aspx.cs" Inherits="CADASTRAR_INCOMING" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Cadastrar Incoming</legend>
            <form id="Form1" class="form-horizontal col-md-7" runat="server">
            <div class="form-group">
                <label for="txtCodIncoming" class="control-label col-md-2">
                    Cod. Incoming</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCodIncoming" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtEmpresa" class="control-label col-md-2">
                    Empresa</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtEmpresa" runat="server" class="form-control"></asp:TextBox>
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
                <label for="txtEndereco" class="control-label col-md-2">
                    Endereço</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtEndereco" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtPais" class="control-label col-md-2">
                    País</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtPais" runat="server" class="form-control"></asp:TextBox>
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
                <label for="txtEmail" class="control-label col-md-2">
                    Email</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtSite" class="control-label col-md-2">
                    Site</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtSite" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtAtuacao" class="control-label col-md-2">
                    Atuação</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtAtuacao" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 col-md-offset-2">
                <div class="btn-group btn-group-justified">
                    <asp:LinkButton ID="lnkAdIncoming" runat="server" OnClick="lnkAdIncoming_Click" class="btn btn-primary">Adicionar Incoming</asp:LinkButton>
                    <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
                </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
