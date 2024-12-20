using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string Get()
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["CMartinezProgramacionNCapas"].ToString();
            return cadenaConexion;
        }

        public static string GetConnectionString()
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings["CMartinezProgramacionNCapas"].ToString();
            return cadenaConexion;
        }
    }
}
