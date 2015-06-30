<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CADASTRAR_FICHA.aspx.cs" Inherits="CADASTRAR_FICHA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <legend>Cadastrar Ficha</legend>
            <form id="Form1" class="form-horizontal" runat="server">
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
                    <asp:DropDownList ID="ddlVooChegada" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlVooChegada_Change" class="form-control">
                    </asp:DropDownList>
                </div>
                
            </div>
            <!-- Voo Saída -->
            <div class="form-group col-md-3">
                <label for="ddlVooSaida" class="control-label col-md-6">
                    Voo Saída</label>
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlVooSaida" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlVooSaida_Change"  class="form-control">
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
            <div class="form-group col-md-4">
                 <label class="sr-only" for="txtObs">
                            Observações</label>
                <asp:TextBox ID="txtObs" TextMode="MultiLine" Width="745px" placeholder="Observações" runat="server"></asp:TextBox>
            </div>

            <div class="row">
            </div>

            <%--Passageiros(&nbsp;<asp:ImageButton runat="server" ImageUrl="~/Figuras/AddPAX.gif" />&nbsp;clique
            aqui para adicionar pax)--%>

            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Passageiros</strong></div>
                <div class="panel-body">
            <asp:GridView ID="grvData" runat="server" ShowFooter="true" AutoGenerateColumns="false" class="table">
                <Columns>
                    <asp:BoundField DataField="#" HeaderText="#" />
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Identidade">
                        <ItemTemplate>
                            <asp:TextBox ID="txtIdentidade" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Orgao Exp">
                        <ItemTemplate>
                            <asp:TextBox ID="txtOrgao" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefone">
                        <ItemTemplate>
                            <asp:TextBox ID="txtTelefone" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Obs">
                        <ItemTemplate>
                            <asp:TextBox ID="txtObs" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>                         
                            <asp:ImageButton ID="lnkExcluir" runat="server" CommandName="Excluir" ImageUrl="~/Figuras/btn_Delete.gif"
                                ToolTip="Excluir a linha" />
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                        <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" class="btn btn-primary">Adicionar PAX</asp:LinkButton>                            
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
            </div>
            <div class="row"> </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Serviços Inclusos</strong></div>
                <div class="panel-body">          
            <asp:GridView ID="grvServIn" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                OnRowDataBound="RowDataBound1" class="table">
                <Columns>
                    <asp:BoundField DataField="#" HeaderText="#" />
                    <asp:TemplateField HeaderText="Local">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlLocal" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor">
                        <ItemTemplate>
                            <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pagamento">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlPagamento1" runat="server"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:ImageButton ID="lnkExcluirServIn" runat="server" CommandName="Excluir" ImageUrl="~/Figuras/btn_Delete.gif"
                                ToolTip="Excluir a linha" />
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                        <asp:LinkButton ID="ButtonAddServIn" runat="server" OnClick="ButtonAddServIn_Click" class="btn btn-primary">Adicionar Serviço</asp:LinkButton>                         
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
              </div>
              </div>
             
            <div class="row" ></div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <strong>Serviços Adicionais</strong></div>
                <div class="panel-body">          
                <asp:GridView  ID="grvServAd" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                    OnRowDataBound="RowDataBound2" class="table">
                    <Columns>
                        <asp:BoundField DataField="#" HeaderText="#" />
                        <asp:TemplateField HeaderText="Voucher">
                            <ItemTemplate>
                                <asp:TextBox ID="txtVoucher" Width="80px" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Passeio">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlPasseio" runat="server">
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
                                <%--<asp:ImageButton ID="lnkExcluirServIn" runat="server" CommandName="Excluir" ImageUrl="~/Figuras/btn_Delete.gif"
                                    ToolTip="Excluir a linha" />--%>
                                <asp:LinkButton ID="lnkExcluirServAd" runat="server" class="btn btn-danger" OnClick="lnkExcluirServAd_Click">
                                <span class="glyphicon glyphicon-remove"></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:LinkButton ID="ButtonAddServAd" runat="server" OnClick="ButtonAddServAd_Click" class="btn btn-primary">Adicionar Serviço</asp:LinkButton>
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            </div>            
            <asp:LinkButton ID="btnAdFicha" runat="server" OnClick="btnAdFicha_Click" class="btn btn-primary">Adicionar Ficha</asp:LinkButton>
            &nbsp;<asp:LinkButton ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" class="btn btn-warning">Voltar</asp:LinkButton>
            </form>
        </fieldset>
    </div>
</asp:Content>
