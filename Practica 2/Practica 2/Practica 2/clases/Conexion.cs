using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Practica_2.clases
{
    public class Conexion
    {
        string connectionstring = "Data Source=HP-PC\\SQLEXPRESS;Initial Catalog=cargo;Integrated Security=true";
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public bool conectarBase()
        {
            try
            {
                conn = new SqlConnection(connectionstring);
                conn.Open();
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable consultarBase(string sql)
        {
            try
            {
                if (conectarBase())
                {
                    cmd = new SqlCommand(sql, conn);
                    da = new SqlDataAdapter();
                    dt = new DataTable();
                    da.SelectCommand = cmd;
                    da.Fill(dt);                    
                    return dt;
                }
                else
                {
                    return null;
                }
                                
            }

            catch (Exception ex)
            {
                return null;
            }
            
        }

        public bool ejecutarSql(string sql)
        {
            try
            {
                if (conectarBase())
                {
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }            
        }

        public DataTable Ver_personas(int codigo_persona, string nombres, string contacto, string pais)
        {
            try
            {
                if (conectarBase())
                {                    
                    cmd = new SqlCommand("prc_slcpersona", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_codigo_persona", codigo_persona);
                    cmd.Parameters.AddWithValue("p_nombres", nombres);
                    cmd.Parameters.AddWithValue("p_contacto", contacto);
                    cmd.Parameters.AddWithValue("p_pais", pais);
                    da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                else
                    return null;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public int Ingresar_persona(string nombres, int codigo_pais, int codigo_puerto, int codigo_tipo, string marca, string contacto, string estado, string ciudad, string direccion, string telefono, string fax, string email, string direccion2, string telefono2, string fax2, string email2, string zip, int creado_por)
        {
            try
            {
                if (conectarBase())
                {                    
                    cmd = new SqlCommand("prc_inspersona", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_nombres", nombres);
                    cmd.Parameters.AddWithValue("p_codigo_pais", codigo_pais);
                    cmd.Parameters.AddWithValue("p_codigo_puerto", codigo_puerto);
                    cmd.Parameters.AddWithValue("p_codigo_tipo", codigo_tipo);
                    cmd.Parameters.AddWithValue("p_marca", marca);
                    cmd.Parameters.AddWithValue("p_contacto", contacto);
                    cmd.Parameters.AddWithValue("p_estado", estado);
                    cmd.Parameters.AddWithValue("p_ciudad", ciudad);
                    cmd.Parameters.AddWithValue("p_direccion", direccion);
                    cmd.Parameters.AddWithValue("p_telefono", telefono);
                    cmd.Parameters.AddWithValue("p_fax", fax);
                    cmd.Parameters.AddWithValue("p_email", email);
                    cmd.Parameters.AddWithValue("p_direccion2", direccion2);
                    cmd.Parameters.AddWithValue("p_telefono2", telefono2);
                    cmd.Parameters.AddWithValue("p_fax2", fax2);
                    cmd.Parameters.AddWithValue("p_email2", email2);
                    cmd.Parameters.AddWithValue("p_zip", zip);
                    cmd.Parameters.AddWithValue("p_creado_por", creado_por);
                    return cmd.ExecuteNonQuery();
                }

                else
                {
                    return 0;
                }
            }

            catch (Exception ex)
            {
                return 0;
            }
        }

        public int EliminarPersona(int codigo_persona)
        {
            try
            {
                if (conectarBase())
                {
                    cmd = new SqlCommand("prc_delpersona", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_codigo_persona", codigo_persona);
                    return cmd.ExecuteNonQuery();
                }

                else
                {
                    return 0;
                }
            }

            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataTable VerPaises(int codigo_pais, string pais)
        {
            try
            {
                if (conectarBase())
                {
                    da = new SqlDataAdapter();
                    dt = new DataTable();
                    cmd = new SqlCommand("prc_slcpais", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_codigo_pais", codigo_pais);
                    cmd.Parameters.AddWithValue("p_pais", pais);
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    return dt;
                }
                else
                    return null;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable VerPuertos(int codigo_puerto, int codigo_pais, string puerto)
        {
            try
            {
                if (conectarBase())
                {
                    da = new SqlDataAdapter();
                    dt = new DataTable();
                    cmd = new SqlCommand("prc_slcpuerto", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_codigo_puerto", codigo_puerto);
                    cmd.Parameters.AddWithValue("p_codigo_pais", codigo_pais);
                    cmd.Parameters.AddWithValue("p_puerto", puerto);
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    return dt;
                }
                else
                    return null;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable VerTipos(int codigo_tipo)
        {
            try
            {
                if (conectarBase())
                {
                    da = new SqlDataAdapter();
                    dt = new DataTable();
                    cmd = new SqlCommand("prc_slctipo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_codigo_tipo", codigo_tipo);
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    return dt;
                }
                else
                    return null;
            }

            catch(Exception ex)
            {
                return null;
            }
        }
    }    

}