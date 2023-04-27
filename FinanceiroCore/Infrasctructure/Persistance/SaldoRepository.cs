using FinanceiroCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceiroCore.Infrasctructure.Persistance
{
    public class SaldoRepository : ISaldoRepository
    {
        private readonly FinanceiroContext _context;

        public SaldoRepository(FinanceiroContext context)
        {
            _context = context;
        }

        public Saldo Cadastrar(Saldo saldo)
        {
            _context.Add(saldo);
            _context.SaveChanges();
            return saldo;
        }

        public Saldo Atualizar(Saldo saldo)
        {
            _context.Update(saldo);
            _context.SaveChanges();
            return saldo;
        }

        public Saldo ObterSaldo(DateOnly date)
        {
            return _context.Saldos.Where(x => x.Dia == date).FirstOrDefault();
        }

        public Saldo ObterUltimoSaldo()
        {
            return _context.Saldos.OrderByDescending(x => x.Dia).FirstOrDefault();
        }

        public IEnumerable<Saldo> Obter30Saldos()
        {
            return _context.Saldos.OrderByDescending(x => x.Dia).Take(30).ToList(); 
        }
    }
}
