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

public partial class CADASTRAR_FICHA : System.Web.UI.Page
{

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
    private void SetInitialRow()
    {
        GridPAX();
        GridServIn();
        GridServAd();
    }


    bool VerificarCampos()
    {
        if (txtCodFicha.Text.Trim() == "")
        {
            return false;
        }
        else if (txtDataChegada.Text.Trim() == "")
        {
            return false;
        }
        else if (txtDataSaida.Text.Trim() == "")
        {
            return false;
        }

        else if (ddlVooChegada.SelectedValue.Trim() == "")
        {
            return false;
        }

        else if (txtVooHoraChegada.Text.Trim() == "")
        {
            return false;
        }
        else if (ddlVooSaida.SelectedValue.Trim() == "")
        {
            return false;
        }
        else if (txtVooHoraSaida.Text.Trim() == "")
        {
            return false;
        }
        else if (txtAeroportoChegada.Text.Trim() == "")
        {
            return false;
        }
        else if (txtAeroportoSaida.Text.Trim() == "")
        {
            return false;
        }
        else if (txtCodExcursao.Text.Trim() == "")
        {
            return false;
        }
        else if (ddlAgencia.SelectedValue.Trim() == "")
        {
            return false;
        }
        else if (txtRecibo.Text.Trim() == "")
        {
            return false;
        }
        else if (ddlHotel.SelectedValue.Trim() == "")
        {
            return false;
        }
        else if (txtApartamento.Text.Trim() == "")
        {
            return false;
        }
        else if (txtSaidaHotel.Text.Trim() == "")
        {
            return false;
        }

        return true;
    }
    protected void btnAdFicha_Click(object sender, EventArgs e)
    {


        if (VerificarCampos())
        {


            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
                cmd.Connection = conn;

                StringBuilder str = new StringBuilder();
                str.AppendLine(" INSERT INTO [FICHAS] ");
                str.AppendLine(" ([CODIGO_FICHA] ");
                str.AppendLine(" ,[DATA_CHEGADA_FICHA] ");
                str.AppendLine(" ,[DATA_SAIDA_FICHA] ");
                str.AppendLine(" ,[VOO_CHEGADA_FICHA] ");
                str.AppendLine(" ,[VOO_CHEGADA_HORA_FICHA] ");
                str.AppendLine(" ,[VOO_SAIDA_FICHA] ");
                str.AppendLine(" ,[VOO_SAIDA_HORA_FICHA] ");
                str.AppendLine(" ,[AEROPORTO_CHEGADA_FICHA] ");
                str.AppendLine(" ,[AEROPORTO_SAIDA_FICHA] ");
                str.AppendLine(" ,[COD_EXCURSAO_FICHA] ");
                str.AppendLine(" ,[AGENCIA_FICHA] ");
                str.AppendLine(" ,[RECIBO_FICHA] ");
                str.AppendLine(" ,[HOTEL_FICHA] ");
                str.AppendLine(" ,[APARTAMENTO_FICHA] ");
                str.AppendLine(" ,[SAIDA_DO_HOTEL_FICHA] ");
                str.AppendLine(" )");
                str.AppendLine(" VALUES ");
                str.AppendLine(" (@A ");
                str.AppendLine(" ,@B ");
                str.AppendLine(" ,@C ");
                str.AppendLine(" ,@D ");
                str.AppendLine(" ,@E ");
                str.AppendLine(" ,@F ");
                str.AppendLine(" ,@G ");
                str.AppendLine(" ,@H ");
                str.AppendLine(" ,@I ");
                str.AppendLine(" ,@J ");
                str.AppendLine(" ,@L ");
                str.AppendLine(" ,@M ");
                str.AppendLine(" ,@N ");
                str.AppendLine(" ,@O ");
                str.AppendLine(" ,@P )");
                cmd.CommandText = str.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.NChar)).Value = txtCodFicha.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.NChar)).Value = txtDataChegada.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.NChar)).Value = txtDataSaida.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@D", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlVooChegada.SelectedValue.ToString());
                cmd.Parameters.Add(new SqlParameter("@E", SqlDbType.NChar)).Value = txtVooHoraChegada.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@F", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlVooSaida.SelectedValue.ToString());
                cmd.Parameters.Add(new SqlParameter("@G", SqlDbType.NChar)).Value = txtVooHoraSaida.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@H", SqlDbType.NChar)).Value = txtAeroportoChegada.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@I", SqlDbType.NChar)).Value = txtAeroportoSaida.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@J", SqlDbType.NChar)).Value = txtCodExcursao.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@L", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlAgencia.SelectedValue.ToString());
                cmd.Parameters.Add(new SqlParameter("@M", SqlDbType.NChar)).Value = txtRecibo.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@N", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlHotel.SelectedValue.ToString());
                cmd.Parameters.Add(new SqlParameter("@O", SqlDbType.NChar)).Value = txtApartamento.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@P", SqlDbType.NChar)).Value = txtSaidaHotel.Text.Trim();
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                conn.Close();
                conn.Dispose();

                System.Threading.Thread.Sleep(2000);

                Int64 IDFicha = getLastFicha();

                //
                for (int count = 0; count < grvData.Rows.Count; count++)
                {
                    var vTextBox1 = ((TextBox)grvData.Rows[count].FindControl("TextBox1")).Text;
                    var vTextBox2 = ((TextBox)grvData.Rows[count].FindControl("TextBox2")).Text;
                    var vTextBox3 = ((TextBox)grvData.Rows[count].FindControl("TextBox3")).Text;
                    var vTextBox4 = ((TextBox)grvData.Rows[count].FindControl("TextBox4")).Text;
                    var vTextBox5 = ((TextBox)grvData.Rows[count].FindControl("TextBox5")).Text;

                    InserirPAX(IDFicha, vTextBox1.ToString(), vTextBox2.ToString(), vTextBox3.ToString(), vTextBox4.ToString(), vTextBox5.ToString());

                }

                Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('Registro salvo com sucesso!');</script>", false);


            }

            catch (Exception ex)
            {
                throw ex;
                //this.ShowAlert(ex.Message);
            }
        }

        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "Alerta", "<script language='javascript'>window.alert('Favor preencher os campos!');</script>", false);
        }
    }

    Int64 getLastFicha()
    {
        Int64 retorno = 0;

        Fichas c = new Fichas();
        retorno = c.GetLastFicha();
        return retorno;

    }

    void InserirPAX(Int64 IDFicha, string Nome, string Identidade, string OrgaoExp, string Telefone, string Obs)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;

        StringBuilder str = new StringBuilder();
        str.AppendLine(" INSERT INTO [PASSAGEIROS] ");
        str.AppendLine(" ([FICHA_NO] ");
        str.AppendLine(" ,[NOME_PASSAGEIRO] ");
        str.AppendLine(" ,[IDENTIDADE_PASSAGEIRO] ");
        str.AppendLine(" ,[ORG_EXPED_PASSAGEIRO] ");
        str.AppendLine(" ,[TELEFONE_PASSAGEIRO] ");
        str.AppendLine(" ,[OBS_PASSAGEIRO]");
        str.AppendLine(" )");
        str.AppendLine(" VALUES ");
        str.AppendLine(" (@A ");
        str.AppendLine(" ,@B ");
        str.AppendLine(" ,@C ");
        str.AppendLine(" ,@D ");
        str.AppendLine(" ,@E ");
        str.AppendLine(" ,@F )");
        cmd.CommandText = str.ToString();
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@A", SqlDbType.BigInt)).Value = IDFicha;
        cmd.Parameters.Add(new SqlParameter("@B", SqlDbType.NChar)).Value = Nome;
        cmd.Parameters.Add(new SqlParameter("@C", SqlDbType.NChar)).Value = Identidade;
        cmd.Parameters.Add(new SqlParameter("@D", SqlDbType.NChar)).Value = OrgaoExp;
        cmd.Parameters.Add(new SqlParameter("@E", SqlDbType.NChar)).Value = Telefone;
        cmd.Parameters.Add(new SqlParameter("@F", SqlDbType.NChar)).Value = Obs;
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cmd = null;
        conn.Close();
        conn.Dispose();


    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("MENU_FICHAS.aspx"); //LISTAR_FICHAS
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetInitialRow();
            LoadCombos();
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

    protected void RowDataBound2(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
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

            DropDownList ddlPagamento = (e.Row.FindControl("ddlPagamento") as DropDownList);
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

    protected void RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList ddlLocal = (e.Row.FindControl("ddlLocal") as DropDownList);
            ddlLocal.DataSource = GetData(" select ID_SERV_INCLUSO , SERVICO_SERV_INCLUSO from SERV_INCLUSO ");
            ddlLocal.DataTextField = "SERVICO_SERV_INCLUSO";
            ddlLocal.DataValueField = "ID_SERV_INCLUSO";
            ddlLocal.DataBind();

            

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
                    TextBox box3 = (TextBox)grvServIn.Rows[rowIndex].Cells[3].FindControl("txtPagamento"); //Pagamento


                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["#"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["Local"] = box1.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Valor"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Pagamento"] = box3.Text;
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
                    TextBox box1 = (TextBox)grvServAd.Rows[rowIndex].Cells[1].FindControl("ddlLocal"); //Voucher
                    DropDownList box2 = (DropDownList)grvServAd.Rows[rowIndex].Cells[2].FindControl("ddlPasseio"); //Passeio
                    DropDownList box3 = (DropDownList)grvServAd.Rows[rowIndex].Cells[3].FindControl("ddlVendedor"); //Vendedor
                    TextBox box4 = (TextBox)grvServAd.Rows[rowIndex].Cells[4].FindControl("TextBox4"); //Valor
                    TextBox box5 = (TextBox)grvServAd.Rows[rowIndex].Cells[5].FindControl("TextBox5"); //Data
                    TextBox box6 = (TextBox)grvServAd.Rows[rowIndex].Cells[6].FindControl("TextBox6"); //Hora
                    DropDownList box7 = (DropDownList)grvServAd.Rows[rowIndex].Cells[7].FindControl("ddlPagamento"); //Pagamento
                    DropDownList box8 = (DropDownList)grvServAd.Rows[rowIndex].Cells[8].FindControl("ddlStatus"); //Status

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["#"] = i + 1;
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
                    drCurrentRow["#"] = i + 1;
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
                    ImageButton box6 = (ImageButton)grvData.Rows[rowIndex].Cells[6].FindControl("lnkExcluir");

                    box1.Text = dt.Rows[i]["Nome"].ToString();
                    box2.Text = dt.Rows[i]["Identidade"].ToString();
                    box3.Text = dt.Rows[i]["OrgaoExp"].ToString();
                    box4.Text = dt.Rows[i]["Telefone"].ToString();
                    box5.Text = dt.Rows[i]["Obs"].ToString();
                    box6.ImageUrl = "~/Figuras/btn_Delete.gif";

                    rowIndex++;
                }
            }
        }
    }

    protected void ButtonAddServIn_Click(object sender, EventArgs e)
    {
        AddNewRowToGridServIn();
    }

    protected void ButtonAddServAd_Click(object sender, EventArgs e)
    {
        AddNewRowToGridServAd();
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
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
                    TextBox box3 = (TextBox)grvServIn.Rows[rowIndex].Cells[3].FindControl("txtPagamento");
                    ImageButton box6 = (ImageButton)grvServIn.Rows[rowIndex].Cells[4].FindControl("lnkExcluirServIn");

                    box1.SelectedValue = dt.Rows[i]["Local"].ToString();
                    box2.Text = dt.Rows[i]["Valor"].ToString();
                    box3.Text = dt.Rows[i]["Pagamento"].ToString();
                    box6.ImageUrl = "~/Figuras/btn_Delete.gif";

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
                    TextBox box1 = (TextBox)grvServAd.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                    DropDownList box2 = (DropDownList)grvServAd.Rows[rowIndex].Cells[2].FindControl("ddlPasseio");
                    DropDownList box3 = (DropDownList)grvServAd.Rows[rowIndex].Cells[3].FindControl("ddlVendedor");
                    TextBox box4 = (TextBox)grvServAd.Rows[rowIndex].Cells[4].FindControl("TextBox4");
                    TextBox box5 = (TextBox)grvServAd.Rows[rowIndex].Cells[5].FindControl("TextBox5");
                    TextBox box6 = (TextBox)grvServAd.Rows[rowIndex].Cells[6].FindControl("TextBox6");
                    DropDownList box7 = (DropDownList)grvServAd.Rows[rowIndex].Cells[7].FindControl("ddlPagamento");
                    DropDownList box8 = (DropDownList)grvServAd.Rows[rowIndex].Cells[8].FindControl("ddlStatus");
                    ImageButton box9 = (ImageButton)grvServAd.Rows[rowIndex].Cells[9].FindControl("lnkExcluirServIn");


                    box1.Text = dt.Rows[i]["Voucher"].ToString();
                    box2.SelectedValue = dt.Rows[i]["Passeio"].ToString();
                    box3.SelectedValue = dt.Rows[i]["Vendedor"].ToString();
                    box4.Text = dt.Rows[i]["Valor"].ToString();
                    box5.Text = dt.Rows[i]["Data"].ToString();
                    box6.Text = dt.Rows[i]["Hora"].ToString();
                    box7.SelectedValue = dt.Rows[i]["Pagamento"].ToString();
                    box8.SelectedValue = dt.Rows[i]["Status"].ToString();
                    box9.ImageUrl = "~/Figuras/btn_Delete.gif";                          
                   

                    rowIndex++;
                }
            }
        }
    }

}

