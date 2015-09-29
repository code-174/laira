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


public partial class GERAR_FATURA : System.Web.UI.Page
{
    public double SumValorUnitario = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDataInicio.Text = DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR"));
            LoadCombos();
            grvQuantidade.DataSource = FichasListagem.GetQuantidadeFatura();
            grvQuantidade.DataBind();
        }
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

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SumValorUnitario += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "PRECO"));
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Total Valor Unit.";
            e.Row.Cells[0].Font.Bold = true;
            e.Row.Cells[1].Text = SumValorUnitario.ToString();
            e.Row.Cells[1].Font.Bold = true;
            SumValorUnitario = 0;
            //e.Row.Cells[9].Visible = false;
            //e.Row.Cells[10].Visible = false;
        }
    }

    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        if (ddlAgencia.SelectedValue != "0")
        {
            if (txtDataInicio.Text.Trim() != "")
            {
                string strDataIni = txtDataInicio.Text.Trim();
                string strAgencia = ddlAgencia.SelectedValue;
                string strDataFin = "";

                if (txtDataFim.Text == "")
                {
                    strDataFin = strDataIni;
                }
                else
                {
                    strDataFin = txtDataFim.Text.Trim();
                }
                panNaoFaturados.Visible = false;
                grvQuantidade.Visible = false;
                panDadosAdc.Visible = true;
                lnkConfirmar.Visible = true;
                 
                GridView1.DataSource = FichasListagem.FiltroFichasFatura(strDataIni, strDataFin, strAgencia);
                GridView1.DataBind();

            }
        }

    }

    protected void lnkConfirmar_Click(object sender, EventArgs e)
    {
        // TO DO VERIFICAR CAMPOS
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;

        StringBuilder str = new StringBuilder();
        str.AppendLine(" INSERT INTO [FATURAS] ");
        str.AppendLine(" ([DATA_EMISSAO] ");
        str.AppendLine(" ,[VENCIMENTO] ");
        str.AppendLine(" ,[QUANT_PAX] ");
        str.AppendLine(" ,[VALOR] ");
        str.AppendLine(" ,[OBS_FATURA] ");
        str.AppendLine(" )");
        str.AppendLine(" VALUES ");
        str.AppendLine(" (@A ");
        str.AppendLine(" ,@B ");
        str.AppendLine(" ,@C ");
        str.AppendLine(" ,@D ");
        str.AppendLine(" ,@E )");
        cmd.CommandText = str.ToString();
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.Date)).Value = txtDataEmissao.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.Date)).Value = txtVencimento.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.BigInt)).Value = txtQtdPax.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@D", SqlDbType.Money)).Value = txtValorFatura.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@E", SqlDbType.NVarChar)).Value = txtOBS.Text.Trim();
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cmd = null;
        conn.Close();
        conn.Dispose();

        System.Threading.Thread.Sleep(1000);

        Int64 FATURA_NO = getLastFatura();

        System.Threading.Thread.Sleep(1000);

        // Select the checkboxes from the GridView control
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

            if (isChecked)
            {
                Int64 FICHA_NO = Convert.ToInt64(GridView1.DataKeys[row.RowIndex].Value);
                InserirFaturaNo(FATURA_NO, FICHA_NO);
            }
        }
    }
        
    Int64 getLastFatura()
    {
        Int64 retorno = 0;

        Faturas c = new Faturas();
        retorno = c.getLastFatura();
        return retorno;

    }

    void InserirFaturaNo(Int64 FATURA_NO, Int64 FICHA_NO)
    {
        Fichas c = new Fichas();
        c.UpdateFaturaFicha(FATURA_NO, FICHA_NO);
    }

     protected void grvQuantidade_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Faturar")
        {
            int indexRow = Convert.ToInt32(e.CommandArgument);
            string strAgencia = grvQuantidade.DataKeys[indexRow].Value.ToString();

            string strDataIni = "0";
            string strDataFin = "0";
            //string strAgencia = AgenciaNo.ToString();

            panNaoFaturados.Visible = false;
            grvQuantidade.Visible = false;
            panDadosAdc.Visible = true;
            lnkConfirmar.Visible = true;

            GridView1.DataSource = FichasListagem.FiltroFichasFatura(strDataIni, strDataFin, strAgencia);
            GridView1.DataBind();
        }
    }
}