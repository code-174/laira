using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for UsuariosSistema
/// </summary>
public class UsuariosSistema
{
    
    #region Propriedades
    public Int64 ID { get; set; }
    public string USUARIO { get; set; }
    #endregion

	public UsuariosSistema()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    /// <summary>
    /// Retornar Lista de Vendedores
    /// </summary>
    /// <returns></returns>
    public List<UsuariosSistema> GetUsuarios()
    {
        List<UsuariosSistema> xList = new List<UsuariosSistema>();

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select ID_USUARIO, USUARIO_USUARIO  from VENDEDORES ");
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            UsuariosSistema Usuario = new UsuariosSistema
             {
                 ID = reader.GetInt64(0),
                 USUARIO = reader.IsDBNull(1) ? null : reader.GetString(1) 

             };

            xList.Add(Usuario);
        }

        return xList;
    }


    public string UserExists(string Usuario, string Senha)
    {

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select USUARIO_USUARIO ");
        str.AppendLine(" from USUARIOS ");
        str.AppendLine(" WHERE ");
        str.AppendLine(" USUARIO_USUARIO  = @Usuario ");
        str.AppendLine(" and ");
        str.AppendLine(" SENHA_USUARIO  = @Senha ");

        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@Usuario";
        parameter.Value = Usuario;
        cmd.Parameters.Add(parameter);
        SqlParameter parameter1 = new SqlParameter();
        parameter1.ParameterName = "@Senha";
        parameter1.Value = Senha;
        cmd.Parameters.Add(parameter1);

        conn.Open();

        SqlDataReader reader = cmd.ExecuteReader();
        string USUARIO_USUARIO = "-";
        while (reader.Read())
        {
            USUARIO_USUARIO = reader["USUARIO_USUARIO"].ToString();
        }

        return USUARIO_USUARIO;
    }
   
}
