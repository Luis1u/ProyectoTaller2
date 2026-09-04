using CapaAD;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRN
{
    public class lclient
    {
        private bool _caceestcli;
        private string _cacerazsoc;
        private string _cacenitcli;
        private string _pacecodcli;
        private string _cacedircli;
        private string _facecodper;
        private string _cacetelcli;
        private CLConexionPGSQL Conexion;


        private DateTime _capsfecnac;
        private bool _capssexper;
        private bool _capsestper;
        private string _capsapemat;
        private string _capsnomper;
        private string _capsnumcel;
        private string _capscorele;
        private string _capsdirper;
        private string _papscodper;
        private string _capsfotper;
        private string _capsnumcid;
        private string _capsapepat;


        public bool caceestcli
        {
            get { return this._caceestcli; }
            set { this._caceestcli = value; }
        }
        public string cacerazsoc
        {
            get { return this._cacerazsoc; }
            set { this._cacerazsoc = value; }
        }
        public string cacenitcli
        {
            get { return this._cacenitcli; }
            set { this._cacenitcli = value; }
        }
        public string pacecodcli
        {
            get { return this._pacecodcli; }
            set { this._pacecodcli = value; }
        }
        public string cacedircli
        {
            get { return this._cacedircli; }
            set { this._cacedircli = value; }
        }
        public string facecodper
        {
            get { return this._facecodper; }
            set { this._facecodper = value; }
        }
        public string cacetelcli
        {
            get { return this._cacetelcli; }
            set { this._cacetelcli = value; }

        }

        public DateTime capsfecnac
        {
            get { return this._capsfecnac; }
            set { this._capsfecnac = value; }
        }
        public bool capssexper
        {
            get { return this._capssexper; }
            set { this._capssexper = value; }
        }
        public bool capsestper
        {
            get { return this._capsestper; }
            set { this._capsestper = value; }
        }
        public string capsapemat
        {
            get { return this._capsapemat; }
            set { this._capsapemat = value; }
        }
        public string capsnomper
        {
            get { return this._capsnomper; }
            set { this._capsnomper = value; }
        }
        public string capsnumcel
        {
            get { return this._capsnumcel; }
            set { this._capsnumcel = value; }
        }
        public string capscorele
        {
            get { return this._capscorele; }
            set { this._capscorele = value; }
        }
        public string capsdirper
        {
            get { return this._capsdirper; }
            set { this._capsdirper = value; }
        }
        public string papscodper
        {
            get { return this._papscodper; }
            set { this._papscodper = value; }
        }
        public string capsfotper
        {
            get { return this._capsfotper; }
            set { this._capsfotper = value; }
        }
        public string capsnumcid
        {
            get { return this._capsnumcid; }
            set { this._capsnumcid = value; }
        }
        public string capsapepat
        {
            get { return this._capsapepat; }
            set { this._capsapepat = value; }
        }

        public lclient()
        {
            this._caceestcli = true;
            this._cacerazsoc = "";
            this._cacenitcli = "";
            this._pacecodcli = "";
            this._cacedircli = "";
            this._facecodper = "";
            this._cacetelcli = "";

            this._capsfecnac = DateTime.Now;
            this._capssexper = true;
            this._capsestper = true;
            this._capsapemat = "";
            this._capsnomper = "";
            this._capsnumcel = "";
            this._capscorele = "";
            this._capsdirper = "";
            this._papscodper = "";
            this._capsfotper = "";
            this._capsnumcid = "";
            this._capsapepat = "";
            this.Conexion = new CLConexionPGSQL();
        }
        public List<lclient> Lista(string where)
        {
            List<lclient> ListaResultado = new List<lclient>();
            this.Conexion.Conectar();
            string sql = "select " +
                                     "caceestcli," +
                                     "cacerazsoc," +
                                     "cacenitcli," +
                                     "pacecodcli," +
                                     "cacedircli," +
                                     "facecodper," +
                                     "cacetelcli," +
                                     "capsfecnac," +
                                     "capssexper," +
                                     "capsestper," +
                                     "capsapemat," +
                                     "capsnomper," +
                                     "capsnumcel," +
                                     "capscorele," +
                                     "capsdirper," +
                                     "papscodper," +
                                     "capsfotper," +
                                     "capsnumcid," +
                                     "capsapepat " +
                         "from aclient,aperson " +
                         "where facecodper = papscodper ";

            if (where.Replace(" ", "") != "")
            {
                sql += "and " + where;
            }

            this.Conexion.PrepararComando(sql);
            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta != null)
            {
                while (ResultadoConsulta.Read())
                {
                    lclient Auxiliar = new lclient();
                    Auxiliar.caceestcli = ResultadoConsulta.GetBoolean(0);
                    Auxiliar.cacerazsoc = ResultadoConsulta.GetString(1);
                    Auxiliar.cacenitcli = ResultadoConsulta.GetString(2);
                    Auxiliar.pacecodcli = ResultadoConsulta.GetString(3);
                    Auxiliar.cacedircli = ResultadoConsulta.GetString(4);
                    Auxiliar.facecodper = ResultadoConsulta.GetString(5);
                    Auxiliar.cacetelcli = ResultadoConsulta.GetString(6);

                    Auxiliar.capsfecnac = ResultadoConsulta.GetDateTime(7);
                    Auxiliar.capssexper = ResultadoConsulta.GetBoolean(8);
                    Auxiliar.capsestper = ResultadoConsulta.GetBoolean(9);
                    Auxiliar.capsapemat = ResultadoConsulta.GetString(10);
                    Auxiliar.capsnomper = ResultadoConsulta.GetString(11);
                    Auxiliar.capsnumcel = ResultadoConsulta.GetString(12);
                    Auxiliar.capscorele = ResultadoConsulta.GetString(13);
                    Auxiliar.capsdirper = ResultadoConsulta.GetString(14);
                    Auxiliar.papscodper = ResultadoConsulta.GetString(15);
                    Auxiliar.capsfotper = ResultadoConsulta.GetString(16);
                    Auxiliar.capsnumcid = ResultadoConsulta.GetString(17);
                    Auxiliar.capsapepat = ResultadoConsulta.GetString(18);
                    ListaResultado.Add(Auxiliar);
                }

            }
            this.Conexion.Desconectar();
            return ListaResultado;
        }
    }
}