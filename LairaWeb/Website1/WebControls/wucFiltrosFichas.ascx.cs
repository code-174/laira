using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebControls_wucFiltrosFichas : System.Web.UI.UserControl
{
    protected System.Web.UI.WebControls.Button btnListarFicha;
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

    private void btnListarFicha1_Click(object sender, System.EventArgs e)
    {
        Response.Write("WebUserControl1 :: Begin Button1_Click <BR>");
        OnBubbleClick(e);
        Response.Write("WebUserControl1 :: End Button1_Click <BR>");
    }

    public event EventHandler BubbleClick;

    protected void OnBubbleClick(EventArgs e)
    {
        if (BubbleClick != null)
        {
            BubbleClick(this, e);
        }
    }


}