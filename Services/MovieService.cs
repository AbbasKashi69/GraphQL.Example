using GraphQl.WebApi.Models;

namespace GraphQl.WebApi.Services
{
    public class MovieService
    {
        public  List<Movie> GetMovies() =>
            Enumerable.Range(1, 25).Select(index => new Movie
            {
                Id = index,
                Genre = Genres[Random.Shared.Next(0, 6)],
                Name = "movie " + Random.Shared.Next(1, 100),
                Time = new TimeOnly(Random.Shared.Next(2), Random.Shared.Next(59), 0),
            }).ToList();

        private  string[] Genres => ["Action", "Comedy", "Drama", "Horror", "Romance", "Science Fiction", "Thriller"];

        public string AddMovie(string name, string genre)
        {
            return $"فیلم {name} با موفقیت ثبت شد.";
        }
    }
}
