using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_VOOS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Voos c = new Voos();
        grvData.DataSource = c.GetVoos();
        grvData.DataBind();
    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CADASTRAR_VOO.aspx");
    }
}