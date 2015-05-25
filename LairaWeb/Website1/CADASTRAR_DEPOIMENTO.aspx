<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CADASTRAR_DEPOIMENTO.aspx.cs" Inherits="CADASTRAR_DEPOIMENTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Cadastrar Depoimento"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label8" runat="server" Text="Código Depoimento"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCodDepoimento" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Nome"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label6" runat="server" Text="Cidade"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label7" runat="server" Text="Depoimento"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDepoimento" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAdDepoimento" runat="server" Text="Adicionar Depoimento" 
                    onclick="btnAdDepoimento_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

