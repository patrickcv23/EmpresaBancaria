using BANCO.ENTIDADES;
using BANCO.DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANCO.NEGOCIO
{
    public static class CLIENTENEGOCIO
    {
        //CREAR MÉTODO PARA LO QUE SE REQUIERA (EN ESTE CASO LISTA)
        public static List<CLIENTE> Listar()
        {
            //CREAR OBJETO PARA CLIENTEDB PARA LLAMAR A LA LISTA
            var ClienteProc = new CLIENTEPROCEDIMIENTOS();
            //LLAMAR A LA CLASE PROC Y AL MÉTODO 
            return ClienteProc.Listar();
        }

        //LLAMAR A LA CLASE CLIENTE YA QUE LO QUE SE INGRESA SON DATOS CLIENTE
        public static bool Insertar(CLIENTE Cliente)
        {
            //CREAR OBJETO 
            var ClienteProc = new CLIENTEPROCEDIMIENTOS();
            //LLAMAR A LA CLASE PROC Y AL MÉTODO 
            return ClienteProc.InsertarValores(Cliente) > 0;
        }

    }
}
