using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace LigaFut
{
    public partial class Heroes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HeroeNegocio heroe = new HeroeNegocio();
            dgvHeroes.DataSource = heroe.listarConSP();
            dgvHeroes.DataBind();
        }

        protected void dgvHeroes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvHeroes.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioHeroes.aspx?Id=" + id, false);
        }

        protected void dgvHeroes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvHeroes.PageIndex = e.NewPageIndex;
            dgvHeroes.DataBind();
        }
    }
}