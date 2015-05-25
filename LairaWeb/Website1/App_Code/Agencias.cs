﻿using System;
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
        str.AppendLine(" select CODIGO_AGENCIA, NOME_AGENCIA, CONTATOS_AGENCIA, TELEFONE_AGENCIA, EMAIL_AGENCIA from AGENCIAS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Agencias Agencia = new Agencias
            {
                CODIGO = reader.GetString(0),
                NOME = reader.GetString(1),
                CONTATOS = reader.GetString(2),
                TELEFONE = reader.GetString(3),
                EMAIL = reader.GetString(4)
            };

            xList.Add(Agencia);
        }

        return xList;
    }
}