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
            <div class="form-inline">
            <div class="row">
                <div class="form-group col-md-2"> 
                    <label for="txtCodFicha" class="control-label">Código da Ficha</label>            
                    <asp:TextBox ID="txtCodFicha" runat="server" class="form-control col-md-offset-1"></asp:TextBox>
                </div> 
                </div>           
                
                
                <div class="row voffset2">
                <div class="form-group col-md-2">          
                <label for="txtDataChegada" class="control-label">Data Chegada</label>           
                <asp:TextBox ID="txtDataChegada" runat="server" class="form-control col-md-offset-1"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">       
                <label for="txtDataSaida" class="control-label">Data Saída</label>         
                <asp:TextBox ID="txtDataSaida" runat="server" class="form-control col-md-offset-1"></asp:TextBox>                
                </div>
                </div>
                
                <div class="row voffset2">                
                <div class="form-group col-md-2">           
                <label for="ddlVooChegada"  class="control-label">Voo Chegada / Hora</label>           
                <asp:DropDownList ID="ddlVooChegada" runat="server" class="form-control">
                </asp:DropDownList>            
                <asp:TextBox ID="txtVooHoraChegada" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                <label for="ddlVooSaida"  class="control-label">Voo Saída / Hora</label>            
                <asp:DropDownList ID="ddlVooSaida" runat="server" class="form-control">
                </asp:DropDownList>           
                <asp:TextBox ID="txtVooHoraSaida" runat="server" class="form-control"></asp:TextBox>
                </div>
                </div>                

                <div class="row voffset2">
                <div class="form-group col-md-2">
                <label for="txtAeroportoChegada"  class="control-label">Aeroporto Chegada</label>            
                <asp:TextBox ID="txtAeroportoChegada" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">                    
                <label for="txtAeroportoSaida"  class="control-label">Aeroporto Saída</label>            
                <asp:TextBox ID="txtAeroportoSaida" runat="server" class="form-control"></asp:TextBox>
                </div>                
                </div>
                 
                <div class="row voffset2">
                <div class="form-group col-md-2">
                <label for="txtCodExcursao"  class="control-label">Código Excursão</label>
                <asp:TextBox ID="txtCodExcursao" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                <label for="ddlAgencia"  class="control-label">Agência</label>
                <asp:DropDownList ID="ddlAgencia" runat="server" class="form-control"></asp:DropDownList>
                </div>                
                </div>
               
                <div class="row voffset2">
                <div class="form-group col-md-2">
                <label for="txtRecibo"  class="control-label">Recibo</label>           
                <asp:TextBox ID="txtRecibo" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                <label for="ddlHotel"  class="control-label">Hotel</label>           
                <asp:DropDownList ID="ddlHotel" runat="server" class="form-control">
                </asp:DropDownList>
                </div>
                </div>
                
                <div class="row voffset2">
                <div class="form-group col-md-2">
                <label for="txtApartamento"  class="control-label">Apartamento</label>            
                <asp:TextBox ID="txtApartamento" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group col-md-3">
                <label for="txtSaidaHotel"  class="control-label">Saída do Hotel</label>          
                <asp:TextBox ID="txtSaidaHotel" runat="server" class="form-control"></asp:TextBox>
                </div>
                </div>
                </div> <%--end form-inline--%>

                <div class="row voffset3">
           
                <asp:LinkButton ID="btnAdFicha" runat="server" OnClick="btnAdFicha_Click">[Adicionar Ficha]</asp:LinkButton>
                &nbsp;<asp:LinkButton ID="btnVoltar" runat="server" OnClick="btnVoltar_Click">[Voltar]</asp:LinkButton>
            
                Passageiros(&nbsp;<asp:ImageButton runat="server" ImageUrl="~/Figuras/AddPAX.gif" />&nbsp;clique
                aqui para adicionar pax)

                </div>
            
                <asp:GridView ID="grvData" runat="server" ShowFooter="true" AutoGenerateColumns="false">
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
                        <asp:TemplateField HeaderText="Excluir">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkExcluir" runat="server" CommandName="Excluir" ImageUrl="~/Figuras/btn_Delete.gif"
                                    ToolTip="Excluir a linha" />
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Button ID="ButtonAdd" runat="server" Text="Adicionar PAX" OnClick="ButtonAdd_Click" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            
                Observacoes:
            
                <asp:TextBox TextMode="MultiLine" Width="745px" runat="server"></asp:TextBox>
           
          <asp:GridView ID="grvServIn" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDataBound = "RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="#" HeaderText="#" />
                        <asp:TemplateField HeaderText="Local">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlLocal" runat="server"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Valor">
                            <ItemTemplate>
                                <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pagamento">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPagamento" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Excluir">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkExcluirServIn" runat="server" CommandName="Excluir" ImageUrl="~/Figuras/btn_Delete.gif"
                                    ToolTip="Excluir a linha" />
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Button ID="ButtonAddServIn" runat="server" Text="Adicionar" OnClick="ButtonAddServIn_Click" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
       
          <asp:GridView ID="grvServAd" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowDataBound = "RowDataBound2">
                    <Columns>
                        <asp:BoundField DataField="#" HeaderText="#" />

                          <asp:TemplateField HeaderText="Voucher">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Passeio">
                            <ItemTemplate>
                                <asp:DropDownList  CssClass=style1 ID="ddlPasseio" runat="server"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>                        

                          <asp:TemplateField HeaderText="Vendedor">
                            <ItemTemplate>
                                <asp:DropDownList  CssClass=style1 ID="ddlVendedor" runat="server"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Valor">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Data">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                           
                          <asp:TemplateField HeaderText="Hora">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Pagamento">
                            <ItemTemplate>
                                <asp:DropDownList  CssClass=style1 ID="ddlPagamento" runat="server"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:DropDownList CssClass=style1 ID="ddlStatus" runat="server"></asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>




                        <asp:TemplateField HeaderText="Excluir">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkExcluirServIn" runat="server" CommandName="Excluir" ImageUrl="~/Figuras/btn_Delete.gif"
                                    ToolTip="Excluir a linha" />
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Button ID="ButtonAddServIn" runat="server" Text="Adicionar" OnClick="ButtonAddServIn_Click" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

           </form>     
        </fieldset>
        
    </div>
       
</asp:Content>
