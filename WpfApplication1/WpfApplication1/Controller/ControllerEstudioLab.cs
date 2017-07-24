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
    class ControllerEstudioLab
    {
        DSL dsl = new DSL();

        public void AddEL(int IDP, int IDL, EstudioLab EL)
        {
            try
            {
                dsl = new DSL();
                dsl.Open("DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES", Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.usp_AddEL", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@Idp", ParameterDirection.Input, eTypes.Entero, IDP);
                dsl.SetParameterProcedure("@Idl", ParameterDirection.Input, eTypes.Entero, IDL);
                dsl.SetParameterProcedure("@Motivo", ParameterDirection.Input, eTypes.Cadena, EL.Motivo);
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
    }
}
