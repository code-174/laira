using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Incoming
/// </summary>
public class Incoming
{
    #region Propriedades
    public string CODIGO { get; set; }
    public string NOME { get; set; }
    public string EMPRESA { get; set; }
    public string TELEFONE { get; set; }
    public string EMAIL { get; set; }
    #endregion
	public Incoming()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Retornar Lista de Incoming
    /// </summary>
    /// <returns></returns>
    public List<Incoming> GetIncoming()
    {
        List<Incoming> xList = new List<Incoming>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select CODIGO_INCOMING, NOME_INCOMING, EMPRESA_INCOMING, TELEFONE_INCOMING, EMAIL_INCOMING from INCOMING ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Incoming Incom = new Incoming
            {
                CODIGO = reader.IsDBNull(0) ? null : reader.GetString(0),
                NOME = reader.IsDBNull(1) ? null : reader.GetString(1),
                EMPRESA = reader.IsDBNull(2) ? null : reader.GetString(2),
                TELEFONE = reader.IsDBNull(3) ? null : reader.GetString(3),
                EMAIL = reader.IsDBNull(4) ? null : reader.GetString(4)
            };

            xList.Add(Incom);
        }

        return xList;
    }
}