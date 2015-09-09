using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_ORDEM_SERV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Tipo = Request.QueryString["Tipo"];
            string Data = Request.QueryString["Data"];

            if (Tipo.Trim().ToString() != "")
            {
                GridView1.DataSource = OrdemServico.GetOS(Tipo, Data);
                GridView1.DataBind();

                //switch (Tipo)
                //{
                //    case "C":
                //        Titulo.InnerText = "Listagem de Fichas de Chegada";
                //        break;
                //    case "S":
                //        Titulo.InnerText = "Listagem de Fichas de Saída";
                //        break;

                //    default:
                //        break;
                //}

                //ddlTipo.SelectedValue = Tipo;

            }
        }
    }

    protected void lnkProcessar_Click(object sender, EventArgs e)
    {

    }

    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {
        if (txtOSNo.Text != "")
        {
            Response.Redirect("RELATORIO_ORDEM_SERVICO.aspx?No=" + txtOSNo.Text);
        }    
    }
}