<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="teste_ficha.aspx.cs" Inherits="teste_ficha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <form runat="server" class="form">
        <asp:LinkButton ID="lnkGerar" runat="server" OnClick="lnkGerar_Click" class="btn btn-warning">Gerar</asp:LinkButton>

        <asp:GridView ID="GridView1" class="table table-hover" runat="server" AutoGenerateColumns="false"
            OnRowDataBound="GridView1_RowDataBound" GridLines="vertical">
            <Columns>
                <asp:BoundField DataField="FICHA_NO" HeaderText="FICHA" />
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
                                <asp:GridView ID="GridView2" class="table table-hover" runat="server" AutoGenerateColumns="false"
                                    DataSource='<%# Bind("ServicosInclusos") %>' GridLines="none">
                                    <Columns>
                                        <asp:BoundField DataField="SERV_IN" HeaderText="Serviços Inclusos" />
                                        <asp:BoundField DataField="PRECO" HeaderText="Valor" />
                                        <asp:BoundField DataField="FORMA_PAG" HeaderText="Forma Pag." />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">
                                <asp:GridView ID="GridView3" class="table table-hover" runat="server"  AutoGenerateColumns="false"
                                     DataSource='<%# Bind("ServicosAdicionais") %>' GridLines="none">
                                    <Columns>
                                        <asp:BoundField DataField="SERV_AD" HeaderText="Serviços Adicionais" />
                                        <asp:BoundField DataField="VOUCHER" HeaderText="Voucher" />
                                        <asp:BoundField DataField="PRECO" HeaderText="Valor" />
                                        <asp:BoundField DataField="DATA" HeaderText="Data" />
                                        <asp:BoundField DataField="HORA" HeaderText="Hora" />
                                        <asp:BoundField DataField="VENDEDOR" HeaderText="Vendedor" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </form>
    </div>
</asp:Content>
