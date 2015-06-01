using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_FORMAS_PAGAMENTO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FormasPagamento c = new FormasPagamento();
        grvData.DataSource = c.GetFormasPagamento();
        grvData.DataBind();
    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CADASTRAR_FORMA_PAGAMENTO.aspx");
    }
}