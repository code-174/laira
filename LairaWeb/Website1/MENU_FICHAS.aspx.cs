using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class MENU_FICHAS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            //txtDataRelatorio.Text = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"));
            //txtDataFicha.Text = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"));
        }
    }
    protected void btnCadastrarFicha_Click(object sender, EventArgs e)
    {
        Response.Redirect("CADASTRAR_FICHA.aspx");
    }

    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        if (ddlSelecione.SelectedValue == "L")
        {            
            Response.Redirect("LISTAR_FICHAS.aspx?Tipo=" + ddlTipo.SelectedValue + "&Data=" + txtData.Text);
        }

        else
        {
            Response.Redirect("RELATORIO_FICHAS.aspx?Tipo=" + ddlTipo.SelectedValue + "&Data=" + txtData.Text);
        }

    }
   
    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {
        bool ValidTextbox = false;
        string TextCheck = txtCriterio.Text.Trim();
        double Num;
        bool isNum = double.TryParse(TextCheck, out Num);

        if (!string.IsNullOrEmpty(txtCriterio.Text) && isNum)
        {
            ValidTextbox = true;
        }
        else
        {
            ValidTextbox = false;            
        }

        if (ValidTextbox)
        {
            if (ddlLocalizar.SelectedValue == "F")
            {
                Response.Redirect("ALTERAR_FICHA.aspx?Criterio=" + txtCriterio.Text + "&Tipo=F");
            }

            else
            {
                Response.Redirect("ALTERAR_FICHA.aspx?Criterio=" + txtCriterio.Text + "&Tipo=C");
            }
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('Favor preencher o campo somente com números');</script>", false);
        }      

    }

    

}