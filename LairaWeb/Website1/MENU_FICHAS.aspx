﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MENU_FICHAS.aspx.cs" Inherits="MENU_FICHAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Fichas</legend>
            <form id="Form1" class="form col-md-4" runat="server">
            <div class="well">
                <div class="form-group">
                    <a href="CADASTRAR_FICHA.aspx" class="btn btn-primary btn-lg btn-block">Cadastrar Ficha
                    </a>
                </div>
            </div>
            <div class="form-group form-horizontal">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <strong>Processar</strong>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label for="ddlOperacao" class="control-label col-md-3">
                                Operação</label>
                            <div class="col-md-5">
                                <asp:DropDownList ID="ddlOperacao" runat="server" class="form-control">
                                    <asp:ListItem Value="L">Listar</asp:ListItem>
                                    <asp:ListItem Value="R">Relatório</asp:ListItem>
                                </asp:DropDownList>
                            </div>                        
                        </div>
                        <div class="form-group">
                        <label for="ddlTipo" class="control-label col-md-3">
                            Tipo</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlTipo" runat="server" class="form-control">
                                <asp:ListItem Value="C">Chegada</asp:ListItem>
                                <asp:ListItem Value="S">Saída</asp:ListItem>
                            </asp:DropDownList>
                        </div>                        
                    </div>
                    <div class="form-group">
                        <label for="txtData" class="control-label col-md-3">
                            Data</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtData" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        </div>

                    <div class="button-group col-md-offset-3">
                        <asp:LinkButton ID="lnkProcessar" class="btn btn-success" runat="server" OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                    </div>


                        </div>
                        </div>
                        </div>




<%--
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Listar</strong></div>
                <div class="panel-body">
                    <div class="radio">
                        <label>
                            <asp:RadioButton runat="server" Checked="true" AutoPostBack="true" ID="optradio1"
                                OnCheckedChanged="optradio1_CheckedChanged" />Chegada</label>
                    </div>
                    <div class="radio">
                        <label>
                            <asp:RadioButton runat="server" Checked="false" AutoPostBack="true" ID="optradio2"
                                OnCheckedChanged="optradio2_CheckedChanged" />Saída</label>
                    </div>
                    <div class="form-group col-xs-5">
                        <asp:TextBox type="date" class="form-control" runat="server" ID="txtDataFicha"></asp:TextBox>
                    </div>
                    <div>
                        <asp:LinkButton ID="lnkListarFichas" class="btn btn-success btn-sm" runat="server"
                            OnClick="lnkListarFichas_Click"><span class="glyphicon glyphicon-arrow-right">
                        </span></asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Relatório</strong>
                </div>
                <div class="panel-body">
                    <div class="radio">
                        <label>
                            <asp:RadioButton runat="server" Checked="true" AutoPostBack="true" ID="optradio3"
                                OnCheckedChanged="optradio3_CheckedChanged" />Chegada</label>
                    </div>
                    <div class="radio">
                        <label>
                            <asp:RadioButton runat="server" Checked="false" AutoPostBack="true" ID="optradio4"
                                OnCheckedChanged="optradio4_CheckedChanged" />Saída</label>
                    </div>
                    <div class="form-group col-xs-5">
                        <asp:TextBox class="form-control" runat="server" ID="txtDataRelatorio"></asp:TextBox>
                    </div>
                    <div>
                        <asp:LinkButton ID="lnkRelatorios" class="btn btn-success btn-sm" runat="server"
                            OnClick="lnkRelatorios_Click"><span class="glyphicon glyphicon-arrow-right">
                        </span></asp:LinkButton>
                    </div>
                </div>
            </div>--%>


            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Localizar</strong>
                    </div>
                <div class="panel-body">
                    <div class="radio">
                        <label>
                            <asp:RadioButton runat="server" Checked="true" AutoPostBack="true" ID="optradio5"
                                OnCheckedChanged="optradio5_CheckedChanged" />Número</label>
                    </div>
                    <div class="radio">
                        <label>
                            <asp:RadioButton runat="server" Checked="false" AutoPostBack="true" ID="optradio6"
                                OnCheckedChanged="optradio6_CheckedChanged" />Cod. Excursão</label>
                    </div>
                    <div class="form-group col-xs-5">
                        <asp:TextBox class="form-control" runat="server" ID="txtChave"></asp:TextBox>
                    </div>
                    <div>
                        <asp:LinkButton ID="lnkConsultar" class="btn btn-success btn-sm" runat="server" OnClick="lnkConsultar_Click"><span class="glyphicon glyphicon-arrow-right">
                        </span></asp:LinkButton>
                    </div>
                </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
