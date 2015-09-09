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
        GridView1.DataSource = FichasListagem.GetFichasOS(TipoFicha, DataFicha);
        GridView1.DataBind();
        switch (TipoFicha)
        {
            case "C":
                Titulo.InnerText = "Gerar OS de Chegada" + " " + DataFicha;
                break;
            case "S":
                Titulo.InnerText = "Gerar OS de Saída" + " " + DataFicha;
                break;

            default:
                break;
        }
        //Fichas c = new Fichas();
        //grvFichas.DataSource = c.GetFichasByTypeNDate(TipoFicha, DataFicha);
        //grvFichas.DataBind();
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
    
       
    
    protected void lnkProcessarCriterios_Click(object sender, EventArgs e)
    {
        TipoFicha = ddlTipoServico.SelectedValue;
        DataFicha = txtDataServico.Text;
        LoadGrid(TipoFicha, DataFicha);
    }
    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        // TO DO VERIFICAR CAMPOS
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;

        StringBuilder str = new StringBuilder();
        str.AppendLine(" INSERT INTO [ORDEM_SERV] ");
        str.AppendLine(" ([DATA] ");
        str.AppendLine(" ,[TIPO_SERVICO] ");
        str.AppendLine(" ,[FEITO_POR_NO] ");
        str.AppendLine(" ,[VALOR_SERVICO] ");
        str.AppendLine(" ,[VALOR_ESTAC] ");
        str.AppendLine(" ,[OBS_ORDEM_SERV] ");
        str.AppendLine(" ,[MOTORISTA_NO] ");
        str.AppendLine(" ,[GUIA_NO] ");
        str.AppendLine(" )");
        str.AppendLine(" VALUES ");
        str.AppendLine(" (@A ");
        str.AppendLine(" ,@B ");
        str.AppendLine(" ,@C ");
        str.AppendLine(" ,@D ");
        str.AppendLine(" ,@E ");
        str.AppendLine(" ,@F ");
        str.AppendLine(" ,@G ");
        str.AppendLine(" ,@H )");
        cmd.CommandText = str.ToString();
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.Date)).Value = txtDataServico.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.NChar)).Value = ddlTipoServico.SelectedValue;
        cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlServicoFeitoPor.SelectedValue.ToString());
        cmd.Parameters.Add(new SqlParameter("@D", SqlDbType.Money)).Value = txtValorServico.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@E", SqlDbType.Money)).Value = txtValorEstacionamento.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@F", SqlDbType.NChar)).Value = txtObs.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@G", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlMotorista.SelectedValue.ToString());
        cmd.Parameters.Add(new SqlParameter("@H", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlGuia.SelectedValue.ToString());
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cmd = null;
        conn.Close();
        conn.Dispose();

        System.Threading.Thread.Sleep(1000);

        Int64 OS_NO = getLastOS();

        System.Threading.Thread.Sleep(1000);

        // Select the checkboxes from the GridView control
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

            if (isChecked)
            {                
                Int64 FICHA_NO = Convert.ToInt64(GridView1.Rows[i].Cells[1].Text);
                InserirOSFicha(OS_NO, FICHA_NO);
            }
        }
    }
    Int64 getLastOS()
    {
        Int64 retorno = 0;

        OrdemServico c = new OrdemServico();
        retorno = c.getLastOS();
        return retorno;

    }

    void InserirOSFicha(Int64 OS_NO, Int64 FICHA_NO)
    {
        TipoFicha = ddlTipoServico.SelectedValue;
        Fichas c = new Fichas();
        c.UpdateOSFicha(TipoFicha, OS_NO, FICHA_NO);
    }
}