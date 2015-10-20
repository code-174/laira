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
    public string AGENCIA { get; set; }
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

    public static List<Faturas> GetFaturas(string DataIni, string DataFin, string Tipo, string Agencia)
    {
        List<Faturas> xList = new List<Faturas>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        //DateTime DataOS = Convert.ToDateTime(strData);
        DateTime DataI = Convert.ToDateTime(DataIni);
        DateTime DataF = Convert.ToDateTime(DataFin);


        str.AppendLine(" select ID_FATURA, DATA_EMISSAO, VENCIMENTO, ");
        str.AppendLine(" QUANT_PAX, VALOR, OBS_FATURA, NOME_AGENCIA, ");
        str.AppendLine(" DATA_PAG, ISNULL(VALOR_PAG, 0) as VALOR_PAG  ");
        str.AppendLine(" from FATURAS ");
        str.AppendLine(" LEFT JOIN AGENCIAS ON FATURAS.AGENCIA_NO = AGENCIAS.ID_AGENCIA ");      
        str.AppendLine(" WHERE ");

        if (Tipo == "V")
        {
            str.AppendLine(" VENCIMENTO between @DATA_INI and @DATA_FIN ");
        }

        if (Tipo == "E")
        {
            str.AppendLine(" DATA_EMISSAO between @DATA_INI and @DATA_FIN ");
        }

        if (Agencia != "0")
        {
            str.AppendLine(" AND AGENCIA_NO = @AGENCIA_NO ");
        }
        
        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@DATA_INI";
        parameter.Value = DataI;
        cmd.Parameters.Add(parameter);

        SqlParameter parameter2 = new SqlParameter();
        parameter2.ParameterName = "@DATA_FIN";
        parameter2.Value = DataF;
        cmd.Parameters.Add(parameter2);

        if (Agencia != "0")
        {
            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@AGENCIA_NO";
            parameter5.Value = Agencia;
            cmd.Parameters.Add(parameter5);
        }

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Faturas Fatura = new Faturas();
            Fatura.ID_FATURA = Convert.ToInt64(reader["ID_FATURA"]);
            Fatura.AGENCIA = reader["NOME_AGENCIA"].ToString();
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