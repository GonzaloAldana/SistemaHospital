using Integrador2017.Controller;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.Model;
using WpfApplication1.Reporte;

namespace WpfApplication1.View.UcControls
{
    /// <summary>
    /// Lógica de interacción para UcConsulta.xaml
    /// </summary>
    public partial class UcConsulta : UserControl
    {
        General gen = new General();
        ControllerConsulta CC = new ControllerConsulta();
        ControllerPaciente CP = new ControllerPaciente();
        ControllerLab CL = new ControllerLab();
        ControllerEstudioLab CEL = new ControllerEstudioLab();
        Paciente P = new Paciente();
        Consulta C = new Consulta();
        int ID = 0;
        public UcConsulta()
        {
            InitializeComponent();
            dtgLabs.ItemsSource = null;
            dtgLabs.ItemsSource = CL.BusLab();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = CP.ShowAllPac();
        }

        private void btnRegresar(object sender, RoutedEventArgs e)
        {
            WpfApplication1.View.WindowAdministrador u = new WindowAdministrador();//Ventana que se va a mostrar
            u.Show();
            Window.GetWindow(this).Close();//Ventana que se va a cerrar
        }

        private void btnPro_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            P = new Paciente();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = CP.ShowAllPac();
            C = new Consulta();
            C.IdPaciente = int.Parse(txtIdPac.Text);
            C.Peso = txtPeso.Text;
            C.PresionArt = txtPresion.Text;
            C.Altura = texAltura.Text;
            C.Antecedentes = txtAntece.Text;
            C.Motivo = txtMotivo.Text;
            C.Diagnostico = txtDiag.Text;
            C.Receta = txtRec.Text;
            CC.AddCons(C, C.IdPaciente);
        }

        private void btnAddEL_Click(object sender, RoutedEventArgs e)
        {
            EstudioLab E = new EstudioLab();
            E.Motivo = txtorden.Text;
            dtgLabs.ItemsSource = null;
            dtgLabs.ItemsSource = CL.BusLab();
            txtId2.Text = txtIdPac.Text;
            CEL.AddEL(int.Parse(txtId2.Text), int.Parse(txtIdlab.Text), E);
        }

        private void btnAddcita_Click(object sender, RoutedEventArgs e)
        {
            
            ID=int.Parse(txtIdPac.Text);
            P = new Paciente();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = CP.ShowAllPac();
            C = new Consulta();
            C.IdPaciente = int.Parse(txtIdPac.Text);
            txtId2.Text = txtIdPac.Text;
            C.Peso = txtPeso.Text;
            C.PresionArt = txtPresion.Text;
            C.Altura = texAltura.Text;
            C.Antecedentes = txtAntece.Text;
            C.Motivo = txtMotivo.Text;
            C.Diagnostico = txtDiag.Text;
            C.Receta = txtRec.Text;
            CC.AddCons(C, C.IdPaciente);
            txtId2.Text = txtIdPac.Text;

        }

        private void btnAddcita_Copy_Click(object sender, RoutedEventArgs e)
        {

            Consulta cons = new Consulta()
            {
                IdPaciente = int.Parse(txtIdPac.Text),
                Altura = texAltura.Text,
                Antecedentes = txtAntece.Text,
                Peso = txtPeso.Text,
                PresionArt = txtPresion.Text,
                Fecha = DateTime.Now.ToString(),
                Motivo = txtMotivo.Text,
                Diagnostico = txtDiag.Text,
                Receta = txtRec.Text

            };
            gen.GenerarReporteConsulta(cons);
            gen.GenerarReporteConsultaDesdeBD();
            
        }

        private void btnReporteReceta_Click(object sender, RoutedEventArgs e)
        {

            Receta rec = new Receta()
            {
                Cuerpo = txtRec.Text,
                IdPaciente = int.Parse(txtIdPac.Text),
                Diagnostico = txtDiag.Text
            };
            gen.GenerarReporteReceta(rec);            
        }
    }
}
