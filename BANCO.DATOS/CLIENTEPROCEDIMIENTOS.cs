using BANCO.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCO.DATOS
{
    public class CLIENTEPROCEDIMIENTOS
    {
        //CREAR LA LISTA
        public List<CLIENTE> Listar()
        {
            var Listado = new List<CLIENTE>();
            //ESTABLECER LA CONEXIÓN
            using (var Conexion = new SqlConnection(ACCESO.CadenaConexion()))
            {
                Conexion.Open();
                //COMANDO
                using (var Comando = new SqlCommand("SELECT * FROM Cliente", Conexion))
                {
                    using (var Lector = Comando.ExecuteReader())
                    {
                        //CONDICIONAR 
                        if (Lector != null && Lector.HasRows)  
                        {
                            //DAR NOMBRE A LA CLASE 
                            CLIENTE Cliente; 
                            //WHILE 
                            while (Lector.Read()) 
                            {
                                //CREAR OBJETO 
                                Cliente = new CLIENTE();
                                //ASIGNAR LOS LUGARES 
                                Cliente.ID = (int)Lector[0];
                                Cliente.Nombres = (string)Lector[1];
                                Cliente.Apellidos = (string)Lector[2];
                                Cliente.RazonSocial = (string)Lector[3];
                                Cliente.NumeroDocumento = (string)Lector[4];
                                Cliente.IdTipoDocumento = (int)Lector[5];
                                Cliente.IdTipoCliente = (int)Lector[6];
                                Cliente.Direccion = (string)Lector[7];
                                Cliente.Referencia = (string)Lector[8];
                                Cliente.Telefono = (string)Lector[9];
                                Cliente.Email = (string)Lector[10];
                                //AGREGAR A LA LISTA
                                Listado.Add(Cliente);
                            }
                        }
                    }
                }
            }
            return Listado;
        }

        //CREAR MÉTODO INSERTAR con PARÁMETRO CLASE "CLIENTE"
        public int InsertarValores(CLIENTE Cliente)
        {
            int filas = 0;
            //ESTABLECER CONEXIÓN
            using (var Conexion = new SqlConnection(ACCESO.CadenaConexion()))
            {
                Conexion.Open();
                //CREAR LA CONSULTA
                var Query = "EXEC sp_InsertarValores @Nom, @Ape, @Raz, @Num, @IdTDoc," +
                    " @IdTClie, @Direc, @Ref, @Tel, @Email";
                //COMANDO
                using (var Comando = new SqlCommand(Query, Conexion))
                {
                    //AGREGAR LOS PARÁMETROS
                    Comando.Parameters.AddWithValue("@Nom", Cliente.Nombres);
                    Comando.Parameters.AddWithValue("@Ape", Cliente.Apellidos);
                    Comando.Parameters.AddWithValue("@Raz", Cliente.RazonSocial);
                    Comando.Parameters.AddWithValue("@Num", Cliente.NumeroDocumento);
                    Comando.Parameters.AddWithValue("@IdTDoc", Cliente.IdTipoDocumento);
                    Comando.Parameters.AddWithValue("@IdTClie", Cliente.IdTipoCliente);
                    Comando.Parameters.AddWithValue("@Direc", Cliente.Direccion);
                    Comando.Parameters.AddWithValue("@Ref", Cliente.Referencia);
                    Comando.Parameters.AddWithValue("@Tel", Cliente.Telefono);
                    Comando.Parameters.AddWithValue("@Email", Cliente.Email);
                    //AGREGAR EL COMANDO para VER LAS INSERCIONES
                    filas = Comando.ExecuteNonQuery();
                }
            }
            return filas;
        }
    }    
}
