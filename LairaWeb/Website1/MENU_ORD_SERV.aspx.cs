using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class MENU_ORD_SERV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDataRelatorio.Text = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"));            
        }

    }
    protected void optChegadaOS_CheckedChanged(Object sender, EventArgs e)
    {
        optSaidaOS.Checked = false;

    }
    protected void optSaidaOS_CheckedChanged(Object sender, EventArgs e)
    {
        optChegadaOS.Checked = false;

    }
    protected void optTodas_CheckedChanged(Object sender, EventArgs e)
    {
        optNaoImpressas.Checked = false;
        optOSNo.Checked = false;

    }
    protected void optNaoImpressas_CheckedChanged(Object sender, EventArgs e)
    {
        optTodas.Checked = false;
        optOSNo.Checked = false;

    }
    protected void optOSNo_CheckedChanged(Object sender, EventArgs e)
    {
        optTodas.Checked = false;
        optNaoImpressas.Checked = false;

    }
    protected void lnkGerarOS_Click(object sender, EventArgs e)
    {
        Response.Redirect("GERAR_ORDEM_SERV.aspx");
        //Response.Redirect("LISTAR_ORDEM_SERV.aspx?Codigo=5" + "&Data=" + txtChave.Text);
    }
    protected void lnkRelatorios_Click(object sender, EventArgs e)
    {

        //if (optChegada.Checked)
        //{
        //    Response.Redirect("LISTAR_FICHAS.aspx?Codigo=3" + "&Data=" + txtDataRelatorio.Text);
        //}

        //else
        //{
        //    Response.Redirect("LISTAR_FICHAS.aspx?Codigo=4" + "&Data=" + txtDataRelatorio.Text);
        //}

    }
    protected void lnkConsultar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("LISTAR_ORDEM_SERV.aspx?Codigo=5" + "&Data=" + txtChave.Text);
    }
}