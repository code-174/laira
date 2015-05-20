// =========================================
//Code developed by MetraTech team
// =========================================

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using MetraTech;
using MetraTech.ActivityServices.Common;
using MetraTech.ActivityServices.Services.Common;
using MetraTech.Auth.Capabilities;
using MetraTech.Core.Services.ClientProxies;
using MetraTech.DataAccess;
using MetraTech.DomainModel.AccountTypes;
using MetraTech.DomainModel.BaseTypes;
using MetraTech.DomainModel.Enums;
using MetraTech.UI.Common;
using System.Web.UI;
using MetraTech.Interop.COMMeter;
using MetraTech.Interop.MTServerAccess;
using MetraTech.Interop.MTAuth;
using System.Drawing;
using System.Web.UI.HtmlControls;



/// <summary>
/// Report page (ad hoc)
/// </summary>
public partial class Aviation_Reports : MTPage
{

    /// <summary>
    /// Load page and set default language to pt-br
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //set culture
        System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("pt-br");

        if (!Page.IsPostBack)
        {
            SetDefaults();
            FillDDLs();
        }

    }

    void SetLocalization(string idiom)
    {
        //todo:

        //switch (switch_on)
        //{
        //  default:
        //}
    }

    /// <summary>
    /// Agni Campos
    /// set default dates
    /// </summary>
    private void SetDefaults()
    {

        DateTime today = DateTime.Today;
        DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
        mtdpStartDate.Text = startOfMonth.ToString();

        mtdpEndDate.Text = System.DateTime.Now.ToShortDateString();

        grvICAO.DataSource = GetAllAirlines();
        grvICAO.DataBind();

        GetIntervals();

        FillddlFantasia();
        FillddlContratos();
        FillddlLUC();

    }

    public void GenerateSpreedSheet(GridView gv)
    {

        gv.AllowPaging = false;
        BindGrid();

        string reportName = ddlReports.SelectedValue.Replace(" ", "_").Replace("ç", "c").Replace("ã", "a").Replace("ê", "e").Replace("ô", "o").Replace("í", "i").Replace("ó", "o");

        string html = GenerateHtmlForExport(gv);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
        HttpContext.Current.Response.Charset = "ISO-8859-1";
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + reportName + ".xls");
        HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        HttpContext.Current.Response.ContentType = "application/vnd.xls";

        HttpContext.Current.Response.Write(reportName);

        byte[] read = new byte[4096];
        Int32 countRead = 0;

        Stream reader = new MemoryStream(new UTF8Encoding().GetBytes(html));
        countRead = reader.Read(read, 0, 4096);

        while (countRead > 0)
        {
            HttpContext.Current.Response.BinaryWrite(read);
            read = new byte[4096];
            countRead = reader.Read(read, 0, 4096);
        }

        HttpContext.Current.Response.End();
    }

    private string GenerateHtmlForExport(GridView gv)
    {
        //gv.AllowPaging = false;
        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a table to contain the grid
                Table table = new Table();

                //  include the gridline settings
                table.GridLines = gv.GridLines;
                table.Style.Value = gv.Style.Value;
                table.SkinID = gv.SkinID;

                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    PrepareControlForExport(gv.HeaderRow);

                    table.Rows.Add(gv.HeaderRow);
                }

                //  add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    PrepareControlForExport(row);

                    table.Rows.Add(row);
                }

                //  add the footer row to the table
                if (gv.FooterRow != null)
                {
                    PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                foreach (TableRow row in table.Rows)
                {
                    row.Style.Add("padding", "4px 5px");
                    row.Style.Add("vertical-align", "middle");
                    row.Style.Add("line-height", "20px");
                    row.Style.Add("text-align", "left");
                    row.Style.Add("border-top", "1px dotted f#DDD");
                    row.Style.Add("border-collapse", "collapse");
                    row.Style.Add("border-spacing", "0px");
                    //row.Style.Add("text-decoration", "none");
                    row.Style.Add("font-family", "'Open Sans',sans-serif");
                    row.Style.Add("font-size", "13px");
                    row.Style.Add("Width", "190px");
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                return sw.ToString();
            }
        }
    }

    private void PrepareControlForExport(Control control)
    {
        //HideItems(control);

        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];

            if (current is HtmlInputCheckBox)
            {
                control.Controls.Remove(current);
            }
            else if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                //control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }
            else if (current is System.Web.UI.WebControls.Image)
            {
                control.Controls.Remove(current);
            }
            else if (current is DataControlFieldHeaderCell)
            {
                DataControlFieldHeaderCell dataControlFieldHeaderCell = (DataControlFieldHeaderCell)(current);
                dataControlFieldHeaderCell.Text = dataControlFieldHeaderCell.ContainingField.HeaderText;
                current = dataControlFieldHeaderCell;
            }

            if (current.HasControls())
            {
                PrepareControlForExport(current);
            }
        }
    }

    void ViewFilters(string sRpt)
    {

        if (sRpt == "(SELECIONE)" || sRpt == "------- Relatórios Aeroporto ------------" || sRpt == "------- Relatórios ANAC ------------" || sRpt == "------- Relatórios ERP ------------" || sRpt == "------- Relatórios Comercial ------------" || sRpt == "------- Relatórios Detalhamento Faturas ------------")
        {
            //Response.Write("<script type='text/javascript'>alert('É obrigatório selecionar um relatório para visualizar seus filtros!');</script>");
            return;
        }

        SelIntervalo.Visible = false;
        SelGrupo.Visible = false;
        ddlGrupo1.Visible = false;
        ddlGrupo2.Visible = false;
        ddlGrupo1.Checked = false;
        grvICAO.Visible = false;
        divGrid.Style.Add("height", "0px");
        btnOK.Visible = true;

        lblStartDate.Visible = true;
        mtdpStartDate.Visible = true;
        lblEndtDate.Visible = true;
        mtdpEndDate.Visible = true;

        ddBillingPeriod.Visible = false;

        switch (sRpt)
        {
            case "Detalhamento Embarque":
                lblStartDate.Visible = false;
                mtdpStartDate.Visible = false;
                lblEndtDate.Visible = false;
                mtdpEndDate.Visible = false;
                SelGrupo.Visible = true;
                ddlGrupo1.Visible = true;
                ddlGrupo2.Visible = false;
                grvICAO.Visible = true;
                ddlGrupo2.Checked = false;
                divGrid.Style.Add("height", "110px");
                ddlGrupo1.Checked = true;
                ddlGrupo1.Enabled = false;
                SelIntervalo.Visible = true;
                ddBillingPeriod.Visible = true;
                break;
            case "Detalhamento Conexão":
                lblStartDate.Visible = false;
                mtdpStartDate.Visible = false;
                lblEndtDate.Visible = false;
                mtdpEndDate.Visible = false;
                SelGrupo.Visible = true;
                ddlGrupo1.Visible = true;
                ddlGrupo2.Visible = false;
                grvICAO.Visible = true;
                ddlGrupo2.Checked = false;
                divGrid.Style.Add("height", "110px");
                ddlGrupo1.Checked = true;
                ddlGrupo1.Enabled = false;
                SelIntervalo.Visible = true;
                ddBillingPeriod.Visible = true;
                break;
            case "Detalhamento Pouso":
                lblStartDate.Visible = false;
                mtdpStartDate.Visible = false;
                lblEndtDate.Visible = false;
                mtdpEndDate.Visible = false;
                SelGrupo.Visible = true;
                ddlGrupo1.Visible = true;
                ddlGrupo2.Visible = true;
                grvICAO.Visible = true;
                ddlGrupo2.Checked = false;
                divGrid.Style.Add("height", "110px");
                ddlGrupo1.Checked = true;
                ddlGrupo1.Enabled = true;
                SelIntervalo.Visible = true;
                ddBillingPeriod.Visible = true;
                break;
            case "Detalhamento Permanencia":
                lblStartDate.Visible = false;
                mtdpStartDate.Visible = false;
                lblEndtDate.Visible = false;
                mtdpEndDate.Visible = false;
                SelGrupo.Visible = true;
                ddlGrupo1.Visible = true;
                ddlGrupo2.Visible = true;
                grvICAO.Visible = true;
                ddlGrupo2.Checked = false;
                divGrid.Style.Add("height", "110px");
                ddlGrupo1.Checked = true;
                ddlGrupo1.Enabled = true;
                SelIntervalo.Visible = true;
                ddBillingPeriod.Visible = true;
                break;
            case "Listagem Grupo I":
                lblStartDate.Visible = false;
                mtdpStartDate.Visible = false;
                lblEndtDate.Visible = false;
                mtdpEndDate.Visible = false;
                break;
            case "Listagem Grupo II":
                lblStartDate.Visible = false;
                mtdpStartDate.Visible = false;
                lblEndtDate.Visible = false;
                mtdpEndDate.Visible = false;
                break;
            case "Listagem Aeroportos":
                lblStartDate.Visible = false;
                mtdpStartDate.Visible = false;
                lblEndtDate.Visible = false;
                mtdpEndDate.Visible = false;
                break;
            case "Confirmação Eletrônica - Log":
                break;
            case "Pouso":
                SelGrupo.Visible = true;
                ddlGrupo1.Visible = true;
                ddlGrupo2.Visible = true;
                grvICAO.Visible = true;
                ddlGrupo2.Checked = false;
                divGrid.Style.Add("height", "110px");
                ddlGrupo1.Checked = true;
                ddlGrupo1.Enabled = true;
                break;
            case "Estadia":
                SelGrupo.Visible = true;
                ddlGrupo1.Visible = true;
                ddlGrupo2.Visible = true;
                grvICAO.Visible = true;
                ddlGrupo2.Checked = false;
                divGrid.Style.Add("height", "110px");
                ddlGrupo1.Checked = true;
                ddlGrupo1.Enabled = true;
                break;
            case "Manobra":
                SelGrupo.Visible = true;
                ddlGrupo1.Visible = true;
                ddlGrupo2.Visible = true;
                grvICAO.Visible = true;
                ddlGrupo2.Checked = false;
                divGrid.Style.Add("height", "110px");
                ddlGrupo1.Checked = true;
                ddlGrupo1.Enabled = true;
                break;
            case "Conexão":
                SelGrupo.Visible = true;
                ddlGrupo1.Visible = true;
                ddlGrupo2.Visible = false;
                grvICAO.Visible = true;
                ddlGrupo2.Checked = false;
                divGrid.Style.Add("height", "110px");
                ddlGrupo1.Checked = true;
                ddlGrupo1.Enabled = false;
                break;
            case "Embarque":
                SelGrupo.Visible = true;
                ddlGrupo1.Visible = true;
                ddlGrupo2.Visible = false;
                grvICAO.Visible = true;
                ddlGrupo2.Checked = false;
                divGrid.Style.Add("height", "110px");
                ddlGrupo1.Checked = true;
                ddlGrupo1.Enabled = false;
                break;
            case "Tarifas Analítico":
                break;
            case "RTE Resumido":
                break;
            case "DAT Resumido":
                break;
            case "RPE Resumido":
                break;
            case "RPE Analítico":
                break;
            case "Tarifas a Cobrar por Cliente":
                break;
            case "Suprimentos":
                lblStartDate.Visible = true;
                mtdpStartDate.Visible = true;
                lblEndtDate.Visible = true;
                mtdpEndDate.Visible = true;
                lblNomeFantasia.Visible = true;
                ddlFantasia.Visible = true;
                lblNumContrato.Visible = true;
                ddlContrato.Visible = true;
                lblLUC.Visible = true;
                ddlLUC.Visible = true;
                break;
            default:
                break;
        }
    }

    protected void dddlReports_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        grvData.Visible = false;
        lblGrandTotal.Text = "";
        lblGrandTotal.Visible = false;
        btnOK.Visible = false;
        btnPrint.Visible = false;
        col_erro.Text = "";
        col_erro.Visible = false;

        string sRpt = ddlReports.SelectedValue;
        ViewFilters(sRpt);
        SetDefaults();

    }

    protected void ddlGrupo1_CheckedChanged(object sender, System.EventArgs e)
    {

        grvData.Visible = false;
        grvICAO.Visible = false;
        BindGrid();
        col_erro.Text = "";
        col_erro.Visible = false;
        string sRpt = ddlReports.SelectedValue;
        divGrid.Style.Add("height", "0px");
        btnOK.Visible = true;
        btnPrint.Visible = true;
        if (ddlGrupo1.Checked)
        {
            divGrid.Style.Add("height", "110px");
            grvICAO.Visible = true;
        }
        else
        {
            if (sRpt != "Estadia" && sRpt != "Manobra" && sRpt != "Pouso" && sRpt != "Detalhamento Embarque" && sRpt != "Detalhamento Conexão" && sRpt != "Detalhamento Pouso" && sRpt != "Detalhamento Permanencia")
            {
                btnPrint.Visible = false;
                btnOK.Visible = false;
            }
        }
    }

    //private void HideItems(Control control)
    //{
    //    List<int> distinctOrderedColumns =  columnsToHide.Distinct<int>().OrderBy(col => col).ToList();
    //    int removedItems = 0;

    //    if (distinctOrderedColumns != null && distinctOrderedColumns.Count > 0)
    //    {
    //        foreach (int tmpColToRemove in distinctOrderedColumns)
    //        {
    //            int colToRemove = tmpColToRemove - removedItems;
    //            if (control.Controls.Count > colToRemove && colToRemove >= 0)
    //            {
    //                control.Controls.RemoveAt(colToRemove);
    //                removedItems++;
    //            }
    //        }
    //    }
    //}

    /// <summary>
    /// Agni Campos
    /// Fill list of available reports
    /// </summary>
    void FillDDLs()
    {
        //introduction of Capabilites for showing or not reports on list.
        var AviationReportsCapabilites = UI.SessionContext.SecurityContext.GetCapabilitiesOfType("AVIATION_REPORTS");
        var ANACReportsCapabilites = UI.SessionContext.SecurityContext.GetCapabilitiesOfType("ANAC_REPORTS");

        ddlReports.Items.Add("(SELECIONE)");                                //List of queries on ICE
        if ((AviationReportsCapabilites.Count > 0) || (UI.SessionContext.SecurityContext.IsSuperUser()))
        {
            ddlReports.Items.Add("------- Relatórios Aeroporto ------------");
            ddlReports.Items.Add("Relatório Analítico");                        //__ANAC__
            ddlReports.Items.Add("RPE Resumido");                               //__PASSAGEIROS__
            //ddlReports.Items.Add("RPE Analítico");                              //__RPE_ANALITICO_RPT__               dead ...
            ddlReports.Items.Add("RPE Analítico - Embarque e Conexão");         //__RPE_ANALITICO_EMB_CONEX_RPT__       ***new
            ddlReports.Items.Add("RPE Analítico- Desembarque");                 //__RPE_ANALITICO_DES_RPT__             ***new 
            ddlReports.Items.Add("Tarifas a Cobrar por Cliente");               //__TARIFAS_A_COBRAR_POR_CLIENTE__
            ddlReports.Items.Add("DAT Resumido");                               //__DAT__
            ddlReports.Items.Add("DAT Analítico");                               //__DAT_ANALITICO__
            ddlReports.Items.Add("RTE Resumido");                               //__RTE__
            ddlReports.Items.Add("Divergência RPExSISO");                       //__RPE_WITHOUT_SISO_RPT__
            ddlReports.Items.Add("Pendência SISOxRPE");                         //__SISO_WITHOUT_RPE_RPT__
            ddlReports.Items.Add("Confirmação Eletrônica - Log");               //__ELTR_CONF_RPT__
            ddlReports.Items.Add("Listagem Aeroportos");                        //__AEROPORTOS_RPT__
            ddlReports.Items.Add("Listagem Grupo I");                           //__GRP1_RPT__
            ddlReports.Items.Add("Listagem Grupo II");                          //__GRP2_RPT__
            ddlReports.Items.Add("Suprimentos");
            ddlReports.Items.Add("------- Relatórios Detalhamento Faturas ------------");
            ddlReports.Items.Add("Detalhamento Embarque");                      //__DET_EMBARQUE_RPT__
            ddlReports.Items.Add("Detalhamento Conexão");                       //__DET_CONEXAO_RPT__
            ddlReports.Items.Add("Detalhamento Pouso");                         //__DET_POUSO_RPT__
            ddlReports.Items.Add("Detalhamento Permanencia");                   //__DET_PERMANENCIA_RPT__
            ddlReports.Items.Add("------- Relatórios Comercial ------------");
            ddlReports.Items.Add("Listagem de Contratos");                      //__CONTRACT_RPT__
            ddlReports.Items.Add("Informe de Vendas");                          //__SALES_RPT__
            ddlReports.Items.Add("------- Relatórios ERP ------------");
            ddlReports.Items.Add("Exportação ERP (com LOGIN)");                 //__EXPORT_ERP_RPT__
            ddlReports.Items.Add("Sumarização ERP por Nome-Item");              //__GET_SUMMARIZATION_EXPORT_ERP_NOME_ITEM__
            ddlReports.Items.Add("Prévia Exportação ERP");                      //__PREVIEW_ERP_RPT__

        }
        if ((ANACReportsCapabilites.Count > 0) || (UI.SessionContext.SecurityContext.IsSuperUser()))
        {
            ddlReports.Items.Add("------- Relatórios ANAC ------------");
            ddlReports.Items.Add("Embarque");                                   //__EMPLANEMENT_RPT__
            ddlReports.Items.Add("Conexão");                                    //__CONNECTION_RPT__
            ddlReports.Items.Add("Pouso");                                      //__LANDING_RPT__
            ddlReports.Items.Add("Estadia");                                    //__PARKING_RPT__
            ddlReports.Items.Add("Manobra");                                    //__MANEUVER_RPT__
        }
    }

    protected void grvData_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {

        grvData.PageIndex = e.NewPageIndex;
        BindGrid();
        string sRpt = ddlReports.SelectedValue;
        CalculaTotal(sRpt);

    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //generate excel file
        GenerateSpreedSheet(grvData);
    }

    /// <summary>
    /// Function to validate date range
    /// </summary>
    /// <returns></returns>
    bool ValidaDados()
    {
        bool retorno = true;

        if ((mtdpStartDate.Text.Replace(" ", "") == "") || (mtdpEndDate.Text.Replace(" ", "") == ""))
        {
            retorno = false;
        }
        else
        {

            string dtIni = System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd").Replace("-", "");
            string dtFim = System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd").Replace("-", "");

            if (System.Int32.Parse(dtIni) > System.Int32.Parse(dtFim))
            {
                retorno = false;
            }
        }


        string sRpt = ddlReports.SelectedValue;

        switch (sRpt)
        {
            case "Listagem Grupo I":
                retorno = true;
                break;
            case "Listagem Grupo II":
                retorno = true;
                break;
            case "Listagem Aeroportos":
                retorno = true;
                break;
        }

        return retorno;
    }

    bool NeedDates()
    {

        string sRpt = ddlReports.SelectedValue;
        bool retorno = true;

        switch (sRpt)
        {
            case "Detalhamento Embarque":
                retorno = false;
                break;
            case "Detalhamento Conexão":
                retorno = false;
                break;
            case "Detalhamento Pouso":
                retorno = false;
                break;
            case "Detalhamento Permanencia":
                retorno = false;
                break;
            case "Listagem Grupo I":
                retorno = false;
                break;
            case "Listagem Grupo II":
                retorno = false;
                break;
            case "Listagem Aeroportos":
                retorno = false;
                break;
        }


        return retorno;
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if ((mtdpStartDate.Text.Replace(" ", "") != "") && (mtdpEndDate.Text.Replace(" ", "") != ""))
        {
            if (ValidaDados())
            {
                BindGrid();
                grvData.Visible = true;
            }
            else
            {
                if (NeedDates())
                {
                    Response.Write("<script type='text/javascript'>alert('É necessário selecionar [Data Fim Operação] maior ou igual [Data Início Operação]!');</script>");
                }
                else
                {
                    BindGrid();
                    grvData.Visible = true;

                }
            }
        }
        else
        {
            if (NeedDates())
            {
                Response.Write("<script type='text/javascript'>alert('É necessário preencher a [Data Início Operação] e a [Data Fim Operação]!');</script>");
            }
            else
            {
                BindGrid();
                grvData.Visible = true;

            }

        }
    }

    string IntervaloFilterProcess()
    {
        string retorno = "";
        string s = ddBillingPeriod.SelectedItem.Text;
        var posicao = s.IndexOf("(");

        if (posicao != -1)
        {
            posicao = (posicao - 1);
            retorno = ddBillingPeriod.SelectedItem.Text.Substring(0, posicao);
        }
        return retorno;
    }

    /// <summary>
    /// Filter process 
    /// </summary>
    /// <returns></returns>
    string ICAOFilterProcess()
    {
        string retorno = "";

        if (!ddlGrupo1.Checked)
        {
            retorno = "'METRATECH'";
            return retorno;
        }

        bool selectedOne = false;
        //loop through grid
        foreach (GridViewRow row in grvICAO.Rows)
        {
            if (((CheckBox)row.FindControl("chkSelect")).Checked)
            {
                if (!selectedOne)
                {
                    retorno = "\'" + row.Cells[1].Text + "\'";
                    selectedOne = true;
                }
                else
                {
                    retorno = retorno + ",\'" + row.Cells[1].Text + "\'";
                }

            }
        }

        if (retorno == "")
        {
            retorno = "'METRATECH'";
        }

        return retorno;

    }

    /// <summary>
    /// function used to set filter for GP2
    /// </summary>
    /// <returns></returns>
    string GP2FilterProcess()
    {
        string retorno = "";
        bool selected = false;

        if (ddlGrupo2.Checked)
        {
            retorno = "1";
        }
        else
        {
            retorno = "0";
        }

        return retorno;
    }

    /// <summary>
    /// Agni Campos
    /// Bind grid data (no matter what query is run)
    /// </summary>
    private void BindGrid()
    {
        string sRpt = ddlReports.SelectedValue;

        if (sRpt == "(SELECIONE)" || sRpt == "------- Relatórios Aeroporto ------------" || sRpt == "------- Relatórios ANAC ------------" || sRpt == "------- Relatórios ERP ------------" || sRpt == "------- Relatórios Comercial ------------" || sRpt == "------- Relatórios Detalhamento Faturas ------------")
        {
            Response.Write("<script type='text/javascript'>alert('É obrigatório selecionar um relatório para visualizar seus resultados!');</script>");
            return;

        }
        string ICAOfilter = "";
        string GP2filter = "";
        string sFiltersGP1 = "";
        string sFiltersGP2 = "";
        string sFilters = "";
        string Intervalofilter = "";

        switch (sRpt)
        {
            case "Detalhamento Embarque":
                ICAOfilter = ICAOFilterProcess();
                Intervalofilter = IntervaloFilterProcess();
                grvData.DataSource = GetDetEmbarque(ICAOfilter, Intervalofilter);
                grvData.DataBind();
                sFiltersGP1 = (ICAOfilter == "'METRATECH'" ? "" : "(Grupo I :: " + ICAOfilter + ")");
                sFilters = (sFiltersGP1 == "" ? "" + sFiltersGP2 : sFiltersGP1 + "<br/>" + sFiltersGP2);
                grvData.PageIndex = 0;
                break;
            case "Detalhamento Conexão":
                ICAOfilter = ICAOFilterProcess();
                Intervalofilter = IntervaloFilterProcess();
                grvData.DataSource = GetDetConexao(ICAOfilter, Intervalofilter);
                grvData.DataBind();
                sFiltersGP1 = (ICAOfilter == "'METRATECH'" ? "" : "(Grupo I :: " + ICAOfilter + ")");
                sFilters = (sFiltersGP1 == "" ? "" + sFiltersGP2 : sFiltersGP1 + "<br/>" + sFiltersGP2);
                grvData.PageIndex = 0;
                break;
            case "Detalhamento Pouso":
                ICAOfilter = ICAOFilterProcess();
                GP2filter = GP2FilterProcess();
                Intervalofilter = IntervaloFilterProcess();
                grvData.DataSource = GetDetPouso(ICAOfilter, GP2filter, Intervalofilter);
                grvData.DataBind();
                sFiltersGP1 = (ICAOfilter == "'METRATECH'" ? "" : "(Grupo I :: " + ICAOfilter + ")");
                sFilters = (sFiltersGP1 == "" ? "" + sFiltersGP2 : sFiltersGP1 + "<br/>" + sFiltersGP2);
                grvData.PageIndex = 0;
                break;
            case "Detalhamento Permanencia":
                ICAOfilter = ICAOFilterProcess();
                GP2filter = GP2FilterProcess();
                Intervalofilter = IntervaloFilterProcess();
                grvData.DataSource = GetDetPermanencia(ICAOfilter, GP2filter, Intervalofilter);
                grvData.DataBind();
                sFiltersGP1 = (ICAOfilter == "'METRATECH'" ? "" : "(Grupo I :: " + ICAOfilter + ")");
                sFilters = (sFiltersGP1 == "" ? "" + sFiltersGP2 : sFiltersGP1 + "<br/>" + sFiltersGP2);
                grvData.PageIndex = 0;
                break;
            case "Listagem de Contratos":
                grvData.DataSource = GetListagemContratos();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "Prévia Exportação ERP":
                grvData.DataSource = GetPreviewExportERP();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "Sumarização ERP por Nome-Item":
                grvData.DataSource = GetExportERPSumarizationNomeItem();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "Exportação ERP (com LOGIN)":
                grvData.DataSource = GetExportERP();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "Relatório Analítico":
                grvData.DataSource = GetAnac();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "Listagem Aeroportos":
                grvData.DataSource = GetAeroportos();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "Confirmação Eletrônica - Log":
                grvData.DataSource = GetCE();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "Pouso":
                ICAOfilter = ICAOFilterProcess();
                GP2filter = GP2FilterProcess();
                grvData.DataSource = GetPouso(ICAOfilter, GP2filter);
                grvData.DataBind();
                sFiltersGP1 = (ICAOfilter == "'METRATECH'" ? "" : "(Grupo I :: " + ICAOfilter + ")");
                sFiltersGP2 = (GP2filter == "0" ? "" : "(Grupo II)");
                sFilters = (sFiltersGP1 == "" ? "" + sFiltersGP2 : sFiltersGP1 + "<br/>" + sFiltersGP2);
                grvData.PageIndex = 0;
                break;
            case "Estadia":
                ICAOfilter = ICAOFilterProcess();
                GP2filter = GP2FilterProcess();
                grvData.DataSource = GetPermanenciaEstadia(ICAOfilter, GP2filter);
                grvData.DataBind();
                sFiltersGP1 = (ICAOfilter == "'METRATECH'" ? "" : "(Grupo I :: " + ICAOfilter + ")");
                sFiltersGP2 = (GP2filter == "0" ? "" : "(Grupo II)");
                sFilters = (sFiltersGP1 == "" ? "" + sFiltersGP2 : sFiltersGP1 + "<br/>" + sFiltersGP2);
                grvData.PageIndex = 0;
                break;
            case "Manobra":
                ICAOfilter = ICAOFilterProcess();
                GP2filter = GP2FilterProcess();
                grvData.DataSource = GetPermanenciaManobra(ICAOfilter, GP2filter);
                grvData.DataBind();
                sFiltersGP1 = (ICAOfilter == "'METRATECH'" ? "" : "(Grupo I :: " + ICAOfilter + ")");
                sFiltersGP2 = (GP2filter == "0" ? "" : "(Grupo II)");
                sFilters = (sFiltersGP1 == "" ? "" + sFiltersGP2 : sFiltersGP1 + "<br/>" + sFiltersGP2);
                grvData.PageIndex = 0;
                break;
            case "Conexão":
                ICAOfilter = ICAOFilterProcess();
                grvData.DataSource = GetConexao(ICAOfilter);
                grvData.DataBind();
                sFiltersGP1 = (ICAOfilter == "'METRATECH'" ? "" : "(Grupo I :: " + ICAOfilter + ")");
                sFilters = (sFiltersGP1 == "" ? "" + sFiltersGP2 : sFiltersGP1 + "<br/>" + sFiltersGP2);
                grvData.PageIndex = 0;
                break;
            case "Embarque":
                ICAOfilter = ICAOFilterProcess();
                grvData.DataSource = GetEmbarque(ICAOfilter);
                grvData.DataBind();
                sFiltersGP1 = (ICAOfilter == "'METRATECH'" ? "" : "(Grupo I :: " + ICAOfilter + ")");
                sFilters = (sFiltersGP1 == "" ? "" + sFiltersGP2 : sFiltersGP1 + "<br/>" + sFiltersGP2);
                grvData.PageIndex = 0;
                break;
            case "Tarifas Analítico":
                grvData.DataSource = GetAnac();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "RTE Resumido":
                grvData.DataSource = GetRTE();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "DAT Resumido":
                grvData.DataSource = GetDAT();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "DAT Analítico":
                grvData.DataSource = GetDATAnalitico();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "RPE Resumido":
                grvData.DataSource = GetPassageiros();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "RPE Analítico - Embarque e Conexão":
                grvData.DataSource = GetRPEAnaliticoEmbConex();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "RPE Analítico- Desembarque":
                grvData.DataSource = GetRPEAnaliticoDesembarque();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            //case "RPE Analítico":
            //    grvData.DataSource = GetRPEAnalitico();
            //    grvData.DataBind();
            //    grvData.PageIndex = 0;
            //    break;
            case "Tarifas a Cobrar por Cliente":
                grvData.DataSource = GetTarifasPorCliente();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "Divergência RPExSISO":
                grvData.DataSource = GetRPExSISO();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "Pendência SISOxRPE":
                grvData.DataSource = GetSISOxRPE();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "Listagem Grupo I":
                grvData.DataSource = GetGrp1();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "Listagem Grupo II":
                grvData.DataSource = GetGrp2();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            case "Informe de Vendas":
                grvData.DataSource = GetSalesRpt();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            // RELATORIO SUPRIMENTOS LUIZ ARAUJO
            case "Suprimentos":
                grvData.DataSource = GetSuprimentosRpt();
                grvData.DataBind();
                grvData.PageIndex = 0;
                break;
            default:
                break;
        }

        string sDatas = "Paramêtros: Data Início (" + mtdpStartDate.Text + ") Data Fim: (" + mtdpEndDate.Text + ")";

        if (!NeedDates())
        {
            sDatas = "";
        }

        if (grvData.Rows.Count == 0)
        {
            lblGrandTotal.Visible = false;
            btnPrint.Visible = false;
            col_erro.Text = "Não foram encontrados registros no critério selecionado para o relatório " + sRpt + "." + "<br/>Data/Hora Execução: " + System.DateTime.Now.ToString() + "<br/>" + sDatas + "<br/>" + sFilters;
            col_erro.Visible = true;
        }
        else
        {
            col_erro.Text = "Último relatório executado: " + sRpt + "." + "<br/>Data/Hora execução: " + System.DateTime.Now.ToString() + "<br/>" + sDatas + "<br/>" + sFilters;
            col_erro.Visible = true;
            btnPrint.Visible = true;
            CalculaTotal(sRpt);
        }

    }

    #region "CalcularTotais"
    void CalculaTotal(string reportName)
    {
        switch (reportName)
        {
            case "Relatório Analítico":
                lblGrandTotal.Visible = true;
                lblGrandTotal.Text = ""; //"Total Geral Operações: R$ " + CalculaTotalPouso().ToString("##,#.00");
                break;
            case "Pouso":
                lblGrandTotal.Visible = true;
                lblGrandTotal.Text = ""; //"Total Geral Operações: R$ " + CalculaTotalPouso().ToString("##,#.00");
                break;
            case "Estadia":
                lblGrandTotal.Visible = true;
                lblGrandTotal.Text = ""; //"Total Geral Operações: R$ " + CalculaTotalPermanencia().ToString("##,#.00");
                break;
            case "Manobra":
                lblGrandTotal.Visible = true;
                lblGrandTotal.Text = ""; //"Total Geral Operações: R$ " + CalculaTotalPermanencia().ToString("##,#.00");
                break;
            case "Conexão":
                lblGrandTotal.Visible = true;
                lblGrandTotal.Text = ""; //"Total Geral Operações: R$ " + CalculaTotalConexao().ToString("##,#.00");
                break;
            case "Embarque":
                lblGrandTotal.Visible = true;
                lblGrandTotal.Text = ""; //"Total Geral Operações: R$ " + CalculaTotalEmbarque().ToString("##,#.00");
                break;
            case "Tarifas Analítico":
                lblGrandTotal.Text = "";
                break;
            case "RTE Resumido":
                lblGrandTotal.Text = "";
                break;
            case "DAT Resumido":
                lblGrandTotal.Text = "";
                break;
            case "RPE Resumido":
                lblGrandTotal.Text = "";
                break;
            case "Tarifas a Cobrar por Cliente":
                lblGrandTotal.Text = "";
                break;
            default:
                break;
        }

    }

    decimal CalculaTotalEmbarque()
    {
        decimal a = 0, c = 0;

        for (int i = 0; i < (grvData.Rows.Count); i++)
        {
            a = Convert.ToDecimal(grvData.Rows[i].Cells[16].Text.ToString());
            c = c + a; //storing total qty into variable 
        }
        return c;
    }
    decimal CalculaTotalConexao()
    {
        decimal a = 0, c = 0;

        for (int i = 0; i < (grvData.Rows.Count); i++)
        {
            a = Convert.ToDecimal(grvData.Rows[i].Cells[13].Text.ToString());
            c = c + a; //storing total qty into variable 
        }
        return c;
    }
    decimal CalculaTotalPouso()
    {
        decimal a = 0, c = 0;

        for (int i = 0; i < (grvData.Rows.Count); i++)
        {
            a = Convert.ToDecimal(grvData.Rows[i].Cells[21].Text.ToString());
            c = c + a; //storing total qty into variable 
        }
        return c;
    }
    decimal CalculaTotalPermanencia()
    {
        decimal a = 0, c = 0;

        for (int i = 0; i < (grvData.Rows.Count); i++)
        {
            a = Convert.ToDecimal(grvData.Rows[i].Cells[19].Text.ToString());
            c = c + a; //storing total qty into variable 
        }
        return c;
    }
    decimal CalculaTotalANAC()
    {
        decimal a = 0, c = 0;

        for (int i = 0; i < (grvData.Rows.Count); i++)
        {
            a = Convert.ToDecimal(grvData.Rows[i].Cells[13].Text.ToString());
            c = c + a; //storing total qty into variable 
        }
        return c;
    }
    #endregion

    public List<Report_Det_Pouso> GetDetPouso(string ICAOfilter, string GP2filter, string Intervalofilter)
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__DET_POUSO_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%ICAO%%", ICAOfilter, true);//using dontValidateString = true to enable list with "'" character.
            stmt.AddParam("%%GP2%%", GP2filter, true);//using dontValidateString = true to enable list with "'" character.
            stmt.AddParam("%%INTERVALO%%", Intervalofilter);

            List<Report_Det_Pouso> xList = new List<Report_Det_Pouso>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Det_Pouso account = new Report_Det_Pouso
                    {

                        CLIENTE = reader.GetString("CLIENTE"),
                        ICAO = reader.GetString("ICAO"),
                        DATAHORA_VOO = reader.GetDateTime("DATA").ToString(),
                        NUM_VOO = reader.GetString("NUMVOO"),
                        TIPOAERONAVE = reader.GetString("TIPOAERONAVE"),
                        NATUREZAVOO = reader.GetString("NATUREZAVOO"),
                        ORIGEM = reader.GetString("ORIGEM"),
                        MATRICULA = reader.GetString("MATRICULA"),
                        PMD = reader.GetInt32("PMD"),
                        TARIFA_POUSO = reader.GetDecimal("TARIFA_POUSO").ToString("##,0.00"),
                        TOTAL_POUSO = reader.GetDecimal("TOTAL_POUSO").ToString("##,0.00"),
                        PERC_ATAERO = reader.GetString("PERC_ATAERO"),
                        ATAERO = reader.GetDecimal("ATAERO").ToString("##,0.00"),
                        VALOR_TOTAL = reader.GetString("VALOR_TOTAL")
                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    public List<Report_Det_Permanencia> GetDetPermanencia(string ICAOfilter, string GP2filter, string Intervalofilter)
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__DET_PERMANENCIA_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%ICAO%%", ICAOfilter, true);//using dontValidateString = true to enable list with "'" character.
            stmt.AddParam("%%GP2%%", GP2filter, true);//using dontValidateString = true to enable list with "'" character.
            stmt.AddParam("%%INTERVALO%%", Intervalofilter);

            List<Report_Det_Permanencia> xList = new List<Report_Det_Permanencia>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Det_Permanencia account = new Report_Det_Permanencia
                    {

                        CLIENTE = reader.GetString("CLIENTE"),
                        ICAO = reader.GetString("ICAO"),
                        DATAHORA_OPERACAO = reader.GetDateTime("DATA").ToString(),
                        NUM_VOO = reader.GetString("NUMVOO"),
                        TIPOAERONAVE = reader.GetString("TIPOAERONAVE"),
                        NATUREZAVOO = reader.GetString("NATUREZAVOO"),
                        ORIGEM = reader.GetString("ORIGEM"),
                        MATRICULA = reader.GetString("MATRICULA"),
                        PMD = reader.GetInt32("PMD"),
                        ESTADIA = reader.GetInt32("ESTADIA"),
                        VALOR_ESTADIA = reader.GetDecimal("VALOR_ESTADIA").ToString("##,0.00"),
                        MANOBRA = reader.GetInt32("MANOBRA"),
                        VALOR_MANOBRA = reader.GetDecimal("VALOR_MANOBRA").ToString("##,0.00"),
                        TARIFA_ESTADIA = reader.GetDecimal("TARIFA_ESTADIA").ToString("##,0.00"),
                        TARIFA_MANOBRA = reader.GetDecimal("TARIFA_MANOBRA").ToString("##,0.00"),
                        TOTAL_PERMANENCIA = reader.GetDecimal("TOTAL_PERMANENCIA").ToString("##,0.00"),
                        PERC_ATAERO = reader.GetString("PERC_ATAERO"),
                        TOTAL_ATAERO = reader.GetDecimal("TOTAL_ATAERO").ToString("##,0.00"),
                        VALOR_TOTAL = reader.GetDecimal("VALOR_TOTAL").ToString("##,0.00")


                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    public List<Report_Det_Embarque> GetDetEmbarque(string ICAOfilter, string Intervalofilter)
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__DET_EMBARQUE_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%ICAO%%", ICAOfilter, true);//using dontValidateString = true to enable list with "'" character.
            stmt.AddParam("%%INTERVALO%%", Intervalofilter);

            List<Report_Det_Embarque> xList = new List<Report_Det_Embarque>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Det_Embarque account = new Report_Det_Embarque
                    {

                        ICAO = reader.GetString("ICAO"),
                        DATAHORA_VOO = reader.GetString("DATAHORA_VOO"),
                        NUM_VOO = reader.GetString("NUM_VOO"),
                        QTD_DOM = reader.GetInt32("QTD_DOM"),
                        VALOR_TARIFA_DOM = reader.GetDecimal("TARIFA_UNIT_EMBARQ_DOM").ToString("##,0.00"),
                        VALOR_DOM = reader.GetString("VALOR_DOM"),
                        QTD_INTL = reader.GetInt32("QTD_INTL"),
                        VALOR_TARIFA_INTL = reader.GetDecimal("TARIFA_UNIT_EMBARQ_INTL").ToString("##,0.00"),
                        VALOR_INTL = reader.GetString("VALOR_INTL"),
                        VALOR_ATAERO = reader.GetString("VALOR_ATAERO"),
                        VALOR_FNAC = reader.GetString("VALOR_FNAC"),
                        VALOR_TOTAL = reader.GetString("VALOR_TOTAL")

                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    public List<Report_Det_Conexao> GetDetConexao(string ICAOfilter, string Intervalofilter)
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__DET_CONEXAO_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%ICAO%%", ICAOfilter, true);//using dontValidateString = true to enable list with "'" character.
            stmt.AddParam("%%INTERVALO%%", Intervalofilter);

            List<Report_Det_Conexao> xList = new List<Report_Det_Conexao>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Det_Conexao account = new Report_Det_Conexao
                    {

                        ICAO = reader.GetString("ICAO"),
                        DATAHORA_VOO = reader.GetString("DATAHORA_VOO").ToString(),
                        NUM_VOO = reader.GetString("NUM_VOO"),
                        QTD_DOM = reader.GetInt32("QTD_DOM"),
                        QTD_INTL = reader.GetInt32("QTD_INTL"),
                        TARIFA_UNIT_CONEXAO_DOM = reader.GetDecimal("TARIFA_UNIT_CONEXAO_DOM").ToString("##,0.00"),
                        TARIFA_UNIT_CONEXAO_INTL = reader.GetDecimal("TARIFA_UNIT_CONEXAO_INT").ToString("##,0.00"),
                        VALOR_DOM = reader.GetDecimal("VALOR_DOM").ToString("##,0.00"),
                        VALOR_INTL = reader.GetDecimal("VALOR_INTL").ToString("##,0.00"),
                        VALOR_TOTAL = reader.GetString("TOTAL")

                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    public List<Report_Listagem_Contratos> GetListagemContratos()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            //DateTime mdate = DateTime.Now;

            string mquery = "__CONTRACT_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_Listagem_Contratos> xList = new List<Report_Listagem_Contratos>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Listagem_Contratos account = new Report_Listagem_Contratos
                    {
                        CLIENTE = reader.GetString("EMPRESA"),
                        CONTRATO = reader.GetString("CONTRATO"),
                        LUC = reader.GetString("LUC"),
                        DATA_INICIO_CONTRATO = reader.GetDateTime("DT_INICIO_CONTRATO").ToString("dd-MM-yyyy"),
                        DATA_FIM_CONTRATO = reader.GetDateTime("DT_FIM_CONTRATO").ToString("dd-MM-yyyy"),
                        ASSINATURA = reader.GetString("ASSINATURA"),
                        VALOR_COBRANCA = reader.GetDecimal("VALOR_COBRANCA").ToString("##,0.00"),
                        DATA_INICIO_VALOR = reader.GetDateTime("DT_INICIO_COBRANCA").ToString("dd-MM-yyyy"),
                        DATA_FIM_VALOR = reader.GetDateTime("DT_FIM_COBRANCA").ToString("dd-MM-yyyy")

                    };
                    xList.Add(account);
                }
            }
            return xList;
        }

    }

    public List<Report_RPE_Without_SISO> GetRPExSISO()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            //DateTime mdate = DateTime.Now;

            string mquery = "__RPE_WITHOUT_SISO_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_RPE_Without_SISO> xList = new List<Report_RPE_Without_SISO>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_RPE_Without_SISO account = new Report_RPE_Without_SISO
                    {
                        EMPRESA_AEREA = reader.GetString("ICAO"),
                        NUMERO_VOO = reader.GetString("NUM_VOO"),
                        DATA_VOO = reader.GetDateTime("DATA_VOO").ToString("dd-MM-yyyy")

                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    public List<Report_SISO_Without_RPE> GetSISOxRPE()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            //DateTime mdate = DateTime.Now;

            string mquery = "__SISO_WITHOUT_RPE_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_SISO_Without_RPE> xList = new List<Report_SISO_Without_RPE>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_SISO_Without_RPE account = new Report_SISO_Without_RPE
                    {
                        EMPRESA_AEREA = reader.GetString("ICAO"),
                        NUMERO_VOO = reader.GetString("NUM_VOO"),
                        DATA_VOO = reader.GetDateTime("DATA_VOO").ToString("dd-MM-yyyy")
                    };
                    xList.Add(account);
                }
            }
            return xList;
        }

    }

    public List<Report_EXPORT_ERP_SUMARIZATION_NOME_ITEM> GetExportERPSumarizationNomeItem()
    {

        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {
            string mquery = "__GET_SUMMARIZATION_EXPORT_ERP_NOME_ITEM__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_EXPORT_ERP_SUMARIZATION_NOME_ITEM> xList = new List<Report_EXPORT_ERP_SUMARIZATION_NOME_ITEM>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_EXPORT_ERP_SUMARIZATION_NOME_ITEM account = new Report_EXPORT_ERP_SUMARIZATION_NOME_ITEM
                    {
                        DATA_CRIACAO = (reader.GetDateTime("DATA_CRIACAO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_CRIACAO").ToString("dd-MM-yyyy")),
                        NOME_ITEM = reader.GetString("NOME_ITEM"),
                        ID_ATAERO = reader.GetString("ID_ATAERO"),
                        PK = reader.GetString("PK"),
                        NUMERO_CONTRATO = reader.GetString("NUMERO_CONTRATO"),
                        LUC = reader.GetString("LUC"),
                        QUANTIDADE = reader.GetInt32("QUANTIDADE"),
                        VALOR = reader.GetDecimal("VALOR").ToString("##,0.00")
                    };
                    xList.Add(account);
                }
            }
            return xList;
        }

    }

    public List<Report_EXPORT_ERP> GetExportERP()
    {

        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            //DateTime mdate = DateTime.Now;

            string mquery = "__EXPORT_ERP_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_EXPORT_ERP> xList = new List<Report_EXPORT_ERP>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_EXPORT_ERP account = new Report_EXPORT_ERP
                    {
                        LOGIN = reader.GetString("LOGIN"),
                        NOME_CLIENTE = reader.GetString("NOME_CLIENTE"),
                        NUMERO_CLIENTE = reader.GetString("NUMERO_CLIENTE"),
                        EMAIL_CLIENTE = reader.GetString("EMAIL_CLIENTE"),
                        TIPO_CONTA = reader.GetString("TIPO_CONTA"),
                        ENQUADRADO_SIMPLES = reader.GetString("ENQUADRADO_SIMPLES"),
                        PARTICIPANTE_FOME_ZERO = reader.GetString("PARTICIPANTE_FOME_ZERO"),
                        NATUREZA_JURIDICA = reader.GetString("NATUREZA_JURIDICA"),
                        PREFERENCIA_MOEDA = reader.GetString("PREFERENCIA_MOEDA"),
                        METODO_PAGAMENTO = reader.GetString("METODO_PAGAMENTO"),
                        PAIS = reader.GetString("PAIS"),
                        RUA = reader.GetString("RUA"),
                        BAIRRO = reader.GetString("BAIRRO"),
                        NUMERO = reader.GetString("NUMERO"),
                        COMPLEMENTO = reader.GetString("COMPLEMENTO"),
                        ESTADO = reader.GetString("ESTADO"),
                        CIDADE = reader.GetString("CIDADE"),
                        CEP = reader.GetString("CEP"),
                        CATEGORIA_ATRIBUTO = reader.GetString("CATEGORIA_ATRIBUTO"),
                        TIPO_INSCRICAO = reader.GetString("TIPO_INSCRICAO"),
                        CPF = reader.GetString("CPF"),
                        DIGITO_INSCRICAO_CPF = reader.GetString("DIGITO_INSCRICAO_CPF"),
                        CNPJ = reader.GetString("CNPJ"),
                        AGENCIA_INSCRICAO = reader.GetString("AGENCIA_INSCRICAO"),
                        DIGITO_INSCRICAO_CNPJ = reader.GetString("DIGITO_INSCRICAO_CNPJ"),
                        INSCRICAO_ESTADUAL = reader.GetString("INSCRICAO_ESTADUAL"),
                        INSCRICAO_MUNICIPAL = reader.GetString("INSCRICAO_MUNICIPAL"),
                        CLASSE_CONTRIBUINTE = reader.GetString("CLASSE_CONTRIBUINTE"),
                        ORIGEM = reader.GetString("ORIGEM"),
                        NUMERO_CLIENTE_TRANS = reader.GetString("NUMERO_CLIENTE_TRANS"),
                        CODIGO_MOEDA = reader.GetString("CODIGO_MOEDA"),
                        CODIGO_NOTA = reader.GetString("CODIGO_NOTA"),
                        TERMO_PAGAMENTO = reader.GetString("TERMO_PAGAMENTO"),
                        NUMERO_LINHA = reader.GetInt32("NUMERO_LINHA"),
                        NOME_ITEM = reader.GetString("NOME_ITEM"),
                        QUANTIDADE = reader.GetInt32("QUANTIDADE"),
                        PRECO_UNITARIO = reader.GetDecimal("PRECO_UNITARIO").ToString("##,0.00"),
                        VALOR_LINHA = reader.GetDecimal("VALOR_LINHA").ToString("##,0.00"),
                        STATUS_PAGAMENTO = reader.GetString("STATUS_PAGAMENTO"),
                        CODIGO_NOTA_REC = reader.GetString("CODIGO_NOTA_REC"),
                        METODO_PAGAMENTO_BAIXA = reader.GetString("METODO_PAGAMENTO_BAIXA"),
                        VALOR_RECEBIDO = reader.GetDecimal("VALOR_RECEBIDO").ToString("##,0.00"),
                        DATA_PAGAMENTO = (reader.GetDateTime("DATA_PAGAMENTO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_PAGAMENTO").ToString("dd-MM-yyyy")),
                        STATUS_INTEGRACAO = reader.GetString("STATUS_INTEGRACAO"),
                        DATA_CRIACAO = (reader.GetDateTime("DATA_CRIACAO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_CRIACAO").ToString("dd-MM-yyyy")),
                        CRIADO_POR = reader.GetString("CRIADO_POR"),
                        DATA_ATUALIZACAO = (reader.GetDateTime("DATA_ATUALIZACAO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_ATUALIZACAO").ToString("dd-MM-yyyy")),
                        ATUALIZADO_POR = reader.GetString("ATUALIZADO_POR"),
                        MENSAGEM_ERRO = reader.GetString("MENSAGEM_ERRO"),
                        //ID_SESS = reader.GetInt32("ID_SESS"),
                        DATA_EXTRACAO = (reader.GetDateTime("DATA_EXTRACAO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_EXTRACAO").ToString("dd-MM-yyyy")),
                        //ID_USAGE_INTERVAL = reader.GetInt32("ID_USAGE_INTERVAL"),
                        //ID_ACC = reader.GetInt32("ID_ACC"),
                        JUROS = reader.GetDecimal("JUROS").ToString("##,0.00"),
                        MULTA = reader.GetDecimal("MULTA").ToString("##,0.00"),
                        //SERV_DEF = reader.GetString("SERV_DEF"),
                        DATA_PROC_PAG_METRA = (reader.GetDateTime("DATA_PROC_PAG_METRA").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_PROC_PAG_METRA").ToString("dd-MM-yyyy")),
                        //RUN_ID = reader.GetInt32("RUN_ID"),
                        //DATA_CRIACAO_USO = (reader.GetDateTime("DATA_CRIACAO_USO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_CRIACAO_USO").ToString("dd-MM-yyyy"))
                        DATA_EMISSAO = (reader.GetDateTime("DATA_EMISSAO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_EMISSAO").ToString("dd-MM-yyyy")),
                        ID_ATAERO = reader.GetString("ID_ATAERO"),
                        PK = reader.GetString("PK"),
                        NUMERO_CONTRATO = reader.GetString("NUMERO_CONTRATO"),
                        LUC = reader.GetString("LUC")
                    };
                    xList.Add(account);
                }
            }
            return xList;
        }

    }

    public List<Report_EXPORT_ERP> GetPreviewExportERP()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {
            string mquery = "__PREVIEW_ERP_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_EXPORT_ERP> xList = new List<Report_EXPORT_ERP>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_EXPORT_ERP account = new Report_EXPORT_ERP
                    {
                        LOGIN = reader.GetString("LOGIN"),
                        NOME_CLIENTE = reader.GetString("NOME_CLIENTE"),
                        NUMERO_CLIENTE = reader.GetString("NUMERO_CLIENTE"),
                        EMAIL_CLIENTE = reader.GetString("EMAIL_CLIENTE"),
                        TIPO_CONTA = reader.GetString("TIPO_CONTA"),
                        ENQUADRADO_SIMPLES = reader.GetString("ENQUADRADO_SIMPLES"),
                        PARTICIPANTE_FOME_ZERO = reader.GetString("PARTICIPANTE_FOME_ZERO"),
                        NATUREZA_JURIDICA = reader.GetString("NATUREZA_JURIDICA"),
                        PREFERENCIA_MOEDA = reader.GetString("PREFERENCIA_MOEDA"),
                        METODO_PAGAMENTO = reader.GetString("METODO_PAGAMENTO"),
                        PAIS = reader.GetString("PAIS"),
                        RUA = reader.GetString("RUA"),
                        BAIRRO = reader.GetString("BAIRRO"),
                        NUMERO = reader.GetString("NUMERO"),
                        COMPLEMENTO = reader.GetString("COMPLEMENTO"),
                        ESTADO = reader.GetString("ESTADO"),
                        CIDADE = reader.GetString("CIDADE"),
                        CEP = reader.GetString("CEP"),
                        CATEGORIA_ATRIBUTO = reader.GetString("CATEGORIA_ATRIBUTO"),
                        TIPO_INSCRICAO = reader.GetString("TIPO_INSCRICAO"),
                        CPF = reader.GetString("CPF"),
                        DIGITO_INSCRICAO_CPF = reader.GetString("DIGITO_INSCRICAO_CPF"),
                        CNPJ = reader.GetString("CNPJ"),
                        AGENCIA_INSCRICAO = reader.GetString("AGENCIA_INSCRICAO"),
                        DIGITO_INSCRICAO_CNPJ = reader.GetString("DIGITO_INSCRICAO_CNPJ"),
                        INSCRICAO_ESTADUAL = reader.GetString("INSCRICAO_ESTADUAL"),
                        INSCRICAO_MUNICIPAL = reader.GetString("INSCRICAO_MUNICIPAL"),
                        CLASSE_CONTRIBUINTE = reader.GetString("CLASSE_CONTRIBUINTE"),
                        ORIGEM = reader.GetString("ORIGEM"),
                        NUMERO_CLIENTE_TRANS = reader.GetString("NUMERO_CLIENTE_TRANS"),
                        CODIGO_MOEDA = reader.GetString("CODIGO_MOEDA"),
                        CODIGO_NOTA = reader.GetString("CODIGO_NOTA"),
                        TERMO_PAGAMENTO = reader.GetString("TERMO_PAGAMENTO"),
                        NUMERO_LINHA = reader.GetInt32("NUMERO_LINHA"),
                        NOME_ITEM = reader.GetString("NOME_ITEM"),
                        QUANTIDADE = reader.GetInt32("QUANTIDADE"),
                        PRECO_UNITARIO = reader.GetDecimal("PRECO_UNITARIO").ToString("##,0.00"),
                        VALOR_LINHA = reader.GetDecimal("VALOR_LINHA").ToString("##,0.00"),
                        STATUS_PAGAMENTO = reader.GetString("STATUS_PAGAMENTO"),
                        CODIGO_NOTA_REC = reader.GetString("CODIGO_NOTA_REC"),
                        METODO_PAGAMENTO_BAIXA = reader.GetString("METODO_PAGAMENTO_BAIXA"),
                        VALOR_RECEBIDO = reader.GetDecimal("VALOR_RECEBIDO").ToString("##,0.00"),
                        DATA_PAGAMENTO = (reader.GetDateTime("DATA_PAGAMENTO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_PAGAMENTO").ToString("dd-MM-yyyy")),
                        STATUS_INTEGRACAO = reader.GetString("STATUS_INTEGRACAO"),
                        DATA_CRIACAO = (reader.GetDateTime("DATA_CRIACAO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_CRIACAO").ToString("dd-MM-yyyy")),
                        CRIADO_POR = reader.GetString("CRIADO_POR"),
                        DATA_ATUALIZACAO = (reader.GetDateTime("DATA_ATUALIZACAO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_ATUALIZACAO").ToString("dd-MM-yyyy")),
                        ATUALIZADO_POR = reader.GetString("ATUALIZADO_POR"),
                        MENSAGEM_ERRO = reader.GetString("MENSAGEM_ERRO"),
                        //ID_SESS = reader.GetInt32("ID_SESS"),
                        DATA_EXTRACAO = (reader.GetDateTime("DATA_EXTRACAO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_EXTRACAO").ToString("dd-MM-yyyy")),
                        //ID_USAGE_INTERVAL = reader.GetInt32("ID_USAGE_INTERVAL"),
                        //ID_ACC = reader.GetInt32("ID_ACC"),
                        JUROS = reader.GetDecimal("JUROS").ToString("##,0.00"),
                        MULTA = reader.GetDecimal("MULTA").ToString("##,0.00"),
                        //SERV_DEF = reader.GetString("SERV_DEF"),
                        DATA_PROC_PAG_METRA = (reader.GetDateTime("DATA_PROC_PAG_METRA").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_PROC_PAG_METRA").ToString("dd-MM-yyyy")),
                        //RUN_ID = reader.GetInt32("RUN_ID"),
                        //DATA_CRIACAO_USO = (reader.GetDateTime("DATA_CRIACAO_USO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_CRIACAO_USO").ToString("dd-MM-yyyy"))
                        DATA_EMISSAO = (reader.GetDateTime("DATA_EMISSAO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATA_EMISSAO").ToString("dd-MM-yyyy"))
                        ,
                        ID_ATAERO = reader.GetString("ID_ATAERO"),
                        PK = reader.GetString("PK"),
                        NUMERO_CONTRATO = reader.GetString("NUMERO_CONTRATO"),
                        LUC = reader.GetString("LUC")
                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    //public List<Report_RPE_ANALITICO> GetRPEAnalitico()
    //{
    //    using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
    //    {

    //        //DateTime mdate = DateTime.Now;

    //        string mquery = "__RPE_ANALITICO_RPT__";

    //        IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

    //        stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
    //        stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

    //        List<Report_RPE_ANALITICO> xList = new List<Report_RPE_ANALITICO>();

    //        using (IMTDataReader reader = stmt.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                Report_RPE_ANALITICO account = new Report_RPE_ANALITICO
    //                {
    //                    Terminal = (reader.GetString("Terminal") == "0" ? "" : reader.GetString("Terminal")),
    //                    ICAO = reader.GetString("ICAO"),
    //                    NUMVOO = (reader.GetString("NUMVOO")=="0"?"":reader.GetString("NUMVOO")),
    //                    DATA_VOO = (reader.GetDateTime("DATAVOO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATAVOO").ToString("dd-MM-yyyy")),
    //                    HORA_VOO = reader.GetString("HORAVOO"),
    //                    MATRICULA = reader.GetString("MATRICULA"),
    //                    QTD_EMB_DOM = reader.GetInt32("QTD_EMB_DOM"),
    //                    QTD_EMB_INTL = reader.GetInt32("QTD_EMB_INTL"),
    //                    VALOR_TARIFA_DOM = reader.GetDecimal("VALOR_TARIFA_DOM").ToString("##,0.00"),
    //                    VALOR_TARIFA_INTL = reader.GetDecimal("VALOR_TARIFA_INTL").ToString("##,0.00"),
    //                    VALOR_EMB_DOM = reader.GetDecimal("VALOR_DOM").ToString("##,0.00"),
    //                    VALOR_EMB_INTL = reader.GetDecimal("VALOR_INTL").ToString("##,0.00"),
    //                    ATAERO_EMB_DOM = reader.GetDecimal("ATAERO_DOM").ToString("##,0.00"),
    //                    ATAERO_EMB_INTL = reader.GetDecimal("ATAERO_INTL").ToString("##,0.00"),
    //                    ADICIONAL_TARIFA = reader.GetDecimal("ADICIONAL_TARIFA").ToString("##,0.00"),
    //                    QTD_CONEX_DOM = reader.GetInt32("C_NUMBERDOMESTICCONNECTION"),
    //                    VALOR_CONEX_DOM = reader.GetDecimal("C_DOMESTICCONNECTIONAMOUNT").ToString("##,0.00"),
    //                    QTD_CONEX_INTL = reader.GetInt32("C_NUMBERINTCONNECTION"),
    //                    VALOR_CONEX_INTL = reader.GetDecimal("C_INTCONNECTIONAMOUNT").ToString("##,0.00"),
    //                    TIPO_VOO = (reader.GetString("C_FLIGHTTYPE") == null ? "" : reader.GetString("C_FLIGHTTYPE")),
    //                    MATRICULA_DESEMB = reader.GetString("C_AIRCRAFTREGISTRATION"),
    //                    PARTICIPACAO = (reader.GetString("C_PARTICIPATION") == null ? "" : reader.GetString("C_PARTICIPATION")),
    //                    NATUREZAVOO = (reader.GetString("C_FLIGHTNATURE") == null ? "" : reader.GetString("C_FLIGHTNATURE")),
    //                    TOTAL_PAX_VOO = reader.GetInt32("C_FLIGHT_TOTAL_PAX"),
    //                    C_TOTAL_DOM_TICKET_PAX = reader.GetInt32("C_TOTAL_DOM_TICKET_PAX"),
    //                    C_TOTAL_DOM_TICKET_PAX_PREV = reader.GetInt32("C_TOTAL_DOM_TICKET_PAX_PREV"),
    //                    C_TOTAL_INTL_TICKET_PAX = reader.GetInt32("C_TOTAL_INT_TICKET_PAX"),
    //                    C_TOTAL_INTL_TICKET_PAX_PREV = reader.GetInt32("C_TOTAL_INT_TICKET_PAX_PREV"),
    //                    C_DOM_CONN_CHECKIN_TOTAL = reader.GetInt32("C_DOM_CONN_CHECKIN_TOTAL"),
    //                    C_INTL_CONN_CHECKIN_TOTAL = reader.GetInt32("C_INT_CONN_CHECKIN_TOTAL"),
    //                    C_TOTAL_DOM_TAR_ADVANCE = reader.GetInt32("C_TOTAL_DOM_TAR_ADVANCE"),
    //                    C_TOTAL_INTL_TAR_ADVANCE = reader.GetInt32("C_TOTAL_INT_TAR_ADVANCE"),
    //                    ISENTOS = reader.GetInt32("C_LAP_PAX"),
    //                    TRANSITO_A_BORDO = reader.GetInt32("C_PAX_TR_ONBORD"),
    //                    IAC = reader.GetInt32("C_PAX_IAC"),
    //                    BAGAGEM_EMB_DOM = reader.GetInt32("C_BOARD_DOM_BAGGAGE"),
    //                    BAGAGEM_EMB_INTL = reader.GetInt32("C_BOARD_INT_BAGGAGE"),
    //                    CARGA_EMB_DOM = reader.GetInt32("C_BOARD_DOM_CARGO"),
    //                    CARGA_EMB_INTL = reader.GetInt32("C_BOARD_INT_CARGO"),
    //                    CORREIO_EMB_DOM = reader.GetInt32("C_BOARD_DOM_POSTAL"),
    //                    CORREIO_EMB_INTL = reader.GetInt32("C_BOARD_INT_POSTAL"),
    //                    NUMVOO_DESEMB = (reader.GetInt32("C_ARRIVAL_FLIGHT_NUMBER") == 0 ? 0 : reader.GetInt32("C_ARRIVAL_FLIGHT_NUMBER")),
    //                    DATAVOO_DESEMB = (reader.GetDateTime("C_ARRIVAL_FLIGHT_DATE").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("C_ARRIVAL_FLIGHT_DATE").ToString("dd-MM-yyyy")),
    //                    HORAVOO_DESEMB = reader.GetString("C_ARRIVAL_FLIGHT_HOUR"),
    //                    TIPO_VOO_DESEMB = (reader.GetString("C_ARRIVAL_FLIGHT_TYPE") == null ? "" : reader.GetString("C_ARRIVAL_FLIGHT_TYPE")),
    //                    PARTICIPACAO_DESEMB = (reader.GetString("C_ARRIVAL_PARTICIPATION") == null ? "" : reader.GetString("C_ARRIVAL_PARTICIPATION")),
    //                    NATUREZA_VOO_DESEMB = (reader.GetString("C_ARRIVAL_FLIGHT_NATURE") == null ? "" : reader.GetString("C_ARRIVAL_FLIGHT_NATURE")),
    //                    PAX_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_PAX"),
    //                    PAX_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_PAX"),
    //                    PAX_DOM_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_CONN_PAX"),
    //                    PAX_INTL_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_INT_CONN_PAX"),
    //                    BAGAGEM_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_BAGGAGE"),
    //                    BAGAGEM_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_BAGGAGE"),
    //                    BAGAGEM_DOM_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_CONN_BAGGAGE"),
    //                    BAGAGEM_INTL_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_INT_CONN_BAGGAGE"),
    //                    CARGA_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_CARGO"),
    //                    CARGA_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_CARGO"),
    //                    CARGA_DOM_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_CONN_CARGO"),
    //                    CARGA_INTL_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_INT_CONN_CARGO"),
    //                    CORREIO_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_POSTAL"),
    //                    CORREIO_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_POSTAL"),
    //                    CORREIO_DOM_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_CONN_POSTAL"),
    //                    CORREIO_INTL_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_INT_CONN_POSTAL"),
    //                    BAGAGEM_TRANSITO_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_TRANSIT_BAGGAGE"),
    //                    BAGAGEM_TRANSITO_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_TRANSIT_BAGGAGE"),
    //                    CARGA_TRANSITO_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_TRANSIT_CARGO"),
    //                    CARGA_TRANSITO_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_TRANSIT_CARGO"),
    //                    CORREIO_TRANSITO_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_TRANSIT_POSTAL"),
    //                    CORREIO_TRANSITO_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_TRANSIT_POSTAL"),
    //                    VALOR_TARIFA_CONEX_DOM = reader.GetDecimal("C_DOMESTICCONNECTIONRATE").ToString("##,0.00"),
    //                    VALOR_TARIFA_CONEX_INTL = reader.GetDecimal("C_INTCONNECTIONRATE").ToString("##,0.00"),
    //                    USUARIO = reader.GetString("USUARIO")

    //                };
    //                xList.Add(account);
    //            }
    //        }
    //        return xList;
    //    }
    //}

    //Embarque e Conexao
    public List<Report_RPE_ANALITICO_EMB_CONEX> GetRPEAnaliticoEmbConex()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            //DateTime mdate = DateTime.Now;

            string mquery = "__RPE_ANALITICO_EMB_CONEX_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_RPE_ANALITICO_EMB_CONEX> xList = new List<Report_RPE_ANALITICO_EMB_CONEX>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_RPE_ANALITICO_EMB_CONEX account = new Report_RPE_ANALITICO_EMB_CONEX
                    {
                        Terminal = (reader.GetString("Terminal") == "0" ? "" : reader.GetString("Terminal")),
                        ICAO = reader.GetString("ICAO"),
                        NUMVOO = (reader.GetString("NUMVOO") == "0" ? "" : reader.GetString("NUMVOO")),
                        DATA_VOO = (reader.GetDateTime("DATAVOO").ToString() == "01/01/1900 00:00:00" ? "" : reader.GetDateTime("DATAVOO").ToString("dd-MM-yyyy")),
                        HORA_VOO = reader.GetString("HORAVOO"),
                        MATRICULA = reader.GetString("MATRICULA"),
                        QTD_EMB_DOM = reader.GetInt32("QTD_EMB_DOM"),
                        QTD_EMB_INTL = reader.GetInt32("QTD_EMB_INTL"),
                        VALOR_TARIFA_DOM = reader.GetDecimal("VALOR_TARIFA_DOM").ToString("##,0.00"),
                        VALOR_TARIFA_INTL = reader.GetDecimal("VALOR_TARIFA_INTL").ToString("##,0.00"),
                        VALOR_EMB_DOM = reader.GetDecimal("VALOR_DOM").ToString("##,0.00"),
                        VALOR_EMB_INTL = reader.GetDecimal("VALOR_INTL").ToString("##,0.00"),
                        ATAERO_EMB_DOM = reader.GetDecimal("ATAERO_DOM").ToString("##,0.00"),
                        ATAERO_EMB_INTL = reader.GetDecimal("ATAERO_INTL").ToString("##,0.00"),
                        ADICIONAL_TARIFA = reader.GetDecimal("ADICIONAL_TARIFA").ToString("##,0.00"),
                        QTD_CONEX_DOM = reader.GetInt32("C_NUMBERDOMESTICCONNECTION"),
                        VALOR_CONEX_DOM = reader.GetDecimal("C_DOMESTICCONNECTIONAMOUNT").ToString("##,0.00"),
                        QTD_CONEX_INTL = reader.GetInt32("C_NUMBERINTCONNECTION"),
                        VALOR_CONEX_INTL = reader.GetDecimal("C_INTCONNECTIONAMOUNT").ToString("##,0.00"),
                        TIPO_VOO = (reader.GetString("C_FLIGHTTYPE") == null ? "" : reader.GetString("C_FLIGHTTYPE")),
                        PARTICIPACAO = (reader.GetString("C_PARTICIPATION") == null ? "" : reader.GetString("C_PARTICIPATION")),
                        NATUREZAVOO = (reader.GetString("C_FLIGHTNATURE") == null ? "" : reader.GetString("C_FLIGHTNATURE")),
                        TOTAL_PAX_VOO = reader.GetInt32("C_FLIGHT_TOTAL_PAX"),
                        C_TOTAL_DOM_TICKET_PAX = reader.GetInt32("C_TOTAL_DOM_TICKET_PAX"),
                        C_TOTAL_DOM_TICKET_PAX_PREV = reader.GetInt32("C_TOTAL_DOM_TICKET_PAX_PREV"),
                        C_TOTAL_INTL_TICKET_PAX = reader.GetInt32("C_TOTAL_INT_TICKET_PAX"),
                        C_TOTAL_INTL_TICKET_PAX_PREV = reader.GetInt32("C_TOTAL_INT_TICKET_PAX_PREV"),
                        C_DOM_CONN_CHECKIN_TOTAL = reader.GetInt32("C_DOM_CONN_CHECKIN_TOTAL"),
                        C_INTL_CONN_CHECKIN_TOTAL = reader.GetInt32("C_INT_CONN_CHECKIN_TOTAL"),
                        C_TOTAL_DOM_TAR_ADVANCE = reader.GetInt32("C_TOTAL_DOM_TAR_ADVANCE"),
                        C_TOTAL_INTL_TAR_ADVANCE = reader.GetInt32("C_TOTAL_INT_TAR_ADVANCE"),
                        ISENTOS = reader.GetInt32("C_LAP_PAX"),
                        TRANSITO_A_BORDO = reader.GetInt32("C_PAX_TR_ONBORD"),
                        IAC = reader.GetInt32("C_PAX_IAC"),
                        BAGAGEM_EMB_DOM = reader.GetInt32("C_BOARD_DOM_BAGGAGE"),
                        BAGAGEM_EMB_INTL = reader.GetInt32("C_BOARD_INT_BAGGAGE"),
                        CARGA_EMB_DOM = reader.GetInt32("C_BOARD_DOM_CARGO"),
                        CARGA_EMB_INTL = reader.GetInt32("C_BOARD_INT_CARGO"),
                        CORREIO_EMB_DOM = reader.GetInt32("C_BOARD_DOM_POSTAL"),
                        CORREIO_EMB_INTL = reader.GetInt32("C_BOARD_INT_POSTAL"),
                        DATA_DIGITACAO = reader.GetDateTime("DATA_DIGITACAO").ToString("dd-MM-yyyy"),
                        USUARIO = reader.GetString("C_GUIUSER")
                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    //Desembarque
    public List<Report_RPE_ANALITICO_DESEMB> GetRPEAnaliticoDesembarque()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            //DateTime mdate = DateTime.Now;

            string mquery = "__RPE_ANALITICO_DES_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_RPE_ANALITICO_DESEMB> xList = new List<Report_RPE_ANALITICO_DESEMB>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_RPE_ANALITICO_DESEMB account = new Report_RPE_ANALITICO_DESEMB
                    {
                        ICAO = reader.GetString("ICAO"),
                        NUMVOO_DESEMB = (reader.GetInt32("C_ARRIVAL_FLIGHT_NUMBER") == 0 ? 0 : reader.GetInt32("C_ARRIVAL_FLIGHT_NUMBER")),
                        DATAVOO_DESEMB = (reader.GetDateTime("C_ARRIVAL_FLIGHT_DATE").ToString() == "01/01/1900 00:00:00" || reader.GetDateTime("C_ARRIVAL_FLIGHT_DATE").ToString() == null ? "" : reader.GetDateTime("C_ARRIVAL_FLIGHT_DATE").ToString("dd-MM-yyyy")),
                        HORAVOO_DESEMB = (reader.GetString("C_ARRIVAL_FLIGHT_HOUR") == "00:00" || reader.GetString("C_ARRIVAL_FLIGHT_HOUR") == null ? "" : reader.GetString("C_ARRIVAL_FLIGHT_HOUR")),
                        TIPO_VOO_DESEMB = (reader.GetString("C_ARRIVAL_FLIGHT_TYPE") == null ? "" : reader.GetString("C_ARRIVAL_FLIGHT_TYPE")),
                        PARTICIPACAO_DESEMB = (reader.GetString("C_ARRIVAL_PARTICIPATION") == null ? "" : reader.GetString("C_ARRIVAL_PARTICIPATION")),
                        NATUREZA_VOO_DESEMB = (reader.GetString("C_ARRIVAL_FLIGHT_NATURE") == null ? "" : reader.GetString("C_ARRIVAL_FLIGHT_NATURE")),
                        PAX_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_PAX"),
                        PAX_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_PAX"),
                        PAX_DOM_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_CONN_PAX"),
                        PAX_INTL_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_INT_CONN_PAX"),
                        BAGAGEM_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_BAGGAGE"),
                        BAGAGEM_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_BAGGAGE"),
                        BAGAGEM_DOM_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_CONN_BAGGAGE"),
                        BAGAGEM_INTL_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_INT_CONN_BAGGAGE"),
                        CARGA_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_CARGO"),
                        CARGA_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_CARGO"),
                        CARGA_DOM_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_CONN_CARGO"),
                        CARGA_INTL_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_INT_CONN_CARGO"),
                        CORREIO_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_POSTAL"),
                        CORREIO_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_POSTAL"),
                        CORREIO_DOM_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_CONN_POSTAL"),
                        CORREIO_INTL_CONEX_DESEMB = reader.GetInt32("C_ARRIVAL_INT_CONN_POSTAL"),
                        BAGAGEM_TRANSITO_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_TRANSIT_BAGGAGE"),
                        BAGAGEM_TRANSITO_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_TRANSIT_BAGGAGE"),
                        CARGA_TRANSITO_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_TRANSIT_CARGO"),
                        CARGA_TRANSITO_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_TRANSIT_CARGO"),
                        CORREIO_TRANSITO_DOM_DESEMB = reader.GetInt32("C_ARRIVAL_DOM_TRANSIT_POSTAL"),
                        CORREIO_TRANSITO_INTL_DESEMB = reader.GetInt32("C_ARRIVAL_INT_TRANSIT_POSTAL"),
                        DATA_DIGITACAO = reader.GetDateTime("DATA_DIGITACAO").ToString("dd-MM-yyyy"),
                        USUARIO = reader.GetString("C_GUIUSER")
                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }
    //

    /// <summary>
    /// List for RTE Report
    /// </summary>
    /// <returns></returns>
    public List<Report_RTE> GetRTE()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            //DateTime mdate = DateTime.Now;

            string mquery = "__RTE__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_RTE> xList = new List<Report_RTE>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_RTE account = new Report_RTE
                    {
                        EMPRESA_AEREA = reader.GetString("CiaAerea"),
                        CODIGO_OPERACAO = reader.GetString("NumRTE"),
                        TIPO_OPERACAO = reader.GetString("Operacao"),
                        QUANTIDADE = reader.GetInt32("QUANTIDADE"),
                        DATA_OPERACAO = reader.GetDateTime("DATA_OPERACAO").ToString("dd-MM-yyyy"),
                        ATAERO_ARRECADADO = (reader.GetDecimal("ATAERO") != null ? reader.GetDecimal("ATAERO") : 0).ToString("##,0.00"),
                        ADICIONAL_TARIFA_EMBARQUE_INTERNACIONAL = (reader.GetDecimal("ADICIONAL") != null ? reader.GetDecimal("ADICIONAL") : 0).ToString("##,0.00"),
                        VALOR_TARIFA_OPERACAO = (reader.GetDecimal("Valor") != null ? reader.GetDecimal("Valor") : 0).ToString("##,0.00"),
                        VALOR_COBRADO = (reader.GetDecimal("VALOR_TOTAL") != null ? reader.GetDecimal("VALOR_TOTAL") : 0).ToString("##,0.00")
                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    /// <summary>
    /// List for DAT Report
    /// </summary>
    /// <returns></returns>
    public List<Report_DAT> GetDAT()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            //DateTime mdate = DateTime.Now;

            string mquery = "__DAT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_DAT> xList = new List<Report_DAT>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_DAT account = new Report_DAT
                    {
                        TIPO_OPERACAO = reader.GetString("Operacao"),
                        CODIGO_OPERACAO = reader.GetString("NUMDAT"),
                        EMPRESA_AEREA = (reader.GetString("GRUPO") == "Grp. I" ? reader.GetString("ICAO") : reader.GetString("documentnumber")),
                        GRUPO_AERONAVE = reader.GetString("GRUPO"),
                        MODELO_AERONAVE = reader.GetString("MODELO"),
                        CLASSE_AERONAVE = reader.GetString("CLASSE"),
                        MARCAS_AERONAVE = reader.GetString("MATRICULA"),
                        OPERADOR_AERONAVE = reader.GetString("documentnumber"),
                        NUMERO_VOO = reader.GetString("NUMVOO"),
                        NATUREZA_VOO = reader.GetString("NATUREZAVOO"),
                        DATA_OPERACAO_REALIZADO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("dd-MM-yyyy"),
                        HORARIO_OPERACAO_REALIZADO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("HH:mm:00"),
                        AEROPORTO_POUSO = reader.GetString("DESTINO"),
                        AEROPORTO_ORIGEM = reader.GetString("ORIGEM"),
                        PMD = reader.GetInt32("PMD"),
                        VALOR_TARIFA_OPERACAO = (reader.GetDecimal("VALOR_OPERACAO") != null ? reader.GetDecimal("VALOR_OPERACAO") : 0).ToString("##,0.00##"),
                        VALOR_COBRADO = (reader.GetDecimal("TOTAL_OPERACAO") != null && reader.GetDecimal("TOTAL_OPERACAO") != 0 ? reader.GetDecimal("TOTAL_OPERACAO") : reader.GetDecimal("VALOR_OPERACAO")).ToString("##,0.00"),
                        DATA_REGISTRO_SISTEMA = reader.GetDateTime("DATA_HORA_EMISSAO").ToString("dd-MM-yyyy"),
                        ATAERO_ARRECADADO = (reader.GetDecimal("ATAERO") != null ? reader.GetDecimal("ATAERO") : 0).ToString("##,0.00")



                    };
                    xList.Add(account);
                }
            }
            return xList;
        }

    }

    public List<Report_DAT_Analitico> GetDATAnalitico()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            //DateTime mdate = DateTime.Now;

            string mquery = "__DAT_ANALITICO__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_DAT_Analitico> xList = new List<Report_DAT_Analitico>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_DAT_Analitico account = new Report_DAT_Analitico
                    {
                        CODIGO_OPERACAO = reader.GetString("NUMDAT"),
                        CLIENTE = (reader.GetString("GRUPO") == "Grp. I" ? reader.GetString("ICAO") : reader.GetString("MATRICULA")),
                        NUMVOO = reader.GetString("NUMVOO"),
                        NATUREZAVOO = reader.GetString("NATUREZAVOO"),
                        FORMA_PGTO = reader.GetString("FORMA_PGTO"),
                        DATA_OPERACAO_REALIZADO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("dd-MM-yyyy"),
                        HORARIO_OPERACAO_REALIZADO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("HH:mm:00"),
                        AEROPORTO_POUSO = reader.GetString("DESTINO"),
                        AEROPORTO_ORIGEM = reader.GetString("ORIGEM"),
                        PMD = reader.GetInt32("PMD"),
                        MODELO = reader.GetString("MODELO"),
                        TOTAL_OPERACAO_POUSO = (reader.GetDecimal("TOTAL_OPERACAO_POUSO") != null && reader.GetDecimal("TOTAL_OPERACAO_POUSO") != 0 ? reader.GetDecimal("TOTAL_OPERACAO_POUSO") : reader.GetDecimal("TOTAL_OPERACAO_POUSO")).ToString("##,0.00"),
                        TOTAL_OPERACAO_MANOBRA = (reader.GetDecimal("TOTAL_OPERACAO_MANOBRA") != null && reader.GetDecimal("TOTAL_OPERACAO_MANOBRA") != 0 ? reader.GetDecimal("TOTAL_OPERACAO_MANOBRA") : reader.GetDecimal("TOTAL_OPERACAO_MANOBRA")).ToString("##,0.00"),
                        TOTAL_OPERACAO_ESTADIA = (reader.GetDecimal("TOTAL_OPERACAO_ESTADIA") != null && reader.GetDecimal("TOTAL_OPERACAO_ESTADIA") != 0 ? reader.GetDecimal("TOTAL_OPERACAO_ESTADIA") : reader.GetDecimal("TOTAL_OPERACAO_ESTADIA")).ToString("##,0.00"),
                        TOTAL_OPERACAO_PAT = (reader.GetDecimal("TOTAL_OPERACAO_PAT") != null && reader.GetDecimal("TOTAL_OPERACAO_PAT") != 0 ? reader.GetDecimal("TOTAL_OPERACAO_PAT") : reader.GetDecimal("VALOR_OPERACAO")).ToString("##,0.00"),
                        TOTAL_OPERACAO_PAN = (reader.GetDecimal("TOTAL_OPERACAO_PAN") != null && reader.GetDecimal("TOTAL_OPERACAO_PAN") != 0 ? reader.GetDecimal("TOTAL_OPERACAO_PAN") : reader.GetDecimal("TOTAL_OPERACAO_PAN")).ToString("##,0.00"),
                        NOTES = reader.GetString("NOTES"),
                        TOTAL_DOLAR = (reader.GetDecimal("TOTAL_DOLAR") != null && reader.GetDecimal("TOTAL_DOLAR") != 0 ? reader.GetDecimal("TOTAL_DOLAR") : reader.GetDecimal("TOTAL_DOLAR")).ToString("##,0.00"),
                        TOTAL_ATAERO = (reader.GetDecimal("TOTAL_ATAERO") != null && reader.GetDecimal("TOTAL_ATAERO") != 0 ? reader.GetDecimal("TOTAL_ATAERO") : reader.GetDecimal("TOTAL_ATAERO")).ToString("##,0.00"),
                        TOTAL_GERAL = (reader.GetDecimal("TOTAL_GERAL") != null && reader.GetDecimal("TOTAL_GERAL") != 0 ? reader.GetDecimal("TOTAL_GERAL") : reader.GetDecimal("TOTAL_GERAL")).ToString("##,0.00"),
                        DATA_REGISTRO_SISTEMA = reader.GetDateTime("DATA_HORA_EMISSAO").ToString("dd-MM-yyyy"),
                        STATUS = reader.GetString("STATUS")

                    };
                    xList.Add(account);
                }
            }
            return xList;
        }

    }

    /// <summary>
    /// List for Tarrifs by Client Report
    /// </summary>
    /// <returns></returns>
    public List<Report_TarifasPorCliente> GetTarifasPorCliente()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            //DateTime mdate = DateTime.Now;

            string mquery = "__TARIFAS_A_COBRAR_POR_CLIENTE__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_TarifasPorCliente> xList = new List<Report_TarifasPorCliente>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_TarifasPorCliente account = new Report_TarifasPorCliente
                    {
                        EMPRESA_AEREA = reader.GetString("Cliente"),
                        TIPO_OPERACAO = reader.GetString("Operacao"),
                        VALOR_OPERACAO = (reader.GetDecimal("Valor") != null ? reader.GetDecimal("Valor") : 0).ToString("##,0.00")
                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }
    /// <summary>
    /// List for Passengers Report
    /// </summary>
    /// <returns></returns>
    public List<Report_Passageiros> GetPassageiros()
    {

        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            //DateTime mdate = DateTime.Now;

            string mquery = "__PASSAGEIROS__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_Passageiros> xList = new List<Report_Passageiros>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Passageiros account = new Report_Passageiros
                    {
                        NUMERO_VOO = reader.GetString("c_FlightNumber"),
                        DATA_VOO = reader.GetDateTime("c_FlightDateTime").ToString("dd-MM-yyyy"),
                        EMPRESA_AEREA = reader.GetString("CiaAerea"),
                        TIPO_OPERACAO = reader.GetString("Operacao"),
                        VALOR_TOTAL_OPERACAO = (reader.GetDecimal("Valor") != null ? reader.GetDecimal("Valor") : 0).ToString("##,0.00"),
                        ATAERO_ARRECADADO = (reader.GetDecimal("Ataero") != null ? reader.GetDecimal("Ataero") : 0).ToString("##,0.00"),
                        QUANTIDADE = reader.GetInt32("QUANTIDADE"),
                        ADICIONAL_TARIFA_EMBARQUE_INTERNACIONAL = (reader.GetDecimal("ADICIONAL") != null ? reader.GetDecimal("ADICIONAL") : 0).ToString("##,0.00"),
                        VALOR_TARIFA_OPERACAO = reader.GetDecimal("Valor_Tarifa").ToString("##,0.00")

                    };
                    xList.Add(account);
                }
            }
            return xList;
        }

    }
    /// <summary>
    /// List for ANAC Analitics Report
    /// </summary>
    /// <returns></returns>
    public List<Report_ANAC> GetAnac()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__ANAC__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_ANAC> xList = new List<Report_ANAC>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_ANAC account = new Report_ANAC
                    {

                        TIPO_OPERACAO = reader.GetString("Operacao"),
                        EMPRESA_AEREA = (reader.GetString("GRUPO") == "Grp. I" ? reader.GetString("ICAO") : reader.GetString("Cliente")),
                        CODIGO_OPERACAO = reader.GetString("CODIGO_OPERACAO"),
                        TIPO_LINHA = (reader.GetString("GRUPO") == "Grp. I" ? "Regular" : "Não regular"),
                        NUMERO_VOO = reader.GetString("NUMVOO"),
                        DATA_VOO_REALIZADO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("dd-MM-yyyy"),
                        HORARIO_VOO_REALIZADO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("HH:mm:00"),
                        DATA_VOO_PREVISTO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("dd-MM-yyyy"),
                        VALOR_TARIFA_OPERACAO = (reader.GetDecimal("VALOR_OPERACAO") != null ? reader.GetDecimal("VALOR_OPERACAO") : 0).ToString("##,0.00##"),
                        VALOR_TOTAL_OPERACAO = (reader.GetDecimal("TOTAL_OPERACAO") != null && reader.GetDecimal("TOTAL_OPERACAO") != 0 ? reader.GetDecimal("TOTAL_OPERACAO") : reader.GetDecimal("VALOR_OPERACAO")).ToString("##,0.00"),
                        GRUPO = reader.GetString("GRUPO"),
                        ICAO = reader.GetString("ICAO"),
                        PMD = reader.GetInt32("PMD"),
                        ORIGEM = reader.GetString("ORIGEM"),
                        NATUREZA_VOO = reader.GetString("NATUREZAVOO"),
                        MODELO_AERONAVE = reader.GetString("MODELO"),
                        CATEGORIA = reader.GetString("CATEGORIA"),
                        CLASSE = reader.GetString("CLASSE"),
                        MANOBRA = reader.GetInt32("MANOBRA"),
                        ESTADIA = reader.GetInt32("ESTADIA"),
                        DATA_REGISTRO_SISTEMA = reader.GetDateTime("DATA_HORA_EMISSAO").ToString("dd-MM-yyyy"),
                        ADICIONAL_TARIFA_EMBARQUE_INTERNACIONAL = (reader.GetDecimal("ADICIONAL") != null ? reader.GetDecimal("ADICIONAL") : 0).ToString("##,0.00"),
                        ATAERO_ARRECADADO = (reader.GetDecimal("ATAERO") != null ? reader.GetDecimal("ATAERO") : 0).ToString("##,0.00"),

                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }
    /// <summary>
    /// List for Landing Report
    /// </summary>
    /// <returns></returns>
    public List<Report_Pouso> GetPouso(string ICAOfilter, string GP2filter)
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__LANDING_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%ICAO%%", ICAOfilter, true); //using dontValidateString = true to enable list with "'" character.
            stmt.AddParam("%%GP2%%", GP2filter, true);

            List<Report_Pouso> xList = new List<Report_Pouso>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Pouso account = new Report_Pouso
                    {

                        TIPO_OPERACAO = reader.GetString("Operacao"),
                        CODIGO_OPERACAO = reader.GetString("CODIGO_OPERACAO"),
                        EMPRESA_AEREA = (reader.GetString("GRUPO") == "Grp. I" ? reader.GetString("ICAO") : reader.GetString("documentnumber")),
                        GRUPO_AERONAVE = reader.GetString("GRUPO"),
                        MODELO_AERONAVE = reader.GetString("MODELO"),
                        CLASSE_AERONAVE = reader.GetString("CLASSE"),
                        MARCAS_AERONAVE = reader.GetString("MATRICULA"),
                        OPERADOR_AERONAVE = reader.GetString("documentnumber"),
                        NUMERO_VOO = reader.GetString("NUMVOO"),
                        NATUREZA_VOO = reader.GetString("NATUREZAVOO"),
                        TIPO_LINHA = (reader.GetString("GRUPO") == "Grp. I" ? "Regular" : "Não regular"),
                        DATA_OPERACAO_REALIZADO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("dd-MM-yyyy"),
                        HORARIO_OPERACAO_REALIZADO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("HH:mm:00"),
                        DATA_DESCALCO_REALIZADO = "",//TODO:
                        HORARIO_DESCALCO_REALIZADO = "",//TODO:
                        DATA_OPERACAO_PREVISTO = "",//TODO:
                        HORARIO_OPERACAO_PREVISTO = "",//TODO:
                        AEROPORTO_POUSO = reader.GetString("DESTINO"),
                        AEROPORTO_ORIGEM = reader.GetString("ORIGEM"),
                        PMD = reader.GetInt32("PMD"),
                        VALOR_TARIFA_OPERACAO = (reader.GetDecimal("VALOR_OPERACAO") != null ? reader.GetDecimal("VALOR_OPERACAO") : 0).ToString("##,0.00##"),
                        VALOR_COBRADO = (reader.GetDecimal("TOTAL_OPERACAO") != null && reader.GetDecimal("TOTAL_OPERACAO") != 0 ? reader.GetDecimal("TOTAL_OPERACAO") : reader.GetDecimal("VALOR_OPERACAO")).ToString("##,0.00"),
                        DATA_REGISTRO_SISTEMA = reader.GetDateTime("DATA_HORA_EMISSAO").ToString("dd-MM-yyyy"),
                        TIPO_COBRANCA = reader.GetString("TIPO_COBRANCA"),
                        ATAERO_ARRECADADO = (reader.GetDecimal("ATAERO") != null ? reader.GetDecimal("ATAERO") : 0).ToString("##,0.00")

                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }
    /// <summary>
    /// Permanência Estadia
    /// </summary>
    /// <returns></returns>
    public List<Report_Permanencia> GetPermanenciaEstadia(string ICAOfilter, string GP2filter)
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__PARKING_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%ICAO%%", ICAOfilter, true); //using dontValidateString = true to enable list with "'" character.
            stmt.AddParam("%%GP2%%", GP2filter, true);

            List<Report_Permanencia> xList = new List<Report_Permanencia>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Permanencia account = new Report_Permanencia
                    {

                        TIPO_OPERACAO = reader.GetString("Operacao"),
                        CODIGO_OPERACAO = reader.GetString("CODIGO_OPERACAO"),
                        EMPRESA_AEREA = (reader.GetString("GRUPO") == "Grp. I" ? reader.GetString("ICAO") : reader.GetString("documentnumber")),
                        GRUPO_AERONAVE = reader.GetString("GRUPO"),
                        MODELO_AERONAVE = reader.GetString("MODELO"),
                        CLASSE_AERONAVE = reader.GetString("CLASSE"),
                        MARCAS_AERONAVE = reader.GetString("MATRICULA"),
                        OPERADOR_AERONAVE = reader.GetString("documentnumber"),
                        NUMERO_VOO = reader.GetString("NUMVOO"),
                        NATUREZA_VOO = reader.GetString("NATUREZAVOO"),
                        TIPO_LINHA = (reader.GetString("GRUPO") == "Grp. I" ? "Regular" : "Não regular"),
                        DATA_INICIO_OPERACAO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("dd-MM-yyyy"),
                        HORARIO_INICIO_OPERACAO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("HH:mm:00"),
                        DATA_FIM_OPERACAO = "",//TODO:
                        HORARIO_FIM_OPERACAO = "",//TODO:
                        PERIODO_PERMANENCIA = (reader.GetInt32("Estadia")),
                        AEROPORTO_PERMANENCIA = "SBGL", //TODO: reader.GetString("ORIGEM"),
                        PMD = reader.GetInt32("PMD"),
                        VALOR_TARIFA_OPERACAO = (reader.GetDecimal("VALOR_OPERACAO") != null ? reader.GetDecimal("VALOR_OPERACAO") : 0).ToString("##,0.00##"),
                        VALOR_COBRADO = (reader.GetDecimal("TOTAL_OPERACAO") != null && reader.GetDecimal("TOTAL_OPERACAO") != 0 ? reader.GetDecimal("TOTAL_OPERACAO") : reader.GetDecimal("VALOR_OPERACAO")).ToString("##,0.00"),
                        DATA_REGISTRO_SISTEMA = reader.GetDateTime("DATA_HORA_EMISSAO").ToString("dd-MM-yyyy"),
                        TIPO_COBRANCA = reader.GetString("TIPO_COBRANCA"),
                        ATAERO_ARRECADADO = (reader.GetDecimal("ATAERO") != null ? reader.GetDecimal("ATAERO") : 0).ToString("##,0.00")

                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }
    /// <summary>
    /// Permanência Manobra
    /// </summary>
    /// <returns></returns>
    public List<Report_Permanencia> GetPermanenciaManobra(string ICAOfilter, string GP2filter)
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__MANEUVER_RPT__ ";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%ICAO%%", ICAOfilter, true); //using dontValidateString = true to enable list with "'" character.
            stmt.AddParam("%%GP2%%", GP2filter, true);

            List<Report_Permanencia> xList = new List<Report_Permanencia>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Permanencia account = new Report_Permanencia
                    {

                        TIPO_OPERACAO = reader.GetString("Operacao"),
                        CODIGO_OPERACAO = reader.GetString("CODIGO_OPERACAO"),
                        EMPRESA_AEREA = (reader.GetString("GRUPO") == "Grp. I" ? reader.GetString("ICAO") : reader.GetString("documentnumber")),
                        GRUPO_AERONAVE = reader.GetString("GRUPO"),
                        MODELO_AERONAVE = reader.GetString("MODELO"),
                        CLASSE_AERONAVE = reader.GetString("CLASSE"),
                        MARCAS_AERONAVE = reader.GetString("MATRICULA"),
                        OPERADOR_AERONAVE = reader.GetString("documentnumber"),
                        NUMERO_VOO = reader.GetString("NUMVOO"),
                        NATUREZA_VOO = reader.GetString("NATUREZAVOO"),
                        TIPO_LINHA = (reader.GetString("GRUPO") == "Grp. I" ? "Regular" : "Não regular"),
                        DATA_INICIO_OPERACAO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("dd-MM-yyyy"),
                        HORARIO_INICIO_OPERACAO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("HH:mm:00"),
                        DATA_FIM_OPERACAO = "",//TODO:
                        HORARIO_FIM_OPERACAO = "",//TODO:
                        PERIODO_PERMANENCIA = (reader.GetInt32("Manobra")),
                        AEROPORTO_PERMANENCIA = "SBGL", //TODO: reader.GetString("ORIGEM"),
                        PMD = reader.GetInt32("PMD"),
                        VALOR_TARIFA_OPERACAO = (reader.GetDecimal("VALOR_OPERACAO") != null ? reader.GetDecimal("VALOR_OPERACAO") : 0).ToString("##,0.00##"),
                        VALOR_COBRADO = (reader.GetDecimal("TOTAL_OPERACAO") != null && reader.GetDecimal("TOTAL_OPERACAO") != 0 ? reader.GetDecimal("TOTAL_OPERACAO") : reader.GetDecimal("VALOR_OPERACAO")).ToString("##,0.00"),
                        DATA_REGISTRO_SISTEMA = reader.GetDateTime("DATA_HORA_EMISSAO").ToString("dd-MM-yyyy"),
                        TIPO_COBRANCA = reader.GetString("TIPO_COBRANCA"),
                        ATAERO_ARRECADADO = (reader.GetDecimal("ATAERO") != null ? reader.GetDecimal("ATAERO") : 0).ToString("##,0.00")

                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }
    /// <summary>
    /// List for Connection report
    /// </summary>
    /// <returns></returns>
    public List<Report_Conexao> GetConexao(string ICAOfilter)
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__CONNECTION_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%ICAO%%", ICAOfilter, true); //using dontValidateString = true to enable list with "'" character.

            List<Report_Conexao> xList = new List<Report_Conexao>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Conexao account = new Report_Conexao
                    {

                        TIPO_OPERACAO = reader.GetString("Operacao"),
                        EMPRESA_AEREA = reader.GetString("ICAO"),
                        CODIGO_OPERACAO = reader.GetString("CODIGO_OPERACAO"),
                        TIPO_LINHA = (reader.GetString("GRUPO") == "Grp. I" ? "Regular" : "Não regular"),
                        NUMERO_VOO = reader.GetString("NUMVOO"),
                        DATA_VOO_REALIZADO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("dd-MM-yyyy"),
                        HORARIO_VOO_REALIZADO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("HH:mm:00"),
                        DATA_VOO_PREVISTO = "",   //reader.GetDateTime("DATA_HORA_OPERACAO").ToString("dd-MM-yyyy"),
                        HORARIO_VOO_PREVISTO = "",//reader.GetDateTime("DATA_HORA_OPERACAO").ToString("HH:mm:00"),
                        VALOR_TARIFA_OPERACAO = (reader.GetDecimal("VALOR_OPERACAO") != null ? reader.GetDecimal("VALOR_OPERACAO") : 0).ToString("##,0.00##"),
                        VALOR_TOTAL_OPERACAO = (reader.GetDecimal("TOTAL_OPERACAO") != null && reader.GetDecimal("TOTAL_OPERACAO") != 0 ? reader.GetDecimal("TOTAL_OPERACAO") : reader.GetDecimal("VALOR_OPERACAO")).ToString("##,0.00"),
                        NATUREZA_VOO = reader.GetString("NATUREZAVOO"),
                        DATA_REGISTRO_SISTEMA = reader.GetDateTime("DATA_HORA_EMISSAO").ToString("dd-MM-yyyy"),
                        QUANTIDADE = reader.GetInt32("QUANTIDADE")

                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }
    /// <summary>
    /// List for Emplanement report
    /// </summary>
    /// <returns></returns>
    public List<Report_Embarque> GetEmbarque(string ICAOfilter)
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__EMPLANEMENT_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%ICAO%%", ICAOfilter, true);//using dontValidateString = true to enable list with "'" character.

            List<Report_Embarque> xList = new List<Report_Embarque>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Embarque account = new Report_Embarque
                    {

                        TIPO_OPERACAO = reader.GetString("Operacao"),
                        EMPRESA_AEREA = reader.GetString("ICAO"),
                        CODIGO_OPERACAO = reader.GetString("CODIGO_OPERACAO"),
                        TIPO_LINHA = (reader.GetString("GRUPO") == "Grp. I" ? "Regular" : "Não regular"),
                        NATUREZA_VOO = reader.GetString("NATUREZAVOO"),
                        DATA_VOO_REALIZADO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("dd-MM-yyyy"),
                        HORARIO_VOO_REALIZADO = reader.GetDateTime("DATA_HORA_OPERACAO").ToString("HH:mm:00"),
                        DATA_VOO_PREVISTO = "",//reader.GetDateTime("DATA_HORA_OPERACAO").ToString("dd-MM-yyyy"),
                        HORARIO_VOO_PREVISTO = "",//reader.GetDateTime("DATA_HORA_OPERACAO").ToString("dd-MM-yyyy"),
                        VALOR_TOTAL_OPERACAO = (reader.GetDecimal("TOTAL_OPERACAO") != null && reader.GetDecimal("TOTAL_OPERACAO") != 0 ? reader.GetDecimal("TOTAL_OPERACAO") : reader.GetDecimal("VALOR_OPERACAO")).ToString("##,0.00"),
                        NUMERO_VOO = reader.GetString("NUMVOO"),
                        MODELO_AERONAVE = reader.GetString("MODELO"),
                        QUANTIDADE = reader.GetInt32("QUANTIDADE"),
                        DATA_REGISTRO_SISTEMA = reader.GetDateTime("DATA_HORA_EMISSAO").ToString("dd-MM-yyyy"),
                        ADICIONAL_TARIFA_EMBARQUE_INTERNACIONAL = (reader.GetDecimal("ADICIONAL") != null ? reader.GetDecimal("ADICIONAL") : 0).ToString("##,0.00"),
                        VALOR_TARIFA_OPERACAO = (reader.GetDecimal("VALOR_OPERACAO") != null ? reader.GetDecimal("VALOR_OPERACAO") : 0).ToString("##,0.00##"),
                        ATAERO_ARRECADADO = (reader.GetDecimal("ATAERO") != null ? reader.GetDecimal("ATAERO") : 0).ToString("##,0.00")

                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    public List<Report_Aeroportos> GetAeroportos()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__AEROPORTOS_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            List<Report_Aeroportos> xList = new List<Report_Aeroportos>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Aeroportos account = new Report_Aeroportos
                    {

                        ICAO = reader.GetString("C_ICAO"),
                        DESCRICAO = reader.GetString("C_DESCRIPTION")


                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    public List<Report_CE> GetCE()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__ELTR_CONF_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_CE> xList = new List<Report_CE>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_CE account = new Report_CE
                    {

                        IATA = reader.GetString("IATA"),
                        EMPRESA_AEREA = reader.GetString("EMPRESA_AEREA"),
                        NUMERO_VOO = reader.GetString("NUM_VOO"),
                        DATA_VOO = reader.GetDateTime("DATA_VOO").ToString("dd-MM-yyyy"),
                        AEROPORTO_ORIGEM = reader.GetString("AEROPORTO_ORIGEM"),
                        TOTAL_PAX_DOM = reader.GetInt32("TOTAL_PAX_DOM"),
                        TOTAL_PAX_INTL = reader.GetInt32("TOTAL_PAX_INTL")


                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    public List<Report_Sales> GetSalesRpt()
    {
        var query = string.Format(@"select p.C_ACCOUNT, d.TX_DESC, p.C_REVDATE, p.C_REVENUEAMOUNT from t_pv_mprevenueprodview p, t_description d
                    where p.c_revenuetype = d.id_desc 
                    and d.id_lang_code = 1046 
                    and p.C_REVDATE BETWEEN TO_DATE('{0:dd/MM/yyyy}','DD/MM/YYYY') AND TO_DATE('{1:dd/MM/yyyy}','DD/MM/YYYY')
                    order by p.C_ACCOUNT,p.C_REVDATE", System.DateTime.Parse(mtdpStartDate.Text), System.DateTime.Parse(mtdpEndDate.Text));

        var list = new List<Report_Sales>();

        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {
            var stmt = conn.CreateStatement(query);
            var reader = stmt.ExecuteReader();

            while (reader.Read())
            {
                var s = new Report_Sales();
                //p.C_ACCOUNT, d.TX_DESC, p.C_REVDATE, p.C_REVENUEAMOUNT
                s.CLIENTE = reader.GetString("C_ACCOUNT");
                s.CATEGORIA_DE_PRODUTO = reader.GetString("TX_DESC");
                s.DATA_DA_RECEITA = reader.GetDateTime("C_REVDATE").ToString("dd-MM-yyyy");
                s.VALOR_DE_VENDA_INFORMADO = reader.GetDecimal("C_REVENUEAMOUNT").ToString("C2");

                list.Add(s);
            }
        }

        return list;
    }

    public List<Report_Grupo1> GetGrp1()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__GRP1_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            // stmt.AddParam("%%START_DATE%%", System.DateTime.Parse(mtdpStartDate.Text).ToString("yyyy-MM-dd"));
            // stmt.AddParam("%%END_DATE%%", System.DateTime.Parse(mtdpEndDate.Text).ToString("yyyy-MM-dd"));

            List<Report_Grupo1> xList = new List<Report_Grupo1>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Grupo1 account = new Report_Grupo1
                    {
                        NOME_CLIENTE = reader.GetString("NOME_CLIENTE"),
                        TIPO_DOCUMENTO = reader.GetString("TIPO_DOCUMENTO"),
                        DOCUMENTO = reader.GetString("DOCUMENTO"),
                        EMAIL = reader.GetString("EMAIL"),
                        ENDERECO = reader.GetString("ENDERECO"),
                        CEP = reader.GetString("CEP"),
                        INSCR_MUNICIPAL = reader.GetString("INSCR_MUNICIPAL"),
                        INSCR_ESTADUAL = reader.GetString("INSCR_ESTADUAL"),
                        IATA = reader.GetString("IATA"),
                        ICAO = reader.GetString("ICAO")
                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    public List<Report_Grupo2> GetGrp2()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {

            string mquery = "__GRP2_RPT__";

            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", mquery);

            List<Report_Grupo2> xList = new List<Report_Grupo2>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    Report_Grupo2 account = new Report_Grupo2
                    {
                        NOME_CLIENTE = reader.GetString("NOME_CLIENTE"),
                        TIPO_DOCUMENTO = reader.GetString("TIPO_DOCUMENTO"),
                        DOCUMENTO = reader.GetString("DOCUMENTO"),
                        EMAIL = reader.GetString("EMAIL"),
                        ENDERECO = reader.GetString("ENDERECO"),
                        CEP = reader.GetString("CEP"),
                        INSCR_MUNICIPAL = reader.GetString("INSCR_MUNICIPAL"),
                        INSCR_ESTADUAL = reader.GetString("INSCR_ESTADUAL"),
                        MATRICULA = reader.GetString("MATRICULA"),
                        MODELO = reader.GetString("MODELO"),
                        PMD = reader.GetInt32("PMD"),
                        CATEGORIA = reader.GetString("CATEGORIA"),
                        CLASSE = reader.GetString("CLASSE"),
                        ESTRANGEIRA = (reader.GetString("ESTRANGEIRA") == "0" ? "NÃO" : "SIM")
                    };
                    xList.Add(account);
                }
            }
            return xList;
        }
    }

    public List<Report_Rateio> GetSuprimentosRpt()
    {
        StringBuilder sql = new StringBuilder();
        sql.Append(@"SELECT v.* from V_GIG_RATEIO v ");
        sql.Append(@"WHERE TO_DATE(v.DT_INICIO_CONTRATO,'DD/MM/YYYY') BETWEEN TO_DATE('" + System.DateTime.Parse(mtdpStartDate.Text).ToString("dd/MM/yyyy") + "','DD/MM/YYYY') AND TO_DATE('" + System.DateTime.Parse(mtdpEndDate.Text).ToString("dd/MM/yyyy") + "','DD/MM/YYYY') ");
        
        if (ddlFantasia.SelectedItem.ToString() != "(SELECIONE)")
        {
            sql.Append(@" AND v.nome_fantasia = '" + ddlFantasia.SelectedItem.ToString() + "' ");
        }
        if (ddlContrato.SelectedItem.ToString() != "(SELECIONE)")
        {
            sql.Append(@" AND v.contrato = '" + ddlContrato.SelectedItem.ToString() + "' ");
        }
        if (ddlLUC.SelectedItem.ToString() != "(SELECIONE)")
        {
            sql.Append(@" AND v.LUC = '" + ddlLUC.SelectedItem.ToString() + "' ");
        }

        var list = new List<Report_Rateio>();
        string query = sql.ToString();

        //Response.Write("<script type='text/javascript'>alert('" + query.ToString() + "');</script>");

        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {
            var stmt = conn.CreateStatement(query);
            var reader = stmt.ExecuteReader();

            while (reader.Read())
            {
                var s = new Report_Rateio();
                if (!reader.IsDBNull("PK"))
                {
                    s.PK = reader.GetString("PK");
                }
                else
                {
                    s.PK = string.Empty;
                }
                if (!reader.IsDBNull("CNPJ"))
                {
                    s.CNPJ = reader.GetString("CNPJ");
                }
                else
                {
                    s.CNPJ = string.Empty;
                }
                if (!reader.IsDBNull("CONTRATO"))
                {
                    s.CONTRATO = reader.GetString("CONTRATO");
                }
                else
                {
                    s.CONTRATO = string.Empty;
                }
                if (!reader.IsDBNull("LUC"))
                {
                    s.LUC = reader.GetString("LUC");
                }
                else
                {
                    s.LUC = string.Empty;
                }
                if (!reader.IsDBNull("RAZAO_SOCIAL"))
                {
                    s.RAZAO_SOCIAL = reader.GetString("RAZAO_SOCIAL");
                }
                else
                {
                    s.RAZAO_SOCIAL = string.Empty;
                }
                if (!reader.IsDBNull("NOME_FANTASIA"))
                {
                    s.NOME_FANTASIA = reader.GetString("NOME_FANTASIA");
                }
                else
                {
                    s.NOME_FANTASIA = string.Empty;
                }
                if (!reader.IsDBNull("FORMATO"))
                {
                    s.FORMATO = reader.GetString("FORMATO");
                }
                else
                {
                    s.FORMATO = string.Empty;
                }
                if (!reader.IsDBNull("GRUPO"))
                {
                    s.GRUPO = reader.GetString("GRUPO");
                }
                else
                {
                    s.GRUPO = string.Empty;
                }
                if (!reader.IsDBNull("SUB_GRUPO"))
                {
                    s.SUB_GRUPO = reader.GetString("SUB_GRUPO");
                }
                else
                {
                    s.SUB_GRUPO = string.Empty;
                }
                if (!reader.IsDBNull("TIPO_AREA"))
                {
                    s.TIPO_AREA = reader.GetString("TIPO_AREA");
                }
                else
                {
                    s.TIPO_AREA = string.Empty;
                }
                if (!reader.IsDBNull("EDIFICACAO"))
                {
                    s.EDIFICACAO = reader.GetString("EDIFICACAO");
                }
                else
                {
                    s.EDIFICACAO = string.Empty;
                }
                if (!reader.IsDBNull("DESCRICAO_LOCALIZACAO"))
                {
                    s.DESCRICAO_LOCALIZACAO = reader.GetString("DESCRICAO_LOCALIZACAO");
                }
                else
                {
                    s.DESCRICAO_LOCALIZACAO = string.Empty;
                }
                if (!reader.IsDBNull("AREA"))
                {
                    s.AREA = reader.GetInt32("AREA");
                }
                else
                {
                    s.AREA = 0;
                }
                if (!reader.IsDBNull("DT_INICIO_CONTRATO"))
                {
                    s.DT_INICIO_CONTRATO = reader.GetString("DT_INICIO_CONTRATO");
                }
                else
                {
                    s.DT_INICIO_CONTRATO = string.Empty;
                }
                if (!reader.IsDBNull("DT_FIM_CONTRATO"))
                {
                    s.DT_FIM_CONTRATO = reader.GetString("DT_FIM_CONTRATO");
                }
                else
                {
                    s.DT_FIM_CONTRATO = string.Empty;
                }

                list.Add(s);
            }
        }

        return list;
    }


    /// <summary>
    /// Agni Campos
    /// RETURN ICAO 
    /// </summary>
    /// 
    public List<ALL_ICAOs> GetAllAirlines()
    {
        using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
        {
            IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", "__SELECT_ALL_AIRLINES__");

            List<ALL_ICAOs> xList = new List<ALL_ICAOs>();

            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    ALL_ICAOs account = new ALL_ICAOs
                    {
                        ICAO = reader.GetString("NM_LOGIN")
                    };

                    xList.Add(account);
                }
            }
            return xList;
        }
    }
    //private void GetAllAircrafts()
    //{

    // using (IMTServicedConnection conn = ConnectionManager.CreateConnection())
    //    {
    //        IMTAdapterStatement stmt = conn.CreateAdapterStatement("Queries", "__SELECT_ALL_AIRCRAFTS__");

    //        using (IMTDataReader reader = stmt.ExecuteReader())
    //        {
    //            while (reader.Read())
    //            {
    //                ddlAircrafts.Items.Add(reader.GetString("NM_LOGIN"));
    //            }
    //        }
    //    }

    //}

    public void GetIntervals()
    {
        ddBillingPeriod.Items.Clear();

        string sql = "";
        sql = "SELECT UI.ID_INTERVAL || ' (' ||  TO_CHAR(UI.DT_START,  'DD-MM-YYYY') ||  ' - ' ||  TO_CHAR(UI.DT_END,  'DD-MM-YYYY') ||  ')' FROM T_USAGE_INTERVAL UI WHERE UI.ID_INTERVAL IN (SELECT DISTINCT AUI.ID_USAGE_INTERVAL FROM T_ACC_USAGE_INTERVAL AUI, T_ACCOUNT ACC, T_ACCOUNT_TYPE ACCT WHERE AUI.ID_ACC = ACC.ID_ACC AND ACC.ID_TYPE = ACCT.ID_TYPE AND ACCT.NAME LIKE 'AVN%' AND AUI.ID_USAGE_INTERVAL = UI.ID_INTERVAL) ORDER BY UI.DT_END DESC";

        using (var conn = ConnectionManager.CreateConnection())
        {
            var stmt = conn.CreateStatement(sql);
            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    ListItem itm = new ListItem(reader.GetString(0).ToUpper());
                    ddBillingPeriod.Items.Add(itm);

                }
            }
        }
    }

    public void FillddlFantasia()
    {
        ddlFantasia.Items.Clear();
        ddlFantasia.Items.Add("(SELECIONE)");
        string sql = string.Empty;
        sql = "select DISTINCT v.NOME_FANTASIA from V_GIG_RATEIO v order by v.NOME_FANTASIA";

        using (var conn = ConnectionManager.CreateConnection())
        {
            var stmt = conn.CreateStatement(sql);
            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    ListItem itm = new ListItem(reader.GetString(0).ToUpper());
                    ddlFantasia.Items.Add(itm);
                }
            }
        }
    }

    public void FillddlContratos()
    {
        ddlContrato.Items.Clear();
        ddlContrato.Items.Add("(SELECIONE)");
        string sql = "";
        sql = "select DISTINCT v.CONTRATO from V_GIG_RATEIO v order by v.CONTRATO";

        using (var conn = ConnectionManager.CreateConnection())
        {
            var stmt = conn.CreateStatement(sql);
            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    ListItem itm = new ListItem(reader.GetString(0).ToUpper());
                    ddlContrato.Items.Add(itm);

                }
            }
        }
    }

    public void FillddlLUC()
    {
        ddlLUC.Items.Clear();
        ddlLUC.Items.Add("(SELECIONE)");
        string sql = "";
        sql = "select DISTINCT v.LUC from V_GIG_RATEIO v order by v.LUC";

        using (var conn = ConnectionManager.CreateConnection())
        {
            var stmt = conn.CreateStatement(sql);
            using (IMTDataReader reader = stmt.ExecuteReader())
            {
                while (reader.Read())
                {
                    ListItem itm = new ListItem(reader.GetString(0).ToUpper());
                    ddlLUC.Items.Add(itm);
                }
            }
        }
    }
}


