using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFACT2Events1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnCalculer.Click += BtnCalculer_Click;
            txtA.PreviewTextInput += TxtA_PreviewTextInput;
            txtB.PreviewTextInput += TxtA_PreviewTextInput;
            txtC.PreviewTextInput += TxtA_PreviewTextInput;

            



        }

        private void BtnCalculer_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(txtA.Text, out double a);
            double.TryParse(txtB.Text, out double b);
            double.TryParse(txtC.Text, out double c);
            ResoudTrinome(a, b, c, out string message);
            ResoudCalculer secondePage = new ResoudCalculer();
            secondePage.LblResultat.Text = message;
            secondePage.Show();


        }

        private void TxtA_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text , out int n))
            {
                e.Handled = true;
            }
        }

        public void ResoudTrinome(double a, double b, double c, out string message)
        {
            double delta = Math.Pow(b, 2) - 4 * a * c;
            if (delta < 0)
            {
                message = "Il n'y a pas de solution réelle";

            }
            else if (delta == 0)
            {
                double x1 = -b / (2 * a);
                message = "Il y a une solution " + x1;
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                message = "Il y a deux solutions " + x1 + " et " + x2;
            }
        }
    }
}
