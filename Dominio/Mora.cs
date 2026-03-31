namespace REPORTES.Domain
{
    public class Mora
    {
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public int Cantidad { get; set; }

        public bool EsMoroso()
        {
            return Cantidad >= 3;
        }
    }
}