#region "PARAMETERS"
public class Parameters
{
    public string REPORT_NAME { get; set; }
    public string REPORT_RUNDATE { get; set; }
    public string REPORT_GUID { get; set; }
    public string REPORT_DISPLAY_NAME { get; set; }
    public string REPORT_PARAMETERS { get; set; }

}


#endregion

#region "ANAC REPORTS"

/// <summary>
/// 17 colunas 
/// Todo: DATA_VOO_PREVISTO e HORARIO_VOO_PREVISTO
/// </summary>
public class Report_Embarque
{
    public string TIPO_OPERACAO { get; set; }
    public string CODIGO_OPERACAO { get; set; }
    public string EMPRESA_AEREA { get; set; }
    public string NATUREZA_VOO { get; set; }
    public string TIPO_LINHA { get; set; }
    public string NUMERO_VOO { get; set; }
    public string DATA_VOO_REALIZADO { get; set; }
    public string HORARIO_VOO_REALIZADO { get; set; }
    public string DATA_VOO_PREVISTO { get; set; }
    public string HORARIO_VOO_PREVISTO { get; set; }
    public string VALOR_TARIFA_OPERACAO { get; set; }
    public string DATA_REGISTRO_SISTEMA { get; set; }
    public string ATAERO_ARRECADADO { get; set; }
    public string ADICIONAL_TARIFA_EMBARQUE_INTERNACIONAL { get; set; }
    public string MODELO_AERONAVE { get; set; }
    public int? QUANTIDADE { get; set; }
    public string VALOR_TOTAL_OPERACAO { get; set; }

}
/// <summary>
/// 14 colunas
/// Todo: DATA_VOO_PREVISTO e HORARIO_VOO_PREVISTO
/// </summary>
public class Report_Conexao
{
    public string TIPO_OPERACAO { get; set; }
    public string CODIGO_OPERACAO { get; set; }
    public string EMPRESA_AEREA { get; set; }
    public string NATUREZA_VOO { get; set; }
    public string TIPO_LINHA { get; set; }
    public string NUMERO_VOO { get; set; }
    public string DATA_VOO_REALIZADO { get; set; }
    public string HORARIO_VOO_REALIZADO { get; set; }
    public string DATA_VOO_PREVISTO { get; set; }
    public string HORARIO_VOO_PREVISTO { get; set; }
    public string VALOR_TARIFA_OPERACAO { get; set; }
    public string DATA_REGISTRO_SISTEMA { get; set; }
    public int? QUANTIDADE { get; set; }
    public string VALOR_TOTAL_OPERACAO { get; set; }

}
/// <summary>
/// 25 colunas
/// </summary>
public class Report_Pouso
{
    public string TIPO_OPERACAO { get; set; }
    public string CODIGO_OPERACAO { get; set; }
    public string EMPRESA_AEREA { get; set; }
    public string OPERADOR_AERONAVE { get; set; }
    public string GRUPO_AERONAVE { get; set; }
    public string MODELO_AERONAVE { get; set; }
    public string CLASSE_AERONAVE { get; set; }
    public string MARCAS_AERONAVE { get; set; } //TODO:
    public string NUMERO_VOO { get; set; }
    public string NATUREZA_VOO { get; set; }
    public string TIPO_LINHA { get; set; }//TODO:
    public string DATA_OPERACAO_REALIZADO { get; set; }
    public string HORARIO_OPERACAO_REALIZADO { get; set; }
    public string DATA_DESCALCO_REALIZADO { get; set; }//TODO:
    public string HORARIO_DESCALCO_REALIZADO { get; set; }//TODO:
    public string DATA_OPERACAO_PREVISTO { get; set; }//TODO:
    public string HORARIO_OPERACAO_PREVISTO { get; set; }//TODO:
    public string AEROPORTO_POUSO { get; set; }//TODO:    
    public string AEROPORTO_ORIGEM { get; set; }
    public int? PMD { get; set; }
    public string VALOR_TARIFA_OPERACAO { get; set; }
    public string VALOR_COBRADO { get; set; }
    public string DATA_REGISTRO_SISTEMA { get; set; }
    public string TIPO_COBRANCA { get; set; }//TODO:
    public string ATAERO_ARRECADADO { get; set; }


}
/// <summary>
/// 23 colunas
/// </summary>
public class Report_Permanencia
{
    public string TIPO_OPERACAO { get; set; }
    public string CODIGO_OPERACAO { get; set; }
    public string EMPRESA_AEREA { get; set; }
    public string OPERADOR_AERONAVE { get; set; }
    public string GRUPO_AERONAVE { get; set; }
    public string MODELO_AERONAVE { get; set; }
    public string CLASSE_AERONAVE { get; set; }
    public string MARCAS_AERONAVE { get; set; } //TODO:
    public string NUMERO_VOO { get; set; }
    public string NATUREZA_VOO { get; set; }
    public string TIPO_LINHA { get; set; }//TODO:
    public string DATA_INICIO_OPERACAO { get; set; }
    public string DATA_FIM_OPERACAO { get; set; }//TODO:
    public string HORARIO_INICIO_OPERACAO { get; set; }
    public string HORARIO_FIM_OPERACAO { get; set; }//TODO:
    public int? PERIODO_PERMANENCIA { get; set; }//TODO:
    public string AEROPORTO_PERMANENCIA { get; set; }//TODO:
    public int? PMD { get; set; }
    public string VALOR_TARIFA_OPERACAO { get; set; }
    public string VALOR_COBRADO { get; set; }
    public string DATA_REGISTRO_SISTEMA { get; set; }
    public string TIPO_COBRANCA { get; set; }//TODO:
    public string ATAERO_ARRECADADO { get; set; }

}

