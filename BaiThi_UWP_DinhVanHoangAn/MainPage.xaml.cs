using BaiThi_UWP_DinhVanHoangAn.Entity;
using BaiThi_UWP_DinhVanHoangAn.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BaiThi_UWP_DinhVanHoangAn
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static ObservableCollection<Contact> ListAllContact;
        private ContactModel contactModel;

        public MainPage()
        {
            this.InitializeComponent();
            this.contactModel = new ContactModel();
            this.Loaded += LoadContact;
        }

        private void LoadContact(object sender, RoutedEventArgs e)
        {
            var list = this.contactModel.Select();
            if (list != null && list.Count != 0)
            {
                ListAllContact = new ObservableCollection<Contact>(list);
                ListViewContact.ItemsSource = ListAllContact;
            }
        }

        private void LoadFirstContact(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = Name.Text,
            };

            var getContact = this.contactModel.SelectFirstContact(contact);
            if(getContact.PhoneNumber == null)
            {
                Warning.Visibility = Visibility.Visible;
            }
            else
            {
                PhoneNumber.Text = getContact.PhoneNumber;
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            LoadFirstContact(null, null);
        }

        private void BtnOrCreate_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.InsertContact));
        }
    }
}
