using System;
namespace SistemaPrestamos.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Garantia { get; set; }
        public decimal Sueldo { get; set; }
        public bool Moroso { get; set; }

        public decimal LimiteFinanciable()
        {
            return Sueldo * 4;
        }
    }
}

// Entidad principal del sistema - Juan