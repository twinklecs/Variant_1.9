using System.Windows;
using Variant_1._9.AppDataFile;
using Variant_1._9.Pages;

namespace Variant_1._9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConnectOdb.conObj = new BigPackEntities();
            FrameObj.frameMain = frmMain;
        }

        private void btnMaterials_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new MarerialsPages());
        }

        private void btnSuplliers_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new SupplierPage());
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(new ChoicePage());
        }
    }
}
