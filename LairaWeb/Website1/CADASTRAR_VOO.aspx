<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_VOO.aspx.cs" Inherits="CADASTRAR_VOO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Cadastrar Voo</legend>
            <form id="Form1" class="form-horizontal col-md-7" runat="server">
            <div class="form-group">
                <label for="txtNome" class="control-label col-md-2">
                    Nome</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtNome" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtSigla" class="control-label col-md-2">
                    Sigla</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtSigla" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtHora" class="control-label col-md-2">
                    Hora</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtHora" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtAeroporto" class="control-label col-md-2">
                    Aeroporto</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtAeroporto" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtTipo" class="control-label col-md-2">
                    Tipo</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtTipo" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 col-md-offset-2">
                <div class="btn-group btn-group-justified">
                    <asp:LinkButton ID="lnkAdVoo" runat="server" OnClick="lnkAdVoo_Click" class="btn btn-primary">Adicionar Voo</asp:LinkButton>
                    <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
                </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
