﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LISTAR_DEPOIMENTOS.aspx.cs" Inherits="LISTAR_DEPOIMENTOS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');">[Imprimir]</asp:LinkButton>

    <div id="divPrint">
    <asp:GridView ID="grvData" runat="server">
    </asp:GridView>
    </div>
</asp:Content>

