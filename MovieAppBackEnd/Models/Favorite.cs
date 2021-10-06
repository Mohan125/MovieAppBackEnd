using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppBackEnd.Models
{
    public class Favorite
    {
        [Key]
        public int Index { get; set; }


        public string UserName { get; set; }

        [ForeignKey("toTitle")]
        public string Title { get; set; }

        public MovieList toTitle { get; set; } 
        
    }
}
