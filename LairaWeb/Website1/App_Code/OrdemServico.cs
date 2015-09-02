﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for OrdemServico
/// </summary>
public class OrdemServico
{
    #region Propriedades
    public Int64 ID_OS { get; set; }
    public string TIPO_OS { get; set; }
    public string DATA { get; set; }
    public string FEITO_POR { get; set; }
    public string OBS_OS { get; set; }
    public string MOTORISTA { get; set; }
    public string GUIA { get; set; }

    public List<FichasListagem> FichasLista
    {
        get
        {
            return FichasListagem.GetRelatorioFichasOS(this.ID_OS, this.TIPO_OS);
        }
    }
    #endregion
    public OrdemServico()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public Int64 getLastOS()
    {

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select MAX(ID_ORDEM_SERV) from ORDEM_SERV ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        Int64 retorno = 0;
        while (reader.Read())
        {
            retorno = reader.GetInt64(0);
        }

        return retorno;
    }

    public static List<OrdemServico> GetOS(string strTipo, string strData)
    {
        List<OrdemServico> xList = new List<OrdemServico>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        //DateTime DataOS = new DateTime(strData);
        DateTime DataOS = Convert.ToDateTime(strData);


        if (strTipo == "C")
        {
            str.AppendLine(" select ID_ORDEM_SERV, TIPO_SERVICO, DATA, NOME_PRESTADOR AS FEITO_POR, OBS_ORDEM_SERV ");
            //str.AppendLine(" MOTORISTA_NO, GUIA_NO ");
            //str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
            //str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA ");
            str.AppendLine(" from ORDEM_SERV ");
            str.AppendLine(" LEFT JOIN PRESTADORES ON ORDEM_SERV.FEITO_POR_NO = PRESTADORES.ID_PRESTADOR ");
            //str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
            //str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
            str.AppendLine(" WHERE ");
            str.AppendLine(" DATA  = @DATA ");
            //str.AppendLine(" AND OS_CHEGADA IS NULL ");

            cmd.CommandText = str.ToString();

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@DATA";
            parameter.Value = DataOS;
            cmd.Parameters.Add(parameter);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                OrdemServico OS = new OrdemServico();
                OS.ID_OS = Convert.ToInt64(reader["ID_ORDEM_SERV"]);
                OS.TIPO_OS = reader["TIPO_SERVICO"].ToString();
                OS.DATA = reader["DATA"].ToString();
                OS.FEITO_POR = reader["FEITO_POR"].ToString();
                OS.OBS_OS = reader["OBS_ORDEM_SERV"].ToString();
                //OS.MOTORISTA = reader["SIGLA_VOO"].ToString();
                //OS.GUIA = reader["NOME_PASSAGEIRO"].ToString();               
                xList.Add(OS);
            }

            return xList;
        }
        else
        {
            str.AppendLine(" select ID_ORDEM_SERV, TIPO_SERVICO, DATA, NOME_PRESTADOR AS FEITO_POR, OBS_ORDEM_SERV ");
            //str.AppendLine(" MOTORISTA_NO, GUIA_NO ");
            //str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
            //str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA ");
            str.AppendLine(" from ORDEM_SERV ");
            str.AppendLine(" LEFT JOIN PRESTADORES ON ORDEM_SERV.FEITO_POR_NO = PRESTADORES.ID_PRESTADOR ");
            //str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
            //str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
            str.AppendLine(" WHERE ");
            str.AppendLine(" DATA  = @DATA ");
            //str.AppendLine(" AND OS_SAIDA IS NULL ");
            //str.AppendLine(" group by ID_FICHA ");

            cmd.CommandText = str.ToString();

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@DATA";
            parameter.Value = DataOS;
            cmd.Parameters.Add(parameter);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                OrdemServico OS = new OrdemServico();
                OS.ID_OS = Convert.ToInt64(reader["ID_ORDEM_SERV"]);
                OS.TIPO_OS = reader["TIPO_SERVICO"].ToString();
                OS.DATA = reader["DATA"].ToString();
                OS.FEITO_POR = reader["FEITO_POR"].ToString();
                OS.OBS_OS = reader["OBS_ORDEM_SERV"].ToString();
                //OS.MOTORISTA = reader["SIGLA_VOO"].ToString();
                //OS.GUIA = reader["NOME_PASSAGEIRO"].ToString();               
                xList.Add(OS);
            }

            return xList;
        }

    }

    public static List<OrdemServico> GetOSByNo(string OS_NO)
    {
        List<OrdemServico> xList = new List<OrdemServico>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();


        str.AppendLine(" select ID_ORDEM_SERV, TIPO_SERVICO, DATA, NOME_PRESTADOR AS FEITO_POR, OBS_ORDEM_SERV ");
        //str.AppendLine(" MOTORISTA_NO, GUIA_NO ");
        //str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
        //str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA ");
        str.AppendLine(" from ORDEM_SERV ");
        str.AppendLine(" LEFT JOIN PRESTADORES ON ORDEM_SERV.FEITO_POR_NO = PRESTADORES.ID_PRESTADOR ");
        //str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
        //str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
        str.AppendLine(" WHERE ");
        str.AppendLine(" ID_ORDEM_SERV = @OS_NO ");
        //str.AppendLine(" AND OS_CHEGADA IS NULL ");

        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@OS_NO";
        parameter.Value = OS_NO;
        cmd.Parameters.Add(parameter);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            OrdemServico OS = new OrdemServico();
            OS.ID_OS = Convert.ToInt64(reader["ID_ORDEM_SERV"]);
            OS.TIPO_OS = reader["TIPO_SERVICO"].ToString();
            OS.DATA = reader["DATA"].ToString();
            OS.FEITO_POR = reader["FEITO_POR"].ToString();
            OS.OBS_OS = reader["OBS_ORDEM_SERV"].ToString();
            //OS.MOTORISTA = reader["SIGLA_VOO"].ToString();
            //OS.GUIA = reader["NOME_PASSAGEIRO"].ToString();               
            xList.Add(OS);
        }

        return xList;
    }


}