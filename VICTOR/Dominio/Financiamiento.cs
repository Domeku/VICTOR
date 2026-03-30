using System;

namespace SistemaPrestamos.Dominio
{
    public class Financiamiento
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public decimal Monto { get; set; }
        public int Plazo { get; set; }
        public decimal Interes { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public decimal SaldoPendiente(decimal pagado)
        {
            decimal saldo = Total - pagado;
            return saldo < 0 ? 0 : saldo;
        }
    }
}