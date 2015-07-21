<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="GERAR_ORDEM_SERV.aspx.cs" Inherits="GERAR_ORDEM_SERV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Ordens de Serviços</legend>
            <form id="Form2" class="form form-horizontal col-md-6" runat="server">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <strong>Critérios</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtDataServico" class="control-label col-md-4">
                            Data dos Serviços</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDataServico" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlTipoServico" class="control-label col-md-4">
                            Tipo dos Serviços</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlTipoServico" runat="server" class="form-control">
                                <asp:ListItem Value="C">Transfer In (Chegada)</asp:ListItem>
                                <asp:ListItem Value="S">Transfer Out (Saída)</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL TIPO SERVICO-->
                    <div class="button-group col-md-offset-4">
                        <asp:LinkButton ID="lnkProcessarCriterios" class="btn btn-success" runat="server"
                            OnClick="lnkProcessarCriterios_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                    </div>
                    <!-- / BUTTON PROCESSAR-->
                </div>
            </div>
            <!-- / PANEL CRITERIOS-->
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <strong>Dados Adicionais</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="ddlServicoFeitoPor" class="control-label col-md-4">
                            Serviço feito por</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlServicoFeitoPor" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL SERVICO FEITO POR-->
                    <div class="form-group">
                        <label for="txtValorServico" class="control-label col-md-4">
                            Valor do Serviço</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtValorServico" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!-- / TXT VALOR SERVICO-->
                    <div class="form-group">
                        <label for="txtValorEstacionamento" class="control-label col-md-4">
                            Valor Estacionamento</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtValorEstacionamento" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!-- / TXT VALOR ESTACIONAMENTO-->
                    <%--<div class="form-group">
                        <label for="txtTotalServico" class="control-label col-md-4">
                            Total do Serviço</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtTotalServico" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="LinkButton1" class="btn btn-success" runat="server" OnClick="lnkProcessarCriterios_Click"><span class="glyphicon glyphicon-ok">
                        </span> Calcular</asp:LinkButton>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label for="txtTotalServico" class="control-label col-md-4">
                            Total do Serviço</label>
                        <div class="col-md-5">
                            <div class="input-group">
                                <input type="txtTotalServico" class="form-control">
                                <span class="input-group-btn">
                                    <button class="btn btn-default" type="button">
                                        Calcular</button>
                                </span>
                            </div>
                            <!-- /input-group -->
                        </div>
                    </div>
                    <!-- / TXT TOTAL SERVICO-->
                </div>
            </div>
            <!-- /PANEL DADOS ADICIONAIS-->
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <strong>Motorista e Guia</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="ddlMotorista" class="control-label col-md-4">
                            Motorista</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlMotorista" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL MOTORISTA-->
                    <div class="form-group">
                        <label for="ddlGuia" class="control-label col-md-4">
                            Guia</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlGuia" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL GUIA-->
                </div>
            </div>
            <!-- /PANEL DADOS MOTORISTA E GUIA-->
            <asp:GridView ID="grvFichas" runat="server" class="table table-hover table-bordered"
                GridLines="None" EmptyDataRowStyle-BackColor="Yellow" EmptyDataText="Nao existem fichas para a Data informada!">
            </asp:GridView>
            </form>
        </fieldset>
    </div>
    <!-- /.container-fluid -->
</asp:Content>
