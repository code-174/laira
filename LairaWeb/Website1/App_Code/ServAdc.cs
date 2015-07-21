using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for ServAdc
/// </summary>
public class ServAdc
{
    #region Propriedades
    public Int64 ID { get; set; }
    public string CODIGO { get; set; }
    public string PASSEIO { get; set; }
    public decimal PRECO { get; set; }
    #endregion

	public ServAdc()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Retornar Lista de Servicos Adicionais
    /// </summary>
    /// <returns></returns>
    public List<ServAdc> GetServAdc()
    {
        List<ServAdc> xList = new List<ServAdc>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_SERV_ADC, COD_SERV_ADC, PASSEIO_SERV_ADC, PRECO_SERV_ADC from SERV_ADC ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            ServAdc ServicoAdicional = new ServAdc
            {
                ID = reader.GetInt64(0),
                CODIGO = reader.IsDBNull(1) ? null : reader.GetString(1),
                PASSEIO = reader.IsDBNull(2) ? null : reader.GetString(2),
                PRECO = reader.GetDecimal(3)
            };

            xList.Add(ServicoAdicional);
        }

        return xList;
    }
    public List<ServAdc> GetServAdcCombo()
    {
        List<ServAdc> xList = new List<ServAdc>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_SERV_ADC, PASSEIO_SERV_ADC from SERV_ADC ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            ServAdc ServicoAdicional = new ServAdc
            {
                ID = reader.GetInt64(0),
                PASSEIO = reader.IsDBNull(1) ? null : reader.GetString(1)
            };

            xList.Add(ServicoAdicional);
        }

        return xList;

    }
}