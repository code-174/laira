using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GERAR_COMUNICADO_TRANSFER : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtData.Text = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"));
            //string DataOS;
            //DataOS = txtData.Text;
            //LoadGrid(DataOS);
        }
    }

    private void LoadGrid(string strCriterio, string strTipo)
    {
        GridView1.DataSource = FichasListagem.GetFichasTransferOut(strCriterio, strTipo);
        GridView1.DataBind();
    }


    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        if (txtCriterio.Text != "")
        {
            string strTipo = ddlSelecione.SelectedValue;
            string strCriterio = txtCriterio.Text.Trim();
            if (strTipo == "D")
            {
                LoadGrid(strCriterio, strTipo);
            }
            else
            {
                double Num;
                bool isNum = double.TryParse(strCriterio, out Num);
                if (isNum)
                {
                    LoadGrid(strCriterio, strTipo);
                }
            }            
        }


    }
    protected void lnkSelecionarTodas_Click(object sender, EventArgs e)
    {
        // TO DO
    }
    protected void lnkEnviarEmail_Click(object sender, EventArgs e)
    {
        // TO DO
    }
}