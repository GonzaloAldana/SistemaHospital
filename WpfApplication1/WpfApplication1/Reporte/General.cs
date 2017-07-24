
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integrador2017.Controller;
using Modelos;
using WpfApplication1.Model;
using System.IO;
using System.Configuration;
using RNConnection.DataStorageLayer;
using System.Data;

namespace WpfApplication1.Reporte
{
    class General
    {
        string Con = "DATA SOURCE = DESKTOP-LJO4T18\\SQLEXPRESS; INITIAL CATALOG = PROYECTOINTEGRADOR; INTEGRATED SECURITY = YES";
        string ruta = "C:\\Users\\Gonzalo\\Desktop\\INTEGRADORV1.111\\Reporte\\";

        public void GenerarReportePaciente(List<Paciente> pacientes)

        {
            FormarDoctoPDF documentoPDF = new FormarDoctoPDF();

            documentoPDF.ConfiguracionArchivo = new ConfigArchivo();
            documentoPDF.ConfiguracionEncabezado = new ConfigEncabezado();
            documentoPDF.ConfiguracionPiePagina = new ConfigPiePagina();

            //Configuración del Archivo Genérico
            documentoPDF.ConfiguracionArchivo.TipoHoja = eTipoHoja.Carta;
            documentoPDF.ConfiguracionArchivo.Fuente = eTipoFuente.Arial;
            documentoPDF.ConfiguracionArchivo.SizeFuente = eSizeFuente.Tiny;
            documentoPDF.ConfiguracionArchivo.OrientacionPagina = eOrientacion.Horizontal;
            documentoPDF.ConfiguracionArchivo.BCopiar = true;
            documentoPDF.ConfiguracionArchivo.BImprimir = false; //False se puede imprimir el documento, true no se puede imprimir el documento
            documentoPDF.ConfiguracionArchivo.BAccesibilidadContenido = true;
            documentoPDF.ConfiguracionArchivo.Resumen = false;

            #region Reporte Simple

            ReporteSimple reporteSimple = new ReporteSimple();
            reporteSimple.Escuela = "PACIENTES";
            reporteSimple.ParrafoCuerpo = "Pedro Armendariz";

            //Configuración del Archivo Personal
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "HTMLDesdeCodigoPaciente" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;

            string htmlCuerpo = "<p><table border='0'>" +
             "<tr>" +
                "<td align='left' colspan='5'>" +
                        "<h4>Archivo de Pacientes</h4>" +
                "</td>" +
            "</tr></table>";

            //Configuración del cuerpo
            htmlCuerpo += "<p><table border='0'>" +
             "<tr>" +
                "<td align='left' colspan='4'>" +
                    "<strong>" +
                        "<h4 align='center'>Pacientes registrados:</h4>" +
                    "</strong>" +
                "</td>";
            foreach (Paciente pac in pacientes)
            {
                htmlCuerpo += "<tr>" +
               "<td align='left' colspan='4'>" +
                       "<h4>" +
                       pac.Nombre + " "
                + pac.ApePaterno + " "
                + pac.ApeMaterno + ", "
               + pac.Municipio + " "
               + pac.Estado + ", "
               + pac.Calle + " "
               + pac.NumeroCasa + " "
               + pac.Colonia + ", CURP: "
               + pac.CURP + " "
               + pac.Edad + " años,"
               + pac.Email + ", <br>"
               + pac.Sexo + " "
               + pac.EstadoCivil + ", "
               + pac.Ocupacion + ", RFC: "
               + pac.RFC + ", Casa: "
               + pac.TelCasa + " Móvil: "
               + pac.TelMovil
                      + "</h4>" +
               "</td>" +
           "</tr>";
            }

            htmlCuerpo += "</tr>" +
            "</table>";

            reporteSimple.ParrafoCuerpo = htmlCuerpo;
            reporteSimple.InicialesUsuario = "Gonzalo Aldana Chávez";
            documentoPDF.ObtenerDocumentoPDF(null, reporteSimple);
            #endregion


            reporteSimple = new ReporteSimple();
            reporteSimple.Escuela = "PACINTES (Desde HTML existente)";
            reporteSimple.ParrafoCuerpo = "Pedro Armendariz";

            //Configuracion de archivo
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "HTMLExistentePac" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;

            string html = File.ReadAllText(ConfigurationManager.ConnectionStrings["RutaHTML"].ToString() + @"\Paciente.html");

            string aux = "";
            foreach (Paciente pac in pacientes)
            {
                aux += "<tr>" +
               "<td align='left' colspan='4'>" +
                       "<h4>" +
                       pac.Nombre + " "
                + pac.ApePaterno + " "
                + pac.ApeMaterno + ", "
               + pac.Municipio + " "
               + pac.Estado + ", "
               + pac.Calle + " "
               + pac.NumeroCasa + " "
               + pac.Colonia + ", CURP: "
               + pac.CURP + " "
               + pac.Edad + " años,"
               + pac.Email + ", <br>"
               + pac.Sexo + " "
               + pac.EstadoCivil + ", "
               + pac.Ocupacion + ", RFC: "
               + pac.RFC + ", Casa: "
               + pac.TelCasa + " Móvil: "
               + pac.TelMovil
                      + "</h4>" +
               "</td>" +
           "</tr>";
            }
            html = html.Replace("#CITAS#", aux);
            reporteSimple.ParrafoCuerpo = html;
            reporteSimple.InicialesUsuario = "GAC"; //Iniciales del usuario logeado
            documentoPDF.ObtenerDocumentoPDF(null, reporteSimple);
        }


