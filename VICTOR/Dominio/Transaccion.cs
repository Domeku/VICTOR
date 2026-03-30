using System;

namespace SistemaPrestamos.Dominio
{
    public class Transaccion
    {
        public int Id { get; set; }
        public int FinanciamientoId { get; set; }
        public decimal SaldoAntes { get; set; }
        public decimal InteresAplicado { get; set; }
        public decimal MontoAbonado { get; set; }
        public decimal SaldoDespues { get; set; }
        public DateTime Fecha { get; set; }
    }
}