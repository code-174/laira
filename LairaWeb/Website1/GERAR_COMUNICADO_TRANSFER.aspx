<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="GERAR_COMUNICADO_TRANSFER.aspx.cs" Inherits="GERAR_COMUNICADO_TRANSFER" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend><strong>Comunicado de Transfer out</strong></legend>
            <form id="Form1" class="form form-horizontal col-md-4" runat="server">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Filtros</strong>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="ddlSelecione" class="control-label col-md-3">
                            Selecione</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlSelecione" runat="server" class="form-control">
                                <asp:ListItem Value="D">Data</asp:ListItem>
                                <asp:ListItem Value="F">Número da Ficha</asp:ListItem>
                                <asp:ListItem Value="E">Cód. de Excursão</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtCriterio" class="control-label col-md-3">
                            Critério</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtCriterio" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="button-group col-md-offset-3">
                        <asp:LinkButton ID="lnkProcessar" class="btn btn-success" runat="server" OnClick="lnkProcessar_Click"><span class="glyphicon glyphicon-ok">
                        </span> Filtrar Dados</asp:LinkButton>
                    </div>
                </div>
            </div>
            <asp:GridView ID="GridView1" class="table table-bordered" runat="server" AutoGenerateColumns="false"
                GridLines="none" HeaderStyle-CssClass="bg-primary" EmptyDataRowStyle-BackColor="Yellow"
                EmptyDataText="Nao existem fichas para a Data informada!" DataKeyNames="ID_SERV_AD_FICHA">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="HORA" HeaderText="Hora" />
                    <asp:BoundField DataField="AEROPORTO" HeaderText="Aer" />
                    <asp:BoundField DataField="VOO" HeaderText="Vôo" />
                    <asp:BoundField DataField="HORA_VOO" HeaderText="Hora Vôo" />
                    <asp:BoundField DataField="FICHA_NO" HeaderText="FICHA" />
                    <asp:BoundField DataField="COD_EXCURSAO" HeaderText="Cód. Excursão" />
                    <asp:BoundField DataField="PAX" HeaderText="Pax" />
                    <asp:BoundField DataField="HOTEL" HeaderText="Hotel" />
                    <asp:BoundField DataField="APTO" HeaderText="Apto" />
                    <asp:BoundField DataField="PRESTADOR" HeaderText="Realizado por" />                    
                    <asp:BoundField DataField="OS_NO" HeaderText="OS" />
                </Columns>
                </asp:GridView>
            </form>
        </fieldset>
    </div>
</asp:Content>
