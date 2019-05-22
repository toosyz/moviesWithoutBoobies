﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Models
{

    public class PopularMovies
    {
        public int page { get; set; }
        public PopularMovie[] results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }

    public class PopularMovie
    {
        public string poster_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public int[] genre_ids { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }
        public string original_language { get; set; }
        public string title { get; set; }
        public string backdrop_path { get; set; }
        public float popularity { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public string poster_uri => "https://image.tmdb.org/t/p/w300/" + poster_path;

    }
}
