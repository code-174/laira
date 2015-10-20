using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

public partial class FATURA_BAIXAR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCombos();

            string DataIni = Request.QueryString["DataIni"];
            string DataFin = Request.QueryString["DataFin"];
            string Tipo = Request.QueryString["Tipo"];
            string Agencia = Request.QueryString["Agencia"];

            GridFaturas(DataIni, DataFin, Tipo, Agencia);

        }

    }

    void GridFaturas(string DataIni, string DataFin, string Tipo, string Agencia)
    {
        GridView1.DataSource = Faturas.GetFaturas(DataIni, DataFin, Tipo, Agencia);
        GridView1.DataBind();
    }

    void LoadCombos()
    {
        // POPULATE AGENCIAS DROP DOWN LIST
        Agencias c = new Agencias();
        List<Agencias> details = c.GetAgenciasCombo();
        ddlAgencia.DataTextField = "NOME";
        ddlAgencia.DataValueField = "ID";
        ddlAgencia.DataSource = details;
        ddlAgencia.DataBind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int indexRow = Convert.ToInt32(e.RowIndex);

        string strDataPag = ((TextBox)GridView1.Rows[indexRow].FindControl("txtDataPag")).Text;
        string strValorPag = ((TextBox)GridView1.Rows[indexRow].FindControl("txtValorPag")).Text;
        string strFaturaNo = GridView1.Rows[indexRow].Cells[0].Text;

        if (CheckValor(strValorPag))
        {
            if (CheckData(strDataPag))
            {
                //update
                UpdateFatura(strFaturaNo, strDataPag, strValorPag);
            }
            else
            {
                //mensagem preencher data
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Favor preencher o campo Data Pag. corretamente.');</script>", false);
            }
        }
        else
        {
            //MESSAGE PREENCHER VALOR
            //RegisterClientScriptBlock("", "Por favor preencher o Valor do Pagamento");
            //ClientScript.RegisterClientScriptBlock(this.Page, "Pop", "What");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Favor preencher o campo Valor Pag. corretamente.');</script>", false);
        }

    }

    bool CheckValor(string strValor)
    {
        if (!string.IsNullOrEmpty(strValor))
        {
            decimal temp;
            if (Decimal.TryParse(strValor, out temp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    bool CheckData(string strData)
    {
        if (!string.IsNullOrEmpty(strData))
        {
            DateTime temp;
            if (DateTime.TryParse(strData, out temp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    void UpdateFatura(string FaturaNo, string DataPag, string ValorPag)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
            cmd.Connection = conn;

            StringBuilder str = new StringBuilder();

            str.AppendLine(" update FATURAS ");
            str.AppendLine(" set DATA_PAG = @DATA_PAG, ");
            str.AppendLine(" VALOR_PAG = @VALOR_PAG ");
            str.AppendLine(" where ID_FATURA = @ID_FATURA ");

            cmd.CommandText = str.ToString();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@DATA_PAG", SqlDbType.Date)).Value = Convert.ToDateTime(DataPag);
            cmd.Parameters.Add(new SqlParameter("@VALOR_PAG", SqlDbType.Money)).Value = Convert.ToDecimal(ValorPag);
            cmd.Parameters.Add(new SqlParameter("@ID_FATURA", SqlDbType.BigInt)).Value = Convert.ToInt64(FaturaNo);

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
            conn.Close();
            conn.Dispose();

            //mensagem servico alterado com sucesso.
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "AlertMsg", "<script language='javascript'>alert('Registro salvo com sucesso.');</script>", false);
        }
        catch (Exception e)
        {

            throw e;
        }
        //Faturas c = new Faturas();
        //c.BaixarFatura(FaturaNo, DataPag, ValorPag);        
    }

    protected void lnkProcessar_Click(object sender, EventArgs e)
    {

    }
    protected void lnkLocalizar_Click(object sender, EventArgs e)
    {

    }
}