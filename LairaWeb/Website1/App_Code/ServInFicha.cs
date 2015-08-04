﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for ServInFicha
/// </summary>
public class ServInFicha
{
    #region Propriedades
    public Int64 ID { get; set; }
    public string PRECO { get; set; }
    public Int64 FORMA_PAG_NO { get; set; }
    public string SERV_IN { get; set; }
    #endregion

	public ServInFicha()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Retornar Lista de SERV_IN_FICHA
    /// </summary>
    /// <returns></returns>
    public static List<ServInFicha> GetServInFicha(Int64 IdFicha)
    {
        List<ServInFicha> xList = new List<ServInFicha>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_SERV_IN_FICHA, REPLACE (CAST(VALOR AS VARCHAR(100)),'.' ,',') AS PRECO, ");
        str.AppendLine(" FORMA_PAG_NO, SERVICO_SERV_INCLUSO ");
        str.AppendLine(" from SERV_IN_FICHA ");
        str.AppendLine(" left join SERV_INCLUSO on SERV_IN_FICHA.SERV_IN_NO = SERV_INCLUSO.ID_SERV_INCLUSO ");
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
            ServInFicha ServicosInclusosFicha = new ServInFicha();
            ServicosInclusosFicha.ID = Convert.ToInt64(reader["ID_SERV_IN_FICHA"]);            
            ServicosInclusosFicha.PRECO = reader["PRECO"].ToString();
            ServicosInclusosFicha.FORMA_PAG_NO = Convert.ToInt64(reader["FORMA_PAG_NO"]);
            ServicosInclusosFicha.SERV_IN = reader["SERVICO_SERV_INCLUSO"].ToString();
                
            xList.Add(ServicosInclusosFicha);
        }

        return xList;
    }
}