        public void GenerarReporteLaboratorio(List<Laboratorio> laboratorios)

        {
            FormarDoctoPDF documentoPDF = new FormarDoctoPDF();

            documentoPDF.ConfiguracionArchivo = new ConfigArchivo();
            documentoPDF.ConfiguracionEncabezado = new ConfigEncabezado();
            documentoPDF.ConfiguracionPiePagina = new ConfigPiePagina();

            //Configuración del Archivo Genérico
            documentoPDF.ConfiguracionArchivo.TipoHoja = eTipoHoja.Carta;
            documentoPDF.ConfiguracionArchivo.Fuente = eTipoFuente.Arial;
            documentoPDF.ConfiguracionArchivo.SizeFuente = eSizeFuente.Tiny;
            documentoPDF.ConfiguracionArchivo.OrientacionPagina = eOrientacion.Horizontal;
            documentoPDF.ConfiguracionArchivo.BCopiar = true;
            documentoPDF.ConfiguracionArchivo.BImprimir = false; //False se puede imprimir el documento, true no se puede imprimir el documento
            documentoPDF.ConfiguracionArchivo.BAccesibilidadContenido = true;
            documentoPDF.ConfiguracionArchivo.Resumen = false;

            #region Reporte Simple

            ReporteSimple reporteSimple = new ReporteSimple();
            reporteSimple.Escuela = "LABORATORIOS";
            reporteSimple.ParrafoCuerpo = "Pedro Armendariz";

            //Configuración del Archivo Personal
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "HTMLDesdeCodigoLab" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;

            string htmlCuerpo = "<p><table border='0'>" +
             "<tr>" +
                "<td align='left' colspan='5'>" +
                        "<h4>Archivo de Laboratorios</h4>" +
                "</td>" +
            "</tr></table>";

            //Configuración del cuerpo
            htmlCuerpo += "<p><table border='0'>" +
             "<tr>" +
                "<td align='left' colspan='4'>" +
                    "<strong>" +
                        "<h4 align='center'>Laboratorios registrados:</h4>" +
                    "</strong>" +
                "</td>";
            foreach (Laboratorio lab in laboratorios)
            {
                htmlCuerpo += "<tr>" +
               "<td align='left' colspan='4'>" +
                       "<h4>" +
                       lab.Nombre + ", Director: "
                + lab.Director + ", "
               + lab.Municipio + " "
               + lab.Estado + ", "
               + lab.Calle + " "
               + lab.Colonia + ", Telefono: "
               + lab.Telefono
                      + "</h4>" +
               "</td>" +
           "</tr>";
            }

            htmlCuerpo += "</tr>" +
            "</table>";

            reporteSimple.ParrafoCuerpo = htmlCuerpo;
            reporteSimple.InicialesUsuario = "Gonzalo Aldana Chávez";
            documentoPDF.ObtenerDocumentoPDF(null, reporteSimple);
            #endregion


            reporteSimple = new ReporteSimple();
            reporteSimple.Escuela = "LABORATORIOS (Desde HTML existente)";
            reporteSimple.ParrafoCuerpo = "Pedro Armendariz";

            //Configuracion de archivo
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "HTMLExistenteLab" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;

            string html = File.ReadAllText(ConfigurationManager.ConnectionStrings["RutaHTML"].ToString() + @"\Laboratorio.html");

            string aux = "";
            foreach (Laboratorio lab in laboratorios)
            {
                aux += "<tr>" +
               "<td align='left' colspan='4'>" +
                       "<h4>" +
                       lab.Nombre + ", Director: "
                + lab.Director + ", "
               + lab.Municipio + " "
               + lab.Estado + ", "
               + lab.Calle + " "
               + lab.Colonia + ", Telefono: "
               + lab.Telefono
                      + "</h4>" +
               "</td>" +
           "</tr>";
            }
            html = html.Replace("#CITAS#", aux);
            reporteSimple.ParrafoCuerpo = html;
            reporteSimple.InicialesUsuario = "GAC"; //Iniciales del usuario logeado
            documentoPDF.ObtenerDocumentoPDF(null, reporteSimple);
        }


