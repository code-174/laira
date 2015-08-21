using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;


/// <summary>
/// Summary description for Fichas
/// </summary>
public class Fichas
{

    #region Propriedades
    public string No_FICHA { get; set; }
    public string COD_EXCURSAO { get; set; }
    public string DATA { get; set; }
    public string HORA { get; set; }
    public string AEROPORTO { get; set; }
    public string VOO { get; set; }
    public string PAX { get; set; }
    public string HOTEL { get; set; }
    public string OS_No { get; set; }
    public string SERV_IN { get; set; }
    public string SERV_AD { get; set; }
    public string OBS { get; set; }
    #endregion

    public Fichas()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Fichas> GetFichasByTypeNDate(string TipoFicha, string DataFicha)
    {
        List<Fichas> xList = new List<Fichas>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select ");
        switch (TipoFicha)
        {
            case "C"://Chegada           
                str.AppendLine(" cast(ID_FICHA as VARCHAR(10)), DATA_CHEGADA_FICHA, VOO_CHEGADA_HORA_FICHA, SIGLA_VOO, AEROPORTO_CHEGADA_FICHA, COD_EXCURSAO_FICHA, ISNULL(NOME_HOTEL, '---') , dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO   from FICHAS LEFT JOIN VOOS ON FICHAS.VOO_CHEGADA_FICHA = VOOS.ID_VOO  LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL  ");
                str.AppendLine(" WHERE ");
                str.AppendLine(" DATA_CHEGADA_FICHA  = '" + DataFicha + "'");
                break;
            case "S": //Saida
                str.AppendLine(" cast(ID_FICHA as VARCHAR(10)), DATA_SAIDA_FICHA, VOO_SAIDA_HORA_FICHA, SIGLA_VOO, AEROPORTO_SAIDA_FICHA, COD_EXCURSAO_FICHA, ISNULL(NOME_HOTEL, '---') , dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO   from FICHAS LEFT JOIN VOOS ON FICHAS.VOO_SAIDA_FICHA = VOOS.ID_VOO  LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
                str.AppendLine(" WHERE ");
                str.AppendLine("  DATA_SAIDA_FICHA='" + DataFicha + "'");
                break;
            default:
                break;
        }

        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Fichas Ficha = new Fichas
            {
                No_FICHA = reader.IsDBNull(0) ? null : reader.GetString(0),
                COD_EXCURSAO = reader.IsDBNull(5) ? null : reader.GetString(5),
                DATA = reader.IsDBNull(1) ? null : reader.GetString(1),
                HORA = reader.IsDBNull(2) ? null : reader.GetString(2),
                AEROPORTO = reader.IsDBNull(4) ? null : reader.GetString(4),
                VOO = reader.IsDBNull(3) ? null : reader.GetString(3),
                PAX = reader.IsDBNull(7) ? null : reader.GetString(7),
                HOTEL = reader.IsDBNull(6) ? null : reader.GetString(6),
                OS_No = string.Empty,
                SERV_IN = string.Empty,
                SERV_AD = string.Empty,
                OBS = string.Empty

            };

            xList.Add(Ficha);
        }

        return xList;

    }


