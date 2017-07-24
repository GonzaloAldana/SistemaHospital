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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using Contedores;
using MedSoft.View;

namespace WpfApplication1.View
{
    /// <summary>
    /// Lógica de interacción para WindowAdministrador.xaml
    /// </summary>
    public partial class WindowAdministrador : MetroWindow
    {
        
        public WindowAdministrador()
        {
            InitializeComponent();
        }
        private void ShowUcPacientes(object sender, RoutedEventArgs e)
        {
            LlenarContenedor.LelnarUserControl(G1, new UcControls.UcPaciente());
        }

        private void ShowUcLaboratorios(object sender, RoutedEventArgs e)
        {
            LlenarContenedor.LelnarUserControl(G1, new UcControls.UcLaboratorio());
        }

        private void ShowUcAgendarCita(object sender, RoutedEventArgs e)
        {
            LlenarContenedor.LelnarUserControl(G1, new UcControls.UcCitas());
        }

        private void ShowUcConsultas(object sender, RoutedEventArgs e)
        {
            LlenarContenedor.LelnarUserControl(G1, new UcControls.UcConsulta());
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Login L = new Login();
            L.Show();
            this.Close();
        }
    }
}
