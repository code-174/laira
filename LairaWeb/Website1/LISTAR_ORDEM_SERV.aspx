<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="LISTAR_ORDEM_SERV.aspx.cs" Inherits="LISTAR_ORDEM_SERV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server" style="font-weight:bold">Relatório de Ordens de Serviços</legend>
            <form id="Form2" class="form form-horizontal col-md-6" runat="server">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <strong>Filtros</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtDataInicio" class="control-label col-md-4">
                            Data Inicial</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDataInicio" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="form-group">
                        <label for="txtDataFim" class="control-label col-md-4">
                            Data Final</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDataFim" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlTipoOS" class="control-label col-md-4">
                            Tipo dos Serviços</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlTipoOS" runat="server" class="form-control">
                                <asp:ListItem Value="C">Chegada</asp:ListItem>
                                <asp:ListItem Value="S">Saída</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL TIPO OS-->
                    <div class="form-group">
                        <label for="ddlPrestador" class="control-label col-md-4">
                            Prestadores</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlPrestador" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL PRESTADOR-->
                    <div class="form-group">
                        <label for="ddlSelecione" class="control-label col-md-4">
                            Selecione</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlSelecione" runat="server" class="form-control">
                                <asp:ListItem Value="T">Todas</asp:ListItem>
                                <asp:ListItem Value="N">Não Impressas</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL SELECIONE-->
                    <div class="button-group col-md-offset-4">
                        <asp:LinkButton ID="lnkProcessar" class="btn btn-success" runat="server" OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Filtrar Dados</asp:LinkButton>
                    </div>
                    <!-- / BUTTON PROCESSAR-->
                </div>
            </div>
            <!-- / PAINEL FILTROS-->
            <div class="panel panel-success">
                <div class="panel-heading">
                    <strong>Localizar</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group form-horizontal">
                        <label for="txtOSNo" class="control-label col-md-3">
                            Número</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtOSNo" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="button-group col-md-offset-3">
                        <asp:LinkButton ID="lnkLocalizar" class="btn btn-success" runat="server" OnClick="lnkLocalizar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                    </div>
                    <!-- / BUTTON LOCALIZAR-->
                </div>
            </div>
            <!-- /PANEL LOCALIZAR-->
            <asp:GridView ID="GridView1" class="table table-hover table-bordered" runat="server"
                AutoGenerateColumns="false" ShowHeader="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr class="bg-primary">
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
