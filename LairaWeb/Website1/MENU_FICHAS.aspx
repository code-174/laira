<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
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
            <div class="panel panel-default">
                <div class="panel-heading">
                    Listar Ficha</div>
                <div class="panel-body">
                    <div class="radio">
                        <label>
                            <input type="radio" name="optradio">Chegada</label>
                    </div>
                    <div class="radio">
                        <label>
                            <input type="radio" name="optradio">Saída</label>
                    </div>
                    <div class="form-group col-xs-5">
                        <input type="text" class="form-control" id="txtData">
                    </div>
                    <div>
                        <a href="CADASTRAR_FICHA.aspx" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-arrow-right">
                        </span></a>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    Relatório</div>
                <div class="panel-body">
                    <div class="radio">
                        <label>
                            <input type="radio" name="optradio">Chegada</label>
                    </div>
                    <div class="radio">
                        <label>
                            <input type="radio" name="optradio">Saída</label>
                    </div>
                    <div class="form-group col-xs-5">
                        <input type="text" class="form-control" id="Text1">
                    </div>
                    <div>
                        <a href="CADASTRAR_FICHA.aspx" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-arrow-right">
                        </span></a>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    Localizar</div>
                <div class="panel-body">
                    <div class="radio">
                        <label>
                            <input type="radio" name="optradio">Número</label>
                    </div>
                    <div class="radio">
                        <label>
                            <input type="radio" name="optradio">Cod. Excursão</label>
                    </div>
                    <div class="form-group col-xs-5">
                        <input type="text" class="form-control" id="Text2">
                    </div>
                    <div>
                        <a href="CADASTRAR_FICHA.aspx" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-arrow-right">
                        </span></a>
                    </div>
                </div>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
