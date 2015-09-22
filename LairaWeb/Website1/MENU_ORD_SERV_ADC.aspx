<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MENU_ORD_SERV_ADC.aspx.cs" Inherits="MENU_ORD_SERV_ADC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend><strong>Ordem de Serviço Adicional</strong></legend>
            <form id="Form2" class="form form-horizontal col-md-4" runat="server">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Processar</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="ddlSelecione" class="control-label col-md-3">
                            Selecione</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlSelecione" runat="server" class="form-control">
                                <asp:ListItem Value="G">Gerar</asp:ListItem>
                                <asp:ListItem Value="R">Relatório</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtData" class="control-label col-md-3">
                            Data</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtData" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="button-group col-md-offset-3">
                        <asp:LinkButton ID="lnkProcessar" class="btn btn-success" runat="server" OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                    </div>
                    <!-- / BUTTON PROCESSAR-->
                </div>
            </div>
            <!-- / PANEL PROCESSAR-->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Relatório por Prestador</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtDataInicio" class="control-label col-md-3">
                            De</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDataInicio" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="form-group">
                        <label for="txtDataFim" class="control-label col-md-3">
                            Até</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDataFim" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlPrestador" class="control-label col-md-3">
                            Prestador</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlPrestador" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                        <asp:LinkButton ID="lnkRelatorioPrestador" class="btn btn-success" runat="server"
                            OnClick="lnkRelatorioPrestador_Click"><span class="glyphicon glyphicon-ok">
                        </span></asp:LinkButton>
                    </div>
                </div>
            </div>
            <!-- /PANEL RELATORIO POR PRESTADOR-->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Localizar</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtOSNo" class="control-label col-md-3">
                            Número</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtOSNo" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="button-group col-md-3">
                            <asp:LinkButton ID="lnkLocalizar" class="btn btn-success" runat="server" OnClick="lnkLocalizar_Click"><span class="glyphicon glyphicon-ok">
                        </span> 
                        Localizar</asp:LinkButton>
                        </div>
                        <!-- / BUTTON LOCALIZAR-->
                    </div>
                </div>
            </div>
            <!-- /PANEL LOCALIZAR-->
            </form>
        </fieldset>
    </div>
</asp:Content>
