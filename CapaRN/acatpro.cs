using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class acatpro {

		#region Campos
            private bool _cacpestcat;
            private string _pacpcodcat;
            private string _cacpnomcat;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public bool cacpestcat
            { 
                get{ return this._cacpestcat;}
                set{ this._cacpestcat = value;}
            } 
		    public string pacpcodcat
            { 
                get{ return this._pacpcodcat;}
                set{ this._pacpcodcat = value;}
            } 
		    public string cacpnomcat
            { 
                get{ return this._cacpnomcat;}
                set{ this._cacpnomcat = value;}
            } 
        #endregion

        #region Constructor
            public acatpro()
            { 
		        this._cacpestcat = true;
		        this._pacpcodcat = "";
		        this._cacpnomcat = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "cacpestcat," +
                                     "pacpcodcat," +
                                     "cacpnomcat " + 
                             "from acatpro " +
                             "where "+
                                    "pacpcodcat = @pacpcodcat";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@pacpcodcat",this._pacpcodcat);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._cacpestcat=ResultadoConsulta.GetBoolean(0);
                    this._pacpcodcat=ResultadoConsulta.GetString(1);
                    this._cacpnomcat=ResultadoConsulta.GetString(2);
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
                                 "cacpestcat," +
                                 "pacpcodcat," +
                                 "cacpnomcat " +
                         "from acatpro " +
                         "where " +
                                "cacpnomcat = @cacpnomcat";

            if (modificar)
            {
                sql += " and cacpnomcat!='" + nombre + "'";
            }

            this.Conexion.PrepararComando(sql);

            this.Conexion.AsignarParametroCadena("@cacpnomcat", this._cacpnomcat);

            DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

            if (ResultadoConsulta.Read())
            {
                this._cacpestcat = ResultadoConsulta.GetBoolean(0);
                this._pacpcodcat = ResultadoConsulta.GetString(1);
                this._cacpnomcat = ResultadoConsulta.GetString(2);
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
                                     "cacpestcat," +
                                     "pacpcodcat," +
                                     "cacpnomcat " + 
                             "from acatpro " +
                             "where " +
                                    "pacpcodcat = @pacpcodcat";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@pacpcodcat",this._pacpcodcat);

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
			        string sql = "insert into acatpro (" +
                                                       "cacpestcat," +
                                                       "pacpcodcat," +
                                                       "cacpnomcat" +
                                                       ") " +
	                             "values (" + 
                                          "@cacpestcat," +
                                          "@pacpcodcat," +
                                          "@cacpnomcat" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroLogico("@cacpestcat",this._cacpestcat);
                    this.Conexion.AsignarParametroCadena("@pacpcodcat",this._pacpcodcat);
                    this.Conexion.AsignarParametroCadena("@cacpnomcat",this._cacpnomcat);

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
			        string sql = "update acatpro set " +
                                                     "cacpestcat = @cacpestcat, " +
                                                     "cacpnomcat = @cacpnomcat" +
                                 " where " +
                                        "pacpcodcat = @pacpcodcat";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroLogico("@cacpestcat",this._cacpestcat);
                    this.Conexion.AsignarParametroCadena("@pacpcodcat",this._pacpcodcat);
                    this.Conexion.AsignarParametroCadena("@cacpnomcat",this._cacpnomcat);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<acatpro> Lista(string where)
            { 
                List<acatpro> ListaResultado = new List<acatpro>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "cacpestcat," +
                                     "pacpcodcat," +
                                     "cacpnomcat " + 
                             "from acatpro " ;
 
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
                          acatpro Auxiliar = new acatpro();
                          Auxiliar.cacpestcat = ResultadoConsulta.GetBoolean(0);
                          Auxiliar.pacpcodcat = ResultadoConsulta.GetString(1);
                          Auxiliar.cacpnomcat = ResultadoConsulta.GetString(2);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            } 
        #endregion 

	}
}

