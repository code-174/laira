<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogon.master" AutoEventWireup="true"
    CodeFile="Logout.aspx.cs" Inherits="Logout" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Obrigado por utilizar o sistema.</legend>
            <form id="Form1" class="form-horizontal col-md-7" runat="server">
            <div class="form-group">
                
            </div>
            <div class="col-md-6 col-md-offset-2">
                <div class="btn-group btn-group-justified">
                    <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-primary">Voltar ao Sistema</asp:LinkButton>
                </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
