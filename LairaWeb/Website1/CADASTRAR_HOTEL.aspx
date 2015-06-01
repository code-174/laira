<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_HOTEL.aspx.cs" Inherits="CADASTRAR_HOTEL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="headd">
        <table class="style1">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Cadastrar Hotel"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label15" runat="server" Text="Código do Hotel"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCodHotel" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label3" runat="server" Text="Nome"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label12" runat="server" Text="Telefone"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label13" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label4" runat="server" Text="Endereço"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label14" runat="server" Text="Hora"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtHora" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton ID="btnAdHotel" runat="server" onclick="btnAdHotel_Click">[Adicionar Hotel]</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnVoltar" runat="server" OnClick="btnVoltar_Click">[Voltar]</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
