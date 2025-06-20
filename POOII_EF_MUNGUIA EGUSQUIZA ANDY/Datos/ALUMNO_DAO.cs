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
    public class ALUMNO_DAO
    {
        public List<ALUMNO> ListarAlumnos()
        {
            var lista = new List<ALUMNO>();

            DataTable dt =
                DBHelper.RetornaDataTable("ListarAlumnos");

            // serializar el datatable a json
            string cad = JsonConvert.SerializeObject(dt);
            // deserializar la cadena json a un objeto
            lista =
                JsonConvert.DeserializeObject<List<ALUMNO>>(cad);

            return lista;
        }

        public string GrabarALUMNO(ALUMNO obj)
        {
            try
            {
                DBHelper.EjecutarSP("RegistrarAlumno",
                    obj.CodAlumno, obj.NomAlumno, obj.EmailAlumno,
                    obj.CodEsp, obj.CodCol);
                //
                return $"Se registró al Alumno con el codigo: {obj.CodAlumno}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ActualizarALUMNO(ALUMNO obj)
        {
            try
            {
                DBHelper.EjecutarSP("ActualizarAlumno",
                    obj.CodAlumno, obj.NomAlumno, obj.EmailAlumno,
                    obj.CodEsp, obj.CodCol);
                //
                return $"Se Actualizó al Alumno con el codigo: {obj.CodAlumno}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
