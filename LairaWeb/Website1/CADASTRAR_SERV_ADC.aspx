<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="CADASTRAR_SERV_ADC.aspx.cs" Inherits="CADASTRAR_SERV_ADC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Cadastrar Serviços Adicionais</legend>
            <form id="Form1" class="form-horizontal col-md-7" runat="server">
            <div class="form-group">
                <label for="txtCodigo" class="control-label col-md-2">
                    Cod. Servico</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtPasseio" class="control-label col-md-2">
                    Passeio</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtPasseio" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="txtPreco" class="control-label col-md-2">
                    Preço</label>
                <div class="col-md-7">
                    <asp:TextBox ID="txtPreco" runat="server" class="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 col-md-offset-2">
                <div class="btn-group btn-group-justified">
                    <asp:LinkButton ID="lnkAdServ" runat="server" OnClick="lnkAdServ_Click" class="btn btn-primary">Adicionar Serviço</asp:LinkButton>
                    <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
                </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
