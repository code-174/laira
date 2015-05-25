using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_SERV_INCLUSOS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ServInclusos c = new ServInclusos();
        grvData.DataSource = c.GetServInclusos();
        grvData.DataBind();
    }
}