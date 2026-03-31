// Auto-generado — actualizado para incluir Administradores
namespace REPORTES
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class PrestamosDBEntities : DbContext
    {
        public PrestamosDBEntities()
            : base("name=PrestamosDBEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Moras> Moras { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<Prestamos> Prestamos { get; set; }
        public virtual DbSet<Administradores> Administradores { get; set; }
    }
}
