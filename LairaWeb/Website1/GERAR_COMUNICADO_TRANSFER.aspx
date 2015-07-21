<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GERAR_COMUNICADO_TRANSFER.aspx.cs" Inherits="GERAR_COMUNICADO_TRANSFER" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="container-fluid">
        <fieldset>
            <legend>Comunicado de Transfer Out</legend>
            <form id="Form2" class="form form-horizontal col-md-6" runat="server">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Filtros</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group form-horizontal">
                        <label for="txtData" class="control-label col-md-3">
                            Data</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtData" runat="server" class="form-control"></asp:TextBox>
                        </div>                        
                    </div>
                </div>
            </div>
            <!-- / PANEL PERIODO-->

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

