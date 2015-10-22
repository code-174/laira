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

public partial class ALTERAR_OS_ADC : System.Web.UI.Page
{
    protected string OSNo;
    protected void Page_Load(object sender, EventArgs e)
    {  
        if (!IsPostBack)
        {
            string strOSNo = Request.QueryString["OSNo"];

            Titulo.InnerText = "Alterar OS (Passeios) Nr." + " " + strOSNo;

            LoadCombos();

            string strTipo = "N";
            List<OrdemServAdc> l = OrdemServAdc.GetOSAdc(strOSNo, strTipo);
            
            foreach (var item in l)
            {
                ddlServicoFeitoPor.SelectedValue = l[0].FEITO_POR;
                txtObs.Text = l[0].OBS_OS;
                ddlMotorista.SelectedValue = l[0].MOTORISTA;
                ddlGuia.SelectedValue = l[0].GUIA;
            }

            LoadGrid(strOSNo);

            ViewState["OSNo"] = strOSNo; 
        }

        if (ViewState["OSNo"] != null)
        {
            OSNo = ViewState["OSNo"].ToString();
        }
    }
    private void LoadGrid(string strOSNo)
    {
        Int64 ID_OS = Convert.ToInt64(strOSNo);
        GridView1.DataSource = FichasListagem.GetRelatorioFichasOSAdc(ID_OS);
        GridView1.DataBind();
    }
    void LoadCombos()
    {
        // POPULATE SERVICO FEITO POR DROP DOWN LIST
        Prestadores c = new Prestadores();
        List<Prestadores> details = c.GetPrestadoresCombo();
        ddlServicoFeitoPor.DataTextField = "NOME";
        ddlServicoFeitoPor.DataValueField = "ID";
        ddlServicoFeitoPor.DataSource = details;
        ddlServicoFeitoPor.DataBind();

        // POPULATE MOTORISTA DROP DOWN LIST
        Prestadores cm = new Prestadores();
        List<Prestadores> detailsMot = cm.GetPrestadoresCombo();
        ddlMotorista.DataTextField = "NOME";
        ddlMotorista.DataValueField = "ID";
        ddlMotorista.DataSource = detailsMot;
        ddlMotorista.DataBind();

        // POPULATE GUIA DROP DOWN LIST
        Prestadores cg = new Prestadores();
        List<Prestadores> detailsGui = c.GetPrestadoresCombo();
        ddlGuia.DataTextField = "NOME";
        ddlGuia.DataValueField = "ID";
        ddlGuia.DataSource = detailsGui;
        ddlGuia.DataBind();
    }
    protected void lnkProcessar_Click(object sender, EventArgs e)
    {
        // TO DO VERIFICAR CAMPOS
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["LairaWebDB"].ConnectionString;
        cmd.Connection = conn;

        StringBuilder str = new StringBuilder();

        str.AppendLine(" update OS_ADC ");
        str.AppendLine(" set FEITO_POR_NO = @FEITO_POR_NO, ");
        str.AppendLine(" OBS = @OBS, ");
        str.AppendLine(" MOTORISTA_NO = @MOTORISTA_NO, ");
        str.AppendLine(" GUIA_NO = @GUIA_NO ");
        str.AppendLine(" where ID_OS_ADC = @ID_OS_ADC ");

        cmd.CommandText = str.ToString();
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add(new SqlParameter("@FEITO_POR_NO", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlServicoFeitoPor.SelectedValue.ToString());
        cmd.Parameters.Add(new SqlParameter("@OBS", SqlDbType.NChar)).Value = txtObs.Text.Trim();
        cmd.Parameters.Add(new SqlParameter("@MOTORISTA_NO", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlMotorista.SelectedValue.ToString());
        cmd.Parameters.Add(new SqlParameter("@GUIA_NO", SqlDbType.BigInt)).Value = Convert.ToInt64(ddlGuia.SelectedValue.ToString());
        cmd.Parameters.Add(new SqlParameter("@ID_OS_ADC", SqlDbType.BigInt)).Value = Convert.ToInt64(OSNo);

       
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cmd = null;
        conn.Close();
        conn.Dispose();

        

        // Select the checkboxes from the GridView control
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridViewRow row = GridView1.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;            

            if (!isChecked)
            {
                Int64 SERV_ADC_FICHA_NO = Convert.ToInt64(GridView1.DataKeys[row.RowIndex].Value);
                UpdateServAdFicha(SERV_ADC_FICHA_NO);
            }           
        }
    }    

    void UpdateServAdFicha(Int64 SERV_ADC_FICHA_NO)
    {
        ServAdFicha c = new ServAdFicha();
        c.UpdateServAdFicha(SERV_ADC_FICHA_NO);
    }
}