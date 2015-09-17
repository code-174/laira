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
                string DataOSAdc = Request.QueryString["Data"];
                GridReportDate(DataOSAdc);                
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
                string OSAdcNo = Request.QueryString["OSAdcNo"];
                GridReportNumber(OSAdcNo);
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

    private void GridReportDate(string DataOSAdc)
    {
        GridView1.DataSource = OrdemServAdc.GetOSAdc(DataOSAdc);
        GridView1.DataBind();
    }

    private void GridReportFilter(string DataIni, string DataFin, string Passeio, string Prestador, string Vendedor)
    {
        GridView1.DataSource = FichasOSAdc.FiltroOSAdc(DataIni, DataFin, Passeio, Prestador, Vendedor);
        GridView1.DataBind();
    }

    private void GridReportNumber(string OSAdcNo)
    {
        GridView1.DataSource = OrdemServAdc.GetOSAdc(OSAdcNo);
        GridView1.DataBind();
    }

    bool VerificarCampos()
    {
        if (txtDataInicio.Text.Trim() == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        if (VerificarCampos())
        {
            string strDataIni = txtDataInicio.Text.Trim();
            if (txtDataFim.Text == "")
            {
                string strDataFin = strDataIni;
                Response.Redirect("RELATORIO_OS_ADC.aspx?DataIni=" + strDataIni + "&DataFin=" + strDataFin + "&Passeio=" + ddlPasseio.SelectedValue + "&Prestador=" + ddlPrestador.SelectedValue + "&Vendedor=" + ddlVendedor.SelectedValue + "&ReportType=FilterRpt");
            }
            else
            {
                string strDataFin = txtDataFim.Text.Trim();
                Response.Redirect("RELATORIO_OS_ADC.aspx?DataIni=" + strDataIni + "&DataFin=" + strDataFin + "&Passeio=" + ddlPasseio.SelectedValue + "&Prestador=" + ddlPrestador.SelectedValue + "&Vendedor=" + ddlVendedor.SelectedValue + "&ReportType=FilterRpt");
            }
        }
    }

    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {

    }
}