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

public partial class CADASTRAR_SERV_INCLUSO : System.Web.UI.Page
{
    bool VerificarCampos()
    {
        if (txtCodigo.Text.Trim() == "")
        {
            return false;
        }
        else if (txtServico.Text.Trim() == "")
        {
            return false;
        }
        else if (txtPreco.Text.Trim() == "")
        {
            return false;
        }


        return true;
    }
    protected void btnAdServ_Click(object sender, EventArgs e)
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
                str.AppendLine(" INSERT INTO [SERV_INCLUSO] ");
                str.AppendLine(" ([COD_SERV_INCLUSO] ");
                str.AppendLine(" ,[SERVICO_SERV_INCLUSO ] ");
                str.AppendLine(" ,[PRECO_SERV_INCLUSO] ");
                str.AppendLine(" )");
                str.AppendLine(" VALUES ");
                str.AppendLine(" (@A ");
                str.AppendLine(" ,@B ");
                str.AppendLine(" ,@C )");
                cmd.CommandText = str.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.NChar)).Value = txtCodigo.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.NChar)).Value = txtServico.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.NChar)).Value = txtPreco.Text.Trim();
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


    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_ADMINISTRACAO.aspx");
    }
}