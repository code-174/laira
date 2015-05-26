using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControls_wucFiltrosFichas : System.Web.UI.UserControl
{
   
    public string txtListarFicha_Text
    {
        get
        {
            return txtListarFicha.Text;
        }
        set
        {
            txtListarFicha.Text = value;
        }
    }
    /// <summary>
    /// Navega para página de Cadastro
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCadastrarFicha_Click(object sender, EventArgs e)
    {
        Response.Redirect("CADASTRAR_FICHA.aspx");
    }




}