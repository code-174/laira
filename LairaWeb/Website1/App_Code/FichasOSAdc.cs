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
    public Int64 FICHA_NO { get; set; }
    public string HORA { get; set; }
    public string HOTEL { get; set; }
    public string APTO { get; set; }
    public string PASSEIO { get; set; }
    public string PAX { get; set; }
    public string FORMA_PAG { get; set; }
    public string VOUCHER { get; set; }    
    #endregion  
	public FichasOSAdc()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static List<FichasOSAdc> GetFichasOS(string strData)
    {
        List<FichasOSAdc> xList = new List<FichasOSAdc>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();


        str.AppendLine(" select FICHA_NO, HORA, ");
        str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA, ");
        str.AppendLine(" PASSEIO_SERV_ADC, ");
        str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
        str.AppendLine(" FORMA_DE_PAGAMENTO, ");
        str.AppendLine(" ISNULL(VOUCHER, '---') AS VOUCHER ");
        str.AppendLine(" from SERV_AD_FICHA ");
        str.AppendLine(" inner join FICHAS ");
        str.AppendLine(" on SERV_AD_FICHA.FICHA_NO = FICHAS.ID_FICHA ");
        str.AppendLine(" left join SERV_ADC on SERV_AD_FICHA.SERV_AD_NO = SERV_ADC.ID_SERV_ADC ");
        str.AppendLine(" left join FORMA_DE_PAGAMENTO on SERV_AD_FICHA.FORMA_PAG_NO = FORMA_DE_PAGAMENTO.ID_FORMA_DE_PAGAMENTO ");
        str.AppendLine(" left join HOTEIS on FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
        str.AppendLine(" where ");
        str.AppendLine(" DATA  = @DATA ");
        str.AppendLine(" and OS_ADC_NO is null ");

        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@DATA";
        parameter.Value = strData;
        cmd.Parameters.Add(parameter);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            FichasOSAdc FichaOSAdc = new FichasOSAdc();
            FichaOSAdc.FICHA_NO = Convert.ToInt64(reader["FICHA_NO"]);
            FichaOSAdc.HORA = reader["HORA"].ToString();
            FichaOSAdc.HOTEL = reader["HOTEL"].ToString();
            FichaOSAdc.APTO = reader["APARTAMENTO_FICHA"].ToString();
            FichaOSAdc.PASSEIO = reader["PASSEIO_SERV_ADC"].ToString();
            FichaOSAdc.PAX = reader["NOME_PASSAGEIRO"].ToString();
            FichaOSAdc.FORMA_PAG = reader["FORMA_DE_PAGAMENTO"].ToString();
            FichaOSAdc.VOUCHER = reader["VOUCHER"].ToString();
            xList.Add(FichaOSAdc);
        }

        return xList;
    }
}