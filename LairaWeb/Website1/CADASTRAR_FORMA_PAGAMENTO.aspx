<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_FORMA_PAGAMENTO.aspx.cs" Inherits="CADASTRAR_FORMA_PAGAMENTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Cadastrar Forma de Pagamento</legend>
            <form id="Form1" class="form-horizontal col-md-7" runat="server">
            <div class="form-group">
                <label for="txtCodFormaPagamento" class="control-label col-md-3">
                    Cod. Forma de Pag
                </label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCodFormaPagamento" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtFormaPagamento" class="control-label col-md-3">
                    Forma de Pagamento
                </label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtFormaPagamento" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtTipoFormaPagamento" class="control-label col-md-3">
                    Tipo
                </label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtTipoFormaPagamento" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 col-md-offset-3">
                <div class="btn-group btn-group-justified">
                    <asp:LinkButton ID="lnkAdFormaPagamento" runat="server" OnClick="lnkAdFormaPagamento_Click"
                        class="btn btn-primary">Adicionar Forma de Pag.</asp:LinkButton>
                    <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
                </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
