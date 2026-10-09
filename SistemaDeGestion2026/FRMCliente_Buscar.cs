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
    public partial class FRMCliente_Buscar : Form
    {
        #region Variables
        public lclient lcliente= new lclient();
        private List<lclient> lista_clientes = new List<lclient>();

        public aclient cliente = new aclient();
        public bool seleccionadoOk = false;
        public String condicion = "";
        public bool clienteok = false;  
        #endregion

        #region Constructor
        public FRMCliente_Buscar()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista_clientes.Clear();
            lista_clientes = lcliente.Lista("(capsnumcid like '%" + TXTFiltrar.Text + "%' or " +
                                             "capsapepat like '%" + TXTFiltrar.Text + "%' or " +
                                             "capsapemat like '%" + TXTFiltrar.Text + "%' or " +
                                             "capsnomper like '%" + TXTFiltrar.Text + "%')and caceestcli=true limit " +
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
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.cacerazsoc;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.cacenitcli;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.cacetelcli;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.cacedircli;
               
            }
        }
        #endregion

        #region Evetos

        private void FRMCliente_Buscar_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void BTNAgregarPersona_Click(object sender, EventArgs e)
        {
            FRMCliente_Registrar a = new FRMCliente_Registrar();
            a.ShowDialog();
            if (a.actualizar)
            {
                ActualizarGrid();
            }
        }

        private void BTNFiltrar_Click_1(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void BTNAgregarPersona_Click_1(object sender, EventArgs e)
        {
            FRMCliente_Registrar a = new FRMCliente_Registrar();
            a.ShowDialog();
            if (a.actualizar)
            {
                ActualizarGrid();
            }
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count == 1)
            {
                cliente.pacecodcli = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (cliente.ObtenerDatos())
                {
                    seleccionadoOk = true;
                    this.Close();
                }
            }
        }

        private void DTGLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DTGLista.SelectedRows.Count == 1)
            {
                cliente.pacecodcli = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (cliente.ObtenerDatos())
                {
                    seleccionadoOk = true;
                    this.Close();
                }
            }
        }

        #endregion

    }
}
