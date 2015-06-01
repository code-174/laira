<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LISTAR_SERV_ADC.aspx.cs" Inherits="LISTAR_SERV_ADV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="divPrint">
        <asp:GridView ID="grvData" runat="server">
        </asp:GridView>
    </div>
    <asp:LinkButton ID="lnkNew" runat="server" OnClick="lnkNew_Click">[Cadastrar Serviço Adicional]</asp:LinkButton>
    &nbsp;<asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');">[Imprimir]</asp:LinkButton>
</asp:Content>

