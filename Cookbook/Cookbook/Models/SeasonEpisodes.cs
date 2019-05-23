﻿namespace Cookbook.Models
{

    public class SeasonEpisodes
    {
        public string _id { get; set; }
        public string air_date { get; set; }
        public Episode[] episodes { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public int id { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }
    }

    public class Episode
    {
        public string air_date { get; set; }
        public Crew[] crew { get; set; }
        public int episode_number { get; set; }
        public Guest_Stars[] guest_stars { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public int id { get; set; }
        public string production_code { get; set; }
        public int season_number { get; set; }
        public string still_path { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
    }

    public class Guest_Stars
    {
        public int id { get; set; }
        public string name { get; set; }
        public string credit_id { get; set; }
        public string character { get; set; }
        public int order { get; set; }
        public string profile_path { get; set; }
    }


}
