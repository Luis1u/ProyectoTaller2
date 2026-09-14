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
    public partial class FRMCategoria_Registrar : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private acatpro categoria = new acatpro();
        private xnumcor correlativo = new xnumcor();
        public bool modificar = false;
        public String codCatMod = "";
        public bool actualizar = false;
        #endregion

        #region Constructor
        public FRMCategoria_Registrar()
        {
            InitializeComponent();
        }
        #endregion
        private void JalarDatos()
        {
            categoria.pacpcodcat = this.codCatMod;
            categoria.ObtenerDatos();
            SWBEstado.Value = categoria.cacpestcat;
            TXTNombre.Text = categoria.cacpnomcat;
        }


        private void FRMCategoria_Registrar_Load(object sender, EventArgs e)
        {
            if (this.modificar)
            {
                JalarDatos();
                BTNGrabar.Text = "&Modificar";
                this.Text = "Modificar Categoria";
                GPPanelPrincipal.Text = "Modificar Categoria";
                TXTNombre.Focus();
            }
            else
            {
                LimpiarCasillas();
                BTNGrabar.Text = "&Guardar";
                this.Text = "Registrar Categoria";
                GPPanelPrincipal.Text = "Registrar Categoria";
                TXTNombre.Focus();
            }
        }
        private void LimpiarCasillas()
        {
            TXTNombre.Text = "";
            SWBEstado.Value = true;
        }

        private void BTNGrabar_Click(object sender, EventArgs e)
        {
            if (VerificarIntegridad())
            {
                categoria = new acatpro();

                if (!this.modificar)
                {
                    //Generar el correlativo
                    correlativo.pxnctipcor = "acatpro";
                    if (correlativo.ObtenerSiguiente())
                    {
                        categoria.pacpcodcat= correlativo.pxnctipcor + "-" +
                                             correlativo.cxncnumcor.ToString("D12");
                    }
                }
                else
                {
                    categoria.pacpcodcat = this.codCatMod;
                }
                categoria.cacpnomcat = TXTNombre.Text;
                categoria.cacpestcat = SWBEstado.Value;
               

                if (!this.modificar)
                {
                    if (categoria.Grabar())
                    {
                        MessageBox.Show("Categoria guardada correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMCategoria_Registrar_FormClosing;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Categoria no se pudo guardar!!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (categoria.Modificar())
                    {
                        MessageBox.Show("Categoria modificada correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMCategoria_Registrar_FormClosing;
                     
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Categoria no se pudo modificar!!",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private bool VerificarIntegridad()
        {
            bool respuesta = true;

            acatpro categoria2 = new acatpro();
            categoria2.cacpnomcat = TXTNombre.Text;

            if (TXTNombre.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el nombre de la categoria", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNombre.Focus();
                respuesta = false;
            }
            else if (categoria2.ObtenerDatosNombre(modificar, categoria.cacpnomcat))
            {
                MessageBox.Show("Ya existe una categoria con este nombre", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNombre.Focus();
                respuesta = false;
            }
            


            return respuesta;
        }

        private void FRMCategoria_Registrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar el formulario?",
                               "Pregunta",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }

      

        private void TXTNombre_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;

            if ((e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z) && (!e.Alt))
                teclaValida = true;
            else if ((e.KeyCode == Keys.Space) ||
                (e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right) ||
                ((e.KeyCode == Keys.Oem4) && !e.Shift))
                teclaValida = true;
            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void SWBEstado_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TXTNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
