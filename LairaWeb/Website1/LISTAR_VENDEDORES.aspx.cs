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
}