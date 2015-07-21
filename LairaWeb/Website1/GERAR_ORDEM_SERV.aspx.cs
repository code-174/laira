using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GERAR_ORDEM_SERV : System.Web.UI.Page
{
    public string TipoFicha { get; set; }
    public string DataFicha { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCombos();
            TipoFicha = Request.QueryString["Tipo"];
            DataFicha = Request.QueryString["Data"];
            LoadGrid(TipoFicha, DataFicha);
            ddlTipoServico.SelectedValue = TipoFicha;
            txtDataServico.Text = DataFicha;
        }
    }
    private void LoadGrid(string TipoFicha, string DataFicha)
    {
        Fichas c = new Fichas();
        grvFichas.DataSource = c.GetFichasByTypeNDate(TipoFicha, DataFicha);
        grvFichas.DataBind();
    }

    void LoadCombos()
    { 
        // POPULATE SERVICO FEITO POR DROP DOWN LIST
        Prestadores c = new Prestadores();
        List<Prestadores> details = c.GetPrestadoresCombo();
        ddlServicoFeitoPor.DataTextField = "NOME";
        ddlServicoFeitoPor.DataValueField = "ID";
        ddlServicoFeitoPor.DataSource = details;
        ddlServicoFeitoPor.DataBind();

        // POPULATE MOTORISTA DROP DOWN LIST
        Prestadores cm = new Prestadores();
        List<Prestadores> detailsMot = cm.GetPrestadoresCombo();
        ddlMotorista.DataTextField = "NOME";
        ddlMotorista.DataValueField = "ID";
        ddlMotorista.DataSource = detailsMot;
        ddlMotorista.DataBind();

        // POPULATE GUIA DROP DOWN LIST
        Prestadores cg = new Prestadores();
        List<Prestadores> detailsGui = c.GetPrestadoresCombo();
        ddlGuia.DataTextField = "NOME";
        ddlGuia.DataValueField = "ID";
        ddlGuia.DataSource = detailsGui;
        ddlGuia.DataBind();
    }
    
       
    
    protected void lnkProcessarCriterios_Click(object sender, EventArgs e)
    {
        TipoFicha = ddlTipoServico.SelectedValue;
        DataFicha = txtDataServico.Text;
        LoadGrid(TipoFicha, DataFicha);
    }
}