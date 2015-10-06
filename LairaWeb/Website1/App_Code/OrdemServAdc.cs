using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for OrdemServAdc
/// </summary>
public class OrdemServAdc
{
    #region Propriedades
    public Int64 ID_OS_ADC { get; set; }
    public string DATA { get; set; }
    public string FEITO_POR { get; set; }
    public string OBS_OS { get; set; }
    public string MOTORISTA { get; set; }
    public string GUIA { get; set; }

    public List<FichasListagem> FichasLista
    {
        get
        {
            return FichasListagem.GetRelatorioFichasOSAdc(this.ID_OS_ADC);
        }
    }
    #endregion
    public OrdemServAdc()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Int64 getLastOSAdc()
    {

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select MAX(ID_OS_ADC) from OS_ADC ");
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

    public static List<OrdemServAdc> GetOSAdc(string strCriterio, string strTipo)
    {
        List<OrdemServAdc> xList = new List<OrdemServAdc>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        //DateTime DataOS = new DateTime(strData);
        //DateTime DataOS = Convert.ToDateTime(strData);


        str.AppendLine(" select ID_OS_ADC, DATA_OS_ADC, NOME_PRESTADOR AS FEITO_POR, OBS, ");
        str.AppendLine(" MOTORISTA_NO, GUIA_NO ");
        //str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
        //str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA ");
        str.AppendLine(" from OS_ADC ");
        str.AppendLine(" LEFT JOIN PRESTADORES ON OS_ADC.FEITO_POR_NO = PRESTADORES.ID_PRESTADOR ");
        //str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
        //str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
        str.AppendLine(" WHERE ");
        if (strTipo == "D")
        {
            str.AppendLine(" DATA_OS_ADC  = @CRITERIO ");
        }
        else if (strTipo == "N")
        {
            str.AppendLine(" ID_OS_ADC  = @CRITERIO ");
        }


        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@CRITERIO";
        parameter.Value = strCriterio;
        cmd.Parameters.Add(parameter);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            OrdemServAdc OS = new OrdemServAdc();
            OS.ID_OS_ADC = Convert.ToInt64(reader["ID_OS_ADC"]);
            OS.DATA = reader["DATA_OS_ADC"].ToString();
            OS.FEITO_POR = reader["FEITO_POR"].ToString();
            OS.OBS_OS = reader["OBS"].ToString();
            OS.MOTORISTA = reader["MOTORISTA_NO"].ToString();
            OS.GUIA = reader["GUIA_NO"].ToString();               
            xList.Add(OS);
        }

        return xList;
    }

    public static List<OrdemServAdc> FiltroOSAdc(string DataIni, string DataFin, string Passeio, string Prestador, string Vendedor)
    {
        List<OrdemServAdc> xList = new List<OrdemServAdc>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        //DateTime DataOS = new DateTime(strData);
        //DateTime DataOS = Convert.ToDateTime(strData);


        str.AppendLine(" select ID_OS_ADC, DATA_OS_ADC, NOME_PRESTADOR AS FEITO_POR, OBS ");
        //str.AppendLine(" MOTORISTA_NO, GUIA_NO ");
        //str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
        //str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA ");
        str.AppendLine(" from OS_ADC ");
        str.AppendLine(" inner join SERV_AD_FICHA ");
        str.AppendLine(" on OS_ADC.ID_OS_ADC = SERV_AD_FICHA.OS_ADC_NO ");

        str.AppendLine(" LEFT JOIN PRESTADORES ON OS_ADC.FEITO_POR_NO = PRESTADORES.ID_PRESTADOR ");
        //str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
        //str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
        str.AppendLine(" WHERE ");
        str.AppendLine(" DATA_OS_ADC between @DATA_INI and @DATA_FIN ");
        //str.AppendLine(" AND OS_CHEGADA IS NULL ");

        if (Passeio != "0")
        {
            str.AppendLine(" AND SERV_AD_NO = @PASSEIO ");
        }
        if (Prestador != "0")
        {
            str.AppendLine(" AND FEITO_POR_NO = @PRESTADOR ");
        }
        if (Vendedor != "0")
        {
            str.AppendLine(" AND VENDEDOR_NO = @VENDEDOR ");
        }


        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@DATA_INI";
        parameter.Value = DataIni;
        cmd.Parameters.Add(parameter);

        SqlParameter parameter2 = new SqlParameter();
        parameter2.ParameterName = "@DATA_FIN";
        parameter2.Value = DataFin;
        cmd.Parameters.Add(parameter2);

        if (Passeio != "0")
        {
            SqlParameter parameter3 = new SqlParameter();
            parameter3.ParameterName = "@PASSEIO";
            parameter3.Value = Passeio;
            cmd.Parameters.Add(parameter3);
        }

        if (Prestador != "0")
        {
            SqlParameter parameter4 = new SqlParameter();
            parameter4.ParameterName = "@PRESTADOR";
            parameter4.Value = Prestador;
            cmd.Parameters.Add(parameter4);
        }

        if (Vendedor != "0")
        {
            SqlParameter parameter5 = new SqlParameter();
            parameter5.ParameterName = "@VENDEDOR";
            parameter5.Value = Vendedor;
            cmd.Parameters.Add(parameter5);
        }

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            OrdemServAdc OS = new OrdemServAdc();
            OS.ID_OS_ADC = Convert.ToInt64(reader["ID_OS_ADC"]);
            OS.DATA = reader["DATA_OS_ADC"].ToString();
            OS.FEITO_POR = reader["FEITO_POR"].ToString();
            OS.OBS_OS = reader["OBS"].ToString();
            //OS.MOTORISTA = reader["SIGLA_VOO"].ToString();
            //OS.GUIA = reader["NOME_PASSAGEIRO"].ToString();               
            xList.Add(OS);
        }

        return xList;
    }

}