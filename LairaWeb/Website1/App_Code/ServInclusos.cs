using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for ServInclusos
/// </summary>
public class ServInclusos
{
    #region Propriedades
    public string CODIGO { get; set; }
    public string SERVICO { get; set; }
    public string PRECO { get; set; }
    #endregion

	public ServInclusos()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Retornar Lista de Servicos Inclusos
    /// </summary>
    /// <returns></returns>
    public List<ServInclusos> GetServInclusos()
    {
        List<ServInclusos> xList = new List<ServInclusos>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select COD_SERV_INCLUSO, SERVICO_SERV_INCLUSO, PRECO_SERV_INCLUSO from SERV_INCLUSO ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            ServInclusos ServicoInclusos = new ServInclusos
            {
                CODIGO = reader.GetString(0),
                SERVICO = reader.GetString(1),
                PRECO = reader.GetString(2)
            };

            xList.Add(ServicoInclusos);
        }

        return xList;
    }
}