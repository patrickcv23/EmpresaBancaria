using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BANCO.DATOS
{
    public static class ACCESO
    {
        public static string CadenaConexion()
        {
            string CadenaConexion = "Server = DESKTOP-GB7LT06; DataBase = BancoBD; User = AppDATA; Password = ProyectosSQL";
            return CadenaConexion;
        }
    }
}
