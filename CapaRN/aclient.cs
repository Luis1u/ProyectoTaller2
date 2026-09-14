using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class aclient {

		#region Campos
            private bool _caceestcli;
            private string _cacerazsoc;
            private string _cacenitcli;
            private string _pacecodcli;
            private string _cacedircli;
            private string _facecodper;
            private string _cacetelcli;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public bool caceestcli
            { 
                get{ return this._caceestcli;}
                set{ this._caceestcli = value;}
            } 
		    public string cacerazsoc
            { 
                get{ return this._cacerazsoc;}
                set{ this._cacerazsoc = value;}
            } 
		    public string cacenitcli
            { 
                get{ return this._cacenitcli;}
                set{ this._cacenitcli = value;}
            } 
		    public string pacecodcli
            { 
                get{ return this._pacecodcli;}
                set{ this._pacecodcli = value;}
            } 
		    public string cacedircli
            { 
                get{ return this._cacedircli;}
                set{ this._cacedircli = value;}
            } 
		    public string facecodper
            { 
                get{ return this._facecodper;}
                set{ this._facecodper = value;}
            } 
		    public string cacetelcli
            { 
                get{ return this._cacetelcli;}
                set{ this._cacetelcli = value;}
            } 
        #endregion

        #region Constructor
            public aclient()
            { 
		        this._caceestcli = true;
		        this._cacerazsoc = "";
		        this._cacenitcli = "";
		        this._pacecodcli = "";
		        this._cacedircli = "";
		        this._facecodper = "";
		        this._cacetelcli = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "caceestcli," +
                                     "cacerazsoc," +
                                     "cacenitcli," +
                                     "pacecodcli," +
                                     "cacedircli," +
                                     "facecodper," +
                                     "cacetelcli " + 
                             "from aclient " +
                             "where "+
                                    "pacecodcli = @pacecodcli";
            

            this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@pacecodcli",this._pacecodcli);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._caceestcli=ResultadoConsulta.GetBoolean(0);
                    this._cacerazsoc=ResultadoConsulta.GetString(1);
                    this._cacenitcli=ResultadoConsulta.GetString(2);
                    this._pacecodcli=ResultadoConsulta.GetString(3);
                    this._cacedircli=ResultadoConsulta.GetString(4);
                    this._facecodper=ResultadoConsulta.GetString(5);
                    this._cacetelcli=ResultadoConsulta.GetString(6);
                    this.Conexion.Desconectar();

                    return true;
                }
                else
                {
                    this.Conexion.Desconectar();
                    return false;
                }
            }
        public bool ObtenerDatosNit(bool modificar, string nit)
        {
            this.Conexion.Conectar();
            string sql = "select " +
                                 "caceestcli," +
                                 "cacerazsoc," +
                                 "cacenitcli," +
                                 "pacecodcli," +
                                 "cacedircli," +
                                 "facecodper," +
                                 "cacetelcli " +
                         "from aclient " +
                         "where " +
                                "cacenitcli = @cacenitcli";
            if (modificar)
            {
                sql += " and cacenitcli !='" + nit + "'";
            }

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@cacenitcli", this._cacenitcli);


            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.Read())
            {
                this._caceestcli = ResultadoConsulta.GetBoolean(0);
                this._cacerazsoc = ResultadoConsulta.GetString(1);
                this._cacenitcli = ResultadoConsulta.GetString(2);
                this._pacecodcli = ResultadoConsulta.GetString(3);
                this._cacedircli = ResultadoConsulta.GetString(4);
                this._facecodper = ResultadoConsulta.GetString(5);
                this._cacetelcli = ResultadoConsulta.GetString(6);
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
                                     "caceestcli," +
                                     "cacerazsoc," +
                                     "cacenitcli," +
                                     "pacecodcli," +
                                     "cacedircli," +
                                     "facecodper," +
                                     "cacetelcli " + 
                             "from aclient " +
                             "where " +
                                    "pacecodcli = @pacecodcli";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@pacecodcli",this._pacecodcli);

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
			        string sql = "insert into aclient (" +
                                                       "caceestcli," +
                                                       "cacerazsoc," +
                                                       "cacenitcli," +
                                                       "pacecodcli," +
                                                       "cacedircli," +
                                                       "facecodper," +
                                                       "cacetelcli" +
                                                       ") " +
	                             "values (" + 
                                          "@caceestcli," +
                                          "@cacerazsoc," +
                                          "@cacenitcli," +
                                          "@pacecodcli," +
                                          "@cacedircli," +
                                          "@facecodper," +
                                          "@cacetelcli" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroLogico("@caceestcli",this._caceestcli);
                    this.Conexion.AsignarParametroCadena("@cacerazsoc",this._cacerazsoc);
                    this.Conexion.AsignarParametroCadena("@cacenitcli",this._cacenitcli);
                    this.Conexion.AsignarParametroCadena("@pacecodcli",this._pacecodcli);
                    this.Conexion.AsignarParametroCadena("@cacedircli",this._cacedircli);
                    this.Conexion.AsignarParametroCadena("@facecodper",this._facecodper);
                    this.Conexion.AsignarParametroCadena("@cacetelcli",this._cacetelcli);

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
			        string sql = "update aclient set " +
                                                     "caceestcli = @caceestcli, " +
                                                     "cacerazsoc = @cacerazsoc, " +
                                                     "cacenitcli = @cacenitcli, " +
                                                     "cacedircli = @cacedircli, " +
                                                     "facecodper = @facecodper, " +
                                                     "cacetelcli = @cacetelcli" +
                                 " where " +
                                        "pacecodcli = @pacecodcli";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroLogico("@caceestcli",this._caceestcli);
                    this.Conexion.AsignarParametroCadena("@cacerazsoc",this._cacerazsoc);
                    this.Conexion.AsignarParametroCadena("@cacenitcli",this._cacenitcli);
                    this.Conexion.AsignarParametroCadena("@pacecodcli",this._pacecodcli);
                    this.Conexion.AsignarParametroCadena("@cacedircli",this._cacedircli);
                    this.Conexion.AsignarParametroCadena("@facecodper",this._facecodper);
                    this.Conexion.AsignarParametroCadena("@cacetelcli",this._cacetelcli);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<aclient> Lista(string where)
            { 
                List<aclient> ListaResultado = new List<aclient>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "caceestcli," +
                                     "cacerazsoc," +
                                     "cacenitcli," +
                                     "pacecodcli," +
                                     "cacedircli," +
                                     "facecodper," +
                                     "cacetelcli " + 
                             "from aclient " ;
 
                if (where.Replace(" ", "") != "")
                {
                    sql+= "where " + where;
                }

 
                this.Conexion.PrepararComando(sql); 
                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta!=null)
                {
                    while (ResultadoConsulta.Read())
                    {
                          aclient Auxiliar = new aclient();
                          Auxiliar.caceestcli = ResultadoConsulta.GetBoolean(0);
                          Auxiliar.cacerazsoc = ResultadoConsulta.GetString(1);
                          Auxiliar.cacenitcli = ResultadoConsulta.GetString(2);
                          Auxiliar.pacecodcli = ResultadoConsulta.GetString(3);
                          Auxiliar.cacedircli = ResultadoConsulta.GetString(4);
                          Auxiliar.facecodper = ResultadoConsulta.GetString(5);
                          Auxiliar.cacetelcli = ResultadoConsulta.GetString(6);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            } 
        #endregion 

	}
}

