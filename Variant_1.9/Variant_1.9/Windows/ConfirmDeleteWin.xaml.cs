using System.Windows;
using Variant_1._9.AppDataFile;

namespace Variant_1._9.Windows
{
    /// <summary>
    /// Логика взаимодействия для ConfirmDeleteWin.xaml
    /// </summary>
    public partial class ConfirmDeleteWin : Window
    {
        private object _obj;

        public ConfirmDeleteWin(object obj)
        {
            InitializeComponent();
            this._obj = obj;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            ConnectOdb.conObj.Entry(_obj).State = System.Data.Entity.EntityState.Deleted;
            ConnectOdb.conObj.SaveChanges();
            Close();
        }
    }
}
