<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="GERAR_FATURA.aspx.cs" Inherits="GERAR_FATURA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server" style="font-weight: bold">Emitir Fatura</legend>
            <form id="Form1" class="form form-horizontal col-md-6" runat="server">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <strong>Faturar serviços com os critérios:</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtDataInicio" class="control-label col-md-2">
                            De</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDataInicio" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <label for="txtDataFim" class="control-label col-md-1">
                            Até</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDataFim" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlAgencia" class="control-label col-md-2">
                            Agência</label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlAgencia" runat="server" class="form-control" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Selecione</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <asp:LinkButton ID="lnkProcessar" class="btn btn-success" runat="server" OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /PANEL CRITERIOS-->
            <div class="panel panel-success" id="panNaoFaturados" runat="server" visible="true">
                <div class="panel-heading">
                    <strong>Lista de serviços não faturados:</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtDataInicio2" class="control-label col-md-2">
                            De</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDataInicio2" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <label for="txtDataFim2" class="control-label col-md-1">
                            Até</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDataFim2" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <asp:LinkButton ID="LinkButton1" class="btn btn-success" runat="server" OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /PANEL NAO FATURADOS-->
            <div class="panel panel-success" id="panDadosAdc" runat="server" visible="false">
                <div class="panel-heading">
                    <strong>Dados adicionais:</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtDataEmissao" class="control-label col-md-3">
                            Data Emissão</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDataEmissao" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <label for="txtVencimento" class="control-label col-md-2">
                            Vencimento</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtVencimento" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtValorFatura" class="control-label col-md-3">
                            Valor da Fatura</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtValorFatura" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <label for="txtQtdPax" class="control-label col-md-2">
                            Qtd. Pax</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtQtdPax" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtFaturaNo" class="control-label col-md-3">
                            Nº Faturamento</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtFaturaNo" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtOBS" class="control-label col-md-3">
                            OBS</label>
                        <div class="col-md-8">
                            <%--<textarea id="txtOBS" runat="server" class="form-control" rows="3"></textarea>--%>
                            <asp:TextBox ID="txtOBS" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /PANEL NAO FATURADOS-->
            <asp:GridView ID="grvQuantidade" runat="server" class="table table-bordered" AutoGenerateColumns="false"
                GridLines="none" HeaderStyle-CssClass="bg-primary"  DataKeyNames="AGENCIA_NO" OnRowCommand="grvQuantidade_RowCommand">
                <Columns>
                    <asp:BoundField DataField="NOME_AGENCIA" HeaderText="Agência" />
                    <asp:BoundField DataField="QUANT_FICHA" HeaderText="Total de Serviços" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkFaturar" CommandName="Faturar" CommandArgument='<%# Container.DataItemIndex %>' class="btn btn-success" runat="server"><span class="glyphicon glyphicon-ok">
                        </span> Gerar Fatura</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:GridView ID="GridView1" class="table table-bordered" runat="server" AutoGenerateColumns="false"
                GridLines="none" DataKeyNames="FICHA_NO">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr class="bg-primary">
                                <th>
                                </th>
                                <th>
                                    Ficha
                                </th>
                                <th>
                                    Excursão
                                </th>
                                <th>
                                    Valor Unit.
                                </th>
                                <th>
                                    Quant. Pax
                                </th>
                                <th>
                                    Valor Total
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </td>
                                <td>
                                    <%#Eval("FICHA_NO")%>
                                </td>
                                <td>
                                    <%#Eval("COD_EXCURSAO")%>
                                </td>
                                <td>
                                    <%#Eval("VALOR_UNIT")%>
                                </td>
                                <td>
                                    <%#Eval("QUANT_PAX")%>
                                </td>
                                <td>
                                 <%# Convert.ToDouble(DataBinder.Eval(Container.DataItem, "VALOR_UNIT")) * Convert.ToDouble(DataBinder.Eval(Container.DataItem, "QUANT_PAX"))%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="ficha_no" HeaderText="ficha" />
                        <asp:BoundField DataField="cod_excursao" HeaderText="cód. excursão" />
                        <asp:BoundField DataField="data" HeaderText="data" />
                        <asp:BoundField DataField="hora" HeaderText="hora" />
                        <asp:BoundField DataField="aeroporto" HeaderText="aer" />
                        <asp:BoundField DataField="voo" HeaderText="vôo" />
                        <asp:BoundField DataField="quant_pax" HeaderText="quant. pax" />
                        <asp:BoundField DataField="pax" HeaderText="pax" />
                        <asp:BoundField DataField="hotel" HeaderText="hotel" />
                        <asp:BoundField DataField="apto" HeaderText="apto" />--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr>
                                <td colspan="100%">
                                    <asp:GridView ID="GridView2" class="table table-hover" runat="server" AutoGenerateColumns="false"
                                        DataSource='<%# Bind("ServicosInclusos") %>' GridLines="none" OnRowDataBound="GridView2_RowDataBound"
                                        ShowFooter="true">
                                        <Columns>
                                            <asp:BoundField DataField="SERV_IN" HeaderText="Serviços Inclusos" />
                                            <asp:BoundField DataField="PRECO" HeaderText="Valor" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="col-md-3">
                <asp:LinkButton ID="lnkConfirmar" class="btn btn-warning" runat="server" OnClick="lnkConfirmar_Click"
                    Visible="false"><span class="glyphicon glyphicon-ok">
                        </span> Confirmar</asp:LinkButton>
            </div>
            <%--<div class="btn-group btn-group-justified">
        <asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');"
            class="btn btn-info">Imprimir</asp:LinkButton>
        <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
    </div>--%>
            </form>
        </fieldset>
    </div>
</asp:Content>
