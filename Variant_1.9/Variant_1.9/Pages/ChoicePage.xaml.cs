using System.Windows;
using System.Windows.Controls;
using Variant_1._9.AppDataFile;

namespace Variant_1._9.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChoicePage.xaml
    /// </summary>
    public partial class ChoicePage : Page
    {
        public ChoicePage()
        {
            InitializeComponent();
        }

        private void btnAddMaterail_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new AddMaterialPage());
        }

        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new AddSupplierPage());
        }
    }
}
