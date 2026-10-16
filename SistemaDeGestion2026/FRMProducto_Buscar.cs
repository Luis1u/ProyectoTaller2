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
    public partial class FRMProducto_Buscar : Form
    {
        #region Variables
        public lproduc lproduc = new lproduc();
        private List<lproduc> lista_productos= new List<lproduc>();

        public aproduc producto = new aproduc();
        public bool seleccionadoOk = false;
        public bool Productook = false;
        #endregion

        #region Constructor
        public FRMProducto_Buscar()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista_productos.Clear();
            lista_productos = lproduc.Lista("(capdmodpro like '%" + TXTFiltrar.Text + "%' or " +
                                             "capdcodbar like '%" + TXTFiltrar.Text + "%' or " +
                                             "capdnompro like '%" + TXTFiltrar.Text + "%' or " +
                                             "capdgenpro like '%" + TXTFiltrar.Text + "%' or " +
                                             "capdmarpro like '%" + TXTFiltrar.Text + "%' or " +
                                             "capdcolpro like '%" + TXTFiltrar.Text + "%' or " +
                                             "capdtalpro like '%" + TXTFiltrar.Text + "%' or " +
                                             "capddespro like '%" + TXTFiltrar.Text + "%' or " +
                                             "cacpnomcat like '%" + TXTFiltrar.Text + "%') and capdestpro = true limit " +
                                           IINFilas.Value.ToString()
                                           );
            foreach (lproduc a in lista_productos)
            {
               
                DTGLista.Rows.Add();
               
                
                DTGLista[0, DTGLista.Rows.Count - 1].Value = a.papdcodpro;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.capdestpro;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.capdmodpro;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.capdcodbar;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.capdnompro;
                DTGLista[5, DTGLista.Rows.Count - 1].Value = a.cacpnomcat;
                DTGLista[6, DTGLista.Rows.Count - 1].Value = a.capdgenpro;
                DTGLista[7, DTGLista.Rows.Count - 1].Value = a.capdmarpro;
                DTGLista[8, DTGLista.Rows.Count - 1].Value = a.capdcolpro;
                DTGLista[9, DTGLista.Rows.Count - 1].Value = a.capdtalpro;
                DTGLista[10, DTGLista.Rows.Count - 1].Value = a.capdstopro;
                DTGLista[11, DTGLista.Rows.Count - 1].Value = a.capdpreven;
                DTGLista[12, DTGLista.Rows.Count - 1].Value = a.capddespro;

            }

        }
        #endregion

        #region Eventos

        private void FRMProducto_Bucar_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count == 1)
            {
                producto.papdcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (producto.ObtenerDatos())
                {
                    seleccionadoOk = true;
                    this.Close();
                }
            }
        }

        private void BTNFiltrar_Click(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void DTGLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DTGLista.SelectedRows.Count == 1)
            {
                producto.papdcodpro= DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (producto.ObtenerDatos())
                {
                    seleccionadoOk = true;
                    this.Close();
                }
            }
        }
        #endregion
    }
}
