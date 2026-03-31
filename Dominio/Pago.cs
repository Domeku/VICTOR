using System;

namespace REPORTES.Domain
{
    public class Pago
    {
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public decimal MontoAnterior { get; set; }
        public decimal InteresPagado { get; set; }
        public decimal MontoAbonado { get; set; }
        public decimal NuevoMonto { get; set; }
        public DateTime FechaPago { get; set; }

        public bool TieneAbono()
        {
            return MontoAbonado > 0;
        }
    }
}