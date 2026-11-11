using CapaRN;
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
    public partial class FRMVenta_Registrar : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        FRMPrincipal principal = (FRMPrincipal)Application.OpenForms["FRMPrincipal"];

        private avenpro venta = new avenpro();
        private aiteven item = new aiteven();
        private xnumcor correlativo = new xnumcor();

        public aususis usuario = new aususis();

        public bool actualizar = false;




        private aclient cliente = new aclient();
        private bool clienteOk = false;

        private List<liteven> listaItems = new List<liteven>();


        private bool lectorCBHabilitado = false;
        public aproduc producto = new aproduc();

        private bool productoOk = false;
        private liteven itemModificar = new liteven();
        private bool modificarItem = false;
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
            usuario.pauscodusu = principal.usuario.pauscodusu;
            usuario.ObtenerDatos();
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
                if ((item.caivcanite + 1) > pro.capdstopro)
                {
                    MessageBox.Show("No se puede agregar mas unidades de este producto, stock insuficiente: "+ pro.capddespro);
                    return;
                }
                item.caivcanite += 1;
                item.caivsubtot = item.caivcanite * item.caivpreuni;

            }
            else

            {
                if (pro.capdstopro < 1)
                {
                    MessageBox.Show("No se puede agregar este producto, stock insuficiente: "+ pro.capddespro);
                    return;
                }
                
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
                item.capdstopro = pro.capdstopro;
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
                if (MessageBox.Show("¿Está seguro que desea borrar este producto? "+ DTGLista[5, DTGLista.SelectedRows[0].Index].Value.ToString(),
                            "Pregunta"  ,
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
            LBLTotalALiteral.Text ="SON: "+ numeroEnLetras +". BOLIVIANOS";
        }
        private void EliminarItem(string CodPro)
        {
            listaItems.RemoveAll(x => x.faivcodpro == CodPro);
            ActualizarGridItems(); 
           
        }

        private void DTGLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DTGLista.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("¿Está seguro que desea borrar este producto? "+ DTGLista[5, DTGLista.SelectedRows[0].Index].Value.ToString(),
                                "Pregunta" ,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        EliminarItem(DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString());
                    }
                }
            }
        }

        

        private void DTGLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            itemModificar = listaItems.Find(x => x.faivcodpro == DTGLista[0, e.RowIndex].Value.ToString());
            modificarItem = true;
            if (itemModificar != null)
            {
                TXTDescripcion.Text = itemModificar.capddespro;
                DINCantidad.Value = itemModificar.caivcanite;
                DINPrecio.Value = (Double)itemModificar.caivpreuni;
                producto.papdcodpro = itemModificar.faivcodpro;
                if (producto.ObtenerDatos())
                {
                    if (producto.capdfotpro == "")
                    {

                        PCBFotografia.Image = Resources.NoImagen;
                    }
                    else
                    {
                        PCBFotografia.Image = MetodosGenerales.ConvertBase64StringToImage(producto.capdfotpro);
                    }
                }
            }

        }

        private void BTNModificarProducto_Click(object sender, EventArgs e)
        {
            if (modificarItem)
            {
                if (((int)DINCantidad.Value) < 1)
                {
                    MessageBox.Show("La cantidad no puede ser menor a cero");
                    DINCantidad.Value = itemModificar.caivcanite;
                    return;
                }else if(((int)DINCantidad.Value) > producto.capdstopro)
                {
                    MessageBox.Show("El nuevo monto introducido sobrepasa el stock actual");
                    DINCantidad.Value = itemModificar.caivcanite;
                    return;
                }else if (((Decimal)DINPrecio.Value) < producto.capdpremin)
                {
                    MessageBox.Show("El precio modificado es menor al precio minimo");
                    DINPrecio.Value = (Double)itemModificar.caivpreuni;
                    return;
                }
                
                itemModificar.caivcanite = (int)DINCantidad.Value;
                itemModificar.caivpreuni = (Decimal)DINPrecio.Value;
                itemModificar.caivsubtot = itemModificar.caivcanite * itemModificar.caivpreuni;
                ActualizarGridItems();
                modificarItem = false;
                TXTDescripcion.Text = "Descripción del producto";
                DINCantidad.Value = 0;
                DINPrecio.Value = 0;
                PCBFotografia.Image = Resources.NoImagen;
            }
        }

        private void BTNLimpiarProducto_Click(object sender, EventArgs e)
        {
            modificarItem = false;
            TXTDescripcion.Text = "Descripción del producto";
            DINCantidad.Value = 0;
            DINPrecio.Value = 0;
            PCBFotografia.Image = Resources.NoImagen;
        }

        private void BTNGrabar_Click(object sender, EventArgs e)
        {
            List<aproduc> ListaProductos = new List<aproduc>();
            ListaProductos = listaItems.Select(x => new aproduc
            {
                papdcodpro = x.faivcodpro,
                capdstopro = x.capdstopro - x.caivcanite,
                capdcodbar = x.capdcodbar,
                capdnompro = x.capdnompro,
                capdtalpro = x.capdtalpro,
                capddespro = x.capddespro,
                capdpreven = x.caivpreuni,
                capdmodpro = x.capdmodpro

            }).ToList();
            
            if (Verificar_Integridad())
            {
                venta = new avenpro();
                correlativo.pxnctipcor = "avenpro";
                if (correlativo.ObtenerSiguiente())
                {
                    venta.pavpcodven = correlativo.pxnctipcor + "-" +
                                       correlativo.cxncnumcor.ToString("D12");
                }
                venta.cavpestven = true;
                venta.cavpfeccre = DateTime.Now;
                venta.cavpfechor = DateTime.Now;
                venta.cavpfecmod = DateTime.Now;
                venta.cavptotven = listaItems.Sum(x => x.caivsubtot);
                venta.cavpobsven = TXTDescripcion.Text;
                venta.favpcodcli = cliente.pacecodcli;
                venta.favpusucre = usuario.pauscodusu;
                venta.favpusumod = usuario.pauscodusu;

                //Grabado de los items de la venta
                correlativo.pxnctipcor = "aiteven";
                if (correlativo.ObtenerSiguiente(listaItems.Count))
                {
                    correlativo.cxncnumcor -= listaItems.Count - 1;
                    foreach (liteven item in listaItems)
                    {

                        item.paivcodite = correlativo.pxnctipcor + "-" +
                                          correlativo.cxncnumcor.ToString("D12");
                        item.faivcodven = venta.pavpcodven;
                        correlativo.cxncnumcor++;
                    }

                }

                if (venta.Grabar() && item.Grabar(listaItems) && producto.ActualizarStock(ListaProductos))
                {
                    MessageBox.Show("Venta guardada correctamente!!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 1. Preguntamos al usuario si desea guardar en PDF o imprimir en físico
                    DialogResult opcion = MessageBox.Show("¿Desea guardar el recibo en PDF?\n\n(Haga clic en 'Sí' para elegir dónde guardarlo, o 'No' para imprimir en impresora física)",
                                                         "Opciones de Recibo",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);

                    if (opcion == DialogResult.Yes)
                    {
                        // Opción de Guardar en PDF con selector de ruta
                        SaveFileDialog guardarPDF = new SaveFileDialog();
                        guardarPDF.Filter = "Archivo PDF (*.pdf)|*.pdf";
                        guardarPDF.FileName = "Recibo_" + venta.pavpcodven.Replace("/", "-") + ".pdf";

                        if (guardarPDF.ShowDialog() == DialogResult.OK)
                        {
                            PRDRecibo.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                            PRDRecibo.PrinterSettings.PrintToFile = true;
                            PRDRecibo.PrinterSettings.PrintFileName = guardarPDF.FileName;
                            PRDRecibo.Print();

                            MessageBox.Show("¡PDF guardado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // Opción de Impresión Física (abre el selector de impresoras normales)
                        PDGDialogo.Document = PRDRecibo;
                        if (PDGDialogo.ShowDialog() == DialogResult.OK)
                        {
                            PRDRecibo.Print();
                        }
                    }

                    this.actualizar = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Venta no se pudo guardar!!",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }

        }
        private bool Verificar_Integridad()
        {
           
            if (!clienteOk)
            {
                MessageBox.Show("Deve seleccionar un cliente",
                                    "Mensaje",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                return false;
  
            }else if (listaItems.Count < 1)
            {

                MessageBox.Show("Deve haber por lo menos un producto en el carrito",
                                    "Mensaje",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                return false;
            }

            return true;

        }

        private void PRDRecibo_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {// Fuentes compactas ideales para tickets térmicos
            Font fuenteTitulo = new Font("Consolas", 10, FontStyle.Bold);
            Font fuenteNegrita = new Font("Consolas", 8, FontStyle.Bold);
            Font fuenteNormal = new Font("Consolas", 8, FontStyle.Regular);
            Brush pincel = Brushes.Black;

            float margenIzquierdo = 10;
            float posicionY = 10;
            float anchoTicket = 270; // Ancho útil para impresora térmica

            // 1. Cabecera del Recibo
            e.Graphics.DrawString("SISTEMA DE GESTIÓN 2026", fuenteTitulo, pincel, new PointF(margenIzquierdo, posicionY));
            posicionY += 16;

            e.Graphics.DrawString("RECIBO DE VENTA", fuenteNegrita, pincel, new PointF(margenIzquierdo, posicionY));
            posicionY += 14;

            e.Graphics.DrawString("Nro: " + venta.pavpcodven.Replace("avenpro-", ""), fuenteNormal, pincel, new PointF(margenIzquierdo, posicionY));

            posicionY += 12;

            e.Graphics.DrawString("FECHA: " + venta.cavpfechor.ToString("dd/MM/yyyy HH:mm"), fuenteNormal, pincel, new PointF(margenIzquierdo, posicionY));
            posicionY += 12;

            e.Graphics.DrawString("CLIENTE: " + cliente.cacerazsoc, fuenteNormal, pincel, new PointF(margenIzquierdo, posicionY));
            posicionY += 12;

            e.Graphics.DrawString("NIT/CI: " + cliente.cacenitcli, fuenteNormal, pincel, new PointF(margenIzquierdo, posicionY));
            posicionY += 15;

            // Línea divisoria
            e.Graphics.DrawLine(Pens.Black, margenIzquierdo, posicionY, margenIzquierdo + anchoTicket, posicionY);
            posicionY += 8;

            // 2. Cabecera de la Tabla de Productos
            e.Graphics.DrawString("CANT", fuenteNegrita, pincel, new PointF(margenIzquierdo, posicionY));
            e.Graphics.DrawString("PRODUCTO", fuenteNegrita, pincel, new PointF(margenIzquierdo + 35, posicionY));
            e.Graphics.DrawString("P.U.", fuenteNegrita, pincel, new PointF(margenIzquierdo + 175, posicionY));
            e.Graphics.DrawString("SUB", fuenteNegrita, pincel, new PointF(margenIzquierdo + 220, posicionY));
            posicionY += 14;

            e.Graphics.DrawLine(Pens.Gray, margenIzquierdo, posicionY, margenIzquierdo + anchoTicket, posicionY);
            posicionY += 6;

            // 3. Detalle de los Productos
            foreach (liteven item in listaItems)
            {
                string cantidad = item.caivcanite.ToString();
                string descripcion = item.capdnompro;
                string pUnitario = item.caivpreuni.ToString("F2");
                string subtotal = item.caivsubtot.ToString("F2");

                // Recortar texto largo para que no se desborde en el ticket angosto
                if (descripcion.Length > 22)
                {
                    descripcion = descripcion.Substring(0, 20) + "..";
                }

                e.Graphics.DrawString(cantidad, fuenteNormal, pincel, new PointF(margenIzquierdo, posicionY));
                e.Graphics.DrawString(descripcion, fuenteNormal, pincel, new PointF(margenIzquierdo + 35, posicionY));
                e.Graphics.DrawString(pUnitario, fuenteNormal, pincel, new PointF(margenIzquierdo + 175, posicionY));
                e.Graphics.DrawString(subtotal, fuenteNormal, pincel, new PointF(margenIzquierdo + 220, posicionY));

                posicionY += 14;
            }

            e.Graphics.DrawLine(Pens.Black, margenIzquierdo, posicionY, margenIzquierdo + anchoTicket, posicionY);
            posicionY += 10;

            // 4. Totales
            e.Graphics.DrawString("TOTAL A PAGAR:", fuenteNegrita, pincel, new PointF(margenIzquierdo + 75, posicionY));
            e.Graphics.DrawString(total.ToString("F2"), fuenteNegrita, pincel, new PointF(margenIzquierdo + 210, posicionY));
            posicionY += 16;

            string numeroEnLetras = MetodosGenerales.ConvertirNumeroALetras(total);
            e.Graphics.DrawString("SON: " + numeroEnLetras + " BOLIVIANOS", fuenteNormal, pincel, new PointF(margenIzquierdo, posicionY));
            posicionY += 22;

            // 5. Pie de Página
            Font fuentePie = new Font("Consolas", 7, FontStyle.Italic);
            e.Graphics.DrawString("¡Gracias por su compra!", fuentePie, pincel, new PointF(margenIzquierdo + 55, posicionY));
        
        }
    }
}
