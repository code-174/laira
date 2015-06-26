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
      //  RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (VerificarCampos())
        {
            Response.Redirect("../MENU_FICHAS.aspx");
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
