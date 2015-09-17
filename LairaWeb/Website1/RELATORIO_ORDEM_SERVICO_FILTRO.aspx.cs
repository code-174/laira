using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RELATORIO_ORDEM_SERVICO_FILTRO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string DataIni = Request.QueryString["DataIni"];
            string DataFin = Request.QueryString["DataFin"];
            string Tipo = Request.QueryString["Tipo"];
            string FeitoPor = Request.QueryString["FeitoPor"];

            LoadCombos();

            if (DataIni.Trim().ToString() != "")
            {
                GridView1.DataSource = OrdemServico.FiltroOS(DataIni, DataFin, Tipo, FeitoPor);
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

    bool VerificarCampos()
    {
        if (txtDataInicio.Text.Trim() == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        if (VerificarCampos())
        {
            //string strDataIni = txtDataInicio.Text.Trim();
            if (txtDataFim.Text == "")
            {
                txtDataFim.Text = txtDataInicio.Text;
                //string strDataFin = strDataIni;
                Response.Redirect("RELATORIO_ORDEM_SERVICO_FILTRO.aspx?DataIni=" + txtDataInicio.Text + "&DataFin=" + txtDataFim.Text + "&Tipo=" + ddlTipoOS.SelectedValue + "&FeitoPor=" + ddlPrestador.SelectedValue);
            }
            else
            {
                //string strDataFin = txtDataFim.Text.Trim();
                Response.Redirect("RELATORIO_ORDEM_SERVICO_FILTRO.aspx?DataIni=" + txtDataInicio.Text + "&DataFin=" + txtDataFim.Text + "&Tipo=" + ddlTipoOS.SelectedValue + "&FeitoPor=" + ddlPrestador.SelectedValue);
            }
        }
    }

    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {
        if (txtOSNo.Text != "")
        {
            Response.Redirect("RELATORIO_ORDEM_SERVICO.aspx?No=" + txtOSNo.Text);
        }
    }
}