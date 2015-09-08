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

        private void LoadGrid(string DataOS)
    {
        GridView1.DataSource = FichasListagem.GetFichasTransferOut(DataOS);
        GridView1.DataBind();
    }

   
    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
       string DataOS;
       DataOS = txtCriterio.Text;
       LoadGrid(DataOS);
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