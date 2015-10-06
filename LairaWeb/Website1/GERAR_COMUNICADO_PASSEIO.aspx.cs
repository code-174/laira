using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class GERAR_COMUNICADO_PASSEIO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCombos();
            //txtData.Text = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"));
            //string DataOS;
            //DataOS = txtData.Text;
            //LoadGrid(DataOS);
        }
    }
    void LoadCombos()
    {
        // POPULATE PASSEIO DROP DOWN LIST
        ServAdc p = new ServAdc();
        List<ServAdc> detailsPasseio = p.GetServAdcCombo();
        ddlPasseio.DataTextField = "PASSEIO";
        ddlPasseio.DataValueField = "ID";
        ddlPasseio.DataSource = detailsPasseio;
        ddlPasseio.DataBind();

        // POPULATE PRESTADOR DROP DOWN LIST
        Prestadores prest = new Prestadores();
        List<Prestadores> detailsPrest = prest.GetPrestadoresCombo();
        ddlPrestador.DataTextField = "NOME";
        ddlPrestador.DataValueField = "ID";
        ddlPrestador.DataSource = detailsPrest;
        ddlPrestador.DataBind();

        // POPULATE VENDEDOR DROP DOWN LIST
        Vendedores vend = new Vendedores();
        List<Vendedores> detailsVend = vend.GetVendedoresCombo();
        ddlVendedor.DataTextField = "NOME";
        ddlVendedor.DataValueField = "ID";
        ddlVendedor.DataSource = detailsVend;
        ddlVendedor.DataBind();

    }

    private void LoadGrid(string strData, string Passeio, string Prestador, string Vendedor)
    {
        //GridView1.DataSource = FichasListagem.GetFichasPasseio(DataOS);
        //GridView1.DataBind();

        GridView1.DataSource = FichasListagem.GetFiltroFichasPasseio(strData, Passeio, Prestador, Vendedor);
        GridView1.DataBind();
    }
    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        if (txtData.Text != "")
        {
            string strData = txtData.Text.Trim();
            string Passeio = ddlPasseio.SelectedValue;
            string Prestador = ddlPrestador.SelectedValue;
            string Vendedor = ddlVendedor.SelectedValue;
            LoadGrid(strData, Passeio, Prestador, Vendedor);
        }
    }
    protected void lnkSelecionarTodas_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];
            ((CheckBox)row.FindControl("chkSelect")).Checked = true;
        }
    }
    protected void lnkEnviarEmail_Click(object sender, EventArgs e)
    {
        // TO DO
    }

    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {
        if (txtOSNo.Text != "")
        {
            string strOSNo = txtOSNo.Text.Trim();
            double Num;
            bool isNum = double.TryParse(strOSNo, out Num);
            if (isNum)
            {
                GridView1.DataSource = FichasListagem.GetFichasPasseio(strOSNo);
                GridView1.DataBind();
            }
            else
            {
                // mesage box "you gotta put only numbers"
                // no records found asp gridview
            }
        }
    }
}