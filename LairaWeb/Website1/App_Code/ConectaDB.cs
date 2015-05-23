using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ConectaDB
/// </summary>
public class ConectaDB
{
	public ConectaDB()
	{
        //TO DO 
        

	}

   SqlConnection Conectar()
    {
        
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        

        return conn;
    }



}

//Imports System.Web
//Imports System.Data.SqlClient 

//   Public Class DAL_Cargai9 
//===============================================
//      Private cnLM As SqlConnection 
//      Private _connectionStringMain As String = "Data Source=192.168.3.2\QDT_SAVE;Initial Catalog=DBMTT;User Id=sa;" 
//      Const _ErrMsg As String = "Not possible to complete operation. Check info.!" 
//===============================================
//         Public Sub AjustarClientes() 　
//            'BEGIN -- SalvarEstatisticai9 -- 
//               Try 
//               cnLM = New SqlConnection(_connectionStringMain) 
//                  Try    
//                     cnLM.Open()
//                  Catch ex As Exception 
//                     Throw ex 
//                  End Try

//                  Dim cmdSalvarStats As New SqlCommand("aspAtualizarCadastroTMOffice", cnLM) 
//                  cmdSalvarStats.CommandType = CommandType.StoredProcedure
//                  cmdSalvarStats.ExecuteNonQuery()

//                  Catch ex As Exception 
//                          Finally 
//                  cnLM.Close()
//                  End Try 
//                  'END -- SalvarEstatisticai9 -- 
//    End Sub
//===============================================
//#Region "Útil Functions"
//===============================================
//Public Sub SQLExecute(ByVal XSQL As String)
//'Retorna: 'Zero=Ok ou nº do Erro.
//cnLM =  New SqlConnection(_connectionStringMain)
//Dim myCommand As New SqlCommand
//Try
//cnLM.ConnectionString = _connectionStringMain
//cnLM.Open()
//With myCommand
//.Connection = cnLM
//.CommandText = XSQL
//.ExecuteNonQuery()
//End With
//Catch e As Exception
//'Throw e.Message
//Finally
//cnLM.Close()
//End Try
//End Sub 
//===============================================
//Public Function GetSQLExecute(ByVal XSQL) As String
//cnLM =
//New SqlConnection(_connectionStringMain)
//Dim CmdtoExecute As New SqlCommand
//Dim mySqlDataReader As SqlDataReader
//cnLM.ConnectionString = _connectionStringMain
//Try
//cnLM.Open()
//With CmdtoExecute
//.Connection = cnLM
//.CommandText = XSQL
//mySqlDataReader = .ExecuteReader()
//End With
//With mySqlDataReader
//If .Read Then
//If IsDBNull(.Item(0)) Then
//GetSQLExecute = ""
//Else
//GetSQLExecute = .Item(0)
//End If
//Else
//GetSQLExecute = ""
//End If
//.Close()
//End With
//cnLM.Close()
//Catch ex As Exception
//Throw New Exception("iXLink::SQLExecute::Error Ocurred", ex)
//Finally
//cnLM.Close()
//CmdtoExecute.Dispose()
//'mySqlDataReader.Dispose()
//End Try
//Return GetSQLExecute
//End Function
//===============================================
//Public Sub FillDropDown(ByVal XDropDownList As Object, ByVal XSQL As String)
//cnLM = New SqlConnection(_connectionStringMain)
//Dim myda As SqlDataAdapter
//Dim ds As DataSet
//Try
//cnLM.ConnectionString = _connectionStringMain
//cnLM.Open()
//myda =
//New SqlDataAdapter(XSQL, cnLM)
//ds =
//New DataSet
//myda.Fill(ds, "Tab")
//With XDropDownList
//.DataSource = ds
//.DataSource = ds.Tables(0)
//.DataValueField = ds.Tables(0).Columns(0).ColumnName.ToString()
//.DataTextField = ds.Tables(0).Columns(1).ColumnName.ToString()
//.DataBind()
//End With
//cnLM.Close()
//Catch ex As Exception
//Throw ex
//End Try
//End Sub
//===============================================
//Public Sub FillListBox(ByVal XDropDownList As Object, ByVal XSQL As String)
//cnLM = New SqlConnection(_connectionStringMain)
//Dim myda As SqlDataAdapter
//Dim ds As DataSet
//Try
//cnLM.ConnectionString = _connectionStringMain
//cnLM.Open()
//myda =
//New SqlDataAdapter(XSQL, cnLM)
//ds =
//New DataSet
//myda.Fill(ds, "Tab")
//With XDropDownList
//.DataSource = ds
//.DataSource = ds.Tables(0)
//.DataValueField = ds.Tables(0).Columns(0).ColumnName.ToString()
//.DataTextField = ds.Tables(0).Columns(1).ColumnName.ToString()
//.DataBind()
//End With
//cnLM.Close()
//Catch ex As Exception
//Throw ex
//End Try
//End Sub
//===============================================　
//Public Sub Fill_DataGrid(ByVal XDataGrid As Object, ByVal XSQL As String)
//Dim XComando As SqlDataAdapter
//Dim XRS As DataSet
//'Build the connection string
//Dim StrCon As String = _connectionStringMain
//connection.ConnectionString = StrCon
//XComando = New SqlDataAdapter(XSQL, connection)
//XRS = New DataSet("Data_DataGrid")
//XComando.Fill(XRS)
//XDataGrid.DataSource = XRS
//XDataGrid.DataBind()
//connection.Close()
//End Sub
//===============================================
//Public Function Get_DBValue(ByVal XTAB As String, ByVal XCOLUMN As String, ByVal XID As String, ByVal XWhere As Object) As Object
//Dim myConnection As SqlConnection = New SqlConnection
//Dim DefaultData As DataTable
//Dim XSQL As String
//Dim Exec As New DAL_Cargai9
　
//myConnection.ConnectionString = _connectionStringMain
//If XID <> Nothing And XID <> "" Then
//XSQL &=
//"Select " & XCOLUMN & " From " & XTAB
//End If
//If XID <> "" Then XSQL &= " Where " & XID & " " & XWhere
//DefaultData = Exec.SQLExecuteDataTable(XSQL)
//If DefaultData.Rows.Count > 0 Then
//Get_DBValue = DefaultData.Rows(0)(0)
//Else
//Get_DBValue =
//""
//End If
//End Function
//===============================================
//Public Function SQLExecuteDataTable(ByVal XSQL) As DataTable
//Dim Conn As SqlConnection = New SqlConnection
//Dim CmdtoExecute As New SqlCommand
//Dim reader As SqlDataAdapter
//Dim returnDataTable As New DataTable
//Conn.ConnectionString = _connectionStringMain
//Try
//Conn.Open()
//CmdtoExecute.Connection = Conn
//CmdtoExecute.CommandText = XSQL
//reader =
//New SqlDataAdapter(CmdtoExecute)
//reader.Fill(returnDataTable)
//Catch ex As Exception
//Throw New Exception("SQLUTIL::SQLExecute::Error Ocurred", ex)
//Finally
//Conn.Close()
//CmdtoExecute.Dispose()
//'ORIGINAL
//'reader.Dispose()
//End Try
//Return returnDataTable
//End Function
//===============================================
//#End Region
　
// End Class 