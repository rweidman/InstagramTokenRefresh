using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace InstagramTokenRefresh.Context
{
    public class InstagramDbContext : DbContext
    {

    
        public InstagramDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}
