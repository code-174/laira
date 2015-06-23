<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="LISTAR_FORMAS_PAGAMENTO.aspx.cs" Inherits="LISTAR_FORMAS_PAGAMENTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Listar Formas de Pagamento</legend>
            <form id="Form1" class="form col-md-7" runat="server">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <strong>Busca interna:</strong></div>
                <div class="panel-body">
                    <div class="form-inline">
                        <label class="sr-only" for="txtPagamento">
                            Sigla:</label>
                        <asp:TextBox ID="txtPagamento" runat="server" class="form-control" placeholder="Pagamento"></asp:TextBox>
                        <label class="sr-only" for="txtPaginas">
                            Total de resultados por página:</label>
                        <asp:TextBox ID="txtPaginas" runat="server" class="form-control" placeholder="Resultados por página"></asp:TextBox>
                        <asp:LinkButton ID="lnkFiltrar" runat="server" class="btn btn-success" OnClick="lnkFiltrar_Click">
                        <span class="glyphicon glyphicon-ok-sign"></span> Processar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            <div id="divPrint">
                <asp:GridView ID="grvData" runat="server" class="table">
                </asp:GridView>
            </div>
            <div class="btn-group btn-group-justified">
                <asp:LinkButton ID="lnkNew" runat="server" OnClick="lnkNew_Click" class="btn btn-primary">Adicionar Pagamento</asp:LinkButton>
                <asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');"
                    class="btn btn-info">Imprimir</asp:LinkButton>
                <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
