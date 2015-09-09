<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="GERAR_ORDEM_SERV.aspx.cs" Inherits="GERAR_ORDEM_SERV" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server" style="font-weight: bold"><strong>Gerar Ordem de Serviço</strong></legend>
            <form id="Form2" class="form form-horizontal col-md-7" runat="server">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <strong>Critérios</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtDataServico" class="control-label col-md-3">
                            Data dos Serviços</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDataServico" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlTipoServico" class="control-label col-md-3">
                            Tipo dos Serviços</label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlTipoServico" runat="server" class="form-control">
                                <asp:ListItem Value="C">Transfer In (Chegada)</asp:ListItem>
                                <asp:ListItem Value="S">Transfer Out (Saída)</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL TIPO SERVICO-->
                    <div class="button-group col-md-offset-4">
                        <asp:LinkButton ID="lnkProcessarCriterios" class="btn btn-success" runat="server"
                            OnClick="lnkProcessarCriterios_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                    </div>
                    <!-- / BUTTON PROCESSAR-->
                </div>
            </div>
            <!-- / PANEL CRITERIOS-->
            <div class="panel panel-success">
                <div class="panel-heading">
                    <strong>Dados Adicionais</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="ddlServicoFeitoPor" class="control-label col-md-4">
                            Serviço feito por</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlServicoFeitoPor" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL SERVICO FEITO POR-->
                    <div class="form-group">
                        <label for="txtValorServico" class="control-label col-md-4">
                            Valor do Serviço</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtValorServico" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!-- / TXT VALOR SERVICO-->
                    <div class="form-group">
                        <label for="txtValorEstacionamento" class="control-label col-md-4">
                            Valor Estacionamento</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtValorEstacionamento" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!-- / TXT VALOR ESTACIONAMENTO-->
                    <%--<div class="form-group">
                        <label for="txtTotalServico" class="control-label col-md-4">
                            Total do Serviço</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtTotalServico" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="LinkButton1" class="btn btn-success" runat="server" OnClick="lnkProcessarCriterios_Click"><span class="glyphicon glyphicon-ok">
                        </span> Calcular</asp:LinkButton>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <label for="txtTotalServico" class="control-label col-md-4">
                            Total do Serviço</label>
                        <div class="col-md-5">
                            <div class="input-group">
                                <input type="txtTotalServico" class="form-control">
                                <span class="input-group-btn">
                                    <button class="btn btn-default" type="button">
                                        Calcular</button>
                                </span>
                            </div>
                            <!-- /input-group -->
                        </div>
                    </div>
                    <!-- / TXT TOTAL SERVICO-->
                    <div class="form-group">
                        <label for="txtObs" class="control-label col-md-4">
                            Obs</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtObs" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!-- / TXT OBS-->
                </div>
            </div>
            <!-- /PANEL DADOS ADICIONAIS-->
            <div class="panel panel-success">
                <div class="panel-heading">
                    <strong>Motorista e Guia</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="ddlMotorista" class="control-label col-md-4">
                            Motorista</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlMotorista" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL MOTORISTA-->
                    <div class="form-group">
                        <label for="ddlGuia" class="control-label col-md-4">
                            Guia</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlGuia" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL GUIA-->
                </div>
            </div>
            <!-- /PANEL DADOS MOTORISTA E GUIA-->
            <%--<asp:GridView ID="grvFichas" runat="server" class="table table-hover table-bordered"
                GridLines="None" EmptyDataRowStyle-BackColor="Yellow" EmptyDataText="Nao existem fichas para a Data informada!">
            </asp:GridView>--%>
            <%--<asp:GridView runat="server">
            <asp:TemplateField HeaderTemplate    
            <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td colspan="100%">--%>
            <asp:GridView ID="GridView1" class="table table-bordered" runat="server" AutoGenerateColumns="false"
                OnRowDataBound="GridView1_RowDataBound" GridLines="none" HeaderStyle-CssClass="bg-primary"
                EmptyDataRowStyle-BackColor="Yellow" EmptyDataText="Nao existem fichas para a Data informada!">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FICHA_NO" HeaderText="FICHA" />
                    <asp:BoundField DataField="HORA" HeaderText="Hora" />
                    <asp:BoundField DataField="VOO" HeaderText="Vôo" />
                    <asp:BoundField DataField="AEROPORTO" HeaderText="Aer" />
                    <asp:BoundField DataField="HOTEL" HeaderText="Hotel" />
                    <asp:BoundField DataField="APTO" HeaderText="Apto" />
                    <asp:BoundField DataField="COD_EXCURSAO" HeaderText="Cód. Excursão" />
                    <asp:BoundField DataField="QUANT_PAX" HeaderText="Quant. Pax" />
                    <asp:BoundField DataField="PAX" HeaderText="Pax" />
                    <%--<asp:TemplateField>
                        <ItemTemplate>
                            <tr>
                                <td colspan="100%">
                                    <asp:GridView ID="GridView2" class="table table-hover" runat="server" AutoGenerateColumns="false"
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
                                    <asp:GridView ID="GridView3" class="table table-hover" runat="server" AutoGenerateColumns="false"
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
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
            <div class="button-group col-md-offset-3">
                <asp:LinkButton ID="lnkProcessar" class="btn btn-warning" runat="server" OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Confirmar</asp:LinkButton>
            </div>
            <!-- / BUTTON PROCESSAR-->
            </form>
        </fieldset>
    </div>
    <!-- /.container-fluid -->
</asp:Content>
