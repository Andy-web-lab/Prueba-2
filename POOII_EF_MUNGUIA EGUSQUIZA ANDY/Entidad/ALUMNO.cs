using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class ALUMNO
    {
        public string CodAlumno { get; set; }

       
        public string NomAlumno { get; set; }

      
        public string EmailAlumno { get; set; } = "Sin Email";

       
        public string CodEsp { get; set; }

       
        public string CodCol { get; set; }

        
        public string Eliminado { get; set; } = "No";


    }
}
