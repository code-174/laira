﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LAYOUT_COMUNICADO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //agni
        string strFicha = Request.QueryString["Ficha"];
        if (!IsPostBack)
        {

            List<FichasListagem> l = Fichas.GetFichaInfo(strFicha);

            foreach (var item in l)
            {
                txtData.Text = l[0].DATA;
                txtHora.Text = l[0].HORA;
                txtHotel.Text = l[0].HOTEL;
                txtPax.Text = l[0].PAX;
                txtTour.Text = l[0].PASSEIO;
            }

        }

    }
}