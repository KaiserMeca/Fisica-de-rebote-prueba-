using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            Juntar = new Conexion.ConexionClass();
            DataContext = Juntar;
            Juntar.heightValue = 200;
            Juntar.widthValue = 200;
            //SelfUserControl.Width = 800;
            //SelfUserControl.Height = 500;
            Bola.Margin = new Thickness(0, 70, 0, 0);
            Juntar.realMove();
        }
        public Conexion.ConexionClass Juntar;
    }
}
