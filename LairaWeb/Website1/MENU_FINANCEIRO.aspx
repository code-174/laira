<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MENU_FINANCEIRO.aspx.cs" Inherits="MENU_FINANCEIRO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 38px;
        }
        .style3
        {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="2">
            <asp:Label ID="Label1" runat="server" Text="Financeiro" Font-Bold="True" 
                    Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
            <asp:Label ID="Label2" runat="server" Text="Emitir Faturas"></asp:Label>
            </td>
            <td>
            <asp:Button ID="btnEmitirFaturas" runat="server" Text="Ok" />
            </td>
        </tr>
        </table>
    <p>
    </p>
    <table class="style1">
        <tr>
            <td class="style3">
            <asp:Label ID="Label3" runat="server" Text="Relatório de Vendedores"></asp:Label>
            </td>
            <td>
            <asp:Button ID="btnRelatorioVendedores" runat="server" Text="Ok" />
            </td>
        </tr>
        </table>
    <p>
    </p>
    <table class="style1">
        <tr>
            <td colspan="2">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem>Baixar</asp:ListItem>
                    <asp:ListItem Value="Relatorios">Relatórios</asp:ListItem>
                    <asp:ListItem>Imprimir</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style2">
            <asp:Label ID="Label5" runat="server" Text="de:"></asp:Label>
            </td>
            <td>
            <asp:TextBox ID="txtDataInic" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
            <asp:Label ID="Label6" runat="server" Text="até:"></asp:Label>
            </td>
            <td>
            <asp:TextBox ID="txtDataFinal" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Vencimento</asp:ListItem>
                    <asp:ListItem Value="Emissao">Emissão</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <p>
    </p>
    <table class="style1">
        <tr>
            <td class="style3">
            <asp:Label ID="Label8" runat="server" Text="Localizar"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
            <asp:Label ID="Label9" runat="server" Text="№:"></asp:Label>
            <asp:TextBox ID="txtNumero" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label11" runat="server" Text="Agência"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:DropDownList ID="ddlAgencia" runat="server">
                    <asp:ListItem>Todos</asp:ListItem>
                    <asp:ListItem>CVC BRASIL</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:Button ID="btnLocalizarFatura" runat="server" Text="Ok" />
            </td>
        </tr>
    </table>
</asp:Content>

