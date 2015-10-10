using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Session["USUARIO_USUARIO"] = "-";
        //  RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (VerificarCampos())
        {
            UsuariosSistema X = new UsuariosSistema();
            string UsuarioExiste = X.UserExists(UserName.Text.Trim(), Password.Text.Trim());


            if (UsuarioExiste != "-")
            {
                Session["USUARIO_USUARIO"] = UserName.Text.Trim();
                Response.Redirect("../MENU_FICHAS.aspx");
            }
            else
            {
                Session["USUARIO_USUARIO"] = "-";
                Response.Write("<script type='text/javascript'>alert('Login inexistente!!!');</script>");

            }
        }

    }

    bool VerificarCampos()
    {
        if (UserName.Text.Trim() == "")
        {
            return false;
        }
        else if (Password.Text.Trim() == "")
        {
            return false;
        }

        return true;
    }
    //protected void lnkVoltar_Click(object sender, EventArgs e)
    //{
    //    RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

    //}
}
