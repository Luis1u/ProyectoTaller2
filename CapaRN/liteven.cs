using CapaAD;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaRN
{
    public class liteven
    {

        #region Campos
        private decimal _caivpreuni;
        private bool _caivestite;
        private int _caivcanite;
        private decimal _caivsubtot;
        private string _faivcodpro;
        private string _faivcodven;
        private string _paivcodite;

        private string _capdmodpro;
        private string _capdcodbar;
        private string _capdnompro;
        private string _capddespro;
        private string _capdtalpro;







        //Instancia para conexion a PostgreSQL 8.2
        private CLConexionPGSQL Conexion;
        #endregion

        #region Propiedades
        public decimal caivpreuni
        {
            get { return this._caivpreuni; }
            set { this._caivpreuni = value; }
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

        public string capdcodbar
        {
            get { return this._capdcodbar; }
            set { this._capdcodbar = value; }
        }
        public bool caivestite
        {
            get { return this._caivestite; }
            set { this._caivestite = value; }
        }
        public int caivcanite
        {
            get { return this._caivcanite; }
            set { this._caivcanite = value; }
        }
        public decimal caivsubtot
        {
            get { return this._caivsubtot; }
            set { this._caivsubtot = value; }
        }
        public string faivcodpro
        {
            get { return this._faivcodpro; }
            set { this._faivcodpro = value; }
        }
        public string faivcodven
        {
            get { return this._faivcodven; }
            set { this._faivcodven = value; }
        }
        public string paivcodite
        {
            get { return this._paivcodite; }
            set { this._paivcodite = value; }
        }
        #endregion

        #region Constructor
        public liteven()
        {
            this._caivpreuni = 0;
            this._caivestite = true;
            this._caivcanite = 0;
            this._caivsubtot = 0;
            this._faivcodpro = "";
            this._faivcodven = "";
            this._paivcodite = "";

            this._capdcodbar = "";
            this._capdnompro = "";
            this._capdtalpro = "";
            this._capddespro = "";
            this._capdmodpro = "";

            this.Conexion = new CLConexionPGSQL();
        }
        #endregion

        #region Metodos
        public bool ObtenerDatos()
        {
            this.Conexion.Conectar();
            string sql = "select " +
                                 "caivpreuni," +
                                 "caivestite," +
                                 "caivcanite," +
                                 "caivsubtot," +
                                 "faivcodpro," +
                                 "faivcodven," +
                                 "paivcodite " +
                         "from aiteven " +
                         "where " +
                                "paivcodite = @paivcodite";

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@paivcodite", this._paivcodite);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.Read())
            {
                this._caivpreuni = ResultadoConsulta.GetDecimal(0);
                this._caivestite = ResultadoConsulta.GetBoolean(1);
                this._caivcanite = ResultadoConsulta.GetInt32(2);
                this._caivsubtot = ResultadoConsulta.GetDecimal(3);
                this._faivcodpro = ResultadoConsulta.GetString(4);
                this._faivcodven = ResultadoConsulta.GetString(5);
                this._paivcodite = ResultadoConsulta.GetString(6);
                this.Conexion.Desconectar();

                return true;
            }
            else
            {
                this.Conexion.Desconectar();
                return false;
            }
        }
        public bool VerificarExistencia()
        {
            this.Conexion.Conectar();
            string sql = "select " +
                                 "caivpreuni," +
                                 "caivestite," +
                                 "caivcanite," +
                                 "caivsubtot," +
                                 "faivcodpro," +
                                 "faivcodven," +
                                 "paivcodite " +
                         "from aiteven " +
                         "where " +
                                "paivcodite = @paivcodite";

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@paivcodite", this._paivcodite);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.HasRows)
            {
                this.Conexion.Desconectar();

                return true;
            }
            else
            {

                this.Conexion.Desconectar();
                return false;
            }
        }
        public bool Grabar()
        {
            if (this.VerificarExistencia())
            {
                return false;
            }
            else
            {
                this.Conexion.Conectar();
                string sql = "insert into aiteven (" +
                                                   "caivpreuni," +
                                                   "caivestite," +
                                                   "caivcanite," +
                                                   "caivsubtot," +
                                                   "faivcodpro," +
                                                   "faivcodven," +
                                                   "paivcodite" +
                                                   ") " +
                             "values (" +
                                      "@caivpreuni," +
                                      "@caivestite," +
                                      "@caivcanite," +
                                      "@caivsubtot," +
                                      "@faivcodpro," +
                                      "@faivcodven," +
                                      "@paivcodite" +
                                                   ")";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroDecimal("@caivpreuni", this._caivpreuni);
                this.Conexion.AsignarParametroLogico("@caivestite", this._caivestite);
                this.Conexion.AsignarParametroEntero("@caivcanite", this._caivcanite);
                this.Conexion.AsignarParametroDecimal("@caivsubtot", this._caivsubtot);
                this.Conexion.AsignarParametroCadena("@faivcodpro", this._faivcodpro);
                this.Conexion.AsignarParametroCadena("@faivcodven", this._faivcodven);
                this.Conexion.AsignarParametroCadena("@paivcodite", this._paivcodite);

                this.Conexion.EjecutarTransaccion();
                this.Conexion.Desconectar();

                return true;
            }
        }
        public bool Modificar()
        {
            if (!this.VerificarExistencia())
            {
                return false;
            }
            else
            {
                this.Conexion.Conectar();
                string sql = "update aiteven set " +
                                                 "caivpreuni = @caivpreuni, " +
                                                 "caivestite = @caivestite, " +
                                                 "caivcanite = @caivcanite, " +
                                                 "caivsubtot = @caivsubtot, " +
                                                 "faivcodpro = @faivcodpro, " +
                                                 "faivcodven = @faivcodven" +
                             " where " +
                                    "paivcodite = @paivcodite";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroDecimal("@caivpreuni", this._caivpreuni);
                this.Conexion.AsignarParametroLogico("@caivestite", this._caivestite);
                this.Conexion.AsignarParametroEntero("@caivcanite", this._caivcanite);
                this.Conexion.AsignarParametroDecimal("@caivsubtot", this._caivsubtot);
                this.Conexion.AsignarParametroCadena("@faivcodpro", this._faivcodpro);
                this.Conexion.AsignarParametroCadena("@faivcodven", this._faivcodven);
                this.Conexion.AsignarParametroCadena("@paivcodite", this._paivcodite);

                this.Conexion.EjecutarTransaccion();
                this.Conexion.Desconectar();

                return true;
            }
        }
        public List<aiteven> Lista(string where)
        {
            List<aiteven> ListaResultado = new List<aiteven>();
            this.Conexion.Conectar();
            string sql = "select " +
                                 "caivpreuni," +
                                 "caivestite," +
                                 "caivcanite," +
                                 "caivsubtot," +
                                 "faivcodpro," +
                                 "faivcodven," +
                                 "paivcodite " +
                         "from aiteven ";

            if (where.Replace(" ", "") != "")
            {
                sql += "where " + where;
            }


            this.Conexion.PrepararComando(sql);
            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta != null)
            {
                while (ResultadoConsulta.Read())
                {
                    aiteven Auxiliar = new aiteven();
                    Auxiliar.caivpreuni = ResultadoConsulta.GetDecimal(0);
                    Auxiliar.caivestite = ResultadoConsulta.GetBoolean(1);
                    Auxiliar.caivcanite = ResultadoConsulta.GetInt32(2);
                    Auxiliar.caivsubtot = ResultadoConsulta.GetDecimal(3);
                    Auxiliar.faivcodpro = ResultadoConsulta.GetString(4);
                    Auxiliar.faivcodven = ResultadoConsulta.GetString(5);
                    Auxiliar.paivcodite = ResultadoConsulta.GetString(6);
                    ListaResultado.Add(Auxiliar);
                }

            }
            this.Conexion.Desconectar();
            return ListaResultado;
        }
        #endregion


    }
}
