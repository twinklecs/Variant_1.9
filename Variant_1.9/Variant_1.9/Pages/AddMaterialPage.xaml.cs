using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Variant_1._9.AppDataFile;
using Variant_1._9.Windows;

namespace Variant_1._9.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddMaterialPage.xaml
    /// </summary>
    public partial class AddMaterialPage : Page
    {
        public AddMaterialPage()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (tbTitle.Text != "" && tbCountInPack.Text != "" && tbUnit.Text != "" &&
                tbCountInStock.Text != "" && tbMinCount.Text != "" &&
                tbCost.Text != "" && tbTypeString.Text != "")
            {
                if (tbImageString.Text == "")
                    tbImageString.Text = "NULL";


                Material material = new Material()
                {
                    Title = tbTitle.Text,
                    CountInPack = Convert.ToInt32(tbCountInPack.Text),
                    Unit = tbUnit.Text,
                    CountInStock = Convert.ToInt32(tbCountInStock.Text),
                    MinCount = Convert.ToInt32(tbMinCount.Text),
                    Description = tbDescription.Text,
                    Image = tbImageString.Text
                };

                var materialType = ConnectOdb.conObj.MaterialType.ToList();

                for (int i = 0; i < materialType.Count; i++)
                {
                    if (materialType[i].Title.ToString() == tbTypeString.Text)
                    {
                        material.MaterialTypeID = materialType[i].ID;
                    }
                }

                ConfirmAddWin confirmAddWin = new ConfirmAddWin(material);
                confirmAddWin.Show();
            }
            else
                MessageBox.Show("Не все поля заполнены!", "Предупреждение");
        }
    }
}
