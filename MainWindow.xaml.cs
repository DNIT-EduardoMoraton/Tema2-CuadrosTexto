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

namespace Tema2_CuadrosTexto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nombreTextBox.Tag = new {helper = ayudaNombreTextBlock, toggle =  false};
            apellidoTextBox.Tag = new {helper = ayudaApellidoTextBlock, toggle = false};
            edadTextBox.Tag = false;
        }

        private void ayudaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            dynamic content = tb.Tag;
            bool enabled = content.toggle;

            if (e.Key == Key.F1)
                enabled = !enabled;

            TextBlock ayuda = content.helper;
            if (enabled)
                ayuda.Visibility = Visibility.Visible;
            else
                ayuda.Visibility = Visibility.Hidden;

            tb.Tag = new {helper = ayuda, toggle = enabled};
        }

        private void edadTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            bool enabled = (bool)tb.Tag;
            if (e.Key == Key.F2 && !int.TryParse(tb.Text, out _))
                enabled = true;
            else
                enabled = false;
            

            if (enabled)
                errorEdadTextBlock.Visibility = Visibility.Visible;
            else
                errorEdadTextBlock.Visibility = Visibility.Hidden;

            tb.Tag = enabled;
        }
    }
}
