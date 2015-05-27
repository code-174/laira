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

public partial class CADASTRAR_FICHA : System.Web.UI.Page
{
   



    bool VerificarCampos()
    {
        if (txtCodFicha.Text.Trim() == "")
        {
            return false;
        }
        else if (txtDataChegada.Text.Trim() == "")
        {
            return false;
        }
        else if (txtDataSaida.Text.Trim() == "")
        {
            return false;
        }

        else if (txtVooChegada.Text.Trim() == "")
        {
            return false;
        }

        else if (txtVooHoraChegada.Text.Trim() == "")
        {
            return false;
        }
        else if (txtVooSaida.Text.Trim() == "")
        {
            return false;
        }
        else if (txtVooHoraSaida.Text.Trim() == "")
        {
            return false;
        }
        else if (txtAeroportoChegada.Text.Trim() == "")
        {
            return false;
        }
        else if (txtAeroportoSaida.Text.Trim() == "")
        {
            return false;
        }
        else if (txtCodExcursao.Text.Trim() == "")
        {
            return false;
        }
        else if (ddlAgencia.SelectedValue.Trim() == "")
        {
            return false;
        }
        else if (txtRecibo.Text.Trim() == "")
        {
            return false;
        }
        else if (txtHotel.Text.Trim() == "")
        {
            return false;
        }
        else if (txtApartamento.Text.Trim() == "")
        {
            return false;
        }
        else if (txtSaidaHotel.Text.Trim() == "")
        {
            return false;
        }

        return true;
    }
    protected void btnAdFicha_Click(object sender, EventArgs e)
    {

        //Convert.ToInt64( )
       //Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('" + ddlAgencia.SelectedValue + "');</script>", false);

        if (VerificarCampos())
        {


            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
                cmd.Connection = conn;

                StringBuilder str = new StringBuilder();
                str.AppendLine(" INSERT INTO [FICHAS] ");
                str.AppendLine(" ([CODIGO_FICHA] ");
                str.AppendLine(" ,[DATA_CHEGADA_FICHA] ");
                str.AppendLine(" ,[DATA_SAIDA_FICHA] ");
                str.AppendLine(" ,[VOO_CHEGADA_FICHA] ");
                str.AppendLine(" ,[VOO_CHEGADA_HORA_FICHA] ");
                str.AppendLine(" ,[VOO_SAIDA_FICHA] ");
                str.AppendLine(" ,[VOO_SAIDA_HORA_FICHA] ");
                str.AppendLine(" ,[AEROPORTO_CHEGADA_FICHA] ");
                str.AppendLine(" ,[AEROPORTO_SAIDA_FICHA] ");
                str.AppendLine(" ,[COD_EXCURSAO_FICHA] ");
                str.AppendLine(" ,[AGENCIA_FICHA] ");
                str.AppendLine(" ,[RECIBO_FICHA] ");
                str.AppendLine(" ,[HOTEL_FICHA] ");
                str.AppendLine(" ,[APARTAMENTO_FICHA] ");
                str.AppendLine(" ,[SAIDA_DO_HOTEL_FICHA] ");
                str.AppendLine(" )");
                str.AppendLine(" VALUES ");
                str.AppendLine(" (@A ");
                str.AppendLine(" ,@B ");
                str.AppendLine(" ,@C ");
                str.AppendLine(" ,@D ");
                str.AppendLine(" ,@E ");
                str.AppendLine(" ,@F ");
                str.AppendLine(" ,@G ");
                str.AppendLine(" ,@H ");
                str.AppendLine(" ,@I ");
                str.AppendLine(" ,@J ");
                str.AppendLine(" ,@L ");
                str.AppendLine(" ,@M ");
                str.AppendLine(" ,@N ");
                str.AppendLine(" ,@O ");
                str.AppendLine(" ,@P )");
                cmd.CommandText = str.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.NChar)).Value = txtCodFicha.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.NChar)).Value = txtDataChegada.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.NChar)).Value = txtDataSaida.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@D", SqlDbType.NChar)).Value = txtVooChegada.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@E", SqlDbType.NChar)).Value = txtVooHoraChegada.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@F", SqlDbType.NChar)).Value = txtVooSaida.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@G", SqlDbType.NChar)).Value = txtVooHoraSaida.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@H", SqlDbType.NChar)).Value = txtAeroportoChegada.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@I", SqlDbType.NChar)).Value = txtAeroportoSaida.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@J", SqlDbType.NChar)).Value = txtCodExcursao.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@L", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlAgencia.SelectedValue.ToString());
                cmd.Parameters.Add(new SqlParameter("@M", SqlDbType.NChar)).Value = txtRecibo.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@N", SqlDbType.NChar)).Value = txtHotel.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@O", SqlDbType.NChar)).Value = txtApartamento.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@P", SqlDbType.NChar)).Value = txtSaidaHotel.Text.Trim();
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                conn.Close();
                conn.Dispose();

                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('Registro salvo com sucesso!');</script>", false);
            }

            catch (Exception ex)
            {
                throw ex;
                //this.ShowAlert(ex.Message);
            }
        }

        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('Favor preencher os campos!');</script>", false);
        }
    }


    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_FICHAS.aspx"); //LISTAR_FICHAS
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Agencias c = new Agencias();
            List<Agencias> details = c.GetAgenciasCombo();

            ddlAgencia.DataTextField = "NOME";
            ddlAgencia.DataValueField = "ID";
            ddlAgencia.DataSource = details;
            ddlAgencia.DataBind();

           loadDataTables();

        }

    }

    private void loadTablePAX()
    {
        DataSet ds = new DataSet();
        DataTable dt;
        DataRow dr;
        DataColumn pName;
        DataColumn pIdentidade;
        DataColumn pOrgao;
        DataColumn pTelefone;
        DataColumn pObs;
        int i = 0;
        dt = new DataTable();
        pName = new DataColumn("Nome", Type.GetType("System.String"));
        pIdentidade = new DataColumn("Identidade", Type.GetType("System.String"));
        pOrgao = new DataColumn("Orgao", Type.GetType("System.String"));
        pTelefone = new DataColumn("Telefone", Type.GetType("System.String"));
        pObs = new DataColumn("Obs", Type.GetType("System.String"));

        dt.Columns.Add(pName);
        dt.Columns.Add(pIdentidade);
        dt.Columns.Add(pOrgao);
        dt.Columns.Add(pTelefone);
        dt.Columns.Add(pObs);

        dr = dt.NewRow();
        dr["Nome"] = "";
        dr["Identidade"] = "";
        dr["Orgao"] = "";
        dr["Telefone"] = "";
        dr["Obs"] = "";
        dt.Rows.Add(dr);

        ds.Tables.Add(dt);
        grvData.DataSource = ds.Tables[0];
        grvData.DataBind();
    }

    private void loadTableServIncl()
    {
        DataSet ds = new DataSet();
        DataTable dt;
        DataRow dr;
        DataColumn pLocal;
        DataColumn pValor;
        DataColumn pPagamento;
        int i = 0;
        dt = new DataTable();
        pLocal = new DataColumn("Local", Type.GetType("System.String"));
        pValor = new DataColumn("Valor", Type.GetType("System.String"));
        pPagamento = new DataColumn("Pagamento", Type.GetType("System.String"));

        dt.Columns.Add(pLocal);
        dt.Columns.Add(pValor);
        dt.Columns.Add(pPagamento);

        dr = dt.NewRow();
        dr["Local"] = "";
        dr["Valor"] = "";
        dr["Pagamento"] = "";
        dt.Rows.Add(dr);

        ds.Tables.Add(dt);
        grvData1.DataSource = ds.Tables[0];
        grvData1.DataBind();
    }
    private void loadDataTables()
    {
        loadTablePAX();
        loadTableServIncl();
            
    }
    protected void Unnamed2_Click(object sender, ImageClickEventArgs e)
    {
      
    }
}

