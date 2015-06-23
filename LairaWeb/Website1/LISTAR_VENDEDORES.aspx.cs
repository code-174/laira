using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_VENDEDORES : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Vendedores c = new Vendedores();
        grvData.DataSource = c.GetVendedores();
        grvData.DataBind();

    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CADASTRAR_VENDEDOR.aspx");
    }
    protected void lnkVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_ADMINISTRACAO.aspx");
    }
    protected void lnkFiltrar_Click(object sender, EventArgs e)
    {
        // TO DO
    }
}