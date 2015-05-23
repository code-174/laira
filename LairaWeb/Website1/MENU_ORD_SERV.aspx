<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MENU_ORD_SERV.aspx.cs" Inherits="MENU_ORD_SERV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
        .style2
        {
        }
        .style3
        {
        }
        .style7
        {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style2" colspan="2">
            <asp:Label ID="Label1" runat="server" Text="Ordem de Serviço" Font-Bold="True" 
                Font-Size="Large"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style7">
            <asp:Label ID="Label2" runat="server" Text="Gerar"></asp:Label>
        </td>
        <td>
            <asp:Button ID="btnGerar" runat="server" Text="Ok" />
        </td>
    </tr>
    </table>
    <p>
    </p>
    <table class="style1">
    <tr>
        <td class="style3" colspan="2">
            <asp:Label ID="Label3" runat="server" Text="Relatório"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style7">
            <asp:TextBox ID="txtDataRelatorio" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style7">
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Chegada</asp:ListItem>
                <asp:ListItem Value="Saida">Saída</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="btnRelatorio" runat="server" Text="Ok" />
        </td>
    </tr>
    </table>
    <p>
    </p>
    <table class="style1">
    <tr>
        <td class="style3" colspan="2">
            <asp:Label ID="Label4" runat="server" Text="Localizar"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style7">
            <asp:Label ID="Label5" runat="server" Text="№:"></asp:Label> &nbsp;
            <asp:TextBox ID="txtNumero" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnLocalizarNumero" runat="server" Text="Ok" />
        </td>
    </tr>
    </table>
</asp:Content>

