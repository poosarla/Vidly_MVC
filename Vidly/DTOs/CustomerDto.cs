using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class CustomerDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int? ID { get; set; }

        public string CustomerMovieRecievedDate { get; set; }

        public bool isSubscribedtoNewsLetter { get; set; }

        public int MemberShipTypeID { get; set; }

        public MemberShipTypeDTO MemberShipType { get; set; }

        public DateTime? DOB { get; set; }
    }

    public class MemberShipTypeDTO
    {
        public int ID { get; set; }

        public string MemberShipTypeDesc { get; set; }

        public int DiscountRate { get; set; }
    }
}