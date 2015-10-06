using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RELATORIO_OS_ADC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCombos();

            string ReportType = Request.QueryString["ReportType"];

            if (ReportType == "DateRpt")
            {
                string strCriterio = Request.QueryString["Data"];
                string strTipo = "D";
                GridReport(strCriterio, strTipo);
            }
            else if (ReportType == "FilterRpt")
            {
                string DataIni = Request.QueryString["DataIni"];
                string DataFin = Request.QueryString["DataFin"];
                string Passeio = Request.QueryString["Passeio"];
                string Prestador = Request.QueryString["Prestador"];
                string Vendedor = Request.QueryString["Vendedor"];
                GridReportFilter(DataIni, DataFin, Passeio, Prestador, Vendedor);
            }
            else if (ReportType == "NumberRpt")
            {
                string strCriterio = Request.QueryString["OSNo"];
                string strTipo = "N";
                GridReport(strCriterio, strTipo);
            }

        }
    }

    void LoadCombos()
    {
        // POPULATE PASSEIO DROP DOWN LIST
        ServAdc p = new ServAdc();
        List<ServAdc> detailsPasseio = p.GetServAdcCombo();
        ddlPasseio.DataTextField = "PASSEIO";
        ddlPasseio.DataValueField = "ID";
        ddlPasseio.DataSource = detailsPasseio;
        ddlPasseio.DataBind();

        // POPULATE PRESTADOR DROP DOWN LIST
        Prestadores prest = new Prestadores();
        List<Prestadores> detailsPrest = prest.GetPrestadoresCombo();
        ddlPrestador.DataTextField = "NOME";
        ddlPrestador.DataValueField = "ID";
        ddlPrestador.DataSource = detailsPrest;
        ddlPrestador.DataBind();

        // POPULATE VENDEDOR DROP DOWN LIST
        Vendedores vend = new Vendedores();
        List<Vendedores> detailsVend = vend.GetVendedoresCombo();
        ddlVendedor.DataTextField = "NOME";
        ddlVendedor.DataValueField = "ID";
        ddlVendedor.DataSource = detailsVend;
        ddlVendedor.DataBind();

    }

    private void GridReport(string strCriterio, string strTipo)
    {
        GridView1.DataSource = OrdemServAdc.GetOSAdc(strCriterio, strTipo);
        GridView1.DataBind();
    }

    private void GridReportFilter(string DataIni, string DataFin, string Passeio, string Prestador, string Vendedor)
    {
        GridView1.DataSource = FichasOSAdc.FiltroOSAdc(DataIni, DataFin, Passeio, Prestador, Vendedor);
        GridView1.DataBind();
    }

    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        if (txtDataInicio.Text.Trim() != "")
        {
            string strDataIni = txtDataInicio.Text.Trim();
            string strPasseio = ddlPasseio.SelectedValue;
            string strPrestador = ddlPrestador.SelectedValue;
            string strVendedor = ddlVendedor.SelectedValue;
            string strDataFin = "";

            if (txtDataFim.Text == "")
            {
                strDataFin = strDataIni;
            }
            else
            {
                strDataFin = txtDataFim.Text.Trim();
            }

            GridReportFilter(strDataIni, strDataFin, strPasseio, strPrestador, strVendedor);
        }
    }

    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {
        if (txtOSNo.Text != "")
        {
            string OS_NO = txtOSNo.Text.Trim();
            double Num;
            bool isNum = double.TryParse(OS_NO, out Num);
            if (isNum)
            {
                string strTipo = "N";
                GridReport(OS_NO, strTipo);
            }
            else
            {
                // mesage box "you gotta put only numbers"
                // no records found asp gridview
            }
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AlterarOS")
        {
            int indexRow = Convert.ToInt32(e.CommandArgument);
            string strOSNo = GridView1.DataKeys[indexRow].Value.ToString();

            Response.Redirect("ALTERAR_OS_ADC.aspx?OSNo=" + strOSNo);
        }
    }

    protected void lnkSelectAll_Click(object sender, EventArgs e)
    {
        // TO DO
    }

    protected void lnkVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_ORD_SERV_ADC.aspx");
    }
}