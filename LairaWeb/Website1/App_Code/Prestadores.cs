using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Prestadores
/// </summary>
public class Prestadores
{
    #region Propriedades
    public Int64 ID { get; set; }
    public string CODIGO { get; set; }
    public string NOME { get; set; }
    public string ENDERECO { get; set; }
    public string TELEFONE { get; set; }
    public string EMAIL { get; set; }
    #endregion

	public Prestadores()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Retornar Lista de Prestadores
    /// </summary>
    /// <returns></returns>
    public List<Prestadores> GetPrestadores()
    {
        List<Prestadores> xList = new List<Prestadores>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_PRESTADOR, CODIGO_PRESTADOR, NOME_PRESTADOR, ENDERECO_PRESTADOR, TELEFONE_PRESTADOR, EMAIL_PRESTADOR from PRESTADORES ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Prestadores Prestador = new Prestadores
            {
                ID = reader.GetInt64(0),
                CODIGO = reader.GetString(1),
                NOME = reader.GetString(2),
                ENDERECO = reader.GetString(3),
                TELEFONE = reader.GetString(4),
                EMAIL = reader.GetString(5)
            };

            xList.Add(Prestador);
        }

        return xList;
    }
    public List<Prestadores> GetPrestadoresCombo()
    {
        List<Prestadores> xList = new List<Prestadores>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_PRESTADOR, NOME_PRESTADOR from PRESTADORES ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Prestadores Prestador = new Prestadores
            {
                ID = reader.GetInt64(0),
                NOME = reader.IsDBNull(1) ? null : reader.GetString(1)
            };

            xList.Add(Prestador);
        }

        return xList;

    }
}