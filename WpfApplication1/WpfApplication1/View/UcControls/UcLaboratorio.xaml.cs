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
using Modelos;
using Integrador2017.Controller;
using WpfApplication1.Reporte;

namespace WpfApplication1.View.UcControls
{
    /// <summary>
    /// Lógica de interacción para UcLaboratorio.xaml
    /// </summary>
    public partial class UcLaboratorio : UserControl
    {
        ControllerLab CL = new ControllerLab();
        Laboratorio L = new Laboratorio();
        ItemServLab SL = new ItemServLab();
        List<ItemServLab> LS = new List<ItemServLab>();
        General gen = new General();
        int IDL;
        public UcLaboratorio()
        {
            InitializeComponent();
            dtgModLab.ItemsSource = null;
            dtgModLab.ItemsSource = CL.BusLab();
            dtgDelLab.ItemsSource = null;
            dtgDelLab.ItemsSource = CL.BusLab();
            dtgBuscarLab.ItemsSource = null;
            dtgBuscarLab.ItemsSource = CL.BusLab();
        }

        private void btnRegresar(object sender, RoutedEventArgs e)
        {
            WpfApplication1.View.WindowAdministrador u = new WindowAdministrador();//Ventana que se va a mostrar
            u.Show();
            Window.GetWindow(this).Close();//Ventana que se va a cerrar
        }

        private void btnAddLab_Click(object sender, RoutedEventArgs e)
        {
            L = new Laboratorio();
            L.Nombre = txtAddNombreLab.Text;
            L.Director = txtAddDirLab.Text;
            L.Telefono = txtAddTelLab.Text;
            L.Calle = txtModCalleLab.Text;
            L.Colonia = txtAddColLab.Text;
            L.Municipio = txtAddMunLab.Text;
            L.Estado = txtAddEstLab.Text;
            IDL=CL.AddLab(L);
            dtgModLab.ItemsSource = null;
            dtgModLab.ItemsSource = CL.BusLab();
            dtgDelLab.ItemsSource = null;
            dtgDelLab.ItemsSource = CL.BusLab();
            dtgBuscarLab.ItemsSource = null;
            dtgBuscarLab.ItemsSource = CL.BusLab();

        }

        private void btnAddItemsLab_Click(object sender, RoutedEventArgs e)
        {
            SL = new ItemServLab();
            SL.Servicio = txServicio.Text;
            LS.Add(SL);
            dtgModLab.ItemsSource = null;
            dtgModLab.ItemsSource = CL.BusLab();
            dtgDelLab.ItemsSource = null;
            dtgDelLab.ItemsSource = CL.BusLab();
            dtgBuscarLab.ItemsSource = null;
            dtgBuscarLab.ItemsSource = CL.BusLab();
        }

        private void btnFinishAddLab_Click(object sender, RoutedEventArgs e)
        {
            CL.AddServ(LS, IDL);
            dtgModLab.ItemsSource = null;
            dtgModLab.ItemsSource = CL.BusLab();
            dtgDelLab.ItemsSource = null;
            dtgDelLab.ItemsSource = CL.BusLab();
            dtgBuscarLab.ItemsSource = null;
            dtgBuscarLab.ItemsSource = CL.BusLab();
        }

        private void btnAgregar_Copy12_Click(object sender, RoutedEventArgs e)
        {
            dtgModLab.ItemsSource = null;
            dtgModLab.ItemsSource = CL.BusLab();
            dtgDelLab.ItemsSource = null;
            dtgDelLab.ItemsSource = CL.BusLab();
            dtgBuscarLab.ItemsSource = null;
            dtgBuscarLab.ItemsSource = CL.BusLab();
            L = new Laboratorio();
            L.Nombre = txtModNomLab.Text;
            L.Director = txtModDirLab.Text;
            L.Telefono = txtModTelLab.Text;
            L.Calle = txtModCalleLab.Text;
            L.Colonia = txtModColLab.Text;
            L.Municipio = txtModMunLab.Text;
            L.Estado = txtModEstatLab.Text;
            L.IdLab = int.Parse(txtModIdLab.Text);
            CL.ModLab(L);
            dtgModLab.ItemsSource = null;
            dtgModLab.ItemsSource = CL.BusLab();
            dtgDelLab.ItemsSource = null;
            dtgDelLab.ItemsSource = CL.BusLab();
            dtgBuscarLab.ItemsSource = null;
            dtgBuscarLab.ItemsSource = CL.BusLab();

        }

        private void btnDeLab_Click(object sender, RoutedEventArgs e)
        {
            int id;
            dtgDelLab.ItemsSource = null;
            dtgDelLab.ItemsSource = CL.BusLab();
            dtgModLab.ItemsSource = null;
            dtgModLab.ItemsSource = CL.BusLab();
            dtgBuscarLab.ItemsSource = null;
            dtgBuscarLab.ItemsSource = CL.BusLab();
            id = int.Parse(txtDelId.Text);
            CL.DelLab(id);
            dtgModLab.ItemsSource = null;
            dtgModLab.ItemsSource = CL.BusLab();
            dtgBuscarLab.ItemsSource = null;
            dtgBuscarLab.ItemsSource = CL.BusLab();
            dtgDelLab.ItemsSource = null;
            dtgDelLab.ItemsSource = CL.BusLab();
        }

        private void btnReporteTodos_Click(object sender, RoutedEventArgs e)
        {
            gen.GenerarReporteLaboratorio(CL.BusLab());
            gen.GenerarReporteLaboratorioDesdeBD();
        }
    }
}
