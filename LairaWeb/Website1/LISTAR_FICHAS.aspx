<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="LISTAR_FICHAS.aspx.cs" Inherits="LISTAR_FICHAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server">Listar Fichas</legend>
            <form id="Form1" class="form col-md-7" runat="server">
            
            <div id="divPrint">
                <asp:GridView ID="grvData" runat="server" class="table table-hover" 
                    GridLines="None">
                </asp:GridView>
            </div>
            <div class="btn-group btn-group-justified">
                <asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');"
                    class="btn btn-info">Imprimir</asp:LinkButton>
                <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
