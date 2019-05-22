using Cookbook.Models;
using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Cookbook.Views
{
    /// <summary>
    /// Page for showing search results
    /// </summary>
    public sealed partial class MultiSearchPage : Page
    {
        public MultiSearchPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToPreviousPage(); //Calling viewmodel function for navigating to previous results
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewModel.NavigateToNextPage(); //Calling viewmodel function for navigating to next page
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.NavigateToMotionPicture(((MultiSearchResult)e.ClickedItem).id, ((MultiSearchResult)e.ClickedItem).media_type); //Calling viewmodel function for navigating to movie, person or tv show page
        }
    }
}