public class Report_ANAC
{

    public string TIPO_OPERACAO { get; set; }
    public string EMPRESA_AEREA { get; set; }
    public string CODIGO_OPERACAO { get; set; }
    public string NATUREZA_VOO { get; set; }
    public string TIPO_LINHA { get; set; }
    public string NUMERO_VOO { get; set; }
    public string DATA_VOO_REALIZADO { get; set; }
    public string HORARIO_VOO_REALIZADO { get; set; }
    public string DATA_VOO_PREVISTO { get; set; }
    public string HORARIO_VOO_PREVISTO { get; set; }
    public string DATA_REGISTRO_SISTEMA { get; set; }
    public string GRUPO { get; set; }
    public string ICAO { get; set; }
    public int? PMD { get; set; }
    public string ORIGEM { get; set; }
    public string MODELO_AERONAVE { get; set; }
    public string CATEGORIA { get; set; }
    public string CLASSE { get; set; }
    public int? MANOBRA { get; set; }
    public int? ESTADIA { get; set; }
    public string VALOR_TARIFA_OPERACAO { get; set; }
    public string ATAERO_ARRECADADO { get; set; }
    public string ADICIONAL_TARIFA_EMBARQUE_INTERNACIONAL { get; set; }
    public string VALOR_TOTAL_OPERACAO { get; set; }

}

