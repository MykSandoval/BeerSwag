using BeerSwag.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BeerSwag
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Database db;
        public MainPage()
        {
            this.InitializeComponent();
            db = new Database();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (db.Login(txtUser.Text,txtPassword.Text))
            {
                var message = new MessageDialog("Login Success");
                await message.ShowAsync();
                Frame.Navigate(typeof(HomePage));
            }
            else
            {
                var message = new MessageDialog("Login Failed");
                await message.ShowAsync();
            }
        }
    }
}
