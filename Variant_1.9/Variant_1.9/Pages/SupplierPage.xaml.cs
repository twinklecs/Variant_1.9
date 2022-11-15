using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Variant_1._9.AppDataFile;
using Variant_1._9.Windows;

namespace Variant_1._9.Pages
{
    /// <summary>
    /// Логика взаимодействия для SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Page
    {
        public SupplierPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var supplierList = ConnectOdb.conObj.Supplier.ToList();

            ListSupplier.ItemsSource = supplierList;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            ConfirmDeleteWin confirmDeleteWin = new ConfirmDeleteWin(((Button)sender).DataContext as Supplier);
            confirmDeleteWin.Show();
        }
    }
}
