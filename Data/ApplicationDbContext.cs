using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TournamentsWebApplication.Models;

namespace TournamentsWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TournamentsWebApplication.Models.Tournament> Tournament { get; set; }
        public DbSet<TournamentsWebApplication.Models.Event> Event { get; set; }
        public DbSet<TournamentsWebApplication.Models.EventDetail> EventDetail { get; set; }
    }
}
