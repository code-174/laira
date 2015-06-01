<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GERAR_ORDEM_SERV.aspx.cs" Inherits="GERAR_ORDEM_SERV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style4" colspan="5">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Ordem de Serviços"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style4" colspan="5">
                    <asp:Label ID="Label2" runat="server" Text="Critérios:"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="style4">
                    <asp:Label ID="Label3" runat="server" Text="Data dos Serviços"></asp:Label>
                </td>
            <td class="style5">
                <asp:TextBox ID="txtDataServico" runat="server"></asp:TextBox>
            </td>
            <td class="style6">
                <asp:Label ID="Label4" runat="server" Text="Tipo dos Serviços"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="ddlTipoServico" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4" colspan="5">
                <asp:LinkButton ID="LinkButton1" runat="server">[Processar]</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style4" colspan="5">
                <asp:Label ID="Label5" runat="server" Text="Dados adicionais:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label6" runat="server" Text="Serviços feito por:"></asp:Label>
            </td>
            <td class="style5">
                <asp:DropDownList ID="ddlServicoFeitoPor" runat="server">
                </asp:DropDownList>
            </td>
            <td class="style6">
                <asp:Label ID="Label7" runat="server" Text="Valor do Serviço:"></asp:Label>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtValorServico" runat="server"></asp:TextBox>
                <asp:Label ID="Label8" runat="server" Text=" Valor Estacionamento:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtValorEstacionamento" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label9" runat="server" Text="Total do Serviço:"></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="txtTotalServico" runat="server"></asp:TextBox>
            </td>
            <td class="style6" colspan="3">
                <asp:LinkButton ID="btnCalcular" runat="server">[Calcular]</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style4" colspan="5">
                <asp:Label ID="Label10" runat="server" Text="Obs:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4" colspan="5">
                <asp:TextBox ID="txtObs" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4" colspan="5">
                <asp:Label ID="Label11" runat="server" Text="Motorista e guia:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label12" runat="server" Text="Motorista:"></asp:Label>
            </td>
            <td class="style5" colspan="4">
                <asp:DropDownList ID="ddlMotorista" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label13" runat="server" Text="Guia:"></asp:Label>
            </td>
            <td class="style5" colspan="4">
                <asp:DropDownList ID="ddlGuia" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style4" colspan="5">
                <asp:Label ID="Label14" runat="server" Text="Selecione as fichas desejadas:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4" colspan="5">
                <asp:GridView ID="grvSelecionarFichas" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

