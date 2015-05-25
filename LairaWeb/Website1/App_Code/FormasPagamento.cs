using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for FormasPagamento
/// </summary>
public class FormasPagamento
{
    #region Propriedades
    public string CODIGO { get; set; }
    public string FORMA_PAG { get; set; }
    public string TIPO { get; set; }    
    #endregion

	public FormasPagamento()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Retornar Lista de Formas de Pagamento
    /// </summary>
    /// <returns></returns>
    public List<FormasPagamento> GetFormasPagamento()
    {
        List<FormasPagamento> xList = new List<FormasPagamento>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select COD_FORMA_DE_PAGAMENTO, FORMA_DE_PAGAMENTO, TIPO_FORMA_DE_PAGAMENTO from FORMA_DE_PAGAMENTO ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            FormasPagamento FormaPag = new FormasPagamento
            {
                CODIGO = reader.GetString(0),
                FORMA_PAG = reader.GetString(1),
                TIPO = reader.GetString(2),                
            };

            xList.Add(FormaPag);
        }

        return xList;
    }
}