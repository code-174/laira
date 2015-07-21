using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_AEROPORTOS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Filtro = Request.QueryString["Filtro"];

            if (Filtro.Trim().ToString() == "")
            {
                Aeroportos c = new Aeroportos();
                grvData.DataSource = c.GetAeroportos();
                grvData.DataBind();
            }
            else
            {
                Aeroportos c = new Aeroportos();
                grvData.DataSource = c.GetAeroportosByCode(Filtro);
                grvData.DataBind();
            }
        }
    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CADASTRAR_AEROPORTO.aspx");
    }
    protected void lnkVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_ADMINISTRACAO.aspx");
    }
    protected void lnkFiltrar_Click(object sender, EventArgs e)
    {
        string Filtro = txtFiltro.Text;
        Aeroportos c = new Aeroportos();
        grvData.DataSource = c.GetAeroportosByCode(Filtro);
        grvData.DataBind();
    }
}