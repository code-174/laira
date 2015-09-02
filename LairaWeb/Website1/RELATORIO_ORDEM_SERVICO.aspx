<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RELATORIO_ORDEM_SERVICO.aspx.cs" Inherits="RELATORIO_ORDEM_SERVICO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server">Listagem de Ordens de Serviços</legend>
            <form id="Form2" class="form form-horizontal col-md-6" runat="server">
            <asp:GridView ID="GridView1" class="table table-hover table-bordered" runat="server"
                AutoGenerateColumns="false" ShowHeader="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr>
                                <th>
                                    OS NO
                                </th>
                                <th>
                                    TIPO
                                </th>
                                <th>
                                    DATA
                                </th>
                                <th>
                                    FEITO POR
                                </th>
                                <th>
                                    OBS
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <%#Eval("ID_OS")%>
                                </td>
                                <td>
                                    <%#Eval("TIPO_OS")%>
                                </td>
                                <td>
                                    <%#Eval("DATA")%>
                                </td>
                                <td>
                                    <%#Eval("FEITO_POR")%>
                                </td>
                                <td>
                                    <%#Eval("OBS_OS")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="ID_OS" HeaderText="OS NO" />
                    <asp:BoundField DataField="TIPO_OS" HeaderText="TIPO" />
                    <asp:BoundField DataField="DATA" HeaderText="DATA" />
                    <asp:BoundField DataField="FEITO_POR" HeaderText="FEITO POR" />
                    <asp:BoundField DataField="quant_pax" HeaderText="quant. pax" />
                    <asp:BoundField DataField="OBS_OS" HeaderText="OBS" />--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr>
                                <td colspan="100%">
                                    <asp:GridView ID="GridView2" class="table table-hover table-bordered" runat="server"
                                        AutoGenerateColumns="false" DataSource='<%# Bind("FichasLista") %>' GridLines="none">
                                        <Columns>
                                            <asp:BoundField DataField="ficha_no" HeaderText="Ficha No" />
                                            <asp:BoundField DataField="hora" HeaderText="Horário" />
                                            <asp:BoundField DataField="aeroporto" HeaderText="Aeroporto" />
                                            <asp:BoundField DataField="voo" HeaderText="Vôo" />
                                            <%--<asp:BoundField DataField="quant_pax" HeaderText="quant. pax" />--%>
                                            <asp:BoundField DataField="pax" HeaderText="Pax" />
                                            <asp:BoundField DataField="hotel" HeaderText="hotel" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td colspan="100%">
                                                            <asp:GridView ID="GridView3" class="table table-hover" runat="server" AutoGenerateColumns="false"
                                                                DataSource='<%# Bind("ServicosInclusos") %>' GridLines="none">
                                                                <Columns>
                                                                    <asp:BoundField DataField="SERV_IN" HeaderText="Serviços Inclusos" />
                                                                    <asp:BoundField DataField="PRECO" HeaderText="Valor" />
                                                                    <asp:BoundField DataField="FORMA_PAG_NO" HeaderText="Forma Pag." />
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
                                                            <asp:GridView ID="GridView4" class="table table-hover" runat="server" AutoGenerateColumns="false"
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
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </form>
        </fieldset>
    </div>
    <!-- /.container-fluid -->
</asp:Content>

