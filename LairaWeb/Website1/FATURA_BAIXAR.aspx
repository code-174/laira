<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="FATURA_BAIXAR.aspx.cs" Inherits="FATURA_BAIXAR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend id="Titulo" runat="server" style="font-weight: bold"><strong>Baixa em Faturas</strong></legend>
            <form id="Form2" class="form" runat="server">
            <asp:GridView ID="grvFaturas" class="table table-bordered" runat="server" AutoGenerateColumns="false"
                GridLines="none" HeaderStyle-CssClass="bg-primary"
                EmptyDataRowStyle-BackColor="Yellow" EmptyDataText="Nao existem fichas para a Data informada!">
                <Columns>                    
                    <asp:BoundField DataField="FICHA_NO" HeaderText="FICHA" />
                    <asp:BoundField DataField="COD_EXCURSAO" HeaderText="Cód. Excursão" />
                    <asp:BoundField DataField="VOO" HeaderText="Vôo" />
                    <asp:BoundField DataField="AEROPORTO" HeaderText="Aer" />
                    <asp:BoundField DataField="HOTEL" HeaderText="Hotel" />
                    <asp:BoundField DataField="APTO" HeaderText="Apto" />
                    <asp:BoundField DataField="HORA" HeaderText="Hora" />
                    <asp:BoundField DataField="QUANT_PAX" HeaderText="Quant. Pax" />
                    <asp:BoundField DataField="PAX" HeaderText="Pax" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="txtDataPg" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="txtValorPg" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </form>
        </fieldset>
    </div>
</asp:Content>
