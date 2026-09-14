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
    public partial class FRMProveedor_Lista : Form
    {
        #region Variables
        private lprovee lproveee = new lprovee();
        private aprovee aprovee = new aprovee();
        private List<lprovee> lista_proveedores = new List<lprovee>();
        #endregion
        public FRMProveedor_Lista()
        {
            InitializeComponent();
        }
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista_proveedores.Clear();
            lista_proveedores = lproveee.Lista("(capsnumcid like '%" + TXTFiltrar.Text + "%' or " +
                                             "capsapepat like '%" + TXTFiltrar.Text + "%' or " +
                                             "capsapemat like '%" + TXTFiltrar.Text + "%' or " +
                                             "capsnomper like '%" + TXTFiltrar.Text + "%') limit " +
                                           IINFilas.Value.ToString()
                                           );
            foreach (lprovee a in lista_proveedores)
            {
                DTGLista.Rows.Add();
                if (a.capvestpro)
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
                DTGLista[0, DTGLista.Rows.Count - 1].Value = a.papvcodpro;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.capvestpro;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.capsnumcid;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.capsapepat + " " +
                                                             a.capsapemat + " " +
                                                             a.capsnomper;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.capvrazsoc;
                DTGLista[5, DTGLista.Rows.Count - 1].Value = a.capvnitpro;
            }
        }


        private void FRMProveedor_Lista_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ActualizarGrid();
           
        }

        

        private void BTNRegistrar_Click(object sender, EventArgs e)
        {
            FRMProveedor_Registrar a = new FRMProveedor_Registrar();
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
                FRMProveedor_Registrar F1 = new FRMProveedor_Registrar();
                F1.modificar = true;
                F1.codProMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                F1.ShowDialog();
                if (F1.actualizar)
                {
                    ActualizarGrid();
                }
            }
        }

        private void CMSMenu_Opening(object sender, CancelEventArgs e)
        {

            if (DTGLista.SelectedRows.Count > 0)
            {
                aprovee.papvcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (aprovee.ObtenerDatos())
                {
                    if (aprovee.capvestpro)
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

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMProveedor_Registrar F1 = new FRMProveedor_Registrar();
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
                aprovee.papvcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (aprovee.ObtenerDatos())
                {
                    aprovee.capvestpro = false;
                    if (aprovee.Modificar())
                    {
                        MessageBox.Show("Proveedor inhabilitado correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                aprovee.papvcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (aprovee.ObtenerDatos())
                {
                    aprovee.capvestpro = true;
                    if (aprovee.Modificar())
                    {
                        MessageBox.Show("Proveedor habilitado correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }

        private void DTGLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DTGLista.SelectedRows.Count > 0)
                {
                    FRMProveedor_Registrar F1 = new FRMProveedor_Registrar();
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
    }
}
