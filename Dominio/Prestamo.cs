using System;

namespace REPORTES.Domain
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public decimal Monto { get; set; }
        public int Meses { get; set; }
        public decimal InteresGenerado { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaPrestamo { get; set; }

        public decimal CalcularSaldoPendiente(decimal totalPagado)
        {
            decimal saldo = MontoTotal - totalPagado;

            if (saldo < 0)
                saldo = 0;

            return saldo;
        }
    }
}