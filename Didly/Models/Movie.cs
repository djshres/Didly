﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Didly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(Name="Number In Stock")]
        public byte NumberInstock { get; set; }
        [Display(Name="Genre")]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}