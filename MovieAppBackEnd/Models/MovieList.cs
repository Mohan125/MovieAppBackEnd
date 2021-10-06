using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppBackEnd.Models
{
    public class MovieList
    {
        [Key]
        public string Title { get; set; }
        public string BoxOffice { get; set; }
        public bool Active { get; set; }
        public DateTime DateOfLaunch { get; set; }

        
        public string Genre { get; set; }
        public bool HasTeaser { get; set; }
        public bool FavoriteIndicator { get; set; }

    }
}
