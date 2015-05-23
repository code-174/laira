<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MENU_COMUNICADOS.aspx.cs" Inherits="MENU_COMUNICADOS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="2">
            <asp:Label ID="Label1" runat="server" Text="Comunicados" Font-Bold="True" 
                    Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
            <asp:Label ID="Label2" runat="server" Text="Passeio"></asp:Label>
            </td>
            <td>
            <asp:Button ID="btnPasseio" runat="server" Text="Ok" />
            </td>
        </tr>
        <tr>
            <td class="style2">
            <asp:Label ID="Label3" runat="server" Text="Transfer Out"></asp:Label>
            </td>
            <td>
            <asp:Button ID="btnTransferOut" runat="server" Text="Ok" />
            </td>
        </tr>
    </table>
</asp:Content>