#endregion

// ============================================= 

#region "CARJSA REPORTS"

public class Report_Det_Embarque
{
    public string ICAO { get; set; }
    public string DATAHORA_VOO { get; set; }
    public string NUM_VOO { get; set; }
    public int? QTD_DOM { get; set; }
    public string VALOR_TARIFA_DOM { get; set; }
    public string VALOR_DOM { get; set; }
    public int? QTD_INTL { get; set; }
    public string VALOR_TARIFA_INTL { get; set; }
    public string VALOR_INTL { get; set; }
    public string VALOR_ATAERO { get; set; }
    public string VALOR_FNAC { get; set; }
    public string VALOR_TOTAL { get; set; }

}

public class Report_Det_Conexao
{
    public string ICAO { get; set; }
    public string DATAHORA_VOO { get; set; }
    public string NUM_VOO { get; set; }
    public int? QTD_DOM { get; set; }
    public string TARIFA_UNIT_CONEXAO_DOM { get; set; }
    public string VALOR_DOM { get; set; }
    public int? QTD_INTL { get; set; }
    public string TARIFA_UNIT_CONEXAO_INTL { get; set; }
    public string VALOR_INTL { get; set; }
    public string VALOR_TOTAL { get; set; }

}

public class Report_Det_Pouso
{
    public string CLIENTE { get; set; }
    public string ICAO { get; set; }
    public string DATAHORA_VOO { get; set; }
    public string NUM_VOO { get; set; }
    public string TIPOAERONAVE { get; set; }
    public string NATUREZAVOO { get; set; }
    public string ORIGEM { get; set; }
    public string MATRICULA { get; set; }
    public int? PMD { get; set; }
    public string TARIFA_POUSO { get; set; }
    public string TOTAL_POUSO { get; set; }
    public string PERC_ATAERO { get; set; }
    public string ATAERO { get; set; }
    public string VALOR_TOTAL { get; set; }

}

