using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Hoteis
/// </summary>
public class Hoteis
{
    #region Propriedades
    public Int64 ID { get; set; }
    public string CODIGO { get; set; }
    public string NOME { get; set; }
    public string ENDERECO { get; set; }
    public string EMAIL { get; set; }
    public string TELEFONE { get; set; }
    public string HORA { get; set; }
    #endregion

	public Hoteis()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public string GetEmailHotelByFicha (string FichaNo  )
    {
        List<Fichas> xList = new List<Fichas>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select ISNULL(EMAIL_HOTEL ,'-') as EMAIL_HOTEL ");
        str.AppendLine(" from FICHAS F INNER JOIN HOTEIS H ON F.HOTEL_FICHA = H.ID_HOTEL ");
        str.AppendLine(" WHERE ");
        str.AppendLine(" ID_FICHA  = @ID_FICHA ");

        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@ID_FICHA";
        parameter.Value = FichaNo;
        cmd.Parameters.Add(parameter);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();
         string EMAIL ="";
        while (reader.Read())
        {
           EMAIL = reader["EMAIL_HOTEL"].ToString();
        }

        return EMAIL;
    }
    /// <summary>
    /// Retornar Lista de Vendedores
    /// </summary>
    /// <returns></returns>
    public List<Hoteis> GetHoteis()
    {
        List<Hoteis> xList = new List<Hoteis>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_HOTEL, CODIGO_HOTEL, NOME_HOTEL, ENDERECO_HOTEL,  EMAIL_HOTEL, TELEFONE_HOTEL, HORA_HOTEL from HOTEIS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Hoteis Hotel = new Hoteis
            {
                ID = reader.GetInt64(0),
                CODIGO = reader.IsDBNull(1) ? null : reader.GetString(1),
                NOME = reader.IsDBNull(2) ? null : reader.GetString(2),
                ENDERECO = reader.IsDBNull(3) ? null : reader.GetString(3),
                EMAIL = reader.IsDBNull(4) ? null : reader.GetString(4),
                TELEFONE = reader.IsDBNull(5) ? null : reader.GetString(5),
                HORA = reader.IsDBNull(6) ? null : reader.GetString(6)
            };

            xList.Add(Hotel);
        }

        return xList;
    }
    public List<Hoteis> GetHoteisCombo()
    {
        List<Hoteis> xList = new List<Hoteis>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_HOTEL , NOME_HOTEL from HOTEIS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Hoteis Hotel = new Hoteis
            {
                ID = reader.GetInt64(0),
                NOME = reader.IsDBNull(1) ? null : reader.GetString(1)
            };

            xList.Add(Hotel);
        }

        return xList;

    }
}