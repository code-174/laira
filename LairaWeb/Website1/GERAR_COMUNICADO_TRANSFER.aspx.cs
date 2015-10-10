using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Threading;

public partial class GERAR_COMUNICADO_TRANSFER : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtData.Text = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"));
            //string DataOS;
            //DataOS = txtData.Text;
            //LoadGrid(DataOS);
        }
    }

    private void LoadGrid(string strCriterio, string strTipo)
    {
        GridView1.DataSource = FichasListagem.GetFichasTransferOut(strCriterio, strTipo);
        GridView1.DataBind();
    }


    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        if (txtCriterio.Text != "")
        {
            string strTipo = ddlSelecione.SelectedValue;
            string strCriterio = txtCriterio.Text.Trim();
            if (strTipo == "D")
            {
                LoadGrid(strCriterio, strTipo);
                GridView1.Visible = true;
                EmailSentTo.Visible = false;
            }
            else
            {
                double Num;
                bool isNum = double.TryParse(strCriterio, out Num);
                if (isNum)
                {
                    LoadGrid(strCriterio, strTipo);
                    GridView1.Visible = true;
                    EmailSentTo.Visible = false;
                }
            }
        }


    }
    protected void lnkSelecionarTodas_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];
            ((CheckBox)row.FindControl("chkSelect")).Checked = true;
        }
    }
    protected void lnkEnviarEmail_Click(object sender, EventArgs e)
    {
        // TO DO
        string SendTo = "";

        try
        {
            StringBuilder Hoteis = new StringBuilder();
            bool enviou = false;
            int i = 0;
            int? j = 0;
            //loop through grid
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("chkSelect")).Checked)
                {
                    string Hora = row.Cells[1].Text;
                    string Ficha = row.Cells[5].Text;
                    string Hospedes = row.Cells[7].Text;
                    string Hotel = row.Cells[8].Text;
                    string Apto = row.Cells[9].Text;
                    string Data = GridView1.DataKeys[row.RowIndex].Value.ToString();



                    Hoteis x = new Hoteis();
                    SendTo = x.GetEmailHotelByFicha(Ficha);
                    SendMail(SendTo, Ficha, Hora, Hotel, Apto, Hospedes, Data);
                    Hoteis.AppendLine(Hotel + "\n");
                    enviou = true;
                }
            }
            if (enviou)
            {
                //Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('E-mail enviado com sucesso!');</script>", false);
                GridView1.Visible = false;
                EmailSentTo.Visible = true;
                EmailSentTo.Text = Hoteis.ToString();
            }

        }
        catch
        {
            Response.Write("<script type='text/javascript'>alert('Erro ao submeter transação!');</script>");
        }

    }

    void SendMail(string SendTo, string Ficha, string Hora, string Hotel, string Apto, string Hospedes, string Data)
    {

        var fromAddress = new MailAddress("tourslaira@gmail.com", "Laira Tours");

        // Read the file and display it line by line.
        Security x = new Security();
        string fromPassword = x.Password;
        var toAddress = new MailAddress(SendTo, SendTo);

        string subject = "Laira Tours - Comunicado de Transfer Out";
        string body = "<h1>";

        string titulo = "";
        string subTitulo = "";
        string abrirsite = "";
        StringBuilder texto = new StringBuilder();

        texto.AppendLine("<html>");
        texto.AppendLine("<body>");
        texto.AppendLine("<div class=\"container-fluid\">");
        texto.AppendLine("<fieldset> ");
        texto.AppendLine("<form id=\"Form2\" class=\"form col-md-7\" runat=\"server\"> ");
        texto.AppendLine(" <div class=\"panel panel-default\"> ");
        texto.AppendLine(" <div class=\"panel-body\"> ");
        texto.AppendLine(" <div class=\"text-center\"> ");
        texto.AppendLine(" <h2> ");
        texto.AppendLine(" <span class=\"label label-default\">Comunicado de Transfer out</span></h2> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" <div class=\"form-group col-md-12\"> ");
        texto.AppendLine(" <label for=\"txtHotel\" class=\"control-label\"> ");
        texto.AppendLine(" Hotel</label> ");
        texto.AppendLine(" <div> ");
        texto.AppendLine(" <asp:TextBox ID=\"txtHotel\" runat=\"server\" TextMode=\"MultiLine\" class=\"form-control\">" + Hotel + "</asp:TextBox> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" <div class=\"form-group\"> ");
        texto.AppendLine(" <div class=\"col-md-8\"> ");
        texto.AppendLine(" <h3> ");
        texto.AppendLine(" <span class=\"label label-default\">Comunicado para o hóspede</span></h3> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" <div class=\"col-md-4\"> ");
        texto.AppendLine(" <h3> ");
        texto.AppendLine(" <span class=\"label label-default\">Apartamento</span></h3> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" <div class=\"col-md-8\"> ");
        texto.AppendLine(" <asp:TextBox ID=\"txtPax\" runat=\"server\" TextMode=\"MultiLine\" class=\"form-control\">" + Hospedes + "</asp:TextBox> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine("<div class=\"col-md-4\"> ");
        texto.AppendLine(" <asp:TextBox ID=\"TextBox1\" runat=\"server\" class=\"form-control\">" + Apto + "</asp:TextBox> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" <div class=\"panel panel-default\"> ");
        texto.AppendLine(" <div class=\"panel-body\"> ");
        texto.AppendLine(" <div class=\"col-md-12\"> ");
        texto.AppendLine(" <strong> ");
        texto.AppendLine(" Comunicamos que o traslado dos Srs. será no dia ");
        texto.AppendLine(" <asp:TextBox ID=\"txtData\" runat=\"server\" class=\"form-control\">" + Data +"</asp:TextBox>");
        texto.AppendLine(" , às <asp:TextBox ID=\"txtHora\" runat=\"server\" class=\"form-control\">" + Hora + "</asp:TextBox>");
        texto.AppendLine(" . Favor aguardar na recepção do hotel. Em caso de dúvidas ou discordâncias de horários de ");
        texto.AppendLine(" transfer com relação ao horário do vôo impresso em seu voucher, favor chamar: Horário ");
        texto.AppendLine(" comercial : (21) 2577-6678 ou 24h : (21) 98304-1000 / (21) 97675-0117 ");
        texto.AppendLine(" </strong> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" <div class=\"panel-footer text-center\"> ");
        texto.AppendLine(" <strong>A Laira Tours não está autorizada a trocar vôos, prevalecendo sempre o vôo e ");
        texto.AppendLine(" horário impressos no voucher da sua operadora. </strong> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" <!-- / PANEL HOSPEDE--> ");
        texto.AppendLine(" <div class=\"panel panel-default\"> ");
        texto.AppendLine(" <div class=\"panel-body\"> ");
        texto.AppendLine(" <table style=\"width:100%\" class=\"table table-striped\"> ");
        texto.AppendLine(" <tr> ");
        texto.AppendLine(" <th> ");
        texto.AppendLine(" Aeroporto Galeão ");
        texto.AppendLine(" </th> ");
        texto.AppendLine(" <th> ");
        texto.AppendLine(" Hotéis Centro e Zona Sul ");
        texto.AppendLine(" </th> ");
        texto.AppendLine(" <th> ");
        texto.AppendLine(" São Conrrado e Barra ");
        texto.AppendLine(" </th> ");
        texto.AppendLine(" </tr> ");
        texto.AppendLine(" <tr> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" Voos Nacionais ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" 03 horas antes ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" 04 horas antes ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" </tr> ");
        texto.AppendLine(" <tr> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" Voos Nacionais partidas (19 a 22 horas) ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" 04 horas antes ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" 05 horas antes ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" </tr> ");
        texto.AppendLine(" <tr> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" Voos Internacionais ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" 04 horas antes ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" 04 horas antes ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" </tr> ");
        texto.AppendLine(" <tr> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" Voos Internacionais partidas (19 a 22 horas) ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" 05 horas antes ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" 06 horas antes ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" </tr> ");
        //texto.AppendLine(" </table> ");
        //texto.AppendLine(" <table class=\"table table-striped\"> ");
        texto.AppendLine(" <tr> ");
        texto.AppendLine(" <th> ");
        texto.AppendLine(" Aeroporto SDU ");
        texto.AppendLine(" </th> ");
        texto.AppendLine(" <th> ");
        texto.AppendLine(" Hotéis Centro e Zona Sul ");
        texto.AppendLine(" </th> ");
        texto.AppendLine(" <th> ");
        texto.AppendLine(" São Conrrado e Barra ");
        texto.AppendLine(" </th> ");
        texto.AppendLine(" </tr> ");
        texto.AppendLine(" <tr> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" Voos Nacionais ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" 02 horas antes ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" 03 horas antes ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" </tr> ");
        texto.AppendLine(" <tr> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" Voos Nacionais partidas (19 a 22 horas) ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" 02 horas antes ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" <td> ");
        texto.AppendLine(" 04 horas antes ");
        texto.AppendLine(" </td> ");
        texto.AppendLine(" </tr> ");
        texto.AppendLine(" </table> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" <div class=\"panel panel-default\"> ");
        texto.AppendLine(" <div class=\"panel-heading\"> ");
        texto.AppendLine(" <h3> ");
        texto.AppendLine(" Importante! Leia com atenção:</h3> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" <div class=\"panel-body\"> ");
        texto.AppendLine(" <ul class=\"list-group\"> ");
        texto.AppendLine(" <li class=\"list-group-item\">Caso o horário informado não se enquadre na regra acima, ");
        texto.AppendLine(" favor ligar para a agência para remarcar o horário.</li> ");
        texto.AppendLine(" <li class=\"list-group-item\">Na troca de horário de saída por parte do cliente, a Laira ");
        texto.AppendLine(" Tours não se responsabiliza por quaisquer problemas que venham a acarretar a perda ");
        texto.AppendLine(" do vôo.</li> ");
        texto.AppendLine(" <li class=\"list-group-item\">Em caso de atraso do carro do transfer, favor ligar para ");
        texto.AppendLine(" o atendimento 24h.</li> ");
        texto.AppendLine(" <li class=\"list-group-item\">Lembramos que as diárias encerram às 12h; o late check out ");
        texto.AppendLine(" é uma cortesia do hotel em caso de disponibilidade. Consulte a recepção na manhã ");
        texto.AppendLine(" do dia de saída sobre a possibilidade desde check out.</li> ");
        texto.AppendLine(" <li class=\"list-group-item\">Caso não tenha incluso este serviço em seu voucher ou não ");
        texto.AppendLine(" tenha contratado favor desconsiderar este comunicado.</li> ");
        texto.AppendLine(" <li class=\"list-group-item\">Não é permitido despachar nas bagagens objetos de valor, ");
        texto.AppendLine(" tais como: joias, dinheiro, eletrônico, dentre outros.</li> ");
        texto.AppendLine(" <li class=\"list-group-item\">Pertences transportados no interior do veiculo são de inteira ");
        texto.AppendLine(" responsabilidade do cliente. Não havendo responsabilidade da empresa no caso de ");
        texto.AppendLine(" esquecimento.</li> ");
        texto.AppendLine(" </ul> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" <!-- / PANEL AVISO--> ");
        texto.AppendLine(" </form> ");
        texto.AppendLine(" </fieldset> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" </html> ");
        texto.AppendLine(" <body> ");

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com", //example smtp 
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            Timeout = 20000
        };


        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Priority = MailPriority.High,
            IsBodyHtml = true,
            Subject = subject,
            Body = body + titulo + "</h1>" + subTitulo + "<br/>" + texto + "<br/><br/>" + abrirsite
        })
        {
            message.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
            message.IsBodyHtml = true;
            message.Bcc.Add(SendTo);
            AlternateView plainView = AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(body, @"<(.|\n)*?>", string.Empty), null, "text/plain");
            System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            smtp.Send(message);
        }


    }

    public class Security
    {
        private string strPassword = "ultron123"; //
        public string Password
        {
            get { return strPassword; }
        }
    }
}