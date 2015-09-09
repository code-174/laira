<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RELATORIO_VENDEDORES.aspx.cs" Inherits="RELATORIO_VENDEDORES" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend><strong>Relatório de Vendedores</strong></legend>
            <form id="Form2" class="form form-horizontal col-md-4" runat="server">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Período</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtDataInicio" class="control-label col-md-3">
                            De</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDataInicio" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtDataFim" class="control-label col-md-3">
                            Até</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtDataFim" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <!-- / PANEL PERIODO-->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Filtros</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="ddlVendedor" class="control-label col-md-3">
                            Vendedores</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlVendedor" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL VENDEDOR-->
                    <div class="form-group">
                        <label for="ddlComissao" class="control-label col-md-3">
                            Comissão definida?</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlComissao" runat="server" class="form-control">
                                <asp:ListItem Value="I">Indiferente</asp:ListItem>
                                <asp:ListItem Value="N">Não</asp:ListItem>
                                <asp:ListItem Value="S">Sim</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- / DDL COMISSAO-->
                    <div class="button-group col-md-offset-3">
                        <asp:LinkButton ID="lnkProcessar" class="btn btn-success" runat="server" OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Processar</asp:LinkButton>
                    </div>
                    <!-- / BUTTON PROCESSAR-->
                </div>
            </div>
            <!-- / PANEL FILTROS-->
            <%-- <div class="btn-group btn-group-justified">
                <asp:LinkButton ID="lnkSelecionarTodas" runat="server" OnClick="lnkSelecionarTodas_Click"
                    class="btn btn-primary">Selecionar Todas</asp:LinkButton>
                <asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');"
                    class="btn btn-info">Imprimir</asp:LinkButton>
                <asp:LinkButton ID="lnkEnviarEmail" runat="server" OnClick="lnkEnviarEmail_Click"
                    class="btn btn-warning">Enviar Por Email</asp:LinkButton>
            </div>--%>
            <!-- / BUTTON GROUP-->
            <asp:GridView ID="GridView1" class="table table-bordered" runat="server" AutoGenerateColumns="false"
                GridLines="none" HeaderStyle-CssClass="bg-primary" EmptyDataRowStyle-BackColor="Yellow"
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
                    <asp:BoundField DataField="QUANT_PAX" HeaderText="Quant. Pax" />
                    <asp:BoundField DataField="PAX" HeaderText="Pax" />
                    <asp:BoundField DataField="FORMA_PAG" HeaderText="Forma Pag." />
                    <asp:BoundField DataField="VOUCHER" HeaderText="Voucher" />
                </Columns>
            </asp:GridView>
            <!-- / GRIDVIEW1-->
            </form>
        </fieldset>
    </div>
</asp:Content>
