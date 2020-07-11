using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MikeUpjohnWebPortfolioV2.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Please enter your name")]
        [MaxLength(100, ErrorMessage = "Your name must be no longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter your e-mail address")]
        [EmailAddress(ErrorMessage ="Please enter a valid e-mail address")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please choose your reason for contact")]
        public string SelectedEnquiryOption { get; set; }
        public List<SelectListItem> EnquiryOptions { get; set; }

        [Required(ErrorMessage ="Please enter a message")]
        [MaxLength(5000, ErrorMessage ="Please shorten your message, or contact me directly instead.")]
        public string Message { get; set; }
    }
}