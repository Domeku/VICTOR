namespace REPORTES.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Garantia { get; set; }
        public decimal Sueldo { get; set; }
        public bool EsMoroso { get; set; }

        public decimal ObtenerMaximoPrestamo()
        {
            return Sueldo * 4;
        }
    }
}