<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogon.master" AutoEventWireup="true"
    CodeFile="LAYOUT_COMUNICADO.aspx.cs" Inherits="LAYOUT_COMUNICADO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <fieldset>
            <form id="Form2" class="form col-md-7" runat="server">
            <div class="panel panel-default">
                <div class="panel-body">
                <div class="text-center">
                    <h2>
                        <span class="label label-default">Comunicado de Passeio</span></h2>
                        </div>  
                    <div class="form-group">
                        <div class="col-md-8">
                            <h3>
                                <span class="label label-default">Comunicado para o hóspede</span></h3>
                        </div>
                        <div class="col-md-4">
                            <h3>
                                <span class="label label-default">Apartamento</span></h3>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtPax" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    </div>
            </div>
                    
                    <div class="panel panel-default">
                <div class="panel-body">

                    <div class="col-md-12">
                        <h5>
                      
                            A <strong>Laira Tours</strong> agradece a preferência pela escolha da nossa empresa.
                            Aproveitamos, através deste, para confirmar sua reserva à bordo do tour:
                         </h5>
                    </div>
                    <div class="form-group col-md-12">
                        <label for="txtTour" class="control-label">
                            Tour</label>
                        <div>
                            <asp:TextBox ID="txtTour" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-group col-md-6">
                            <label for="txtHotel" class="control-label">
                                Hotel</label>
                            <asp:TextBox ID="txtHotel" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3">
                            <label for="txtData" class="control-label">
                                Data / Date</label>
                            <asp:TextBox ID="txtData" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-3">
                            <label for="txtHora" class="control-label">
                                Hora / Time</label>
                            <asp:TextBox ID="txtHora" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    </div>
                    </div>

                
            <!-- / PANEL HOSPEDE-->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3>
                        Importante! Leia com atenção:</h3>
                </div>
                <div class="panel-body">
                    <!-- List
            group -->
                    <ul class="list-group">
                        <li class="list-group-item">Solicitamos que aguarde na recepção do hotel. Nossos guias
                            não procuram nos apartamentos nem nos restaurantes. Em caso de atraso dos mesmos,
                            favor entrar em contato conosco o mais rapidamente possível.</li>
                        <li class="list-group-item">Nenhum dos passeios dentro da cidade do Rio de Janeiro inclui
                            ingresso ou refeição. Estes devem ser adquiridos pelo próprio cliente.</li>
                        <li class="list-group-item">Todos os passeios são realizados independentemente das condições
                            climáticas, exceto aqueles que dependem de condições de navegação. Uma vez embarcado
                            não há direito a devolução de valores. Quando não houver possibilidade de navegação
                            o cliente será restituido do valor do passeio da escuna negociado com o a empresa
                            prestadora.</li>
                        <li class="list-group-item">Em caso de não embarque, será considerado "no show", não
                            havendo remarcação do passeio e/ou devolução de valores pagos. Quando incluso no
                            voucher de pacotes das operadoras.</li>
                        <li class="list-group-item">Por se tratar de serviços regulares (serviços compartilhados
                            com outras pessoas) os horários acima informados são estimados de embarque, portanto
                            sujeitos a atrasos de trânsito e/ou de embarque de clientes comuns a este serviço.</li>
                        <li class="list-group-item">Os contraentes elegem o Foro da cidade do Rio de Janeiro
                            como competente para soluciona os litígios que resultadres deste contrato.</li>
                        <li class="list-group-item">Este não é válido como recibo e/ou voucher de serviço.</li>
                    </ul>
                </div>
                <div class="panel-footer
            text-center">
                    <strong>Em caso de dúvidas, estamos à sua inteira disposição através dos telefones:<br />
                        Horário comercial: (21) 2577-6678 ou 24h: (21) 98304-1000 / (21) 97675-0117
                    </strong>
                </div>
            </div>
            <div class="col-md-6">
            <h4>
                É um grande prazer tê-lo à bordo.<br /> Atenciosamente,</h4>
            </div>
            <!-- / PANEL AVISO-->
            </form>
        </fieldset>
    </div>
</asp:Content>