public class Report_Det_Permanencia
{
    public string CLIENTE { get; set; }
    public string ICAO { get; set; }
    public string DATAHORA_OPERACAO { get; set; }
    public string NUM_VOO { get; set; }
    public string TIPOAERONAVE { get; set; }
    public string NATUREZAVOO { get; set; }
    public string ORIGEM { get; set; }
    public string MATRICULA { get; set; }
    public int? ESTADIA { get; set; }//NUMBER(10)          
    public string VALOR_ESTADIA { get; set; }//NUMBER              
    public int? MANOBRA { get; set; }//NUMBER(10)          
    public string VALOR_MANOBRA { get; set; }//NUMBER              
    public string TARIFA_ESTADIA { get; set; }//NUMBER              
    public string TARIFA_MANOBRA { get; set; }//NUMBER              
    public int? PMD { get; set; }//NUMBER              
    public string TOTAL_PERMANENCIA { get; set; }//NUMBER              
    public string PERC_ATAERO { get; set; }//VARCHAR2(10)        
    public string TOTAL_ATAERO { get; set; }//NUMBER              
    public string VALOR_TOTAL { get; set; }//NUMBER              


}

public class Report_Listagem_Contratos
{
    public string CLIENTE { get; set; }
    public string CONTRATO { get; set; }
    public string LUC { get; set; }
    public string DATA_INICIO_CONTRATO { get; set; }
    public string DATA_FIM_CONTRATO { get; set; }
    public string ASSINATURA { get; set; }
    public string VALOR_COBRANCA { get; set; }
    public string DATA_INICIO_VALOR { get; set; }
    public string DATA_FIM_VALOR { get; set; }
}

