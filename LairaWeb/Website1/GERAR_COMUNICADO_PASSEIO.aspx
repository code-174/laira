<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GERAR_COMUNICADO_PASSEIO.aspx.cs" Inherits="GERAR_COMUNICADO_PASSEIO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="container-fluid">
        <fieldset>
            <legend>Comunicado de Passeio</legend>
            <form id="Form2" class="form form-horizontal col-md-4" runat="server">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Período</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group form-horizontal">
                        <label for="txtData" class="control-label col-md-3">
                            Data</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtData" runat="server" class="form-control"></asp:TextBox>
                        </div>                        
                    </div>
                </div>
            </div>
            <!-- / PANEL PERIODO-->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Filtros</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="ddlPasseio" class="control-label col-md-3">
                            Passeio</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlPasseio" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL PASSEIO-->
                    <div class="form-group">
                        <label for="ddlPrestador" class="control-label col-md-3">
                            Prestador</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlPrestador" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL PRESTADOR-->
                    <div class="form-group">
                        <label for="ddlVendedor" class="control-label col-md-3">
                            Vendedor</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlVendedor" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL VENDEDOR-->
                    <div class="form-group">
                        <label for="ddlVisualizar" class="control-label col-md-3">
                            Visualizar</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlVisualizar" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL VISUALIZAR-->
                    <div class="form-group">
                        <label for="txtPaginas" class="control-label col-md-3">
                            Fichas por Página</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPaginas" runat="server" class="form-control">
                            </asp:TextBox>
                        </div>
                    </div>
                    <!-- / DDL PAGINAS-->
                    <div class="button-group col-md-offset-3">
                        <asp:LinkButton ID="lnkProcessar" class="btn btn-success" runat="server"
                            OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                    </div>
                    <!-- / BUTTON PROCESSAR-->
                </div>
            </div>
            <!-- / PANEL FILTROS-->
            <div class="btn-group btn-group-justified">
                <asp:LinkButton ID="lnkSelecionarTodas" runat="server" OnClick="lnkSelecionarTodas_Click" class="btn btn-primary">Selecionar Todas</asp:LinkButton>
                <asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');"
                    class="btn btn-info">Imprimir</asp:LinkButton>
                <asp:LinkButton ID="lnkEnviarEmail" runat="server" OnClick="lnkEnviarEmail_Click" class="btn btn-warning">Enviar Por Email</asp:LinkButton>
            </div>
            <!-- / BUTTON GROUP-->

            </form>
        </fieldset>
    </div>
</asp:Content>

