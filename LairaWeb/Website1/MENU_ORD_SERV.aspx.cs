using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class MENU_ORD_SERV : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtDataRelatorio.Text = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"));
        }

    }        
    
    protected void lnkGerarOS_Click(object sender, EventArgs e)
    {
        if (txtDataOS.Text != "")
        {
            Response.Redirect("GERAR_ORDEM_SERV.aspx?Tipo=" + ddlTipoOS.SelectedValue.ToString().Substring(0) + "&Data=" + txtDataOS.Text);
        }

    }
    protected void lnkRelatorios_Click(object sender, EventArgs e)
    {
        //if (txtDataRelatorio.Text != "")        
        if (ddlSelecione.SelectedValue == "T")
        {
            Response.Redirect("RELATORIO_ORDEM_SERVICO.aspx?Tipo=" + ddlTipoRel.SelectedValue.ToString().Substring(0) + "&Data=" + txtDataRelatorio.Text + "&ReportType=DateRpt");
        }
        else
        {
             //TO DO OS NAO IMPRESSAS   
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
                Response.Redirect("RELATORIO_ORDEM_SERVICO.aspx?No=" + OS_NO + "&ReportType=NumberRpt");
            }
            else
            {
                // mesage box "you gotta put only numbers"
                // no records found asp gridview
            }
        }
    }
}