public class Report_Grupo1
{
    public string NOME_CLIENTE { get; set; }
    public string TIPO_DOCUMENTO { get; set; }
    public string DOCUMENTO { get; set; }
    public string EMAIL { get; set; }
    public string ENDERECO { get; set; }
    public string CEP { get; set; }
    public string INSCR_MUNICIPAL { get; set; }
    public string INSCR_ESTADUAL { get; set; }
    public string IATA { get; set; }
    public string ICAO { get; set; }

}

public class Report_Grupo2
{
    public string NOME_CLIENTE { get; set; }
    public string TIPO_DOCUMENTO { get; set; }
    public string DOCUMENTO { get; set; }
    public string EMAIL { get; set; }
    public string ENDERECO { get; set; }
    public string CEP { get; set; }
    public string INSCR_MUNICIPAL { get; set; }
    public string INSCR_ESTADUAL { get; set; }
    public string MATRICULA { get; set; }
    public string MODELO { get; set; }
    public int? PMD { get; set; }
    public string CATEGORIA { get; set; }
    public string CLASSE { get; set; }
    public string ESTRANGEIRA { get; set; }

}
public class Report_DAT_Analitico
{
    public string CLIENTE { get; set; }
    public string CODIGO_OPERACAO { get; set; }
    public string NUMVOO { get; set; }
    public string STATUS { get; set; }
    public int? PMD { get; set; }
    public string AEROPORTO_ORIGEM { get; set; }
    public string AEROPORTO_POUSO { get; set; }
    public string NATUREZAVOO { get; set; }
    public string MODELO { get; set; }
    public string DATA_OPERACAO_REALIZADO { get; set; }
    public string HORARIO_OPERACAO_REALIZADO { get; set; }
    public string DATA_REGISTRO_SISTEMA { get; set; }
    public string TOTAL_OPERACAO_POUSO { get; set; }
    public string TOTAL_OPERACAO_MANOBRA { get; set; }
    public string TOTAL_OPERACAO_ESTADIA { get; set; }
    public string TOTAL_OPERACAO_PAT { get; set; }
    public string TOTAL_OPERACAO_PAN { get; set; }
    public string FORMA_PGTO { get; set; }
    public string TOTAL_ATAERO { get; set; }
    public string TOTAL_DOLAR { get; set; }
    public string TOTAL_GERAL { get; set; }
    public string NOTES { get; set; }
}

