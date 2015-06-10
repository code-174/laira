using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Aeroportos
/// </summary>
/// 

public class Aeroportos
{

    #region Propriedades
    public string CODIGO { get; set; }
    public string NOME { get; set; }
    #endregion

    public Aeroportos()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Retornar Lista de Aeroportos
    /// </summary>
    /// <returns></returns>
    public List<Aeroportos> GetAeroportos()
    {
        List<Aeroportos> xList = new List<Aeroportos>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select CODIGO_AEROPORTO, NOME_AEROPORTO from AEROPORTOS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Aeroportos Aeroporto = new Aeroportos
            {
                CODIGO = reader.GetString(0),
                NOME = reader.GetString(1)
            };

            xList.Add(Aeroporto);
        }

        return xList;
    }

    public List<Aeroportos> GetAeroportosByCode(string strQuery)
    {
        List<Aeroportos> xList = new List<Aeroportos>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select CODIGO_AEROPORTO, NOME_AEROPORTO from AEROPORTOS WHERE ( UPPER(CODIGO_AEROPORTO) ");
        str.AppendLine(" LIKE '%" + strQuery + "%' )");
        str.AppendLine("OR");
        str.AppendLine(" (UPPER(NOME_AEROPORTO)  LIKE '%" + strQuery + "%' )");

        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Aeroportos Aeroporto = new Aeroportos
            {
                CODIGO = reader.GetString(0),
                NOME = reader.GetString(1)
            };

            xList.Add(Aeroporto);
        }

        return xList;
    }
}