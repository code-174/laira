<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MENU_ORD_SERV_ADC.aspx.cs" Inherits="MENU_ORD_SERV_ADC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Ordem de Serviço Adicional</legend>
            <form id="Form2" class="form col-md-4" runat="server">
            <div class="well">
                <div class="form-group">
                    <a href="GERAR_ORDEM_SERV_ADC.aspx" class="btn btn-primary btn-lg btn-block">Gerar OS
                        Adicional</a>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Relatório</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group form-horizontal">
                        <label for="txtDataRelatorio" class="control-label col-md-2">
                            Data</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDataRelatorio" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <asp:LinkButton ID="lnkRelatorios" class="btn btn-success btn-sm" runat="server"
                            OnClick="lnkRelatorios_Click"><span class="glyphicon glyphicon-arrow-right">
                        </span></asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Relatório por Prestador</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group form-horizontal col-md-12">
                        <label for="txtDataInicio" class="control-label col-md-3">
                            De</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDataInicio" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="form-group form-horizontal col-md-12">
                        <label for="txtDataFim" class="control-label col-md-3">
                            Até</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDataFim" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group form-horizontal col-md-12">
                        <label for="ddlPrestador" class="control-label col-md-3">
                            Prestador</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlPrestador" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                        <asp:LinkButton ID="lnkRelatorioPrestador" class="btn btn-success btn-sm" runat="server"
                            OnClick="lnkRelatorioPrestador_Click"><span class="glyphicon glyphicon-arrow-right">
                        </span></asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Localizar</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group form-horizontal">
                        <label for="txtChave" class="control-label col-md-2">
                            Número</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtChave" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <asp:LinkButton ID="lnkConsultar" class="btn btn-success btn-sm" runat="server" OnClick="lnkConsultar_Click"><span class="glyphicon glyphicon-arrow-right">
                        </span></asp:LinkButton>
                    </div>
                </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
