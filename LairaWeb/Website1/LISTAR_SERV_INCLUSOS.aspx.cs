﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_SERV_INCLUSOS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ServInclusos c = new ServInclusos();
        grvData.DataSource = c.GetServInclusos();
        grvData.DataBind();
    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CADASTRAR_SERV_INCLUSO.aspx");
    }
    protected void lnkVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_ADMINISTRACAO.aspx");
    }
    protected void lnkFiltrar_Click(object sender, EventArgs e)
    {
        // TO DO
    }
}