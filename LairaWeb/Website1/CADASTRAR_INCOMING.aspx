<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_INCOMING.aspx.cs" Inherits="CADASTRAR_INCOMING" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="headd">
        <table class="style1">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Cadastrar Incoming"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label17" runat="server" Text="Código do Incoming"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCodIncoming" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label2" runat="server" Text="Empresa"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpresa" runat="server"></asp:TextBox>
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
                    <asp:Label ID="Label16" runat="server" Text="Endereço"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label4" runat="server" Text="País"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPais" runat="server"></asp:TextBox>
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
                    <asp:Label ID="Label14" runat="server" Text="Site"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSite" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label15" runat="server" Text="Atuação"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAtuacao" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">                    
                    <asp:LinkButton ID="btnAdIncoming" runat="server" onclick="btnAdIncoming_Click">[Adicionar Incoming]</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnVoltar" runat="server" OnClick="btnVoltar_Click">[Voltar]</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