        public void GenerarReporteCita(List<Cita> citas)

        {/*
            Cita C = new Cita()
            {
                IdPaciente = 1,
                FechaHora = "12/12/1212 12:45"
            };
            citas.Add(C);
            citas.Add(C);*/
            FormarDoctoPDF documentoPDF = new FormarDoctoPDF();

            documentoPDF.ConfiguracionArchivo = new ConfigArchivo();
            documentoPDF.ConfiguracionEncabezado = new ConfigEncabezado();
            documentoPDF.ConfiguracionPiePagina = new ConfigPiePagina();

            //Configuración del Archivo Genérico
            documentoPDF.ConfiguracionArchivo.TipoHoja = eTipoHoja.Carta;
            documentoPDF.ConfiguracionArchivo.Fuente = eTipoFuente.Arial;
            documentoPDF.ConfiguracionArchivo.SizeFuente = eSizeFuente.Tiny;
            documentoPDF.ConfiguracionArchivo.OrientacionPagina = eOrientacion.Horizontal;
            documentoPDF.ConfiguracionArchivo.BCopiar = true;
            documentoPDF.ConfiguracionArchivo.BImprimir = false; //False se puede imprimir el documento, true no se puede imprimir el documento
            documentoPDF.ConfiguracionArchivo.BAccesibilidadContenido = true;
            documentoPDF.ConfiguracionArchivo.Resumen = false;

            #region Reporte Simple

            ReporteSimple reporteSimple = new ReporteSimple();
            reporteSimple.Escuela = "CITAS";
            reporteSimple.ParrafoCuerpo = "Pedro Armendariz";

            //Configuración del Archivo Personal
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "HTMLDesdeCodigoCita" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;

            string htmlCuerpo = "<p><table border='0'>" +
             "<tr>" +
                "<td align='left' colspan='5'>" +
                        "<h4>Archivo de Citas</h4>" +
                "</td>" +
            "</tr></table>";

            //Configuración del cuerpo
            htmlCuerpo += "<p><table border='0'>" +
             "<tr>" +
                "<td align='left' colspan='4'>" +
                    "<strong>" +
                        "<h4 align='center'>Citas registradas:</h4>" +
                    "</strong>" +
                "</td>";
            foreach (Cita cita in citas)
            {
                htmlCuerpo += "<tr>" +
               "<td align='left' colspan='4'>" +
                       "<h4> ID del paciente: " +
                       cita.IdPaciente + ", Fecha y Hora: "
                + cita.FechaHora + ", ";
                htmlCuerpo += "</h4>" +
               "</td>" +
           "</tr>";
            }

            htmlCuerpo += "</tr>" +
            "</table>";

            reporteSimple.ParrafoCuerpo = htmlCuerpo;
            reporteSimple.InicialesUsuario = "Gonzalo Aldana Chávez";
            documentoPDF.ObtenerDocumentoPDF(null, reporteSimple);
            #endregion


            reporteSimple = new ReporteSimple();
            reporteSimple.Escuela = "CITAS (Desde HTML existente)";
            reporteSimple.ParrafoCuerpo = "Pedro Armendariz";

            //Configuracion de archivo
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "HTMLExistenteCita" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;

            string html = File.ReadAllText(ConfigurationManager.ConnectionStrings["RutaHTML"].ToString() + @"\Cita.html");

            string aux = "";
            foreach (Cita cita in citas)
            {
                aux += "<tr>" +
               "<td align='left' colspan='4'>" +
                       "<h4> ID del paciente: " +
                       cita.IdPaciente + ", Fecha y Hora: "
                + cita.FechaHora + ", ";
                htmlCuerpo += "</h4>" +
               "</td>" +
           "</tr>";
            }
            html = html.Replace("#CITAS#", aux);
            reporteSimple.ParrafoCuerpo = html;
            reporteSimple.InicialesUsuario = "GAC"; //Iniciales del usuario logeado
            documentoPDF.ObtenerDocumentoPDF(null, reporteSimple);
        }

