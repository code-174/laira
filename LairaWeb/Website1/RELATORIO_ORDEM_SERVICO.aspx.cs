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
            LoadCombos();

            string ReportType = Request.QueryString["ReportType"];

            if (ReportType == "DateRpt")
            {
                string strTipo = Request.QueryString["Tipo"];
                string strData = Request.QueryString["Data"];

                GridView1.DataSource = OrdemServico.GetOS(strTipo, strData);
                GridView1.DataBind();

                txtDataInicio.Text = strData;
                ddlTipoOS.SelectedValue = strTipo;

            }
            else if (ReportType == "NumberRpt")
            {
                string OS_NO = Request.QueryString["No"];
                if (OS_NO.Trim().ToString() != "")
                {
                    GridView1.DataSource = OrdemServico.GetOSByNo(OS_NO);
                    GridView1.DataBind();

                    txtOSNo.Text = OS_NO;
                }
            }
        }
    }


    void LoadCombos()
    {
        // POPULATE PRESTADOR DROP DOWN LIST
        Prestadores c = new Prestadores();
        List<Prestadores> details = c.GetPrestadoresCombo();
        ddlPrestador.DataTextField = "NOME";
        ddlPrestador.DataValueField = "ID";
        ddlPrestador.DataSource = details;
        ddlPrestador.DataBind();
    }

    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        if (txtDataInicio.Text.Trim() != "")
        {
            string strDataIni = txtDataInicio.Text.Trim();
            string strTipo = ddlTipoOS.SelectedValue;
            string strFeitoPor = ddlPrestador.SelectedValue;
            string strDataFin = "";

            if (txtDataFim.Text == "")
            {
                strDataFin = strDataIni;
            }
            else
            {
                strDataFin = txtDataFim.Text.Trim();
            }

            GridView1.DataSource = OrdemServico.FiltroOS(strDataIni, strDataFin, strTipo, strFeitoPor);
            GridView1.DataBind();
        }
    }

    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {
        if (txtOSNo.Text != "")
        {
            string OS_NO = txtOSNo.Text.Trim();
            double Num;
            bool isNum = double.TryParse(OS_NO, out Num);
            if (isNum)
            {
                GridView1.DataSource = OrdemServico.GetOSByNo(OS_NO);
                GridView1.DataBind();
            }
            else
            {
                // mesage box "you gotta put only numbers"
                // no records found asp gridview
            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AlterarOS")
        {
            int indexRow = Convert.ToInt32(e.CommandArgument);
            string strOSNo = GridView1.DataKeys[indexRow].Value.ToString();

            Response.Redirect("ALTERAR_OS.aspx?OSNo=" + strOSNo);
        }
    }

    protected void lnkSelectAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];
            ((CheckBox)row.FindControl("chkSelect")).Checked = true;
        }
    }

    protected void lnkVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_ORD_SERV.aspx");
    }
}