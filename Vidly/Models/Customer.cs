using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Customer's Name"), StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Please Enter a Membership Type"), Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth"), Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}