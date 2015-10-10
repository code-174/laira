<%@ Page Title="Log In" Language="C#" MasterPageFile="~/SiteLogon.master" AutoEventWireup="false" 
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<asp:Content ID="HeadContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-fluid">
        <fieldset>
            <legend>Acessar Painel</legend>
            <form id="Form1" class="form-horizontal col-md-7" runat="server">
            <div class="form-group">
                <legend>Informações de Acesso</legend>
                <div class="form-group">
                    <label for="UserName" class="control-label col-md-2">
                        Senha</label>
                    <div class="col-md-7">
                        <asp:TextBox ID="UserName" Style="width: 90%" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label for="PasswordLabel" class="control-label col-md-2">
                        Senha</label>
                    <div class="col-md-7">
                        <asp:TextBox ID="Password" Style="width: 90%" TextMode="Password" runat="server"
                            class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6 col-md-offset-2">
                    <div class="btn-group btn-group-justified">
                        <asp:LinkButton ID="LoginButton" runat="server" OnClick="btnOK_Click" class="btn btn-primary">Acessar Painel</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <p style="font-size: small; padding-left: 145px; width: 70%">
                    Seja bem-vindo ao sistema <strong>LAIRA TOURS</strong>, uma área com vários serviços
                    visando o aperfeiçoamento da prestação de serviços ao cliente final.</p>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
