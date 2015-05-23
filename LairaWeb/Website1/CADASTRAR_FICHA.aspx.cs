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
        else if (txtAgencia.Text.Trim() == "")
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
                cmd.Parameters.Add(new SqlParameter("@L", SqlDbType.NChar)).Value = txtAgencia.Text.Trim();
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

                Response.Write("<script type='text/javascript'>alert('Registro salvo com sucesso!');</script>");
            }

            catch (Exception ex)
            {
                throw ex;
                //this.ShowAlert(ex.Message);
            }
        }

        else
        {
            Response.Write("<script type='text/javascript'>alert('Favor preencher os campos!');</script>");
        }
    }

 
    }
    
