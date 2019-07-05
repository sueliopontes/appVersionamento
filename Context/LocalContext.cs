using Microsoft.EntityFrameworkCore;
using SignaVersionamento.Models;

namespace SignaVersionamento.Context
{
    public class LocalContext : DbContext
    {
        public LocalContext(DbContextOptions<LocalContext> options)
            : base(options)
        {
        }

        public DbSet<LocalModel> Local { get; set; }
    }
}