using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibForBlog.BlogModels
{
    public enum HomeTextNames{
        SiteName, IndexBody, PrivacyBody
    }

    [Index(nameof(Name), IsUnique = true)]
    public class HomeText{

        public int Id { get; set; }

        public HomeTextNames Name{get; set;}

        [Required]
        public string? Value{get; set;}
    }
}