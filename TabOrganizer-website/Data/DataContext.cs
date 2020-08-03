using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabOrganizer_website.Models;

namespace TabOrganizer_website.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Website> Websites { get; set; }
    }
}
