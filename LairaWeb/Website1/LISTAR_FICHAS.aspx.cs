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

                switch (Codigo)
                {
                    case "1":
                        Titulo.InnerText = "Fichas de Chegadas programadas";
                        break;
                    case "2":
                        Titulo.InnerText = "Fichas de Saídas programadas";
                        break;
                    case "3":
                        Titulo.InnerText = "Relatorio de Chegadas programadas";
                        break;
                    case "4":
                        Titulo.InnerText = "Relatorio de Saídas programadas";
                        break;
                    case "5":
                        Titulo.InnerText = "Saídas programadas por No. Ficha";
                        break;
                    case "6":
                        Titulo.InnerText = "Saídas programadas por Cod. Exc.";
                        break;
                    default:
                        break;

                }


            }



        }
    }

    protected void lnkVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_FICHAS.aspx");
    }

}