using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GERAR_COMUNICADO_PASSEIO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCombos();
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
    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        // TO DO
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