using BeerSwag.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BeerSwag
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        Database db;

        

        public RegisterPage()
        {
            this.InitializeComponent();
            db = new Database();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Handle Back Button
            SystemNavigationManager.GetForCurrentView().BackRequested += RegisterPage_Back;
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //remove handle back button
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= RegisterPage_Back;
        }
        
      
        private void RegisterPage_Back(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();

        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            
            db.Register(new Common.Users() {
                UserName = txtUserName.Text.Trim(),
                Password = txtPassword.Password,
                Email = txtEmail.Text.Trim()
            });
            if (code == -1)
            {
                var message = new MessageDialog("Login Failed");
                await message.ShowAsync();
            }
            else 
            {
                var message = new MessageDialog("Register Success")
                await message.ShowAsync();
            }
         
            
        }
    }
}
