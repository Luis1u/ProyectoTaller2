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
    public partial class FRMCliente_Registrar : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private aclient cliente = new aclient();
        private aperson persona = new aperson();
        private bool personaok = false;
        private xnumcor correlativo = new xnumcor();
        public bool modificar = false;
        public String codCliMod = "";
        public bool actualizar = false;
        #endregion
        public FRMCliente_Registrar()
        {
            InitializeComponent();
        }
        private void JalarDatos()
        {
            cliente.pacecodcli = this.codCliMod;
            cliente.ObtenerDatos();
            persona.papscodper = cliente.facecodper;
            persona.ObtenerDatos();
            SWBEstado.Value = cliente.caceestcli;
            TXTCI.Text = persona.capsnumcid;
            TXTNombres.Text = persona.capsapepat + " " +
                                persona.capsapemat + " " +
                                persona.capsnomper;
            TXTDireccion.Text = cliente.cacedircli;
            TXTNit.Text = cliente.cacenitcli;
            TXTRazonSocial.Text = cliente.cacerazsoc;
            TXTTelefono.Text = cliente.cacetelcli;
            
            
        }

        private void FRMCliente_Registrar_Load(object sender, EventArgs e)
        {
            if (this.modificar)
            {
                JalarDatos();
                BTNGrabar.Text = "&Modificar";
                this.Text = "Modificar cliente";
                GPPanelPrincipal.Text = "Modificar cliente";
                TXTCI.Focus();
            }
            else
            {
                LimpiarCasillas();
                BTNGrabar.Text = "&Guardar";
                this.Text = "Registrar cliente";
                GPPanelPrincipal.Text = "Registrar cliente";
                TXTCI.Focus();
            }
        }

        private void BTNBuscarCliente_Click(object sender, EventArgs e)
        {
            FRMPersona_Buscar a = new FRMPersona_Buscar();
            a.tipo = 2;
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
        private bool VerificarIntegridad()
        {
            bool respuesta = true;
            aclient cliente2 = new aclient();
            cliente2.cacenitcli = TXTNit.Text;

            if (TXTNit.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el NIT del cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNit.Focus();
                respuesta = false;
            }
            else if (cliente2.ObtenerDatosNit(modificar,cliente.cacenitcli))
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

        private void BTNGrabar_Click(object sender, EventArgs e)
        {
            if (VerificarIntegridad())
            {
                if (!this.modificar)
                {
                    //Generar el correlativo
                    correlativo.pxnctipcor = "aclient";
                    if (correlativo.ObtenerSiguiente())
                    {
                        cliente.pacecodcli = correlativo.pxnctipcor + "-" +
                                             correlativo.cxncnumcor.ToString("D12");
                    }
                }
                else
                {
                    cliente.pacecodcli = this.codCliMod;
                }
                cliente.caceestcli = SWBEstado.Value;
                cliente.cacerazsoc = TXTRazonSocial.Text;
                cliente.cacenitcli = TXTNit.Text;
                cliente.cacedircli  = TXTDireccion.Text;
                cliente.cacetelcli = TXTTelefono.Text;
                cliente.facecodper = persona.papscodper;


                if (!this.modificar)
                {
                    if (cliente.Grabar())
                    {
                        MessageBox.Show("cliente guardado correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMCliente_Registrar_FormClosing;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("cliente no se pudo guardar!!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (cliente.Modificar())
                    {
                        MessageBox.Show("cliente modificado correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMCliente_Registrar_FormClosing;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("cliente no se pudo modificar!!",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void FRMCliente_Registrar_FormClosing(object sender, FormClosingEventArgs e)
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

        private void TXTNit_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;

            if ((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.NumPad9))
                teclaValida = true;
            else if ((e.KeyCode >= Keys.D0) && (e.KeyCode <= Keys.D9) && !e.Shift)
                teclaValida = true;
            else if
                ((e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right))
                teclaValida = true;

            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
