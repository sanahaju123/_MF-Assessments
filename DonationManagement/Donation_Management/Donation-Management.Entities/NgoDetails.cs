using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Donation_Management.Entities
{
    public class NgoDetails
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public long NgoId { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }

            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime StartedIn { get; set; }

            public string FilePath { get; set; }

            public bool IsDeleted { get; set; }
    }
}
