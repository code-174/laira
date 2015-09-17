<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RELATORIO_OS_ADC.aspx.cs" Inherits="RELATORIO_OS_ADC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server" style="font-weight: bold">Listagem de OS (Passeios)</legend>
            <form id="Form2" class="form form-horizontal col-md-6" runat="server">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <strong>Filtros</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtDataInicio" class="control-label col-md-2">
                            De</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDataInicio" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <label for="txtDataFim" class="control-label col-md-2">
                            Até</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDataFim" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlPasseio" class="control-label col-md-2">
                            Passeios</label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlPasseio" runat="server" class="form-control" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Todos</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label for="ddlSelecione" class="control-label col-md-2">
                            Gerar</label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlSelecione" runat="server" class="form-control">
                                <asp:ListItem Value="T">Todas</asp:ListItem>
                                <asp:ListItem Value="N">Não Impressas</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlPrestador" class="control-label col-md-2">
                            Prestadores</label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlPrestador" runat="server" class="form-control" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Todos</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label for="ddlVendedor" class="control-label col-md-2">
                            Vendedor</label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlVendedor" runat="server" class="form-control" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Todos</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="button-group col-md-offset-4">
                        <asp:LinkButton ID="lnkProcessar" class="btn btn-success" runat="server" OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Filtrar Dados</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="panel panel-success">
                <div class="panel-heading">
                    <strong>Localizar</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group form-horizontal">
                        <label for="txtOSNo" class="control-label col-md-3">
                            Número</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtOSNo" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="button-group col-md-3">
                            <asp:LinkButton ID="lnkLocalizar" class="btn btn-success" runat="server" OnClick="lnkLocalizar_Click"><span class="glyphicon glyphicon-ok">
                        </span> 
                        Localizar</asp:LinkButton>
                        </div>
                        <!-- / BUTTON LOCALIZAR-->
                    </div>
                </div>
            </div>
            <!-- /PANEL LOCALIZAR-->
            <asp:GridView ID="GridView1" class="table table-bordered" runat="server" AutoGenerateColumns="false"
                GridLines="none" ShowHeader="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr class="bg-primary">
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
