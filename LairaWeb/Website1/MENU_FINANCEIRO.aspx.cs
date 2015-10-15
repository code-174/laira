using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MENU_FINANCEIRO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadCombos();
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
        if (!string.IsNullOrEmpty(txtDataInicio.Text))
        {
            if (ddlSelecione.SelectedValue == "B")
            {
                Response.Redirect("FATURA_BAIXAR.aspx?Criterio=" + txtDataInicio.Text + "&Tipo=F");
            }

            else if (ddlSelecione.SelectedValue == "R")
            {
                
            }
            else if (ddlSelecione.SelectedValue == "I")
            {
                
            }            
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('Favor preencher o campo data');</script>", false);
        }      
    }
    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("LISTAR_ORDEM_SERV.aspx?Codigo=5" + "&Data=" + txtChave.Text);
    }
}