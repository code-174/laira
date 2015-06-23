using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Hoteis
/// </summary>
public class Hoteis
{
    #region Propriedades
    public Int64 ID { get; set; }
    public string CODIGO { get; set; }
    public string NOME { get; set; }
    public string ENDERECO { get; set; }
    public string EMAIL { get; set; }
    public string TELEFONE { get; set; }
    public string HORA { get; set; }
    #endregion

	public Hoteis()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /// <summary>
    /// Retornar Lista de Vendedores
    /// </summary>
    /// <returns></returns>
    public List<Hoteis> GetHoteis()
    {
        List<Hoteis> xList = new List<Hoteis>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select CODIGO_HOTEL, NOME_HOTEL, ENDERECO_HOTEL,  EMAIL_HOTEL, TELEFONE_HOTEL, HORA_HOTEL from HOTEIS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Hoteis Hotel = new Hoteis
            {
                CODIGO = reader.IsDBNull(0) ? null : reader.GetString(0),
                NOME = reader.IsDBNull(1) ? null : reader.GetString(1),
                ENDERECO = reader.IsDBNull(2) ? null : reader.GetString(2),
                EMAIL = reader.IsDBNull(3) ? null : reader.GetString(3),
                TELEFONE = reader.IsDBNull(4) ? null : reader.GetString(4),
                HORA = reader.IsDBNull(5) ? null : reader.GetString(5)
            };

            xList.Add(Hotel);
        }

        return xList;
    }
    public List<Hoteis> GetHoteisCombo()
    {
        List<Hoteis> xList = new List<Hoteis>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_HOTEL , NOME_HOTEL from HOTEIS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Hoteis Hotel = new Hoteis
            {
                ID = reader.GetInt64(0),
                NOME = reader.IsDBNull(1) ? null : reader.GetString(1)
            };

            xList.Add(Hotel);
        }

        return xList;

    }
}