<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MENU_ORD_SERV_ADC.aspx.cs" Inherits="MENU_ORD_SERV_ADC" %>

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
        .style4
        {
            width: 38px;
            height: 21px;
        }
        .style5
        {
            height: 21px;
        }
        .style6
        {
            width: 200px;
        }
        .style7
        {
        }
        .style9
        {
            width: 38px;
        }
        .style10
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2" colspan="2">
            <asp:Label ID="Label1" runat="server" Text="Ordem de Serviço Adicional" 
                    Font-Bold="True" Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
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
            <td class="style6">
            <asp:TextBox ID="txtDataRelatorio" runat="server"></asp:TextBox>
            </td>
            <td>
            <asp:Button ID="btnRelatorio" runat="server" Text="Ok" Width="31px" />
            </td>
        </tr>
        </table>
    <p>
    </p>
    <table class="style1">
        <tr>
            <td class="style3" colspan="2">
            <asp:Label ID="Label4" runat="server" Text="Relatório do Prestador"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4">
            <asp:Label ID="Label5" runat="server" Text="de:"></asp:Label>
            </td>
            <td class="style5">
            <asp:TextBox ID="txtDataInicPrestador" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style9">
            <asp:Label ID="Label6" runat="server" Text="até:"></asp:Label>
            </td>
            <td>
                <span style="font-size:11.0pt;line-height:115%;
font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
Calibri;mso-fareast-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">
            <asp:TextBox ID="txtDataFinalPrestador" runat="server"></asp:TextBox>
                </span></td>
        </tr>
        </table>
    <table class="style1">
        <tr>
            <td class="style7" colspan="2">
            <asp:Label ID="Label7" runat="server" Text="Prestador:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:DropDownList ID="ddlPrestador" runat="server">
                    <asp:ListItem>Todos</asp:ListItem>
                    <asp:ListItem>CVC BRASIL</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:Button ID="btnRelatorioPrestador" runat="server" Text="Ok" Width="31px" />
            </td>
        </tr>
        </table>
    <p>
    </p>
    <table class="style1">
        <tr>
            <td class="style10" colspan="2">
            <asp:Label ID="Label8" runat="server" Text="Localizar"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
            <asp:Label ID="Label9" runat="server" Text="№:"></asp:Label>
            <asp:TextBox ID="txtNumero" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>
            <asp:Button ID="btnLocalizarNumero" runat="server" Text="Ok" />
            </td>
        </tr>
        </table>
</asp:Content>

