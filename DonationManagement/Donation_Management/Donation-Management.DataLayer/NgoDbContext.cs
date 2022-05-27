using Donation_Management.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Donation_Management.DataLayer
{
    public class NgoDbContext: DbContext
    {
        public NgoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<NgoDetails> NgoDetails { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donation { get; set; }
        public DbSet<DonationRequest> DonationRequests { get; set; }

    }
}
