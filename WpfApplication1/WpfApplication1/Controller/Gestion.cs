using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNConnection.DataAbstractionLayer;
using RNConnection.DataStorageLayer;
using Modelos;
using System.Data;

namespace MedSoft.Controller
{
    class Gestion
    {
        string Con = "DATA SOURCE = JARVIS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES";
        DSL dsl = new DSL();
        public int CheckUser(Usuario U)
        {
           // DSL dsl = new DSL();
            int IDT=0;
            //Usuario Us = new Usuario();
            dsl = new DSL();
            DataTable Dt = new DataTable();
            try
            {
                dsl.Open(Con, Proveedor.SQLServer);
                dsl.InitialSQLStatement("dbo.CheckUser", CommandType.StoredProcedure);
                dsl.SetParameterProcedure("Id", ParameterDirection.Output, eTypes.Entero,null);
                dsl.SetParameterProcedure("NombreU", ParameterDirection.Input, eTypes.Cadena, U.NombreUsuario);
                dsl.SetParameterProcedure("Password", ParameterDirection.Input, eTypes.Cadena, U.CodigoAcceso);
                IDT = int.Parse(dsl.ExecuteStoredOutPut().ToString());
                dsl.Close();
                return IDT;
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
