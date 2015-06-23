using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Voos
/// </summary>
public class Voos
{
    #region Propriedades
    public Int64 ID { get; set; }
    public string NOME { get; set; }
    public string SIGLA { get; set; }
    public string HORA { get; set; }
    public string AEROPORTO { get; set; }
    public string TIPO { get; set; }
    #endregion

    public Voos()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Retornar Lista de Voos
    /// </summary>
    /// <returns></returns>
    public List<Voos> GetVoos()
    {
        List<Voos> xList = new List<Voos>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select NOME_VOO, SIGLA_VOO, HORA_VOO, AEROPORTO_VOO, TIPO_VOO from VOOS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Voos Voo = new Voos
            {
                NOME = reader.IsDBNull(0) ? null : reader.GetString(0),
                SIGLA = reader.IsDBNull(1) ? null : reader.GetString(1),
                HORA = reader.IsDBNull(2) ? null : reader.GetString(2),
                AEROPORTO = reader.IsDBNull(3) ? null : reader.GetString(3),
                TIPO = reader.IsDBNull(4) ? null : reader.GetString(4)
            };

            xList.Add(Voo);
        }

        return xList;
    }

    public List<Voos> GetVooChegadaCombo()
    {
        List<Voos> xList = new List<Voos>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_VOO , SIGLA_VOO from VOOS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Voos Voo = new Voos
            {
                ID = reader.GetInt64(0),
                SIGLA = reader.IsDBNull(1) ? null : reader.GetString(1)
            };

            xList.Add(Voo);
        }

        return xList;

    }

    public List<Voos> GetVooSaidaCombo()
    {
        List<Voos> xList = new List<Voos>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_VOO , SIGLA_VOO from VOOS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Voos Voo = new Voos
            {
                ID = reader.GetInt64(0),
                SIGLA = reader.IsDBNull(1) ? null : reader.GetString(1)
            };

            xList.Add(Voo);
        }

        return xList;

    }
}