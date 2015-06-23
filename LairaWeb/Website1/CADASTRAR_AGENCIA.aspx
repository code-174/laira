<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_AGENCIA.aspx.cs" Inherits="CADASTRAR_AGENCIA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Cadastrar Agência</legend>
            <form id="Form2" class="form-horizontal col-md-7" runat="server">
            <div class="form-group">
                <label for="txtCodAgencia" class="control-label col-md-2">
                    Cód. Agência</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCodAgencia" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtRazaoSocial" class="control-label col-md-2">
                    Razão Social</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtRazaoSocial" runat="server" class="form-control"></asp:TextBox>
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
                <label for="txtBairro" class="control-label col-md-2">
                    Bairro</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtBairro" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtCidade" class="control-label col-md-2">
                    Cidade</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCidade" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtUF" class="control-label col-md-2">
                    UF</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtUF" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtCEP" class="control-label col-md-2">
                    CEP</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCEP" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtCNPJ" class="control-label col-md-2">
                    CNPJ</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCNPJ" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtInscrMun" class="control-label col-md-2">
                    Inscr. Mun.</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtInscrMun" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtContatos" class="control-label col-md-2">
                    Contatos</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtContatos" runat="server" class="form-control"></asp:TextBox>
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
            <div class="col-md-6 col-md-offset-2">
                <div class="btn-group btn-group-justified">
                    <asp:LinkButton ID="lnkAdAgencia" runat="server" OnClick="lnkAdAgencia_Click" class="btn btn-primary">Adicionar Agência</asp:LinkButton>
                    <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
                </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
