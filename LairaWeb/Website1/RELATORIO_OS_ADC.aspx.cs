using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RELATORIO_OS_ADC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //LoadCombos();
            string DataOS = Request.QueryString["Data"];
            //txtDataServico.Text = DataOS;
            LoadGrid(DataOS);
        }
    }

    private void LoadGrid(string DataOS)
    {
        GridView1.DataSource = OrdemServAdc.GetOSAdc(DataOS);
        GridView1.DataBind();
    }
}