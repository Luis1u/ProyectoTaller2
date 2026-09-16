using AForge.Video;
using AForge.Video.DirectShow;
using CapaRN;
using DevComponents.DotNetBar.Controls;
using SistemaDeGestion2026.Properties;
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
    public partial class FRMProducto_Registrar : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private bool lectorCBHabilitado = false;
        public aproduc producto = new aproduc();        
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
        public FRMProducto_Registrar()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos

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

        private bool VerificarIntegridad()
        {
            bool respuesta = true;
            aproduc producto2 = new aproduc();
            producto2.capdcodbar = LBLCodigoDeBarras.Text;
            
            if (producto2.ObtenerDatosCodigo(modificar, producto.capdcodbar))
            {
                MessageBox.Show("Este codigo de barras de la prenda ya existe", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BTNCodigoDeBarras.Focus();
                respuesta = false;
            }            
            else if (TXTModelo.Text.Replace(" ", "") == "")
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
            else if (DINPrecioVenta.Value <= 0)
            {
                MessageBox.Show("Introduzca un precio de venta válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DINPrecioVenta.Focus();
                respuesta = false;
            }
            else if ((DINPrecioMinimo.Value <= 0)&&(DINPrecioMinimo.Value > DINPrecioVenta.Value))
            {
                MessageBox.Show("Introduzca un precio de venta mínimo válido", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DINPrecioMinimo.Focus();
                respuesta = false;
            }

            return respuesta;
        }
        private void LimpiarCasillas()
        {
            SWBEstado.Value = true;
            LBLCodigoDeBarras.Text = "SIN CÓDIGO";
            LBLCodigoDeBarras.BackColor = Color.PaleGreen;
            TXTModelo.Text = "";
            CMBGenero.SelectedIndex= -1;
            CMBCategoria.SelectedIndex= -1;
            CMBNombreProducto.Text = "";
            CMBMarca.Text = "";
            CMBMaterial.Text = "";
            CMBColor.Text = "";
            CMBTalla.Text = "";
            TXTDescripcion.Text = "";
            IINStock.Value = 0;
            DINPrecioVenta.Value = 0;
            DINPrecioMinimo.Value = 0;
            TieneFoto = false;
            PCBFotografia.Image = Resources.NoImagen;
            TXTModelo.Focus();
        }

        private void JalarDatos()
        {
            producto.papdcodpro = this.codProMod;
            producto.ObtenerDatos();

            SWBEstado.Value = producto.capdestpro;
            LBLCodigoDeBarras.Text = producto.capdcodbar;
            if (producto.capdcodbar != "")
            {
                LBLCodigoDeBarras.Text = "SIN CÓDIGO";
                LBLCodigoDeBarras.BackColor = Color.PaleGreen;
            }
            else
            {
                LBLCodigoDeBarras.Text = producto.capdcodbar;
                LBLCodigoDeBarras.BackColor = Color.PaleGreen;
            }
            
            TXTModelo.Text = producto.capdmodpro;
            CMBGenero.SelectedText = producto.capdgenpro;
            CMBCategoria.SelectedValue = producto.fapdcodcat;
            
            CMBNombreProducto.Text = producto.capdnompro;
            CMBMarca.Text = producto.capdmarpro;
            CMBColor.Text = producto.capdcolpro;
            CMBTalla.Text = producto.capdtalpro;
            CMBMaterial.Text = producto.capdmatpro;
            TXTDescripcion.Text = producto.capddespro;
            IINStock.Value = producto.capdstopro;
            DINPrecioVenta.Value = (double) producto.capdpreven;
            DINPrecioMinimo.Value = (double)producto.capdpremin;
                                  
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
        
        private void FRMProducto_Registrar_Load(object sender, EventArgs e)
        {
            IniciarCamara();

            CargarComboCategorias();
            CargarCombo("capdnompro", CMBNombreProducto);
            CargarCombo("capdmarpro", CMBMarca);
            CargarCombo("capdmatpro", CMBMaterial);
            CargarCombo("capdcolpro", CMBColor);
            CargarCombo("capdtalpro", CMBTalla);

            if (this.modificar)
            {
                JalarDatos();
                BTNGrabar.Text = "&Modificar";
                this.Text = "Modificar Producto";
                GPPanelPrincipal.Text = "Modificar Producto";
                TXTModelo.Focus();
            }
            else
            {
                LimpiarCasillas();
                BTNGrabar.Text = "&Guardar";
                this.Text = "Registrar Producto";
                GPPanelPrincipal.Text = "Registrar Producto";
                TXTModelo.Focus();
            }            
        }

        #endregion

        #region Metodos para la Cámara

        private void DetectarCamaras()
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);//constructor            
            FinalFrame = new VideoCaptureDevice();
        }

        private void IniciarCamara()
        {
            try
            {
                FinalFrame = new VideoCaptureDevice(CaptureDevice[1].MonikerString);// specified web cam and its filter moniker string
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

        #endregion

        private void BTNSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMProducto_Registrar_FormClosing(object sender, FormClosingEventArgs e)
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

        private void TXTModelo_Enter(object sender, EventArgs e)
        {
            TextBoxX a = (TextBoxX)sender;
            a.SelectAll();
        }

        private void CMBNombreProducto_Enter(object sender, EventArgs e)
        {
            ComboBoxEx a = (ComboBoxEx)sender;
            a.SelectAll();
        }

        private void CMBNombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void CMBNombreProducto_KeyDown(object sender, KeyEventArgs e)
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

        private void CMBMarca_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;
            if ((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.NumPad9))
                teclaValida = true;
            else if ((e.KeyCode >= Keys.D0) && (e.KeyCode <= Keys.D9) && !e.Shift)
                teclaValida = true;
            else if ((e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z) && (!e.Alt))
                teclaValida = true;
            else if ((e.KeyCode == Keys.Subtract) ||
                (e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Space) ||
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right) ||
                ((e.KeyCode == Keys.OemMinus) && !e.Shift))
                teclaValida = true;

            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void CMBTalla_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;
            if ((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.NumPad9))
                teclaValida = true;
            else if ((e.KeyCode >= Keys.D0) && (e.KeyCode <= Keys.D9) && !e.Shift)
                teclaValida = true;
            else if ((e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z) && (!e.Alt))
                teclaValida = true;
            else if ((e.KeyCode == Keys.Subtract) ||
                (e.KeyCode == Keys.Back) ||                
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right) ||
                ((e.KeyCode == Keys.OemMinus) && !e.Shift))
                teclaValida = true;

            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
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

        private void BTNCodigoDeBarras_Click_1(object sender, EventArgs e)
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
    }
}
