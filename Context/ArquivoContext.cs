using Microsoft.EntityFrameworkCore;
using SignaVersionamento.Models;

namespace SignaVersionamento.Context
{
    public class ArquivoContext : DbContext
    {
        public ArquivoContext(DbContextOptions<ArquivoContext> options)
            : base(options)
        {
        }

        public DbSet<ArquivoModel> Arquivos { get; set; }
    }
}