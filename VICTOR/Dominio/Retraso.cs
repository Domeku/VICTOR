using System;
namespace SistemaPrestamos.Dominio
{
    public class Retraso
    {
        public int Id { get; set; }
        public int FinanciamientoId { get; set; }
        public int Cantidad { get; set; }

        public bool EsMoroso()
        {
            return Cantidad >= 3;
        }
    }
}