    public List<Fichas> GetFichas(string strQuery, string Chave)
    {
        List<Fichas> xList = new List<Fichas>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select ");

        switch (strQuery)
        {
            case "1"://1 e 3                
                str.AppendLine(" cast(ID_FICHA as VARCHAR(10)), DATA_CHEGADA_FICHA, VOO_CHEGADA_HORA_FICHA, SIGLA_VOO, AEROPORTO_CHEGADA_FICHA, COD_EXCURSAO_FICHA, ISNULL(NOME_HOTEL, '---') , dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO   from FICHAS LEFT JOIN VOOS ON FICHAS.VOO_CHEGADA_FICHA = VOOS.ID_VOO  LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL  ");
                str.AppendLine(" WHERE ");
                str.AppendLine(" DATA_CHEGADA_FICHA  = '" + Chave + "'");
                break;

            case "3"://1 e 3                
                str.AppendLine(" cast(ID_FICHA as VARCHAR(10)), DATA_CHEGADA_FICHA, VOO_CHEGADA_HORA_FICHA, SIGLA_VOO, AEROPORTO_CHEGADA_FICHA, COD_EXCURSAO_FICHA, ISNULL(NOME_HOTEL, '---') , dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO   from FICHAS LEFT JOIN VOOS ON FICHAS.VOO_CHEGADA_FICHA = VOOS.ID_VOO  LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL  ");
                str.AppendLine(" WHERE ");
                str.AppendLine(" DATA_CHEGADA_FICHA  = '" + Chave + "'");
                break;

            case "2": //2 e 4
                str.AppendLine(" cast(ID_FICHA as VARCHAR(10)), DATA_SAIDA_FICHA, VOO_SAIDA_HORA_FICHA, SIGLA_VOO, AEROPORTO_SAIDA_FICHA, COD_EXCURSAO_FICHA, ISNULL(NOME_HOTEL, '---') , dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO   from FICHAS LEFT JOIN VOOS ON FICHAS.VOO_SAIDA_FICHA = VOOS.ID_VOO  LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
                str.AppendLine(" WHERE ");
                str.AppendLine("  DATA_SAIDA_FICHA='" + Chave + "'");
                break;
            case "4": //2 e 4
                str.AppendLine(" cast(ID_FICHA as VARCHAR(10)), DATA_SAIDA_FICHA, VOO_SAIDA_HORA_FICHA, SIGLA_VOO, AEROPORTO_SAIDA_FICHA, COD_EXCURSAO_FICHA, ISNULL(NOME_HOTEL, '---') , dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO   from FICHAS LEFT JOIN VOOS ON FICHAS.VOO_SAIDA_FICHA = VOOS.ID_VOO  LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
                str.AppendLine(" WHERE ");
                str.AppendLine("  DATA_SAIDA_FICHA='" + Chave + "'");
                break;
            case "5":
                str.AppendLine(" cast(ID_FICHA as VARCHAR(10)), DATA_SAIDA_FICHA, VOO_SAIDA_HORA_FICHA, SIGLA_VOO, AEROPORTO_SAIDA_FICHA, COD_EXCURSAO_FICHA, ISNULL(NOME_HOTEL, '---') , dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO   from FICHAS LEFT JOIN VOOS ON FICHAS.VOO_SAIDA_FICHA = VOOS.ID_VOO  LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
                str.AppendLine(" WHERE ");
                str.AppendLine("  cast(ID_FICHA as VARCHAR(10)) ='" + Chave + "'");
                break;
            case "6":
                str.AppendLine(" cast(ID_FICHA as VARCHAR(10)), DATA_SAIDA_FICHA, VOO_SAIDA_HORA_FICHA, SIGLA_VOO, AEROPORTO_SAIDA_FICHA, COD_EXCURSAO_FICHA, ISNULL(NOME_HOTEL, '---') , dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO   from FICHAS LEFT JOIN VOOS ON FICHAS.VOO_SAIDA_FICHA = VOOS.ID_VOO  LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
                str.AppendLine(" WHERE ");
                str.AppendLine("  COD_EXCURSAO_FICHA ='" + Chave + "'");
                break;
            default:
                break;
        }


        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Fichas Ficha = new Fichas
            {

                No_FICHA = reader.IsDBNull(0) ? null : reader.GetString(0),
                COD_EXCURSAO = reader.IsDBNull(5) ? null : reader.GetString(5),
                DATA = reader.IsDBNull(1) ? null : reader.GetString(1),
                HORA = reader.IsDBNull(2) ? null : reader.GetString(2),
                AEROPORTO = reader.IsDBNull(4) ? null : reader.GetString(4),
                VOO = reader.IsDBNull(3) ? null : reader.GetString(3),
                PAX = reader.IsDBNull(7) ? null : reader.GetString(7),
                HOTEL = reader.IsDBNull(6) ? null : reader.GetString(6),
                OS_No = string.Empty,
                SERV_IN = string.Empty,
                SERV_AD = string.Empty,
                OBS = string.Empty

            };

            xList.Add(Ficha);
        }

        return xList;
    }



    public Int64 GetLastFicha()
    {

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select MAX(ID_FICHA) from FICHAS ");
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

    public void UpdateOSFicha(string Tipo, Int64 OS_NO, Int64 FICHA_NO)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        if (Tipo == "C")
        {
            str.AppendLine(" update FICHAS ");
            str.AppendLine(" set OS_CHEGADA = @OS_NO ");
            str.AppendLine(" where ID_FICHA = @FICHA_NO "); 
        }
        else
        {
            str.AppendLine(" update FICHAS ");
            str.AppendLine(" set OS_SAIDA = @OS_NO ");
            str.AppendLine(" where ID_FICHA = @FICHA_NO "); 
        }

        cmd.CommandText = str.ToString();
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@OS_NO", SqlDbType.BigInt)).Value = OS_NO;
        cmd.Parameters.Add(new SqlParameter("@FICHA_NO", SqlDbType.BigInt)).Value = FICHA_NO;

        conn.Open();

        cmd.ExecuteNonQuery();

        cmd.Dispose();
        cmd = null;
        conn.Close();
        conn.Dispose();

    }

}