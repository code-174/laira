using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RELATORIO_ORDEM_SERVICO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string OS_NO = Request.QueryString["No"];

            if (OS_NO.Trim().ToString() != "")
            {
                GridView1.DataSource = OrdemServico.GetOSByNo(OS_NO);
                GridView1.DataBind();

                //switch (Tipo)
                //{
                //    case "C":
                //        Titulo.InnerText = "Listagem de Fichas de Chegada";
                //        break;
                //    case "S":
                //        Titulo.InnerText = "Listagem de Fichas de Saída";
                //        break;

                //    default:
                //        break;
                //}

                //ddlTipo.SelectedValue = Tipo;

            }
        }
    }
}