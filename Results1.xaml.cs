using _13_5GrafickProject.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace _13_5GrafickProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Results1 : Page
    {
        
        public Results1()
        {
            this.InitializeComponent();
        }

        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text != "")
            {
                nameCanvas.Visibility = Visibility.Collapsed;
                scoreAndName.Visibility = Visibility.Visible;
            }

        }
    }
}
