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

public partial class CADASTRAR_DEPOIMENTO : System.Web.UI.Page
{
    bool VerificarCampos()
    {
        if (txtCodDepoimento.Text.Trim() == "")
        {
            return false;
        }
        else if (txtNome.Text.Trim() == "")
        {
            return false;
        }

        else if (txtCidade.Text.Trim() == "")
        {
            return false;
        }

        else if (txtDepoimento.Text.Trim() == "")
        {
            return false;
        }

        return true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdDepoimento_Click(object sender, EventArgs e)
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
                str.AppendLine(" INSERT INTO [DEPOIMENTOS] ");
                str.AppendLine(" ([CODIGO_DEPOIMENTO] ");
                str.AppendLine(" ,[NOME_DEPOIMENTO] ");
                str.AppendLine(" ,[CIDADE_DEPOIMENTO] ");
                str.AppendLine(" ,[DEPOIMENTO_DEPOIMENTO] ");
                str.AppendLine(" )");
                str.AppendLine(" VALUES ");
                str.AppendLine(" (@A ");
                str.AppendLine(" ,@B ");
                str.AppendLine(" ,@C ");
                str.AppendLine(" ,@D )");
                cmd.CommandText = str.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.NChar)).Value = txtCodDepoimento.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.NChar)).Value = txtNome.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.NChar)).Value = txtCidade.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@D", SqlDbType.NChar)).Value = txtDepoimento.Text.Trim();
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
}