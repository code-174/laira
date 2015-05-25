<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MENU_FICHAS.aspx.cs" Inherits="MENU_FICHAS" %>

<%@ Register src="WebControls/wucFiltrosFichas.ascx" tagname="wucFiltrosFichas" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   
    <uc1:wucFiltrosFichas ID="wucFiltrosFichas1" runat="server" />
   
</asp:Content>

