<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MENU_ADMINISTRACAO.aspx.cs" Inherits="MENU_ADMINISTRACAO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
            <fieldset>
            <legend>Administração</legend>
        <form id="Form1" class="form col-md-4" runat="server">
            <div class="well">
                <div class="form-group">
                    <label for="ddlListar">Listar:</label>
                    <asp:DropDownList ID="ddlListar" runat="server" class="form-control">
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
                <div class="form-group">
                    <asp:LinkButton ID="btnListar" runat="server" class="btn btn-success" OnClick="btnListar_Click">
                        <span class="glyphicon glyphicon-ok-sign"></span> Processar
                    </asp:LinkButton>
                </div>
            </div>
            <div class="well">
                <div class="form-group">
                    <label for="ddlCadastrar">
                        Cadastrar:</label>
                    <asp:DropDownList ID="ddlCadastrar" runat="server" class="form-control">
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
                <div class="form-group">
                    <asp:LinkButton ID="btnCadastrar" runat="server" class="btn btn-success" OnClick="btnCadastrar_Click">
                        <span class="glyphicon glyphicon-ok-sign"></span> Processar
                    </asp:LinkButton>
                </div>
            </div>
            <div class="well">
                <div class="form-group">
                    <label for="txtLocalizar">
                        Localizar:</label>
                    <asp:TextBox ID="txtLocalizar" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:LinkButton ID="btnLocalizar" runat="server" class="btn btn-success" OnClick="btnLocalizar_Click">
                        <span class="glyphicon glyphicon-search"></span> Localizar
                    </asp:LinkButton>
                </div>
            </div>
            </form>
        </fieldset>
        
    </div>
</asp:Content>
