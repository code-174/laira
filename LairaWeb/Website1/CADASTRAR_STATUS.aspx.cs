﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

public partial class CADASTRAR_STATUS : System.Web.UI.Page
{
    bool VerificarCampos()
    {
        if (txtCodStatus.Text.Trim() == "")
        {
            return false;
        }
        else if (txtStatus.Text.Trim() == "")
        {
            return false;
        }

        
        return true;
    }
    protected void btnAdStatus_Click(object sender, EventArgs e)
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
                str.AppendLine(" INSERT INTO [STATUS] ");
                str.AppendLine(" ([CODIGO_STATUS] ");
                str.AppendLine(" ,[STATUS_STATUS] ");
                str.AppendLine(" )");
                str.AppendLine(" VALUES ");
                str.AppendLine(" (@A ");
                str.AppendLine(" ,@B )");
                cmd.CommandText = str.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.NChar)).Value = txtCodStatus.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.NChar)).Value = txtStatus.Text.Trim();
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