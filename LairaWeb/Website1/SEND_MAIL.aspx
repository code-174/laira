<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="SEND_MAIL.aspx.cs" Inherits="SEND_MAIL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Envio de Emails</legend>
            <form class="form-horizontal col-md-7" runat="server">
            <div class="form-group">
                <label for="SendTo" class="control-label col-md-2">
                    Enviar para:</label>
                <div class="col-md-7">
                    <asp:TextBox ID="SendTo" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 col-md-offset-2">
            <div class="btn-group btn-group-justified">
                <asp:LinkButton ID="lnkAdAeroporto" runat="server" OnClick="lnkSendMail_Click"
                    class="btn btn-primary">Enviar</asp:LinkButton>
                <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
            </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
