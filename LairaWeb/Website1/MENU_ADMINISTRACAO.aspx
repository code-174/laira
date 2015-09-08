<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MENU_ADMINISTRACAO.aspx.cs" Inherits="MENU_ADMINISTRACAO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend><strong>Administração</strong></legend>
            <form id="Form1" class="form form-horizontal col-md-4" runat="server">
           <%-- <div class="form-group">
                    <a href="teste_ficha.aspx" class="btn btn-primary btn-lg btn-block">teste ficha</a>
                </div>--%>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Processar</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="ddlOperacao" class="control-label col-md-3">
                            Operação</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlOperacao" runat="server" class="form-control">
                                <asp:ListItem Value="L">Listar</asp:ListItem>
                                <asp:ListItem Value="C">Cadastrar</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlSelecione" class="control-label col-md-3">
                            Selecione</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlSelecione" runat="server" class="form-control">
                                <asp:ListItem Value="aer">Aeroportos</asp:ListItem>
                                <asp:ListItem Value="age">Agências</asp:ListItem>
                                <asp:ListItem Value="dep">Depoimentos</asp:ListItem>
                                <asp:ListItem Value="for">Formas de Pagamento</asp:ListItem>
                                <asp:ListItem Value="hot">Hotéis</asp:ListItem>
                                <asp:ListItem Value="pre">Prestadores</asp:ListItem>
                                <asp:ListItem Value="sea">Serv. Adicionais</asp:ListItem>
                                <asp:ListItem Value="inc">Incoming</asp:ListItem>
                                <asp:ListItem Value="sei">Serv. Inclusos</asp:ListItem>
                                <asp:ListItem Value="sta">Status</asp:ListItem>
                                <asp:ListItem Value="usu">Usuários</asp:ListItem>
                                <asp:ListItem Value="ven">Vendedores</asp:ListItem>
                                <asp:ListItem Value="voo">Voos</asp:ListItem>
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
            <!-- / PANEL PROCESSAR-->
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
                                <asp:ListItem Value="aer">Aeroportos</asp:ListItem>
                                <asp:ListItem Value="age">Agências</asp:ListItem>
                                <asp:ListItem Value="dep">Depoimentos</asp:ListItem>
                                <asp:ListItem Value="for">Formas de Pagamento</asp:ListItem>
                                <asp:ListItem Value="hot">Hotéis</asp:ListItem>
                                <asp:ListItem Value="pre">Prestadores</asp:ListItem>
                                <asp:ListItem Value="sea">Serv. Adicionais</asp:ListItem>
                                <asp:ListItem Value="inc">Incoming</asp:ListItem>
                                <asp:ListItem Value="sei">Serv. Inclusos</asp:ListItem>
                                <asp:ListItem Value="sta">Status</asp:ListItem>
                                <asp:ListItem Value="usu">Usuários</asp:ListItem>
                                <asp:ListItem Value="ven">Vendedores</asp:ListItem>
                                <asp:ListItem Value="voo">Voos</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtLocalizar" class="control-label col-md-3">
                            Localizar:</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtLocalizar" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="button-group col-md-offset-3">
                        <asp:LinkButton ID="lnkLocalizar" class="btn btn-success" runat="server" OnClick="lnkLocalizar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Filtrar</asp:LinkButton>
                    </div>
                    <!-- / BUTTON LOCALIZAR-->
                </div>
            </div>
            <!-- / PANEL LOCALIZAR-->
            </form>
        </fieldset>
    </div>
</asp:Content>
