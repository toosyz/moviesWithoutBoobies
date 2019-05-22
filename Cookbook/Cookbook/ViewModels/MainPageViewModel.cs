using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Cookbook.Models;
using Cookbook.Services;
using Cookbook.Views;
using Windows.UI.Xaml.Controls;
using System.ComponentModel;

namespace Cookbook.ViewModels
{
    //Responsible for the logic and data of the main page
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        //List of popular movies that are displayed when the application is opened for the first time
        public ObservableCollection<PopularMovie> PopularMovieList { get; set; } = new ObservableCollection<PopularMovie>();

        //List of popular tv shows that are displayed when the application is opened for the first time
        public ObservableCollection<PopSeries> PopularSeriesList { get; set; } = new ObservableCollection<PopSeries>();

        //Variable that alerts the view to display new value of property
        public event PropertyChangedEventHandler PropertyChanged;

        int _page = 1;

        //Current page, can go from 1 to 1000
        public int Page
        {
            get { return _page; }
            set
            {
                if (_page != value)
                {
                    _page = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Page)));
                }
            }
        }

        //Loading the view along with the movies and tv shows to be displayed
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            LoadMovies();
            LoadSeries();
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        //Navigationg to a new view, where a specific tv show's details are displayed, that we clicked on
        internal void NavigateToSeriesDetails(int id)
        {
            NavigationService.Navigate(typeof(SeriesDetailsPage), id);
        }

        //Navigationg to a new view, where search results are displayed
        internal void NavigateToSearchDetails(string text)
        {
            NavigationService.Navigate(typeof(MultiSearchPage), text);
        }

        //Navigationg to a new view, where a specific movie's details are displayed, that we clicked on
        internal void NavigateToMovieDetails(int id)
        {
            NavigationService.Navigate(typeof(MovieDetailsPage), id);
        }

        //Seperate function for loading movies
        private async void LoadMovies()
        {
            var service = new MovieService();
            PopularMovieList.Clear();
            var popularMovieList = await service.GetPopularMoviesAsync(Page);
            foreach (PopularMovie pm in popularMovieList.results)
            {
                PopularMovieList.Add(pm);
            }
        }

        //Seperate function for loading tv shows
        private async void LoadSeries()
        {
            var service = new MovieService();
            PopularSeriesList.Clear();
            var popularSeriesList = await service.GetPopularSeriesAsync(Page);
            foreach (PopSeries ps in popularSeriesList.results)
            {
                PopularSeriesList.Add(ps);
            }
        }

        //Going to previous page, when possible, loading movies and series corresponding to page number
        internal void NavigateToPreviousPage()
        {
            if (Page != 1)
            {
                Page--;
                LoadMovies();
                LoadSeries();
            }
        }

        //Going to next page, when possible, loading movies and series corresponding to page number
        public void NavigateToNextPage()
        {
            if (Page != 1000)
            {
                Page++;
                LoadMovies();
                LoadSeries();
            }
        }

        
    }
}

