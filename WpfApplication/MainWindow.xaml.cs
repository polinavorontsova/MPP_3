using System.Windows;
using WpfApplication.Views;

namespace WpfApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ApplicationView();
        }
    }
}