        public void GenerarReporteConsulta(Consulta cons)

        {
            FormarDoctoPDF documentoPDF = new FormarDoctoPDF();

            documentoPDF.ConfiguracionArchivo = new ConfigArchivo();
            documentoPDF.ConfiguracionEncabezado = new ConfigEncabezado();
            documentoPDF.ConfiguracionPiePagina = new ConfigPiePagina();

            //Configuración del Archivo Genérico
            documentoPDF.ConfiguracionArchivo.TipoHoja = eTipoHoja.Carta;
            documentoPDF.ConfiguracionArchivo.Fuente = eTipoFuente.Arial;
            documentoPDF.ConfiguracionArchivo.SizeFuente = eSizeFuente.Tiny;
            documentoPDF.ConfiguracionArchivo.OrientacionPagina = eOrientacion.Horizontal;
            documentoPDF.ConfiguracionArchivo.BCopiar = true;
            documentoPDF.ConfiguracionArchivo.BImprimir = false; //False se puede imprimir el documento, true no se puede imprimir el documento
            documentoPDF.ConfiguracionArchivo.BAccesibilidadContenido = true;
            documentoPDF.ConfiguracionArchivo.Resumen = false;

            #region Reporte Simple

            ReporteSimple reporteSimple = new ReporteSimple();
            reporteSimple.Escuela = "CONSULTAS";
            reporteSimple.ParrafoCuerpo = "Pedro Armendariz";

            //Configuración del Archivo Personal
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "HTMLDesdeCodigoConsulta" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;

            string htmlCuerpo = "<p><table border='0'>" +
             "<tr>" +
                "<td align='left' colspan='5'>" +
                        "<h4>Consulta de paciente ID: " + cons.IdPaciente + "</h4>" +
                "</td>" +
            "</tr></table>";

            //Configuración del cuerpo
            htmlCuerpo += "<p><table border='0'>" +
             "<tr>" +
                "<td align='left' colspan='4'>" +
                    "<strong>" +
                        "<h4 align='center'>Consulta:</h4>" +
                    "</strong>" +
                "</td>";
            htmlCuerpo += "<tr>" +
           "<td align='left' colspan='4'>" +
                   "<h4>" +
                   cons.Fecha + ", Motivo: "
            + cons.Motivo + "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Antecedentes: "
           + cons.Antecedentes + ", Diagnostico: "
           + cons.Diagnostico + "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Presión Arterial: "
           + cons.PresionArt + ", Peso: "
           + cons.Peso + ", Altura "
           + cons.Altura
                  + "</h4>" +
           "</td>" +
       "</tr>";

            htmlCuerpo += "</tr>" +
            "</table>";

            reporteSimple.ParrafoCuerpo = htmlCuerpo;
            reporteSimple.InicialesUsuario = "Gonzalo Aldana Chávez";
            documentoPDF.ObtenerDocumentoPDF(null, reporteSimple);
            #endregion

            reporteSimple = new ReporteSimple();
            reporteSimple.Escuela = "CONSULTA (Desde HTML existente)";
            reporteSimple.ParrafoCuerpo = "Pedro Armendariz";

            //Configuracion de archivo
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "HTMLExistenteConsulta" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;

            string html = File.ReadAllText(ConfigurationManager.ConnectionStrings["RutaHTML"].ToString() + @"\Consulta.html");

            html = html.Replace("#ID#", cons.IdPaciente.ToString());
            html = html.Replace("#FECHA#", DateTime.Now.ToString());
            html = html.Replace("#MOTIVO#", cons.Motivo);
            html = html.Replace("#ANTS#", cons.Antecedentes);
            html = html.Replace("#DIAG#", cons.Diagnostico);
            html = html.Replace("#PA#", cons.PresionArt);
            html = html.Replace("#PESO#", cons.Peso);
            html = html.Replace("#ALTURA#", cons.Altura);
            reporteSimple.ParrafoCuerpo = html;
            reporteSimple.InicialesUsuario = "GAC"; //Iniciales del usuario logeado
            documentoPDF.ObtenerDocumentoPDF(null, reporteSimple);
        }
        public void GenerarReporteReceta(Receta rec)

