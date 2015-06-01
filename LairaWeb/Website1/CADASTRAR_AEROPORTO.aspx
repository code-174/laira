<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_AEROPORTO.aspx.cs" Inherits="INCLUIR_AEROPORTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="headd">
        <table class="style1">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="Cadastrar Aeroporto"
                        Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label2" runat="server" Text="Nome"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNomeAeroporto" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="Label3" runat="server" Text="Sigla"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSiglaAeroporto" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3" colspan="2">
                    <asp:LinkButton ID="btnAdAeroporto" runat="server" OnClick="btnAdAeroporto_Click">[Adicionar Aeroporto]</asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="btnVoltar" runat="server" OnClick="btnVoltar_Click">[Voltar]</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
