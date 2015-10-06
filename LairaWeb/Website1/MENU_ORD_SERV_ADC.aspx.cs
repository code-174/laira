using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class MENU_ORD_SERV_ADC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtData.Text = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"));
            LoadCombos();
        }
    }
    void LoadCombos()
    {
        // POPULATE PRESTADOR DROP DOWN LIST
        Prestadores c = new Prestadores();
        List<Prestadores> details = c.GetPrestadoresCombo();
        ddlPrestador.DataTextField = "NOME";
        ddlPrestador.DataValueField = "ID";
        ddlPrestador.DataSource = details;
        ddlPrestador.DataBind();
    }
    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        if (txtData.Text != "")
        {
            if (ddlSelecione.SelectedValue == "G")
            {
                Response.Redirect("GERAR_ORDEM_SERV_ADC.aspx?&Data=" + txtData.Text);
            }
            else
            {
                Response.Redirect("RELATORIO_OS_ADC.aspx?&Data=" + txtData.Text + "&ReportType=DateRpt");
            }
            
        }

    }
 
    protected void lnkRelatorioPrestador_Click(object sender, EventArgs e)
    {
        if (txtDataInicio.Text.Trim() != "")
        {
            string strDataIni = txtDataInicio.Text.Trim();
            if (txtDataFim.Text == "")
            {
                string strDataFin = strDataIni;
                Response.Redirect("RELATORIO_OS_ADC.aspx?DataIni=" + strDataIni + "&DataFin=" + strDataFin + "&Passeio=0" + "&Prestador=" + ddlPrestador.SelectedValue + "&Vendedor=0" + "&ReportType=FilterRpt");
            }
            else
            {
                string strDataFin = txtDataFim.Text.Trim();
                Response.Redirect("RELATORIO_OS_ADC.aspx?DataIni=" + strDataIni + "&DataFin=" + strDataFin + "&Passeio=0" + "&Prestador=" + ddlPrestador.SelectedValue + "&Vendedor=0" + "&ReportType=FilterRpt");
            }
        }
    }
    
    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {        
        if (txtOSNo.Text != "")
        {
            string strOSNo = txtOSNo.Text.Trim();
            double Num;
            bool isNum = double.TryParse(strOSNo, out Num);
            if (isNum)
            {
                Response.Redirect("RELATORIO_OS_ADC.aspx?OSNo=" + strOSNo + "&ReportType=NumberRpt");
            }
            else
            {
                // mesage box "you gotta put only numbers"
                // no records found asp gridview
            }
        }
    }
   
}