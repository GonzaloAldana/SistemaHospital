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

namespace WpfApplication1.View.UcControls
{
    /// <summary>
    /// Lógica de interacción para UcPacienteSecre.xaml
    /// </summary>
    public partial class UcPacienteSecre : UserControl
    {
        int ID = 0;
        ControllerPaciente CP = new ControllerPaciente();
        Paciente P = new Paciente();
        public UcPacienteSecre()
        {
            InitializeComponent();
            dtgModPac.ItemsSource = CP.ShowAllPac();
        }

        private void btnRegresar(object sender, RoutedEventArgs e)
        {
            WpfApplication1.View.WindowSecretaria u = new WindowSecretaria();//Ventana que se va a mostrar
            u.Show();
            Window.GetWindow(this).Close();//Ventana que se va a cerrar
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dtgModPac.ItemsSource = null;
            dtgModPac.ItemsSource = CP.ShowAllPac();
            dtgBuscarPac.ItemsSource = null;
            dtgBuscarPac.ItemsSource = CP.ShowAllPac();
            P.Nombre = txtAddNomPac.Text;
            P.ApePaterno = txtAddApPac.Text;
            P.ApeMaterno = txtAddAmPac.Text;
            P.Edad = int.Parse(txtAddEdadPac.Text);
            P.Sexo = txtAddSexPac.Text;
            P.FechaNacimiento = txtAddFechPac.Text;
            P.EstadoCivil = txtAddEstatPac.Text;
            P.Estado = txtAddEstPac.Text;
            P.RFC = txtAddRFCPac.Text;
            P.CURP = txtAddCURPPac.Text;
            P.Email = txtAddMailPac.Text;
            P.TelMovil = txtAddTelMPac.Text;
            P.TelCasa = txtAddTelCPac.Text;
            P.NumeroCasa = txtAddNumPac.Text;
            P.Calle = txtAddCallePac.Text;
            P.Colonia = txtAddColoniaPac.Text;
            P.Municipio = txtAddMuniPac.Text;
            P.Ocupacion = txtAddOcuPac.Text;
            CP.AddPac(P);

        }

        private void btnBucarPac_Click(object sender, RoutedEventArgs e)
        {
            dtgModPac.ItemsSource = null;
            dtgModPac.ItemsSource = CP.ShowAllPac();
            dtgBuscarPac.ItemsSource = null;
            dtgBuscarPac.ItemsSource = CP.ShowAllPac();
            List<Paciente> LP = new List<Paciente>();
            P = new Paciente();
            P.Nombre = txtBusNomPac.Text;
            P.ApePaterno = txtBusApPac.Text;
            P.ApeMaterno = txtBusAmPac.Text;
            P.FechaNacimiento = txtBusFechPac.Text;
            LP = CP.BusPacNapFe(P);
            dtgBuscarPac.ItemsSource = null;
            dtgBuscarPac.ItemsSource = LP;
        }

        private void btnModPac_Click(object sender, RoutedEventArgs e)
        {
            dtgModPac.ItemsSource = null;
            dtgModPac.ItemsSource = CP.ShowAllPac();
            dtgBuscarPac.ItemsSource = null;
            dtgBuscarPac.ItemsSource = CP.ShowAllPac();
            P.Nombre = txtModNomPac.Text;
            P.ApePaterno = txtModApPac.Text;
            P.ApeMaterno = txtModAmPac.Text;
            P.Edad = int.Parse(txtModEdadPac.Text);
            P.Sexo = txtModSexPac.Text;
            P.FechaNacimiento = txtModFechPac.Text;
            P.EstadoCivil = txtModEstatCivPac.Text;
            P.Estado = txtModEstPac.Text;
            P.RFC = txtModRFCPac.Text;
            P.CURP = txtModCURPPac.Text;
            P.Email = txtModEmailPac.Text;
            P.TelMovil = txtModTelMPac.Text;
            P.TelCasa = txtModTelCPac.Text;
            P.NumeroCasa = txtModNumC.Text;
            P.Calle = txtModCallePac.Text;
            P.Colonia = txtModColoniaPac.Text;
            P.Municipio = txtModMuniPac.Text;
            P.Ocupacion = txtModOcuPac.Text;
            P.IdPersona = ID;
            CP.ModPac(P);
            dtgModPac.ItemsSource = null;
            dtgModPac.ItemsSource = CP.ShowAllPac();
            dtgBuscarPac.ItemsSource = null;
            dtgBuscarPac.ItemsSource = CP.ShowAllPac();
        }

        private void btnElegir_Click(object sender, RoutedEventArgs e)
        {
            dtgModPac.ItemsSource = null;
            dtgModPac.ItemsSource = CP.ShowAllPac();
            dtgBuscarPac.ItemsSource = null;
            dtgBuscarPac.ItemsSource = CP.ShowAllPac();
            List<Paciente> LX = new List<Paciente>();
            P = new Paciente();
            P.IdPersona = int.Parse(txtModIdP.Text);
            ID = int.Parse(txtModIdP.Text);
            //  LX = CP.BusIdPac(P);

        }

        private void btnElegire_Click(object sender, RoutedEventArgs e)
        {
            dtgModPac.ItemsSource = null;
            dtgModPac.ItemsSource = CP.ShowAllPac();
            dtgBuscarPac.ItemsSource = null;
            dtgBuscarPac.ItemsSource = CP.ShowAllPac();
            List<Paciente> LX = new List<Paciente>();
            P = new Paciente();
            P.IdPersona = int.Parse(txtModIdP.Text);
            ID = int.Parse(txtModIdP.Text);
        }
    }
}
