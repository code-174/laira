using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for FichasListagem
/// </summary>
public class FichasListagem
{
    #region Propriedades
    public Int64 FICHA_NO { get; set; }
    public string COD_EXCURSAO { get; set; }
    public string DATA { get; set; }
    public string HORA { get; set; }
    public string AEROPORTO { get; set; }
    public string VOO { get; set; }
    public string PAX { get; set; }
    public string HOTEL { get; set; }
    public string APTO { get; set; }
    //public string OS_No { get; set; }
    public List<ServInFicha> ServicosInclusos
    {
        get
        {
            return ServInFicha.GetServInFicha(this.FICHA_NO);
        }
    }
    public List<ServAdFicha> ServicosAdicionais
    {
        get
        {
            return ServAdFicha.GetServAdFicha(this.FICHA_NO);
        }
    }
    #endregion
	public FichasListagem()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static List<FichasListagem> GetFichasListagem(string strTipo, string strData)
    {
        List<FichasListagem> xList = new List<FichasListagem>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        if (strTipo == "C")
        {
            str.AppendLine(" select ID_FICHA, COD_EXCURSAO_FICHA, DATA_CHEGADA_FICHA, VOO_CHEGADA_HORA_FICHA, AEROPORTO_CHEGADA_FICHA, ");
            str.AppendLine(" SIGLA_VOO, ");
            str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
            str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA ");
            str.AppendLine(" from FICHAS ");
            str.AppendLine(" LEFT JOIN VOOS ON FICHAS.VOO_CHEGADA_FICHA = VOOS.ID_VOO ");
            str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
            str.AppendLine(" WHERE ");
            str.AppendLine(" DATA_CHEGADA_FICHA  = @DATA_CHEGADA_FICHA ");

            cmd.CommandText = str.ToString();
            
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@DATA_CHEGADA_FICHA";
            parameter.Value = strData;
            cmd.Parameters.Add(parameter);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                FichasListagem FichaListagem = new FichasListagem();
                FichaListagem.FICHA_NO = Convert.ToInt64(reader["ID_FICHA"]);
                FichaListagem.COD_EXCURSAO = reader["COD_EXCURSAO_FICHA"].ToString();
                FichaListagem.DATA = reader["DATA_CHEGADA_FICHA"].ToString();
                FichaListagem.HORA = reader["VOO_CHEGADA_HORA_FICHA"].ToString();
                FichaListagem.AEROPORTO = reader["AEROPORTO_CHEGADA_FICHA"].ToString();
                FichaListagem.VOO = reader["SIGLA_VOO"].ToString();
                FichaListagem.PAX = reader["NOME_PASSAGEIRO"].ToString();
                FichaListagem.HOTEL = reader["HOTEL"].ToString();
                FichaListagem.APTO = reader["APARTAMENTO_FICHA"].ToString();
                xList.Add(FichaListagem);
            }

            return xList;
        }
        else
        {
            str.AppendLine(" select ID_FICHA, COD_EXCURSAO_FICHA, DATA_SAIDA_FICHA, VOO_SAIDA_HORA_FICHA, AEROPORTO_SAIDA_FICHA, ");
            str.AppendLine(" SIGLA_VOO, ");
            str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
            str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA ");
            str.AppendLine(" from FICHAS ");
            str.AppendLine(" LEFT JOIN VOOS ON FICHAS.VOO_SAIDA_FICHA = VOOS.ID_VOO ");
            str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
            str.AppendLine(" WHERE ");
            str.AppendLine(" DATA_SAIDA_FICHA  = @DATA_SAIDA_FICHA ");

            cmd.CommandText = str.ToString();

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@DATA_SAIDA_FICHA";
            parameter.Value = strData;
            cmd.Parameters.Add(parameter);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                FichasListagem FichaListagem = new FichasListagem();
                FichaListagem.FICHA_NO = Convert.ToInt64(reader["ID_FICHA"]);
                FichaListagem.COD_EXCURSAO = reader["COD_EXCURSAO_FICHA"].ToString();
                FichaListagem.DATA = reader["DATA_SAIDA_FICHA"].ToString();
                FichaListagem.HORA = reader["VOO_SAIDA_HORA_FICHA"].ToString();
                FichaListagem.AEROPORTO = reader["AEROPORTO_SAIDA_FICHA"].ToString();
                FichaListagem.VOO = reader["SIGLA_VOO"].ToString();
                FichaListagem.PAX = reader["NOME_PASSAGEIRO"].ToString();
                FichaListagem.HOTEL = reader["HOTEL"].ToString();
                FichaListagem.APTO = reader["APARTAMENTO_FICHA"].ToString();
                xList.Add(FichaListagem);
            }

