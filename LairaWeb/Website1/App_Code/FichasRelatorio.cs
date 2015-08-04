using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for FichasRelatorio
/// </summary>
public class FichasRelatorio
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

    public FichasRelatorio()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static List<FichasRelatorio> GetFichasRelatorio()
    {
        List<FichasRelatorio> xList = new List<FichasRelatorio>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select ID_FICHA, COD_EXCURSAO_FICHA, DATA_CHEGADA_FICHA, VOO_CHEGADA_HORA_FICHA, AEROPORTO_CHEGADA_FICHA, ");
        str.AppendLine(" SIGLA_VOO, ");
        str.AppendLine(" dbo.getpax(FICHAS.ID_FICHA) AS NOME_PASSAGEIRO, ");
        str.AppendLine(" ISNULL(NOME_HOTEL, '---') AS HOTEL ");
        str.AppendLine(" from FICHAS ");
        str.AppendLine(" LEFT JOIN VOOS ON FICHAS.VOO_CHEGADA_FICHA = VOOS.ID_VOO ");
        str.AppendLine(" LEFT JOIN HOTEIS ON FICHAS.HOTEL_FICHA = HOTEIS.ID_HOTEL ");

        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            FichasRelatorio FichaRelatorio = new FichasRelatorio();
            FichaRelatorio.FICHA_NO = Convert.ToInt64(reader["ID_FICHA"]);
            FichaRelatorio.COD_EXCURSAO = reader["COD_EXCURSAO_FICHA"].ToString();
            FichaRelatorio.DATA = reader["DATA_CHEGADA_FICHA"].ToString();
            FichaRelatorio.HORA = reader["VOO_CHEGADA_HORA_FICHA"].ToString();
            FichaRelatorio.AEROPORTO = reader["AEROPORTO_CHEGADA_FICHA"].ToString();
            FichaRelatorio.VOO = reader["SIGLA_VOO"].ToString();
            FichaRelatorio.PAX = reader["NOME_PASSAGEIRO"].ToString();
            FichaRelatorio.HOTEL = reader["HOTEL"].ToString();
            xList.Add(FichaRelatorio);
        }

        return xList;
    }

}