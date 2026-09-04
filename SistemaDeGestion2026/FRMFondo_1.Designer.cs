namespace SistemaDeGestion2026
{
    partial class FRMFondo_1
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
            this.LBLTitulo = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // LBLTitulo
            // 
            // 
            // 
            // 
            this.LBLTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBLTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLTitulo.Location = new System.Drawing.Point(0, 0);
            this.LBLTitulo.Name = "LBLTitulo";
            this.LBLTitulo.Size = new System.Drawing.Size(800, 450);
            this.LBLTitulo.TabIndex = 0;
            this.LBLTitulo.Text = "SISTEMA DE \r\nGESTIÓN 2026";
            this.LBLTitulo.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // FRMFondo_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LBLTitulo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRMFondo_1";
            this.Text = "FRMFondo_1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX LBLTitulo;
    }
}