using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media.Animation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ShakeGestures;

namespace ModernScrum
{
    public partial class Card : PhoneApplicationPage
    {
        private bool shown;

        public Card()
        {
            InitializeComponent();
            shown = false;
            ShakeGesturesHelper.Instance.ShakeGesture += Instance_ShakeGesture;
            ShakeGesturesHelper.Instance.Active = true;
        }

        void Instance_ShakeGesture(object sender, ShakeGestureEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(()=>
            {
                if (shown == false)
                {
                    Reveal.Begin();
                    shown = true;
                }   
            });
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string number;
            if (NavigationContext.QueryString.TryGetValue("number", out number))
            {
                ((TextBlock)FindName("selectedNumber")).Text = number;
            }
        }

        private void ContentPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.ToggleCard();
        }

        private void ToggleCard()
        {
            if (shown == true)
            {
                Hide.Begin();
                shown = false;
            }
            else
            {
                Reveal.Begin();
                shown = true;
            }
        }
    }
}