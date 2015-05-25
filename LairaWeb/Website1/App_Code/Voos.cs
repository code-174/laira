using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Voos
/// </summary>
public class Voos
{
    #region Propriedades
    public string NOME { get; set; }
    public string SIGLA { get; set; }
    public string HORA { get; set; }
    public string AEROPORTO { get; set; }
    public string TIPO { get; set; }
    #endregion

	public Voos()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    /// <summary>
    /// Retornar Lista de Voos
    /// </summary>
    /// <returns></returns>
    public List<Voos> GetVoos()
    {
        List<Voos> xList = new List<Voos>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select NOME_VOO, SIGLA_VOO, HORA_VOO, AEROPORTO_VOO, TIPO_VOO from VOOS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Voos Voo = new Voos
            {
                NOME = reader.GetString(0),
                SIGLA = reader.GetString(1),
                HORA = reader.GetString(2),
                AEROPORTO = reader.GetString(3),
                TIPO = reader.GetString(4)
            };

            xList.Add(Voo);
        }

        return xList;
    }
}