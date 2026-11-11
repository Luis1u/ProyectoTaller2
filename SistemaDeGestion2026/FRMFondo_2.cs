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
    public partial class FRMFondo_2 : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
            public aususis usuario = new aususis();
            public aperson persona = new aperson();
        #endregion

        #region Constructor
        public FRMFondo_2()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void TMRReloj_Tick(object sender, EventArgs e)
        {
            LBLFecha.Text = DateTime.Now.ToString("F");
        }

        private void FRMFondo_2_Load(object sender, EventArgs e)
        {
            TMRReloj.Enabled = true;
            LBLUsuario.Text = "Usuario: " + 
                              persona.capsapepat + " " + 
                              persona.capsapemat + " " + 
                              persona.capsnomper;
        }

        private void FRMFondo_2_FormClosed(object sender, FormClosedEventArgs e)
        {
            TMRReloj.Enabled = false;
        }
        #endregion

        private void LBLFecha_Click(object sender, EventArgs e)
        {

        }
    }
}
