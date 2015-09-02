<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RELATORIO_OS_ADC.aspx.cs" Inherits="RELATORIO_OS_ADC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server">Listagem de OS (Passeios)</legend>
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
                                    <%#Eval("ID_OS_ADC")%>
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
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr>
                                <td colspan="100%">
                                    <asp:GridView ID="GridView2" class="table table-hover table-bordered" runat="server"
                                        AutoGenerateColumns="false" DataSource='<%# Bind("FichasLista") %>' GridLines="none">
                                        <Columns>
                                            <asp:BoundField DataField="ficha_no" HeaderText="Ficha No" />
                                            <asp:BoundField DataField="hora" HeaderText="Horário" />
                                            <asp:BoundField DataField="hotel" HeaderText="Hotel" />
                                            <asp:BoundField DataField="apto" HeaderText="Apto" />
                                            <asp:BoundField DataField="passeio" HeaderText="Passeio" />
                                            <asp:BoundField DataField="forma_pag" HeaderText="Forma Pag." />
                                            <asp:BoundField DataField="vendedor" HeaderText="Vendedor" />
                                            <asp:BoundField DataField="pax" HeaderText="Pax" />
                                            <%--<asp:BoundField DataField="quant_pax" HeaderText="quant. pax" />--%>
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
</asp:Content>
