using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MENU_FINANCEIRO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void optBaixar_CheckedChanged(Object sender, EventArgs e)
    {        
        optRelatorio.Checked = false;
        optImprimir.Checked = false;

    }
    protected void optRelatorio_CheckedChanged(Object sender, EventArgs e)
    {
        optBaixar.Checked = false;
        optImprimir.Checked = false;

    }
    protected void optImprimir_CheckedChanged(Object sender, EventArgs e)
    {
        optBaixar.Checked = false;
        optRelatorio.Checked = false;
    }
    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("LISTAR_ORDEM_SERV.aspx?Codigo=5" + "&Data=" + txtChave.Text);
    }
    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("LISTAR_ORDEM_SERV.aspx?Codigo=5" + "&Data=" + txtChave.Text);
    }
}