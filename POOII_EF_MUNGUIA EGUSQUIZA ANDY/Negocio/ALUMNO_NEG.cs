using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;
using Newtonsoft.Json;

namespace Negocio
{
    public class ALUMNO_NEG
    {
        ALUMNO_DAO dao = new ALUMNO_DAO();

        public List<ALUMNO> ListarAlumnos()
        {

            return dao.ListarAlumnos();
        }

        public string GrabarALUMNO(ALUMNO obj)
        {
            return dao.GrabarALUMNO(obj);
        }

        public string ActualizarALUMNO(ALUMNO obj)
        {
            return dao.ActualizarALUMNO(obj);
        }
    }
}
