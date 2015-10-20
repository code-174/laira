using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FATURA_RELATORIO : System.Web.UI.Page
{
    private decimal SumValorPag;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCombos();

            string DataIni = Request.QueryString["DataIni"];
            string DataFin = Request.QueryString["DataFin"];
            string Tipo = Request.QueryString["Tipo"];
            string Agencia = Request.QueryString["Agencia"];

            GridFaturas(DataIni, DataFin, Tipo, Agencia);

        }
    }

    void GridFaturas(string DataIni, string DataFin, string Tipo, string Agencia)
    {
        GridView1.DataSource = Faturas.GetFaturas(DataIni, DataFin, Tipo, Agencia);
        GridView1.DataBind();
    }

    void LoadCombos()
    {
        // POPULATE AGENCIAS DROP DOWN LIST
        Agencias c = new Agencias();
        List<Agencias> details = c.GetAgenciasCombo();
        ddlAgencia.DataTextField = "NOME";
        ddlAgencia.DataValueField = "ID";
        ddlAgencia.DataSource = details;
        ddlAgencia.DataBind();
    }

    protected void lnkProcessar_Click(object sender, EventArgs e)
    {

    }
    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SumValorPag += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "VALOR_PAG"));
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            //e.Row.Cells[0].Text = "Total Valor Pag.";
            //e.Row.Cells[0].Font.Bold = true;
            e.Row.Cells[7].Text = SumValorPag.ToString();
            e.Row.Cells[7].Font.Bold = true;
            //SumValorUnitario = 0;
            //e.Row.Cells[9].Visible = false;
            //e.Row.Cells[10].Visible = false;
        }
    }
}