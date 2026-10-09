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
    public partial class FRMCategoria_Lista : Form
    {
       private  acatpro categoria = new acatpro();
        private List<acatpro>  lista_categorias = new List<acatpro>(); 

        public FRMCategoria_Lista()
        {
            InitializeComponent();
        }

        private void BTNRegistrar_Click(object sender, EventArgs e)
        {
            FRMCategoria_Registrar a = new FRMCategoria_Registrar();
            a.ShowDialog();
            ActualizarGrid();
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMCategoria_Registrar F1 = new FRMCategoria_Registrar();
                F1.modificar = true;
                F1.codCatMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                F1.ShowDialog();
                if (F1.actualizar)
                {
                    ActualizarGrid();
                }
            }
        }
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista_categorias.Clear();
            lista_categorias = categoria.Lista("cacpnomcat like '%" + TXTFiltrar.Text + "%' limit " +
                                           IINFilas.Value.ToString()
                                           );
            foreach (acatpro a in lista_categorias)
            {
                DTGLista.Rows.Add();
                if (a.cacpestcat)
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
                DTGLista[0, DTGLista.Rows.Count - 1].Value = a.pacpcodcat;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.cacpestcat;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.cacpnomcat;
            }

        }

        private void EPNFiltrar_Click(object sender, EventArgs e)
        {

        }

        private void FRMCategoria_Lista_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ActualizarGrid();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMCategoria_Registrar F1 = new FRMCategoria_Registrar();
                F1.modificar = true;
                F1.codCatMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
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
                categoria.pacpcodcat = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (categoria.ObtenerDatos())
                {
                    categoria.cacpestcat = false;
                    if (categoria.Modificar())
                    {
                        MessageBox.Show("categoria inhabilitada correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                categoria.pacpcodcat = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (categoria.ObtenerDatos())
                {
                    categoria.cacpestcat = true;
                    if (categoria.Modificar())
                    {
                        MessageBox.Show("categoria habilitada correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }

        private void CMSMenu_Opening(object sender, CancelEventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                categoria.pacpcodcat= DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (categoria.ObtenerDatos())
                {
                    if (categoria.cacpestcat)
                    {

                        CMSMenu.Items[1].Visible = true;
                        CMSMenu.Items[2].Visible = false;

                    }
                    else
                    {
                        CMSMenu.Items[1].Visible = false;
                        CMSMenu.Items[2].Visible = true;
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void DTGLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DTGLista.SelectedRows.Count > 0)
                {
                    FRMCategoria_Registrar F1= new FRMCategoria_Registrar();
                    F1.modificar = true;
                    F1.codCatMod = DTGLista[0, e.RowIndex].Value.ToString();
                    F1.ShowDialog();
                    if (F1.actualizar)
                    {
                        ActualizarGrid();
                    }
                }
            }
        }
    }
}