public class Report_Sales
{
    public string CLIENTE { get; set; }
    public string CATEGORIA_DE_PRODUTO { get; set; }
    public string DATA_DA_RECEITA { get; set; }
    public string VALOR_DE_VENDA_INFORMADO { get; set; }
}

public class Report_SISO_Without_RPE
{

    public string EMPRESA_AEREA { get; set; }
    public string NUMERO_VOO { get; set; }
    public string DATA_VOO { get; set; }

}

public class Report_RPE_Without_SISO
{

    public string EMPRESA_AEREA { get; set; }
    public string NUMERO_VOO { get; set; }
    public string DATA_VOO { get; set; }

}


public class Report_EXPORT_ERP_SUMARIZATION_NOME_ITEM
{
    public string DATA_CRIACAO { get; set; }
    public string NOME_ITEM { get; set; }
    public string ID_ATAERO { get; set; }
    public string PK { get; set; }
    public string NUMERO_CONTRATO { get; set; }
    public string LUC { get; set; }
    public int? QUANTIDADE { get; set; }
    public string VALOR { get; set; }
}

public class Report_EXPORT_ERP
{
    public string LOGIN { get; set; }
    public string NOME_CLIENTE { get; set; }
    public string NUMERO_CLIENTE { get; set; }
    public string EMAIL_CLIENTE { get; set; }
    public string TIPO_CONTA { get; set; }
    public string ENQUADRADO_SIMPLES { get; set; }
    public string PARTICIPANTE_FOME_ZERO { get; set; }
    public string NATUREZA_JURIDICA { get; set; }
    public string PREFERENCIA_MOEDA { get; set; }
    public string METODO_PAGAMENTO { get; set; }
    public string PAIS { get; set; }
    public string RUA { get; set; }
    public string BAIRRO { get; set; }
    public string NUMERO { get; set; }
    public string COMPLEMENTO { get; set; }
    public string ESTADO { get; set; }
    public string CIDADE { get; set; }
    public string CEP { get; set; }
    public string CATEGORIA_ATRIBUTO { get; set; }
    public string TIPO_INSCRICAO { get; set; }
    public string CPF { get; set; }
    public string DIGITO_INSCRICAO_CPF { get; set; }
    public string CNPJ { get; set; }
    public string AGENCIA_INSCRICAO { get; set; }
    public string DIGITO_INSCRICAO_CNPJ { get; set; }
    public string INSCRICAO_ESTADUAL { get; set; }
    public string INSCRICAO_MUNICIPAL { get; set; }
    public string CLASSE_CONTRIBUINTE { get; set; }
    public string ORIGEM { get; set; }
    public string NUMERO_CLIENTE_TRANS { get; set; }
    public string CODIGO_MOEDA { get; set; }
    public string CODIGO_NOTA { get; set; }
    public string TERMO_PAGAMENTO { get; set; }
    public int? NUMERO_LINHA { get; set; }
    public string NOME_ITEM { get; set; }
    public int? QUANTIDADE { get; set; }
    public string PRECO_UNITARIO { get; set; }
    public string VALOR_LINHA { get; set; }
    public string STATUS_PAGAMENTO { get; set; }
    public string CODIGO_NOTA_REC { get; set; }
    public string METODO_PAGAMENTO_BAIXA { get; set; }
    public string VALOR_RECEBIDO { get; set; }
    public string DATA_PAGAMENTO { get; set; }
    public string STATUS_INTEGRACAO { get; set; }
    public string DATA_CRIACAO { get; set; }
    public string CRIADO_POR { get; set; }
    public string DATA_ATUALIZACAO { get; set; }
    public string ATUALIZADO_POR { get; set; }
    public string MENSAGEM_ERRO { get; set; }
    //public int? ID_SESS { get; set; }
    public string DATA_EXTRACAO { get; set; }
    //public int? ID_USAGE_INTERVAL { get; set; }
    //public int?  ID_ACC { get; set; }
    public string JUROS { get; set; }
    public string MULTA { get; set; }
    //public string SERV_DEF { get; set; }
    public string DATA_PROC_PAG_METRA { get; set; }
    //public int? RUN_ID { get; set; }
    //public string DATA_CRIACAO_USO { get; set; }
    public string DATA_EMISSAO { get; set; }
    public string ID_ATAERO { get; set; }
    public string PK { get; set; }
    public string NUMERO_CONTRATO { get; set; }
    public string LUC { get; set; }
}

