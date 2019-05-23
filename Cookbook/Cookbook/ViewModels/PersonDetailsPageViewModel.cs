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
    //Responsible for the logic and data of the person details page
    class PersonDetailsPageViewModel : ViewModelBase
    {
        //List of movies and tv shows that the person has worked on, displayed when navigated to multi search page
        public ObservableCollection<PersonCombinedCast> Credits { get; set; } = new ObservableCollection<PersonCombinedCast>();

        private Person _person;

        //Data of person whose page we are on
        public Person Person
        {
            get { return _person; }
            set { Set(ref _person, value); }
        }

        //Loading the view along with the data to be displayed
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            int id = 0;
            if (parameter != null) id = (int)parameter;
            var service = new MovieService();

            Person = await service.GetPersonAsync(id);

            var credits = await service.GetPersonCombinedCreditsAsync(id);
            foreach (PersonCombinedCast c in credits.cast)
            {
                Credits.Add(c);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        //Navigating to new page of tv show or movie that was clicked on
        internal void NavigateToMotionPicture(int id, object type)
        {
            if(type.ToString().Equals("tv")) NavigationService.Navigate(typeof(SeriesDetailsPage), id);
            if (type.ToString().Equals("movie")) NavigationService.Navigate(typeof(MovieDetailsPage), id);
        }
    }
}
