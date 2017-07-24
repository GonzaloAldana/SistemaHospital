using Integrador2017.Controller;
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
    /// Lógica de interacción para UcDocLab.xaml
    /// </summary>
    public partial class UcDocLab : UserControl
    {
        ControllerLab CL = new ControllerLab();
        public UcDocLab()
        {
            InitializeComponent();
            dtgBuscarLab.ItemsSource = null;
            dtgBuscarLab.ItemsSource = CL.BusLab();
        }

        private void btnRegresar(object sender, RoutedEventArgs e)
        {
            WpfApplication1.View.WindowAdministrador u = new WindowAdministrador();//Ventana que se va a mostrar
            u.Show();
            Window.GetWindow(this).Close();//Ventana que se va a cerrar
        }
    }
}
