using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MENU_FICHAS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCadastrarFicha_Click(object sender, EventArgs e)
    {
        Response.Redirect("CADASTRAR_FICHA.aspx");
    }
}