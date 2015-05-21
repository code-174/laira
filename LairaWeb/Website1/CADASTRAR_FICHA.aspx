<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CADASTRAR_FICHA.aspx.cs" Inherits="CADASTRAR_FICHA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 161px;
        }
        .style3
        {
            width: 175px;
        }
        .style5
        {
            width: 125px;
        }
        .style6
        {
            width: 173px;
        }
        .style7
        {
            width: 91px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="6">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Cadastrar Ficha"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Data Chegada"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtDataChegada" runat="server"></asp:TextBox>
            </td>
            <td class="style7">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="Label8" runat="server" Text="Data Saída"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtDataSaida" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Voo Chegada / Hora"></asp:Label>
            </td>
            <td class="style3">
                <asp:DropDownList ID="ddlVooChegada" runat="server">
                </asp:DropDownList>
            </td>
            <td class="style7">
                <asp:TextBox ID="txtChegadaHora" runat="server" Width="75px"></asp:TextBox>
            </td>
            <td class="style5">
                <asp:Label ID="Label9" runat="server" Text="Voo Saída / Hora"></asp:Label>
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlVooSaida" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="txtSaidaHora" runat="server" Width="75px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label4" runat="server" Text="Aeroporto Chegada"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtAeroportoChegada" runat="server"></asp:TextBox>
            </td>
            <td class="style7">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="Label10" runat="server" Text="Aeroporto Saída"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtAeroportoSaida" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label5" runat="server" Text="Código Excursão"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtCodExcursao" runat="server"></asp:TextBox>
            </td>
            <td class="style7">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="Label11" runat="server" Text="Agência"></asp:Label>
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlAgencia" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label6" runat="server" Text="Recibo"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtRecibo" runat="server"></asp:TextBox>
            </td>
            <td class="style7">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="Label12" runat="server" Text="Hotel"></asp:Label>
            </td>
            <td class="style6">
                <asp:DropDownList ID="ddlHotel" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label7" runat="server" Text="Apartamento"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="txtApartamento" runat="server"></asp:TextBox>
            </td>
            <td class="style7">
                &nbsp;</td>
            <td class="style5">
                <asp:Label ID="Label13" runat="server" Text="Saída do Hotel"></asp:Label>
            </td>
            <td class="style6">
                <asp:TextBox ID="txtSaidaHotel" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

