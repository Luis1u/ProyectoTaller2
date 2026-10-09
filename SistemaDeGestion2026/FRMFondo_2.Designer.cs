namespace SistemaDeGestion2026
{
    partial class FRMFondo_2
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
            this.components = new System.ComponentModel.Container();
            this.PNLBarraInferior = new DevComponents.DotNetBar.PanelEx();
            this.LBLFecha = new DevComponents.DotNetBar.LabelX();
            this.LBLUsuario = new DevComponents.DotNetBar.LabelX();
            this.TMRReloj = new System.Windows.Forms.Timer(this.components);
            this.PNLBarraInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // PNLBarraInferior
            // 
            this.PNLBarraInferior.CanvasColor = System.Drawing.SystemColors.Control;
            this.PNLBarraInferior.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PNLBarraInferior.Controls.Add(this.LBLFecha);
            this.PNLBarraInferior.Controls.Add(this.LBLUsuario);
            this.PNLBarraInferior.DisabledBackColor = System.Drawing.Color.Empty;
            this.PNLBarraInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PNLBarraInferior.Location = new System.Drawing.Point(0, 302);
            this.PNLBarraInferior.Margin = new System.Windows.Forms.Padding(4);
            this.PNLBarraInferior.Name = "PNLBarraInferior";
            this.PNLBarraInferior.Size = new System.Drawing.Size(764, 42);
            this.PNLBarraInferior.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PNLBarraInferior.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PNLBarraInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PNLBarraInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PNLBarraInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PNLBarraInferior.Style.GradientAngle = 90;
            this.PNLBarraInferior.TabIndex = 0;
            // 
            // LBLFecha
            // 
            // 
            // 
            // 
            this.LBLFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBLFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLFecha.Location = new System.Drawing.Point(411, 0);
            this.LBLFecha.Margin = new System.Windows.Forms.Padding(4);
            this.LBLFecha.Name = "LBLFecha";
            this.LBLFecha.PaddingRight = 10;
            this.LBLFecha.Size = new System.Drawing.Size(353, 42);
            this.LBLFecha.TabIndex = 1;
            this.LBLFecha.Text = "Bermejo";
            this.LBLFecha.TextAlignment = System.Drawing.StringAlignment.Far;
            this.LBLFecha.Click += new System.EventHandler(this.LBLFecha_Click);
            // 
            // LBLUsuario
            // 
            // 
            // 
            // 
            this.LBLUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.LBLUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLUsuario.Location = new System.Drawing.Point(0, 0);
            this.LBLUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.LBLUsuario.Name = "LBLUsuario";
            this.LBLUsuario.PaddingLeft = 10;
            this.LBLUsuario.Size = new System.Drawing.Size(411, 42);
            this.LBLUsuario.TabIndex = 0;
            this.LBLUsuario.Text = "Usuario: ";
            // 
            // TMRReloj
            // 
            this.TMRReloj.Interval = 1000;
            this.TMRReloj.Tick += new System.EventHandler(this.TMRReloj_Tick);
            // 
            // FRMFondo_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 344);
            this.Controls.Add(this.PNLBarraInferior);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRMFondo_2";
            this.Text = "FRMFondo_2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRMFondo_2_FormClosed);
            this.Load += new System.EventHandler(this.FRMFondo_2_Load);
            this.PNLBarraInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx PNLBarraInferior;
        private DevComponents.DotNetBar.LabelX LBLFecha;
        private DevComponents.DotNetBar.LabelX LBLUsuario;
        private System.Windows.Forms.Timer TMRReloj;
    }
}