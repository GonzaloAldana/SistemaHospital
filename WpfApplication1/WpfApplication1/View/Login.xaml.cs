using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Modelos;
using MedSoft.Controller;
using MedSoft.View;
using WpfApplication1.View;
using WpfApplication1.View.UcControls;

namespace MedSoft.View
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        WindowAdministrador WA = new WindowAdministrador();
        WindowDoctor WD = new WindowDoctor();
        WindowSecretaria WS = new WindowSecretaria();
        SolidColorBrush Colorr = new SolidColorBrush();
        UcLaboratorio UL = new UcLaboratorio();
        UcPaciente up = new UcPaciente();
        Gestion G = new Gestion();
        Usuario U = new Usuario();
        
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            U = new Usuario();
            U.NombreUsuario = int.Parse(txtUser.Text);
            U.CodigoAcceso = txtPass.Password;
            // Si CheckUser devuelve 1 es decir que entro el admin  2.- Doctor  3.-Secretaria
            if (G.CheckUser(U)==1)
            {
                WA.Show();
                this.Close();
                //Abrir Interfaz de Admin
            }
            else if (G.CheckUser(U)==2)
            {
                WD.Show();
                
                this.Close();
                //Abrir Interfaz de Doctor
            }
            else if (G.CheckUser(U)==3)
            {
                WS.Show();
                this.Close();
                //Abrir Interfaz de Secretaria
            }
            else if (G.CheckUser(U)==0)
            {
                //No se encontro el usuario
                txtUser.Text = "Capture un Usuario Valido";
                txtPass.Clear();

                
            }
        }

        private void txtUser_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Esto es para que en nombre de usuario solo capture numeros (Requerimientos)
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }
       
    }
}
