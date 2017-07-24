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
    class ControllerConsulta
    {
        DSL dsl = new DSL();

        public void AddCons(Consulta C, int IDCH)
        {
            try
            {
                dsl = new DSL();
                dsl.Open("DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES", Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.usp_AddCons", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("@IdPac", ParameterDirection.Input, eTypes.Entero, IDCH);
                dsl.SetParameterProcedure("@Peso", ParameterDirection.Input, eTypes.Entero, C.Peso);
                dsl.SetParameterProcedure("@Altura", ParameterDirection.Input, eTypes.Entero, C.Altura);
                dsl.SetParameterProcedure("@Presion", ParameterDirection.Input, eTypes.Cadena, C.PresionArt);
                dsl.SetParameterProcedure("@Motivo", ParameterDirection.Input, eTypes.Cadena, C.Motivo);
                dsl.SetParameterProcedure("@Antecedentes", ParameterDirection.Input, eTypes.Cadena, C.Antecedentes);
                dsl.SetParameterProcedure("@Diagnostico", ParameterDirection.Input, eTypes.Cadena, C.Diagnostico);
                dsl.SetParameterProcedure("@Receta", ParameterDirection.Input, eTypes.Cadena, C.Receta);
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
