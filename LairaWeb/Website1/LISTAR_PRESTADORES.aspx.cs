﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_PRESTADORES : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Prestadores c = new Prestadores();
        grvData.DataSource = c.GetPrestadores();
        grvData.DataBind();
    }
}