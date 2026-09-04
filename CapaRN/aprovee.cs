using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class aprovee {

		#region Campos
            private bool _capvestpro;
            private string _capvrazsoc;
            private string _capvnitpro;
            private string _papvcodpro;
            private string _capvdirpro;
            private string _fapvcodper;
            private string _capvtelpro;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public bool capvestpro
            { 
                get{ return this._capvestpro;}
                set{ this._capvestpro = value;}
            } 
		    public string capvrazsoc
            { 
                get{ return this._capvrazsoc;}
                set{ this._capvrazsoc = value;}
            } 
		    public string capvnitpro
            { 
                get{ return this._capvnitpro;}
                set{ this._capvnitpro = value;}
            } 
		    public string papvcodpro
            { 
                get{ return this._papvcodpro;}
                set{ this._papvcodpro = value;}
            } 
		    public string capvdirpro
            { 
                get{ return this._capvdirpro;}
                set{ this._capvdirpro = value;}
            } 
		    public string fapvcodper
            { 
                get{ return this._fapvcodper;}
                set{ this._fapvcodper = value;}
            } 
		    public string capvtelpro
            { 
                get{ return this._capvtelpro;}
                set{ this._capvtelpro = value;}
            } 
        #endregion

        #region Constructor
            public aprovee()
            { 
		        this._capvestpro = true;
		        this._capvrazsoc = "";
		        this._capvnitpro = "";
		        this._papvcodpro = "";
		        this._capvdirpro = "";
		        this._fapvcodper = "";
		        this._capvtelpro = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "capvestpro," +
                                     "capvrazsoc," +
                                     "capvnitpro," +
                                     "papvcodpro," +
                                     "capvdirpro," +
                                     "fapvcodper," +
                                     "capvtelpro " + 
                             "from aprovee " +
                             "where "+
                                    "papvcodpro = @papvcodpro";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@papvcodpro",this._papvcodpro);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._capvestpro=ResultadoConsulta.GetBoolean(0);
                    this._capvrazsoc=ResultadoConsulta.GetString(1);
                    this._capvnitpro=ResultadoConsulta.GetString(2);
                    this._papvcodpro=ResultadoConsulta.GetString(3);
                    this._capvdirpro=ResultadoConsulta.GetString(4);
                    this._fapvcodper=ResultadoConsulta.GetString(5);
                    this._capvtelpro=ResultadoConsulta.GetString(6);
                    this.Conexion.Desconectar();

                    return true;
                }
                else
                {
                    this.Conexion.Desconectar();
                    return false;
                }
            }
        public bool ObtenerDatosNit(bool modificar,string nit)
        {
            this.Conexion.Conectar();
            string sql = "select " +
                                 "capvestpro," +
                                 "capvrazsoc," +
                                 "capvnitpro," +
                                 "papvcodpro," +
                                 "capvdirpro," +
                                 "fapvcodper," +
                                 "capvtelpro " +
                         "from aprovee " +
                         "where " +
                                "capvnitpro = @capvnitpro";
            if (modificar)
            {
                sql += " and capvnitpro !='" + nit + "'";
            }

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@capvnitpro", this._capvnitpro);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.Read())
            {
                this._capvestpro = ResultadoConsulta.GetBoolean(0);
                this._capvrazsoc = ResultadoConsulta.GetString(1);
                this._capvnitpro = ResultadoConsulta.GetString(2);
                this._papvcodpro = ResultadoConsulta.GetString(3);
                this._capvdirpro = ResultadoConsulta.GetString(4);
                this._fapvcodper = ResultadoConsulta.GetString(5);
                this._capvtelpro = ResultadoConsulta.GetString(6);
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
                                     "capvestpro," +
                                     "capvrazsoc," +
                                     "capvnitpro," +
                                     "papvcodpro," +
                                     "capvdirpro," +
                                     "fapvcodper," +
                                     "capvtelpro " + 
                             "from aprovee " +
                             "where " +
                                    "papvcodpro = @papvcodpro";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@papvcodpro",this._papvcodpro);

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
			        string sql = "insert into aprovee (" +
                                                       "capvestpro," +
                                                       "capvrazsoc," +
                                                       "capvnitpro," +
                                                       "papvcodpro," +
                                                       "capvdirpro," +
                                                       "fapvcodper," +
                                                       "capvtelpro" +
                                                       ") " +
	                             "values (" + 
                                          "@capvestpro," +
                                          "@capvrazsoc," +
                                          "@capvnitpro," +
                                          "@papvcodpro," +
                                          "@capvdirpro," +
                                          "@fapvcodper," +
                                          "@capvtelpro" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroLogico("@capvestpro",this._capvestpro);
                    this.Conexion.AsignarParametroCadena("@capvrazsoc",this._capvrazsoc);
                    this.Conexion.AsignarParametroCadena("@capvnitpro",this._capvnitpro);
                    this.Conexion.AsignarParametroCadena("@papvcodpro",this._papvcodpro);
                    this.Conexion.AsignarParametroCadena("@capvdirpro",this._capvdirpro);
                    this.Conexion.AsignarParametroCadena("@fapvcodper",this._fapvcodper);
                    this.Conexion.AsignarParametroCadena("@capvtelpro",this._capvtelpro);

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
			        string sql = "update aprovee set " +
                                                     "capvestpro = @capvestpro, " +
                                                     "capvrazsoc = @capvrazsoc, " +
                                                     "capvnitpro = @capvnitpro, " +
                                                     "capvdirpro = @capvdirpro, " +
                                                     "fapvcodper = @fapvcodper, " +
                                                     "capvtelpro = @capvtelpro" +
                                 " where " +
                                        "papvcodpro = @papvcodpro";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroLogico("@capvestpro",this._capvestpro);
                    this.Conexion.AsignarParametroCadena("@capvrazsoc",this._capvrazsoc);
                    this.Conexion.AsignarParametroCadena("@capvnitpro",this._capvnitpro);
                    this.Conexion.AsignarParametroCadena("@papvcodpro",this._papvcodpro);
                    this.Conexion.AsignarParametroCadena("@capvdirpro",this._capvdirpro);
                    this.Conexion.AsignarParametroCadena("@fapvcodper",this._fapvcodper);
                    this.Conexion.AsignarParametroCadena("@capvtelpro",this._capvtelpro);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<aprovee> Lista(string where)
            { 
                List<aprovee> ListaResultado = new List<aprovee>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "capvestpro," +
                                     "capvrazsoc," +
                                     "capvnitpro," +
                                     "papvcodpro," +
                                     "capvdirpro," +
                                     "fapvcodper," +
                                     "capvtelpro " + 
                             "from aprovee " ;
 
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
                          aprovee Auxiliar = new aprovee();
                          Auxiliar.capvestpro = ResultadoConsulta.GetBoolean(0);
                          Auxiliar.capvrazsoc = ResultadoConsulta.GetString(1);
                          Auxiliar.capvnitpro = ResultadoConsulta.GetString(2);
                          Auxiliar.papvcodpro = ResultadoConsulta.GetString(3);
                          Auxiliar.capvdirpro = ResultadoConsulta.GetString(4);
                          Auxiliar.fapvcodper = ResultadoConsulta.GetString(5);
                          Auxiliar.capvtelpro = ResultadoConsulta.GetString(6);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            } 
        #endregion 

	}
}

