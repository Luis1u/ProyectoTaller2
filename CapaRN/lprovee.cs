using CapaAD;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRN
{
    public class lprovee
    {
        private bool _capvestpro;
        private string _capvrazsoc;
        private string _capvnitpro;
        private string _papvcodpro;
        private string _capvdirpro;
        private string _fapvcodper;
        private string _capvtelpro;
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


        public bool capvestpro
        {
            get { return this._capvestpro; }
            set { this._capvestpro = value; }
        }
        public string capvrazsoc
        {
            get { return this._capvrazsoc; }
            set { this._capvrazsoc = value; }
        }
        public string capvnitpro
        {
            get { return this._capvnitpro; }
            set { this._capvnitpro = value; }
        }
        public string papvcodpro
        {
            get { return this._papvcodpro; }
            set { this._papvcodpro = value; }
        }
        public string capvdirpro
        {
            get { return this._capvdirpro; }
            set { this._capvdirpro = value; }
        }
        public string fapvcodper
        {
            get { return this._fapvcodper; }
            set { this._fapvcodper = value; }
        }
        public string capvtelpro
        {
            get { return this._capvtelpro; }
            set { this._capvtelpro = value; }

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

        public lprovee()
        {
            this._capvestpro = true;
            this._capvrazsoc = "";
            this._capvnitpro = "";
            this._papvcodpro = "";
            this._capvdirpro = "";
            this._fapvcodper = "";
            this._capvtelpro = "";

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
        public List<lprovee> Lista(string where)
        {
            List<lprovee> ListaResultado = new List<lprovee>();
            this.Conexion.Conectar();
            string sql = "select " +
                                     "capvestpro," +
                                     "capvrazsoc," +
                                     "capvnitpro," +
                                     "papvcodpro," +
                                     "capvdirpro," +
                                     "fapvcodper," +
                                     "capvtelpro," +
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
                         "from aprovee,aperson " +
                         "where fapvcodper = papscodper ";

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
                    lprovee Auxiliar = new lprovee();
                    Auxiliar.capvestpro = ResultadoConsulta.GetBoolean(0);
                    Auxiliar.capvrazsoc = ResultadoConsulta.GetString(1);
                    Auxiliar.capvnitpro = ResultadoConsulta.GetString(2);
                    Auxiliar.papvcodpro = ResultadoConsulta.GetString(3);
                    Auxiliar.capvdirpro = ResultadoConsulta.GetString(4);
                    Auxiliar.fapvcodper = ResultadoConsulta.GetString(5);
                    Auxiliar.capvtelpro = ResultadoConsulta.GetString(6);

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
