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

public partial class CADASTRAR_PRESTADOR : System.Web.UI.Page
{
    bool VerificarCampos()
    {
        if (txtCodPrestador.Text.Trim() == "")
        {
            return false;
        }
        else if (txtNome.Text.Trim() == "")
        {
            return false;
        }
        else if (txtTelefone.Text.Trim() == "")
        {
            return false;
        }
        else if (txtEndereco.Text.Trim() == "")
        {
            return false;
        }
        else if (txtEmail.Text.Trim() == "")
        {
            return false;
        }


        return true;
    }
    protected void btnAdPrestador_Click(object sender, EventArgs e)
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
                str.AppendLine(" INSERT INTO [PRESTADORES] ");
                str.AppendLine(" ([CODIGO_PRESTADOR] ");
                str.AppendLine(" ,[NOME_PRESTADOR ] ");
                str.AppendLine(" ,[TELEFONE_PRESTADOR] ");
                str.AppendLine(" ,[ENDERECO_PRESTADOR] ");
                str.AppendLine(" ,[EMAIL_PRESTADOR] ");
                str.AppendLine(" )");
                str.AppendLine(" VALUES ");
                str.AppendLine(" (@A ");
                str.AppendLine(" ,@B ");
                str.AppendLine(" ,@C ");
                str.AppendLine(" ,@D ");
                str.AppendLine(" ,@E )");
                cmd.CommandText = str.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.NChar)).Value = txtCodPrestador.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.NChar)).Value = txtNome.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.NChar)).Value = txtTelefone.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@D", SqlDbType.NChar)).Value = txtEndereco.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@E", SqlDbType.NChar)).Value = txtEmail.Text.Trim();
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