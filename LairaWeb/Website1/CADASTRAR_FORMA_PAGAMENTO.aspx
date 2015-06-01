<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_FORMA_PAGAMENTO.aspx.cs" Inherits="CADASTRAR_FORMA_PAGAMENTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="headd">
        <table class="style1">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Cadastrar Forma de Pagamento"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label14" runat="server" Text="Cod Forma de Pag"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCodFormaPagamento" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label2" runat="server" Text="Forma de Pagamento"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFormaPagamento" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label3" runat="server" Text="Tipo"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTipoFormaPagamento" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton ID="btnAdFormaPagamento" runat="server" OnClick="btnAdFormaPagamento_Click">[Adicionar Forma de Pagamento]</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnVoltar" runat="server" OnClick="btnVoltar_Click">[Voltar]</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
