using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Faturas
/// </summary>
public class Faturas
{
    #region Propriedades
    public Int64 ID_FATURA { get; set; }
    public string DATA_EMISSAO { get; set; }
    public string VENCIMENTO { get; set; }
    public string QUANT_PAX { get; set; }
    public string VALOR { get; set; }
    public string OBS_FATURA { get; set; }
    #endregion

    public Faturas()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Int64 getLastFatura()
    {

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select MAX(ID_FATURA) from FATURAS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        Int64 retorno = 0;
        while (reader.Read())
        {
            retorno = reader.GetInt64(0);
        }

        return retorno;
    }
}