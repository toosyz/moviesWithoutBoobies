using Cookbook.Models;
using Cookbook.Services;
using Cookbook.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Cookbook.ViewModels
{
    //Responsible for the logic and data of the movie details page
    class MovieDetailsPageViewModel : ViewModelBase
    {
        //List of cast that are displayed when navigated to movie details page 
        public ObservableCollection<Cast> Casts { get; set; } = new ObservableCollection<Cast>();

        //List of crew that are displayed when navigated to movie details page 
        public ObservableCollection<Crew> Crews { get; set; } = new ObservableCollection<Crew>();

        private Movie _movie;

        //Reference to object that holds details and data about the movie we have clicked on
        public Movie Movie
        {
            get { return _movie; }
            set { Set(ref _movie, value); }
        }

        //Loading the view along with the data to be displayed
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            int id = 0;
            if(parameter !=null) id = (int)parameter;
            var service = new MovieService();

            Movie = await service.GetMovieAsync(id);

            var credits = await service.GetMovieCastAndCrewAsync(id);
            foreach(Cast c in credits.cast)
            {
                Casts.Add(c);
            }

            foreach(Crew c in credits.crew)
            {
                Crews.Add(c);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        //Navigationg to a new view, where a specific person's details are displayed, that we clicked on
        internal void NavigateToPerson(int id)
        {
            NavigationService.Navigate(typeof(PersonDetailsPage), id);
        }
    }
}
