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

        private List<liteven> listaItems = new List<liteven>();


        private bool lectorCBHabilitado = false;
        public aproduc producto = new aproduc();

        private bool productoOk = false;

        private double total = 0;

        #endregion

        #region Constructor
        public FRMVenta_Registrar()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
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
                producto.capdcodbar = LBLCodigoDeBarras.Text;
                if (producto.ObtenerDatosCodigo(false, producto.capdcodbar))
                {
                    AgregarProducto(producto);
                    // lectorCBHabilitado = true;
                    LBLCodigoDeBarras.Text = "LECTOR ACTIVO";
                    LBLCodigoDeBarras.BackColor = Color.PaleGreen;

                }
                else
                {
                    MessageBox.Show("Producto no encontrado");
                    LBLCodigoDeBarras.Text = "LECTOR ACTIVO";
                    LBLCodigoDeBarras.BackColor = Color.PaleGreen;


                }




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
        private void BTNBuscarProducto_Click(object sender, EventArgs e)
        {
            FRMProducto_Buscar a = new FRMProducto_Buscar();
            a.ShowDialog();
            if (a.seleccionadoOk)
            {
                this.producto = a.producto;
                this.productoOk = true;
                AgregarProducto(producto);

            }
            else
            {
                this.productoOk = false;

            }

        }

        private void FRMVenta_Registrar_Load(object sender, EventArgs e)
        {
            LBLTotalNumero.Text = "0";
            lectorCBHabilitado = false;
            LBLCodigoDeBarras.Text = "LECTOR INACTIVO";
            LBLCodigoDeBarras.BackColor = Color.LightSalmon;
        }

        private void BTNCodigoDeBarras_Leave(object sender, EventArgs e)
        {
            lectorCBHabilitado = false;
            LBLCodigoDeBarras.Text = "LECTOR INACTIVO";
            LBLCodigoDeBarras.BackColor = Color.LightSalmon;
        }

        #endregion

        #region Metodos
        private void AgregarProducto(aproduc pro)
        {
            liteven item = new liteven();

            item = listaItems.Find(x => x.faivcodpro == pro.papdcodpro);

            if (item != null)
            {
                item.caivcanite += 1;
                item.caivsubtot = item.caivcanite * item.caivpreuni;
            }
            else

            {
                item = new liteven();
                item.faivcodpro = pro.papdcodpro;
                item.capdmodpro = pro.capdmodpro;
                item.capdcodbar = pro.capdcodbar;
                item.capdnompro = pro.capdnompro;
                item.capdtalpro = pro.capdtalpro;
                item.capddespro = pro.capddespro;
                item.caivcanite = 1;
                item.caivpreuni = pro.capdpreven;
                item.caivsubtot = item.caivcanite * item.caivpreuni;
                item.caivestite = true;
                listaItems.Add(item);

            }

            ActualizarGridItems();
        }
        private void ActualizarGridItems()
        {
            DTGLista.Rows.Clear();
            foreach (liteven item in listaItems)
            {
                DTGLista.Rows.Add();
                DTGLista[0, DTGLista.RowCount - 1].Value = item.faivcodpro;
                DTGLista[1, DTGLista.RowCount - 1].Value = item.capdmodpro;
                DTGLista[2, DTGLista.RowCount - 1].Value = item.capdcodbar;
                DTGLista[3, DTGLista.RowCount - 1].Value = item.capdnompro;
                DTGLista[4, DTGLista.RowCount - 1].Value = item.capdtalpro;
                DTGLista[5, DTGLista.RowCount - 1].Value = item.capddespro;
                DTGLista[6, DTGLista.RowCount - 1].Value = item.caivcanite;
                DTGLista[7, DTGLista.RowCount - 1].Value = item.caivpreuni;
                DTGLista[8, DTGLista.RowCount - 1].Value = item.caivsubtot;

            }
            CalcularTotal();
            
        }

        #endregion

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro que desea borrar este producto?",
                            "Pregunta",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                EliminarItem(DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString());
    
                }
                
            }
           
        }
        private void CalcularTotal()
        {
            total = 0;
           
            foreach (liteven item in listaItems)
            {
           
               
                total += double.Parse(item.caivsubtot.ToString());

            }
            LBLTotalNumero.Text = total.ToString("F2");
            string numeroEnLetras = MetodosGenerales.ConvertirNumeroALetras(total);
            LBLTotalALiteral.Text ="SON: "+ numeroEnLetras;
        }
        private void EliminarItem(string CodPro)
        {
            listaItems.RemoveAll(x => x.faivcodpro == CodPro);
            ActualizarGridItems(); 
           
        }

       

    }
}
