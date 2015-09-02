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
                Response.Redirect("RELATORIO_OS_ADC.aspx?&Data=" + txtData.Text);
            }
            
        }

    }
 
    protected void lnkRelatorioPrestador_Click(object sender, EventArgs e)
    {
        //Response.Redirect("LISTAR_ORDEM_SERV.aspx?Codigo=5" + "&Data=" + txtDataInicio.Text);
    }
    protected void lnkConsultar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("LISTAR_ORDEM_SERV.aspx?Codigo=5" + "&Data=" + txtChave.Text);
    }
}