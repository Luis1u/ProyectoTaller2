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
    public partial class FRMProveedor_Registrar : Form
    {
        #region Variables
        private aprovee proveedor = new aprovee();
        private aperson persona = new aperson();
        private bool personaok = false;
        private xnumcor correlativo = new xnumcor();
        public bool modificar = false;
        public String codProMod = "";
        public bool actualizar = false;
        #endregion
        public FRMProveedor_Registrar()
        {
            InitializeComponent();
        }

        private void BTNBuscarProveedor_prock(object sender, EventArgs e)
        {
            FRMPersona_Buscar a = new FRMPersona_Buscar();
            a.tipo = 3;
            a.ShowDialog();
            if (a.seleccionadoOk)
            {
                this.persona = a.persona;
                this.personaok = true;
                TXTCI.Text = persona.capsnumcid;
                TXTNombres.Text = persona.capsapepat + " " +
                                  persona.capsapemat + " " +
                                  persona.capsnomper;
            }
            else
            {
                this.personaok = false;
                TXTCI.Text = "";
                TXTNombres.Text = "Nombre Completo";
            }
        }

       

        private void BTNGrabar_Click(object sender, EventArgs e)
        {
            if (VerificarIntegridad())
            {
                if (!this.modificar)
                {
                    //Generar el correlativo
                    correlativo.pxnctipcor = "aproent";
                    if (correlativo.ObtenerSiguiente())
                    {
                        proveedor.papvcodpro = correlativo.pxnctipcor + "-" +
                                             correlativo.cxncnumcor.ToString("D12");
                    }
                }
                else
                {
                    proveedor.papvcodpro = this.codProMod;
                }
                proveedor.capvestpro = SWBEstado.Value;
                proveedor.capvrazsoc = TXTRazonSocial.Text;
                proveedor.capvnitpro = TXTNit.Text;
                proveedor.capvdirpro = TXTDireccion.Text;
                proveedor.capvtelpro = TXTTelefono.Text;
                proveedor.fapvcodper = persona.papscodper;


                if (!this.modificar)
                {
                    if (proveedor.Grabar())
                    {
                        MessageBox.Show("proveedor guardado correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMProveedor_Registrar_FormClosing;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("proveedor no se pudo guardar!!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (proveedor.Modificar())
                    {
                        MessageBox.Show("proveedor modificado correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMProveedor_Registrar_FormClosing;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("proveedor no se pudo modificar!!",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void FRMProveedor_Registrar_FormClosing(object sender, FormClosingEventArgs e)
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
        private void JalarDatos()
        {
            proveedor.papvcodpro = this.codProMod;
            proveedor.ObtenerDatos();
            persona.papscodper = proveedor.fapvcodper;
            persona.ObtenerDatos();
            SWBEstado.Value = proveedor.capvestpro;
            TXTCI.Text = persona.capsnumcid;
            TXTNombres.Text = persona.capsapepat + " " +
                                persona.capsapemat + " " +
                                persona.capsnomper;
            TXTDireccion.Text = proveedor.capvdirpro;
            TXTNit.Text = proveedor.capvnitpro;
            TXTRazonSocial.Text = proveedor.capvrazsoc;
            TXTTelefono.Text = proveedor.capvtelpro;


        }

        private void FRMProveedor_Registrar_Load(object sender, EventArgs e)
        {
            if (this.modificar)
            {
                JalarDatos();
                BTNGrabar.Text = "&Modificar";
                this.Text = "Modificar Proveedor";
                GPPanelPrincipal.Text = "Modificar Proveedor";
                TXTCI.Focus();
            }
            else
            {
                LimpiarCasillas();
                BTNGrabar.Text = "&Guardar";
                this.Text = "Registrar Proveedor";
                GPPanelPrincipal.Text = "Registrar Proveedor";
                TXTCI.Focus();
            }
        }
        private bool VerificarIntegridad()
        {
            bool respuesta = true;
            aprovee proveedor2 = new aprovee();
            proveedor2.capvnitpro = TXTNit.Text;

            if (TXTNit.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el NIT del cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNit.Focus();
                respuesta = false;
            }
            else if (proveedor2.ObtenerDatosNit(modificar, proveedor.capvnitpro))
            {
                MessageBox.Show("Este NIT ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNit.Focus();
                respuesta = false;
            }
            else if (TXTRazonSocial.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca la razon social del cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTRazonSocial.Focus();
                respuesta = false;
            }

            else if (TXTDireccion.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca la direccion del cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTDireccion.Focus();
                respuesta = false;
            }
            else if (TXTTelefono.Text.Replace(" ", "") == "")
            {

                MessageBox.Show("Introduzca el telefono del cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTTelefono.Focus();
                respuesta = false;
            }




            return respuesta;
        }
        private void LimpiarCasillas()
        {
            SWBEstado.Value = true;
            TXTRazonSocial.Text = "";
            TXTNit.Text = "";
            TXTDireccion.Text = "";
            TXTTelefono.Text = "";
            TXTCI.Text = "";
            TXTNombres.Text = "";
        }

        private void BTNBuscarProveedor_Click(object sender, EventArgs e)
        {
            FRMPersona_Buscar a = new FRMPersona_Buscar();
            a.tipo = 3;
            a.ShowDialog();
            if (a.seleccionadoOk)
            {
                this.persona = a.persona;
                this.personaok = true;
                TXTCI.Text = persona.capsnumcid;
                TXTNombres.Text = persona.capsapepat + " " +
                                  persona.capsapemat + " " +
                                  persona.capsnomper;
            }
            else
            {
                this.personaok = false;
                TXTCI.Text = "";
                TXTNombres.Text = "Nombre Completo";
            }
        }

        private void TXTDireccion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
