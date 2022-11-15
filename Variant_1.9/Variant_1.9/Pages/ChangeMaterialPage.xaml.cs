using System.Windows;
using System.Windows.Controls;
using Variant_1._9.AppDataFile;
using Variant_1._9.Windows;

namespace Variant_1._9.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChangeMaterialPage.xaml
    /// </summary>
    public partial class ChangeMaterialPage : Page
    {
        private Material material;
        public ChangeMaterialPage(Material material)
        {
            InitializeComponent();
            this.material = material;
            LoadMaterial();
        }

        public void LoadMaterial()
        {
            tbTitle.Text = material.Title;
            tbCountInPack.Text = material.CountInPack.ToString();
            tbUnit.Text = material.Unit;
            tbCountInStock.Text = material.CountInStock.ToString();
            tbMinCount.Text = material.MinCount.ToString();
            tbDescription.Text = material.Description;
            tbCost.Text = material.Cost.ToString();
            tbImageString.Text = material.Image;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ConfirmWin confirmWin = new ConfirmWin(material);
            confirmWin.Show();
        }
    }
}
