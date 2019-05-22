using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Models
{

    public class PersonCombinedCredits
    {
        public PersonCombinedCast[] cast { get; set; }
        public PersonCombinedCrew[] crew { get; set; }
        public int id { get; set; }
    }

    public class PersonCombinedCast
    {
        public int id { get; set; }
        public string original_language { get; set; }
        public int episode_count { get; set; }
        public string overview { get; set; }
        public string[] origin_country { get; set; }
        public string original_name { get; set; }
        public int?[] genre_ids { get; set; }
        public string name { get; set; }
        public string media_type { get; set; }
        public string poster_path { get; set; }
        public string first_air_date { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        public string character { get; set; }
        public string backdrop_path { get; set; }
        public float popularity { get; set; }
        public string credit_id { get; set; }
        public string original_title { get; set; }
        public bool video { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool adult { get; set; }
        public string poster_uri => "https://image.tmdb.org/t/p/w300/" + poster_path;

    }

    public class PersonCombinedCrew
    {
        public int id { get; set; }
        public string department { get; set; }
        public string original_language { get; set; }
        public int episode_count { get; set; }
        public string job { get; set; }
        public string overview { get; set; }
        public string[] origin_country { get; set; }
        public string original_name { get; set; }
        public int vote_count { get; set; }
        public string name { get; set; }
        public string media_type { get; set; }
        public float popularity { get; set; }
        public string credit_id { get; set; }
        public string backdrop_path { get; set; }
        public string first_air_date { get; set; }
        public float vote_average { get; set; }
        public int?[] genre_ids { get; set; }
        public string poster_path { get; set; }
        public string original_title { get; set; }
        public bool video { get; set; }
        public string title { get; set; }
        public bool adult { get; set; }
        public string release_date { get; set; }

    }

}
