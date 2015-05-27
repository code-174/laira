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

public partial class CADASTRAR_INCOMING : System.Web.UI.Page
{
    bool VerificarCampos()
    {
        if (txtCodIncoming.Text.Trim() == "")
        {
            return false;
        }
        else if (txtEmpresa.Text.Trim() == "")
        {
            return false;
        }
        else if (txtNome.Text.Trim() == "")
        {
            return false;
        }
        else if (txtEndereco.Text.Trim() == "")
        {
            return false;
        }
        else if (txtPais.Text.Trim() == "")
        {
            return false;
        }
        else if (txtTelefone.Text.Trim() == "")
        {
            return false;
        }
        else if (txtEmail.Text.Trim() == "")
        {
            return false;
        }
        else if (txtSite.Text.Trim() == "")
        {
            return false;
        }
        else if (txtAtuacao.Text.Trim() == "")
        {
            return false;
        }

        return true;
    }
    protected void btnAdIncoming_Click(object sender, EventArgs e)
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
                str.AppendLine(" INSERT INTO [INCOMING] ");
                str.AppendLine(" ([CODIGO_INCOMING] ");
                str.AppendLine(" ,[EMPRESA_INCOMING ] ");
                str.AppendLine(" ,[NOME_INCOMING] ");
                str.AppendLine(" ,[ENDERECO_INCOMING] ");
                str.AppendLine(" ,[PAIS_INCOMING] ");
                str.AppendLine(" ,[TELEFONE_INCOMING] ");
                str.AppendLine(" ,[EMAIL_INCOMING] ");
                str.AppendLine(" ,[SITE_INCOMING] ");
                str.AppendLine(" ,[ATUACAO_INCOMING] ");
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
                str.AppendLine(" ,@I )");
                cmd.CommandText = str.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.NChar)).Value = txtCodIncoming.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.NChar)).Value = txtEmpresa.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.NChar)).Value = txtNome.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@D", SqlDbType.NChar)).Value = txtEndereco.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@E", SqlDbType.NChar)).Value = txtPais.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@F", SqlDbType.NChar)).Value = txtTelefone.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@G", SqlDbType.NChar)).Value = txtEmail.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@H", SqlDbType.NChar)).Value = txtSite.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@I", SqlDbType.NChar)).Value = txtAtuacao.Text.Trim();
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