using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Depoimentos
/// </summary>
public class Depoimentos
{
    #region Propriedades
    public string CODIGO { get; set; }
    public string NOME { get; set; }
    public string CIDADE { get; set; }
    public string DEPOIMENTO { get; set; }
    #endregion

	public Depoimentos()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Retornar Lista de Depoimentos
    /// </summary>
    /// <returns></returns>
    public List<Depoimentos> GetDepoimentos()
    {
        List<Depoimentos> xList = new List<Depoimentos>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select CODIGO_DEPOIMENTO, NOME_DEPOIMENTO, CIDADE_DEPOIMENTO,  DEPOIMENTO_DEPOIMENTO from DEPOIMENTOS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Depoimentos Depoimento = new Depoimentos
            {
                CODIGO = reader.IsDBNull(0) ? null : reader.GetString(0),
                NOME = reader.IsDBNull(1) ? null : reader.GetString(1),
                CIDADE = reader.IsDBNull(2) ? null : reader.GetString(2),
                DEPOIMENTO = reader.IsDBNull(3) ? null : reader.GetString(3)
            };

            xList.Add(Depoimento);
        }

        return xList;
    }
}