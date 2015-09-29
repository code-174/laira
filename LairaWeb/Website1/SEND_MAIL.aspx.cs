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

public partial class SEND_MAIL : System.Web.UI.Page
{

    bool VerificarCampos()
    {

        if (SendTo.Text.Trim() == "")
        {
            return false;
        }

        return true;
    }




    protected void lnkVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_ADMINISTRACAO.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkSendMail_Click(object sender, EventArgs e)
    {


        var fromAddress = new MailAddress("XXX@XX.XXX", "NOME");

        // Read the file and display it line by line.
        Security x = new Security();
        string fromPassword = x.Password;
        var toAddress = new MailAddress(SendTo.Text, SendTo.Text);

        string subject = "Laira Tours - Comunicado de Passeio";
        string body = "<h1>";

        string titulo = "BEM-VINDO";
        string subTitulo = "";
        string abrirsite = "";
        string texto = "Comunicado de Passeio " + " <br>" + " xxxxxxxxxxxxx xxxxxxxxx xxxxxxxxxxx " + " <br>" + " xxxxxxxxxxxxx xxxxxxxxx xxxxxxxxxxx " + " <br>" + " xxxxxxxxxxxxx xxxxxxxxx xxxxxxxxxxx " + " <br>" + " xxxxxxxxxxxxx xxxxxxxxx xxxxxxxxxxx ";

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
            Subject = subject,
            Body = body + titulo + "</h1>" + subTitulo + "<br/>" + texto + "<br/><br/>" + abrirsite
        })
        {
            message.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
            message.IsBodyHtml = true;
            message.Bcc.Add(SendTo.Text);
            AlternateView plainView = AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(body, @"<(.|\n)*?>", string.Empty), null, "text/plain");
            System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            smtp.Send(message);
        }
    }

}

public class Security
{
    private string strPassword = "SENHA"; //
    public string Password
    {
        get { return strPassword; }
    }
}


