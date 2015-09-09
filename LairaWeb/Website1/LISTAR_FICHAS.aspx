<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="LISTAR_FICHAS.aspx.cs" Inherits="LISTAR_FICHAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server" style="font-weight: bold">Listar Fichas</legend>
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
            </div>
            <div id="divPrint">
                <%--<asp:GridView ID="grvData" runat="server" class="table table-hover" 
                    GridLines="None">
                </asp:GridView>--%>
                <asp:GridView ID="GridView1" class="table table-bordered" runat="server" AutoGenerateColumns="false"
                    OnRowDataBound="GridView1_RowDataBound" GridLines="none" BorderWidth="0" ShowHeader="false">
                    <Columns>                    
                    <asp:TemplateField>
                    <ItemTemplate>                    
                        <tr class="bg-primary">
                            <th>
                                Ficha 
                            </th>
                            <th>
                                Excursão
                            </th>
                            <th>
                                Data
                            </th>
                            <th>
                                Hora
                            </th>
                            <th>
                                Aer
                            </th>
                            <th>
                                Vôo
                            </th>
                            <th>
                                Pax
                            </th>
                            <th>
                                Hotel
                            </th>
                            <th>
                                Apto.
                            </th>
                            <th>
                                Realizado Por
                            </th>
                            <th>
                                Nr. OS
                            </th>
                        </tr>
                        <tr>
                            <td>
                                <%#Eval("FICHA_NO")%>
                            </td>
                            <td>
                                <%#Eval("COD_EXCURSAO")%>
                            </td>
                            <td>
                                <%#Eval("DATA")%>
                            </td>
                            <td>
                                <%#Eval("HORA")%>
                            </td>
                            <td>
                                <%#Eval("AEROPORTO")%>
                            </td>
                            <td>
                                <%#Eval("VOO")%>
                            </td>
                            <td>
                                <%#Eval("PAX")%>
                            </td>
                            <td>
                                <%#Eval("HOTEL")%>
                            </td>
                            <td>
                                <%#Eval("APTO")%>
                            </td>                            
                            <td>
                                <%#Eval("PRESTADOR")%>
                            </td>
                            <td>
                                <%#Eval("OS_NO")%>
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
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="btn-group btn-group-justified">
                <asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');"
                    class="btn btn-info">Imprimir</asp:LinkButton>
                <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
