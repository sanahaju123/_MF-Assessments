using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Management.BusinessLayer.ViewModels
{
    public class RegisterDonationViewModel
    {
        public long DonationId { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public long NgoId { get; set; }
        public long DonorId { get; set; }

    }
}
