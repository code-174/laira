using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GERAR_FATURA : System.Web.UI.Page
{
    public double SumValorUnitario = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = FichasListagem.GetFichasFatura();
        GridView1.DataBind();
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SumValorUnitario += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PRECO"));
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Total Valor Unit.";
            e.Row.Cells[0].Font.Bold = true;
            e.Row.Cells[1].Text = SumValorUnitario.ToString();
            e.Row.Cells[1].Font.Bold = true;
            SumValorUnitario = 0;
            //e.Row.Cells[9].Visible = false;
            //e.Row.Cells[10].Visible = false;
        }
        

    }

    protected void lnkProcessarCriterios_Click(object sender, EventArgs e)
    {
        //TO DO
    }
}