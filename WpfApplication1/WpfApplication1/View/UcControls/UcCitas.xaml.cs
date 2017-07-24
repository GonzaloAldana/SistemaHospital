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
using WpfApplication1.Reporte;

namespace WpfApplication1.View.UcControls
{
    /// <summary>
    /// Lógica de interacción para UcCitas.xaml
    /// </summary>
    public partial class UcCitas : UserControl
    {
        List<Paciente> LP = new List<Paciente>();
        ControllerCita CC = new ControllerCita();
        General gen = new General();
        ControllerPaciente CP = new ControllerPaciente();
        public UcCitas()
        {
            InitializeComponent();
            LP=CP.ShowAllPac();
            dtgAddCita.ItemsSource = LP;
            dtgBusCitaMod.ItemsSource = LP;
        }

        private void btnRegresar(object sender, RoutedEventArgs e)
        {
           WpfApplication1.View.WindowAdministrador u = new WindowAdministrador();//Ventana que se va a mostrar
            u.Show();
            Window.GetWindow(this).Close();//Ventana que se va a cerrar
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAgregarCita_Click(object sender, RoutedEventArgs e)
        {
            dtgBusCitaMod.ItemsSource = null;
            Cita C = new Cita();
            C.FechaHora = txtDia.Text + "/" + txtMes.Text + "/" + txtAño.Text + " " + txtHora.Text;
            C.IdPaciente = int.Parse(txtIdPac.Text);
            CC.AddCita(C.IdPaciente, C);
            dtgBusCitaMod.ItemsSource = LP;

        }

        private void btnBuscarCita_Click(object sender, RoutedEventArgs e)
        {
            dtgbusCita.ItemsSource = CC.BusCita(txtNombreCita.Text);
        }

        private void dtgBusCitaMod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnModCita_Click(object sender, RoutedEventArgs e)
        {
            dtgBusCitaMod.ItemsSource = null;
            dtgBusCitaMod.ItemsSource = LP;
            Cita C = new Cita();
            C.IdCita = int.Parse(txtIdCita.Text);
            C.FechaHora = txtDia.Text + "/" + txtMes.Text + "/" + txtAño.Text + " " + txtHora.Text;
            CC.ModCita(C.IdCita, C);
        }

        private void btnReporteTodo_Click(object sender, RoutedEventArgs e)
        {
            gen.GenerarReporteCitasDesdeBD();
            gen.GenerarReporteCita(CC.BusCita(txtNombreCita.Text));
        }
    }
}
