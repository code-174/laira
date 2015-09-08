<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="GERAR_ORDEM_SERV_ADC.aspx.cs" Inherits="GERAR_ORDEM_SERV_ADC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend><strong>Gerar Ordem de Serviço Adicional (Passeios)</strong></legend>
            <form id="Form2" class="form form-horizontal col-md-6" runat="server">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <strong>Critérios</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtDataServico" class="control-label col-md-4">
                            Data dos Serviços</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtDataServico" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlPasseios" class="control-label col-md-4">
                            Passeios</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlPasseios" runat="server" class="form-control">
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
                        <label for="txtObs" class="control-label col-md-4">
                            Obs</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtObs" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <!-- / TXT VALOR SERVICO-->
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
            <asp:GridView ID="GridView1" class="table table-bordered" runat="server"
                AutoGenerateColumns="false" GridLines="none" HeaderStyle-CssClass="bg-primary"
                EmptyDataRowStyle-BackColor="Yellow"
                EmptyDataText="Nao existem fichas para a Data informada!" DataKeyNames="ID_SERV_AD_FICHA">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FICHA_NO" HeaderText="FICHA" />
                    <asp:BoundField DataField="HORA" HeaderText="Hora" />
                    <asp:BoundField DataField="HOTEL" HeaderText="Hotel" />
                    <asp:BoundField DataField="APTO" HeaderText="Apto" />
                    <asp:BoundField DataField="PASSEIO" HeaderText="Passeio" />
                    <%--<asp:BoundField DataField="QUANT_PAX" HeaderText="Quant. Pax" />--%>
                    <asp:BoundField DataField="PAX" HeaderText="Pax" />
                    <asp:BoundField DataField="FORMA_PAG" HeaderText="Forma Pag." />
                    <asp:BoundField DataField="VOUCHER" HeaderText="Voucher" />
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
</asp:Content>
