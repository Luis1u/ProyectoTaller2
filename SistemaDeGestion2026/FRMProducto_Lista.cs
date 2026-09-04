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
    public partial class FRMProducto_Lista : DevComponents.DotNetBar.Office2007Form
    {

        #region Variables 
        #endregion
        #region Constructor
        #endregion
        #region Metodos 
        #endregion
        #region Eventos
        #endregion
        private aproduc producto = new aproduc();


        private List<aproduc> lista_productos = new List<aproduc>();
        public FRMProducto_Lista()
        {
            InitializeComponent();
        }
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista_productos.Clear();
            lista_productos = producto.Lista("capdnompro like '%" + TXTFiltrar.Text + "%' or " +
                                           "capdmodpro like '%" + TXTFiltrar.Text + "%' or " +
                                           "capdmatpro like '%" + TXTFiltrar.Text + "%' or " +
                                           "capdcolpro like '%" + TXTFiltrar.Text + "%' limit " +
                                           IINFilas.Value.ToString()
                                           );
            foreach (aproduc a in lista_productos)
            {
                DTGLista.Rows.Add();
                if (a.capdestpro)
                {
                    if (DTGLista.Rows.Count % 2 == 0)
                    {
                        DTGLista.Rows[DTGLista.Rows.Count - 1].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                    }
                }
                else
                {
                    DTGLista.Rows[DTGLista.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Salmon;
                }
                DTGLista[0, DTGLista.Rows.Count - 1].Value = a.papdcodpro;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.capdestpro;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.capdnompro;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.capdmarpro;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.capdmodpro;

                DTGLista[5, DTGLista.Rows.Count - 1].Value = a.capdcatpro;
                DTGLista[6, DTGLista.Rows.Count - 1].Value = a.capdgenpro;
                DTGLista[7, DTGLista.Rows.Count - 1].Value = a.capdpreven;
                DTGLista[8, DTGLista.Rows.Count - 1].Value = a.capdstopro;



            }

        }
        private void FRMProducto_Lista_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ActualizarGrid();
        }

        private void BTNRegistrar_Click(object sender, EventArgs e)
        {
            FRMProducto_Registar p = new FRMProducto_Registar();
            p.ShowDialog();
            ActualizarGrid();
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMProducto_Registar F1 = new FRMProducto_Registar();
                F1.modificar = true;
                F1.codProMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                F1.ShowDialog();
                if (F1.actualizar)
                {
                    ActualizarGrid();
                }
            }
        }

        private void EPNFiltrar_Click(object sender, EventArgs e)
        {

        }

        private void DTGLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DTGLista.SelectedRows.Count > 0)
                {
                    FRMProducto_Registar F1 = new FRMProducto_Registar();
                    F1.modificar = true;
                    F1.codProMod = DTGLista[0, e.RowIndex].Value.ToString();
                    F1.ShowDialog();
                    if (F1.actualizar)
                    {
                        ActualizarGrid();
                    }
                }
            }
        }

        private void CMSMenu_Opening(object sender, CancelEventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                producto.papdcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (producto.ObtenerDatos())
                {
                    if (producto.capdestpro)
                    {
                        CMSMenu.Items[2].Visible = false;
                        CMSMenu.Items[1].Visible = true;

                    }
                    else
                    {
                        CMSMenu.Items[2].Visible = true;
                        CMSMenu.Items[1].Visible = false;
                    }
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMProducto_Registar F1 = new FRMProducto_Registar();
                F1.modificar = true;
                F1.codProMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                F1.ShowDialog();
                if (F1.actualizar)
                {
                    ActualizarGrid();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                producto.papdcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (producto.ObtenerDatos())
                {
                    producto.capdestpro = false;
                    if (producto.Modificar())
                    {
                        MessageBox.Show("Producto inhabilitado correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                producto.papdcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (producto.ObtenerDatos())
                {
                    producto.capdestpro = true;
                    if (producto.Modificar())
                    {
                        MessageBox.Show("Producto habilitado correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }
    }
}
