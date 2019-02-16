using Didly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Didly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}