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
        Agencias c = new Agencias();
        grvData.DataSource = c.GetAgencias();
        grvData.DataBind();
    }
}