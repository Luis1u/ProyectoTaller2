namespace SistemaDeGestion2026
{
    partial class FRMIniciar_Sesion_Huella
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
            this.GPPanelPrincipal = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.LBLMensaje = new DevComponents.DotNetBar.LabelX();
            this.PCBHuella = new System.Windows.Forms.PictureBox();
            this.VCHuella = new DPFP.Gui.Verification.VerificationControl();
            this.GPPanelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCBHuella)).BeginInit();
            this.SuspendLayout();
            // 
            // GPPanelPrincipal
            // 
            this.GPPanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.GPPanelPrincipal.CanvasColor = System.Drawing.SystemColors.Control;
            this.GPPanelPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.GPPanelPrincipal.Controls.Add(this.VCHuella);
            this.GPPanelPrincipal.Controls.Add(this.PCBHuella);
            this.GPPanelPrincipal.Controls.Add(this.LBLMensaje);
            this.GPPanelPrincipal.DisabledBackColor = System.Drawing.Color.Empty;
            this.GPPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GPPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.GPPanelPrincipal.Name = "GPPanelPrincipal";
            this.GPPanelPrincipal.Size = new System.Drawing.Size(691, 162);
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
            this.GPPanelPrincipal.TabIndex = 1;
            this.GPPanelPrincipal.Text = "Usuario";
            // 
            // LBLMensaje
            // 
            // 
            // 
            // 
            this.LBLMensaje.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLMensaje.Dock = System.Windows.Forms.DockStyle.Left;
            this.LBLMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLMensaje.Location = new System.Drawing.Point(0, 0);
            this.LBLMensaje.Name = "LBLMensaje";
            this.LBLMensaje.Size = new System.Drawing.Size(548, 134);
            this.LBLMensaje.TabIndex = 0;
            this.LBLMensaje.Text = "Coloque su huella en el lector biométrico";
            this.LBLMensaje.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // PCBHuella
            // 
            this.PCBHuella.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCBHuella.Image = global::SistemaDeGestion2026.Properties.Resources.ic_iniciar_sesion_huella;
            this.PCBHuella.Location = new System.Drawing.Point(548, 0);
            this.PCBHuella.Name = "PCBHuella";
            this.PCBHuella.Size = new System.Drawing.Size(137, 134);
            this.PCBHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PCBHuella.TabIndex = 1;
            this.PCBHuella.TabStop = false;
            // 
            // VCHuella
            // 
            this.VCHuella.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.VCHuella.Location = new System.Drawing.Point(494, 0);
            this.VCHuella.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.VCHuella.Name = "VCHuella";
            this.VCHuella.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
            this.VCHuella.Size = new System.Drawing.Size(46, 52);
            this.VCHuella.TabIndex = 2;
            this.VCHuella.OnComplete += new DPFP.Gui.Verification.VerificationControl._OnComplete(this.VCHuella_OnComplete);
            // 
            // FRMIniciar_Sesion_Huella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 162);
            this.Controls.Add(this.GPPanelPrincipal);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRMIniciar_Sesion_Huella";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión con Huella";
            this.GPPanelPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PCBHuella)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel GPPanelPrincipal;
        private DPFP.Gui.Verification.VerificationControl VCHuella;
        private System.Windows.Forms.PictureBox PCBHuella;
        private DevComponents.DotNetBar.LabelX LBLMensaje;
    }
}