        {
            FormarDoctoPDF documentoPDF = new FormarDoctoPDF();

            documentoPDF.ConfiguracionArchivo = new ConfigArchivo();
            documentoPDF.ConfiguracionEncabezado = new ConfigEncabezado();
            documentoPDF.ConfiguracionPiePagina = new ConfigPiePagina();

            //Configuración del Archivo Genérico
            documentoPDF.ConfiguracionArchivo.TipoHoja = eTipoHoja.Carta;
            documentoPDF.ConfiguracionArchivo.Fuente = eTipoFuente.Arial;
            documentoPDF.ConfiguracionArchivo.SizeFuente = eSizeFuente.Tiny;
            documentoPDF.ConfiguracionArchivo.OrientacionPagina = eOrientacion.Horizontal;
            documentoPDF.ConfiguracionArchivo.BCopiar = true;
            documentoPDF.ConfiguracionArchivo.BImprimir = false; //False se puede imprimir el documento, true no se puede imprimir el documento
            documentoPDF.ConfiguracionArchivo.BAccesibilidadContenido = true;
            documentoPDF.ConfiguracionArchivo.Resumen = false;

            #region Reporte Simple

            ReporteSimple reporteSimple = new ReporteSimple();
            reporteSimple.Escuela = "RECETAS";
            reporteSimple.ParrafoCuerpo = "Pedro Armendariz";

            //Configuración del Archivo Personal
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "HTMLDesdeCodigoReceta" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;

            string htmlCuerpo = "<p><table border='0'>" +
             "<tr>" +
                "<td align='left' colspan='5'>" +
                        "<h4>Receta de paciente ID: " + rec.IdPaciente + "</h4>" +
                "</td>" +
            "</tr></table>";

            //Configuración del cuerpo
            htmlCuerpo += "<p><table border='0'>" +
             "<tr>" +
                "<td align='left' colspan='4'>" +
                    "<strong>" +
                        "<h4 align='center'>Receta registrada:</h4>" +
                    "</strong>" +
                "</td>";
            htmlCuerpo += "<tr>" +
           "<td align='left' colspan='4'>" +
                   "<h4> ID Paciente: " +
                   rec.IdPaciente + "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Diagnostico: "
           + rec.Diagnostico + "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Receta: "
           + rec.Cuerpo
                  + "</h4>" +
           "</td>" +
       "</tr>";


            htmlCuerpo += "</tr>" +
            "</table>";

            reporteSimple.ParrafoCuerpo = htmlCuerpo;
            reporteSimple.InicialesUsuario = "Gonzalo Aldana Chávez";
            documentoPDF.ObtenerDocumentoPDF(null, reporteSimple);
            #endregion


            reporteSimple = new ReporteSimple();
            reporteSimple.Escuela = "RECETA (Desde HTML existente)";
            reporteSimple.ParrafoCuerpo = "Pedro Armendariz";

            //Configuracion de archivo
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "HTMLExistenteReceta" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;

            string html = File.ReadAllText(ConfigurationManager.ConnectionStrings["RutaHTML"].ToString() + @"\Receta.html");

            html = html.Replace("#ID#", rec.IdPaciente.ToString());
            html = html.Replace("#DIAG#", rec.Diagnostico);
            html = html.Replace("#REC#", rec.Cuerpo);
            reporteSimple.ParrafoCuerpo = html;
            reporteSimple.InicialesUsuario = "GAC"; //Iniciales del usuario logeado
            documentoPDF.ObtenerDocumentoPDF(null, reporteSimple);
        }

