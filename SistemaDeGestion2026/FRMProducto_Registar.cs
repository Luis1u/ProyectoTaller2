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
        private bool lectorCBHabilitado = false;

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
            producto2.capdnompro = LBLCodigoDeBarras.Text;

            /*if (LBLCodigoDeBarras.Text == "SIN CODIGO")
            {
                MessageBox.Show("Escanee el codigo de barras  de la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BTNCodigoDeBarras.Focus();
                respuesta = false;
            }
            else if (producto2.ObtenerDatosCodigo(modificar, producto.capdcodbar))
            {
                MessageBox.Show("Este codigo de barras de la prenda ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BTNCodigoDeBarras.Focus();
                respuesta = false;
            }
            */
             if (TXTModelo.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el modelo de la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTModelo.Focus();
                respuesta = false;
            }

            else if (CMBGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un genero para la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CMBGenero.Focus();
                respuesta = false;
            }
            else if (CMBCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Introduzca una categoria de la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CMBCategoria.Focus();
                respuesta = false;
            }
            else if (CMBNombreProducto.Text.Replace(" ", "") == "" && CMBNombreProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Introduzca el nombre de la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CMBNombreProducto.Focus();
                respuesta = false;
            }
            else if (CMBMarca.Text.Replace(" ", "") == "" && CMBMarca.SelectedIndex == -1)
            {
                MessageBox.Show("Introduzca un marca para la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CMBMarca.Focus();
                respuesta = false;
            }
            else if (CMBMaterial.Text.Replace(" ", "") == "" && CMBMaterial.SelectedIndex == -1)
            {
                MessageBox.Show("Introduzca el material de la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CMBMaterial.Focus();
                respuesta = false;
            }
            else if (CMBColor.Text.Replace(" ", "") == "" && CMBColor.SelectedIndex == -1)
            {
                MessageBox.Show("Introduzca el color de la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CMBColor.Focus();
                respuesta = false;
            }
            else if (CMBTalla.Text.Replace(" ", "") == "" && CMBTalla.SelectedIndex == -1)
            {
                MessageBox.Show("Introduzca la talla de la prenda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CMBTalla.Focus();
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
            CMBNombreProducto.Text = "";
            CMBMarca.Text = "";
            CMBMaterial.Text = "";
            CMBColor.Text = "";
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
                FinalFrame = new VideoCaptureDevice(CaptureDevice[0].MonikerString);// specified web cam and its filter moniker string
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
            CMBColor.Text = producto.capdcolpro;
            CMBCategoria.Text = producto.fapdcodcat;
            CMBTalla.Text = producto.capdtalpro;
            CMBGenero.Text = producto.capdgenpro;
            CMBMarca.Text = producto.capdmarpro;
            CMBMaterial.Text = producto.capdmatpro;
            TXTModelo.Text = producto.capdmodpro;
            CMBNombreProducto.Text = producto.capdnompro;
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
            CargarComboCategorias();
            CargarCombo("capdnompro", CMBNombreProducto);
            CargarCombo("capdmarpro", CMBMarca);
            CargarCombo("capdmatpro", CMBMaterial);
            CargarCombo("capdcolpro", CMBColor);
            CargarCombo("capdtalpro", CMBTalla);
            



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


       
        private void CargarComboCategorias()
        {
            List<acatpro> ListaCategorias = new List<acatpro>();
            acatpro categoria = new acatpro();
            ListaCategorias = categoria.Lista("cacpestcat = true order by cacpnomcat");
            CMBCategoria.Items.Clear();
            CMBCategoria.DisplayMember = "cacpnomcat";
            CMBCategoria.ValueMember = "pacpcodcat";
            CMBCategoria.DataSource = ListaCategorias;
            CMBCategoria.SelectedIndex = -1;

        }
        private void CargarCombo(String campo, ComboBox combo)
        {
            List<String> ListaNombresProducto = new List<String>();

            ListaNombresProducto = producto.Combo(campo);
            combo.Items.Clear();
            combo.DisplayMember = campo;
            combo.DataSource = ListaNombresProducto;
            combo.SelectedIndex = -1;

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
                    LBLCodigoDeBarras.BackColor = Color.LightBlue;
                }
                lectorCBHabilitado = false;
                TXTModelo.Focus();
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

        private void BTNGrabar_Click_1(object sender, EventArgs e)
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
                producto.fapdcodcat = CMBCategoria.SelectedValue.ToString();
                producto.capdmodpro = TXTModelo.Text;
                producto.capdnompro = CMBNombreProducto.Text;
                producto.capdmarpro = CMBMarca.Text;
                producto.capdmatpro = CMBMaterial.Text;
                producto.capdcolpro = CMBColor.Text;
                producto.capdtalpro = CMBTalla.Text;
                producto.capddespro = TXTDescripcion.Text;
                producto.capdgenpro = CMBGenero.Text;
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
                        MessageBox.Show("Producto no se pudo guardar!!",
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

        private void CMBGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BTNCapturarFoto_Click_1(object sender, EventArgs e)
        {
            PCBFotografia.Image = PCBCamara.Image;
            TieneFoto = true;
        }

        private void BTNAbrirFoto_Click_1(object sender, EventArgs e)
        {

            if (OFDElegirImagen.ShowDialog() == DialogResult.OK)
            {
                PCBFotografia.ImageLocation = OFDElegirImagen.FileName;
                TieneFoto = true;
            }
        }

        private void BTNLimpiarFoto_Click_1(object sender, EventArgs e)
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

        private void CMBNombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void NUDPrecioMinVenta_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
