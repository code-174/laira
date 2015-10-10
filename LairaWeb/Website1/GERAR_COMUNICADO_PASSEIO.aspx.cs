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


public partial class GERAR_COMUNICADO_PASSEIO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCombos();
        }

        //if (Session["USUARIO_USUARIO"].ToString() != "-")
        //{

        //    if (!IsPostBack)
        //    {
        //        LoadCombos();
        //    }
        //}
        //else
        //{
        //    Response.Redirect("Logout.aspx");
        //}

    }
    void LoadCombos()
    {
        // POPULATE PASSEIO DROP DOWN LIST
        ServAdc p = new ServAdc();
        List<ServAdc> detailsPasseio = p.GetServAdcCombo();
        ddlPasseio.DataTextField = "PASSEIO";
        ddlPasseio.DataValueField = "ID";
        ddlPasseio.DataSource = detailsPasseio;
        ddlPasseio.DataBind();

        // POPULATE PRESTADOR DROP DOWN LIST
        Prestadores prest = new Prestadores();
        List<Prestadores> detailsPrest = prest.GetPrestadoresCombo();
        ddlPrestador.DataTextField = "NOME";
        ddlPrestador.DataValueField = "ID";
        ddlPrestador.DataSource = detailsPrest;
        ddlPrestador.DataBind();

        // POPULATE VENDEDOR DROP DOWN LIST
        Vendedores vend = new Vendedores();
        List<Vendedores> detailsVend = vend.GetVendedoresCombo();
        ddlVendedor.DataTextField = "NOME";
        ddlVendedor.DataValueField = "ID";
        ddlVendedor.DataSource = detailsVend;
        ddlVendedor.DataBind();

    }

    private void LoadGrid(string strData, string Passeio, string Prestador, string Vendedor)
    {
        GridView1.DataSource = FichasListagem.GetFiltroFichasPasseio(strData, Passeio, Prestador, Vendedor);
        GridView1.DataBind();
        GridView1.Visible = true;
        EmailSentTo.Visible = false;
    }
    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        if (txtData.Text != "")
        {
            string strData = txtData.Text.Trim();
            string Passeio = ddlPasseio.SelectedValue;
            string Prestador = ddlPrestador.SelectedValue;
            string Vendedor = ddlVendedor.SelectedValue;
            LoadGrid(strData, Passeio, Prestador, Vendedor);
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

                    string Ficha = row.Cells[1].Text;
                    string Hora = row.Cells[2].Text;
                    string Hotel = row.Cells[3].Text;
                    string Apto = row.Cells[4].Text;
                    string Tour = row.Cells[5].Text;
                    string Hospedes = row.Cells[7].Text;
                    string Data = txtData.Text;


                    Hoteis x = new Hoteis();
                    SendTo = x.GetEmailHotelByFicha(Ficha);
                    SendMail(SendTo, Ficha, Hora, Hotel, Apto, Tour, Hospedes, Data);
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

    void SendMail(string SendTo, string Ficha, string Hora, string Hotel, string Apto, string Tour, string Hospedes, string Data)
    {

        var fromAddress = new MailAddress("tourslaira@gmail.com", "Laira Tours");

        // Read the file and display it line by line.
        Security x = new Security();
        string fromPassword = x.Password;
        var toAddress = new MailAddress(SendTo, SendTo);

        string subject = "Laira Tours - Comunicado de Passeio";
        string body = "<h1>";

        string titulo = "";
        string subTitulo = "";
        string abrirsite = "";
        StringBuilder texto = new StringBuilder();

        //<div class="container-fluid">
        texto.AppendLine("<html>");
        //texto.AppendLine("<head><link href=\"//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css\" rel=\"stylesheet\"></head>");
        texto.AppendLine(" <body>");
        texto.AppendLine(" <div class=\"container-fluid\">");
        texto.AppendLine(" <fieldset> ");
        texto.AppendLine(" <form id=\"Form2\" class=\"form col-md-7\" runat=\"server\"> ");
        texto.AppendLine(" <div class=\"panel panel-default\"> ");
        texto.AppendLine(" <div class=\"panel-body\"> ");
        texto.AppendLine(" <div class=\"text-center\"> ");
        texto.AppendLine(" <h2> ");
        texto.AppendLine(" <span style=\"color:black;\">Comunicado de Passeio</span></h2> ");
        texto.AppendLine(" </div>   ");
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
        texto.AppendLine(" <div class=\"col-md-4\"> ");
        texto.AppendLine(" <asp:TextBox ID=\"TextBox1\" runat=\"server\" class=\"form-control\">" + Apto + "</asp:TextBox> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" </div> ");
        texto.AppendLine(" <div class=\"panel panel-default\">");
        texto.AppendLine(" <div class=\"panel-body\">");
        texto.AppendLine(" <div class=\"col-md-12\">");
        texto.AppendLine(" <h5>");
        texto.AppendLine(" A <strong>Laira Tours</strong> agradece a preferência pela escolha da nossa empresa.");
        texto.AppendLine(" Aproveitamos, através deste, para confirmar sua reserva à bordo do tour:");
        texto.AppendLine(" </h5>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" <div class=\"form-group col-md-12\">");
        texto.AppendLine(" <label for=\"txtTour\" class=\"control-label\">");
        texto.AppendLine(" Tour</label>");
        texto.AppendLine(" <div>");
        texto.AppendLine(" <asp:TextBox ID=\"txtTour\" runat=\"server\" TextMode=\"MultiLine\" class=\"form-control\">" + Tour + "</asp:TextBox>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" <div class=\"form-group\">");
        texto.AppendLine(" <div class=\"form-group col-md-6\">");
        texto.AppendLine(" <label for=\"txtHotel\" class=\"control-label\">");
        texto.AppendLine(" Hotel</label>");
        texto.AppendLine(" <asp:TextBox ID=\"txtHotel\" runat=\"server\" TextMode=\"MultiLine\" class=\"form-control\">" + Hotel + "</asp:TextBox>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" <div class=\"form-group col-md-3\">");
        texto.AppendLine(" <label for=\"txtData\" class=\"control-label\">");
        texto.AppendLine(" Data / Date</label>");
        texto.AppendLine(" <asp:TextBox ID=\"txtData\" runat=\"server\" class=\"form-control\">" + Data + "</asp:TextBox>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" <div class=\"form-group col-md-3\">");
        texto.AppendLine(" <label for=\"txtHora\" class=\"control-label\">");
        texto.AppendLine(" Hora / Time</label>");
        texto.AppendLine(" <asp:TextBox ID=\"txtHora\" runat=\"server\" class=\"form-control\">" + Hora + "</asp:TextBox>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" <div class=\"panel panel-default\">");
        texto.AppendLine(" <div class=\"panel-heading\">");
        texto.AppendLine(" <h3>");
        texto.AppendLine(" Importante! Leia com atenção:</h3>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" <div class=\"panel-body\">");
        texto.AppendLine(" <!-- List");
        texto.AppendLine(" group -->");
        texto.AppendLine(" <ul class=\"list-group\">");
        texto.AppendLine(" <li class=\"list-group-item\">Solicitamos que aguarde na recepção do hotel. Nossos guias");
        texto.AppendLine(" não procuram nos apartamentos nem nos restaurantes. Em caso de atraso dos mesmos,");
        texto.AppendLine(" favor entrar em contato conosco o mais rapidamente possível.</li>");
        texto.AppendLine(" <li class=\"list-group-item\">Nenhum dos passeios dentro da cidade do Rio de Janeiro inclui");
        texto.AppendLine(" ingresso ou refeição. Estes devem ser adquiridos pelo próprio cliente.</li>");
        texto.AppendLine(" <li class=\"list-group-item\">Todos os passeios são realizados independentemente das condições");
        texto.AppendLine(" climáticas, exceto aqueles que dependem de condições de navegação. Uma vez embarcado");
        texto.AppendLine(" não há direito a devolução de valores. Quando não houver possibilidade de navegação");
        texto.AppendLine(" o cliente será restituido do valor do passeio da escuna negociado com o a empresa");
        texto.AppendLine(" prestadora.</li>");
        texto.AppendLine(" <li class=\"list-group-item\">Em caso de não embarque, será considerado \"no show\", não");
        texto.AppendLine(" havendo remarcação do passeio e/ou devolução de valores pagos. Quando incluso no");
        texto.AppendLine(" voucher de pacotes das operadoras.</li>");
        texto.AppendLine(" <li class=\"list-group-item\">Por se tratar de serviços regulares (serviços compartilhados");
        texto.AppendLine(" com outras pessoas) os horários acima informados são estimados de embarque, portanto");
        texto.AppendLine(" sujeitos a atrasos de trânsito e/ou de embarque de clientes comuns a este serviço.</li>");
        texto.AppendLine(" <li class=\"list-group-item\">Os contraentes elegem o Foro da cidade do Rio de Janeiro");
        texto.AppendLine(" como competente para soluciona os litígios que resultadres deste contrato.</li>");
        texto.AppendLine(" <li class=\"list-group-item\">Este não é válido como recibo e/ou voucher de serviço.</li>");
        texto.AppendLine(" </ul>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" <div class=\"panel-footer");
        texto.AppendLine(" text-center\">");
        texto.AppendLine(" <strong>Em caso de dúvidas, estamos à sua inteira disposição através dos telefones:<br />");
        texto.AppendLine(" Horário comercial: (21) 2577-6678 ou 24h: (21) 98304-1000 / (21) 97675-0117");
        texto.AppendLine(" </strong>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" <div class=\"col-md-6\">");
        texto.AppendLine(" <h4>");
        texto.AppendLine(" É um grande prazer tê-lo à bordo.<br /> Atenciosamente,</h4>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" </form>");
        texto.AppendLine(" </fieldset>");
        texto.AppendLine(" </div>");
        texto.AppendLine(" </html>");
        texto.AppendLine(" <body>");

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

    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {
        if (txtOSNo.Text != "")
        {
            string strOSNo = txtOSNo.Text.Trim();
            double Num;
            bool isNum = double.TryParse(strOSNo, out Num);
            if (isNum)
            {
                GridView1.DataSource = FichasListagem.GetFichasPasseio(strOSNo);
                GridView1.DataBind();
            }
            else
            {
                // mesage box "you gotta put only numbers"
                // no records found asp gridview
            }
        }
    }
    protected void lnkImprimir_Click(object sender, EventArgs e)
    {
        //agni
        // TO DO
        string SendTo = "";

        try
        {
            int i = 0;
            int? j = 0;
            //loop through grid
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (((CheckBox)row.FindControl("chkSelect")).Checked)
                {
                    System.Threading.Thread.Sleep(100);
                    string Ficha = row.Cells[1].Text;
                    Response.Write("<script>");
                    Response.Write("window.open('LAYOUT_COMUNICADO.aspx?Ficha=" + Ficha + "','_blank')");
                    Response.Write("</script>");

                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        catch
        {
            Response.Write("<script type='text/javascript'>alert('Erro ao submeter transação!');</script>");
        }
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