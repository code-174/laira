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

public partial class CADASTRAR_VOO : System.Web.UI.Page
{
    bool VerificarCampos()
    {
        if (txtNome.Text.Trim() == "")
        {
            return false;
        }
        else if (txtSigla.Text.Trim() == "")
        {
            return false;
        }
        else if (txtHora.Text.Trim() == "")
        {
            return false;
        }
        else if (txtAeroporto.Text.Trim() == "")
        {
            return false;
        }
        else if (txtTipo.Text.Trim() == "")
        {
            return false;
        }


        return true;
    }
    protected void btnAdVoo_Click(object sender, EventArgs e)
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
                str.AppendLine(" INSERT INTO [VOOS] ");
                str.AppendLine(" ([NOME_VOO] ");
                str.AppendLine(" ,[SIGLA_VOO ] ");
                str.AppendLine(" ,[HORA_VOO] ");
                str.AppendLine(" ,[AEROPORTO_VOO] ");
                str.AppendLine(" ,[TIPO_VOO] ");
                str.AppendLine(" )");
                str.AppendLine(" VALUES ");
                str.AppendLine(" (@A ");
                str.AppendLine(" ,@B ");
                str.AppendLine(" ,@C ");
                str.AppendLine(" ,@D ");
                str.AppendLine(" ,@E )");
                cmd.CommandText = str.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.NChar)).Value = txtNome.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.NChar)).Value = txtSigla.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.NChar)).Value = txtHora.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@D", SqlDbType.NChar)).Value = txtAeroporto.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@E", SqlDbType.NChar)).Value = txtTipo.Text.Trim();
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

                //Response.Write("<script type='text/javascript'>alert('ERRO:', + ex.Message.ToString());</script>");
            }
        }

        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('Favor preencher os campos!');</script>", false);
        }
    }
    
    
}