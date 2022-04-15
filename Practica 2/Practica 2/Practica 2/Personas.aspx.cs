using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica_2
{
    public partial class Personas : System.Web.UI.Page
    {
        DataTable dt;

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
            GridView1.AllowPaging = true;            
            GridView1.DataSource = datos.consultarBase("select * from tpersona order by n_codigo_persona");
            GridView1.DataBind();
            
        }

        public void LlenarPais()
        {
            clases.Conexion datos = new clases.Conexion();            
            cmbPais.DataSource=datos.consultarBase("select * from tpais");
            cmbPais.DataValueField="n_codigo_pais";
            cmbPais.DataTextField="c_pais";
            cmbPais.DataBind();
        }

        public void LlenarPuerto()
        {
            clases.Conexion datos = new clases.Conexion();            
            cmbPuerto.DataSource=datos.consultarBase("select * from tpuerto");
            cmbPuerto.DataValueField = "n_codigo_puerto";
            cmbPuerto.DataTextField = "c_puerto";
            cmbPuerto.DataBind();
        }

        public void LlenarTipo()
        {
            clases.Conexion datos = new clases.Conexion();
            cmbTipo.DataSource = datos.consultarBase("select * from ttipo_persona");
            cmbTipo.DataValueField = "n_codigo_tipo";
            cmbTipo.DataTextField = "c_tipo";
            cmbTipo.DataBind();
        }


        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            LlenarTabla();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
         
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDatos();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        public void LlenarDatos()
        {
            int codigo_persona = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            clases.Conexion datos = new clases.Conexion();
            dt = new DataTable();
            dt = datos.consultarBase("select * from tpersona where n_codigo_persona=" + codigo_persona);
            txtCodigo.Text = dt.Rows[0][0].ToString();
            txtNombres.Text = dt.Rows[0][1].ToString();
            cmbPais.SelectedValue = dt.Rows[0][2].ToString();
            cmbPuerto.SelectedValue = dt.Rows[0][3].ToString();
            cmbTipo.SelectedValue = dt.Rows[0][4].ToString();
            txtCiudad.Text = dt.Rows[0][8].ToString();
            txtTelefono.Text = dt.Rows[0][10].ToString();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            clases.Conexion datos = new clases.Conexion();
            datos.ejecutarSql("insert into tpersona (c_nombres, n_codigo_pais, n_codigo_puerto, n_codigo_tipo, c_ciudad, c_telefono) values ('" + txtNombres.Text + "'," + cmbPais.SelectedValue + "," + cmbPuerto.SelectedValue + "," + cmbTipo.SelectedValue + ",'" + txtCiudad.Text + "','" + txtTelefono.Text + "')");
            LlenarTabla();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            clases.Conexion datos = new clases.Conexion();
            datos.ejecutarSql("update tpersona set c_nombres='" + txtNombres.Text + "', n_codigo_pais=" + cmbPais.SelectedValue + ", n_codigo_puerto=" + cmbPuerto.SelectedValue + ", n_codigo_tipo=" + cmbTipo.SelectedValue + ", c_ciudad='" + txtCiudad.Text + "', c_telefono='" + txtTelefono.Text + "' where n_codigo_persona=" + txtCodigo.Text);
            LlenarTabla();
        }
               

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            clases.Conexion datos = new clases.Conexion();
            datos.ejecutarSql("delete from tpersona where n_codigo_persona=" + txtCodigo.Text);
            LlenarTabla();
        }
                
    }
}