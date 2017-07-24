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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using MedSoft.View;
using Contedores;
using WpfApplication1.View.UcControls;

namespace WpfApplication1.View
{
    /// <summary>
    /// Lógica de interacción para WindowDoctor.xaml
    /// </summary>
    public partial class WindowDoctor : MetroWindow
    {
        UcLaboratorio UL = new UcLaboratorio();
        UcPaciente up = new UcPaciente();
        public WindowDoctor()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Login L = new Login();
            L.Show();
            this.Close();
        }

        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            LlenarContenedor.LelnarUserControl(G1, new UcControls.UcPaciente());
            
        }

        private void Tile_Click_1(object sender, RoutedEventArgs e)
        {
            LlenarContenedor.LelnarUserControl(G1, new UcControls.UcConsulta());
        }

        private void Tile_Click_2(object sender, RoutedEventArgs e)
        {
            LlenarContenedor.LelnarUserControl(G1, new UcControls.UcDocCitas());
        }

        private void Tile_Click_3(object sender, RoutedEventArgs e)
        {
            LlenarContenedor.LelnarUserControl(G1, new UcControls.UcDocLab());
        }
    }
}
