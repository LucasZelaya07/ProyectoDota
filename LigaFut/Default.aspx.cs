using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace LigaFut
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Dominio.Heroes> ListaHeroes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            HeroeNegocio heroe = new HeroeNegocio();
            ListaHeroes = heroe.listarConSP();
            if(!IsPostBack)
            {
                repRepetidor.DataSource = ListaHeroes;
                repRepetidor.DataBind();
            }
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}