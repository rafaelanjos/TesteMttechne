using FinanceiroCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceiroCore.Infrasctructure
{
    public class FinanceiroContext : DbContext
    {
        public FinanceiroContext(DbContextOptions<FinanceiroContext> options ) : base( options )
        {

        }

        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Saldo> Saldos { get; set; }
    }
}
