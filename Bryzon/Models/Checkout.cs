using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bryzon.Models
{
    //Model containing choutout information
    public class Checkout
    {
        [Key]
        [BindNever]
        public int CheckoutId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter at least the first address line.")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please enter a city name.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a zipcode.")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country.")]
        public string Country { get; set; }

        [BindNever]
        public bool PurchaseReceived { get; set; }

    }

}
