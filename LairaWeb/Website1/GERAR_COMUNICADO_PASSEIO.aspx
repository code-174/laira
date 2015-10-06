<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="GERAR_COMUNICADO_PASSEIO.aspx.cs" Inherits="GERAR_COMUNICADO_PASSEIO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server" style="font-weight: bold">Comunicado de Passeio</legend>
            <form id="Form2" class="form form-horizontal col-md-6" runat="server">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <strong>Filtros</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtData" class="control-label col-md-2">
                            Data</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtData" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlPasseio" class="control-label col-md-2">
                            Passeios</label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlPasseio" runat="server" class="form-control" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Todos</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label for="ddlSelecione" class="control-label col-md-2">
                            Gerar</label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlSelecione" runat="server" class="form-control">
                                <asp:ListItem Value="T">Todas</asp:ListItem>
                                <asp:ListItem Value="N">Não Impressas</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlPrestador" class="control-label col-md-2">
                            Prestadores</label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlPrestador" runat="server" class="form-control" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Todos</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <label for="ddlVendedor" class="control-label col-md-2">
                            Vendedor</label>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlVendedor" runat="server" class="form-control" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Todos</asp:ListItem>
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
                        <label for="txtOSNo" class="control-label col-md-3">
                            Número</label>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtOSNo" runat="server" class="form-control"></asp:TextBox>
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



            <div class="btn-group btn-group-justified">
                <asp:LinkButton ID="lnkSelecionarTodas" runat="server" OnClick="lnkSelecionarTodas_Click"
                    class="btn btn-primary">Selecionar Todas</asp:LinkButton>
                <asp:LinkButton ID="lnkImprimir" runat="server" OnClientClick="javascript:CallPrint('divPrint');"
                    class="btn btn-info">Imprimir</asp:LinkButton>
                <asp:LinkButton ID="lnkEnviarEmail" runat="server" OnClick="lnkEnviarEmail_Click"
                    class="btn btn-warning">Enviar Por Email</asp:LinkButton>
            </div>
            <div class="form-group">
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
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
