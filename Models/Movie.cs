﻿namespace GraphQl.WebApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public TimeOnly Time { get; set; }

        
    }
}
