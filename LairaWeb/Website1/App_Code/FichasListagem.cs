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
    public Int64 ID_SERV_AD_FICHA { get; set; }
    public Int64 PASSEIO_NO { get; set; }
    public string COD_EXCURSAO { get; set; }
    public string DATA { get; set; }
    public string HORA { get; set; }
    public string AEROPORTO { get; set; }
    public string VOO { get; set; }
    public string QUANT_PAX { get; set; }
    public string PAX { get; set; }
    public string HOTEL { get; set; }
    public string APTO { get; set; }
    public string OS_No { get; set; }
    public string PASSEIO { get; set; }
    public string FORMA_PAG { get; set; }
    public string VOUCHER { get; set; }
    public string VENDEDOR { get; set; }
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

    public static List<FichasListagem> GetFichasOS(string strTipo, string strData)
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
            str.AppendLine(" AND OS_CHEGADA IS NULL ");

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
            //str.AppendLine(" count(dbo.getpax(FICHAS.ID_FICHA)) AS QUANT_PASSAGEIRO, ");
            str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
            str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA ");
            str.AppendLine(" from FICHAS ");
            str.AppendLine(" LEFT JOIN VOOS ON FICHAS.VOO_SAIDA_FICHA = VOOS.ID_VOO ");
            str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
            str.AppendLine(" WHERE ");
            str.AppendLine(" DATA_SAIDA_FICHA  = @DATA_SAIDA_FICHA ");
            str.AppendLine(" AND OS_SAIDA IS NULL ");
            //str.AppendLine(" group by ID_FICHA ");

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
                //FichaListagem.QUANT_PAX = reader["QUANT_PASSAGEIRO"].ToString();
                FichaListagem.PAX = reader["NOME_PASSAGEIRO"].ToString();
                FichaListagem.HOTEL = reader["HOTEL"].ToString();
                FichaListagem.APTO = reader["APARTAMENTO_FICHA"].ToString();
                xList.Add(FichaListagem);
            }

            return xList;
        }

    }

    public static List<FichasListagem> GetFichasOSAdc(string strData)
    {
        List<FichasListagem> xList = new List<FichasListagem>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();


        str.AppendLine(" select ID_SERV_AD_FICHA, FICHA_NO, SERV_AD_NO, HORA, ");
        str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA, ");
        str.AppendLine(" PASSEIO_SERV_ADC, ");
        str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
        str.AppendLine(" FORMA_DE_PAGAMENTO, ");
        str.AppendLine(" ISNULL(VOUCHER, '---') AS VOUCHER ");
        str.AppendLine(" from SERV_AD_FICHA ");
        str.AppendLine(" inner join FICHAS ");
        str.AppendLine(" on SERV_AD_FICHA.FICHA_NO = FICHAS.ID_FICHA ");
        str.AppendLine(" left join SERV_ADC on SERV_AD_FICHA.SERV_AD_NO = SERV_ADC.ID_SERV_ADC ");
        str.AppendLine(" left join FORMA_DE_PAGAMENTO on SERV_AD_FICHA.FORMA_PAG_NO = FORMA_DE_PAGAMENTO.ID_FORMA_DE_PAGAMENTO ");
        str.AppendLine(" left join HOTEIS on FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
        str.AppendLine(" where ");
        str.AppendLine(" DATA  = @DATA ");
        str.AppendLine(" and OS_ADC_NO is null ");

        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@DATA";
        parameter.Value = strData;
        cmd.Parameters.Add(parameter);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            FichasListagem FichaListagem = new FichasListagem();
            FichaListagem.ID_SERV_AD_FICHA = Convert.ToInt64(reader["ID_SERV_AD_FICHA"]);
            FichaListagem.FICHA_NO = Convert.ToInt64(reader["FICHA_NO"]);
            FichaListagem.PASSEIO_NO = Convert.ToInt64(reader["SERV_AD_NO"]);
            FichaListagem.HORA = reader["HORA"].ToString();
            FichaListagem.HOTEL = reader["HOTEL"].ToString();
            FichaListagem.APTO = reader["APARTAMENTO_FICHA"].ToString();
            FichaListagem.PASSEIO = reader["PASSEIO_SERV_ADC"].ToString();
            FichaListagem.PAX = reader["NOME_PASSAGEIRO"].ToString();
            FichaListagem.FORMA_PAG = reader["FORMA_DE_PAGAMENTO"].ToString();
            FichaListagem.VOUCHER = reader["VOUCHER"].ToString();
            xList.Add(FichaListagem);
        }

        return xList;
    }

    public static List<FichasListagem> GetRelatorioFichasOS(Int64 ID_OS, string TIPO_OS)
    {
        List<FichasListagem> xList = new List<FichasListagem>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        if (TIPO_OS == "C")
        {
            str.AppendLine(" select ID_FICHA, VOO_CHEGADA_HORA_FICHA, SIGLA_VOO, AEROPORTO_CHEGADA_FICHA, ");
            str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
            str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL ");
            str.AppendLine(" from FICHAS ");
            str.AppendLine(" LEFT JOIN VOOS ON FICHAS.VOO_CHEGADA_FICHA = VOOS.ID_VOO ");
            str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
            str.AppendLine(" WHERE ");
            str.AppendLine(" OS_CHEGADA  = @ID_OS ");

            cmd.CommandText = str.ToString();

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID_OS";
            parameter.Value = ID_OS;
            cmd.Parameters.Add(parameter);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                FichasListagem FichaListagem = new FichasListagem();
                FichaListagem.FICHA_NO = Convert.ToInt64(reader["ID_FICHA"]);
                FichaListagem.HORA = reader["VOO_CHEGADA_HORA_FICHA"].ToString();
                FichaListagem.VOO = reader["SIGLA_VOO"].ToString();
                FichaListagem.AEROPORTO = reader["AEROPORTO_CHEGADA_FICHA"].ToString();
                FichaListagem.PAX = reader["NOME_PASSAGEIRO"].ToString();
                FichaListagem.HOTEL = reader["HOTEL"].ToString();
                xList.Add(FichaListagem);
            }

            return xList;
        }
        else
        {
            str.AppendLine(" select ID_FICHA, VOO_SAIDA_HORA_FICHA, SIGLA_VOO, AEROPORTO_SAIDA_FICHA, ");
            str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
            str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL ");
            str.AppendLine(" from FICHAS ");
            str.AppendLine(" LEFT JOIN VOOS ON FICHAS.VOO_SAIDA_FICHA = VOOS.ID_VOO ");
            str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
            str.AppendLine(" WHERE ");
            str.AppendLine(" OS_SAIDA  = @ID_OS ");

            cmd.CommandText = str.ToString();

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@ID_OS";
            parameter.Value = ID_OS;
            cmd.Parameters.Add(parameter);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                FichasListagem FichaListagem = new FichasListagem();
                FichaListagem.FICHA_NO = Convert.ToInt64(reader["ID_FICHA"]);
                FichaListagem.HORA = reader["VOO_SAIDA_HORA_FICHA"].ToString();
                FichaListagem.VOO = reader["SIGLA_VOO"].ToString();
                FichaListagem.AEROPORTO = reader["AEROPORTO_SAIDA_FICHA"].ToString();
                FichaListagem.PAX = reader["NOME_PASSAGEIRO"].ToString();
                FichaListagem.HOTEL = reader["HOTEL"].ToString();
                xList.Add(FichaListagem);
            }

            return xList;
        }

    }

    public static List<FichasListagem> GetRelatorioFichasOSAdc(Int64 ID_OS_ADC)
    {
        List<FichasListagem> xList = new List<FichasListagem>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();


        str.AppendLine(" select ID_SERV_AD_FICHA, FICHA_NO, SERV_AD_NO, HORA, ");
        str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL, APARTAMENTO_FICHA, ");
        str.AppendLine(" PASSEIO_SERV_ADC, ");
        str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
        str.AppendLine(" FORMA_DE_PAGAMENTO, ");
        str.AppendLine(" NOME_VENDEDOR ");
        str.AppendLine(" from SERV_AD_FICHA ");
        str.AppendLine(" inner join OS_ADC ");
        str.AppendLine(" on SERV_AD_FICHA.OS_ADC_NO = OS_ADC.ID_OS_ADC ");
        str.AppendLine(" left join FICHAS on SERV_AD_FICHA.FICHA_NO = FICHAS.ID_FICHA ");
        str.AppendLine(" left join SERV_ADC on SERV_AD_FICHA.SERV_AD_NO = SERV_ADC.ID_SERV_ADC ");
        str.AppendLine(" left join FORMA_DE_PAGAMENTO on SERV_AD_FICHA.FORMA_PAG_NO = FORMA_DE_PAGAMENTO.ID_FORMA_DE_PAGAMENTO ");
        str.AppendLine(" left join HOTEIS on FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");
        str.AppendLine(" left join VENDEDORES on SERV_AD_FICHA.VENDEDOR_NO = VENDEDORES.ID_VENDEDOR ");
        str.AppendLine(" where ");
        str.AppendLine(" OS_ADC_NO  = @ID_OS_ADC ");

        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@ID_OS_ADC";
        parameter.Value = ID_OS_ADC;
        cmd.Parameters.Add(parameter);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            FichasListagem FichaListagem = new FichasListagem();
            FichaListagem.ID_SERV_AD_FICHA = Convert.ToInt64(reader["ID_SERV_AD_FICHA"]);
            FichaListagem.FICHA_NO = Convert.ToInt64(reader["FICHA_NO"]);
            FichaListagem.PASSEIO_NO = Convert.ToInt64(reader["SERV_AD_NO"]);
            FichaListagem.HORA = reader["HORA"].ToString();
            FichaListagem.HOTEL = reader["HOTEL"].ToString();
            FichaListagem.APTO = reader["APARTAMENTO_FICHA"].ToString();
            FichaListagem.PASSEIO = reader["PASSEIO_SERV_ADC"].ToString();
            FichaListagem.PAX = reader["NOME_PASSAGEIRO"].ToString();
            FichaListagem.FORMA_PAG = reader["FORMA_DE_PAGAMENTO"].ToString();
            FichaListagem.VENDEDOR = reader["NOME_VENDEDOR"].ToString();
            xList.Add(FichaListagem);
        }

        return xList;
    }

    public static List<FichasListagem> GetFichasFatura()
    {
        List<FichasListagem> xList = new List<FichasListagem>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select ID_FICHA, COD_EXCURSAO_FICHA, ");
        str.AppendLine(" SIGLA_VOO, AEROPORTO_CHEGADA_FICHA, ");
        str.AppendLine(" count(ID_PASSAGEIRO) as QUANT_PAX, ");
        str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO ");
        str.AppendLine(" from FICHAS ");
        str.AppendLine(" LEFT JOIN VOOS ON FICHAS.VOO_CHEGADA_FICHA = VOOS.ID_VOO ");
        str.AppendLine(" LEFT JOIN PASSAGEIROS ON FICHAS.ID_FICHA = PASSAGEIROS.FICHA_NO ");
        str.AppendLine(" where ");
        str.AppendLine(" FATURA_NO  is null ");
        str.AppendLine(" group by ID_FICHA, COD_EXCURSAO_FICHA, SIGLA_VOO, AEROPORTO_CHEGADA_FICHA ");

        cmd.CommandText = str.ToString();        

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            FichasListagem FichaListagem = new FichasListagem();
            FichaListagem.FICHA_NO = Convert.ToInt64(reader["ID_FICHA"]);
            FichaListagem.COD_EXCURSAO = reader["COD_EXCURSAO_FICHA"].ToString();
            FichaListagem.VOO = reader["SIGLA_VOO"].ToString();
            FichaListagem.AEROPORTO = reader["AEROPORTO_CHEGADA_FICHA"].ToString();
            FichaListagem.QUANT_PAX = reader["QUANT_PAX"].ToString();
            FichaListagem.PAX = reader["NOME_PASSAGEIRO"].ToString();
            xList.Add(FichaListagem);
        }

        return xList;
    }
}