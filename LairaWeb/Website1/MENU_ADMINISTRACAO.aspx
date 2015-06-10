<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MENU_ADMINISTRACAO.aspx.cs" Inherits="MENU_ADMINISTRACAO" %>

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
            <asp:Label ID="Label1" runat="server" Text="Administração" Font-Bold="True" 
                    Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <asp:Label ID="Label3" runat="server" Text="Listar:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:DropDownList ID="ddlListar" runat="server">
                    <asp:ListItem Value="aer">Aeroportos</asp:ListItem>
                    <asp:ListItem Value="age">Agências</asp:ListItem>
                    <asp:ListItem Value="dep">Depoimentos</asp:ListItem>
                    <asp:ListItem Value="for">Formas de Pagamento</asp:ListItem>
                    <asp:ListItem Value="hot">Hotéis</asp:ListItem>
                    <asp:ListItem Value="pre">Prestadores</asp:ListItem>
                    <asp:ListItem Value="sea">Serv. Adicionais</asp:ListItem>
                    <asp:ListItem Value="inc">Incoming</asp:ListItem>
                    <asp:ListItem Value="sei">Serv. Inclusos</asp:ListItem>
                    <asp:ListItem Value="sta">Status</asp:ListItem>
                    <asp:ListItem Value="usu">Usuários</asp:ListItem>
                    <asp:ListItem Value="ven">Vendedores</asp:ListItem>
                    <asp:ListItem Value="voo">Voos</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnListar" runat="server" onclick="btnListar_Click" 
                    Text="Listar" />
            </td>
        </tr>
        </table>
    <p>
    </p>
    <table class="style1">
        <tr>
            <td colspan="2">
            <asp:Label ID="Label4" runat="server" Text="Cadastrar:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:DropDownList ID="ddlCadastrar" runat="server">
                    <asp:ListItem Value="aer">Aeroportos</asp:ListItem>
                    <asp:ListItem Value="age">Agências</asp:ListItem>
                    <asp:ListItem Value="dep">Depoimentos</asp:ListItem>
                    <asp:ListItem Value="for">Formas de Pagamento</asp:ListItem>
                    <asp:ListItem Value="hot">Hotéis</asp:ListItem>
                    <asp:ListItem Value="pre">Prestadores</asp:ListItem>
                    <asp:ListItem Value="sea">Serv. Adicionais</asp:ListItem>
                    <asp:ListItem Value="inc">Incoming</asp:ListItem>
                    <asp:ListItem Value="sei">Serv. Inclusos</asp:ListItem>
                    <asp:ListItem Value="sta">Status</asp:ListItem>
                    <asp:ListItem Value="usu">Usuários</asp:ListItem>
                    <asp:ListItem Value="ven">Vendedores</asp:ListItem>
                    <asp:ListItem Value="voo">Voos</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnCadastrar" runat="server" onclick="btnCadastrar_Click" 
                    Text="Cadastrar" />
            </td>
        </tr>
        </table>
    <p>
    </p>
    <table class="style1">
        <tr>
            <td colspan="2">
            <asp:Label ID="Label5" runat="server" Text="Localizar:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:TextBox ID="txtLocalizar" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnLocalizar" runat="server" Text="Localizar" 
                    onclick="btnLocalizar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

