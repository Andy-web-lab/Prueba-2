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
    public class ESPECIALIDAD_NEG
    {
        ESPECIALIDAD_DAO dao = new ESPECIALIDAD_DAO();

        public List<ESPECIALIDAD> ListarEspecialidad()
        {
           

            return dao.ListarEspecialidad();
        }
    }
}
