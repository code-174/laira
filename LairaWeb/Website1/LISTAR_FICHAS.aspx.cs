using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LISTAR_FICHAS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            string Codigo = Request.QueryString["Codigo"];
            string Data = Request.QueryString["Data"];

            if (Codigo.Trim().ToString() != "")
            {
                Fichas c = new Fichas();
                grvData.DataSource = c.GetFichas(Codigo, Data);
                grvData.DataBind();

                if (Codigo == "1")
                {
                    Titulo.InnerText = "Fichas de Chegada programadas";
                }
                else
                    
                    {
                        Titulo.InnerText = "Fichas de Saída programadas";
                    }
            }

            

        }
    }

    protected void lnkVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_FICHAS.aspx");
    }

}