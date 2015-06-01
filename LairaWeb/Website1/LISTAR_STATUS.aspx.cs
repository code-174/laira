using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_STATUS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Status c = new Status();
        grvData.DataSource = c.GetStatus();
        grvData.DataBind();

    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CADASTRAR_STATUS.aspx");
    }
}