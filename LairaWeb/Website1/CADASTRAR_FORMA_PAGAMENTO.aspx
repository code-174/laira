<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CADASTRAR_FORMA_PAGAMENTO.aspx.cs" Inherits="CADASTRAR_FORMA_PAGAMENTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 344px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Cadastrar Forma de Pagamento"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Forma de Pagamento"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFormaPagamento" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Tipo"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlTipo" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAdFormaPagamento" runat="server" 
                    Text="Adicionar Forma de Pagamento" />
            </td>
        </tr>
    </table>
</asp:Content>

