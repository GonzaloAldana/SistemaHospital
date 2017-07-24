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
    class ControllerHistorial
    {
        DSL dsl = new DSL();

        public void AddHC(Paciente P, Consulta HC)
        {
            try
            {
                dsl = new DSL();
                dsl.Open("DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES", Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.usp_AddHC", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Id", ParameterDirection.Input, eTypes.Entero, P.IdPaciente);
                dsl.SetParameterProcedure("@Peso", ParameterDirection.Input, eTypes.Entero, HC.Peso);
                dsl.SetParameterProcedure("@Altura", ParameterDirection.Input, eTypes.Entero,HC.Altura);
                dsl.SetParameterProcedure("@Presion", ParameterDirection.Input, eTypes.Entero, HC.PresionArt);
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
    }
}
