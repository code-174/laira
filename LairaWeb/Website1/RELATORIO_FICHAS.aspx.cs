using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RELATORIO_FICHAS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Tipo = Request.QueryString["Tipo"];
            string Data = Request.QueryString["Data"];

            if (Tipo.Trim().ToString() != "")
            {
                GridView1.DataSource = FichasListagem.GetFichasListagem(Tipo, Data);
                GridView1.DataBind();

                switch (Tipo)
                {
                    case "C":
                        Titulo.InnerText = "Relatório de Fichas de Chegada" + " " + Data; 
                        break;
                    case "S":
                        Titulo.InnerText = "Relatório de Fichas de Saída" + " " + Data; 
                        break;
                   
                    default:
                        break;
                }
                
                ddlTipo.SelectedValue = Tipo;
                txtCriterio.Text = Data;
            }
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[10].Visible = false;
            //e.Row.Cells[9].Visible = false;
        }
    }

    protected void lnkVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_FICHAS.aspx");
    }
    protected void lnkSelectAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];
            ((CheckBox)row.FindControl("chkSelect")).Checked = true;
        }
    }

    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        string strTipo = ddlTipo.SelectedValue;
        string strCriterio = txtCriterio.Text;
        if (ddlSelecione.SelectedValue == "D")
        {
            GridView1.DataSource = FichasListagem.GetFichasListagem(strTipo, strCriterio);
            GridView1.DataBind();
        }
        else if (ddlSelecione.SelectedValue == "F")
        {
            string Str = txtCriterio.Text.Trim();
            double Num;
            bool isNum = double.TryParse(Str, out Num);
            if (isNum)
            {
                string strSelected = ddlSelecione.SelectedValue;
                GridView1.DataSource = FichasListagem.FiltroFichasListagem(strSelected, strTipo, strCriterio);
                GridView1.DataBind();
            }
        }
        else if (ddlSelecione.SelectedValue == "E")
        {
            string strSelected = ddlSelecione.SelectedValue;
            GridView1.DataSource = FichasListagem.FiltroFichasListagem(strSelected, strTipo, strCriterio);
            GridView1.DataBind();
        }
        switch (strTipo)
        {
            case "C":
                Titulo.InnerText = "Listagem de Fichas de Chegada";
                break;
            case "S":
                Titulo.InnerText = "Listagem de Fichas de Saída";
                break;

            default:
                break;
        }
    }
}