/// <summary>
/// Class to store fields of Tarrifs by Client Report
/// </summary>
public class Report_TarifasPorCliente
{

    public string EMPRESA_AEREA { get; set; }
    public string TIPO_OPERACAO { get; set; }
    public string VALOR_OPERACAO { get; set; }

}

/// <summary>
/// Class to store fields of Passengers Report
/// </summary>
public class Report_Passageiros
{

    public string EMPRESA_AEREA { get; set; }
    public string NUMERO_VOO { get; set; }
    public string TIPO_OPERACAO { get; set; }
    public string DATA_VOO { get; set; }
    public int? QUANTIDADE { get; set; }
    public string ATAERO_ARRECADADO { get; set; }
    public string ADICIONAL_TARIFA_EMBARQUE_INTERNACIONAL { get; set; }
    public string VALOR_TARIFA_OPERACAO { get; set; }
    public string VALOR_TOTAL_OPERACAO { get; set; }

}

/// <summary>
/// Class to store fields of RTE Report
/// </summary>
public class Report_RTE
{
    public string TIPO_OPERACAO { get; set; }
    public string CODIGO_OPERACAO { get; set; }
    public string EMPRESA_AEREA { get; set; }
    public string DATA_OPERACAO { get; set; }
    public int? QUANTIDADE { get; set; }
    public string ADICIONAL_TARIFA_EMBARQUE_INTERNACIONAL { get; set; }
    public string ATAERO_ARRECADADO { get; set; }
    public string VALOR_TARIFA_OPERACAO { get; set; }
    public string VALOR_COBRADO { get; set; }

}

//public class Report_RPE_ANALITICO
//{
//    public string Terminal { get; set; }
//    public string ICAO { get; set; }
//    public string NUMVOO { get; set; }
//    public string DATA_VOO { get; set; }
//    public string HORA_VOO { get; set; }
//    public string MATRICULA { get; set; }
//    public string NATUREZAVOO { get; set; }
//    public string TIPO_VOO { get; set; }
//    public string PARTICIPACAO { get; set; }
//    public int? QTD_EMB_DOM { get; set; }
//    public int? QTD_EMB_INTL { get; set; }
//    public string VALOR_TARIFA_DOM { get; set; }
//    public string VALOR_TARIFA_INTL { get; set; }
//    public string VALOR_EMB_DOM { get; set; }
//    public string VALOR_EMB_INTL { get; set; }
//    public string ATAERO_EMB_DOM { get; set; }
//    public string ATAERO_EMB_INTL { get; set; }
//    public string ADICIONAL_TARIFA { get; set; }
//    public int? QTD_CONEX_DOM { get; set; }
//    public string VALOR_CONEX_DOM { get; set; }
//    public int? QTD_CONEX_INTL { get; set; }
//    public string VALOR_CONEX_INTL { get; set; }
//    public int? TOTAL_PAX_VOO { get; set; }
//    public int? C_TOTAL_DOM_TICKET_PAX { get; set; }
//    public int? C_TOTAL_DOM_TICKET_PAX_PREV { get; set; }
//    public int? C_TOTAL_INTL_TICKET_PAX { get; set; }
//    public int? C_TOTAL_INTL_TICKET_PAX_PREV { get; set; }
//    public int? C_DOM_CONN_CHECKIN_TOTAL { get; set; }
//    public int? C_INTL_CONN_CHECKIN_TOTAL { get; set; }
//    public int? C_TOTAL_DOM_TAR_ADVANCE { get; set; }
//    public int? C_TOTAL_INTL_TAR_ADVANCE { get; set; }
//    public int? ISENTOS { get; set; }
//    public int? TRANSITO_A_BORDO { get; set; }
//    public int? IAC { get; set; }
//    public int? BAGAGEM_EMB_DOM { get; set; }
//    public int? BAGAGEM_EMB_INTL { get; set; }
//    public int? CARGA_EMB_DOM { get; set; }
//    public int? CARGA_EMB_INTL { get; set; }
//    public int? CORREIO_EMB_DOM { get; set; }
//    public int? CORREIO_EMB_INTL { get; set; }
//    public int? NUMVOO_DESEMB { get; set; }
//    public string DATAVOO_DESEMB { get; set; }
//    public string HORAVOO_DESEMB { get; set; }
//    public string MATRICULA_DESEMB { get; set; }
//    public string NATUREZA_VOO_DESEMB { get; set; }
//    public string TIPO_VOO_DESEMB { get; set; }
//    public string PARTICIPACAO_DESEMB { get; set; }
//    public int? PAX_DOM_DESEMB { get; set; }
//    public int? PAX_INTL_DESEMB { get; set; }
//    public int? PAX_DOM_CONEX_DESEMB { get; set; }
//    public int? PAX_INTL_CONEX_DESEMB { get; set; }
//    public int? BAGAGEM_DOM_DESEMB { get; set; }
//    public int? BAGAGEM_INTL_DESEMB { get; set; }
//    public int? BAGAGEM_DOM_CONEX_DESEMB { get; set; }
//    public int? BAGAGEM_INTL_CONEX_DESEMB { get; set; }
//    public int? CARGA_DOM_DESEMB { get; set; }
//    public int? CARGA_INTL_DESEMB { get; set; }
//    public int? CARGA_DOM_CONEX_DESEMB { get; set; }
//    public int? CARGA_INTL_CONEX_DESEMB { get; set; }
//    public int? CORREIO_DOM_DESEMB { get; set; }
//    public int? CORREIO_INTL_DESEMB { get; set; }
//    public int? CORREIO_DOM_CONEX_DESEMB { get; set; }
//    public int? CORREIO_INTL_CONEX_DESEMB { get; set; }
//    public int? BAGAGEM_TRANSITO_DOM_DESEMB { get; set; }
//    public int? BAGAGEM_TRANSITO_INTL_DESEMB { get; set; }
//    public int? CARGA_TRANSITO_DOM_DESEMB { get; set; }
//    public int? CARGA_TRANSITO_INTL_DESEMB { get; set; }
//    public int? CORREIO_TRANSITO_DOM_DESEMB { get; set; }
//    public int? CORREIO_TRANSITO_INTL_DESEMB { get; set; }
//    public string VALOR_TARIFA_CONEX_DOM { get; set; }
//    public string VALOR_TARIFA_CONEX_INTL { get; set; }
//    public string USUARIO { get; set; }
//}

//Embarque e Conexao

public class Report_RPE_ANALITICO_EMB_CONEX
{
    public string Terminal { get; set; }
    public string ICAO { get; set; }
    public string NUMVOO { get; set; }
    public string DATA_VOO { get; set; }
    public string HORA_VOO { get; set; }
    public string MATRICULA { get; set; }
    public string NATUREZAVOO { get; set; }
    public string TIPO_VOO { get; set; }
    public string PARTICIPACAO { get; set; }
    public int? QTD_EMB_DOM { get; set; }
    public int? QTD_EMB_INTL { get; set; }
    public string VALOR_TARIFA_DOM { get; set; }
    public string VALOR_TARIFA_INTL { get; set; }
    public string VALOR_EMB_DOM { get; set; }
    public string VALOR_EMB_INTL { get; set; }
    public string ATAERO_EMB_DOM { get; set; }
    public string ATAERO_EMB_INTL { get; set; }
    public string ADICIONAL_TARIFA { get; set; }
    public int? QTD_CONEX_DOM { get; set; }
    public string VALOR_CONEX_DOM { get; set; }
    public int? QTD_CONEX_INTL { get; set; }
    public string VALOR_CONEX_INTL { get; set; }
    public int? TOTAL_PAX_VOO { get; set; }
    public int? C_TOTAL_DOM_TICKET_PAX { get; set; }
    public int? C_TOTAL_DOM_TICKET_PAX_PREV { get; set; }
    public int? C_TOTAL_INTL_TICKET_PAX { get; set; }
    public int? C_TOTAL_INTL_TICKET_PAX_PREV { get; set; }
    public int? C_DOM_CONN_CHECKIN_TOTAL { get; set; }
    public int? C_INTL_CONN_CHECKIN_TOTAL { get; set; }
    public int? C_TOTAL_DOM_TAR_ADVANCE { get; set; }
    public int? C_TOTAL_INTL_TAR_ADVANCE { get; set; }
    public int? ISENTOS { get; set; }
    public int? TRANSITO_A_BORDO { get; set; }
    public int? IAC { get; set; }
    public int? BAGAGEM_EMB_DOM { get; set; }
    public int? BAGAGEM_EMB_INTL { get; set; }
    public int? CARGA_EMB_DOM { get; set; }
    public int? CARGA_EMB_INTL { get; set; }
    public int? CORREIO_EMB_DOM { get; set; }
    public int? CORREIO_EMB_INTL { get; set; }
    public string DATA_DIGITACAO { get; set; }
    public string USUARIO { get; set; }
}


//Desembarque

public class Report_RPE_ANALITICO_DESEMB
{
    public string ICAO { get; set; }
    public int? NUMVOO_DESEMB { get; set; }
    public string DATAVOO_DESEMB { get; set; }
    public string HORAVOO_DESEMB { get; set; }
    public string MATRICULA_DESEMB { get; set; }
    public string NATUREZA_VOO_DESEMB { get; set; }
    public string TIPO_VOO_DESEMB { get; set; }
    public string PARTICIPACAO_DESEMB { get; set; }
    public int? PAX_DOM_DESEMB { get; set; }
    public int? PAX_INTL_DESEMB { get; set; }
    public int? PAX_DOM_CONEX_DESEMB { get; set; }
    public int? PAX_INTL_CONEX_DESEMB { get; set; }
    public int? BAGAGEM_DOM_DESEMB { get; set; }
    public int? BAGAGEM_INTL_DESEMB { get; set; }
    public int? BAGAGEM_DOM_CONEX_DESEMB { get; set; }
    public int? BAGAGEM_INTL_CONEX_DESEMB { get; set; }
    public int? CARGA_DOM_DESEMB { get; set; }
    public int? CARGA_INTL_DESEMB { get; set; }
    public int? CARGA_DOM_CONEX_DESEMB { get; set; }
    public int? CARGA_INTL_CONEX_DESEMB { get; set; }
    public int? CORREIO_DOM_DESEMB { get; set; }
    public int? CORREIO_INTL_DESEMB { get; set; }
    public int? CORREIO_DOM_CONEX_DESEMB { get; set; }
    public int? CORREIO_INTL_CONEX_DESEMB { get; set; }
    public int? BAGAGEM_TRANSITO_DOM_DESEMB { get; set; }
    public int? BAGAGEM_TRANSITO_INTL_DESEMB { get; set; }
    public int? CARGA_TRANSITO_DOM_DESEMB { get; set; }
    public int? CARGA_TRANSITO_INTL_DESEMB { get; set; }
    public int? CORREIO_TRANSITO_DOM_DESEMB { get; set; }
    public int? CORREIO_TRANSITO_INTL_DESEMB { get; set; }
    public string VALOR_TARIFA_CONEX_DOM { get; set; }
    public string VALOR_TARIFA_CONEX_INTL { get; set; }
    public string DATA_DIGITACAO { get; set; }
    public string USUARIO { get; set; }
}


/// <summary>
/// Class to store fields DAT Report
/// </summary>
public class Report_DAT
{
    public string TIPO_OPERACAO { get; set; }
    public string CODIGO_OPERACAO { get; set; }
    public string EMPRESA_AEREA { get; set; }
    public string OPERADOR_AERONAVE { get; set; }
    public string GRUPO_AERONAVE { get; set; }
    public string MODELO_AERONAVE { get; set; }
    public string CLASSE_AERONAVE { get; set; }
    public string MARCAS_AERONAVE { get; set; } //TODO:
    public string NUMERO_VOO { get; set; }
    public string NATUREZA_VOO { get; set; }
    public string DATA_OPERACAO_REALIZADO { get; set; }
    public string HORARIO_OPERACAO_REALIZADO { get; set; }
    public string AEROPORTO_POUSO { get; set; }//TODO:    
    public string AEROPORTO_ORIGEM { get; set; }
    public int? PMD { get; set; }
    public string VALOR_TARIFA_OPERACAO { get; set; }
    public string VALOR_COBRADO { get; set; }
    public string DATA_REGISTRO_SISTEMA { get; set; }
    public string ATAERO_ARRECADADO { get; set; }

}

public class Report_CE
{

    public string IATA { get; set; }
    public string NUMERO_VOO { get; set; }
    public string DATA_VOO { get; set; }
    public string AEROPORTO_ORIGEM { get; set; }
    public string EMPRESA_AEREA { get; set; }
    public int? TOTAL_PAX_DOM { get; set; }
    public int? TOTAL_PAX_INTL { get; set; }
}

public class Report_Aeroportos
{
    public string ICAO { get; set; }
    public string DESCRICAO { get; set; }
}

public class Lista_Nome_Fantasia
{
    public string NOME_FANTASIA { get; set; }
}

public class Lista_Contrato
{
    public string CONTRATO { get; set; }
}


public class Lista_LUC
{
    public string LUC { get; set; }
}



public class Report_Rateio
{
    public string PK { get; set; }
    public string CNPJ { get; set; }
    public string CONTRATO { get; set; }
    public string LUC { get; set; }
    public string RAZAO_SOCIAL { get; set; }
    public string NOME_FANTASIA { get; set; }
    public string FORMATO { get; set; }
    public string GRUPO { get; set; }
    public string SUB_GRUPO { get; set; }
    public string TIPO_AREA { get; set; }
    public string EDIFICACAO { get; set; }
    public string DESCRICAO_LOCALIZACAO { get; set; }
    public int? AREA { get; set; }
    public string DT_INICIO_CONTRATO { get; set; }
    public string DT_FIM_CONTRATO { get; set; }
}
#endregion

#region "Fill dropdowns"
public class ALL_ICAOs
{
    public string ICAO { get; set; }
}
#endregion 