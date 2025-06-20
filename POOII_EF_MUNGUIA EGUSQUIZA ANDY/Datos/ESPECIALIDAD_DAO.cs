using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Newtonsoft.Json;

namespace Datos
{
    public class ESPECIALIDAD_DAO
    {
        public List<ESPECIALIDAD> ListarEspecialidad()
        {
            var lista = new List<ESPECIALIDAD>();

            DataTable dt =
                DBHelper.RetornaDataTable("ListarEspecialidades");

            // serializar el datatable a json
            string cad = JsonConvert.SerializeObject(dt);
            // deserializar la cadena json a un objeto
            lista =
                JsonConvert.DeserializeObject<List<ESPECIALIDAD>>(cad);

            return lista;
        }
    }
}
