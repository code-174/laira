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
        if (txtCriterio.Text.Trim() != "0")
        {
            if (ddlLocalizar.SelectedValue == "F")
            {
                // TO DO ALTERAR FICHA POR NUMERO DA FICHA
                Response.Redirect("ALTERAR_FICHA.aspx?FichaNo=" + txtCriterio.Text);
            }

            else
            {
                // TO DO ALTERAR FICHA POR CODIGO DA EXCURSAO
                //Response.Redirect("LISTAR_FICHAS.aspx?Codigo=6" + "&Data=" + txtChave.Text);
            }
        }
        else
        {
            //MSG: PLEASE INSERT A NUMBER
        }
        

    }

    

}