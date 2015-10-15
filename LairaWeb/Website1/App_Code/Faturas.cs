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
    public string DATA_PAG { get; set; }
    public string VALOR_PAG { get; set; }
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

    public static List<Faturas> GetFaturas(string strTipo, string strData, string strAgencia)
    {
        List<Faturas> xList = new List<Faturas>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();


        str.AppendLine(" select ID_FATURA, DATA_EMISSAO, VENCIMENTO, ");
        str.AppendLine(" QUANT_PAX, VALOR, OBS_FATURA, ");
        str.AppendLine(" DATA_PG, VALOR_PG ");
        str.AppendLine(" from FATURAS ");        
        str.AppendLine(" WHERE ");
        str.AppendLine(" DATA_  = @DATA_CHEGADA_FICHA ");
        str.AppendLine(" and OS_CHEGADA is not null ");


        if (strAgencia != "0")
        {
            str.AppendLine(" AND AGENCIA = @AGENCIA ");
        }





        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@DATA_CHEGADA_FICHA";
        parameter.Value = strData;
        cmd.Parameters.Add(parameter);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Faturas Fatura = new Faturas();
            Fatura.ID_FATURA = Convert.ToInt64(reader["ID_FATURA"]);
            Fatura.DATA_EMISSAO = reader["DATA_EMISSAO"].ToString();
            Fatura.VENCIMENTO = reader["VENCIMENTO"].ToString();
            Fatura.QUANT_PAX = reader["QUANT_PAX"].ToString();
            Fatura.VALOR = reader["VALOR"].ToString();
            Fatura.OBS_FATURA = reader["OBS_FATURA"].ToString();
            Fatura.DATA_PAG = reader["DATA_PAG"].ToString();
            Fatura.VALOR_PAG = reader["VALOR_PAG"].ToString();


            xList.Add(Fatura);
        }

        return xList;
    }
}