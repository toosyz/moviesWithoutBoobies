using Cookbook.Models;
using Cookbook.Services;
using Cookbook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Cookbook.ViewModels
{
    //Responsible for the logic and data of the series details page
    class SeriesDetailsPageViewModel :ViewModelBase
    {
        //List of cast that are displayed when navigated to series details page 
        public ObservableCollection<Cast> Casts { get; set; } = new ObservableCollection<Cast>();

        //List of crew that are displayed when navigated to series details page 
        public ObservableCollection<Crew> Crews { get; set; } = new ObservableCollection<Crew>();

        //List of seasons and episodes that are displayed when navigated to series details page 
        public ObservableCollection<SeasonEpisodes> Seasons { get; set; } = new ObservableCollection<SeasonEpisodes>();

        private Series _series;

        //Data of the series whose page we are on
        public Series Series
        {
            get { return _series; }
            set { Set(ref _series, value); }
        }

        //Loading the view along with the data to be displayed
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            int id = 0;
            if (parameter != null) id = (int)parameter;
            var service = new MovieService();

            Series = await service.GetSeriesAsync(id);

            var credits = await service.GetSeriesCastAndCrewAsync(id);
            foreach (Cast c in credits.cast)
            {
                Casts.Add(c);
            }

            foreach (Crew c in credits.crew)
            {
                Crews.Add(c);
            }

            for(int i=0; i<Series.number_of_seasons; i++)
            {
                var season = await service.GetSeasonEpisodesAsync(id, i);
                Seasons.Add(season);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        //Navigating to page of the person in the cast that was clicked on
        internal void NavigateToPerson(int id)
        {
            NavigationService.Navigate(typeof(PersonDetailsPage), id);
        }
    }
}
