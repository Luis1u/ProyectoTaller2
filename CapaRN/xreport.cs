using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaRN
{
    public class xreport
    {
        #region Variables
        private string _titulo = "LISTADO GENERAL EMPLEADOS";
        private string _descripcion = "";
        private bool _hoja = false;
        private bool _orientacion = true;
        private int _letra = 0;


        #endregion

        #region Propiedades
        public string titulo
        {
            get { return this._titulo; }
            set { this._titulo = value; }
        }
        public string descripcion
        {
            get { return this._descripcion; }
            set { this._descripcion = value; }
        }
        public bool hoja
        {
            get { return this._hoja; }
            set { this._hoja = value; }
        }
        public bool orientacion
        {
            get { return this._orientacion; }
            set { this._orientacion = value; }
        }

        public int letra { get => _letra; set => _letra = value; }
        #endregion
        #region Constructor
        public xreport()
        {
            this._titulo = "";
            this._descripcion = "";
            this._hoja = true;
            this._orientacion = true;
            this._letra = 0;
        }
        #endregion
        #region Metodos
        public void GenerarReporte(int  columnas ,  float[] anchoColumnas, List<string> titulosColumnas, List<aperson> listaPersonas)
        {

            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.Title = "Nombre del archivo a guardar";
            Guardar.Filter = "Archivo PDF|*.pdf";

            if (Guardar.ShowDialog() == DialogResult.OK)
            {
               iTextSharp.text.Rectangle Hoja = new iTextSharp.text.Rectangle(0, 0, 0, 0);
                if (this.hoja)
                { Hoja = PageSize.A4; }
                else
                { Hoja = PageSize.LETTER; }

                if (this.orientacion)
                {
                    Hoja = Hoja.Rotate();
                }


                iTextSharp.text.Font Fondo11 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 9,iTextSharp.text.Font.BOLD | iTextSharp.text.Font.ITALIC, new iTextSharp.text.Color(System.Drawing.Color.Gray));
                Document Documento = new Document(Hoja, 24, 24, 24, 24);


                //2do. PASO: Crear un escritor de documento PDF
                PdfWriter escritor = PdfWriter.GetInstance(Documento, new FileStream(Guardar.FileName, FileMode.Create));

                HeaderFooter footer = new HeaderFooter(new Phrase("Tienda de ropa Control V 1.0 - P�gina N� ", Fondo11), true);
                footer.Alignment = Element.ALIGN_RIGHT;
                footer.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.Gray);
                footer.BorderWidthBottom = 0;

                Documento.Footer = footer;


                //3er. PASO: Abrir el documento para escritura
                Documento.Open();

                iTextSharp.text.Font Fondo1 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            13,
                                                                            iTextSharp.text.Font.BOLD | iTextSharp.text.Font.ITALIC,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Gray));



                iTextSharp.text.Font Fondo2 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            letra,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo3 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            letra,
                                                                            iTextSharp.text.Font.NORMAL,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo22 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            12,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo33 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            12,
                                                                            iTextSharp.text.Font.NORMAL,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));


                iTextSharp.text.Font FondoT = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            14,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

            //4to. PASO: Escribir en el Documento

            Table Tabla = new Table(2);
            Tabla.Width = 50;
            Tabla.Alignment = Element.ALIGN_LEFT;
            float[] AnchosDeTabla = { 20, 80 };
            Tabla.Widths = AnchosDeTabla;
            Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);




            iTextSharp.text.Image Foto = iTextSharp.text.Image.GetInstance(
                                        Application.StartupPath + "\\imagenes\\ic_bolsa.png");
            Foto.Alignment = Element.ALIGN_CENTER;
            Foto.ScaleToFit(50, 70);

            Cell Celda = new Cell(Foto);
            Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
            Tabla.AddCell(Celda);

            Celda = new Cell();
            Celda.Add(new Paragraph(13, "Sistemas de Gestion 2026 \n" +
                                    "Bermejo - Bolivia \n", Fondo1));
            Celda.Add(new Paragraph(9, "Rep.Gen.: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " \n", Fondo11));

            Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
            Tabla.AddCell(Celda);
            Documento.Add(Tabla);




             //titulo del reporte
            Paragraph Parrafo = new Paragraph(this.titulo+ " \n", FondoT);
            Parrafo.Alignment = Element.ALIGN_CENTER;
            Documento.Add(Parrafo);



                //Descripcion del reporte
            Tabla = new Table(2);
            Tabla.Width = 100;
            Tabla.Alignment = Element.ALIGN_LEFT;
            float[] AnchosDeTabla3 = { 20, 80 };
            Tabla.Widths = AnchosDeTabla3;
            Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);

            Celda = new Cell(new Phrase(12, "Descripcion del Reporte: ", Fondo22));
            Celda.HorizontalAlignment = Element.ALIGN_LEFT;
            Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
            Tabla.AddCell(Celda);

            Celda = new Cell(new Phrase(12, this.descripcion, Fondo33));
            Celda.HorizontalAlignment = Element.ALIGN_LEFT;
            Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
            Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
            Tabla.AddCell(Celda);

            Documento.Add(Tabla);


            //Contenido del reporte




            Tabla = new Table(columnas);

            Tabla.Widths = anchoColumnas;
            Tabla.Alignment = Element.ALIGN_LEFT;
            Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.Black);
            Tabla.BorderWidth = 1.5F;
            Tabla.Width = 100;
            Tabla.DefaultCellBorderColor = new iTextSharp.text.Color(System.Drawing.Color.Black);
            //Tabla.Cellspacing = 2;
            Tabla.Cellpadding = 2;

            

            foreach (string a in titulosColumnas)
            {
                Celda = new Cell(new Phrase(10, a, Fondo2));
                Celda.BorderWidth = 1.5F;
                Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightGray);
                Tabla.AddCell(Celda);
            }

                //continuar ---- -- - - --- - --- - - - - -- - - - - - -   - - - - - - - - - ----------- -------- - - - - - - - - - --     ---- - - - - - - - - - - - - - -
                //--------------------------------------------------------------------------   
                int j = 0;

                foreach (aperson P in listaPersonas)
                {
                    Celda = new Cell(new Paragraph(P.papscodper.Substring(0, 7) + Convert.ToInt32(P.papscodper.Substring(7, P.papscodper.Length - 7)).ToString(), Fondo3));
                    if (!P.capsestper) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightSalmon); }
                    else if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    if (P.capsestper)
                        Celda = new Cell(new Paragraph("Habilitado", Fondo3));
                    else
                        Celda = new Cell(new Paragraph("Inhabilitado", Fondo3));
                    if (!P.capsestper) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightSalmon); }
                    else if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    Tabla.AddCell(Celda);

                    Celda = new Cell(new Paragraph(P.capsnumcid, Fondo3));
                    if (!P.capsestper) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightSalmon); }
                    else if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    Tabla.AddCell(Celda);

                    Celda = new Cell(new Paragraph(P.capsapepat, Fondo3));
                    if (!P.capsestper) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightSalmon); }
                    else if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    Celda = new Cell(new Paragraph(P.capsapemat, Fondo3));
                    if (!P.capsestper) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightSalmon); }
                    else if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    Celda = new Cell(new Paragraph(P.capsnomper, Fondo3));
                    if (!P.capsestper) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightSalmon); }
                    else if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    Celda = new Cell(new Paragraph(P.capsfecnac.ToShortDateString(), Fondo3));
                    if (!P.capsestper) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightSalmon); }
                    else if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    Tabla.AddCell(Celda);

                    if (P.capssexper)
                        Celda = new Cell(new Paragraph("Masculino", Fondo3));
                    else
                        Celda = new Cell(new Paragraph("Femenino", Fondo3));
                    if (!P.capsestper) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightSalmon); }
                    else if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    Tabla.AddCell(Celda);
                    j++;
                }




                Documento.Add(Tabla);

                Documento.Close();






            }

        #endregion

        }
    
       public void GenerarReporte(int columnas, float[] anchoColumnas, List<string> titulosColumnas, List<lproduc> listaProductos)
        {

            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.Title = "Nombre del archivo a guardar";
            Guardar.Filter = "Archivo PDF|*.pdf";

            if (Guardar.ShowDialog() == DialogResult.OK)
            {
                iTextSharp.text.Rectangle Hoja = new iTextSharp.text.Rectangle(0, 0, 0, 0);
                if (this.hoja)
                { Hoja = PageSize.A4; }
                else
                { Hoja = PageSize.LETTER; }

                if (this.orientacion)
                {
                    Hoja = Hoja.Rotate();
                }


                iTextSharp.text.Font Fondo11 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD | iTextSharp.text.Font.ITALIC, new iTextSharp.text.Color(System.Drawing.Color.Gray));
                Document Documento = new Document(Hoja, 24, 24, 24, 24);


                //2do. PASO: Crear un escritor de documento PDF
                PdfWriter escritor = PdfWriter.GetInstance(Documento, new FileStream(Guardar.FileName, FileMode.Create));

                HeaderFooter footer = new HeaderFooter(new Phrase("Tienda de ropa Control V 1.0 - P�gina N� ", Fondo11), true);
                footer.Alignment = Element.ALIGN_RIGHT;
                footer.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.Gray);
                footer.BorderWidthBottom = 0;

                Documento.Footer = footer;


                //3er. PASO: Abrir el documento para escritura
                Documento.Open();

                iTextSharp.text.Font Fondo1 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            13,
                                                                            iTextSharp.text.Font.BOLD | iTextSharp.text.Font.ITALIC,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Gray));



                iTextSharp.text.Font Fondo2 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            letra,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo3 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            letra,
                                                                            iTextSharp.text.Font.NORMAL,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo22 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            12,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo33 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            12,
                                                                            iTextSharp.text.Font.NORMAL,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));


                iTextSharp.text.Font FondoT = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            14,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                //4to. PASO: Escribir en el Documento

                Table Tabla = new Table(2);
                Tabla.Width = 50;
                Tabla.Alignment = Element.ALIGN_LEFT;
                float[] AnchosDeTabla = { 20, 80 };
                Tabla.Widths = AnchosDeTabla;
                Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);




                iTextSharp.text.Image Foto = iTextSharp.text.Image.GetInstance(
                                            Application.StartupPath + "\\imagenes\\ic_bolsa.png");
                Foto.Alignment = Element.ALIGN_CENTER;
                Foto.ScaleToFit(50, 70);

                Cell Celda = new Cell(Foto);
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);

                Celda = new Cell();
                Celda.Add(new Paragraph(13, "Sistemas de Gestion 2026 \n" +
                                        "Bermejo - Bolivia \n", Fondo1));
                Celda.Add(new Paragraph(9, "Rep.Gen.: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " \n", Fondo11));

                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);
                Documento.Add(Tabla);




                //titulo del reporte
                Paragraph Parrafo = new Paragraph(this.titulo + " \n", FondoT);
                Parrafo.Alignment = Element.ALIGN_CENTER;
                Documento.Add(Parrafo);



                //Descripcion del reporte
                Tabla = new Table(2);
                Tabla.Width = 100;
                Tabla.Alignment = Element.ALIGN_LEFT;
                float[] AnchosDeTabla3 = { 20, 80 };
                Tabla.Widths = AnchosDeTabla3;
                Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);

                Celda = new Cell(new Phrase(12, "Descripcion del Reporte: ", Fondo22));
                Celda.HorizontalAlignment = Element.ALIGN_LEFT;
                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);

                Celda = new Cell(new Phrase(12, this.descripcion, Fondo33));
                Celda.HorizontalAlignment = Element.ALIGN_LEFT;
                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);

                Documento.Add(Tabla);


                //Contenido del reporte




                Tabla = new Table(columnas);

                Tabla.Widths = anchoColumnas;
                Tabla.Alignment = Element.ALIGN_LEFT;
                Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.Black);
                Tabla.BorderWidth = 1.5F;
                Tabla.Width = 100;
                Tabla.DefaultCellBorderColor = new iTextSharp.text.Color(System.Drawing.Color.Black);
                //Tabla.Cellspacing = 2;
                Tabla.Cellpadding = 2;



                foreach (string a in titulosColumnas)
                {
                    Celda = new Cell(new Phrase(10, a, Fondo2));
                    Celda.BorderWidth = 1.5F;
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightGray);
                    Tabla.AddCell(Celda);
                }

                //continuar ---- -- - - --- - --- - - - - -- - - - - - -   - - - - - - - - - ----------- -------- - - - - - - - - - --     ---- - - - - - - - - - - - - - -
                //--------------------------------------------------------------------------   
                int j = 0;
                foreach (lproduc P in listaProductos)
                {
                    // 0. Código (papdcodpro)
                    Celda = new Cell(new Paragraph(new Chunk(P.papdcodpro?.ToString() ?? "", Fondo3)));
                    if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    // 1. Cod Barras (capdcodbar)
                    Celda = new Cell(new Paragraph(new Chunk(P.capdcodbar?.ToString() ?? "", Fondo3)));
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    // 2. Producto (capdnompro)
                    Celda = new Cell(new Paragraph(new Chunk(P.capdnompro?.ToString() ?? "", Fondo3)));
                    if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    // 3. Categoria (cacpnomcat)
                    Celda = new Cell(new Paragraph(new Chunk(P.cacpnomcat?.ToString() ?? "", Fondo3)));
                    if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    // 4. Marca (capdmarpro)
                    Celda = new Cell(new Paragraph(new Chunk(P.capdmarpro?.ToString() ?? "", Fondo3)));
                    if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    // 5. Modelo (capdmodpro)
                    Celda = new Cell(new Paragraph(new Chunk(P.capdmodpro?.ToString() ?? "", Fondo3)));
                    if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    // 6. Color (capdcolpro)
                    Celda = new Cell(new Paragraph(new Chunk(P.capdcolpro?.ToString() ?? "", Fondo3)));
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    // 7. Talla (capdtalpro)
                    Celda = new Cell(new Paragraph(new Chunk(P.capdtalpro?.ToString() ?? "", Fondo3)));
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    // 8. Genero (capdgenpro)
                    Celda = new Cell(new Paragraph(new Chunk(P.capdgenpro?.ToString() ?? "", Fondo3)));
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    // 9. Stock (capdstopro) - Numérico alineado a la derecha
                    Celda = new Cell(new Paragraph(new Chunk(P.capdstopro.ToString(), Fondo3)));
                    Celda.HorizontalAlignment = Element.ALIGN_RIGHT;
                    if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    // 10. Precio de Venta (capdpreven) - Numérico con formato y alineado a la derecha
                    Celda = new Cell(new Paragraph(new Chunk(Convert.ToDecimal(P.capdpreven).ToString("N2"), Fondo3)));
                    Celda.HorizontalAlignment = Element.ALIGN_RIGHT;
                    if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightBlue); }
                    Tabla.AddCell(Celda);

                    j++;
                }




                Documento.Add(Tabla);

                Documento.Close();






            }



        }
        public void GenerarReporte(int columnas, float[] anchoColumnas, List<string> titulosColumnas, List<lclient> listaClientes)
        {

            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.Title = "Nombre del archivo a guardar";
            Guardar.Filter = "Archivo PDF|*.pdf";

            if (Guardar.ShowDialog() == DialogResult.OK)
            {
                iTextSharp.text.Rectangle Hoja = new iTextSharp.text.Rectangle(0, 0, 0, 0);
                if (this.hoja)
                { Hoja = PageSize.A4; }
                else
                { Hoja = PageSize.LETTER; }

                if (this.orientacion)
                {
                    Hoja = Hoja.Rotate();
                }


                iTextSharp.text.Font Fondo11 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN, 9, iTextSharp.text.Font.BOLD | iTextSharp.text.Font.ITALIC, new iTextSharp.text.Color(System.Drawing.Color.Gray));
                Document Documento = new Document(Hoja, 24, 24, 24, 24);


                //2do. PASO: Crear un escritor de documento PDF
                PdfWriter escritor = PdfWriter.GetInstance(Documento, new FileStream(Guardar.FileName, FileMode.Create));

                HeaderFooter footer = new HeaderFooter(new Phrase("Tienda de ropa Control V 1.0 - P�gina N� ", Fondo11), true);
                footer.Alignment = Element.ALIGN_RIGHT;
                footer.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.Gray);
                footer.BorderWidthBottom = 0;

                Documento.Footer = footer;


                //3er. PASO: Abrir el documento para escritura
                Documento.Open();

                iTextSharp.text.Font Fondo1 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            13,
                                                                            iTextSharp.text.Font.BOLD | iTextSharp.text.Font.ITALIC,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Gray));



                iTextSharp.text.Font Fondo2 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            letra,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo3 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            letra,
                                                                            iTextSharp.text.Font.NORMAL,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo22 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            12,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                iTextSharp.text.Font Fondo33 = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            12,
                                                                            iTextSharp.text.Font.NORMAL,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));


                iTextSharp.text.Font FondoT = new iTextSharp.text.Font(iTextSharp.text.Font.TIMES_ROMAN,
                                                                            14,
                                                                            iTextSharp.text.Font.BOLD,
                                                                            new iTextSharp.text.Color(System.Drawing.Color.Black));

                //4to. PASO: Escribir en el Documento

                Table Tabla = new Table(2);
                Tabla.Width = 50;
                Tabla.Alignment = Element.ALIGN_LEFT;
                float[] AnchosDeTabla = { 20, 80 };
                Tabla.Widths = AnchosDeTabla;
                Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);




                iTextSharp.text.Image Foto = iTextSharp.text.Image.GetInstance(
                                            Application.StartupPath + "\\imagenes\\ic_bolsa.png");
                Foto.Alignment = Element.ALIGN_CENTER;
                Foto.ScaleToFit(50, 70);

                Cell Celda = new Cell(Foto);
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);

                Celda = new Cell();
                Celda.Add(new Paragraph(13, "Sistemas de Gestion 2026 \n" +
                                        "Bermejo - Bolivia \n", Fondo1));
                Celda.Add(new Paragraph(9, "Rep.Gen.: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " \n", Fondo11));

                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);
                Documento.Add(Tabla);




                //titulo del reporte
                Paragraph Parrafo = new Paragraph(this.titulo + " \n", FondoT);
                Parrafo.Alignment = Element.ALIGN_CENTER;
                Documento.Add(Parrafo);



                //Descripcion del reporte
                Tabla = new Table(2);
                Tabla.Width = 100;
                Tabla.Alignment = Element.ALIGN_LEFT;
                float[] AnchosDeTabla3 = { 20, 80 };
                Tabla.Widths = AnchosDeTabla3;
                Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);

                Celda = new Cell(new Phrase(12, "Descripcion del Reporte: ", Fondo22));
                Celda.HorizontalAlignment = Element.ALIGN_LEFT;
                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);

                Celda = new Cell(new Phrase(12, this.descripcion, Fondo33));
                Celda.HorizontalAlignment = Element.ALIGN_LEFT;
                Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                Celda.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.White);
                Tabla.AddCell(Celda);

                Documento.Add(Tabla);


                //Contenido del reporte




                Tabla = new Table(columnas);

                Tabla.Widths = anchoColumnas;
                Tabla.Alignment = Element.ALIGN_LEFT;
                Tabla.BorderColor = new iTextSharp.text.Color(System.Drawing.Color.Black);
                Tabla.BorderWidth = 1.5F;
                Tabla.Width = 100;
                Tabla.DefaultCellBorderColor = new iTextSharp.text.Color(System.Drawing.Color.Black);
                //Tabla.Cellspacing = 2;
                Tabla.Cellpadding = 2;



                foreach (string a in titulosColumnas)
                {
                    Celda = new Cell(new Phrase(10, a, Fondo2));
                    Celda.BorderWidth = 1.5F;
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    Celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.LightGray);
                    Tabla.AddCell(Celda);
                }

                //continuar ---- -- - - --- - --- - - - - -- - - - - - -   - - - - - - - - - ----------- -------- - - - - - - - - - --     ---- - - - - - - - - - - - - - -
                //--------------------------------------------------------------------------   
                int j = 0;
                foreach (lclient P in listaClientes)
                {
                    // 0. Código de Cliente (pacecodcli)
                    Celda = new Cell(new Paragraph(new Chunk(P.pacecodcli?.ToString() ?? "", Fondo3)));
                    if (j % 2 == 0 && P.caceestcli) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.PaleGoldenrod); }
                    Tabla.AddCell(Celda);

                    // 1. Estado / Habilitado o Inhabilitado (caceestcli - es bool)
                    string textoEstado = P.caceestcli ? "Habilitado" : "Inhabilitado";
                    Celda = new Cell(new Paragraph(new Chunk(textoEstado, Fondo3)));
                    if (!P.caceestcli)
                    {
                        Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Salmon);
                    }
                    else if (j % 2 == 0)
                    {
                        Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.PaleGoldenrod);
                    }
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    Tabla.AddCell(Celda);

                    // 2. Número de Documento / CID (capsnumcid)
                    Celda = new Cell(new Paragraph(new Chunk(P.capsnumcid?.ToString() ?? "", Fondo3)));
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    if (!P.caceestcli) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Salmon); }
                    else if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.PaleGoldenrod); }
                    Tabla.AddCell(Celda);

                    // 3. Nombre Completo (Apellidos y Nombres concatenados)
                    string nombreCompleto = $"{P.capsapepat} {P.capsapemat} {P.capsnomper}";
                    Celda = new Cell(new Paragraph(new Chunk(nombreCompleto, Fondo3)));
                    if (!P.caceestcli) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Salmon); }
                    else if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.PaleGoldenrod); }
                    Tabla.AddCell(Celda);

                    // 4. Razón Social (cacerazsoc)
                    Celda = new Cell(new Paragraph(new Chunk(P.cacerazsoc?.ToString() ?? "", Fondo3)));
                    if (!P.caceestcli) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Salmon); }
                    else if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.PaleGoldenrod); }
                    Tabla.AddCell(Celda);

                    // 5. NIT / Documento Tributario (cacenitcli)
                    Celda = new Cell(new Paragraph(new Chunk(P.cacenitcli?.ToString() ?? "", Fondo3)));
                    Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    if (!P.caceestcli) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.Salmon); }
                    else if (j % 2 == 0) { Celda.BackgroundColor = new iTextSharp.text.Color(System.Drawing.Color.PaleGoldenrod); }
                    Tabla.AddCell(Celda);

                    j++;
                }




                Documento.Add(Tabla);

                Documento.Close();






            }



        }
    }
}
