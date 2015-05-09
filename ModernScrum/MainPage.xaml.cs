using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ModernScrum.Resources;

namespace ModernScrum
{
    public partial class MainPage : PhoneApplicationPage
    {
        bool ListPickerOpened;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            ListPickerOpened = false;


            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void sequenceItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid origin = (Grid)sender;
            TextBlock sequenceNumber = (TextBlock)origin.FindName("sequenceNumber");
            NavigationService.Navigate(new Uri("/Card.xaml?number=" + sequenceNumber.Text, UriKind.Relative));
        }

        private void EditScale_Click(object sender, EventArgs e)
        {
            ListPickerOpened = true;
            ListPicker listPicker = (ListPicker)FindName("Picker");
            listPicker.Open();
        }

        private void Picker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListPicker scaleListPicker = (ListPicker)sender;
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (ListPickerOpened == true)
            {
                string newScale = (string)scaleListPicker.SelectedItem;
                if (settings.Contains("selectedScale"))
                {
                    settings["selectedScale"] = newScale;
                }
                else
                {
                    settings.Add("selectedScale", newScale);
                }
                settings.Save();
                this.DataContext = new ViewModel();
            }
            else if (settings.Contains("selectedScale"))
            {
                scaleListPicker.SelectedItem = settings["selectedScale"];
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}