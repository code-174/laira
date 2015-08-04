using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for ServAdFicha
/// </summary>
public class ServAdFicha
{
    #region Propriedades
    public string SERV_AD { get; set; }
    public string VOUCHER { get; set; }
    public string PRECO { get; set; }
    public string DATA { get; set; }
    public string HORA { get; set; }
    public string VENDEDOR { get; set; }
    #endregion

	public ServAdFicha()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Retornar Lista de SERV_IN_FICHA
    /// </summary>
    /// <returns></returns>
    public static List<ServAdFicha> GetServAdFicha(Int64 IdFicha)
    {
        List<ServAdFicha> xList = new List<ServAdFicha>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select PASSEIO_SERV_ADC, VOUCHER, REPLACE (CAST(VALOR AS VARCHAR(100)),'.' ,',') AS PRECO, ");
        str.AppendLine(" DATA, HORA, NOME_VENDEDOR ");
        str.AppendLine(" from SERV_AD_FICHA ");
        str.AppendLine(" left join SERV_ADC on SERV_AD_FICHA.SERV_AD_NO = SERV_ADC.ID_SERV_ADC ");
        str.AppendLine(" left join VENDEDORES on SERV_AD_FICHA.VENDEDOR_NO = VENDEDORES.ID_VENDEDOR ");
        str.AppendLine(" where FICHA_NO = @ID_FICHA ");
        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@ID_FICHA";
        parameter.Value = IdFicha;
        cmd.Parameters.Add(parameter);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            ServAdFicha ServicosAdicionaisFicha = new ServAdFicha();
            ServicosAdicionaisFicha.SERV_AD = reader["PASSEIO_SERV_ADC"].ToString();
            ServicosAdicionaisFicha.VOUCHER = reader["VOUCHER"].ToString();
            ServicosAdicionaisFicha.PRECO = reader["PRECO"].ToString();
            ServicosAdicionaisFicha.DATA = reader["DATA"].ToString();
            ServicosAdicionaisFicha.HORA = reader["HORA"].ToString();
            ServicosAdicionaisFicha.VENDEDOR = reader["NOME_VENDEDOR"].ToString();

            xList.Add(ServicosAdicionaisFicha);


        }

        return xList;
    }
}