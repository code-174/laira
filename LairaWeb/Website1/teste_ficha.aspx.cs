using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class teste_ficha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //FichasRelatorio c = new FichasRelatorio();
        //grvServInFicha.DataSource = c.GetFichasRelatorio();
        //grvServInFicha.DataBind();

        
    }
    protected void grvFicha_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void lnkGerar_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = FichasRelatorio.GetFichasRelatorio();
        GridView1.DataBind();
    }
}