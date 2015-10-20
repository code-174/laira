﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MENU_FINANCEIRO.aspx.cs" Inherits="MENU_FINANCEIRO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend><strong>Financeiro</strong></legend>
            <form id="Form2" class="form col-md-4" runat="server">
            <div class="well">
                <div class="form-group">
                    <a href="GERAR_FATURA.aspx" class="btn btn-success btn-lg btn-block">Emitir Fatura</a>
                </div>
            </div>
            <div class="well">
                <div class="form-group">
                    <a href="RELATORIO_VENDEDORES.aspx" class="btn btn-success btn-lg btn-block">Relatório
                        de Vendedores</a>
                </div>
            </div>
            <div class="form-group form-horizontal">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <strong>Processar</strong>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label for="ddlSelecione" class="control-label col-md-3">
                                Selecione</label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlSelecione" runat="server" class="form-control">
                                    <asp:ListItem Value="B">Baixar</asp:ListItem>
                                    <asp:ListItem Value="R">Relatórios</asp:ListItem>
                                    <asp:ListItem Value="I">Imprimir</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
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
                            <label for="ddlTipo" class="control-label col-md-3">
                                Tipo</label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlTipo" runat="server" class="form-control">
                                    <asp:ListItem Value="V">Vencimento</asp:ListItem>
                                    <asp:ListItem Value="E">Emissão</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="ddlAgencia" class="control-label col-md-3">
                                Agência</label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlAgencia" runat="server" class="form-control" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Todas</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="button-group col-md-offset-3">
                            <asp:LinkButton ID="lnkProcessar" class="btn btn-success" runat="server" OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                        </div>
                        <!-- / BUTTON PROCESSAR-->
                    </div>
                </div>
                <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Localizar</strong>
                </div>
                <div class="panel-body">
                 <div class="form-group">
                            <label for="ddlSelecione2" class="control-label col-md-3">
                                Selecione</label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlSelecione2" runat="server" class="form-control">
                                    <asp:ListItem Value="B">Baixar</asp:ListItem>
                                    <asp:ListItem Value="R">Relatórios</asp:ListItem>
                                    <asp:ListItem Value="I">Imprimir</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    <div class="form-group">
                        <label for="txtFaturaNo" class="control-label col-md-3">
                            Número</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtFaturaNo" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="button-group col-md-offset-3">
                        <asp:LinkButton ID="lnkLocalizar" class="btn btn-success" runat="server" OnClick="lnkLocalizar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Localizar</asp:LinkButton>
                    </div>
                    <!-- / BUTTON PROCESSAR-->
                </div>
            </div>
            <!-- /PANEL LOCALIZAR-->
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
