using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Status
/// </summary>
public class Status
{
    #region Propriedades
    public string CODIGO { get; set; }
    public string STATUS { get; set; }
    #endregion

	public Status()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Retornar Lista de Status
    /// </summary>
    /// <returns></returns>
    public List<Status> GetStatus()
    {
        List<Status> xList = new List<Status>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select CODIGO_STATUS, STATUS_STATUS from STATUS ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Status Stat = new Status
            {
                CODIGO = reader.GetString(0),
                STATUS = reader.GetString(1)
            };

            xList.Add(Stat);
        }

        return xList;
    }
}