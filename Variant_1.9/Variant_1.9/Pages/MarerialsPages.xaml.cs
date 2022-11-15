using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Variant_1._9.AppDataFile;
using Variant_1._9.Windows;

namespace Variant_1._9.Pages
{
    /// <summary>
    /// Логика взаимодействия для MarerialsPages.xaml
    /// </summary>
    public partial class MarerialsPages : Page
    {
        public static List<Material> materialList = new List<Material>();
        public static List<MaterialType> typeList = new List<MaterialType>();

        public MarerialsPages()
        {
            InitializeComponent();

            materialList = ConnectOdb.conObj.Material.ToList();
            typeList = ConnectOdb.conObj.MaterialType.ToList();

            Timer();

            LoadData();
        }

        private void Timer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += UpdateList;
            timer.Start();
        }

        private void UpdateList(object sender, object e)
        {
            materialList = ConnectOdb.conObj.Material.ToList();
            typeList = ConnectOdb.conObj.MaterialType.ToList();
        }

        public void UpdateData()
        {
            List<object> list = new List<object>();

            for (int i = 0; i < materialList.Count; i++)
            {
                if (materialList[i].Title.Contains(tbSearch.Text))
                {
                    list.Add(materialList[i]);
                }
            }

            ListMaterial.ItemsSource = list;

            //List<object> list = new List<object>();

            //if (tbSearch.Text == "" && cmbType.SelectedIndex == 0 && cmbFilter.SelectedIndex == 0)
            //    ListMaterial.ItemsSource = list;

            //else if (tbSearch.Text != "" && cmbFilter.SelectedIndex == 0 && cmbType.SelectedIndex == 0)
            //{
            //    for (int i = 0; i < materialList.Count; i++)
            //    {
            //        if (materialList[i].Title.Contains(tbSearch.Text) || materialList[i].Title.ToLower().Contains(tbSearch.Text))
            //            list.Add(materialList[i]);
            //    }
            //    ListMaterial.ItemsSource = list;
            //}

            //else if (tbSearch.Text != "" && cmbType.SelectedIndex != 0 && cmbFilter.SelectedIndex == 0)
            //{
            //    for (int i = 0; i < materialList.Count; i++)
            //    {
            //        for (int j = 0; j < typeList.Count; j++)
            //        {
            //            if (materialList[i].Title.Contains(tbSearch.Text)
            //                || materialList[i].Title.ToLower().Contains(tbSearch.Text)
            //                && typeList[j].Title == materialList[i].MaterialType.Title)
            //            {
            //                list.Add(materialList[i]);
            //            }
            //        }
            //    }
            //    ListMaterial.ItemsSource = list;
            //}

            //else if (tbSearch.Text != "" && cmbType.SelectedIndex != 0 && cmbFilter.SelectedIndex != 0)
            //{
            //    for (int i = 0; i < materialList.Count; i++)
            //    {
            //        for (int j = 0; j < typeList.Count; j++)
            //        {
            //            if (materialList[i].Title.Contains(tbSearch.Text)
            //                || materialList[i].Title.ToLower().Contains(tbSearch.Text)
            //                && typeList[j].Title == materialList[i].MaterialType.Title
            //                && cmbFilter.SelectedItem.ToString() == materialList[i].MaterialType.Title.ToString())
            //            {
            //                list.Add(materialList[i]);
            //            }
            //        }
            //    }
            //    ListMaterial.ItemsSource = list;
            //}

            //else if (tbSearch.Text == "" && cmbType.SelectedIndex != 0 && cmbFilter.SelectedIndex == 0)
            //{
            //    for (int i = 0; i < materialList.Count; i++)
            //    {
            //        if (materialList[i].MaterialType.Title.ToString() == cmbType.SelectedItem.ToString())
            //        {
            //            list.Add(materialList[i]);
            //        }
            //    }

            //    ListMaterial.ItemsSource = list;
            //}


            //else if (tbSearch.Text == "" && cmbFilter.SelectedIndex == 0 && cmbType.SelectedIndex == 1)
            //{
            //    List<Material> listChar = materialList;

            //    var orderedNumbers = from i in listChar
            //                         orderby i.CountInStock descending
            //                         select i;

            //    ListMaterial.ItemsSource = orderedNumbers;
            //}
        }

        public void LoadData()
        {
            ListMaterial.ItemsSource = materialList;

            for (int i = 0; i < typeList.Count; i++)
            {
                cmbType.Items.Add(typeList[i].Title);
            }

            cmbFilter.Items.Add("По возрастанию");
            cmbFilter.Items.Add("По убыванию");
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void DeleteMaterial_Click(object sender, RoutedEventArgs e)
        {
            Material material = ((Button)sender).DataContext as Material;
            ConfirmDeleteWin confirmDeleteWin = new ConfirmDeleteWin(material);
            confirmDeleteWin.Show();

        }

        private void ChangeMaterial_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new ChangeMaterialPage(((Button)sender).DataContext as Material));
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //UpdateData();
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //UpdateData();
        }
    }
}
