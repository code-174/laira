<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CADASTRAR_FICHA.aspx.cs" Inherits="CADASTRAR_FICHA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Cadastrar Ficha</legend>
            <form id="Form1" class="form" runat="server">
            <%--<div class="panel panel-default col-md-10">
                <div class="panel-body">--%>
                    <div class="form-group col-md-3">
                        <label for="txtCodFicha" class="control-label col-md-6">
                            Código da Ficha</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtCodFicha" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="form-group col-md-3">
                        <!--tamanho do text box e do label-->
                        <label for="txtDataChegada" class="control-label col-md-6">
                            Data Chegada</label>
                        <!--tamanho do label-->
                        <div class="col-md-6">
                            <!--tamanho do text box-->
                            <asp:TextBox ID="txtDataChegada" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="txtDataSaida" class="control-label col-md-6">
                            Data Saída</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDataSaida" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <!-- Voo Chegada -->
                    <div class="form-group col-md-3">
                        <label for="ddlVooChegada" class="control-label col-md-6">
                            Voo Chegada</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlVooChegada" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlVooChegada_Change"
                                class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <!-- Voo Saída -->
                    <div class="form-group col-md-3">
                        <label for="ddlVooSaida" class="control-label col-md-6">
                            Voo Saída</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlVooSaida" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlVooSaida_Change"
                                class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="form-group col-md-3">
                        <label for="txtVooHoraChegada" class="control-label col-md-6">
                            Hora Chegada</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtVooHoraChegada" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="txtVooHoraSaida" class="control-label col-md-6">
                            Hora Saída</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtVooHoraSaida" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="form-group col-md-3">
                        <label for="txtAeroportoChegada" class="control-label col-md-6">
                            Aer. Chegada</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtAeroportoChegada" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="txtAeroportoSaida" class="control-label col-md-6">
                            Aer. Saída</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtAeroportoSaida" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="form-group col-md-3">
                        <label for="txtCodExcursao" class="control-label col-md-6">
                            Cód. Excursão</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtCodExcursao" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="ddlAgencia" class="control-label col-md-6">
                            Agência</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlAgencia" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="form-group col-md-3">
                        <label for="txtRecibo" class="control-label col-md-6">
                            Recibo</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtRecibo" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="ddlHotel" class="control-label col-md-6">
                            Hotel</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlHotel" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="form-group col-md-3">
                        <label for="txtApartamento" class="control-label col-md-6">
                            Apartamento</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtApartamento" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="txtSaidaHotel" class="control-label col-md-6">
                            Saída do Hotel</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtSaidaHotel" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                    </div>
                    <div class="form-group col-md-6">
                        <label class="sr-only" for="txtObs">
                            Observações</label>
                        <div class="col-md-10 col-md-offset-1">
                            <asp:TextBox ID="txtObs" runat="server" TextMode="multiline" class="form-control"
                                placeholder="Observações"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                    </div>
              <%--  </div>
            </div>--%>
            <div class="form-group col-md-11">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <strong>Passageiros</strong></div>
                    <div class="panel-body">
                        <asp:ScriptManager ID="ScriptManager1" runat="server" />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grvData" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                                    OnRowDeleting="OnRowDeleting" OnRowDataBound="OnRowDataBound" class="table table-hover table-bordered"
                                    GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="#" Visible="false" HeaderText="#" />
                                        <asp:TemplateField HeaderText="Nome">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Identidade">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtIdentidade" Width="100px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Orgao Exp">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtOrgao" Width="100px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Telefone">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Obs">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtObs" TextMode="MultiLine" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkExcluirPAX" CommandName="Delete" runat="server" class="btn btn-danger">
                                <span class="glyphicon glyphicon-remove"></span>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:LinkButton ID="ButtonAdd" AutoPostBack="true" runat="server" OnClick="ButtonAdd_Click"
                                                    class="btn btn-success">Adicionar PAX</asp:LinkButton>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                </div>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <strong>Serviços Inclusos</strong></div>
                    <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grvServIn" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                                    class="table table-hover table-bordered" GridLines="None" OnRowDataBound="RowDataBound1"
                                    OnRowDeleting="grvServIn_OnRowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="#" Visible="false" HeaderText="#" />
                                        <asp:TemplateField HeaderText="Local">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlLocal" Width="200px" runat="server">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valor">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtValor" Width="90px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pagamento">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlPagamento1" runat="server">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkExcluirServIn" CommandName="Delete" runat="server" class="btn btn-danger">
                                <span class="glyphicon glyphicon-remove"></span>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:LinkButton ID="ButtonAddServIn" runat="server" OnClick="ButtonAddServIn_Click"
                                                    class="btn btn-success">Adicionar Serviço</asp:LinkButton>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                </div>
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <strong>Serviços Adicionais</strong></div>
                    <div class="panel-body">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grvServAd" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                                    class="table table-hover table-bordered" GridLines="None" OnRowDataBound="RowDataBound2"
                                    OnRowDeleting="grvServAd_OnRowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="#" Visible="false" HeaderText="#" />
                                        <asp:TemplateField HeaderText="Voucher">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtVoucher" Width="80px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Passeio">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlPasseio" Width="200px" runat="server">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Vendedor">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlVendedor" Width="90px" runat="server">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valor">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtValor2" Width="90px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Data">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtData" Width="90px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Hora">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtHora" Width="90px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pagamento">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlPagamento2" Width="90px" runat="server">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlStatus" Width="90px" runat="server">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkExcluirServAd" CommandName="Delete" runat="server" class="btn btn-danger">
                                <span class="glyphicon glyphicon-remove"></span>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:LinkButton ID="ButtonAddServAd" runat="server" OnClick="ButtonAddServAd_Click"
                                                    class="btn btn-success">Adicionar Serviço</asp:LinkButton>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <asp:LinkButton ID="btnAdFicha" runat="server" OnClick="btnAdFicha_Click" class="btn btn-primary">Adicionar Ficha</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
            </div>
            </form>
        </fieldset>
    </div>
</asp:Content>
