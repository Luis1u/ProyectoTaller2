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
        private lproduc lproduc = new lproduc();

        private aproduc producto = new aproduc();
        private List<lproduc> lista_productos = new List<lproduc>();
        #endregion

        #region Constructor
        public FRMProducto_Lista()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos
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
                                             "cacpnomcat like '%" + TXTFiltrar.Text + "%') limit " +
                                           IINFilas.Value.ToString()
                                           );
            foreach (lproduc a in lista_productos)
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
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.capdmodpro;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.capdcodbar;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.capdnompro;
                DTGLista[5, DTGLista.Rows.Count - 1].Value = a.fapdcodcat;
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
        private void FRMProducto_Lista_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ActualizarGrid();
        }

        private void BTNRegistrar_Click(object sender, EventArgs e)
        {
            FRMProducto_Registrar a = new FRMProducto_Registrar();
            a.ShowDialog();
            if (a.actualizar)
            {
                ActualizarGrid();
            }
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMProducto_Registrar F1 = new FRMProducto_Registrar();
                F1.modificar = true;
                F1.codProMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                F1.ShowDialog();
                if (F1.actualizar)
                {
                    ActualizarGrid();
                }
            }
        }

        private void DTGLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DTGLista.SelectedRows.Count > 0)
                {
                    FRMProducto_Registrar F1 = new FRMProducto_Registrar();
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

        private void BTNFiltrar_Click(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMProducto_Registrar F1 = new FRMProducto_Registrar();
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
            else
            {
                e.Cancel = true;
            }
        }

        private void TXTFiltrar_Enter(object sender, EventArgs e)
        {
            TXTFiltrar.SelectAll();
        }

        #endregion
    }
}
