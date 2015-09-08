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
            txtData.Text = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"));
            string DataOS;
            DataOS = txtData.Text;
            LoadGrid(DataOS);
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

    private void LoadGrid(string DataOS)
    {
        GridView1.DataSource = FichasListagem.GetFichasPasseio(DataOS);
        GridView1.DataBind();
    }
    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        string DataOS;
        DataOS = txtData.Text;
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