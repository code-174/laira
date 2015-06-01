<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Options.aspx.cs" Inherits="Options" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <div id="Filtros">
        <asp:Label ID="Label4" runat="server" Font-Size="12pt" ForeColor="#0080C6" Text="Parametros Gerais do Sistema"
            Font-Bold="True"></asp:Label>
        <br />
        <asp:GridView ID="grdParametros" runat="server" AutoGenerateColumns="False" DataSourceID="dsOptions" 
            AlternatingRowStyle-BackColor="#dddddd" GridLines="None" BorderStyle="None" BorderColor="Transparent"
            DataKeyNames="ID_OPTION" BorderWidth="0px" AllowSorting="True" CellPadding="5"
            Width="100%" PageSize="50">
            <AlternatingRowStyle BackColor="#DDDDDD" />
            <Columns>
                <asp:BoundField DataField="ID_OPTION" ReadOnly="true" HeaderText="Opção" SortExpression="ID_OPTION" />
                <asp:BoundField DataField="OPTION_VALOR" HeaderText="Valor" SortExpression="OPTION_VALOR" />
                <asp:CommandField CancelText="Cancelar" DeleteText="Excluir" EditText="Editar" InsertText="Inserir"
                    NewText="Novo" SelectText="Selecionar" ShowEditButton="True" UpdateText="Atualizar" />
            </Columns>
            <EmptyDataTemplate>
                Sem resultados
            </EmptyDataTemplate>
            <HeaderStyle BackColor="#177DB3" ForeColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="dsOptions" runat="server" ConnectionString="<%$ ConnectionStrings:LairaWebDB %>"
            SelectCommand="SELECT [ID_OPTION], [OPTION_VALOR] FROM [TB_OPTIONS]" InsertCommand="INSERT INTO [TB_OPTIONS] ([ID_OPTION], [OPTION_VALOR]) VALUES (@ID_OPTION, @OPTION_VALOR)"
            UpdateCommand="UPDATE [TB_OPTIONS] SET [OPTION_VALOR] = @OPTION_VALOR WHERE (ID_OPTION = @ID_OPTION) ">
            <InsertParameters>
                <asp:Parameter Name="ID_OPTION" Type="String" />
                <asp:Parameter Name="OPTION_VALOR" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ID_OPTION" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
</asp:Content>

