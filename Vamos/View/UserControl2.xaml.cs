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

namespace Vamos.View
{
    /// <summary>
    /// Lógica de interacción para UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
            Juntar = new Conexion.ConexionClass();
            DataContext = Juntar;
            Juntar.heightValue = 500;
            Juntar.widthValue = 1200;
            //SelfUserControl.Width = 800;
            //SelfUserControl.Height = 500;
            Juntar.realMove();
        }
        public Conexion.ConexionClass Juntar;
    }
}
