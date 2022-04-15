using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Practica_2
{
    public partial class Personas2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarTabla();
                LlenarPais();
                LlenarPuerto();
                LlenarTipo();
            }
        }

        public void LlenarTabla()
        {
            clases.Conexion datos = new clases.Conexion();
            GridView1.DataSource = datos.Ver_personas(-1, "%%", "%%", "%%");
            GridView1.DataBind();
            GridView1.AllowPaging = true;
        }

        public void LlenarPais()
        {
            clases.Conexion datos = new clases.Conexion();
            cmbPais.DataSource = datos.VerPaises(-1, "%%");
            cmbPais.DataValueField = "n_codigo_pais";
            cmbPais.DataTextField = "c_pais";
            cmbPais.DataBind();
        }

        public void LlenarPuerto()
        {
            clases.Conexion datos = new clases.Conexion();
            cmbPuerto.DataSource = datos.VerPuertos(-1, -1,"%%");
            cmbPuerto.DataValueField = "n_codigo_puerto";
            cmbPuerto.DataTextField = "c_puerto";
            cmbPuerto.DataBind();
        }

        public void LlenarTipo()
        {
            clases.Conexion datos=new clases.Conexion();
            cmbTipo.DataSource=datos.VerTipos(-1);
            cmbTipo.DataTextField="c_tipo";
            cmbTipo.DataValueField="n_codigo_tipo";
            cmbTipo.DataBind();
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);

            clases.Conexion datos=new clases.Conexion();
            DataTable dt = new DataTable();
            dt=datos.Ver_personas(codigo, "%%", "%%", "%%");
            txtCodigo.Text = dt.Rows[0][0].ToString();
            txtNombres.Text = dt.Rows[0][1].ToString();
            cmbPais.SelectedValue = dt.Rows[0][2].ToString();
            cmbPuerto.SelectedValue = dt.Rows[0][4].ToString();
            cmbTipo.SelectedValue = dt.Rows[0][6].ToString();
            txtCiudad.Text = dt.Rows[0][11].ToString();
            txtTelefono.Text = dt.Rows[0][13].ToString();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            clases.Conexion datos = new clases.Conexion();
            datos.Ingresar_persona(txtNombres.Text, Convert.ToInt32(cmbPais.SelectedValue), Convert.ToInt32(cmbPuerto.SelectedValue), Convert.ToInt32(cmbTipo.SelectedValue), "", "", "", txtCiudad.Text, "", txtTelefono.Text, "", "", "", "", "", "", "", 0);
            LlenarTabla();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            clases.Conexion datos = new clases.Conexion();
            datos.EliminarPersona(Convert.ToInt32(txtCodigo.Text));
            LlenarTabla();
        }
    }
}