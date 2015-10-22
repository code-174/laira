using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

public partial class ALTERAR_OS : System.Web.UI.Page
{
    protected string OSNo;
    protected string TipoOS;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            string strOSNo = Request.QueryString["OSNo"];
            
            Titulo.InnerText = "Alterar OS Nr." + " " + strOSNo;

            LoadCombos();

            List<OrdemServico> l = OrdemServico.GetOSByNo(strOSNo);

            string strTipoOS = "";
            foreach (var item in l)
            {
                strTipoOS = l[0].TIPO_OS;
                ddlServicoFeitoPor.SelectedValue = l[0].FEITO_POR;
                txtValorServico.Text = l[0].VALOR_SERVICO;
                txtValorEstacionamento.Text = l[0].VALOR_ESTAC;
                txtObs.Text = l[0].OBS_OS;
                ddlMotorista.SelectedValue = l[0].MOTORISTA;
                ddlGuia.SelectedValue = l[0].GUIA;
            }

            LoadGrid(strOSNo, strTipoOS);

            ViewState["OSNo"] = strOSNo; 
            ViewState["TipoOS"] = strTipoOS;            
        }

        if (ViewState["OSNo"] != null)
        {
            OSNo = ViewState["OSNo"].ToString();
        }

        if (ViewState["TipoOS"] != null)
        {
            TipoOS = ViewState["TipoOS"].ToString();
        }

    }

    private void LoadGrid(string strOSNo, string strTipoOS)
    {
        Int64 ID_OS = Convert.ToInt64(strOSNo);
        GridView1.DataSource = FichasListagem.GetRelatorioFichasOS(ID_OS, strTipoOS);
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    e.Row.Cells[8].Visible = false;
        //    e.Row.Cells[9].Visible = false;
        //}
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

    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        // TO DO VERIFICAR CAMPOS
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;

        StringBuilder str = new StringBuilder();

        str.AppendLine(" update ORDEM_SERV ");
        str.AppendLine(" set FEITO_POR_NO = @FEITO_POR_NO, ");
        str.AppendLine(" VALOR_SERVICO = @VALOR_SERVICO, ");
        str.AppendLine(" VALOR_ESTAC = @VALOR_ESTAC, ");
        str.AppendLine(" OBS_ORDEM_SERV = @OBS_ORDEM_SERV, ");
        str.AppendLine(" MOTORISTA_NO = @MOTORISTA_NO, ");
        str.AppendLine(" GUIA_NO = @GUIA_NO ");
        str.AppendLine(" where ID_ORDEM_SERV = @ID_ORDEM_SERV ");

        cmd.CommandText = str.ToString();
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@FEITO_POR_NO", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlServicoFeitoPor.SelectedValue.ToString());
        cmd.Parameters.Add(new SqlParameter("@VALOR_SERVICO", SqlDbType.Money)).Value = txtValorServico.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@VALOR_ESTAC", SqlDbType.Money)).Value = txtValorEstacionamento.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@OBS_ORDEM_SERV", SqlDbType.NChar)).Value = txtObs.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@MOTORISTA_NO", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlMotorista.SelectedValue.ToString());
        cmd.Parameters.Add(new SqlParameter("@GUIA_NO", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlGuia.SelectedValue.ToString());
        cmd.Parameters.Add(new SqlParameter("@ID_ORDEM_SERV", SqlDbType.BigInt)).Value = Convert.ToInt64(OSNo);

        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cmd = null;
        conn.Close();
        conn.Dispose();

        
         //Select the checkboxes from the GridView control
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

            if (!isChecked)
            {
                Int64 FICHA_NO = Convert.ToInt64(GridView1.Rows[i].Cells[1].Text);
                RemoveFichaOS(FICHA_NO);
            }
        }
    }

    void RemoveFichaOS(Int64 FICHA_NO)
    {
        Fichas c = new Fichas();
        c.RemoveFichaOS(FICHA_NO, TipoOS);
    }
}