using System;
using System.Collections.Generic;
using System.Text;
//Libreria para acceso a datos
using System.Data.Common; 
//Libreria para acceso a Capa de Acceso a Datos
using CapaAD;

namespace CapaRN
{
	public class avenpro {

		#region Campos
            private DateTime _cavpfeccre;
            private DateTime _cavpfecmod;
            private DateTime _cavpfechor;
            private decimal _cavptotven;
            private bool _cavpestven;
            private string _favpusumod;
            private string _cavpobsven;
            private string _favpcodcli;
            private string _favpusucre;
            private string _pavpcodven;
            //Instancia para conexion a PostgreSQL 8.2
            private CLConexionPGSQL Conexion;
		#endregion 

		#region Propiedades
		    public DateTime cavpfeccre
            { 
                get{ return this._cavpfeccre;}
                set{ this._cavpfeccre = value;}
            } 
		    public DateTime cavpfecmod
            { 
                get{ return this._cavpfecmod;}
                set{ this._cavpfecmod = value;}
            } 
		    public DateTime cavpfechor
            { 
                get{ return this._cavpfechor;}
                set{ this._cavpfechor = value;}
            } 
		    public decimal cavptotven
            { 
                get{ return this._cavptotven;}
                set{ this._cavptotven = value;}
            } 
		    public bool cavpestven
            { 
                get{ return this._cavpestven;}
                set{ this._cavpestven = value;}
            } 
		    public string favpusumod
            { 
                get{ return this._favpusumod;}
                set{ this._favpusumod = value;}
            } 
		    public string cavpobsven
            { 
                get{ return this._cavpobsven;}
                set{ this._cavpobsven = value;}
            } 
		    public string favpcodcli
            { 
                get{ return this._favpcodcli;}
                set{ this._favpcodcli = value;}
            } 
		    public string favpusucre
            { 
                get{ return this._favpusucre;}
                set{ this._favpusucre = value;}
            } 
		    public string pavpcodven
            { 
                get{ return this._pavpcodven;}
                set{ this._pavpcodven = value;}
            } 
        #endregion

        #region Constructor
            public avenpro()
            { 
		        this._cavpfeccre = DateTime.Now;
		        this._cavpfecmod = DateTime.Now;
		        this._cavpfechor = DateTime.Now;
		        this._cavptotven = 0;
		        this._cavpestven = true;
		        this._favpusumod = "";
		        this._cavpobsven = "";
		        this._favpcodcli = "";
		        this._favpusucre = "";
		        this._pavpcodven = "";
                this.Conexion = new CLConexionPGSQL();            } 
        #endregion

