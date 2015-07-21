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
                        <label for="txtDataOS" class="control-label col-md-2">
                            Data</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDataOS" runat="server" class="form-control"></asp:TextBox>
                        </div>                        
                    </div>
                    <div class="form-group">
                        <label for="ddlTipoOS" class="control-label col-md-2">
                            Tipo</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlTipoOS" runat="server" class="form-control">
                                <asp:ListItem Value="C">Chegada</asp:ListItem>
                                <asp:ListItem Value="S">Saída</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:LinkButton ID="lnkGerarOS" class="btn btn-success" runat="server" 
                            OnClick="lnkGerarOS_Click"><span class="glyphicon glyphicon-ok">
                        </span></asp:LinkButton>
                    </div>
                </div>
            </div>
            <!-- /PANEL GERAR-->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Relatório</strong>
                </div>
                <div class="panel-body">
                    <div class="radio">
                        <label>
                            <asp:RadioButton runat="server" Checked="true" AutoPostBack="true" ID="optTodas"
                                OnCheckedChanged="optTodas_CheckedChanged" />Todas</label>
                    </div>
                    <div class="radio">
                        <label>
                            <asp:RadioButton runat="server" Checked="false" AutoPostBack="true" ID="optNaoImpressas"
                                OnCheckedChanged="optNaoImpressas_CheckedChanged" />Não impressas</label>
                    </div>
                    <div class="radio">
                        <label>
                            <asp:RadioButton runat="server" Checked="false" AutoPostBack="true" ID="optOSNo"
                                OnCheckedChanged="optOSNo_CheckedChanged" />Número
                            <%--<asp:TextBox ID="OSNo" runat="server" class="form-control"></asp:TextBox>--%>
                            </label>
                    </div>
                    <div class="row">
                    </div>
                    <div class="form-group form-horizontal col-md-12">
                        <label for="txtDataRelatorio" class="control-label col-md-2">
                            Data</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDataRelatorio" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="form-group form-horizontal col-md-12">
                        <label for="ddlTipo" class="control-label col-md-2">
                            Tipo</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlTipo" runat="server" class="form-control">
                                <asp:ListItem Value="chegada">Chegada</asp:ListItem>
                                <asp:ListItem Value="saida">Saída</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="col-md-12 col-md-offset-2">
                    <asp:LinkButton ID="lnkRelatorios" class="btn btn-success" runat="server" OnClick="lnkRelatorios_Click">
                    <span class="glyphicon glyphicon-ok"></span> Processar</asp:LinkButton>
                    </div>
                </div>
            </div>
            <!-- /PANEL RELATORIO-->
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
            <!-- /PANEL LOCALIZAR-->
            </form>
        </fieldset>
    </div>
    <!-- /.container-fluid -->
</asp:Content>
