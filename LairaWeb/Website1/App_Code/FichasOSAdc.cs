using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for FichasOSAdc
/// </summary>
public class FichasOSAdc
{
    #region Propriedades    
    public Int64 ID_OS_ADC { get; set; }
    public Int64 ID_SERV_AD_FICHA { get; set; }
    public Int64 FICHA_NO { get; set; }
    public string FEITO_POR { get; set; }
    public string DATA { get; set; }
    public string OBS_OS { get; set; }
    public string VENDEDOR { get; set; }
    public string SERV_AD { get; set; }
    public string OS_ADC_NO { get; set; }
    public List<FichasListagem> FichasLista
    {
        get
        {
            return FichasListagem.GetFiltroFichasOSAdc(this.ID_SERV_AD_FICHA);
        }
    }
    #endregion  
	public FichasOSAdc()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //public static List<FichasOSAdc> GetFichasOS(string strData)
    //{
    //    List<FichasOSAdc> xList = new List<FichasOSAdc>();

    //    SqlCommand cmd = new SqlCommand();
    //    SqlConnection conn = new SqlConnection();
    //    conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
    //    cmd.Connection = conn;
    //    StringBuilder str = new StringBuilder();


    //    str.AppendLine(" select FICHA_NO, HORA, ");
    //    str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA, ");
    //    str.AppendLine(" PASSEIO_SERV_ADC, ");
    //    str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
    //    str.AppendLine(" FORMA_DE_PAGAMENTO, ");
    //    str.AppendLine(" ISNULL(VOUCHER, '---') AS VOUCHER ");
    //    str.AppendLine(" from SERV_AD_FICHA ");
    //    str.AppendLine(" inner join FICHAS ");
    //    str.AppendLine(" on SERV_AD_FICHA.FICHA_NO = FICHAS.ID_FICHA ");
    //    str.AppendLine(" left join SERV_ADC on SERV_AD_FICHA.SERV_AD_NO = SERV_ADC.ID_SERV_ADC ");
    //    str.AppendLine(" left join FORMA_DE_PAGAMENTO on SERV_AD_FICHA.FORMA_PAG_NO = FORMA_DE_PAGAMENTO.ID_FORMA_DE_PAGAMENTO ");
    //    str.AppendLine(" left join HOTEIS on FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
    //    str.AppendLine(" where ");
    //    str.AppendLine(" DATA  = @DATA ");
    //    str.AppendLine(" and OS_ADC_NO is null ");

    //    cmd.CommandText = str.ToString();

    //    SqlParameter parameter = new SqlParameter();
    //    parameter.ParameterName = "@DATA";
    //    parameter.Value = strData;
    //    cmd.Parameters.Add(parameter);

    //    conn.Open();

    //    SqlDataReader reader = cmd.ExecuteReader();

    //    while (reader.Read())
    //    {
    //        FichasOSAdc FichaOSAdc = new FichasOSAdc();
    //        FichaOSAdc.FICHA_NO = Convert.ToInt64(reader["FICHA_NO"]);
    //        FichaOSAdc.HORA = reader["HORA"].ToString();
    //        FichaOSAdc.HOTEL = reader["HOTEL"].ToString();
    //        FichaOSAdc.APTO = reader["APARTAMENTO_FICHA"].ToString();
    //        FichaOSAdc.PASSEIO = reader["PASSEIO_SERV_ADC"].ToString();
    //        FichaOSAdc.PAX = reader["NOME_PASSAGEIRO"].ToString();
    //        FichaOSAdc.FORMA_PAG = reader["FORMA_DE_PAGAMENTO"].ToString();
    //        FichaOSAdc.VOUCHER = reader["VOUCHER"].ToString();
    //        xList.Add(FichaOSAdc);
    //    }

    //    return xList;
    //}

    public static List<FichasOSAdc> FiltroOSAdc(string DataIni, string DataFin, string Passeio, string Prestador, string Vendedor)
    {
        List<FichasOSAdc> xList = new List<FichasOSAdc>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        //DateTime DataOS = new DateTime(strData);
        //DateTime DataOS = Convert.ToDateTime(strData);


        str.AppendLine(" select distinct OS_ADC_NO, ID_SERV_AD_FICHA, DATA_OS_ADC, NOME_PRESTADOR AS FEITO_POR, OBS, FICHA_NO ");
        //str.AppendLine(" MOTORISTA_NO, GUIA_NO ");
        //str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
        //str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA ");
        str.AppendLine(" from SERV_AD_FICHA ");
        str.AppendLine(" inner join OS_ADC ");
        str.AppendLine(" on SERV_AD_FICHA.OS_ADC_NO = OS_ADC.ID_OS_ADC ");

        str.AppendLine(" LEFT JOIN PRESTADORES ON OS_ADC.FEITO_POR_NO = PRESTADORES.ID_PRESTADOR ");
        //str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
        //str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
        str.AppendLine(" WHERE ");
        str.AppendLine(" DATA_OS_ADC between @DATA_INI and @DATA_FIN ");
        

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
            FichasOSAdc OS = new FichasOSAdc();
            OS.ID_OS_ADC = Convert.ToInt64(reader["OS_ADC_NO"]);
            OS.ID_SERV_AD_FICHA = Convert.ToInt64(reader["ID_SERV_AD_FICHA"]);
            OS.DATA = reader["DATA_OS_ADC"].ToString();
            OS.FEITO_POR = reader["FEITO_POR"].ToString();
            OS.OBS_OS = reader["OBS"].ToString();
            OS.FICHA_NO = Convert.ToInt64(reader["FICHA_NO"]);
            //OS.MOTORISTA = reader["SIGLA_VOO"].ToString();
            //OS.GUIA = reader["NOME_PASSAGEIRO"].ToString();               
            xList.Add(OS);
        }

        return xList;
    }
}