using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Contedores
{
    class LlenarContenedor//Lleanr un contenedor Grid con un user Control
    {
        public static void LelnarUserControl(Grid g,UserControl Uc)//Las clases en verde se tuvieron que instanciar
            /*Importante se puede cambiar un Uc O un metro*/
        {
            if (g.Children.Count>0)//Si tiene objetos a dentro haz
            {
                g.Children.Clear();//Limpiara el contenedor grid
                g.Children.Add(Uc);//Recibe por parametro a el Uc. Colocar el objeto User
            }

            else
            {
                g.Children.Add(Uc);
            }
        }
    }
}
