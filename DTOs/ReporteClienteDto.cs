namespace REPORTES.DTOs
{
    public class ReporteClienteDto
    {
        public int ClienteId { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Garantia { get; set; }
        public decimal Sueldo { get; set; }
        public bool EsMoroso { get; set; }
        public decimal MontoPrestado { get; set; }
        public decimal InteresGenerado { get; set; }
        public decimal MontoTotal { get; set; }
        public int Meses { get; set; }
    }
}
