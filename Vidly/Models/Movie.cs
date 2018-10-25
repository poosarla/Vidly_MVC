using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Models
{
    //[Bind(Exclude = "ID")]
    public class Movie
    {
        public Movie()
        {
            DateAdded = DateTime.Now;
        }


        public int? ID { get; set; }


        public string Name { get; set; }

        //public string CheckProp { get; set; }

        //  public string GenreDesc { get; set; }
        [Display(Name = "Released Date")]
        public DateTime ReleasedDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in stock")]
        [MaxQuantity]
        public int NumberinStock { get; set; }

        public Genre Genre { get; set; }

        public int GenreID { get; set; }
    }

    [Bind(Exclude = "ID")]
    public class Customer
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public int ID { get; set; }

        public string CustomerMovieRecievedDate { get; set; }

        public bool isSubscribedtoNewsLetter { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Display(Name = "Membership Type")]
        public int MemberShipTypeID { get; set; }

        [Display(Name = "Date of Birth")]
        [MinAge18Required]
        public DateTime? DOB { get; set; }

    }

    public class Genre
    {
        public int GenreID { get; set; }

        public string GenreDescription { get; set; }

    }

}