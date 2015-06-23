<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_STATUS.aspx.cs" Inherits="CADASTRAR_STATUS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
<div class="container-fluid">
        <fieldset>
            <legend>Cadastrar Status</legend>
            <form id="Form1" class="form-horizontal col-md-7" runat="server">
            <div class="form-group">
                <label for="txtCodStatus" class="control-label col-md-2">Cod.Status</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCodStatus" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtStatus" class="control-label col-md-2">Status</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtStatus" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6 col-md-offset-2">
            <div class="btn-group btn-group-justified">
                <asp:LinkButton ID="lnkAdStatus" runat="server" OnClick="lnkAdStatus_Click"
                    class="btn btn-primary">Adicionar Status</asp:LinkButton>
                <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
            </div>
            </div>
            </form>



        </fieldset>
       
    </div>
</asp:Content>
