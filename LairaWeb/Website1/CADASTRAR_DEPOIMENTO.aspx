<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_DEPOIMENTO.aspx.cs" Inherits="CADASTRAR_DEPOIMENTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Cadastrar Depoimento</legend>
            <form id="Form1" class="form-horizontal col-md-7" runat="server">
            <div class="form-group">
                <label for="txtNomeAeroporto" class="control-label col-md-2">
                    Cod. Depoimento</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCodDepoimento" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtNomeAeroporto" class="control-label col-md-2">
                    Nome</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtNome" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtNomeAeroporto" class="control-label col-md-2">
                    Cidade</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCidade" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtNomeAeroporto" class="control-label col-md-2">
                    Depoimento</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtDepoimento" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 col-md-offset-2">
                <div class="btn-group btn-group-justified">
                    <asp:LinkButton ID="lnkAdDepoimento" runat="server" OnClick="lnkAdDepoimento_Click"
                        class="btn btn-primary">Adicionar Depoimento</asp:LinkButton>
                    <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
                </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
