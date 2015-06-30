<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MENU_ORD_SERV.aspx.cs" Inherits="MENU_ORD_SERV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Ordem de Serviço</legend>
            <form id="Form2" class="form col-md-4" runat="server">
            <div class="well">
                <div class="form-group">
                    <a href="GERAR_ORDEM_SERV.aspx" class="btn btn-primary btn-lg btn-block">Gerar OS</a>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Relatório</strong>
                </div>
                <div class="panel-body">
                    <div class="radio">
                        <label>
                            <asp:RadioButton runat="server" Checked="true" AutoPostBack="true" ID="optChegada"
                                OnCheckedChanged="optChegada_CheckedChanged" />Chegada</label>
                    </div>
                    <div class="radio">
                        <label>
                            <asp:RadioButton runat="server" Checked="false" AutoPostBack="true" ID="optSaida"
                                OnCheckedChanged="optSaida_CheckedChanged" />Saída</label>
                    </div>
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
