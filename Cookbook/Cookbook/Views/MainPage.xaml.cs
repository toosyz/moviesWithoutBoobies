using Cookbook.Models;
using System;
using Windows.UI.Xaml.Controls;

namespace Cookbook.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.NavigateToNextPage(); //Calling viewmodel function for navigating to next page
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.NavigateToPreviousPage(); //Calling viewmodel function for navigating to previous page
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.NavigateToMovieDetails(((PopularMovie)e.ClickedItem).id); //Calling viewmodel function for navigating to a movie's details
        }

        private void GridView_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            ViewModel.NavigateToSeriesDetails(((PopSeries)e.ClickedItem).id); //Calling viewmodel function for navigating to a tv show's details
        }

        private void Button_Click_2(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if(SearchBar!=null && SearchBar.Text!="") ViewModel.NavigateToSearchDetails(SearchBar.Text); //Calling viewmodel function for navigating to search results
        }
    }
}
