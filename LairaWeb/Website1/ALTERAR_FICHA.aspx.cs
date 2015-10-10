using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Collections;

public partial class ALTERAR_FICHA : System.Web.UI.Page
{
    //protected string strFichaID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string strTipo = Request.QueryString["Tipo"];
            string strFichaNo = "";

            if (strTipo == "F")
            {
                strFichaNo = Request.QueryString["Criterio"];                
            }
            else
            {
                string strCodExc = Request.QueryString["Criterio"];
                Int64 IDFicha = GetFichaNo(strCodExc);
                strFichaNo = Convert.ToString(IDFicha);
            }

            InitializePage(strFichaNo);

        }
    }

    void InitializePage(string strFichaNo)
    {
        Titulo.InnerText = "Alterar Ficha Nr." + " " + strFichaNo;

        LoadCombos();

        FillTextBoxes(strFichaNo);

        GridPAX();
        GridServIn();
        GridServAd();

        LoadGridPaxFirst(strFichaNo);
        LoadGridServInFirst(strFichaNo);
        LoadGridServAdFirst(strFichaNo);

    }

    Int64 GetFichaNo(string strCodExc)
    {
        Int64 retorno = 0;

        Fichas c = new Fichas();
        retorno = c.GetFichaNo(strCodExc);
        return retorno;
    }

    void FillTextBoxes(string strFichaNo)
    {
        List<Fichas> l = Fichas.GetFichaByNo(strFichaNo);

        foreach (var item in l)
        {
            txtDataChegada.Text = l[0].DATA_CHEGADA;
            txtDataSaida.Text = l[0].DATA_SAIDA;
            ddlVooChegada.SelectedValue = l[0].VOO_CHEGADA;
            ddlVooSaida.SelectedValue = l[0].VOO_SAIDA;
            txtVooHoraChegada.Text = l[0].VOO_CHEGADA_HORA;
            txtVooHoraSaida.Text = l[0].VOO_SAIDA_HORA;
            txtAeroportoChegada.Text = l[0].AEROPORTO_CHEGADA;
            txtAeroportoSaida.Text = l[0].AEROPORTO_SAIDA;
            txtCodExcursao.Text = l[0].COD_EXCURSAO;
            ddlAgencia.SelectedValue = l[0].AGENCIA_NO;
            txtRecibo.Text = l[0].RECIBO_FICHA;
            ddlHotel.SelectedValue = l[0].HOTEL;
            txtApartamento.Text = l[0].APTO;
            txtSaidaHotel.Text = l[0].SAIDA_DO_HOTEL;
            txtObs.Text = l[0].OBS;
        }
    }

    void GridPAX()
    {
        //Grid PAX
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("#", typeof(string)));
        dt.Columns.Add(new DataColumn("Nome", typeof(string)));
        dt.Columns.Add(new DataColumn("Identidade", typeof(string)));
        dt.Columns.Add(new DataColumn("OrgaoExp", typeof(string)));
        dt.Columns.Add(new DataColumn("Telefone", typeof(string)));
        dt.Columns.Add(new DataColumn("Obs", typeof(string)));
        dr = dt.NewRow();
        dr["#"] = 1;
        dr["Nome"] = string.Empty;
        dr["Identidade"] = string.Empty;
        dr["OrgaoExp"] = string.Empty;
        dr["Telefone"] = string.Empty;
        dr["Obs"] = string.Empty;

        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable1"] = dt;

        grvData.DataSource = dt;
        grvData.DataBind();


    }

    void GridServIn()
    {
        //Grid Serv Inclusos
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("#", typeof(string)));
        dt.Columns.Add(new DataColumn("Local", typeof(string)));
        dt.Columns.Add(new DataColumn("Valor", typeof(string)));
        dt.Columns.Add(new DataColumn("Pagamento", typeof(string)));
        dr = dt.NewRow();
        dr["#"] = 1;
        dr["Local"] = string.Empty;
        dr["Valor"] = string.Empty;
        dr["Pagamento"] = string.Empty;

        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable2"] = dt;

        grvServIn.DataSource = dt;
        grvServIn.DataBind();

    }

    void GridServAd()
    {
        //Grid Serv Adicionais
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("#", typeof(string)));
        dt.Columns.Add(new DataColumn("Voucher", typeof(string)));
        dt.Columns.Add(new DataColumn("Passeio", typeof(string)));
        dt.Columns.Add(new DataColumn("Vendedor", typeof(string)));
        dt.Columns.Add(new DataColumn("Valor", typeof(string)));
        dt.Columns.Add(new DataColumn("Data", typeof(string)));
        dt.Columns.Add(new DataColumn("Hora", typeof(string)));
        dt.Columns.Add(new DataColumn("Pagamento", typeof(string)));
        dt.Columns.Add(new DataColumn("Status", typeof(string)));
        dr = dt.NewRow();
        dr["#"] = 1;
        dr["Voucher"] = string.Empty;
        dr["Passeio"] = string.Empty;
        dr["Vendedor"] = string.Empty;
        dr["Valor"] = string.Empty;
        dr["Data"] = string.Empty;
        dr["Hora"] = string.Empty;
        dr["Pagamento"] = string.Empty;
        dr["Status"] = string.Empty;

        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable3"] = dt;

        grvServAd.DataSource = dt;
        grvServAd.DataBind();

    }

    void LoadGridPaxFirst(string strFichaNo)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select ID_PASSAGEIRO, ");
        str.AppendLine(" NOME_PASSAGEIRO as Nome, ");
        str.AppendLine(" IDENTIDADE_PASSAGEIRO as Identidade, ");
        str.AppendLine(" ORG_EXPED_PASSAGEIRO as OrgaoExp, ");
        str.AppendLine(" TELEFONE_PASSAGEIRO as Telefone, ");
        str.AppendLine(" OBS_PASSAGEIRO as Obs ");
        str.AppendLine(" from PASSAGEIROS ");
        str.AppendLine(" where ");
        str.AppendLine(" FICHA_NO  = @FICHA_NO ");

        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@FICHA_NO";
        parameter.Value = strFichaNo;
        cmd.Parameters.Add(parameter);

        conn.Open();

        DataTable dt = new DataTable();
        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        {
            sda.Fill(dt);
        }

        grvData.DataSource = dt;
        grvData.DataBind();

        int rowIndex = 0;
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBox box1 = (TextBox)grvData.Rows[rowIndex].Cells[1].FindControl("txtNome");
                TextBox box2 = (TextBox)grvData.Rows[rowIndex].Cells[2].FindControl("txtIdentidade");
                TextBox box3 = (TextBox)grvData.Rows[rowIndex].Cells[3].FindControl("txtOrgao");
                TextBox box4 = (TextBox)grvData.Rows[rowIndex].Cells[4].FindControl("txtTelefone");
                TextBox box5 = (TextBox)grvData.Rows[rowIndex].Cells[5].FindControl("txtObs");
                LinkButton box6 = (LinkButton)grvData.Rows[rowIndex].Cells[6].FindControl("lnkExcluirPAX");

                box1.Text = dt.Rows[i]["Nome"].ToString();
                box2.Text = dt.Rows[i]["Identidade"].ToString();
                box3.Text = dt.Rows[i]["OrgaoExp"].ToString();
                box4.Text = dt.Rows[i]["Telefone"].ToString();
                box5.Text = dt.Rows[i]["Obs"].ToString();
                box6.ID = "lnkExcluirPAX";

                rowIndex++;
            }
        }

        ViewState["CurrentTable1"] = dt;

        AddNewRowToGrid();
    }

    void LoadGridServInFirst(string strFichaNo)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select SERV_IN_NO as Local, ");
        str.AppendLine(" VALOR as Valor, ");
        str.AppendLine(" FORMA_PAG_NO as Pagamento ");
        str.AppendLine(" from SERV_IN_FICHA ");
        str.AppendLine(" where ");
        str.AppendLine(" FICHA_NO  = @FICHA_NO ");

        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@FICHA_NO";
        parameter.Value = strFichaNo;
        cmd.Parameters.Add(parameter);

        conn.Open();

        DataTable dt = new DataTable();
        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        {
            sda.Fill(dt);
        }

        grvServIn.DataSource = dt;
        grvServIn.DataBind();

        int rowIndex = 0;
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DropDownList box1 = (DropDownList)grvServIn.Rows[rowIndex].Cells[1].FindControl("ddlLocal");
                TextBox box2 = (TextBox)grvServIn.Rows[rowIndex].Cells[2].FindControl("txtValor");
                DropDownList box3 = (DropDownList)grvServIn.Rows[rowIndex].Cells[3].FindControl("ddlPagamento1");
                LinkButton box6 = (LinkButton)grvServIn.Rows[rowIndex].Cells[4].FindControl("lnkExcluirServIn");

                box1.SelectedValue = dt.Rows[i]["Local"].ToString();
                box2.Text = dt.Rows[i]["Valor"].ToString();
                box3.SelectedValue = dt.Rows[i]["Pagamento"].ToString();
                box6.ID = "lnkExcluirServIn";

                rowIndex++;
            }
        }

        ViewState["CurrentTable2"] = dt;

        AddNewRowToGridServIn();

    }

    void LoadGridServAdFirst(string strFichaNo)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();

        str.AppendLine(" select VOUCHER as Voucher, ");
        str.AppendLine(" SERV_AD_NO as Passeio, ");
        str.AppendLine(" VENDEDOR_NO as Vendedor, ");
        str.AppendLine(" VALOR as Valor, ");
        str.AppendLine(" DATA as Data, ");
        str.AppendLine(" HORA as Hora, ");
        str.AppendLine(" FORMA_PAG_NO as Pagamento, ");
        str.AppendLine(" STATUS_NO as Status ");
        str.AppendLine(" from SERV_AD_FICHA ");
        str.AppendLine(" where ");
        str.AppendLine(" FICHA_NO  = @FICHA_NO ");

        cmd.CommandText = str.ToString();

        SqlParameter parameter = new SqlParameter();
        parameter.ParameterName = "@FICHA_NO";
        parameter.Value = strFichaNo;
        cmd.Parameters.Add(parameter);

        conn.Open();

        DataTable dt = new DataTable();
        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        {
            sda.Fill(dt);
        }

        grvServAd.DataSource = dt;
        grvServAd.DataBind();

        int rowIndex = 0;
        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TextBox box1 = (TextBox)grvServAd.Rows[rowIndex].Cells[1].FindControl("txtVoucher");
                DropDownList box2 = (DropDownList)grvServAd.Rows[rowIndex].Cells[2].FindControl("ddlPasseio");
                DropDownList box3 = (DropDownList)grvServAd.Rows[rowIndex].Cells[3].FindControl("ddlVendedor");
                TextBox box4 = (TextBox)grvServAd.Rows[rowIndex].Cells[4].FindControl("txtValor2");
                TextBox box5 = (TextBox)grvServAd.Rows[rowIndex].Cells[5].FindControl("txtData");
                TextBox box6 = (TextBox)grvServAd.Rows[rowIndex].Cells[6].FindControl("txtHora");
                DropDownList box7 = (DropDownList)grvServAd.Rows[rowIndex].Cells[7].FindControl("ddlPagamento2");
                DropDownList box8 = (DropDownList)grvServAd.Rows[rowIndex].Cells[8].FindControl("ddlStatus");
                LinkButton box9 = (LinkButton)grvServAd.Rows[rowIndex].Cells[9].FindControl("lnkExcluirServAd");


                box1.Text = dt.Rows[i]["Voucher"].ToString();
                box2.SelectedValue = dt.Rows[i]["Passeio"].ToString();
                box3.SelectedValue = dt.Rows[i]["Vendedor"].ToString();
                box4.Text = dt.Rows[i]["Valor"].ToString();
                box5.Text = dt.Rows[i]["Data"].ToString();
                box6.Text = dt.Rows[i]["Hora"].ToString();
                box7.SelectedValue = dt.Rows[i]["Pagamento"].ToString();
                box8.SelectedValue = dt.Rows[i]["Status"].ToString();
                box9.ID = "lnkExcluirServAd";


                rowIndex++;
            }
        }

        ViewState["CurrentTable3"] = dt;

        AddNewRowToGridServAd();



    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }

    protected void ButtonAddServIn_Click(object sender, EventArgs e)
    {
        bool ValidTextbox = false;
        foreach (GridViewRow row in grvServIn.Rows)
        {
            TextBox txt = row.FindControl("txtValor") as TextBox;
            string TextCheck = txt.Text.Trim();
            decimal Num;
            bool isNum = decimal.TryParse(TextCheck, out Num);

            if (!string.IsNullOrEmpty(txt.Text) && isNum)
            {
                ValidTextbox = true;
            }
            else
            {
                ValidTextbox = false;            
                break;
            }
        }

        if (ValidTextbox)
        {
            AddNewRowToGridServIn();
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('Favor preencher o campo Valor');</script>", false);
        }

    }

    protected void ButtonAddServAd_Click(object sender, EventArgs e)
    {
        bool ValidTextbox = false;
        foreach (GridViewRow row in grvServAd.Rows)
        {
            TextBox txt = row.FindControl("txtValor2") as TextBox;
            string TextCheck = txt.Text.Trim();
            decimal Num;
            bool isNum = decimal.TryParse(TextCheck, out Num);

            if (!string.IsNullOrEmpty(txt.Text) && isNum)
            {
                ValidTextbox = true;
            }
            else
            {
                ValidTextbox = false;
                break;
            }
        }

        if (ValidTextbox)
        {
            AddNewRowToGridServAd();
        }
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('Favor preencher o campo Valor');</script>", false);
        }

        
    }

    private void AddNewRowToGrid()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)grvData.Rows[rowIndex].Cells[1].FindControl("txtNome"); //nome
                    TextBox box2 = (TextBox)grvData.Rows[rowIndex].Cells[2].FindControl("txtIdentidade"); //identidade
                    TextBox box3 = (TextBox)grvData.Rows[rowIndex].Cells[3].FindControl("txtOrgao"); // orgao
                    TextBox box4 = (TextBox)grvData.Rows[rowIndex].Cells[4].FindControl("txtTelefone"); // telefone
                    TextBox box5 = (TextBox)grvData.Rows[rowIndex].Cells[5].FindControl("txtObs"); //obs


                    drCurrentRow = dtCurrentTable.NewRow();
                    //drCurrentRow["#"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["Nome"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Identidade"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["OrgaoExp"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["Telefone"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["Obs"] = box5.Text;
                    rowIndex++;
                }

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable1"] = dtCurrentTable;

                grvData.DataSource = dtCurrentTable;
                grvData.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetPreviousData();
    }

    private void AddNewRowToGridServIn()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable2"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable2"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    DropDownList box1 = (DropDownList)grvServIn.Rows[rowIndex].Cells[1].FindControl("ddlLocal"); //Local
                    TextBox box2 = (TextBox)grvServIn.Rows[rowIndex].Cells[2].FindControl("txtValor"); //Valor
                    DropDownList box3 = (DropDownList)grvServIn.Rows[rowIndex].Cells[3].FindControl("ddlPagamento1"); //Pagamento


                    drCurrentRow = dtCurrentTable.NewRow();
                    //drCurrentRow["#"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["Local"] = box1.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Valor"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Pagamento"] = box3.SelectedValue;
                    rowIndex++;
                }

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable2"] = dtCurrentTable;

                grvServIn.DataSource = dtCurrentTable;
                grvServIn.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetPreviousDataServIn();
    }

    private void AddNewRowToGridServAd()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable3"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable3"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)grvServAd.Rows[rowIndex].Cells[1].FindControl("txtVoucher"); //Voucher
                    DropDownList box2 = (DropDownList)grvServAd.Rows[rowIndex].Cells[2].FindControl("ddlPasseio"); //Passeio
                    DropDownList box3 = (DropDownList)grvServAd.Rows[rowIndex].Cells[3].FindControl("ddlVendedor"); //Vendedor
                    TextBox box4 = (TextBox)grvServAd.Rows[rowIndex].Cells[4].FindControl("txtValor2"); //Valor
                    TextBox box5 = (TextBox)grvServAd.Rows[rowIndex].Cells[5].FindControl("txtData"); //Data
                    TextBox box6 = (TextBox)grvServAd.Rows[rowIndex].Cells[6].FindControl("txtHora"); //Hora
                    DropDownList box7 = (DropDownList)grvServAd.Rows[rowIndex].Cells[7].FindControl("ddlPagamento2"); //Pagamento
                    DropDownList box8 = (DropDownList)grvServAd.Rows[rowIndex].Cells[8].FindControl("ddlStatus"); //Status

                    drCurrentRow = dtCurrentTable.NewRow();
                    //drCurrentRow["#"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["Voucher"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Passeio"] = box2.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Vendedor"] = box3.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Valor"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["Data"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["Hora"] = box6.Text;
                    dtCurrentTable.Rows[i - 1]["Pagamento"] = box7.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Status"] = box8.SelectedValue;
                    rowIndex++;
                }

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable3"] = dtCurrentTable;

                grvServAd.DataSource = dtCurrentTable;
                grvServAd.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetPreviousDataServAd();
    }

    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable1"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grvData.Rows[rowIndex].Cells[1].FindControl("txtNome");
                    TextBox box2 = (TextBox)grvData.Rows[rowIndex].Cells[2].FindControl("txtIdentidade");
                    TextBox box3 = (TextBox)grvData.Rows[rowIndex].Cells[3].FindControl("txtOrgao");
                    TextBox box4 = (TextBox)grvData.Rows[rowIndex].Cells[4].FindControl("txtTelefone");
                    TextBox box5 = (TextBox)grvData.Rows[rowIndex].Cells[5].FindControl("txtObs");
                    LinkButton box6 = (LinkButton)grvData.Rows[rowIndex].Cells[6].FindControl("lnkExcluirPAX");

                    box1.Text = dt.Rows[i]["Nome"].ToString();
                    box2.Text = dt.Rows[i]["Identidade"].ToString();
                    box3.Text = dt.Rows[i]["OrgaoExp"].ToString();
                    box4.Text = dt.Rows[i]["Telefone"].ToString();
                    box5.Text = dt.Rows[i]["Obs"].ToString();
                    box6.ID = "lnkExcluirPAX";

                    rowIndex++;
                }

            }
        }
    }

    private void SetPreviousDataServIn()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable2"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable2"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DropDownList box1 = (DropDownList)grvServIn.Rows[rowIndex].Cells[1].FindControl("ddlLocal");
                    TextBox box2 = (TextBox)grvServIn.Rows[rowIndex].Cells[2].FindControl("txtValor");
                    DropDownList box3 = (DropDownList)grvServIn.Rows[rowIndex].Cells[3].FindControl("ddlPagamento1");
                    LinkButton box6 = (LinkButton)grvServIn.Rows[rowIndex].Cells[4].FindControl("lnkExcluirServIn");

                    box1.SelectedValue = dt.Rows[i]["Local"].ToString();
                    box2.Text = dt.Rows[i]["Valor"].ToString();
                    box3.SelectedValue = dt.Rows[i]["Pagamento"].ToString();
                    box6.ID = "lnkExcluirServIn";

                    rowIndex++;
                }
            }
        }
    }

    private void SetPreviousDataServAd()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable3"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable3"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grvServAd.Rows[rowIndex].Cells[1].FindControl("txtVoucher");
                    DropDownList box2 = (DropDownList)grvServAd.Rows[rowIndex].Cells[2].FindControl("ddlPasseio");
                    DropDownList box3 = (DropDownList)grvServAd.Rows[rowIndex].Cells[3].FindControl("ddlVendedor");
                    TextBox box4 = (TextBox)grvServAd.Rows[rowIndex].Cells[4].FindControl("txtValor2");
                    TextBox box5 = (TextBox)grvServAd.Rows[rowIndex].Cells[5].FindControl("txtData");
                    TextBox box6 = (TextBox)grvServAd.Rows[rowIndex].Cells[6].FindControl("txtHora");
                    DropDownList box7 = (DropDownList)grvServAd.Rows[rowIndex].Cells[7].FindControl("ddlPagamento2");
                    DropDownList box8 = (DropDownList)grvServAd.Rows[rowIndex].Cells[8].FindControl("ddlStatus");
                    LinkButton box9 = (LinkButton)grvServAd.Rows[rowIndex].Cells[9].FindControl("lnkExcluirServAd");


                    box1.Text = dt.Rows[i]["Voucher"].ToString();
                    box2.SelectedValue = dt.Rows[i]["Passeio"].ToString();
                    box3.SelectedValue = dt.Rows[i]["Vendedor"].ToString();
                    box4.Text = dt.Rows[i]["Valor"].ToString();
                    box5.Text = dt.Rows[i]["Data"].ToString();
                    box6.Text = dt.Rows[i]["Hora"].ToString();
                    box7.SelectedValue = dt.Rows[i]["Pagamento"].ToString();
                    box8.SelectedValue = dt.Rows[i]["Status"].ToString();
                    box9.ID = "lnkExcluirServAd";


                    rowIndex++;
                }
            }
        }
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable1"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                drCurrentRow = dt.NewRow();
                ViewState["CurrentTable1"] = dt;
                grvData.DataSource = dt;
                grvData.DataBind();

                //for (int i = 0; i < grvData.Rows.Count - 1; i++)
                //{
                //    grvData.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                //}
                SetPreviousData();
            }
        }
    }

    protected void grvServIn_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ViewState["CurrentTable2"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable2"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                drCurrentRow = dt.NewRow();
                ViewState["CurrentTable2"] = dt;
                grvServIn.DataSource = dt;
                grvServIn.DataBind();

                //for (int i = 0; i < grvData.Rows.Count - 1; i++)
                //{
                //    grvServIn.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                //}
                SetPreviousDataServIn();
            }
        }
    }

    protected void grvServAd_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ViewState["CurrentTable3"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable3"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                drCurrentRow = dt.NewRow();
                ViewState["CurrentTable3"] = dt;
                grvServAd.DataSource = dt;
                grvServAd.DataBind();

                //for (int i = 0; i < grvServAd.Rows.Count - 1; i++)
                //{
                //    grvServAd.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                //}
                SetPreviousDataServAd();
            }
        }
    }

    protected void RowDataBound1(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //POPULANDO COMBO DENTRO DO GRID
            DropDownList ddlLocal = (e.Row.FindControl("ddlLocal") as DropDownList);
            ddlLocal.DataSource = GetData(" select ID_SERV_INCLUSO , SERVICO_SERV_INCLUSO from SERV_INCLUSO ");
            ddlLocal.DataTextField = "SERVICO_SERV_INCLUSO";
            ddlLocal.DataValueField = "ID_SERV_INCLUSO";
            ddlLocal.DataBind();

            DropDownList ddlPagamento = (e.Row.FindControl("ddlPagamento1") as DropDownList);
            ddlPagamento.DataSource = GetData(" select ID_FORMA_DE_PAGAMENTO, FORMA_DE_PAGAMENTO from FORMA_DE_PAGAMENTO ");
            ddlPagamento.DataTextField = "FORMA_DE_PAGAMENTO";
            ddlPagamento.DataValueField = "ID_FORMA_DE_PAGAMENTO";
            ddlPagamento.DataBind();

        }
    }

    protected void RowDataBound2(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        //POPULANDO COMBO DENTRO DO GRID
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlPasseio = (e.Row.FindControl("ddlPasseio") as DropDownList);
            ddlPasseio.DataSource = GetData(" select  ID_SERV_ADC , PASSEIO_SERV_ADC from SERV_ADC ");
            ddlPasseio.DataTextField = "PASSEIO_SERV_ADC";
            ddlPasseio.DataValueField = "ID_SERV_ADC";
            ddlPasseio.DataBind();

            DropDownList ddlVendedor = (e.Row.FindControl("ddlVendedor") as DropDownList);
            ddlVendedor.DataSource = GetData(" select  ID_VENDEDOR , NOME_VENDEDOR from VENDEDORES ");
            ddlVendedor.DataTextField = "NOME_VENDEDOR";
            ddlVendedor.DataValueField = "ID_VENDEDOR";
            ddlVendedor.DataBind();

            DropDownList ddlPagamento = (e.Row.FindControl("ddlPagamento2") as DropDownList);
            ddlPagamento.DataSource = GetData(" select  ID_FORMA_DE_PAGAMENTO , FORMA_DE_PAGAMENTO from FORMA_DE_PAGAMENTO ");
            ddlPagamento.DataTextField = "FORMA_DE_PAGAMENTO";
            ddlPagamento.DataValueField = "ID_FORMA_DE_PAGAMENTO";
            ddlPagamento.DataBind();

            DropDownList ddlStatus = (e.Row.FindControl("ddlStatus") as DropDownList);
            ddlStatus.DataSource = GetData(" select  ID_STATUS , STATUS_STATUS from STATUS ");
            ddlStatus.DataTextField = "STATUS_STATUS";
            ddlStatus.DataValueField = "ID_STATUS";
            ddlStatus.DataBind();

        }
    }

    private DataSet GetData(string query)
    {
        string conString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds);
                    return ds;
                }
            }
        }
    }

    void LoadCombos()
    {

        // POPULATE AGENCIAS DROP DOWN LIST
        Agencias c = new Agencias();
        List<Agencias> details = c.GetAgenciasCombo();
        ddlAgencia.DataTextField = "NOME";
        ddlAgencia.DataValueField = "ID";
        ddlAgencia.DataSource = details;
        ddlAgencia.DataBind();

        // POPULATE VOOS CHEGADA DROP DOWN LIST
        Voos vc = new Voos();
        List<Voos> vcdetails = vc.GetVooChegadaCombo();
        ddlVooChegada.DataTextField = "SIGLA";
        ddlVooChegada.DataValueField = "ID";
        ddlVooChegada.DataSource = vcdetails;
        ddlVooChegada.DataBind();

        // POPULATE VOOS SAIDA DROP DOWN LIST
        Voos vs = new Voos();
        List<Voos> vsdetails = vs.GetVooSaidaCombo();
        ddlVooSaida.DataTextField = "SIGLA";
        ddlVooSaida.DataValueField = "ID";
        ddlVooSaida.DataSource = vsdetails;
        ddlVooSaida.DataBind();

        // POPULATE HOTEIS DROP DOWN LIST
        Hoteis h = new Hoteis();
        List<Hoteis> hdetails = h.GetHoteisCombo();
        ddlHotel.DataTextField = "NOME";
        ddlHotel.DataValueField = "ID";
        ddlHotel.DataSource = hdetails;
        ddlHotel.DataBind();
    }

    void getInfoChegada(string IDVoo)
    {

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select HORA_VOO, NOME_AEROPORTO  from VOOS, AEROPORTOS WHERE VOOS.AEROPORTO_VOO = AEROPORTOS.ID_AEROPORTO AND ID_VOO=" + IDVoo);
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        txtVooHoraChegada.Text = "";
        txtAeroportoChegada.Text = "";
        while (reader.Read())
        {
            txtVooHoraChegada.Text = reader.GetString(0);
            txtAeroportoChegada.Text = reader.GetString(1);
        }

    }
    void getInfoSaida(string IDVoo)
    {

        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select HORA_VOO, NOME_AEROPORTO  from VOOS, AEROPORTOS WHERE VOOS.AEROPORTO_VOO = AEROPORTOS.ID_AEROPORTO AND ID_VOO=" + IDVoo);
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        txtVooHoraSaida.Text = "";
        txtAeroportoSaida.Text = "";
        while (reader.Read())
        {
            txtVooHoraSaida.Text = reader.GetString(0);
            txtAeroportoSaida.Text = reader.GetString(1);
        }


    }

    string getValorServIn(string strLocalNo)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select PRECO_SERV_INCLUSO from SERV_INCLUSO ");
        str.AppendLine(" where ID_SERV_INCLUSO = " + strLocalNo);
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        decimal decPreco = 0;
        while (reader.Read())
        {
            decPreco = reader.GetDecimal(0);
        }
        string strPreco = Convert.ToString(decPreco);
        return strPreco;
    }

    string getValorServAd(string strPasseioNo)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;
        StringBuilder str = new StringBuilder();
        str.AppendLine(" select PRECO_SERV_ADC from SERV_ADC ");
        str.AppendLine(" where ID_SERV_ADC = " + strPasseioNo);
        cmd.CommandText = str.ToString();
        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        decimal decPreco = 0;
        while (reader.Read())
        {
            decPreco = reader.GetDecimal(0);
        }
        string strPreco = Convert.ToString(decPreco);
        return strPreco;
    }

    protected void ddlLocal_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl.Parent.Parent;

        string strLocalNo = ddl.SelectedValue.ToString();

        string strValor = getValorServIn(strLocalNo);

        ((TextBox)row.FindControl("txtValor")).Text = strValor;

    }

    protected void ddlPasseio_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl.NamingContainer;

        string strPasseioNo = ddl.SelectedValue.ToString();

        string strValor = getValorServAd(strPasseioNo);

        ((TextBox)row.FindControl("txtValor2")).Text = strValor;

    }

    protected void ddlVooChegada_Change(object sender, EventArgs e)
    {
        getInfoChegada(ddlVooChegada.SelectedValue);
    }
    protected void ddlVooSaida_Change(object sender, EventArgs e)
    {
        getInfoSaida(ddlVooSaida.SelectedValue);

    }
}