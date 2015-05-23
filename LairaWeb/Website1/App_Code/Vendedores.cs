using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

public class Vendedores
{
    #region Propriedades
    public string CODIGO { get; set; }
    public string NOME { get; set; }
    public string TELEFONE { get; set; }
    public string CELULAR { get; set; }
    #endregion

    public Vendedores()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Retornar Lista de Vendedores
    /// </summary>
    /// <returns></returns>
    public List<Vendedores> GetVendedores()
    {
        List<Vendedores> xList = new List<Vendedores>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select CODIGO_VENDEDOR, NOME_VENDEDOR, TELEFONE_VENDEDOR,  CELULAR_VENDEDOR from VENDEDORES ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Vendedores Vendedor = new Vendedores
             {
                 CODIGO = reader.GetString(0),
                 NOME = reader.GetString(1),
                 TELEFONE = reader.GetString(2),
                 CELULAR = reader.GetString(3)
             };

            xList.Add(Vendedor);
        }

        return xList;
    }
}
