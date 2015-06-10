using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MENU_ADMINISTRACAO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnListar_Click(object sender, EventArgs e)
    {
        string dllSelected = ddlListar.SelectedValue;
        switch (dllSelected)
        {
            case "aer":
                Response.Redirect("LISTAR_AEROPORTOS.aspx?Codigo=");
                break;
            case "age":
                Response.Redirect("LISTAR_AGENCIAS.aspx?Codigo=");
                break;
            case "dep":
                Response.Redirect("LISTAR_DEPOIMENTOS.aspx");
                break;
            case "for":
                Response.Redirect("LISTAR_FORMAS_PAGAMENTO.aspx");
                break;
            case "hot":
                Response.Redirect("LISTAR_HOTEIS.aspx");
                break;
            case "pre":
                Response.Redirect("LISTAR_PRESTADORES.aspx");
                break;
            case "sea":
                Response.Redirect("LISTAR_SERV_ADC.aspx");
                break;
            case "inc":
                Response.Redirect("LISTAR_INCOMING.aspx");
                break;
            case "sei":
                Response.Redirect("LISTAR_SERV_INCLUSOS.aspx");
                break;
            case "sta":
                Response.Redirect("LISTAR_STATUS.aspx");
                break;
            case "usu":
                Response.Redirect("LISTAR_AEROPORTOS.aspx");
                break;
            case "ven":
                Response.Redirect("LISTAR_VENDEDORES.aspx");
                break;
            case "voo":
                Response.Redirect("LISTAR_VOOS.aspx");
                break;

            default:
                break;
        }
    }
    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        string dllSelected = ddlCadastrar.SelectedValue;
        switch (dllSelected)
        {
            case "aer":
                Response.Redirect("CADASTRAR_AEROPORTO.aspx");
                break;
            case "age":
                Response.Redirect("CADASTRAR_AGENCIA.aspx");
                break;
            case "dep":
                Response.Redirect("CADASTRAR_DEPOIMENTO.aspx");
                break;
            case "for":
                Response.Redirect("CADASTRAR_FORMA_PAGAMENTO.aspx");
                break;
            case "hot":
                Response.Redirect("CADASTRAR_HOTEL.aspx");
                break;
            case "pre":
                Response.Redirect("CADASTRAR_PRESTADOR.aspx");
                break;
            case "sea":
                Response.Redirect("CADASTRAR_SERV_ADC.aspx");
                break;
            case "inc":
                Response.Redirect("CADASTRAR_INCOMING.aspx");
                break;
            case "sei":
                Response.Redirect("CADASTRAR_SERV_INCLUSO.aspx");
                break;
            case "sta":
                Response.Redirect("CADASTRAR_STATUS.aspx");
                break;
            case "usu":
                Response.Redirect("CADASTRAR_AEROPORTO.aspx");
                break;
            case "ven":
                Response.Redirect("CADASTRAR_VENDEDOR.aspx");
                break;
            case "voo":
                Response.Redirect("CADASTRAR_VOO.aspx");
                break;

            default:
                break;
        }
    }
    protected void btnLocalizar_Click(object sender, EventArgs e)
    {
        string Busca = "?Codigo=" + txtLocalizar.Text.ToUpper().ToString();

        if (txtLocalizar.Text.ToUpper().ToString() == "?Codigo=")
        {
            Busca = "";
        }

        string dllSelected = ddlListar.SelectedValue;
        switch (dllSelected)
        {
            case "aer":
                Response.Redirect("LISTAR_AEROPORTOS.aspx" + Busca);
                break;
            case "age":
                Response.Redirect("LISTAR_AGENCIAS.aspx" + Busca);
                break;
            case "dep":
                Response.Redirect("LISTAR_DEPOIMENTOS.aspx" + Busca);
                break;
            case "for":
                Response.Redirect("LISTAR_FORMAS_PAGAMENTO.aspx" + Busca);
                break;
            case "hot":
                Response.Redirect("LISTAR_HOTEIS.aspx" + Busca);
                break;
            case "pre":
                Response.Redirect("LISTAR_PRESTADORES.aspx" + Busca);
                break;
            case "sea":
                Response.Redirect("LISTAR_SERV_ADC.aspx" + Busca);
                break;
            case "inc":
                Response.Redirect("LISTAR_INCOMING.aspx" + Busca);
                break;
            case "sei":
                Response.Redirect("LISTAR_SERV_INCLUSOS.aspx");
                break;
            case "sta":
                Response.Redirect("LISTAR_STATUS.aspx");
                break;
            case "usu":
                Response.Redirect("LISTAR_AEROPORTOS.aspx");
                break;
            case "ven":
                Response.Redirect("LISTAR_VENDEDORES.aspx");
                break;
            case "voo":
                Response.Redirect("LISTAR_VOOS.aspx");
                break;

            default:
                break;
        }

    }
}