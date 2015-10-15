<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MENU_ORD_SERV.aspx.cs" Inherits="MENU_ORD_SERV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend><strong>Ordem de Serviço</strong></legend>
            <form id="Form2" class="form form-horizontal col-md-4" runat="server">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Gerar OS</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtDataOS" class="control-label col-md-3">
                            Data</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDataOS" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlTipoOS" class="control-label col-md-3">
                            Tipo</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlTipoOS" runat="server" class="form-control">
                                <asp:ListItem Value="C">Chegada</asp:ListItem>
                                <asp:ListItem Value="S">Saída</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="button-group col-md-offset-3">
                        <asp:LinkButton ID="lnkGerarOS" class="btn btn-success" runat="server" OnClick="lnkGerarOS_Click"><span class="glyphicon glyphicon-ok">
                        </span> Gerar OS</asp:LinkButton>
                    </div>
                    <!-- / BUTTON GERAR OS-->
                </div>
            </div>
            <!-- /PANEL GERAR-->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Relatório</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="ddlSelecione" class="control-label col-md-3">
                            Selecione</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlSelecione" runat="server" class="form-control">
                                <asp:ListItem Value="T">Todas</asp:ListItem>
                                <asp:ListItem Value="N">Não Impressas</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL SELECIONE-->
                    <div class="form-group">
                        <label for="ddlTipoRel" class="control-label col-md-3">
                            Tipo</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlTipoRel" runat="server" class="form-control">
                                <asp:ListItem Value="C">Chegada</asp:ListItem>
                                <asp:ListItem Value="S">Saída</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL TIPO RELATORIO-->
                    <div class="form-group">
                        <label for="txtDataRelatorio" class="control-label col-md-3">
                            Data</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDataRelatorio" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!-- / TXT DATA RELATORIO-->
                    <div class="button-group col-md-offset-3">
                        <asp:LinkButton ID="lnkRelatorios" class="btn btn-success" runat="server" OnClick="lnkRelatorios_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                    </div>
                    <!-- / BUTTON PROCESSAR-->
                </div>
            </div>
            <!-- /PANEL RELATORIO-->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Localizar</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group form-horizontal">
                        <label for="txtOSNo" class="control-label col-md-3">
                            Número</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtOSNo" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="button-group col-md-offset-3">
                        <asp:LinkButton ID="lnkLocalizar" class="btn btn-success" runat="server" OnClick="lnkLocalizar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                    </div>
                    <!-- / BUTTON PROCESSAR-->
                </div>
            </div>
            <!-- /PANEL LOCALIZAR-->
            </form>
        </fieldset>
    </div>
    <!-- /.container-fluid -->
</asp:Content>
