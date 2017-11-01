using System;
using System.Windows.Controls;

namespace MahAppsMetro.Samples.Core
{
    public class Navigation
    {
        public Navigation(Frame frame)
        {
            this.Frame = frame;
        }

        public Frame Frame { get; set; }

        public bool Navigate(Uri sourcePageUri)
        {
            if (Frame.CurrentSource != sourcePageUri)
            {
                return Frame.Navigate(sourcePageUri);
            }
            return true;
        }

        public bool Navigate(object content)
        {
            if (Frame.NavigationService.Content != content)
            {
                return Frame.Navigate(content);
            }
            return true;
        }

        public void GoBack()
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
