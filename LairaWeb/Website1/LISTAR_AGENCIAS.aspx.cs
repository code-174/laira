﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_AGENCIAS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string Codigo = Request.QueryString["Codigo"];

            if (Codigo.Trim().ToString() == "")
            {
                Agencias c = new Agencias();
                grvData.DataSource = c.GetAgencias();
                grvData.DataBind();

            }
            else
            {
                Agencias c = new Agencias();
                grvData.DataSource = c.GetAgenciasByCode(Codigo);
                grvData.DataBind();

            }

        }


    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("CADASTRAR_AGENCIA.aspx");
    }
}