using CapaAD;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRN
{
    public class lproduc
    {
        #region Campos
        private decimal _capdpreven;
        private decimal _capdpremin;
        private bool _capdestpro;
        private DateTime _capdfeccre;
        private DateTime _capdfecmod;
        private int _capdstopro;
        private string _capdcolpro;
        private string _capdgenpro;
        private string _capdtalpro;
        private string _capddespro;
        private string _capdfotpro;
        private string _papdcodpro;
        private string _fapdcodcat;
        private string _capdcodbar;
        private string _capdmodpro;
        private string _capdnompro;
        private string _capdmarpro;
        private string _capdmatpro;
        private bool _cacpestcat;
        private string _pacpcodcat;
        private string _cacpnomcat;
        //Instancia para conexion a PostgreSQL 8.2
        private CLConexionPGSQL Conexion;
        #endregion

        #region Propiedades
        public decimal capdpreven
        {
            get { return this._capdpreven; }
            set { this._capdpreven = value; }
        }
        public decimal capdpremin
        {
            get { return this._capdpremin; }
            set { this._capdpremin = value; }
        }
        public bool capdestpro
        {
            get { return this._capdestpro; }
            set { this._capdestpro = value; }
        }
        public DateTime capdfeccre
        {
            get { return this._capdfeccre; }
            set { this._capdfeccre = value; }
        }
        public DateTime capdfecmod
        {
            get { return this._capdfecmod; }
            set { this._capdfecmod = value; }
        }
        public int capdstopro
        {
            get { return this._capdstopro; }
            set { this._capdstopro = value; }
        }
        public string capdcolpro
        {
            get { return this._capdcolpro; }
            set { this._capdcolpro = value; }
        }
        public string capdgenpro
        {
            get { return this._capdgenpro; }
            set { this._capdgenpro = value; }
        }
        public string capdtalpro
        {
            get { return this._capdtalpro; }
            set { this._capdtalpro = value; }
        }
        public string capddespro
        {
            get { return this._capddespro; }
            set { this._capddespro = value; }
        }
        public string capdfotpro
        {
            get { return this._capdfotpro; }
            set { this._capdfotpro = value; }
        }
        public string papdcodpro
        {
            get { return this._papdcodpro; }
            set { this._papdcodpro = value; }
        }
        public string fapdcodcat
        {
            get { return this._fapdcodcat; }
            set { this._fapdcodcat = value; }
        }
        public string capdcodbar
        {
            get { return this._capdcodbar; }
            set { this._capdcodbar = value; }
        }
        public string capdmodpro
        {
            get { return this._capdmodpro; }
            set { this._capdmodpro = value; }
        }
        public string capdnompro
        {
            get { return this._capdnompro; }
            set { this._capdnompro = value; }
        }
        public string capdmarpro
        {
            get { return this._capdmarpro; }
            set { this._capdmarpro = value; }
        }
        public string capdmatpro
        {
            get { return this._capdmatpro; }
            set { this._capdmatpro = value; }
        }
        public bool cacpestcat
        {
            get { return this._cacpestcat; }
            set { this._cacpestcat = value; }
        }
        public string pacpcodcat
        {
            get { return this._pacpcodcat; }
            set { this._pacpcodcat = value; }
        }
        public string cacpnomcat
        {
            get { return this._cacpnomcat; }
            set { this._cacpnomcat = value; }
        }
        #endregion

        #region Constructor
        public lproduc()
        {
            this._capdpreven = 0;
            this._capdpremin = 0;
            this._capdestpro = true;
            this._capdfeccre = DateTime.Now;
            this._capdfecmod = DateTime.Now;
            this._capdstopro = 0;
            this._capdcolpro = "";
            this._capdgenpro = "";
            this._capdtalpro = "";
            this._capddespro = "";
            this._capdfotpro = "";
            this._papdcodpro = "";
            this._fapdcodcat = "";
            this._capdcodbar = "";
            this._capdmodpro = "";
            this._capdnompro = "";
            this._capdmarpro = "";
            this._capdmatpro = "";
            this._cacpestcat = true;
            this._pacpcodcat = "";
            this._cacpnomcat = "";
            this.Conexion = new CLConexionPGSQL();
        }
        #endregion

        #region Métodos


        public List<lproduc> Lista(string where)
        {
            List<lproduc> ListaResultado = new List<lproduc>();
            this.Conexion.Conectar();
            string sql = "select " +
                                 "capdpreven," +
                                 "capdpremin," +
                                 "capdestpro," +
                                 "capdfeccre," +
                                 "capdfecmod," +
                                 "capdstopro," +
                                 "capdcolpro," +
                                 "capdgenpro," +
                                 "capdtalpro," +
                                 "capddespro," +
                                 "capdfotpro," +
                                 "papdcodpro," +
                                 "fapdcodcat," +
                                 "capdcodbar," +
                                 "capdmodpro," +
                                 "capdnompro," +
                                 "capdmarpro," +
                                 "capdmatpro," +
                                 "cacpestcat," +
                                 "pacpcodcat," +
                                 "cacpnomcat " +
                         "from aproduc,acatpro " + 
                         "where aproduc.fapdcodcat = acatpro.pacpcodcat ";

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
                    lproduc Auxiliar = new lproduc();
                    Auxiliar.capdpreven = ResultadoConsulta.GetDecimal(0);
                    Auxiliar.capdpremin = ResultadoConsulta.GetDecimal(1);
                    Auxiliar.capdestpro = ResultadoConsulta.GetBoolean(2);
                    Auxiliar.capdfeccre = ResultadoConsulta.GetDateTime(3);
                    Auxiliar.capdfecmod = ResultadoConsulta.GetDateTime(4);
                    Auxiliar.capdstopro = ResultadoConsulta.GetInt32(5);
                    Auxiliar.capdcolpro = ResultadoConsulta.GetString(6);
                    Auxiliar.capdgenpro = ResultadoConsulta.GetString(7);
                    Auxiliar.capdtalpro = ResultadoConsulta.GetString(8);
                    Auxiliar.capddespro = ResultadoConsulta.GetString(9);
                    Auxiliar.capdfotpro = ResultadoConsulta.GetString(10);
                    Auxiliar.papdcodpro = ResultadoConsulta.GetString(11);
                    Auxiliar.fapdcodcat = ResultadoConsulta.GetString(12);
                    Auxiliar.capdcodbar = ResultadoConsulta.GetString(13);
                    Auxiliar.capdmodpro = ResultadoConsulta.GetString(14);
                    Auxiliar.capdnompro = ResultadoConsulta.GetString(15);
                    Auxiliar.capdmarpro = ResultadoConsulta.GetString(16);
                    Auxiliar.capdmatpro = ResultadoConsulta.GetString(17);
                    Auxiliar.cacpestcat = ResultadoConsulta.GetBoolean(18);
                    Auxiliar.pacpcodcat = ResultadoConsulta.GetString(19);
                    Auxiliar.cacpnomcat = ResultadoConsulta.GetString(20);
                    ListaResultado.Add(Auxiliar);
                }

            }
            this.Conexion.Desconectar();
            return ListaResultado;
        }
        #endregion
    }
}
