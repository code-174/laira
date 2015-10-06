using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for Passageiros
/// </summary>
public class Passageiros
{

    #region Propriedades
    public Int64 PASSAGEIRO_NO { get; set; }
    public string NOME { get; set; }
    public string IDENTIDADE_PASSAGEIRO { get; set; }
    public string ORG_EXPED { get; set; }
    public string TELEFONE_PASSAGEIRO { get; set; }
    public string OBS_PASSAGEIRO { get; set; }
    public string FICHA_NO { get; set; }
    #endregion

    public Passageiros()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static List<Passageiros> GetPassageirosByFichaNo(string FichaNo)
    {
        List<Passageiros> xList = new List<Passageiros>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select ID_PASSAGEIRO, NOME_PASSAGEIRO, IDENTIDADE_PASSAGEIRO, ");
        str.AppendLine(" ORG_EXPED_PASSAGEIRO, TELEFONE_PASSAGEIRO, OBS_PASSAGEIRO ");
        str.AppendLine(" from PASSAGEIROS ");
        str.AppendLine(" where ");
        str.AppendLine(" FICHA_NO  = @FICHA_NO ");

        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@FICHA_NO";
        parameter.Value = FichaNo;
        cmd.Parameters.Add(parameter); 

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Passageiros Passageiro = new Passageiros();
            Passageiro.PASSAGEIRO_NO = Convert.ToInt64(reader["ID_PASSAGEIRO"]);
            Passageiro.NOME = reader["NOME_PASSAGEIRO"].ToString();
            Passageiro.IDENTIDADE_PASSAGEIRO = reader["IDENTIDADE_PASSAGEIRO"].ToString();
            Passageiro.ORG_EXPED = reader["ORG_EXPED_PASSAGEIRO"].ToString();
            Passageiro.TELEFONE_PASSAGEIRO = reader["TELEFONE_PASSAGEIRO"].ToString();
            Passageiro.OBS_PASSAGEIRO = reader["OBS_PASSAGEIRO"].ToString();
            xList.Add(Passageiro);
        }

        return xList;
    }

     
}