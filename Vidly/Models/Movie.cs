using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Movie's Name"), StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Movie's Genre")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Please Enter Movie's Release Date"), Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required, Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Please Enter Number of Movies In Stock"), Display(Name = "Number in Stock"),
            Range(1, 60)]
        public int NumberInStock { get; set; }
    }
}