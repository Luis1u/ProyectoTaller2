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
    public partial class FRMCliente_Lista : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private lclient lcliente= new lclient();
        private aclient aclient= new aclient();
        private List<lclient> lista_clientes = new List<lclient>();
        #endregion
        public FRMCliente_Lista()
        {
            InitializeComponent();
        }
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista_clientes.Clear();
            lista_clientes = lcliente.Lista("(capsnumcid like '%" + TXTFiltrar.Text + "%' or " +
                                             "capsapepat like '%" + TXTFiltrar.Text + "%' or " +
                                             "capsapemat like '%" + TXTFiltrar.Text + "%' or " +
                                             "capsnomper like '%" + TXTFiltrar.Text + "%') limit " +
                                           IINFilas.Value.ToString()
                                           );
            foreach (lclient a in lista_clientes)
            {
                DTGLista.Rows.Add();
                if (a.caceestcli)
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
                DTGLista[0, DTGLista.Rows.Count - 1].Value = a.pacecodcli;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.caceestcli;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.capsnumcid;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.capsapepat + " " +
                                                             a.capsapemat + " " +
                                                             a.capsnomper;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.cacerazsoc;
                DTGLista[5, DTGLista.Rows.Count - 1].Value = a.cacenitcli;
            }
        }

        private void BTNRegistrar_Click(object sender, EventArgs e)
        {
            FRMCliente_Registrar a = new FRMCliente_Registrar();    
            a.ShowDialog();
            if (a.actualizar)
            {
                ActualizarGrid();
            }
        }

        private void FRMCliente_Lista_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ActualizarGrid();
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMCliente_Registrar F1 = new FRMCliente_Registrar();
                F1.modificar = true;
                F1.codCliMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                F1.ShowDialog();
                if (F1.actualizar)
                {
                    ActualizarGrid();
                }
            }
        }

        private void BTNFiltrar_Click(object sender, EventArgs e)
        {

        }

        private void DTGLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DTGLista.SelectedRows.Count > 0)
                {
                    FRMCliente_Registrar F1 = new FRMCliente_Registrar();
                    F1.modificar = true;
                    F1.codCliMod = DTGLista[0, e.RowIndex].Value.ToString();
                    F1.ShowDialog();
                    if (F1.actualizar)
                    {
                        ActualizarGrid();
                    }
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMCliente_Registrar F1 = new FRMCliente_Registrar();
                F1.modificar = true;
                F1.codCliMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
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
                aclient.pacecodcli= DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (aclient.ObtenerDatos())
                {
                    aclient.caceestcli = false;
                    if (aclient.Modificar())
                    {
                        MessageBox.Show("Cliente inhabilitada correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                aclient.pacecodcli = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (aclient.ObtenerDatos())
                {
                    aclient.caceestcli = true;
                    if (aclient.Modificar())
                    {
                        MessageBox.Show("Cliente habilitado correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }

        private void CMSMenu_Opening(object sender, CancelEventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                aclient.pacecodcli = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (aclient.ObtenerDatos())
                {
                    if (aclient.caceestcli)
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
    }
}
