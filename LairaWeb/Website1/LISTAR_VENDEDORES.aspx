<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="LISTAR_VENDEDORES.aspx.cs" Inherits="LISTAR_VENDEDORES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:GridView ID="grvData" runat="server" AutoGenerateColumns="False">
        <Columns>
            <%--  <asp:TemplateField HeaderText="Select">
            <ItemTemplate>
                <asp:ImageButton ID="imgconciliado" runat="server" 
					AlternateText="Img" ImageAlign="Right" style="width:5%"
					ImageUrl="Figuras\logo_laira_site.png" />
            </ItemTemplate>
            <HeaderTemplate>
                <input id="chkAll"  
                runat="server" type="checkbox" />
            </HeaderTemplate>							  
	   </asp:TemplateField>--%>
            <asp:BoundField HeaderText="Codigo" DataField="CODIGO" ReadOnly="TRUE" />
            <asp:BoundField HeaderText="Nome" Visible="TRUE" DataField="NOME" />
            <asp:BoundField HeaderText="Telefone" Visible="TRUE" DataField="TELEFONE" />
            <asp:BoundField HeaderText="Celular" Visible="TRUE" DataField="CELULAR" />
            <asp:TemplateField HeaderText="Editar">
                <ItemTemplate>
                    <asp:ImageButton ID="imgEditar" runat="server" AlternateText="Img" ImageAlign="Middle"
                        Style="width: 35%" ImageUrl="Figuras\logo_laira_site.png" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Excluir">
                <ItemTemplate>
                    <asp:ImageButton ID="imgExcluir" runat="server" AlternateText="Img" ImageAlign="Middle"
                        Style="width: 35%" ImageUrl="Figuras\logo_laira_site.png" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:BoundField HeaderText="Data" DataField="_data" dataformatstring="{0:dd/MM/yyyy}" htmlencode="false"  />--%>
            <%-- <asp:TemplateField HeaderText="Conciliado?">
			<ItemTemplate>
				<asp:ImageButton ID="imgconciliado" runat="server" 
					AlternateText="Conciliado" ImageAlign="Right" style="width:25%"
					ImageUrl="Images\ok.png" />
			</ItemTemplate>
		</asp:TemplateField>  --%>
        </Columns>
        <AlternatingRowStyle BackColor="PaleTurquoise" ForeColor="DarkBlue" Font-Italic="false" />
    </asp:GridView>
</asp:Content>
