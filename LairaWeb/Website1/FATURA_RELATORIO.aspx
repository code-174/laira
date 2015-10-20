<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="FATURA_RELATORIO.aspx.cs" Inherits="FATURA_RELATORIO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server" style="font-weight: bold"><strong>Relatório de Faturas</strong></legend>
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
                        <label for="ddlTipo" class="control-label col-md-2">
                            Tipo</label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlTipo" runat="server" class="form-control">
                                <asp:ListItem Value="V">Vencimento</asp:ListItem>
                                <asp:ListItem Value="E">Emissão</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label for="ddlSelecione" class="control-label col-md-2">
                            Selecione</label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlSelecione" runat="server" class="form-control">
                                <asp:ListItem Value="T">Todas</asp:ListItem>
                                <asp:ListItem Value="P">Pagas</asp:ListItem>
                                <asp:ListItem Value="E">Em Aberto</asp:ListItem>
                                <asp:ListItem Value="A">Atrasadas</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlAgencia" class="control-label col-md-2">
                            Agência</label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlAgencia" runat="server" class="form-control" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Todas</asp:ListItem>
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
                        <label for="txtFaturaNo" class="control-label col-md-3">
                            Número da Fatura</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtFaturaNo" runat="server" class="form-control"></asp:TextBox>
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
                GridLines="none" HeaderStyle-CssClass="bg-primary" EmptyDataRowStyle-BackColor="Yellow"
                EmptyDataText="Nao existem fichas para a Data informada!" 
                ShowFooter="True" FooterStyle-BackColor="#eeeeee" 
                onrowdatabound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ID_FATURA" HeaderText="Fatura" />
                    <asp:BoundField DataField="AGENCIA" HeaderText="Agência" />
                    <asp:BoundField DataField="DATA_EMISSAO" HeaderText="Emissão" />
                    <asp:BoundField DataField="VENCIMENTO" HeaderText="Vencimento" />
                    <asp:BoundField DataField="QUANT_PAX" HeaderText="Quant. Pax" />
                    <asp:BoundField DataField="VALOR" HeaderText="Valor" />
                    <asp:BoundField DataField="DATA_PAG" HeaderText="Data Pag." />
                    <asp:BoundField DataField="VALOR_PAG" HeaderText="Valor Pag." />
                </Columns>
            </asp:GridView>
            </form>
        </fieldset>
    </div>
</asp:Content>
