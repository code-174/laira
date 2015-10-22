<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RELATORIO_FICHAS.aspx.cs" Inherits="RELATORIO_FICHAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server" style="font-weight: bold">Relatório Fichas</legend>
            <form id="Form1" class="form col-md-7" runat="server">
            <div class="form-group form-horizontal">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <strong>Filtros</strong>
                    </div>
                    <div class="panel-body">
                        <div class="form-group">
                            <label for="ddlTipo" class="control-label col-md-2">
                                Tipo</label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlTipo" runat="server" class="form-control">
                                    <asp:ListItem Value="C">Chegada</asp:ListItem>
                                    <asp:ListItem Value="S">Saída</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="ddlSelecione" class="control-label col-md-2">
                                Selecione</label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlSelecione" runat="server" class="form-control">
                                    <asp:ListItem Value="D">Data</asp:ListItem>
                                    <asp:ListItem Value="F">Número da Ficha</asp:ListItem>
                                    <asp:ListItem Value="E">Cód. de Excursão</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtCriterio" class="control-label col-md-2">
                                Critério</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtCriterio" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="button-group col-md-offset-3">
                            <asp:LinkButton ID="lnkProcessar" class="btn btn-success" runat="server" OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Filtrar Dados</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="btn-group btn-group-justified">
                                <asp:LinkButton ID="lnkSelectAll" runat="server" OnClick="lnkSelectAll_Click" class="btn btn-info">Selecionar Todos</asp:LinkButton>
                                <asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');"
                                    class="btn btn-primary">Imprimir</asp:LinkButton>
                                <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
                            </div>
                        </div>
                        <div id="divPrint">
                            <link rel="stylesheet" href="Styles/bootstrap.min.css" type="text/css" media="all" />
                            <div class="form-group">
                                <asp:GridView ID="GridView1" class="table table-bordered" runat="server" AutoGenerateColumns="false"
                                    OnRowDataBound="GridView1_RowDataBound" GridLines="none" HeaderStyle-CssClass="bg-primary">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-CssClass="bg-primary">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="HORA" HeaderText="Hora" />
                                        <asp:BoundField DataField="AEROPORTO" HeaderText="Aer" />
                                        <asp:BoundField DataField="VOO" HeaderText="Vôo" />
                                        <asp:BoundField DataField="FICHA_NO" HeaderText="Ficha" />
                                        <asp:BoundField DataField="COD_EXCURSAO" HeaderText="Cód. Excursão" />
                                        <asp:BoundField DataField="PAX" HeaderText="Pax" />
                                        <asp:BoundField DataField="HOTEL" HeaderText="Hotel" />
                                        <asp:BoundField DataField="PRESTADOR" HeaderText="Realizado Por" />
                                        <asp:BoundField DataField="OS_NO" HeaderText="Nr. OS" />
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
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
<%--<asp:TemplateField>
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
                </asp:TemplateField>--%>
