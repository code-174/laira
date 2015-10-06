<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ALTERAR_OS_ADC.aspx.cs" Inherits="ALTERAR_OS_ADC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server" style="font-weight: bold"><strong>Alterar OS (Passeio)</strong></legend>
            <form id="Form2" class="form form-horizontal col-md-7" runat="server">
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
            <asp:GridView ID="GridView1" class="table table-bordered" runat="server"
                AutoGenerateColumns="false" GridLines="none" HeaderStyle-CssClass="bg-primary"
                EmptyDataRowStyle-BackColor="Yellow"
                EmptyDataText="Nao existem fichas para a Data informada!" DataKeyNames="ID_SERV_AD_FICHA">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" Checked="true" />
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
