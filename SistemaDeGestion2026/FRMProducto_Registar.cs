using AForge.Video;
using AForge.Video.DirectShow;
using CapaRN;
using SistemaDeGestion2026.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeGestion2026
{
    public partial class FRMProducto_Registar : DevComponents.DotNetBar.Office2007Form
    {


        #region Variables 

        private aproduc producto = new aproduc();
        private xnumcor correlativo = new xnumcor();
        public bool modificar = false;
        public String codProMod = "";
        public bool actualizar = false;
        //Variables para la camara
        private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice FinalFrame;
        private bool TieneFoto = false;

        #endregion

        #region Constructor

        public FRMProducto_Registar()
        {
            InitializeComponent();
            DetectarCamaras();
        }

        #endregion

        #region Metodos 

        private bool VerificarIntegridad()
        {
            bool respuesta = true;
            aproduc producto2 = new aproduc();
            producto2.capdnompro = TXTNombreProducto.Text;


            if (TXTNombreProducto.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el nombre de la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNombreProducto.Focus();
                respuesta = false;
            }else if (producto2.ObtenerDatosNombre(modificar, producto.capdnompro))
            {
                MessageBox.Show("Este nombre de prenda ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNombreProducto.Focus();
                respuesta = false;
            }
            else if (TXTMaterial.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el material de la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTMaterial.Focus();
                respuesta = false;
            }
            else if (TXTColor.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca los color de la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTColor.Focus();
                respuesta = false;
            }
            else if (TXTModelo.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el modelo de la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTModelo.Focus();
                respuesta = false;
            }
            else if (TXTMarca.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca un marca para la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTMarca.Focus();
                respuesta = false;
            }
            else if (TXTDescripcion.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca una descripcion de la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTDescripcion.Focus();
                respuesta = false;
            }


            return respuesta;
        }
        private void LimpiarCasillas()
        {
            TXTModelo.Text = "";
            TXTNombreProducto.Text = "";
            TXTMarca.Text = "";
            TXTMaterial.Text = "";
            TXTColor.Text = "";
            TXTDescripcion.Text = "";
            NUDPrecioMinVenta.Value = 1;
            NUDPrecioVenta.Value = 1;


        }
        private void DetectarCamaras()
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);//constructor            
            FinalFrame = new VideoCaptureDevice();
        }

        private void IniciarCamara()
        {
            try
            {
                FinalFrame = new VideoCaptureDevice(CaptureDevice[2].MonikerString);// specified web cam and its filter moniker string
                FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);// click button event is fired, 
                FinalFrame.Start();
            }
            catch
            {
                MessageBox.Show("No se tiene una cámara conectada al equipo",
                    "Error de cámara",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs) // must be void so that it can be accessed everywhere.
                                                                             // New Frame Event Args is an constructor of a class
        {
            PCBCamara.Image = (Bitmap)eventArgs.Frame.Clone();// clone the bitmap
        }

        private void ApagarCamara()
        {
            if (FinalFrame.IsRunning == true) FinalFrame.Stop();
        }


        private void JalarDatos()
        {
            producto.papdcodpro = this.codProMod;
            producto.ObtenerDatos();
            SWBEstadoProducto.Value = producto.capdestpro;
            TXTColor.Text = producto.capdcolpro;
            CBCategoria.Text = producto.capdcatpro;
            CBTalla.Text = producto.capdtalpro;
            CBSexo.Text = producto.capdgenpro;
            TXTMarca.Text = producto.capdmarpro;
            TXTMaterial.Text = producto.capdmatpro;
            TXTModelo.Text = producto.capdmodpro;
            TXTNombreProducto.Text = producto.capdnompro;
            TXTDescripcion.Text = producto.capddespro;
            NUDPrecioMinVenta.Value = producto.capdpremin;
            NUDPrecioVenta.Value = producto.capdpreven;


            if (producto.capdfotpro == "")
            {
                TieneFoto = false;
                PCBFotografia.Image = Resources.NoImagen;
            }
            else
            {
                TieneFoto = true;
                PCBFotografia.Image = MetodosGenerales.ConvertBase64StringToImage(producto.capdfotpro);
            }
        }

        #endregion

        #region Eventos

        private void FRMProducto_Registar_Load(object sender, EventArgs e)
        {

            CBTalla.SelectedIndex = 0;
            CBCategoria.SelectedIndex = 0;
            CBSexo.SelectedIndex = 0;


            IniciarCamara();
            if (this.modificar)
            {
                JalarDatos();
                BTNGrabar.Text = "&Modificar";
                this.Text = "Modificar Producto";
                GPPanelPrincipal.Text = "Modificar Producto";
                SWBEstadoProducto.Focus();
            }
            else
            {
                LimpiarCasillas();
                BTNGrabar.Text = "&Guardar";
                this.Text = "Registrar Producto";
                GPPanelPrincipal.Text = "Registrar Producto";
                SWBEstadoProducto.Focus();
            }





        }
        private void BTNGrabar_Click(object sender, EventArgs e)
        {
            if (VerificarIntegridad())
            {
                producto = new aproduc();

                if (!this.modificar)
                {
                    //Generar el correlativo
                    correlativo.pxnctipcor = "aproduct";
                    if (correlativo.ObtenerSiguiente())
                    {
                        producto.papdcodpro = correlativo.pxnctipcor + "-" +
                                             correlativo.cxncnumcor.ToString("D12");
                    }
                }
                else
                {
                    producto.papdcodpro = this.codProMod;
                }

                producto.capdestpro = SWBEstadoProducto.Value;
                producto.capdcatpro = CBCategoria.Text;
                producto.capdmodpro = TXTModelo.Text;
                producto.capdnompro = TXTNombreProducto.Text;
                producto.capdmarpro = TXTMarca.Text;
                producto.capdmatpro = TXTMaterial.Text;
                producto.capdcolpro = TXTColor.Text;
                producto.capdtalpro = CBTalla.Text;
                producto.capddespro = TXTDescripcion.Text;
                producto.capdgenpro = CBSexo.Text;
                producto.capdpremin = NUDPrecioMinVenta.Value;
                producto.capdpreven = NUDPrecioVenta.Value;
                //Fotografia del producto
                if (TieneFoto)
                {
                    producto.capdfotpro = MetodosGenerales.ConvertImageToBase64String(PCBFotografia.Image);
                }
                else
                {
                    producto.capdfotpro = "";
                }





                if (!this.modificar)
                {
                    if (producto.Grabar())
                    {
                        MessageBox.Show("Producto guardado correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMProducto_Registar_FormClosing;
                        ApagarCamara();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Persona no se pudo guardar!!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (producto.Modificar())
                    {
                        MessageBox.Show("Producto modificado correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMProducto_Registar_FormClosing;
                        ApagarCamara();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Producto no se pudo modificar!!",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void TXTNombreProducto_KeyDown(object sender, KeyEventArgs e)
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

        private void NUDMinVenta_KeyDown(object sender, KeyEventArgs e)
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
                (e.KeyCode == Keys.Right) ||
                (e.KeyCode == Keys.OemPeriod) ||
                (e.KeyCode == Keys.Decimal))
                teclaValida = true;

            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }


        }

        private void NUDCantidadCompra_KeyDown(object sender, KeyEventArgs e)
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

        private void FRMProducto_Registar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar el formulario?",
                               "Pregunta",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question,
                               MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                ApagarCamara();
            }
        }

        private void BTNSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNAbrirFoto_Click(object sender, EventArgs e)
        {
            if (OFDElegirImagen.ShowDialog() == DialogResult.OK)
            {
                PCBFotografia.ImageLocation = OFDElegirImagen.FileName;
                TieneFoto = true;
            }
        }

        private void BTNLimpiarFoto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea borrar la imagen?",
                            "Pregunta",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                TieneFoto = false;
                PCBFotografia.Image = Resources.NoImagen;
            }
        }

        private void BTNCapturarFoto_Click(object sender, EventArgs e)
        {
            PCBFotografia.Image = PCBCamara.Image;
            TieneFoto = true;
        }


        #endregion

        private void BTNLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDropDown5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
