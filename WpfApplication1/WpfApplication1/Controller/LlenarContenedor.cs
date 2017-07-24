using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using RNConnection.DataAbstractionLayer;
using RNConnection.DataStorageLayer;
using Modelos;

namespace Carmen
{
    class LlenarContenedor
    {
        public static void LelnarUserControl(Grid g,UserControl Uc)
          
        {
            if (g.Children.Count>0)
            {
                g.Children.Clear();
                g.Children.Add(Uc);
            }
            else
            {
                g.Children.Add(Uc);
            }
        }
    }
}
