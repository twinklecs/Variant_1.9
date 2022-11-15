using System;
using System.Windows;
using System.Windows.Controls;
using Variant_1._9.AppDataFile;
using Variant_1._9.Windows;

namespace Variant_1._9.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddSupplierPage.xaml
    /// </summary>
    public partial class AddSupplierPage : Page
    {
        public AddSupplierPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbTitle.Text != "" && tbINN.Text != "" &&
                    tbStartDate.Text != "" && tbQualityRating.Text != "" &&
                    tbSupplierType.Text != "")
            {
                Supplier supplier = new Supplier()
                {
                    Title = tbTitle.Text,
                    INN = tbINN.Text,
                    StartDate = Convert.ToDateTime(tbStartDate.Text),
                    QualityRating = Convert.ToInt32(tbQualityRating.Text),
                    SupplierType = tbSupplierType.Text
                };

                ConfirmAddWin confirmAddWin = new ConfirmAddWin(supplier);
                confirmAddWin.Show();


            }
            else
                MessageBox.Show("Не все поля заполнены!", "Предупреждение");
        }
    }
}
