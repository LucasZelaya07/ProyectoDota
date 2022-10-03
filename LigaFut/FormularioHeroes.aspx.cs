using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace LigaFut
{
    public partial class FormularioHeroes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    HeroeNegocio bussiness = new HeroeNegocio();
                    List<Elemento> lista = negocio.listar();
                    List<Dominio.Heroes> list = bussiness.listarHeroe();

                    ddlTipo.DataSource = lista;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    ddlDebilidad.DataSource = list;
                    ddlDebilidad.DataValueField = "Nombre";
                    ddlDebilidad.DataTextField = "Nombre";
                    ddlDebilidad.DataBind();

                    ddlVentaja.DataSource = list;
                    ddlVentaja.DataValueField = "Nombre";
                    ddlVentaja.DataTextField = "Nombre";
                    ddlVentaja.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Hubo un error", ex);
                throw;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Dominio.Heroes nuevo = new Dominio.Heroes();
                HeroeNegocio negocio = new HeroeNegocio();

                nuevo.Numero = int.Parse(txtId.Text);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtImagenUrl.Text;
                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevo.Ventaja = new Elemento();
                nuevo.Ventaja.Id = int.Parse(ddlVentaja.SelectedValue);
                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id= int.Parse(ddlDebilidad.SelectedValue);

                negocio.AgregarconSP(nuevo);
                Response.Redirect("HeroesDota.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Hubo un error", ex);
                throw;
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgHeroe.ImageUrl = txtImagenUrl.Text;
        }
    }
}