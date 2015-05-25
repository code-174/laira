using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_HOTEIS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Hoteis c = new Hoteis();
        grvData.DataSource = c.GetHoteis();
        grvData.DataBind();
    }
}