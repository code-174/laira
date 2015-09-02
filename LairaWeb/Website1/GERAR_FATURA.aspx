<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="GERAR_FATURA.aspx.cs" Inherits="GERAR_FATURA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server">Emitir Fatura</legend>
            <form id="Form1" class="form col-md-7" runat="server">
             <div class="panel panel-primary">
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
            <asp:GridView ID="GridView1" class="table table-hover table-bordered" runat="server"
                AutoGenerateColumns="false" GridLines="none"
                BorderWidth="0" ShowHeader="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <tr>
                                <th>
                                    FICHA NO
                                </th>
                                <th>
                                    COD. EXCURSSÃO
                                </th>
                                <th>
                                    VOO
                                </th>
                                <th>
                                    AER
                                </th> 
                                <th>
                                    VALOR UNIT.
                                </th>                               
                                <th>
                                    PAX
                                </th>
                                <th>
                                    QUANT. PAX
                                </th>
                                <th>
                                    VALOR TOTAL
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
                                    <%#Eval("VOO")%>
                                </td>
                                <td>
                                    <%#Eval("AEROPORTO")%>
                                </td>                                
                                <td>
                                    
                                </td>
                                <td>
                                    <%#Eval("PAX")%>
                                </td>
                                <td>
                                    <%#Eval("QUANT_PAX")%>
                                </td>
                                <td>
                                    
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
                                        DataSource='<%# Bind("ServicosInclusos") %>' GridLines="none" OnRowDataBound = "GridView2_RowDataBound"
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
    
    <%--<div class="btn-group btn-group-justified">
        <asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');"
            class="btn btn-info">Imprimir</asp:LinkButton>
        <asp:LinkButton ID="lnkVoltar" runat="server" OnClick="lnkVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
    </div>--%>
    </form> </fieldset> </div>
</asp:Content>
