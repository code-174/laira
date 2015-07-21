<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="teste_ficha.aspx.cs" Inherits="teste_ficha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <form runat="server" class="form col-md-7">
    <asp:LinkButton ID="lnkGerar" runat="server" OnClick="lnkGerar_Click" class="btn btn-warning">Gerar</asp:LinkButton>
    <asp:GridView ID="GridView1" class="table" runat="server" AutoGenerateColumns="False">
        <Columns>
      
            <asp:BoundField DataField="FICHA_NO" HeaderText="Núm." />
            <asp:BoundField DataField="COD_EXCURSAO" HeaderText="Cód. Excursão" />
            <asp:BoundField DataField="DATA" HeaderText="Data" />
            <asp:BoundField DataField="HORA" HeaderText="Hora" />
            <asp:BoundField DataField="AEROPORTO" HeaderText="Aer" />
            <asp:BoundField DataField="VOO" HeaderText="Vôo" />
            <asp:BoundField DataField="PAX" HeaderText="Pax" />
            <asp:BoundField DataField="HOTEL" HeaderText="Hotel" />
       
            <asp:TemplateField>
                <ItemTemplate>
                 <tr>
                        <td colspan="100%">
                    <asp:GridView ID="GridView2" class="table" runat="server" DataSource='<%# Bind("ServicosInclusos") %>'>
                    </asp:GridView>
                    </td>
                    </tr>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </form>
</asp:Content>
