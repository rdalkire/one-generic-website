using Microsoft.AspNetCore.Mvc.Rendering;
using LibForBlog.MovieModels;

namespace StarterApp.ViewModels
{
    public class MovieGenreViewModel
    {
        public List<Movie>? Movies { get; set; }
        public SelectList? Genres { get; set; }
        public string? MovieGenre { get; set; }
        public string? SearchString { get; set; }
    }
}