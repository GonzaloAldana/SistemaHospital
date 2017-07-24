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
    class ControllerPaciente
    {
        DSL dsl = new DSL();
        List<Paciente> LP = new List<Paciente>();
        string Con = "DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES";
        public void AddPac(Paciente P)
        {
            try
            {
                dsl = new DSL();
                dsl.Open(Con, Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.usp_AddPac", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Nombre", ParameterDirection.Input, eTypes.Cadena, P.Nombre);
                dsl.SetParameterProcedure("@ApePat", ParameterDirection.Input, eTypes.Cadena, P.ApePaterno);
                dsl.SetParameterProcedure("@ApeMat", ParameterDirection.Input, eTypes.Cadena, P.ApeMaterno);
                dsl.SetParameterProcedure("@Edad", ParameterDirection.Input, eTypes.Cadena, P.Edad);
                dsl.SetParameterProcedure("@Sexo", ParameterDirection.Input, eTypes.Cadena, P.Sexo);
                dsl.SetParameterProcedure("@FechaNac", ParameterDirection.Input, eTypes.Cadena, P.FechaNacimiento);
                dsl.SetParameterProcedure("@EstadoCivil", ParameterDirection.Input, eTypes.Cadena, P.EstadoCivil);
                dsl.SetParameterProcedure("@RFC", ParameterDirection.Input, eTypes.Cadena, P.RFC);
                dsl.SetParameterProcedure("@CURP", ParameterDirection.Input, eTypes.Cadena, P.CURP);
                dsl.SetParameterProcedure("@Email", ParameterDirection.Input, eTypes.Cadena, P.Email);
                dsl.SetParameterProcedure("@Ocupacion", ParameterDirection.Input, eTypes.Cadena, P.Ocupacion);
                dsl.SetParameterProcedure("@Num", ParameterDirection.Input, eTypes.Cadena, P.NumeroCasa);
                dsl.SetParameterProcedure("@Calle", ParameterDirection.Input, eTypes.Cadena, P.Calle);
                dsl.SetParameterProcedure("@Colonia", ParameterDirection.Input, eTypes.Cadena, P.Colonia);
                dsl.SetParameterProcedure("@Estado", ParameterDirection.Input, eTypes.Cadena, P.Estado);
                dsl.SetParameterProcedure("@Municipio", ParameterDirection.Input, eTypes.Cadena, P.Municipio);
                dsl.SetParameterProcedure("@TelC", ParameterDirection.Input, eTypes.Cadena, P.TelCasa);
                dsl.SetParameterProcedure("@TelM", ParameterDirection.Input, eTypes.Cadena, P.TelMovil);
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

        public void ModPac(Paciente P)
        {
            
            try
            {
                dsl = new DSL();
                dsl.Open(Con, Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.usp_ModPac", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Nombre", ParameterDirection.Input, eTypes.Cadena, P.Nombre);
                dsl.SetParameterProcedure("@ApePat", ParameterDirection.Input, eTypes.Cadena, P.ApePaterno);
                dsl.SetParameterProcedure("@ApeMat", ParameterDirection.Input, eTypes.Cadena, P.ApeMaterno);
                dsl.SetParameterProcedure("@Edad", ParameterDirection.Input, eTypes.Cadena, P.Edad);
                dsl.SetParameterProcedure("@Sexo", ParameterDirection.Input, eTypes.Cadena, P.Sexo);
                dsl.SetParameterProcedure("@FechaNac", ParameterDirection.Input, eTypes.Cadena, P.FechaNacimiento);
                dsl.SetParameterProcedure("@EstadoCivil", ParameterDirection.Input, eTypes.Cadena, P.EstadoCivil);
                dsl.SetParameterProcedure("@RFC", ParameterDirection.Input, eTypes.Cadena, P.RFC);
                dsl.SetParameterProcedure("@CURP", ParameterDirection.Input, eTypes.Cadena, P.CURP);
                dsl.SetParameterProcedure("@Email", ParameterDirection.Input, eTypes.Cadena, P.Email);
                dsl.SetParameterProcedure("@Ocupacion", ParameterDirection.Input, eTypes.Cadena, P.Ocupacion);
                dsl.SetParameterProcedure("@TelefonoMovil", ParameterDirection.Input, eTypes.Cadena, P.TelMovil);
                dsl.SetParameterProcedure("@TelefonoCasa", ParameterDirection.Input, eTypes.Cadena, P.TelCasa);
                dsl.SetParameterProcedure("@Calle", ParameterDirection.Input, eTypes.Cadena, P.Calle);
                dsl.SetParameterProcedure("@Colonia", ParameterDirection.Input, eTypes.Cadena, P.Colonia);
                dsl.SetParameterProcedure("@Estado", ParameterDirection.Input, eTypes.Cadena, P.Estado);
                dsl.SetParameterProcedure("@Municipio", ParameterDirection.Input, eTypes.Cadena, P.Municipio);
                dsl.SetParameterProcedure("@Num", ParameterDirection.Input, eTypes.Cadena, P.NumeroCasa);
                dsl.SetParameterProcedure("@IdPe", ParameterDirection.Input, eTypes.Entero, P.IdPersona);
                dsl.ExecuteNonQuery();
                dsl.Close();

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

        public void DelPac(int IDP)
        {
            try
            {
                dsl = new DSL();
                dsl.Open(Con, Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.usp_DelPac", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Id", ParameterDirection.Input, eTypes.Entero, IDP);
                dsl.ExecuteNonQuery();
                dsl.Close();
            }
            catch(Exception e)
            {
                throw new Exception();
            }
            finally
            {
                dsl = null;
            }
        }
        public List<Paciente> ShowAllPac()
        {
            List<Paciente> LP = new List<Paciente>();
            Paciente P = new Paciente();
            dsl = new DSL();
            try
            {
                P = new Paciente();
                dsl.Open(Con, Proveedor.SQLServer);
                dsl.InitialSQLStatement("SELECT * FROM dbo.ConsAllPac();", CommandType.Text);
                DataTable Dt = dsl.ReturnTable();
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    P = new Paciente();
                    P.IdPaciente = int.Parse(Dt.Rows[i]["IdPaciente"].ToString());
                    P.Nombre = Dt.Rows[i]["Nombre"].ToString();
                    P.ApePaterno = Dt.Rows[i]["ApePat"].ToString();
                    P.ApeMaterno = Dt.Rows[i]["ApeMat"].ToString();
                    P.Edad = int.Parse(Dt.Rows[i]["Edad"].ToString());
                    P.Sexo = Dt.Rows[i]["Sexo"].ToString();
                    P.FechaNacimiento = Dt.Rows[i]["FechaNac"].ToString();
                    P.EstadoCivil = Dt.Rows[i]["EstadoCivil"].ToString();
                    P.RFC = Dt.Rows[i]["RFC"].ToString();
                    P.CURP = Dt.Rows[i]["CURP"].ToString();
                    P.Ocupacion = Dt.Rows[i]["Ocupacion"].ToString();
                    P.NumeroCasa = Dt.Rows[i]["NumeroCasa"].ToString();
                    P.Calle = Dt.Rows[i]["Calle"].ToString();
                    P.Colonia = Dt.Rows[i]["Colonia"].ToString();
                    P.Estado = Dt.Rows[i]["Estado"].ToString();
                    P.Municipio = Dt.Rows[i]["Municipio"].ToString();
                    P.TelCasa = Dt.Rows[i]["TelefonoCasa"].ToString();
                    P.TelMovil = Dt.Rows[i]["TelefonoMovil"].ToString();
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
        public List<Paciente> BusPacNapFe(Paciente PP)
        {
            List<Paciente> LP = new List<Paciente>();
            Paciente P = new Paciente();
            dsl = new DSL();
            try
            {
                P = new Paciente();
                dsl.Open(Con, Proveedor.SQLServer);
                dsl.InitialSQLStatement("SELECT * FROM dbo.ConsPacientesNomApAmFec('" + PP.Nombre+"','"+PP.ApePaterno+"','"+PP.ApeMaterno+"','"+PP.FechaNacimiento+"');", CommandType.Text);
                DataTable Dt = dsl.ReturnTable();
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    P = new Paciente();

                    P.Nombre = Dt.Rows[i]["Nombre"].ToString();
                    P.ApePaterno = Dt.Rows[i]["ApePat"].ToString();
                    P.ApeMaterno = Dt.Rows[i]["ApeMat"].ToString();
                    P.Edad = int.Parse(Dt.Rows[i]["Edad"].ToString());
                    P.Sexo = Dt.Rows[i]["Sexo"].ToString();
                    P.FechaNacimiento = Dt.Rows[i]["FechaNac"].ToString();
                    P.EstadoCivil = Dt.Rows[i]["EstadoCivil"].ToString();
                    P.RFC = Dt.Rows[i]["RFC"].ToString();
                    P.CURP = Dt.Rows[i]["CURP"].ToString();
                    P.Ocupacion = Dt.Rows[i]["Ocupacion"].ToString();
                    P.NumeroCasa = Dt.Rows[i]["NumeroCasa"].ToString();
                    P.Calle = Dt.Rows[i]["Calle"].ToString();
                    P.Colonia = Dt.Rows[i]["Colonia"].ToString();
                    P.Estado = Dt.Rows[i]["Estado"].ToString();
                    P.Municipio = Dt.Rows[i]["Municipio"].ToString();
                    P.TelCasa = Dt.Rows[i]["TelefonoCasa"].ToString();
                    P.TelMovil = Dt.Rows[i]["TelefonoMovil"].ToString();
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
        public List<Paciente> BusIdPac(Paciente PP)
        {
            List<Paciente> LP = new List<Paciente>();
            Paciente P = new Paciente();
            dsl = new DSL();
            try
            {
                P = new Paciente();
                dsl.Open(Con, Proveedor.SQLServer);
                dsl.InitialSQLStatement("SELECT * FROM dbo.ConsIdPac(" + PP.IdPersona + ");", CommandType.Text);
                DataTable Dt = dsl.ReturnTable();
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    P = new Paciente();

                    P.Nombre = Dt.Rows[i]["Nombre"].ToString();
                    P.ApePaterno = Dt.Rows[i]["ApePat"].ToString();
                    P.ApeMaterno = Dt.Rows[i]["ApeMat"].ToString();
                    P.Edad = int.Parse(Dt.Rows[i]["Edad"].ToString());
                    P.Sexo = Dt.Rows[i]["Sexo"].ToString();
                    P.FechaNacimiento = Dt.Rows[i]["FechaNac"].ToString();
                    P.EstadoCivil = Dt.Rows[i]["EstadoCivil"].ToString();
                    P.RFC = Dt.Rows[i]["RFC"].ToString();
                    P.CURP = Dt.Rows[i]["CURP"].ToString();
                    P.Ocupacion = Dt.Rows[i]["Ocupacion"].ToString();
                    P.NumeroCasa = Dt.Rows[i]["NumeroCasa"].ToString();
                    P.Calle = Dt.Rows[i]["Calle"].ToString();
                    P.Colonia = Dt.Rows[i]["Colonia"].ToString();
                    P.Estado = Dt.Rows[i]["Estado"].ToString();
                    P.Municipio = Dt.Rows[i]["Municipio"].ToString();
                    P.TelCasa = Dt.Rows[i]["TelefonoCasa"].ToString();
                    P.TelMovil = Dt.Rows[i]["TelefonoMovil"].ToString();
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
