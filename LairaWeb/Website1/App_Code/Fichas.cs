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
    public Int64 FICHA_NO { get; set; }
    public string DATA_CHEGADA { get; set; }
    public string DATA_SAIDA { get; set; }
    public string VOO_CHEGADA { get; set; }
    public string VOO_CHEGADA_HORA { get; set; }
    public string VOO_SAIDA { get; set; }
    public string VOO_SAIDA_HORA { get; set; }
    public string AEROPORTO_CHEGADA { get; set; }
    public string AEROPORTO_SAIDA { get; set; }
    public string COD_EXCURSAO { get; set; }
    public string AGENCIA_NO { get; set; }
    public string RECIBO_FICHA { get; set; }
    public string HOTEL { get; set; }
    public string APTO { get; set; }
    public string SAIDA_DO_HOTEL { get; set; }    
    public string OBS { get; set; }
    #endregion

    public Fichas()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<Fichas> GetFichaByNo(string FichaNo)
    {
        List<Fichas> xList = new List<Fichas>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select ID_FICHA, DATA_CHEGADA_FICHA, DATA_SAIDA_FICHA, ");
        str.AppendLine(" VOO_CHEGADA_FICHA, VOO_CHEGADA_HORA_FICHA, VOO_SAIDA_FICHA, VOO_SAIDA_HORA_FICHA, ");
        str.AppendLine(" AEROPORTO_CHEGADA_FICHA, AEROPORTO_SAIDA_FICHA, COD_EXCURSAO_FICHA, ");
        str.AppendLine(" AGENCIA_NO, RECIBO_FICHA, HOTEL_FICHA, APARTAMENTO_FICHA, ");
        str.AppendLine(" SAIDA_DO_HOTEL_FICHA, OBS_FICHA ");
        str.AppendLine(" from FICHAS ");
        str.AppendLine(" where ");
        str.AppendLine(" ID_FICHA  = @ID_FICHA ");

        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@ID_FICHA";
        parameter.Value = FichaNo;
        cmd.Parameters.Add(parameter);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Fichas Ficha = new Fichas();
            Ficha.FICHA_NO = Convert.ToInt64(reader["ID_FICHA"]);
            Ficha.DATA_CHEGADA = reader["DATA_CHEGADA_FICHA"].ToString();
            Ficha.DATA_SAIDA = reader["DATA_SAIDA_FICHA"].ToString();
            Ficha.VOO_CHEGADA = reader["VOO_CHEGADA_FICHA"].ToString();
            Ficha.VOO_CHEGADA_HORA = reader["VOO_CHEGADA_HORA_FICHA"].ToString();
            Ficha.VOO_SAIDA = reader["VOO_SAIDA_FICHA"].ToString();
            Ficha.VOO_SAIDA_HORA = reader["VOO_SAIDA_HORA_FICHA"].ToString();
            Ficha.AEROPORTO_CHEGADA = reader["AEROPORTO_CHEGADA_FICHA"].ToString();
            Ficha.AEROPORTO_SAIDA = reader["AEROPORTO_SAIDA_FICHA"].ToString();
            Ficha.COD_EXCURSAO = reader["COD_EXCURSAO_FICHA"].ToString();
            Ficha.AGENCIA_NO = reader["AGENCIA_NO"].ToString();
            Ficha.RECIBO_FICHA = reader["RECIBO_FICHA"].ToString();
            Ficha.HOTEL = reader["HOTEL_FICHA"].ToString();
            Ficha.APTO = reader["APARTAMENTO_FICHA"].ToString();
            Ficha.SAIDA_DO_HOTEL = reader["SAIDA_DO_HOTEL_FICHA"].ToString();
            Ficha.OBS = reader["OBS_FICHA"].ToString();

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

    public void RemoveFichaOS(Int64 FICHA_NO, string strTipoOS)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        if (strTipoOS == "C")
        {
            str.AppendLine(" update FICHAS ");
            str.AppendLine(" set OS_CHEGADA = null ");
            str.AppendLine(" where ID_FICHA = @FICHA_NO ");
        }
        else
        {
            str.AppendLine(" update FICHAS ");
            str.AppendLine(" set OS_SAIDA = null ");
            str.AppendLine(" where ID_FICHA = @FICHA_NO ");
        }

        cmd.CommandText = str.ToString();
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@FICHA_NO", SqlDbType.BigInt)).Value = FICHA_NO;

        conn.Open();

        cmd.ExecuteNonQuery();

        cmd.Dispose();
        cmd = null;
        conn.Close();
        conn.Dispose();
    }

    public void UpdateFaturaFicha(Int64 FATURA_NO, Int64 FICHA_NO)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" update FICHAS ");
        str.AppendLine(" set FATURA_NO = @FATURA_NO ");
        str.AppendLine(" where ID_FICHA = @FICHA_NO ");


        cmd.CommandText = str.ToString();
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@FATURA_NO", SqlDbType.BigInt)).Value = FATURA_NO;
        cmd.Parameters.Add(new SqlParameter("@FICHA_NO", SqlDbType.BigInt)).Value = FICHA_NO;

        conn.Open();

        cmd.ExecuteNonQuery();

        cmd.Dispose();
        cmd = null;
        conn.Close();
        conn.Dispose();
    }

}