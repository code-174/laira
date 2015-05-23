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

public partial class CADASTRAR_FORMA_PAGAMENTO : System.Web.UI.Page
{
    bool VerificarCampos()
    {
        if (txtCodFormaPagamento.Text.Trim() == "")
        {
            return false;
        }
        else if (txtFormaPagamento.Text.Trim() == "")
        {
            return false;
        }
        else if (txtTipoFormaPagamento.Text.Trim() == "")
        {
            return false;
        }

        return true;
    }
    protected void btnAdFormaPagamento_Click(object sender, EventArgs e)
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
                str.AppendLine(" INSERT INTO [FORMA_DE_PAGAMENTO] ");
                str.AppendLine(" ([COD_FORMA_DE_PAGAMENTO] ");
                str.AppendLine(" ,[FORMA_DE_PAGAMENTO] ");
                str.AppendLine(" ,[TIPO_FORMA_DE_PAGAMENTO] ");
                str.AppendLine(" )");
                str.AppendLine(" VALUES ");
                str.AppendLine(" (@A ");
                str.AppendLine(" ,@B ");
                str.AppendLine(" ,@C )");
                cmd.CommandText = str.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.NChar)).Value = txtCodFormaPagamento.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.NChar)).Value = txtFormaPagamento.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.NChar)).Value = txtTipoFormaPagamento.Text.Trim();
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

                //Response.Write("<script type='text/javascript'>alert('ERRO:', + ex.Message.ToString());</script>");
            }
        }

        else
        {
            Response.Write("<script type='text/javascript'>alert('Favor preencher os campos!');</script>");
        }
    }
}