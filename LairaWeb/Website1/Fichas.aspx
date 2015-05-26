<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Fichas.aspx.cs" Inherits="Fichas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <div id="div1">

</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');">[Imprimir]</asp:LinkButton>

    <div id="divPrint">
    <asp:TextBox ID="test" Text="HAHAHHA" runat="server"></asp:TextBox>

    <asp:GridView ID="grvData" runat="server" AutoGenerateColumns="True" >
        
    </asp:GridView>

</div>

</asp:Content>

