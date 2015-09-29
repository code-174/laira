﻿using System;
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
    public Int64 ID { get; set; }
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
        str.AppendLine(" select ID_AEROPORTO, CODIGO_AEROPORTO, NOME_AEROPORTO from AEROPORTOS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Aeroportos Aeroporto = new Aeroportos
            {
                ID = reader.GetInt64(0),
                CODIGO = reader.IsDBNull(1) ? null : reader.GetString(1),
                NOME = reader.IsDBNull(2) ? null : reader.GetString(2)
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

        str.AppendLine(" select ID_AEROPORTO, CODIGO_AEROPORTO, NOME_AEROPORTO from AEROPORTOS where ( UPPER(CODIGO_AEROPORTO) ");
        str.AppendLine(" like @CODIGO_AEROPORTO )");
        //str.AppendLine("OR");
        //str.AppendLine(" (UPPER(NOME_AEROPORTO)  LIKE '%" + strQuery + "%' )");

        cmd.CommandText = str.ToString();
        cmd.Parameters.AddWithValue("@CODIGO_AEROPORTO", "%" + strQuery + "%");
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Aeroportos Aeroporto = new Aeroportos
            {
                ID = reader.GetInt64(0),
                CODIGO = reader.IsDBNull(1) ? null : reader.GetString(1),
                NOME = reader.IsDBNull(2) ? null : reader.GetString(2)
            };

            xList.Add(Aeroporto);
        }

        return xList;
    }

    public List<Aeroportos> GetAeroportosByID(string strQuery)
    {
        List<Aeroportos> xList = new List<Aeroportos>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select ID_AEROPORTO, CODIGO_AEROPORTO, NOME_AEROPORTO from AEROPORTOS where ( ID_AEROPORTO = @ID_AEROPORTO)");
        cmd.CommandText = str.ToString();
        cmd.Parameters.AddWithValue("@ID_AEROPORTO",  strQuery );
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Aeroportos Aeroporto = new Aeroportos();
            Aeroporto.ID = Convert.ToInt64(reader["ID_AEROPORTO"]);
            Aeroporto.CODIGO = reader["CODIGO_AEROPORTO"].ToString();
            Aeroporto.NOME = reader["NOME_AEROPORTO"].ToString();
            xList.Add(Aeroporto);


            //Aeroportos Aeroporto = new Aeroportos
            //{
            //    ID = reader.GetInt64(0),
            //    CODIGO = reader.IsDBNull(1) ? null : reader.GetString(1),
            //    NOME = reader.IsDBNull(2) ? null : reader.GetString(2)
            //};

            //xList.Add(Aeroporto);
        }

        return xList;
    }

}