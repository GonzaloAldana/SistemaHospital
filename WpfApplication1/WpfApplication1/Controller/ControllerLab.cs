using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNConnection.DataAbstractionLayer;
using RNConnection.DataStorageLayer;
using Modelos;
using System.Data;

namespace Integrador2017.Controller
{
    class ControllerLab
    {
        string Con = "DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES";

        DSL dsl = new DSL();

        public int AddLab(Modelos.Laboratorio L)
        {
            try
            {
                dsl = new DSL();
                int IDL;
                dsl.Open("DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES", Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.usp_AddLab", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Nombre", ParameterDirection.Input, eTypes.Cadena, L.Nombre);
                dsl.SetParameterProcedure("@Director", ParameterDirection.Input, eTypes.Cadena, L.Director);
                dsl.SetParameterProcedure("@Telefono", ParameterDirection.Input, eTypes.Cadena, L.Telefono);
                dsl.SetParameterProcedure("@Calle", ParameterDirection.Input, eTypes.Cadena, L.Calle);
                dsl.SetParameterProcedure("@Colonia", ParameterDirection.Input, eTypes.Cadena, L.Colonia);
                dsl.SetParameterProcedure("@Municipio", ParameterDirection.Input, eTypes.Cadena, L.Municipio);
                dsl.SetParameterProcedure("@Estado", ParameterDirection.Input, eTypes.Cadena, L.Estado);
                dsl.SetParameterProcedure("@Id", ParameterDirection.Output, eTypes.Entero, null);
                IDL= int.Parse(dsl.ExecuteStoredOutPut().ToString());
                dsl.Close();
                return IDL;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                dsl = null;
            }
        }

        public void AddServ(List<ItemServLab> LS, int idl)
        {
            try
            {
                foreach(ItemServLab SL in LS)
                {
                    dsl = new DSL();
                    dsl.Open("DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES", Proveedor.SQLServer);
                    dsl.InitialSQLStatement("dbo.usp_AddServs", CommandType.StoredProcedure);
                    dsl.SetParameterProcedure("@IdLab", ParameterDirection.Input, eTypes.Entero, idl);
                    dsl.SetParameterProcedure("@Serv", ParameterDirection.Input, eTypes.Cadena, SL.Servicio);
                    dsl.ExecuteNonQuery();
                    dsl.Close();
                }

                
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                dsl = null;
            }
        }

        public void ModLab(Modelos.Laboratorio L)
        {
            try
            {
                dsl = new DSL();
                dsl.Open("DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES", Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.usp_ModLab", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Id", ParameterDirection.Input, eTypes.Entero, L.IdLab);
                dsl.SetParameterProcedure("@Nombre", ParameterDirection.Input, eTypes.Cadena, L.Nombre);
                dsl.SetParameterProcedure("@Director", ParameterDirection.Input, eTypes.Cadena, L.Director);
                dsl.SetParameterProcedure("@Telefono", ParameterDirection.Input, eTypes.Cadena, L.Telefono);
                dsl.SetParameterProcedure("@Calle", ParameterDirection.Input, eTypes.Cadena, L.Calle);
                dsl.SetParameterProcedure("@Colonia", ParameterDirection.Input, eTypes.Cadena, L.Colonia);
                dsl.SetParameterProcedure("@Municipio", ParameterDirection.Input, eTypes.Cadena, L.Municipio);
                dsl.SetParameterProcedure("@Estado", ParameterDirection.Input, eTypes.Cadena, L.Estado);
                dsl.ExecuteNonQuery();
                dsl.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                dsl = null;
            }
        }

        public void DelLab(int IDL)
        {
            try
            {
                dsl = new DSL();
                dsl.Open("DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES", Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.usp_DelLab", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Id", ParameterDirection.Input, eTypes.Entero, IDL);
                dsl.ExecuteNonQuery();
                dsl.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                dsl = null;
            }
        }
        public List<Laboratorio> BusLab()
        {
            List<Laboratorio> LP = new List<Laboratorio>();
            Laboratorio P = new Laboratorio();
            dsl = new DSL();
            try
            {
                P = new Laboratorio();
                dsl.Open(Con, Proveedor.SQLServer);
                dsl.InitialSQLStatement("SELECT * FROM dbo.ConsAllLab();", CommandType.Text);
                DataTable Dt = dsl.ReturnTable();
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    P = new Laboratorio();
                    P.IdLab = int.Parse(Dt.Rows[i]["IdLab"].ToString());
                    P.Nombre = Dt.Rows[i]["Nombre"].ToString();
                    P.Director = Dt.Rows[i]["Director"].ToString();
                    P.Telefono = Dt.Rows[i]["Telefono"].ToString();
                    P.Calle = Dt.Rows[i]["Calle"].ToString();
                    P.Colonia = Dt.Rows[i]["Colonia"].ToString();
                    P.Municipio = Dt.Rows[i]["Municipio"].ToString();
                    P.Estado = Dt.Rows[i]["Estado"].ToString();
                    LP.Add(P);
                }
                //dsl.Close();
                return LP;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                dsl = null;
            }
        }
    }
}
