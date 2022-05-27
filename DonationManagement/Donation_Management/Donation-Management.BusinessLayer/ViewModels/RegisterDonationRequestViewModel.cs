using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Management.BusinessLayer.ViewModels
{
    public class RegisterDonationRequestViewModel
    {
        public long DonationRequestId { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
        public long NgoId { get; set; }
        public long DonorId { get; set; }
        public long DonationId { get; set; }
    }
}
