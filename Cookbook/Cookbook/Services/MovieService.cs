using Cookbook.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cookbook.Services
{
    class MovieService
    {
        private readonly Uri serverUrl = new Uri("https://api.themoviedb.org/3/");

        private readonly string api_key = "f8b0ddf47416b488594a2b0afcc24030";

        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json);
                return result;
            }
        }

        public async Task<MovieCastAndCrew> GetMovieCastAndCrewAsync(int id)
        {
            return await GetAsync<MovieCastAndCrew>(new Uri(serverUrl, $"movie/{id}/credits?api_key={api_key}"));
        }

        internal async Task<MultiSearch> GetMultiSearchAsync(int id, string query)
        {
            return await GetAsync<MultiSearch>(new Uri(serverUrl, $"search/multi?query={query}&page={id}&api_key={api_key}"));
        }

        internal async Task<Person> GetPersonAsync(int id)
        {
            return await GetAsync<Person>(new Uri(serverUrl, $"person/{id}?api_key={api_key}"));
        }

        internal async Task<PersonCombinedCredits> GetPersonCombinedCreditsAsync(int id)
        {
            return await GetAsync<PersonCombinedCredits>(new Uri(serverUrl, $"person/{id}/combined_credits?api_key={api_key}"));
        }

        public async Task<SeriesCastAndCrew> GetSeriesCastAndCrewAsync(int id)
        {
            return await GetAsync<SeriesCastAndCrew>(new Uri(serverUrl, $"tv/{id}/credits?api_key={api_key}"));
        }

        public async Task<SeasonEpisodes> GetSeasonEpisodesAsync(int id, int seasonNum)
        {
            return await GetAsync<SeasonEpisodes>(new Uri(serverUrl, $"tv/{id}/season/{seasonNum}?api_key={api_key}"));
        }


        public async Task<Movie> GetMovieAsync(int id)
        {
            try
            {
                return await GetAsync<Movie>(new Uri(serverUrl, $"movie/{id}?api_key={api_key}"));
            }
            catch(Exception e)
            {
                return new Movie();
            }
        }

        public async Task<PopularMovies> GetPopularMoviesAsync(int page)
        {
            return await GetAsync<PopularMovies>(new Uri(serverUrl, $"movie/popular?page={page}&api_key={api_key}"));
        }

        public async Task<PopularSeries> GetPopularSeriesAsync(int page)
        {
            return await GetAsync<PopularSeries>(new Uri(serverUrl, $"tv/popular?api_key={api_key}&page={page}"));
        }

        public async Task<Series> GetSeriesAsync(int id)
        {
            return await GetAsync<Series>(new Uri(serverUrl, $"tv/{id}?api_key={api_key}"));
        }
    }
}
