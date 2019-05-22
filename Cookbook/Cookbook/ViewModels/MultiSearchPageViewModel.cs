using Cookbook.Models;
using Cookbook.Services;
using Cookbook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Cookbook.ViewModels
{
    //Responsible for the logic and data of the multi search page
    class MultiSearchPageViewModel :ViewModelBase, INotifyPropertyChanged
    {
        //List of movies, tv shows and people that are displayed when navigated to multi search page
        public ObservableCollection<MultiSearchResult> Results { get; set; } = new ObservableCollection<MultiSearchResult>();

        //Variable that alerts the view to display new value of property
        public event PropertyChangedEventHandler PropertyChanged;

        //Amount of pages we have of result
        int maxPage = 1;

        private string _query = "example";

        //The query, with which we searched
        public string Query
        {
            get { return _query; }
            set
            {
                if (_query != value)
                {
                    _query = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Query)));
                }
            }
        }

        int _page = 1;

        //Current page, can go from 1 to maxPage
        public int Page
        {
            get { return _page; }
            set
            {
                if(_page != value)
                {
                    _page = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Page)));
                }
            }
        }

        //Going to previous page, when possible, loading results corresponding to page number
        internal void NavigateToPreviousPage()
        {
            if(Page!=1)
            {
                Page--;
                LoadPageAsync();
            }
        }

        //Going to next page, when possible, loading results corresponding to page number
        internal void NavigateToNextPage()
        {
            if (Page != maxPage)
            {
                Page++;
                LoadPageAsync();
            }
        }

        //Loading the view along with the data to be displayed
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (parameter != null) Query = (string)parameter;
            await LoadPageAsync();
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        //Seperate function for loading the data
        private async Task LoadPageAsync()
        {
            Results.Clear();
            var service = new MovieService();
            var results = await service.GetMultiSearchAsync(Page, Query);
            maxPage = results.total_pages;
            foreach (MultiSearchResult msr in results.results)
            {
                Results.Add(msr);
            }
        }

        //Navigating to view of clicked item
        internal void NavigateToMotionPicture(int id, object type)
        {
            if (type.ToString().Equals("tv")) NavigationService.Navigate(typeof(SeriesDetailsPage), id);
            if (type.ToString().Equals("movie")) NavigationService.Navigate(typeof(MovieDetailsPage), id);
            if (type.ToString().Equals("person")) NavigationService.Navigate(typeof(PersonDetailsPage), id);
        }
    }
}
