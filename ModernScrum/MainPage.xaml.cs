using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Controls;

namespace ModernScrum
{
    public partial class MainPage : PhoneApplicationPage
    {
        bool ListPickerOpened;
        
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            ListPickerOpened = false;
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
    }
}