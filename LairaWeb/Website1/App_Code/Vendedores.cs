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
    public Int64 ID { get; set; }
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
        str.AppendLine(" select ID_VENDEDOR, CODIGO_VENDEDOR, NOME_VENDEDOR, TELEFONE_VENDEDOR,  CELULAR_VENDEDOR from VENDEDORES ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Vendedores Vendedor = new Vendedores
             {
                 ID = reader.GetInt64(0),
                 CODIGO = reader.IsDBNull(1) ? null : reader.GetString(1),
                 NOME = reader.IsDBNull(2) ? null : reader.GetString(2),
                 TELEFONE = reader.IsDBNull(3) ? null : reader.GetString(3),
                 CELULAR = reader.IsDBNull(4) ? null : reader.GetString(4)

             };

            xList.Add(Vendedor);
        }

        return xList;
    }
    public List<Vendedores> GetVendedoresCombo()
    {
        List<Vendedores> xList = new List<Vendedores>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_VENDEDOR, NOME_VENDEDOR from VENDEDORES ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Vendedores Vendedor = new Vendedores
            {
                ID = reader.GetInt64(0),
                NOME = reader.IsDBNull(1) ? null : reader.GetString(1)

            };

            xList.Add(Vendedor);
        }

        return xList;
    }
}
