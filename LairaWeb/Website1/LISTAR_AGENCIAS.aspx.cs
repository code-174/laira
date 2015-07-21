using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_AGENCIAS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string Filtro = Request.QueryString["Filtro"];

            if (Filtro.Trim().ToString() == "")
            {
                Agencias c = new Agencias();
                grvData.DataSource = c.GetAgencias();
                grvData.DataBind();
            }
            else
            {
                Agencias c = new Agencias();
                grvData.DataSource = c.GetAgenciasByCode(Filtro);
                grvData.DataBind();
            }
        }

    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CADASTRAR_AGENCIA.aspx");
    }
    protected void lnkFiltrar_Click(object sender, EventArgs e)
    {
        // TO DO
    }
    protected void lnkVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_ADMINISTRACAO.aspx");
    }
}