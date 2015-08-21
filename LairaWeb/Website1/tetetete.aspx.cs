using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tetetete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void button_Click(object sender, EventArgs e)
    {
        //txtHello.Visible = true;
    }
    protected void Unnamed1_TextChanged(object sender, EventArgs e)
    {
        boraiso();
    }
    void boraiso()
    {
        txtHello.Visible = true;
    }
}