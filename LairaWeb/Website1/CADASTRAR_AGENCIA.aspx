<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_AGENCIA.aspx.cs" Inherits="CADASTRAR_AGENCIA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="headd">
        <table class="style1">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Cadastrar Agência"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label14" runat="server" Text="Código da Agência"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCodAgencia" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label2" runat="server" Text="Razão Social"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRazaoSocial" runat="server"></asp:TextBox>
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
                    <asp:Label ID="Label4" runat="server" Text="Endereço"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label5" runat="server" Text="Bairro"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBairro" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label6" runat="server" Text="Cidade"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label7" runat="server" Text="UF"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUF" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label8" runat="server" Text="CEP"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCEP" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label9" runat="server" Text="CNPJ"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCNPJ" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label10" runat="server" Text="Inscrição municipal"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtInscrMun" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label11" runat="server" Text="Contatos"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContatos" runat="server"></asp:TextBox>
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
                <td colspan="2">
                    <asp:LinkButton ID="btnAdAgencia" runat="server" OnClick="btnAdAgencia_Click">[Adicionar Agência]</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnVoltar" runat="server" OnClick="btnVoltar_Click">[Voltar]</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
