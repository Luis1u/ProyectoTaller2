using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class aproduc {

		#region Campos
            private int _capdstopro;
            private decimal _capdpreven;
            private decimal _capdpremin;
            private bool _capdestpro;
            private DateTime _capdfeccre;
            private DateTime _capdfecmod;
            private string _capdmatpro;
            private string _capdcolpro;
            private string _papdcodpro;
            private string _capdtalpro;
            private string _capddespro;
            private string _capdfotpro;
            private string _capdgenpro;
            private string _capdcatpro;
            private string _capdcodbar;
            private string _capdmodpro;
            private string _capdnompro;
            private string _capdmarpro;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public int capdstopro
            { 
                get{ return this._capdstopro;}
                set{ this._capdstopro = value;}
            } 
		    public decimal capdpreven
            { 
                get{ return this._capdpreven;}
                set{ this._capdpreven = value;}
            } 
		    public decimal capdpremin
            { 
                get{ return this._capdpremin;}
                set{ this._capdpremin = value;}
            } 
		    public bool capdestpro
            { 
                get{ return this._capdestpro;}
                set{ this._capdestpro = value;}
            } 
		    public DateTime capdfeccre
            { 
                get{ return this._capdfeccre;}
                set{ this._capdfeccre = value;}
            } 
		    public DateTime capdfecmod
            { 
                get{ return this._capdfecmod;}
                set{ this._capdfecmod = value;}
            } 
		    public string capdmatpro
            { 
                get{ return this._capdmatpro;}
                set{ this._capdmatpro = value;}
            } 
		    public string capdcolpro
            { 
                get{ return this._capdcolpro;}
                set{ this._capdcolpro = value;}
            } 
		    public string papdcodpro
            { 
                get{ return this._papdcodpro;}
                set{ this._papdcodpro = value;}
            } 
		    public string capdtalpro
            { 
                get{ return this._capdtalpro;}
                set{ this._capdtalpro = value;}
            } 
		    public string capddespro
            { 
                get{ return this._capddespro;}
                set{ this._capddespro = value;}
            } 
		    public string capdfotpro
            { 
                get{ return this._capdfotpro;}
                set{ this._capdfotpro = value;}
            } 
		    public string capdgenpro
            { 
                get{ return this._capdgenpro;}
                set{ this._capdgenpro = value;}
            } 
		    public string capdcatpro
            { 
                get{ return this._capdcatpro;}
                set{ this._capdcatpro = value;}
            } 
		    public string capdcodbar
            { 
                get{ return this._capdcodbar;}
                set{ this._capdcodbar = value;}
            } 
		    public string capdmodpro
            { 
                get{ return this._capdmodpro;}
                set{ this._capdmodpro = value;}
            } 
		    public string capdnompro
            { 
                get{ return this._capdnompro;}
                set{ this._capdnompro = value;}
            } 
		    public string capdmarpro
            { 
                get{ return this._capdmarpro;}
                set{ this._capdmarpro = value;}
            } 
        #endregion

        #region Constructor
            public aproduc()
            { 
		        this._capdstopro = 0;
		        this._capdpreven = 0;
		        this._capdpremin = 0;
		        this._capdestpro = true;
		        this._capdfeccre = DateTime.Now;
		        this._capdfecmod = DateTime.Now;
		        this._capdmatpro = "";
		        this._capdcolpro = "";
		        this._papdcodpro = "";
		        this._capdtalpro = "";
		        this._capddespro = "";
		        this._capdfotpro = "";
		        this._capdgenpro = "";
		        this._capdcatpro = "";
		        this._capdcodbar = "";
		        this._capdmodpro = "";
		        this._capdnompro = "";
		        this._capdmarpro = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "capdstopro," +
                                     "capdpreven," +
                                     "capdpremin," +
                                     "capdestpro," +
                                     "capdfeccre," +
                                     "capdfecmod," +
                                     "capdmatpro," +
                                     "capdcolpro," +
                                     "papdcodpro," +
                                     "capdtalpro," +
                                     "capddespro," +
                                     "capdfotpro," +
                                     "capdgenpro," +
                                     "capdcatpro," +
                                     "capdcodbar," +
                                     "capdmodpro," +
                                     "capdnompro," +
                                     "capdmarpro " + 
                             "from aproduc " +
                             "where "+
                                    "papdcodpro = @papdcodpro";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@papdcodpro",this._papdcodpro);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._capdstopro=ResultadoConsulta.GetInt32(0);
                    this._capdpreven=ResultadoConsulta.GetDecimal(1);
                    this._capdpremin=ResultadoConsulta.GetDecimal(2);
                    this._capdestpro=ResultadoConsulta.GetBoolean(3);
                    this._capdfeccre=ResultadoConsulta.GetDateTime(4);
                    this._capdfecmod=ResultadoConsulta.GetDateTime(5);
                    this._capdmatpro=ResultadoConsulta.GetString(6);
                    this._capdcolpro=ResultadoConsulta.GetString(7);
                    this._papdcodpro=ResultadoConsulta.GetString(8);
                    this._capdtalpro=ResultadoConsulta.GetString(9);
                    this._capddespro=ResultadoConsulta.GetString(10);
                    this._capdfotpro=ResultadoConsulta.GetString(11);
                    this._capdgenpro=ResultadoConsulta.GetString(12);
                    this._capdcatpro=ResultadoConsulta.GetString(13);
                    this._capdcodbar=ResultadoConsulta.GetString(14);
                    this._capdmodpro=ResultadoConsulta.GetString(15);
                    this._capdnompro=ResultadoConsulta.GetString(16);
                    this._capdmarpro=ResultadoConsulta.GetString(17);
                    this.Conexion.Desconectar();

                    return true;
                }
                else
                {
                    this.Conexion.Desconectar();
                    return false;
                }
            }
        public bool ObtenerDatosNombre(bool modificar, string nombre)
        {
            this.Conexion.Conectar();
            string sql = "select " +
                                 "capdstopro," +
                                 "capdpreven," +
                                 "capdpremin," +
                                 "capdestpro," +
                                 "capdfeccre," +
                                 "capdfecmod," +
                                 "capdmatpro," +
                                 "capdcolpro," +
                                 "papdcodpro," +
                                 "capdtalpro," +
                                 "capddespro," +
                                 "capdfotpro," +
                                 "capdgenpro," +
                                 "capdcatpro," +
                                 "capdcodbar," +
                                 "capdmodpro," +
                                 "capdnompro," +
                                 "capdmarpro " +
                         "from aproduc " +
                         "where " +
                                "capdnompro = @capdnompro";

            if (modificar)
            {
                sql += " and capdnompro!='" + nombre + "'";
            }

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@capdnompro", this._capdnompro);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.Read())
            {
                this._capdstopro = ResultadoConsulta.GetInt32(0);
                this._capdpreven = ResultadoConsulta.GetDecimal(1);
                this._capdpremin = ResultadoConsulta.GetDecimal(2);
                this._capdestpro = ResultadoConsulta.GetBoolean(3);
                this._capdfeccre = ResultadoConsulta.GetDateTime(4);
                this._capdfecmod = ResultadoConsulta.GetDateTime(5);
                this._capdmatpro = ResultadoConsulta.GetString(6);
                this._capdcolpro = ResultadoConsulta.GetString(7);
                this._papdcodpro = ResultadoConsulta.GetString(8);
                this._capdtalpro = ResultadoConsulta.GetString(9);
                this._capddespro = ResultadoConsulta.GetString(10);
                this._capdfotpro = ResultadoConsulta.GetString(11);
                this._capdgenpro = ResultadoConsulta.GetString(12);
                this._capdcatpro = ResultadoConsulta.GetString(13);
                this._capdcodbar = ResultadoConsulta.GetString(14);
                this._capdmodpro = ResultadoConsulta.GetString(15);
                this._capdnompro = ResultadoConsulta.GetString(16);
                this._capdmarpro = ResultadoConsulta.GetString(17);
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
                                     "capdstopro," +
                                     "capdpreven," +
                                     "capdpremin," +
                                     "capdestpro," +
                                     "capdfeccre," +
                                     "capdfecmod," +
                                     "capdmatpro," +
                                     "capdcolpro," +
                                     "papdcodpro," +
                                     "capdtalpro," +
                                     "capddespro," +
                                     "capdfotpro," +
                                     "capdgenpro," +
                                     "capdcatpro," +
                                     "capdcodbar," +
                                     "capdmodpro," +
                                     "capdnompro," +
                                     "capdmarpro " + 
                             "from aproduc " +
                             "where " +
                                    "papdcodpro = @papdcodpro";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@papdcodpro",this._papdcodpro);

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
			        string sql = "insert into aproduc (" +
                                                       "capdstopro," +
                                                       "capdpreven," +
                                                       "capdpremin," +
                                                       "capdestpro," +
                                                       "capdfeccre," +
                                                       "capdfecmod," +
                                                       "capdmatpro," +
                                                       "capdcolpro," +
                                                       "papdcodpro," +
                                                       "capdtalpro," +
                                                       "capddespro," +
                                                       "capdfotpro," +
                                                       "capdgenpro," +
                                                       "capdcatpro," +
                                                       "capdcodbar," +
                                                       "capdmodpro," +
                                                       "capdnompro," +
                                                       "capdmarpro" +
                                                       ") " +
	                             "values (" + 
                                          "@capdstopro," +
                                          "@capdpreven," +
                                          "@capdpremin," +
                                          "@capdestpro," +
                                          "@capdfeccre," +
                                          "@capdfecmod," +
                                          "@capdmatpro," +
                                          "@capdcolpro," +
                                          "@papdcodpro," +
                                          "@capdtalpro," +
                                          "@capddespro," +
                                          "@capdfotpro," +
                                          "@capdgenpro," +
                                          "@capdcatpro," +
                                          "@capdcodbar," +
                                          "@capdmodpro," +
                                          "@capdnompro," +
                                          "@capdmarpro" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroEntero("@capdstopro",this._capdstopro);
                    this.Conexion.AsignarParametroDecimal("@capdpreven",this._capdpreven);
                    this.Conexion.AsignarParametroDecimal("@capdpremin",this._capdpremin);
                    this.Conexion.AsignarParametroLogico("@capdestpro",this._capdestpro);
                    this.Conexion.AsignarParametroFechaHora("@capdfeccre",this._capdfeccre);
                    this.Conexion.AsignarParametroFechaHora("@capdfecmod",this._capdfecmod);
                    this.Conexion.AsignarParametroCadena("@capdmatpro",this._capdmatpro);
                    this.Conexion.AsignarParametroCadena("@capdcolpro",this._capdcolpro);
                    this.Conexion.AsignarParametroCadena("@papdcodpro",this._papdcodpro);
                    this.Conexion.AsignarParametroCadena("@capdtalpro",this._capdtalpro);
                    this.Conexion.AsignarParametroCadena("@capddespro",this._capddespro);
                    this.Conexion.AsignarParametroCadena("@capdfotpro",this._capdfotpro);
                    this.Conexion.AsignarParametroCadena("@capdgenpro",this._capdgenpro);
                    this.Conexion.AsignarParametroCadena("@capdcatpro",this._capdcatpro);
                    this.Conexion.AsignarParametroCadena("@capdcodbar",this._capdcodbar);
                    this.Conexion.AsignarParametroCadena("@capdmodpro",this._capdmodpro);
                    this.Conexion.AsignarParametroCadena("@capdnompro",this._capdnompro);
                    this.Conexion.AsignarParametroCadena("@capdmarpro",this._capdmarpro);

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
			        string sql = "update aproduc set " +
                                                     "capdstopro = @capdstopro, " +
                                                     "capdpreven = @capdpreven, " +
                                                     "capdpremin = @capdpremin, " +
                                                     "capdestpro = @capdestpro, " +
                                                     "capdfeccre = @capdfeccre, " +
                                                     "capdfecmod = @capdfecmod, " +
                                                     "capdmatpro = @capdmatpro, " +
                                                     "capdcolpro = @capdcolpro, " +
                                                     "capdtalpro = @capdtalpro, " +
                                                     "capddespro = @capddespro, " +
                                                     "capdfotpro = @capdfotpro, " +
                                                     "capdgenpro = @capdgenpro, " +
                                                     "capdcatpro = @capdcatpro, " +
                                                     "capdcodbar = @capdcodbar, " +
                                                     "capdmodpro = @capdmodpro, " +
                                                     "capdnompro = @capdnompro, " +
                                                     "capdmarpro = @capdmarpro" +
                                 " where " +
                                        "papdcodpro = @papdcodpro";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroEntero("@capdstopro",this._capdstopro);
                    this.Conexion.AsignarParametroDecimal("@capdpreven",this._capdpreven);
                    this.Conexion.AsignarParametroDecimal("@capdpremin",this._capdpremin);
                    this.Conexion.AsignarParametroLogico("@capdestpro",this._capdestpro);
                    this.Conexion.AsignarParametroFechaHora("@capdfeccre",this._capdfeccre);
                    this.Conexion.AsignarParametroFechaHora("@capdfecmod",this._capdfecmod);
                    this.Conexion.AsignarParametroCadena("@capdmatpro",this._capdmatpro);
                    this.Conexion.AsignarParametroCadena("@capdcolpro",this._capdcolpro);
                    this.Conexion.AsignarParametroCadena("@papdcodpro",this._papdcodpro);
                    this.Conexion.AsignarParametroCadena("@capdtalpro",this._capdtalpro);
                    this.Conexion.AsignarParametroCadena("@capddespro",this._capddespro);
                    this.Conexion.AsignarParametroCadena("@capdfotpro",this._capdfotpro);
                    this.Conexion.AsignarParametroCadena("@capdgenpro",this._capdgenpro);
                    this.Conexion.AsignarParametroCadena("@capdcatpro",this._capdcatpro);
                    this.Conexion.AsignarParametroCadena("@capdcodbar",this._capdcodbar);
                    this.Conexion.AsignarParametroCadena("@capdmodpro",this._capdmodpro);
                    this.Conexion.AsignarParametroCadena("@capdnompro",this._capdnompro);
                    this.Conexion.AsignarParametroCadena("@capdmarpro",this._capdmarpro);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<aproduc> Lista(string where)
            { 
                List<aproduc> ListaResultado = new List<aproduc>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "capdstopro," +
                                     "capdpreven," +
                                     "capdpremin," +
                                     "capdestpro," +
                                     "capdfeccre," +
                                     "capdfecmod," +
                                     "capdmatpro," +
                                     "capdcolpro," +
                                     "papdcodpro," +
                                     "capdtalpro," +
                                     "capddespro," +
                                     "capdfotpro," +
                                     "capdgenpro," +
                                     "capdcatpro," +
                                     "capdcodbar," +
                                     "capdmodpro," +
                                     "capdnompro," +
                                     "capdmarpro " + 
                             "from aproduc " ;
 
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
                          aproduc Auxiliar = new aproduc();
                          Auxiliar.capdstopro = ResultadoConsulta.GetInt32(0);
                          Auxiliar.capdpreven = ResultadoConsulta.GetDecimal(1);
                          Auxiliar.capdpremin = ResultadoConsulta.GetDecimal(2);
                          Auxiliar.capdestpro = ResultadoConsulta.GetBoolean(3);
                          Auxiliar.capdfeccre = ResultadoConsulta.GetDateTime(4);
                          Auxiliar.capdfecmod = ResultadoConsulta.GetDateTime(5);
                          Auxiliar.capdmatpro = ResultadoConsulta.GetString(6);
                          Auxiliar.capdcolpro = ResultadoConsulta.GetString(7);
                          Auxiliar.papdcodpro = ResultadoConsulta.GetString(8);
                          Auxiliar.capdtalpro = ResultadoConsulta.GetString(9);
                          Auxiliar.capddespro = ResultadoConsulta.GetString(10);
                          Auxiliar.capdfotpro = ResultadoConsulta.GetString(11);
                          Auxiliar.capdgenpro = ResultadoConsulta.GetString(12);
                          Auxiliar.capdcatpro = ResultadoConsulta.GetString(13);
                          Auxiliar.capdcodbar = ResultadoConsulta.GetString(14);
                          Auxiliar.capdmodpro = ResultadoConsulta.GetString(15);
                          Auxiliar.capdnompro = ResultadoConsulta.GetString(16);
                          Auxiliar.capdmarpro = ResultadoConsulta.GetString(17);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            } 
        #endregion 

	}
}

