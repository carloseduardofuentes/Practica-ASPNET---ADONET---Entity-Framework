using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Datos.clases
{    
    public class persona
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        public List<prc_slcPersonaResult> VerPersonas(int codigo_persona, string nombres, string contacto, string pais)
        {
            try
            {
                return dc.prc_slcPersona(codigo_persona, nombres, contacto, pais).ToList();
            }

            catch(Exception ex)
            {
                return null;
            }
        }

        public prc_slcPersonaResult SeleccionarPersona(int codigo_persona, string nombres, string contacto, string pais)
        {
            try
            {
                return dc.prc_slcPersona(codigo_persona, nombres, contacto, pais).SingleOrDefault();
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public int EliminarPersona(int codigo_persona)
        {
            try
            {
                return dc.prc_delPersona(codigo_persona);
            }

            catch (Exception ex)
            {
                return 0;
            }
        }
   
    }
}
