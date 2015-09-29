<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_AEROPORTO_OLD.aspx.cs" Inherits="INCLUIR_AEROPORTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Cadastrar Aeroporto</legend>
            <form class="form-horizontal col-md-7" runat="server">
            <div class="form-group">
                <label for="txtNomeAeroporto" class="control-label col-md-2">
                    Nome</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtNomeAeroporto" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtSiglaAeroporto" class="control-label col-md-2">
                    Sigla</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtSiglaAeroporto" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 col-md-offset-2">
            <div class="btn-group btn-group-justified">
                <asp:LinkButton ID="lnkAdAeroporto" runat="server" OnClick="lnkAdAeroporto_Click"
                    class="btn btn-primary">Adicionar Aeroporto</asp:LinkButton>
                <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
            </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