            return xList;
        }

        
    }

    public static List<FichasListagem> FiltroFichasListagem(string strSelected, string strTipo, string strCriterio)
    {        
            List<FichasListagem> xList = new List<FichasListagem>();

            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
            cmd.Connection = conn;
            StringBuilder str = new StringBuilder();

            if (strTipo == "C")
            {
                str.AppendLine(" select ID_FICHA, COD_EXCURSAO_FICHA, DATA_CHEGADA_FICHA, VOO_CHEGADA_HORA_FICHA, AEROPORTO_CHEGADA_FICHA, ");
                str.AppendLine(" SIGLA_VOO, ");
                str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
                str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA ");
                str.AppendLine(" from FICHAS ");
                str.AppendLine(" LEFT JOIN VOOS ON FICHAS.VOO_CHEGADA_FICHA = VOOS.ID_VOO ");
                str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
                str.AppendLine(" WHERE ");
                if (strSelected == "F")
                {
                    str.AppendLine(" ID_FICHA  = @ID_FICHA ");

                    cmd.CommandText = str.ToString();

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@ID_FICHA";
                    parameter.Value = strCriterio;
                    cmd.Parameters.Add(parameter);
                }
                else
	            {
                    str.AppendLine(" COD_EXCURSAO_FICHA  = @COD_EXCURSAO_FICHA ");

                     cmd.CommandText = str.ToString();

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@COD_EXCURSAO_FICHA";
                    parameter.Value = strCriterio;
                    cmd.Parameters.Add(parameter);
	            }

                cmd.CommandText = str.ToString();
                                
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FichasListagem FichaListagem = new FichasListagem();
                    FichaListagem.FICHA_NO = Convert.ToInt64(reader["ID_FICHA"]);
                    FichaListagem.COD_EXCURSAO = reader["COD_EXCURSAO_FICHA"].ToString();
                    FichaListagem.DATA = reader["DATA_CHEGADA_FICHA"].ToString();
                    FichaListagem.HORA = reader["VOO_CHEGADA_HORA_FICHA"].ToString();
                    FichaListagem.AEROPORTO = reader["AEROPORTO_CHEGADA_FICHA"].ToString();
                    FichaListagem.VOO = reader["SIGLA_VOO"].ToString();
                    FichaListagem.PAX = reader["NOME_PASSAGEIRO"].ToString();
                    FichaListagem.HOTEL = reader["HOTEL"].ToString();
                    FichaListagem.APTO = reader["APARTAMENTO_FICHA"].ToString();
                    xList.Add(FichaListagem);
                }

                return xList;
            }
            else
            {
                str.AppendLine(" select ID_FICHA, COD_EXCURSAO_FICHA, DATA_SAIDA_FICHA, VOO_SAIDA_HORA_FICHA, AEROPORTO_SAIDA_FICHA, ");
                str.AppendLine(" SIGLA_VOO, ");
                str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
                str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA ");
                str.AppendLine(" from FICHAS ");
                str.AppendLine(" LEFT JOIN VOOS ON FICHAS.VOO_CHEGADA_FICHA = VOOS.ID_VOO ");
                str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
                str.AppendLine(" WHERE ");
                if (strSelected == "F")
                {
                    str.AppendLine(" ID_FICHA  = @ID_FICHA ");

                    cmd.CommandText = str.ToString();

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@ID_FICHA";
                    parameter.Value = strCriterio;
                    cmd.Parameters.Add(parameter);
                }
                else
                {
                    str.AppendLine(" COD_EXCURSAO_FICHA  = @COD_EXCURSAO_FICHA ");

                    cmd.CommandText = str.ToString();

                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@COD_EXCURSAO_FICHA";
                    parameter.Value = strCriterio;
                    cmd.Parameters.Add(parameter);
                }

                cmd.CommandText = str.ToString();

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    FichasListagem FichaListagem = new FichasListagem();
                    FichaListagem.FICHA_NO = Convert.ToInt64(reader["ID_FICHA"]);
                    FichaListagem.COD_EXCURSAO = reader["COD_EXCURSAO_FICHA"].ToString();
                    FichaListagem.DATA = reader["DATA_SAIDA_FICHA"].ToString();
                    FichaListagem.HORA = reader["VOO_SAIDA_HORA_FICHA"].ToString();
                    FichaListagem.AEROPORTO = reader["AEROPORTO_SAIDA_FICHA"].ToString();
                    FichaListagem.VOO = reader["SIGLA_VOO"].ToString();
                    FichaListagem.PAX = reader["NOME_PASSAGEIRO"].ToString();
                    FichaListagem.HOTEL = reader["HOTEL"].ToString();
                    FichaListagem.APTO = reader["APARTAMENTO_FICHA"].ToString();
                    xList.Add(FichaListagem);
                }

                return xList;
            }
        }
    
}