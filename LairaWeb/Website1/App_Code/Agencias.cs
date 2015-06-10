using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Agencias
/// </summary>
public class Agencias
{
    #region Propriedades
    public Int64 ID { get; set; }
    public string CODIGO { get; set; }
    public string NOME { get; set; }
    public string CONTATOS { get; set; }
    public string TELEFONE { get; set; }
    public string EMAIL { get; set; }
    #endregion

    public Agencias()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Retornar Lista de Agencias
    /// </summary>
    /// <returns></returns>
    public List<Agencias> GetAgencias()
    {
        List<Agencias> xList = new List<Agencias>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_AGENCIA, CODIGO_AGENCIA, NOME_AGENCIA, CONTATOS_AGENCIA, TELEFONE_AGENCIA, EMAIL_AGENCIA from AGENCIAS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Agencias Agencia = new Agencias
            {
                ID = reader.GetInt64(0),
                CODIGO = reader.GetString(1),
                NOME = reader.GetString(2),
                CONTATOS = reader.GetString(3),
                TELEFONE = reader.GetString(4),
                EMAIL = reader.GetString(5)
            };

            xList.Add(Agencia);
        }

        return xList;
    }


    public List<Agencias> GetAgenciasCombo()
    {
        List<Agencias> xList = new List<Agencias>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_AGENCIA , NOME_AGENCIA from AGENCIAS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Agencias Agencia = new Agencias
            {
                ID = reader.GetInt64(0),
                NOME = reader.GetString(1)
            };

            xList.Add(Agencia);
        }

        return xList;

    }

    public List<Agencias> GetAgenciasByCode(string strQuery)
    {
        List<Agencias> xList = new List<Agencias>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_AGENCIA, CODIGO_AGENCIA, NOME_AGENCIA, CONTATOS_AGENCIA, TELEFONE_AGENCIA, EMAIL_AGENCIA from AGENCIAS WHERE UPPER(CODIGO_AGENCIA) LIKE '%" + strQuery + "%'");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Agencias Agencia = new Agencias
            {
                ID = reader.GetInt64(0),
                CODIGO = reader.GetString(1),
                NOME = reader.GetString(2),
                CONTATOS = reader.GetString(3),
                TELEFONE = reader.GetString(4),
                EMAIL = reader.GetString(5)
            };

            xList.Add(Agencia);
        }

        return xList;
    }
}