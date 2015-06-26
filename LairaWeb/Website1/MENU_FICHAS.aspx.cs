using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class MENU_FICHAS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDataRelatorio.Text = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"));
            txtDataFicha.Text = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"));
        }
    }
    protected void btnCadastrarFicha_Click(object sender, EventArgs e)
    {
        Response.Redirect("CADASTRAR_FICHA.aspx");
    }

    protected void lnkListarFichas_Click(object sender, EventArgs e)
    {

        if (optradio1.Checked)
        {
            Response.Redirect("LISTAR_FICHAS.aspx?Codigo=1" + "&Data=" + txtDataFicha.Text);
        }

        else
        {
            Response.Redirect("LISTAR_FICHAS.aspx?Codigo=2" + "&Data=" + txtDataFicha.Text);
        }

    }


    protected void optradio1_CheckedChanged(Object sender, EventArgs e)
    {
        optradio2.Checked = false;

    }
    protected void optradio2_CheckedChanged(Object sender, EventArgs e)
    {
        optradio1.Checked = false;

    }
}