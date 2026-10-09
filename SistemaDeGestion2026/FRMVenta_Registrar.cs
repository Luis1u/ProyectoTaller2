using CapaRN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeGestion2026
{
    public partial class FRMVenta_Registrar : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private aclient cliente = new aclient();
        private bool clienteOk = false;


        private bool lectorCBHabilitado = false;
        public aproduc producto = new aproduc();

        #endregion
        public FRMVenta_Registrar()
        {
            InitializeComponent();
        }

        private void FRMVenta_Registrar_Load(object sender, EventArgs e)
        {

        }

        private void TXTNitCliente_Leave(object sender, EventArgs e)
        {
            cliente.cacenitcli = TXTNitCliente.Text;
            if (cliente.ObtenerDatosNIT())
            {
                TXTNombreCliente.Text = cliente.cacerazsoc;
                clienteOk = true;

            }
            else
            {
                TXTNombreCliente.Text = "Nombre del cliente";
                clienteOk = false;
            }
        }

        private void BTNBuscarCliente_Click(object sender, EventArgs e)
        {
            FRMCliente_Buscar a = new FRMCliente_Buscar();
            a.ShowDialog();
            if (a.seleccionadoOk)
            {
                this.cliente = a.cliente;
                this.clienteOk = true;
                TXTNitCliente.Text = cliente.cacenitcli;
                TXTNombreCliente.Text = cliente.cacerazsoc;
            }
            else
            {
                this.clienteOk = false;
                TXTNitCliente.Text = "";
                TXTNombreCliente.Text = "Nombre del cliente";
            }
        }

        private void TXTNitCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTNCodigoDeBarras_Click(object sender, EventArgs e)
        {
            if (!lectorCBHabilitado)
            {
                lectorCBHabilitado = true;
                LBLCodigoDeBarras.Text = "LECTOR ACTIVO";
                LBLCodigoDeBarras.BackColor = Color.PaleGreen;
            }
            else
            {
                if (LBLCodigoDeBarras.Text == "LECTOR ACTIVO")
                {
                    LBLCodigoDeBarras.Text = "SIN CÓDIGO";
                    LBLCodigoDeBarras.BackColor = Color.Salmon;
                }
                else
                {
                    producto.capdcodbar = LBLCodigoDeBarras.Text;
                    if(producto.ObtenerDatosCodigo(false, producto.capdcodbar))
                    {
                        MessageBox.Show("Producto encontrado "+producto.capddespro);

                    }
                    
                }
                lectorCBHabilitado = false;
               
            }
        }

        private void BTNCodigoDeBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (LBLCodigoDeBarras.Text == "LECTOR ACTIVO")
            {
                LBLCodigoDeBarras.Text = "" + e.KeyChar;
            }
            else
            {
                LBLCodigoDeBarras.Text += e.KeyChar;
            }
        }
    }
}
