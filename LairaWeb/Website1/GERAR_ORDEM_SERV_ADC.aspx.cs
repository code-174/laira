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

public partial class GERAR_ORDEM_SERV_ADC : System.Web.UI.Page
{
    public string DataOS { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCombos();
            DataOS = Request.QueryString["Data"];
            txtDataServico.Text = DataOS;
            LoadGrid(DataOS);
        }

    }

    private void LoadGrid(string DataOS)
    {
        GridView1.DataSource = FichasListagem.GetFichasOSAdc(DataOS);
        GridView1.DataBind();
    }
    
    void LoadCombos()
    {
        
        // POPULATE PASSEIOS DROP DOWN LIST
        ServAdc p = new ServAdc();
        List<ServAdc> detailsPasseio = p.GetServAdcCombo();
        ddlPasseios.DataTextField = "PASSEIO";
        ddlPasseios.DataValueField = "ID";
        ddlPasseios.DataSource = detailsPasseio;
        ddlPasseios.DataBind();

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

    }
    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        // TO DO VERIFICAR CAMPOS
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;

        StringBuilder str = new StringBuilder();
        str.AppendLine(" INSERT INTO [OS_ADC] ");
        str.AppendLine(" ([DATA_OS_ADC] ");
        str.AppendLine(" ,[FEITO_POR_NO] ");
        str.AppendLine(" ,[OBS] ");
        str.AppendLine(" ,[MOTORISTA_NO] ");
        str.AppendLine(" ,[GUIA_NO] ");
        str.AppendLine(" )");
        str.AppendLine(" VALUES ");
        str.AppendLine(" (@A ");
        str.AppendLine(" ,@B ");
        str.AppendLine(" ,@C ");
        str.AppendLine(" ,@D ");
        str.AppendLine(" ,@E )");
        cmd.CommandText = str.ToString();
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.NChar)).Value = txtDataServico.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlServicoFeitoPor.SelectedValue.ToString());
        cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.NChar)).Value = txtObs.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@D", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlMotorista.SelectedValue.ToString());
        cmd.Parameters.Add(new SqlParameter("@E", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlGuia.SelectedValue.ToString());
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cmd = null;
        conn.Close();
        conn.Dispose();

        System.Threading.Thread.Sleep(1000);

        Int64 OSADC_NO = getLastOSAdc();

        System.Threading.Thread.Sleep(1000);

        // Select the checkboxes from the GridView control
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

            if (isChecked)
            {
                Int64 SERV_ADC_FICHA_NO = Convert.ToInt64(GridView1.DataKeys[row.RowIndex].Value);
                //.Rows[i].Cells[2].Text);
                InserirOSAdc(OSADC_NO, SERV_ADC_FICHA_NO);
            }
        }
    }
    Int64 getLastOSAdc()
    {
        Int64 retorno = 0;

        OrdemServAdc c = new OrdemServAdc();
        retorno = c.getLastOSAdc();
        return retorno;

    }

    void InserirOSAdc(Int64 OSADC_NO, Int64 SERV_ADC_FICHA_NO)
    {
        ServAdFicha c = new ServAdFicha();
        c.InserirOSAdc(OSADC_NO, SERV_ADC_FICHA_NO);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    e.Row.Cells[2].Visible = false;
        //}
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[2].Visible = false;            
        //}
    }
}