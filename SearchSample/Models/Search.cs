using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchSample.Models
{
    public class Search
    {
        public Int64 Id { get; set; }

        [Display(Name = "Search")]
        [Required(ErrorMessage = "Please enter a term to search for.")]
        [StringLength(255)]
        public string Term { get; set; }

    }
}