using BANCO.ENTIDADES;
using BANCO.NEGOCIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANCO.PRESENTACIÓN
{
    public partial class FRMCLIENTEMOSTRAR : Form
    {
        public FRMCLIENTEMOSTRAR()
        {
            InitializeComponent();
        }

        private void CargarFormulario(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            //LIMPIAR DATA GRIED VIEW 
            DGVDatos.Rows.Clear();
            //CREAR OBJETO LISTADO 
            var Listado = CLIENTENEGOCIO.Listar();
            //USAR FOREACH
            foreach ( var Cliente in Listado ) 
            {
                //AGREGAR DATOS AL DATAGV
                //ESPECIFICAR CUALES SON LOS DATOS A AGREGAR 
                DGVDatos.Rows.Add(Cliente.ID, Cliente.RazonSocial, Cliente.Telefono, Cliente.Email);
            }
        }

        private void NuevoRegistro(object sender, EventArgs e)
        {
            var FRM = new FRMPROCEDIMIENTOS();
            //INSERTAR NUEVO CLIENTE POR ESO LLAMAR A LA CLASE CLIENTE
            var NuevoCliente = new CLIENTE();
            //CONDICIONAR EL SHOW 
            if (FRM.ShowDialog() == DialogResult.OK) 
            {
                var Resultado = CLIENTENEGOCIO.Insertar(NuevoCliente);
            }
        }
    }
}
