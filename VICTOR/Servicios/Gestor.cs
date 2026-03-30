using SistemaPrestamos.Calculos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaPrestamos.Servicios
{
    public class Gestor
    {
        private const decimal FondoTotal = 10000000m;

        public decimal FondoDisponible()
        {
            using (var db = DbContextFactory.Create())
            {
                decimal usado = db.Prestamos
                    .Select(p => p.Monto)
                    .DefaultIfEmpty(0m).Sum();
                return FondoTotal - usado;
            }
        }

        public void Validar(Clientes p, decimal monto, int plazo)
        {
            if (p == null)
                throw new Exception("Persona no encontrada.");
            if (monto <= 0)
                throw new Exception("El monto debe ser mayor a cero.");
            if (plazo <= 0)
                throw new Exception("El plazo debe ser mayor a cero.");
            if (string.IsNullOrWhiteSpace(p.Garantia))
                throw new Exception("Se requiere garantía.");
            if (p.Sueldo <= 0)
                throw new Exception("Sueldo no válido.");
            if (monto > p.Sueldo * 4)
                throw new Exception("Monto excede el límite (4x sueldo).");
            if (monto > FondoDisponible())
                throw new Exception("Fondos insuficientes.");
        }

        public Prestamos NuevoPrestamo(int personaId, decimal monto, int plazo)
        {
            using (var db = DbContextFactory.Create())
            {
                var persona = db.Clientes.FirstOrDefault(c => c.Id == personaId);
                Validar(persona, monto, plazo);

                decimal tasa = Calculadora.TasaPorPlazo(plazo);
                decimal interes = Calculadora.Interes(monto, tasa, plazo);
                decimal total = Calculadora.MontoTotal(monto, interes);

                var prestamo = new Prestamos
                {
                    ClienteId = personaId,
                    Monto = monto,
                    Meses = plazo,
                    InteresGenerado = interes,
                    MontoTotal = total,
                    FechaPrestamo = DateTime.Now
                };

                db.Prestamos.Add(prestamo);
                db.SaveChanges();
                return prestamo;
            }
        }

        public List<Calculadora.FilaTabla> ObtenerTabla(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                var p = db.Prestamos.FirstOrDefault(x => x.Id == prestamoId);
                if (p == null) throw new Exception("Préstamo no encontrado.");
                decimal tasa = Calculadora.TasaPorPlazo(p.Meses);
                return Calculadora.TablaAmortizacion(p.Monto, p.Meses, tasa);
            }
        }

        public decimal SaldoActual(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                var ultimo = db.Pagos
                    .Where(p => p.PrestamoId == prestamoId && p.NuevoMonto.HasValue)
                    .OrderByDescending(p => p.FechaPago).FirstOrDefault();

                if (ultimo != null) return ultimo.NuevoMonto.Value;

                var prestamo = db.Prestamos.FirstOrDefault(p => p.Id == prestamoId);
                if (prestamo == null) throw new Exception("Préstamo no encontrado.");
                return prestamo.Monto;
            }
        }

        public int MesesRestantes(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                var p = db.Prestamos.FirstOrDefault(x => x.Id == prestamoId);
                if (p == null) throw new Exception("Préstamo no encontrado.");
                int pagados = db.Pagos.Count(x => x.PrestamoId == prestamoId);
                int restantes = p.Meses - pagados;
                return restantes <= 0 ? 1 : restantes;
            }
        }

        public decimal InteresesPagados(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                return db.Pagos
                    .Where(p => p.PrestamoId == prestamoId && p.InteresPagado.HasValue)
                    .Select(p => p.InteresPagado.Value)
                    .DefaultIfEmpty(0m).Sum();
            }
        }

        public Calculadora.DetalleMes DetallePago(int prestamoId, decimal extra = 0m)
        {
            return Calculadora.CalcularMes(
                SaldoActual(prestamoId),
                MesesRestantes(prestamoId),
                InteresesPagados(prestamoId),
                extra);
        }

        public void RegistrarPago(int prestamoId, decimal extra,
            bool pagado, int mes)
        {
            using (var db = DbContextFactory.Create())
            {
                var prestamo = db.Prestamos.FirstOrDefault(p => p.Id == prestamoId);
                if (prestamo == null) throw new Exception("Préstamo no encontrado.");

                var detalle = DetallePago(prestamoId, extra);

                if (!pagado)
                {
                    var mora = db.Moras.FirstOrDefault(m => m.PrestamoId == prestamoId);
                    if (mora == null)
                        db.Moras.Add(new Moras { PrestamoId = prestamoId, Cantidad = 1 });
                    else
                        mora.Cantidad = (mora.Cantidad ?? 0) + 1;

                    db.SaveChanges();

                    var moraActual = db.Moras.FirstOrDefault(m => m.PrestamoId == prestamoId);
                    if ((moraActual?.Cantidad ?? 0) >= 3)
                    {
                        var cliente = db.Clientes.FirstOrDefault(
                            c => c.Id == prestamo.ClienteId);
                        if (cliente != null)
                        {
                            cliente.EsMoroso = true;
                            db.SaveChanges();
                        }
                    }
                    return;
                }

                db.Pagos.Add(new Pagos
                {
                    PrestamoId = prestamoId,
                    MontoAnterior = detalle.SaldoAntes,
                    InteresPagado = detalle.Interes,
                    MontoAbonado = detalle.Capital,
                    NuevoMonto = detalle.SaldoDespues,
                    FechaPago = DateTime.Now
                });

                db.SaveChanges();
            }
        }
    }
}