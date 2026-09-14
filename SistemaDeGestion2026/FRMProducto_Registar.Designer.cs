namespace SistemaDeGestion2026
{
    partial class FRMProducto_Registar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMProducto_Registar));
            this.OFDElegirImagen = new System.Windows.Forms.OpenFileDialog();
            this.GPPanelPrincipal = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.CMBTalla = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CMBColor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CMBMaterial = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CMBMarca = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CMBNombreProducto = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CMBCategoria = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CMBGenero = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.HOMBRE = new DevComponents.Editors.ComboItem();
            this.MUJER = new DevComponents.Editors.ComboItem();
            this.UNISEX = new DevComponents.Editors.ComboItem();
            this.LBLCodigoDeBarras = new DevComponents.DotNetBar.LabelX();
            this.TXTDescripcion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.NUDPrecioMinVenta = new System.Windows.Forms.NumericUpDown();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.NUDPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.LBLPrecMinVen = new DevComponents.DotNetBar.LabelX();
            this.LBLPrecioVen = new DevComponents.DotNetBar.LabelX();
            this.GPFotografia = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.SWBEstadoProducto = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.BTNCodigoDeBarras = new DevComponents.DotNetBar.ButtonX();
            this.PCBFotografia = new System.Windows.Forms.PictureBox();
            this.BTNAbrirFoto = new DevComponents.DotNetBar.ButtonX();
            this.BTNLimpiarFoto = new DevComponents.DotNetBar.ButtonX();
            this.BTNCapturarFoto = new DevComponents.DotNetBar.ButtonX();
            this.PCBCamara = new System.Windows.Forms.PictureBox();
            this.BTNSalir = new DevComponents.DotNetBar.ButtonX();
            this.BTNLimpiar = new DevComponents.DotNetBar.ButtonX();
            this.BTNGrabar = new DevComponents.DotNetBar.ButtonX();
            this.TXTModelo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.GPPanelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPrecioMinVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPrecioVenta)).BeginInit();
            this.GPFotografia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCBFotografia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBCamara)).BeginInit();
            this.SuspendLayout();
            // 
            // OFDElegirImagen
            // 
            this.OFDElegirImagen.FileName = "openFileDialog1";
            // 
            // GPPanelPrincipal
            // 
            this.GPPanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.GPPanelPrincipal.CanvasColor = System.Drawing.SystemColors.Control;
            this.GPPanelPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.GPPanelPrincipal.Controls.Add(this.textBoxX1);
            this.GPPanelPrincipal.Controls.Add(this.BTNCodigoDeBarras);
            this.GPPanelPrincipal.Controls.Add(this.CMBTalla);
            this.GPPanelPrincipal.Controls.Add(this.CMBColor);
            this.GPPanelPrincipal.Controls.Add(this.CMBMaterial);
            this.GPPanelPrincipal.Controls.Add(this.CMBMarca);
            this.GPPanelPrincipal.Controls.Add(this.CMBNombreProducto);
            this.GPPanelPrincipal.Controls.Add(this.CMBCategoria);
            this.GPPanelPrincipal.Controls.Add(this.CMBGenero);
            this.GPPanelPrincipal.Controls.Add(this.LBLCodigoDeBarras);
            this.GPPanelPrincipal.Controls.Add(this.TXTDescripcion);
            this.GPPanelPrincipal.Controls.Add(this.NUDPrecioMinVenta);
            this.GPPanelPrincipal.Controls.Add(this.labelX1);
            this.GPPanelPrincipal.Controls.Add(this.NUDPrecioVenta);
            this.GPPanelPrincipal.Controls.Add(this.LBLPrecMinVen);
            this.GPPanelPrincipal.Controls.Add(this.LBLPrecioVen);
            this.GPPanelPrincipal.Controls.Add(this.GPFotografia);
            this.GPPanelPrincipal.Controls.Add(this.BTNSalir);
            this.GPPanelPrincipal.Controls.Add(this.BTNLimpiar);
            this.GPPanelPrincipal.Controls.Add(this.BTNGrabar);
            this.GPPanelPrincipal.Controls.Add(this.TXTModelo);
            this.GPPanelPrincipal.Controls.Add(this.SWBEstadoProducto);
            this.GPPanelPrincipal.DisabledBackColor = System.Drawing.Color.Empty;
            this.GPPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GPPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.GPPanelPrincipal.Name = "GPPanelPrincipal";
            this.GPPanelPrincipal.Size = new System.Drawing.Size(529, 472);
            // 
            // 
            // 
            this.GPPanelPrincipal.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.GPPanelPrincipal.Style.BackColorGradientAngle = 90;
            this.GPPanelPrincipal.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.GPPanelPrincipal.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPPanelPrincipal.Style.BorderBottomWidth = 1;
            this.GPPanelPrincipal.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.GPPanelPrincipal.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPPanelPrincipal.Style.BorderLeftWidth = 1;
            this.GPPanelPrincipal.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPPanelPrincipal.Style.BorderRightWidth = 1;
            this.GPPanelPrincipal.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPPanelPrincipal.Style.BorderTopWidth = 1;
            this.GPPanelPrincipal.Style.CornerDiameter = 4;
            this.GPPanelPrincipal.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.GPPanelPrincipal.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.GPPanelPrincipal.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.GPPanelPrincipal.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.GPPanelPrincipal.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.GPPanelPrincipal.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GPPanelPrincipal.TabIndex = 2;
            this.GPPanelPrincipal.Text = "Producto";
            // 
            // CMBTalla
            // 
            this.CMBTalla.DisplayMember = "Text";
            this.CMBTalla.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CMBTalla.FormattingEnabled = true;
            this.CMBTalla.ItemHeight = 17;
            this.CMBTalla.Location = new System.Drawing.Point(170, 185);
            this.CMBTalla.Name = "CMBTalla";
            this.CMBTalla.Size = new System.Drawing.Size(141, 23);
            this.CMBTalla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CMBTalla.TabIndex = 9;
            this.CMBTalla.Text = "TALLA";
            this.CMBTalla.WatermarkText = "TALLA";
            this.CMBTalla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CMBNombreProducto_KeyPress);
            // 
            // CMBColor
            // 
            this.CMBColor.DisplayMember = "Text";
            this.CMBColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CMBColor.FormattingEnabled = true;
            this.CMBColor.ItemHeight = 17;
            this.CMBColor.Location = new System.Drawing.Point(13, 186);
            this.CMBColor.Name = "CMBColor";
            this.CMBColor.Size = new System.Drawing.Size(151, 23);
            this.CMBColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CMBColor.TabIndex = 8;
            this.CMBColor.Text = "COLOR";
            this.CMBColor.WatermarkText = "COLOR";
            this.CMBColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CMBNombreProducto_KeyPress);
            // 
            // CMBMaterial
            // 
            this.CMBMaterial.DisplayMember = "Text";
            this.CMBMaterial.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CMBMaterial.FormattingEnabled = true;
            this.CMBMaterial.ItemHeight = 17;
            this.CMBMaterial.Location = new System.Drawing.Point(13, 156);
            this.CMBMaterial.Name = "CMBMaterial";
            this.CMBMaterial.Size = new System.Drawing.Size(300, 23);
            this.CMBMaterial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CMBMaterial.TabIndex = 7;
            this.CMBMaterial.Text = "MATERIAL";
            this.CMBMaterial.WatermarkText = "MATERIAL";
            this.CMBMaterial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CMBNombreProducto_KeyPress);
            // 
            // CMBMarca
            // 
            this.CMBMarca.DisplayMember = "Text";
            this.CMBMarca.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CMBMarca.FormattingEnabled = true;
            this.CMBMarca.ItemHeight = 17;
            this.CMBMarca.Location = new System.Drawing.Point(13, 128);
            this.CMBMarca.Name = "CMBMarca";
            this.CMBMarca.Size = new System.Drawing.Size(300, 23);
            this.CMBMarca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CMBMarca.TabIndex = 6;
            this.CMBMarca.Text = "MARCA";
            this.CMBMarca.WatermarkText = "MARCA";
            this.CMBMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CMBNombreProducto_KeyPress);
            // 
            // CMBNombreProducto
            // 
            this.CMBNombreProducto.DisplayMember = "Text";
            this.CMBNombreProducto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CMBNombreProducto.FormattingEnabled = true;
            this.CMBNombreProducto.ItemHeight = 17;
            this.CMBNombreProducto.Location = new System.Drawing.Point(13, 103);
            this.CMBNombreProducto.Name = "CMBNombreProducto";
            this.CMBNombreProducto.Size = new System.Drawing.Size(300, 23);
            this.CMBNombreProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CMBNombreProducto.TabIndex = 5;
            this.CMBNombreProducto.Text = " NOMBRE DEL PRODUCTO";
            this.CMBNombreProducto.WatermarkText = "NOMBRE DEL PRODUCTO";
            this.CMBNombreProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CMBNombreProducto_KeyPress);
            // 
            // CMBCategoria
            // 
            this.CMBCategoria.DisplayMember = "Text";
            this.CMBCategoria.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CMBCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBCategoria.FormattingEnabled = true;
            this.CMBCategoria.ItemHeight = 17;
            this.CMBCategoria.Location = new System.Drawing.Point(11, 74);
            this.CMBCategoria.Name = "CMBCategoria";
            this.CMBCategoria.Size = new System.Drawing.Size(300, 23);
            this.CMBCategoria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CMBCategoria.TabIndex = 4;
            this.CMBCategoria.WatermarkText = "CATEGORIA";
            // 
            // CMBGenero
            // 
            this.CMBGenero.DisplayMember = "Text";
            this.CMBGenero.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CMBGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMBGenero.FormattingEnabled = true;
            this.CMBGenero.ItemHeight = 17;
            this.CMBGenero.Items.AddRange(new object[] {
            this.HOMBRE,
            this.MUJER,
            this.UNISEX});
            this.CMBGenero.Location = new System.Drawing.Point(170, 44);
            this.CMBGenero.Name = "CMBGenero";
            this.CMBGenero.Size = new System.Drawing.Size(141, 23);
            this.CMBGenero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CMBGenero.TabIndex = 3;
            this.CMBGenero.WatermarkText = "GENERO";
            this.CMBGenero.SelectedIndexChanged += new System.EventHandler(this.CMBGenero_SelectedIndexChanged);
            // 
            // HOMBRE
            // 
            this.HOMBRE.Text = "HOMBRE";
            // 
            // MUJER
            // 
            this.MUJER.Text = "MUJER";
            // 
            // UNISEX
            // 
            this.UNISEX.Text = "UNISEX";
            // 
            // LBLCodigoDeBarras
            // 
            this.LBLCodigoDeBarras.BackColor = System.Drawing.Color.LightGreen;
            // 
            // 
            // 
            this.LBLCodigoDeBarras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLCodigoDeBarras.Location = new System.Drawing.Point(170, 4);
            this.LBLCodigoDeBarras.Name = "LBLCodigoDeBarras";
            this.LBLCodigoDeBarras.Size = new System.Drawing.Size(112, 23);
            this.LBLCodigoDeBarras.TabIndex = 1;
            this.LBLCodigoDeBarras.Text = "SIN CODIGO";
            // 
            // TXTDescripcion
            // 
            this.TXTDescripcion.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TXTDescripcion.Border.Class = "TextBoxBorder";
            this.TXTDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TXTDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXTDescripcion.DisabledBackColor = System.Drawing.Color.White;
            this.TXTDescripcion.ForeColor = System.Drawing.Color.Black;
            this.TXTDescripcion.Location = new System.Drawing.Point(7, 213);
            this.TXTDescripcion.Multiline = true;
            this.TXTDescripcion.Name = "TXTDescripcion";
            this.TXTDescripcion.PreventEnterBeep = true;
            this.TXTDescripcion.Size = new System.Drawing.Size(304, 58);
            this.TXTDescripcion.TabIndex = 10;
            this.TXTDescripcion.Text = "DESCRIPCION";
            this.TXTDescripcion.WatermarkText = "DESCRIPCION";
            // 
            // NUDPrecioMinVenta
            // 
            this.NUDPrecioMinVenta.DecimalPlaces = 2;
            this.NUDPrecioMinVenta.Location = new System.Drawing.Point(128, 345);
            this.NUDPrecioMinVenta.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            131072});
            this.NUDPrecioMinVenta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDPrecioMinVenta.Name = "NUDPrecioMinVenta";
            this.NUDPrecioMinVenta.Size = new System.Drawing.Size(183, 23);
            this.NUDPrecioMinVenta.TabIndex = 12;
            this.NUDPrecioMinVenta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(11, 344);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(101, 23);
            this.labelX1.TabIndex = 29;
            this.labelX1.Text = "Precio Minimo :";
            // 
            // NUDPrecioVenta
            // 
            this.NUDPrecioVenta.DecimalPlaces = 2;
            this.NUDPrecioVenta.Location = new System.Drawing.Point(128, 316);
            this.NUDPrecioVenta.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            131072});
            this.NUDPrecioVenta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDPrecioVenta.Name = "NUDPrecioVenta";
            this.NUDPrecioVenta.Size = new System.Drawing.Size(183, 23);
            this.NUDPrecioVenta.TabIndex = 11;
            this.NUDPrecioVenta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LBLPrecMinVen
            // 
            // 
            // 
            // 
            this.LBLPrecMinVen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLPrecMinVen.Location = new System.Drawing.Point(10, 286);
            this.LBLPrecMinVen.Name = "LBLPrecMinVen";
            this.LBLPrecMinVen.Size = new System.Drawing.Size(89, 23);
            this.LBLPrecMinVen.TabIndex = 10;
            this.LBLPrecMinVen.Text = "Stock Actual :";
            // 
            // LBLPrecioVen
            // 
            // 
            // 
            // 
            this.LBLPrecioVen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLPrecioVen.Location = new System.Drawing.Point(9, 315);
            this.LBLPrecioVen.Name = "LBLPrecioVen";
            this.LBLPrecioVen.Size = new System.Drawing.Size(101, 23);
            this.LBLPrecioVen.TabIndex = 12;
            this.LBLPrecioVen.Text = "Precio de venta :";
            // 
            // GPFotografia
            // 
            this.GPFotografia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.GPFotografia.CanvasColor = System.Drawing.SystemColors.Control;
            this.GPFotografia.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.GPFotografia.Controls.Add(this.PCBFotografia);
            this.GPFotografia.Controls.Add(this.BTNAbrirFoto);
            this.GPFotografia.Controls.Add(this.BTNLimpiarFoto);
            this.GPFotografia.Controls.Add(this.BTNCapturarFoto);
            this.GPFotografia.Controls.Add(this.PCBCamara);
            this.GPFotografia.DisabledBackColor = System.Drawing.Color.Empty;
            this.GPFotografia.Location = new System.Drawing.Point(328, 3);
            this.GPFotografia.Name = "GPFotografia";
            this.GPFotografia.Size = new System.Drawing.Size(186, 381);
            // 
            // 
            // 
            this.GPFotografia.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.GPFotografia.Style.BackColorGradientAngle = 90;
            this.GPFotografia.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.GPFotografia.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPFotografia.Style.BorderBottomWidth = 1;
            this.GPFotografia.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.GPFotografia.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPFotografia.Style.BorderLeftWidth = 1;
            this.GPFotografia.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPFotografia.Style.BorderRightWidth = 1;
            this.GPFotografia.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPFotografia.Style.BorderTopWidth = 1;
            this.GPFotografia.Style.CornerDiameter = 4;
            this.GPFotografia.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.GPFotografia.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.GPFotografia.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.GPFotografia.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.GPFotografia.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.GPFotografia.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GPFotografia.TabIndex = 17;
            this.GPFotografia.Text = "Fotografía";
            // 
            // SWBEstadoProducto
            // 
            // 
            // 
            // 
            this.SWBEstadoProducto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SWBEstadoProducto.Location = new System.Drawing.Point(9, 3);
            this.SWBEstadoProducto.Name = "SWBEstadoProducto";
            this.SWBEstadoProducto.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SWBEstadoProducto.OffText = "Inhabilitado";
            this.SWBEstadoProducto.OffTextColor = System.Drawing.Color.White;
            this.SWBEstadoProducto.OnBackColor = System.Drawing.Color.LimeGreen;
            this.SWBEstadoProducto.OnText = "Habilitado";
            this.SWBEstadoProducto.OnTextColor = System.Drawing.Color.White;
            this.SWBEstadoProducto.Size = new System.Drawing.Size(149, 26);
            this.SWBEstadoProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SWBEstadoProducto.TabIndex = 0;
            this.SWBEstadoProducto.Value = true;
            this.SWBEstadoProducto.ValueObject = "Y";
            // 
            // BTNCodigoDeBarras
            // 
            this.BTNCodigoDeBarras.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNCodigoDeBarras.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNCodigoDeBarras.Image = ((System.Drawing.Image)(resources.GetObject("BTNCodigoDeBarras.Image")));
            this.BTNCodigoDeBarras.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.BTNCodigoDeBarras.Location = new System.Drawing.Point(288, 4);
            this.BTNCodigoDeBarras.Name = "BTNCodigoDeBarras";
            this.BTNCodigoDeBarras.Size = new System.Drawing.Size(27, 26);
            this.BTNCodigoDeBarras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNCodigoDeBarras.TabIndex = 1;
            this.BTNCodigoDeBarras.Click += new System.EventHandler(this.BTNCodigoDeBarras_Click);
            this.BTNCodigoDeBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BTNCodigoDeBarras_KeyPress);
            // 
            // PCBFotografia
            // 
            this.PCBFotografia.BackColor = System.Drawing.Color.White;
            this.PCBFotografia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCBFotografia.Image = ((System.Drawing.Image)(resources.GetObject("PCBFotografia.Image")));
            this.PCBFotografia.Location = new System.Drawing.Point(3, 212);
            this.PCBFotografia.Name = "PCBFotografia";
            this.PCBFotografia.Size = new System.Drawing.Size(170, 132);
            this.PCBFotografia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PCBFotografia.TabIndex = 14;
            this.PCBFotografia.TabStop = false;
            // 
            // BTNAbrirFoto
            // 
            this.BTNAbrirFoto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNAbrirFoto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNAbrirFoto.Image = ((System.Drawing.Image)(resources.GetObject("BTNAbrirFoto.Image")));
            this.BTNAbrirFoto.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNAbrirFoto.Location = new System.Drawing.Point(62, 159);
            this.BTNAbrirFoto.Name = "BTNAbrirFoto";
            this.BTNAbrirFoto.Size = new System.Drawing.Size(48, 40);
            this.BTNAbrirFoto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNAbrirFoto.TabIndex = 2;
            this.BTNAbrirFoto.Click += new System.EventHandler(this.BTNAbrirFoto_Click_1);
            // 
            // BTNLimpiarFoto
            // 
            this.BTNLimpiarFoto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNLimpiarFoto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNLimpiarFoto.Image = ((System.Drawing.Image)(resources.GetObject("BTNLimpiarFoto.Image")));
            this.BTNLimpiarFoto.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNLimpiarFoto.Location = new System.Drawing.Point(125, 160);
            this.BTNLimpiarFoto.Name = "BTNLimpiarFoto";
            this.BTNLimpiarFoto.Size = new System.Drawing.Size(48, 40);
            this.BTNLimpiarFoto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNLimpiarFoto.TabIndex = 1;
            this.BTNLimpiarFoto.Click += new System.EventHandler(this.BTNLimpiarFoto_Click_1);
            // 
            // BTNCapturarFoto
            // 
            this.BTNCapturarFoto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNCapturarFoto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNCapturarFoto.Image = ((System.Drawing.Image)(resources.GetObject("BTNCapturarFoto.Image")));
            this.BTNCapturarFoto.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNCapturarFoto.Location = new System.Drawing.Point(3, 159);
            this.BTNCapturarFoto.Name = "BTNCapturarFoto";
            this.BTNCapturarFoto.Size = new System.Drawing.Size(48, 40);
            this.BTNCapturarFoto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNCapturarFoto.TabIndex = 0;
            this.BTNCapturarFoto.Click += new System.EventHandler(this.BTNCapturarFoto_Click_1);
            // 
            // PCBCamara
            // 
            this.PCBCamara.BackColor = System.Drawing.Color.White;
            this.PCBCamara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCBCamara.Image = ((System.Drawing.Image)(resources.GetObject("PCBCamara.Image")));
            this.PCBCamara.Location = new System.Drawing.Point(3, 8);
            this.PCBCamara.Name = "PCBCamara";
            this.PCBCamara.Size = new System.Drawing.Size(170, 132);
            this.PCBCamara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PCBCamara.TabIndex = 0;
            this.PCBCamara.TabStop = false;
            // 
            // BTNSalir
            // 
            this.BTNSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTNSalir.Image = ((System.Drawing.Image)(resources.GetObject("BTNSalir.Image")));
            this.BTNSalir.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNSalir.Location = new System.Drawing.Point(363, 390);
            this.BTNSalir.Name = "BTNSalir";
            this.BTNSalir.Size = new System.Drawing.Size(121, 51);
            this.BTNSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNSalir.TabIndex = 15;
            this.BTNSalir.Text = "&Salir";
            // 
            // BTNLimpiar
            // 
            this.BTNLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("BTNLimpiar.Image")));
            this.BTNLimpiar.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNLimpiar.Location = new System.Drawing.Point(192, 390);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(121, 51);
            this.BTNLimpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNLimpiar.TabIndex = 14;
            this.BTNLimpiar.Text = "&Limpiar";
            // 
            // BTNGrabar
            // 
            this.BTNGrabar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNGrabar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNGrabar.Image = ((System.Drawing.Image)(resources.GetObject("BTNGrabar.Image")));
            this.BTNGrabar.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNGrabar.Location = new System.Drawing.Point(30, 390);
            this.BTNGrabar.Name = "BTNGrabar";
            this.BTNGrabar.Size = new System.Drawing.Size(121, 51);
            this.BTNGrabar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNGrabar.TabIndex = 13;
            this.BTNGrabar.Text = "&Grabar";
            this.BTNGrabar.Click += new System.EventHandler(this.BTNGrabar_Click_1);
            // 
            // TXTModelo
            // 
            this.TXTModelo.AutoSelectAll = true;
            this.TXTModelo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TXTModelo.Border.Class = "TextBoxBorder";
            this.TXTModelo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TXTModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXTModelo.DisabledBackColor = System.Drawing.Color.White;
            this.TXTModelo.ForeColor = System.Drawing.Color.Black;
            this.TXTModelo.Location = new System.Drawing.Point(9, 44);
            this.TXTModelo.Name = "TXTModelo";
            this.TXTModelo.PreventEnterBeep = true;
            this.TXTModelo.Size = new System.Drawing.Size(148, 23);
            this.TXTModelo.TabIndex = 2;
            this.TXTModelo.WatermarkText = "MODELO";
            // 
            // textBoxX1
            // 
            this.textBoxX1.AutoSelectAll = true;
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxX1.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX1.Enabled = false;
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(128, 286);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(183, 23);
            this.textBoxX1.TabIndex = 30;
            this.textBoxX1.Text = "0";
            this.textBoxX1.WatermarkText = "0";
            // 
            // FRMProducto_Registar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 472);
            this.Controls.Add(this.GPPanelPrincipal);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRMProducto_Registar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMProducto_Registar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMProducto_Registar_FormClosing);
            this.Load += new System.EventHandler(this.FRMProducto_Registar_Load);
            this.GPPanelPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUDPrecioMinVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPrecioVenta)).EndInit();
            this.GPFotografia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PCBFotografia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBCamara)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OFDElegirImagen;
        private DevComponents.DotNetBar.Controls.GroupPanel GPPanelPrincipal;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CMBNombreProducto;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CMBCategoria;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CMBGenero;
        private DevComponents.DotNetBar.LabelX LBLCodigoDeBarras;
        private DevComponents.DotNetBar.Controls.TextBoxX TXTDescripcion;
        private System.Windows.Forms.NumericUpDown NUDPrecioMinVenta;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.NumericUpDown NUDPrecioVenta;
        private DevComponents.DotNetBar.LabelX LBLPrecMinVen;
        private DevComponents.DotNetBar.LabelX LBLPrecioVen;
        private DevComponents.DotNetBar.Controls.GroupPanel GPFotografia;
        private System.Windows.Forms.PictureBox PCBFotografia;
        private DevComponents.DotNetBar.ButtonX BTNAbrirFoto;
        private DevComponents.DotNetBar.ButtonX BTNLimpiarFoto;
        private DevComponents.DotNetBar.ButtonX BTNCapturarFoto;
        private System.Windows.Forms.PictureBox PCBCamara;
        private DevComponents.DotNetBar.ButtonX BTNSalir;
        private DevComponents.DotNetBar.ButtonX BTNLimpiar;
        private DevComponents.DotNetBar.ButtonX BTNGrabar;
        private DevComponents.DotNetBar.Controls.SwitchButton SWBEstadoProducto;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CMBTalla;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CMBColor;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CMBMaterial;
        private DevComponents.DotNetBar.Controls.ComboBoxEx CMBMarca;
        private DevComponents.DotNetBar.ButtonX BTNCodigoDeBarras;
        private DevComponents.Editors.ComboItem HOMBRE;
        private DevComponents.Editors.ComboItem MUJER;
        private DevComponents.Editors.ComboItem UNISEX;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX TXTModelo;
    }
}