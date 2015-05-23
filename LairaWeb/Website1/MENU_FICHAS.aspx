<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MENU_FICHAS.aspx.cs" Inherits="MENU_FICHAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style3
    {
        height: 29px;
    }
    .style4
    {
        width: 201px;
    }
    .style5
    {
        width: 200px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style3" colspan="2">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" 
                Text="Fichas"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style4">
            <asp:Label ID="Label2" runat="server" Text="Cadastrar Ficha"></asp:Label>
        </td>
        <td>
            <asp:Button ID="btnCadastrarFicha" runat="server" Text="Ok" />
        </td>
    </tr>
</table>
<p>
</p>
<table class="style1">
    <tr>
        <td class="style5">
            <asp:Label ID="Label3" runat="server" Text="Listar Ficha"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>Chegada</asp:ListItem>
                <asp:ListItem Value="Saida">Saída</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            <asp:TextBox ID="txtListarFicha" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnListarFicha" runat="server" Text="Ok" />
        </td>
    </tr>
</table>
<p>
</p>
<table class="style1">
    <tr>
        <td class="style5">
            <asp:Label ID="Label5" runat="server" Text="Relatório"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                <asp:ListItem>Chegada</asp:ListItem>
                <asp:ListItem Value="Saida">Saída</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            <asp:TextBox ID="txtDataRelatorio" runat="server"></asp:TextBox>
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
        <td class="style5">
            <asp:Label ID="Label6" runat="server" Text="Localizar"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            <asp:RadioButtonList ID="RadioButtonList3" runat="server">
                <asp:ListItem Value="Numero">Número</asp:ListItem>
                <asp:ListItem Value="CodExc">Cod. Excursão</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            <asp:TextBox ID="txtLocalizar" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnLocalizar" runat="server" Text="Ok" />
        </td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style5">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

