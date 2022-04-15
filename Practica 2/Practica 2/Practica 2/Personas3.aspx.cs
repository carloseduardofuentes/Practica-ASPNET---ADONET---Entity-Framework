using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Datos;

namespace Practica_2
{
    public partial class Personas3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarTabla();
            }
        }

        public void LlenarTabla()
        {
            Datos.clases.persona datos1= new Datos.clases.persona();
            GridView1.DataSource = datos1.VerPersonas(-1, "%%", "%%", "%%");
            GridView1.DataBind();
        }
                

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Datos.clases.persona datos1 = new Datos.clases.persona();
            datos1.EliminarPersona(Convert.ToInt32(txtCodigo.Text));
            LlenarTabla();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            Datos.clases.persona datos1 = new Datos.clases.persona();
            DataTable dt = new DataTable();
            prc_slcPersonaResult oItems = datos1.SeleccionarPersona(codigo, "%%", "%%", "%%");
            txtCodigo.Text = oItems.N_CODIGO_PERSONA.ToString();
            txtNombres.Text = oItems.C_NOMBRES;
            txtCiudad.Text = oItems.C_CIUDAD;
            txtTelefono.Text = oItems.C_TELEFONO;
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            LlenarTabla();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void btnIr_Click(object sender, EventArgs e)
        {
            Response.RedirectPermanent("Personas.aspx?ID=" + txtCodigo.Text);
        }
    }
}