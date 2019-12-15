using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Library.ViewModels
{
    public class BookDetailsVM
    {
        [Display(Name = "Title of the item")]    
        public string BookName { get; set; }

        [Display(Name = "Author's first name")]
        public string FirstName { get; set; }

        [Display(Name = "Author's last name")]
        public string LastName { get; set; }

        [Display(Name = "Date of publication")]
        [DataType(DataType.Date)]      
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Name of the cover")]
        public string CoverName { get; set; }

        [Display(Name = "Name of the data carrier")]
        public string DataCarrierName { get; set; }

        [Display(Name = "Comment")]
        [StringLength(255)]
        public string Comment { get; set; }

        [Display(Name = "Item id")]
        public int BookId { get; set; }

        public int RentalId { get; set; }
        [Display(Name = "Rental's first name")]
        public string RentalFirstName { get; set; }
        [Display(Name = "Rental's last name")]
        public string RentalLastName { get; set; }
        [Display(Name = "Rental's email")]
        public string RentalEmail { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Rent date")]
        public DateTime RentDateTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Return date")]
        public DateTime ReturnDateTime { get; set; }
    }
}
