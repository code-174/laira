<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MENU_FICHAS.aspx.cs" Inherits="MENU_FICHAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend><strong>Fichas</strong></legend>
            <form id="Form1" class="form col-md-4" runat="server">
            <div class="well">
                <div class="form-group">
                    <a href="CADASTRAR_FICHA.aspx" class="btn btn-success btn-lg btn-block">Cadastrar Ficha
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
                            <label for="ddlSelecione" class="control-label col-md-3">
                                Selecione</label>
                            <div class="col-md-5">
                                <asp:DropDownList ID="ddlSelecione" runat="server" class="form-control">
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
                            <div class="col-md-5">
                                <asp:TextBox ID="txtData" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="button-group col-md-offset-3">
                            <asp:LinkButton ID="lnkProcessar" class="btn btn-success" runat="server" OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                        </div>
                    </div>
                </div>
           
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Localizar</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="ddlLocalizar" class="control-label col-md-3">
                            Selecione</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlLocalizar" runat="server" class="form-control">
                                <asp:ListItem Value="F">Número da Ficha</asp:ListItem>
                                <asp:ListItem Value="E">Cód. de Excursão</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtCriterio" class="control-label col-md-3">
                            Critério</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtCriterio" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="button-group col-md-offset-3">
                        <asp:LinkButton ID="lnkLocalizar" class="btn btn-success" runat="server" OnClick="lnkLocalizar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Filtrar Dados</asp:LinkButton>
                    </div>
                </div>
            </div>
             </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