        #region Metodos
            public bool ObtenerDatos() 
            { 
                this.Conexion.Conectar();
			    string sql = "select " +
                                     "cavpfeccre," +
                                     "cavpfecmod," +
                                     "cavpfechor," +
                                     "cavptotven," +
                                     "cavpestven," +
                                     "favpusumod," +
                                     "cavpobsven," +
                                     "favpcodcli," +
                                     "favpusucre," +
                                     "pavpcodven " + 
                             "from avenpro " +
                             "where "+
                                    "pavpcodven = @pavpcodven";

                this.Conexion.PrepararComando(sql);

                this.Conexion.AsignarParametroCadena("@pavpcodven",this._pavpcodven);

                DbDataReader ResultadoConsulta = Conexion.EjecutarConsulta();

                if (ResultadoConsulta.Read())
                {
                    this._cavpfeccre=ResultadoConsulta.GetDateTime(0);
                    this._cavpfecmod=ResultadoConsulta.GetDateTime(1);
                    this._cavpfechor=ResultadoConsulta.GetDateTime(2);
                    this._cavptotven=ResultadoConsulta.GetDecimal(3);
                    this._cavpestven=ResultadoConsulta.GetBoolean(4);
                    this._favpusumod=ResultadoConsulta.GetString(5);
                    this._cavpobsven=ResultadoConsulta.GetString(6);
                    this._favpcodcli=ResultadoConsulta.GetString(7);
                    this._favpusucre=ResultadoConsulta.GetString(8);
                    this._pavpcodven=ResultadoConsulta.GetString(9);
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
                                     "cavpfeccre," +
                                     "cavpfecmod," +
                                     "cavpfechor," +
                                     "cavptotven," +
                                     "cavpestven," +
                                     "favpusumod," +
                                     "cavpobsven," +
                                     "favpcodcli," +
                                     "favpusucre," +
                                     "pavpcodven " + 
                             "from avenpro " +
                             "where " +
                                    "pavpcodven = @pavpcodven";
 
                this.Conexion.PrepararComando(sql); 

                this.Conexion.AsignarParametroCadena("@pavpcodven",this._pavpcodven);

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
			        string sql = "insert into avenpro (" +
                                                       "cavpfeccre," +
                                                       "cavpfecmod," +
                                                       "cavpfechor," +
                                                       "cavptotven," +
                                                       "cavpestven," +
                                                       "favpusumod," +
                                                       "cavpobsven," +
                                                       "favpcodcli," +
                                                       "favpusucre," +
                                                       "pavpcodven" +
                                                       ") " +
	                             "values (" + 
                                          "@cavpfeccre," +
                                          "@cavpfecmod," +
                                          "@cavpfechor," +
                                          "@cavptotven," +
                                          "@cavpestven," +
                                          "@favpusumod," +
                                          "@cavpobsven," +
                                          "@favpcodcli," +
                                          "@favpusucre," +
                                          "@pavpcodven" +
                                                       ")";

                    this.Conexion.PrepararComando(sql);

                    this.Conexion.AsignarParametroFechaHora("@cavpfeccre",this._cavpfeccre);
                    this.Conexion.AsignarParametroFechaHora("@cavpfecmod",this._cavpfecmod);
                    this.Conexion.AsignarParametroHora("@cavpfechor",this._cavpfechor);
                    this.Conexion.AsignarParametroDecimal("@cavptotven",this._cavptotven);
                    this.Conexion.AsignarParametroLogico("@cavpestven",this._cavpestven);
                    this.Conexion.AsignarParametroCadena("@favpusumod",this._favpusumod);
                    this.Conexion.AsignarParametroCadena("@cavpobsven",this._cavpobsven);
                    this.Conexion.AsignarParametroCadena("@favpcodcli",this._favpcodcli);
                    this.Conexion.AsignarParametroCadena("@favpusucre",this._favpusucre);
                    this.Conexion.AsignarParametroCadena("@pavpcodven",this._pavpcodven);

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
			        string sql = "update avenpro set " +
                                                     "cavpfeccre = @cavpfeccre, " +
                                                     "cavpfecmod = @cavpfecmod, " +
                                                     "cavpfechor = @cavpfechor, " +
                                                     "cavptotven = @cavptotven, " +
                                                     "cavpestven = @cavpestven, " +
                                                     "favpusumod = @favpusumod, " +
                                                     "cavpobsven = @cavpobsven, " +
                                                     "favpcodcli = @favpcodcli, " +
                                                     "favpusucre = @favpusucre" +
                                 " where " +
                                        "pavpcodven = @pavpcodven";
 
                this.Conexion.PrepararComando(sql); 

                    this.Conexion.AsignarParametroFechaHora("@cavpfeccre",this._cavpfeccre);
                    this.Conexion.AsignarParametroFechaHora("@cavpfecmod",this._cavpfecmod);
                    this.Conexion.AsignarParametroHora("@cavpfechor",this._cavpfechor);
                    this.Conexion.AsignarParametroDecimal("@cavptotven",this._cavptotven);
                    this.Conexion.AsignarParametroLogico("@cavpestven",this._cavpestven);
                    this.Conexion.AsignarParametroCadena("@favpusumod",this._favpusumod);
                    this.Conexion.AsignarParametroCadena("@cavpobsven",this._cavpobsven);
                    this.Conexion.AsignarParametroCadena("@favpcodcli",this._favpcodcli);
                    this.Conexion.AsignarParametroCadena("@favpusucre",this._favpusucre);
                    this.Conexion.AsignarParametroCadena("@pavpcodven",this._pavpcodven);

                    this.Conexion.EjecutarTransaccion();
                    this.Conexion.Desconectar();

                    return true;
                }
            }
            public List<avenpro> Lista(string where)
            { 
                List<avenpro> ListaResultado = new List<avenpro>();
                this.Conexion.Conectar(); 
			    string sql = "select " + 
                                     "cavpfeccre," +
                                     "cavpfecmod," +
                                     "cavpfechor," +
                                     "cavptotven," +
                                     "cavpestven," +
                                     "favpusumod," +
                                     "cavpobsven," +
                                     "favpcodcli," +
                                     "favpusucre," +
                                     "pavpcodven " + 
                             "from avenpro " ;
 
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
                          avenpro Auxiliar = new avenpro();
                          Auxiliar.cavpfeccre = ResultadoConsulta.GetDateTime(0);
                          Auxiliar.cavpfecmod = ResultadoConsulta.GetDateTime(1);
                          Auxiliar.cavpfechor = ResultadoConsulta.GetDateTime(2);
                          Auxiliar.cavptotven = ResultadoConsulta.GetDecimal(3);
                          Auxiliar.cavpestven = ResultadoConsulta.GetBoolean(4);
                          Auxiliar.favpusumod = ResultadoConsulta.GetString(5);
                          Auxiliar.cavpobsven = ResultadoConsulta.GetString(6);
                          Auxiliar.favpcodcli = ResultadoConsulta.GetString(7);
                          Auxiliar.favpusucre = ResultadoConsulta.GetString(8);
                          Auxiliar.pavpcodven = ResultadoConsulta.GetString(9);
                          ListaResultado.Add(Auxiliar);
                    }

                }
                this.Conexion.Desconectar();
                return ListaResultado;
            } 
        #endregion 

	}
}

