using System.Windows;
using Variant_1._9.AppDataFile;

namespace Variant_1._9.Windows
{
    /// <summary>
    /// Логика взаимодействия для ConfirmAddWin.xaml
    /// </summary>
    public partial class ConfirmAddWin : Window
    {
        private object _obj;
        public ConfirmAddWin(object obj)
        {
            InitializeComponent();
            _obj = obj;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            ConnectOdb.conObj.Entry(_obj).State = System.Data.Entity.EntityState.Added;
            ConnectOdb.conObj.SaveChanges();
            FrameObj.frameMain.GoBack();
            MessageBox.Show("Добавлено!");
            this.Close();
        }
    }
}