        DSL dsl = new DSL();

        public void GenerarReporteCitasDesdeBD()
        {
            FormarDoctoPDF documentoPDF = new FormarDoctoPDF();

            documentoPDF.ConfiguracionArchivo = new ConfigArchivo();
            documentoPDF.ConfiguracionEncabezado = new ConfigEncabezado();
            documentoPDF.ConfiguracionPiePagina = new ConfigPiePagina();

            //configuracion del archivo
            documentoPDF.ConfiguracionArchivo.TipoHoja = eTipoHoja.Carta;
            documentoPDF.ConfiguracionArchivo.Fuente = eTipoFuente.Arial;
            documentoPDF.ConfiguracionArchivo.SizeFuente = eSizeFuente.Standar;
            documentoPDF.ConfiguracionArchivo.OrientacionPagina = eOrientacion.Vertical;
            documentoPDF.ConfiguracionArchivo.BCopiar = true;
            documentoPDF.ConfiguracionArchivo.BImprimir = false; //false se puede imprimir, true no se puede
            documentoPDF.ConfiguracionArchivo.BAccesibilidadContenido = true;
            documentoPDF.ConfiguracionArchivo.Resumen = false;

            #region Reporte apartir de un HTML
            ReporteSimple reportecitas = new ReporteSimple();
            dsl.Open(Con, RNConnection.DataAbstractionLayer.Proveedor.SQLServer);
            dsl.InitialSQLStatement("SELECT * FROM ReturnValuesCitas()", System.Data.CommandType.Text);
            DataTable tabla = dsl.ReturnTable();

            reportecitas.Escuela = "";
            reportecitas.Universidad = reportecitas.Escuela;

            //configuracion de archivo
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "reporteCitas" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                string html = File.ReadAllText(ConfigurationManager.ConnectionStrings["RutaHTML"].ToString() + @"\Reporte_Citas.html");
                html = html.Replace("#IDCITA#", tabla.Rows[i]["IdCita"].ToString());
                html = html.Replace("#IDPACIENTE#", tabla.Rows[i]["IdPaciente"].ToString());
                html = html.Replace("#FECHAHORA#", tabla.Rows[i]["FechaHora"].ToString());

                reportecitas.ParrafoCuerpo = html;
            }
            reportecitas.InicialesUsuario = "JCVE";
            documentoPDF.ObtenerDocumentoPDF(null, reportecitas);

        }

