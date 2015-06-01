<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="LISTAR_AEROPORTOS.aspx.cs" Inherits="LISTAR_AEROPORTOS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div id="divPrint">
        <asp:GridView ID="grvData" runat="server">
        </asp:GridView>
    </div>
    <asp:LinkButton ID="lnkNew" runat="server" OnClick="lnkNew_Click">[Cadastrar Aeroporto]</asp:LinkButton>
    &nbsp;<asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');">[Imprimir]</asp:LinkButton>
</asp:Content>
