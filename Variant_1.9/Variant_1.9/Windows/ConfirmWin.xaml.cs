using System.Windows;
using Variant_1._9.AppDataFile;

namespace Variant_1._9.Windows
{
    /// <summary>
    /// Логика взаимодействия для ConfirmWin.xaml
    /// </summary>
    public partial class ConfirmWin : Window
    {
        private Material material;
        public ConfirmWin(Material material)
        {
            InitializeComponent();
            this.material = material;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            ConnectOdb.conObj.Entry(material).State = System.Data.Entity.EntityState.Modified;
            ConnectOdb.conObj.SaveChanges();
            FrameObj.frameMain.GoBack();
            Close();
        }
    }
}
