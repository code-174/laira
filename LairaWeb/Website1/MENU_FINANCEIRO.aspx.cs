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
        string strDataIni = txtDataInicio.Text.Trim();
        string strDataFin = txtDataFim.Text.Trim();
        bool DataOk = false;
        if (CheckData(strDataIni))
        {
            if (string.IsNullOrEmpty(strDataFin))
            {
                strDataFin = strDataIni;
                DataOk = true;
            }
            else if (!CheckData(strDataFin))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('Favor preencher o campo data Até corretamente.');</script>", false);
                DataOk = false;
            }
            else
            {
                DataOk = true;
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('Favor preencher o campo data De corretamente.');</script>", false);
        }

        if (DataOk)
        {
            if (ddlSelecione.SelectedValue == "B")
            {
                Response.Redirect("FATURA_BAIXAR.aspx?DataIni=" + strDataIni + "&DataFin=" + strDataFin + "&Tipo=" + ddlTipo.SelectedValue.ToString().Substring(0) + "&Agencia=" + ddlAgencia.SelectedValue.ToString().Substring(0));
            }
            else if (ddlSelecione.SelectedValue == "R")
            {
                Response.Redirect("FATURA_RELATORIO.aspx?DataIni=" + strDataIni + "&DataFin=" + strDataFin + "&Tipo=" + ddlTipo.SelectedValue.ToString().Substring(0) + "&Agencia=" + ddlAgencia.SelectedValue.ToString().Substring(0));
            }
            else if (ddlSelecione.SelectedValue == "I")
            {
                Response.Redirect("FATURA_IMPRIMIR.aspx?DataIni=" + strDataIni + "&DataFin=" + strDataFin + "&Tipo=" + ddlTipo.SelectedValue.ToString().Substring(0) + "&Agencia=" + ddlAgencia.SelectedValue.ToString().Substring(0));
            }
        }

    }

    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("LISTAR_ORDEM_SERV.aspx?Codigo=5" + "&Data=" + txtChave.Text);
    }

    bool CheckData(string strData)
    {
        if (!string.IsNullOrEmpty(strData))
        {
            DateTime temp;
            if (DateTime.TryParse(strData, out temp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}