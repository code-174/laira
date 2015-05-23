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

public partial class CADASTRAR_AGENCIA : System.Web.UI.Page
{
    bool VerificarCampos()
    {
        if (txtCodAgencia.Text.Trim() == "")
        {
            return false;
        }
        else if (txtRazaoSocial.Text.Trim() == "")
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
        else if (txtBairro.Text.Trim() == "")
        {
            return false;
        }
        else if (txtCidade.Text.Trim() == "")
        {
            return false;
        }
        else if (txtUF.Text.Trim() == "")
        {
            return false;
        }
        else if (txtCEP.Text.Trim() == "")
        {
            return false;
        }
        else if (txtCNPJ.Text.Trim() == "")
        {
            return false;
        }
        else if (txtInscrMun.Text.Trim() == "")
        {
            return false;
        }
         else if (txtContatos.Text.Trim() == "")
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

        return true;
    }
    protected void btnAdAgencia_Click(object sender, EventArgs e)
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
                str.AppendLine(" INSERT INTO [AGENCIAS] ");
                str.AppendLine(" ([CODIGO_AGENCIA] ");
                str.AppendLine(" ,[RAZAO_SOCIAL_AGENCIA] ");
                str.AppendLine(" ,[NOME_AGENCIA] ");
                str.AppendLine(" ,[ENDERECO_AGENCIA] ");
                str.AppendLine(" ,[BAIRRO_AGENCIA] ");
                str.AppendLine(" ,[CIDADE_AGENCIA] ");
                str.AppendLine(" ,[UF_AGENCIA] ");
                str.AppendLine(" ,[CEP_AGENCIA] ");
                str.AppendLine(" ,[CNPJ_AGENCIA] ");
                str.AppendLine(" ,[INSCR_MUN_AGENCIA] ");
                str.AppendLine(" ,[CONTATOS_AGENCIA] ");
                str.AppendLine(" ,[TELEFONE_AGENCIA] ");
                str.AppendLine(" ,[EMAIL_AGENCIA] ");
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
                str.AppendLine(" ,@N )");
                cmd.CommandText = str.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.NChar)).Value = txtCodAgencia.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.NChar)).Value = txtRazaoSocial.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.NChar)).Value = txtNome.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@D", SqlDbType.NChar)).Value = txtEndereco.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@E", SqlDbType.NChar)).Value = txtBairro.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@F", SqlDbType.NChar)).Value = txtCidade.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@G", SqlDbType.NChar)).Value = txtUF.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@H", SqlDbType.NChar)).Value = txtCEP.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@I", SqlDbType.NChar)).Value = txtCNPJ.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@J", SqlDbType.NChar)).Value = txtInscrMun.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@L", SqlDbType.NChar)).Value = txtContatos.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@M", SqlDbType.NChar)).Value = txtTelefone.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@N", SqlDbType.NChar)).Value = txtEmail.Text.Trim();
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
