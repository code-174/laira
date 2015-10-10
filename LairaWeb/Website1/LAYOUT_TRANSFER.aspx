<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="LAYOUT_TRANSFER.aspx.cs" Inherits="LAYOUT_TRANSFER" %>

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
                            <span class="label label-default">Comunicado de Transfer out</span></h2>
                    </div>
                    <div class="form-group col-md-12">
                        <label for="txtHotel" class="control-label">
                            Hotel</label>
                        <div>
                            <asp:TextBox ID="txtHotel" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                        </div>
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
                            Comunicamos que o traslado dos Srs. será no dia <asp:TextBox ID="txtData" runat="server" class="form-control">Data</asp:TextBox> , às 13:00:00 . Favor
                            aguardar na recepção do hotel. Em caso de dúvidas ou discordâncias de horários de
                            transfer com relação ao horário do vôo impresso em seu voucher, favor chamar: Horário
                            comercial : (21) 2577-6678 ou 24h : (21) 98304-1000 / (21) 97675-0117
                        </h5>
                    </div>
                </div>
                <div class="panel-footer
            text-center">
                    <strong>A Laira Tours não está autorizada a trocar vôos, prevalecendo sempre o vôo e
                        horário impressos no voucher da sua operadora. </strong>
                </div>
            </div>
            <!-- / PANEL HOSPEDE-->
            <div class="panel panel-default">
                <div class="panel-body">
                    <table class="table table-striped">
                        <tr>
                            <th>
                                Aeroporto Galeão
                            </th>
                            <th>
                                Hotéis Centro e Zona Sul
                            </th>
                            <th>
                                São Conrrado e Barra
                            </th>
                        </tr>
                        <tr>
                            <td>
                                Voos Nacionais
                            </td>
                            <td>
                                03 horas antes
                            </td>
                            <td>
                                04 horas antes
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Voos Nacionais partidas (19 a 22 horas)
                            </td>
                            <td>
                                04 horas antes
                            </td>
                            <td>
                                05 horas antes
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Voos Internacionais
                            </td>
                            <td>
                                04 horas antes
                            </td>
                            <td>
                                04 horas antes
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Voos Internacionais partidas (19 a 22 horas)
                            </td>
                            <td>
                                05 horas antes
                            </td>
                            <td>
                                06 horas antes
                            </td>
                        </tr>
                    </table>
                    <table class="table table-striped">
                        <tr>
                            <th>
                                Aeroporto SDU
                            </th>
                            <th>
                                Hotéis Centro e Zona Sul
                            </th>
                            <th>
                                São Conrrado e Barra
                            </th>
                        </tr>
                        <tr>
                            <td>
                                Voos Nacionais
                            </td>
                            <td>
                                02 horas antes
                            </td>
                            <td>
                                03 horas antes
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Voos Nacionais partidas (19 a 22 horas)
                            </td>
                            <td>
                                02 horas antes
                            </td>
                            <td>
                                04 horas antes
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3>
                        Importante! Leia com atenção:</h3>
                </div>
                <div class="panel-body">
                    <ul class="list-group">
                        <li class="list-group-item">Caso o horário informado não se enquadre na regra acima,
                            favor ligar para a agência para remarcar o horário.</li>
                        <li class="list-group-item">Na troca de horário de saída por parte do cliente, a Laira
                            Tours não se responsabiliza por quaisquer problemas que venham a acarretar a perda
                            do vôo.</li>
                        <li class="list-group-item">Em caso de atraso do carro do transfer, favor ligar para
                            o atendimento 24h.</li>
                        <li class="list-group-item">Lembramos que as diárias encerram às 12h; o late check out
                            é uma cortesia do hotel em caso de disponibilidade. Consulte a recepção na manhã
                            do dia de saída sobre a possibilidade desde check out.</li>
                        <li class="list-group-item">Caso não tenha incluso este serviço em seu voucher ou não
                            tenha contratado favor desconsiderar este comunicado.</li>
                        <li class="list-group-item">Não é permitido despachar nas bagagens objetos de valor,
                            tais como: joias, dinheiro, eletrônico, dentre outros.</li>
                        <li class="list-group-item">Pertences transportados no interior do veiculo são de inteira
                            responsabilidade do cliente. Não havendo responsabilidade da empresa no caso de
                            esquecimento.</li>
                    </ul>
                </div>
            </div>
            <!-- / PANEL AVISO-->
            </form>
        </fieldset>
    </div>
</asp:Content>
