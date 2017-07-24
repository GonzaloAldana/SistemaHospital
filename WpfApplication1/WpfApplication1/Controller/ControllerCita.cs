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
    class ControllerCita
    {
        string Con = "DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES";
        DSL dsl = new DSL();

        public void AddCita(int IDP, Cita C)
        {
            try
            {
                dsl = new DSL();
                dsl.Open("DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES", Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.usp_AddCita", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Id", ParameterDirection.Input, eTypes.Entero, IDP);
                dsl.SetParameterProcedure("@Fec", ParameterDirection.Input, eTypes.Cadena, C.FechaHora);
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

        public void ModCita(int IDC, Cita C)
        {
            try
            {
                dsl = new DSL();
                dsl.Open("DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES", Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.usp_AddCita", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Id", ParameterDirection.Input, eTypes.Entero, IDC);
                dsl.SetParameterProcedure("@Fec", ParameterDirection.Input, eTypes.Cadena, C.FechaHora);
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

        public void DelCita(int IDC)
        {
            try
            {
                dsl = new DSL();
                dsl.Open("DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES", Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.usp_DelCita", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Id", ParameterDirection.Input, eTypes.Entero, IDC);
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
        public List<Cita> BusCita(string Fec)
        {
            Paciente p = new Paciente();
            List<Cita> LP = new List<Cita>();
            Cita P = new Cita();
            dsl = new DSL();
            try
            {
                P = new Cita();
                dsl.Open(Con, Proveedor.SQLServer);
                dsl.InitialSQLStatement("SELECT * FROM dbo.ConsCitFec('"+Fec+"');", CommandType.Text);
                DataTable Dt = dsl.ReturnTable();
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    P = new Cita();
                    P.FechaHora = Dt.Rows[i]["FechaHora"].ToString();
                    P.Nombre = Dt.Rows[i]["Nombre"].ToString();
                   
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