        public void GenerarReporteConsultaDesdeBD()
        {
            FormarDoctoPDF documentoPDF = new FormarDoctoPDF();

            documentoPDF.ConfiguracionArchivo = new ConfigArchivo();
            documentoPDF.ConfiguracionEncabezado = new ConfigEncabezado();
            documentoPDF.ConfiguracionPiePagina = new ConfigPiePagina();

            //configuracion del archivo
            documentoPDF.ConfiguracionArchivo.TipoHoja = eTipoHoja.Carta;
            documentoPDF.ConfiguracionArchivo.Fuente = eTipoFuente.Arial;
            documentoPDF.ConfiguracionArchivo.SizeFuente = eSizeFuente.Standar;
            documentoPDF.ConfiguracionArchivo.OrientacionPagina = eOrientacion.Vertical;
            documentoPDF.ConfiguracionArchivo.BCopiar = true;
            documentoPDF.ConfiguracionArchivo.BImprimir = false; //false se puede imprimir, true no se puede
            documentoPDF.ConfiguracionArchivo.BAccesibilidadContenido = true;
            documentoPDF.ConfiguracionArchivo.Resumen = false;
            ReporteSimple reporteconsultas = new ReporteSimple();
            dsl.Open(Con, RNConnection.DataAbstractionLayer.Proveedor.SQLServer);
            dsl.InitialSQLStatement("SELECT * FROM ReturnValuesConsultas()", System.Data.CommandType.Text);
            DataTable table = dsl.ReturnTable();

            reporteconsultas.Escuela = "";
            reporteconsultas.Universidad = reporteconsultas.Escuela;

            //configuracion de archivo
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "reporteConsultas" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string html = File.ReadAllText(ConfigurationManager.ConnectionStrings["RutaHTML"].ToString() + @"\Reporte_Consultas.html");
                html = html.Replace("#ID#", table.Rows[i]["IdHC"].ToString());
                html = html.Replace("#FECHA#", table.Rows[i]["Fecha"].ToString());
                html = html.Replace("#MOTIVO#", table.Rows[i]["Motivo"].ToString());
                html = html.Replace("#ANTECEDENTES#", table.Rows[i]["Antecedentes"].ToString());
                html = html.Replace("#DIAGNOSTICO#", table.Rows[i]["Diagnostico"].ToString());

                reporteconsultas.ParrafoCuerpo = html;
            }
            reporteconsultas.InicialesUsuario = "JCVE";
            documentoPDF.ObtenerDocumentoPDF(null, reporteconsultas);
        }


        public void GenerarReporteLaboratorioDesdeBD()
        {
            FormarDoctoPDF documentoPDF = new FormarDoctoPDF();

            documentoPDF.ConfiguracionArchivo = new ConfigArchivo();
            documentoPDF.ConfiguracionEncabezado = new ConfigEncabezado();
            documentoPDF.ConfiguracionPiePagina = new ConfigPiePagina();

            //configuracion del archivo
            documentoPDF.ConfiguracionArchivo.TipoHoja = eTipoHoja.Carta;
            documentoPDF.ConfiguracionArchivo.Fuente = eTipoFuente.Arial;
            documentoPDF.ConfiguracionArchivo.SizeFuente = eSizeFuente.Standar;
            documentoPDF.ConfiguracionArchivo.OrientacionPagina = eOrientacion.Vertical;
            documentoPDF.ConfiguracionArchivo.BCopiar = true;
            documentoPDF.ConfiguracionArchivo.BImprimir = false; //false se puede imprimir, true no se puede
            documentoPDF.ConfiguracionArchivo.BAccesibilidadContenido = true;
            documentoPDF.ConfiguracionArchivo.Resumen = false;
            ReporteSimple reportelaboratorios = new ReporteSimple();
            dsl.Open(Con, RNConnection.DataAbstractionLayer.Proveedor.SQLServer);
            dsl.InitialSQLStatement("SELECT * FROM ReturnValuesLaboratorios()", System.Data.CommandType.Text);
            DataTable teabla = dsl.ReturnTable();

            reportelaboratorios.Escuela = "";
            reportelaboratorios.Universidad = reportelaboratorios.Escuela;

            //configuracion de archivo
            documentoPDF.ConfiguracionArchivo.NombreArchivo = ruta + "reporteLaboratorios" + DateTime.Now.Ticks.ToString() + ".pdf";
            documentoPDF.ConfiguracionArchivo.TipoReporte = eTipoReporte.Simple;
            for (int i = 0; i < teabla.Rows.Count; i++)
            {
                string html = File.ReadAllText(ConfigurationManager.ConnectionStrings["RutaHTML"].ToString() + @"\Reporte_Laboratorios.html");
                html = html.Replace("#ID#", teabla.Rows[i]["IdLab"].ToString());
                html = html.Replace("#NOMBRE#", teabla.Rows[i]["Nombre"].ToString());
                html = html.Replace("#DIRECTOR#", teabla.Rows[i]["Director"].ToString());
                html = html.Replace("#TELEFONO#", teabla.Rows[i]["Telefono"].ToString());
                html = html.Replace("#CALLE#", teabla.Rows[i]["Calle"].ToString());
                html = html.Replace("#COLONIA#", teabla.Rows[i]["Colonia"].ToString());
                html = html.Replace("#MUNICIPIO#", teabla.Rows[i]["Municipio"].ToString());
                html = html.Replace("#ESTADO#", teabla.Rows[i]["Estado"].ToString());

                reportelaboratorios.ParrafoCuerpo = html;
            }
            reportelaboratorios.InicialesUsuario = "JCVE";
            documentoPDF.ObtenerDocumentoPDF(null, reportelaboratorios);
            #endregion
        }

    }
}
