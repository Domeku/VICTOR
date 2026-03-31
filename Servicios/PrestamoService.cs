using REPORTES.Calculations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REPORTES.Services
{
    public class PrestamoService
    {
        private const decimal FondoBase = 10000000m;

        // ==============================
        // FONDO DISPONIBLE
        // ==============================
        public decimal CalcularFondoActual()
        {
            using (var db = DbContextFactory.Create())
            {
                decimal totalPrestado = db.Prestamos
                    .Select(p => p.Monto)
                    .DefaultIfEmpty(0m)
                    .Sum();

                return FondoBase - totalPrestado;
            }
        }

        // ==============================
        // VALIDACIONES
        // ==============================
        public void ValidarSolicitudPrestamo(Clientes cliente, decimal monto, int meses)
        {
            if (cliente == null)
                throw new Exception("El cliente no existe.");

            if (monto <= 0)
                throw new Exception("El monto debe ser mayor que cero.");

            if (meses <= 0)
                throw new Exception("El plazo debe ser mayor que cero.");

            if (string.IsNullOrWhiteSpace(cliente.Garantia))
                throw new Exception("No se puede otorgar un préstamo sin garantía.");

            if (cliente.Sueldo <= 0)
                throw new Exception("El cliente no tiene un sueldo válido registrado.");

            if (monto > cliente.Sueldo * 4)
                throw new Exception("No se puede prestar más de 4 veces el sueldo del cliente.");

            decimal fondoActual = CalcularFondoActual();
            if (monto > fondoActual)
                throw new Exception("La entidad no tiene fondo suficiente.");
        }

        // ==============================
        // CREAR PRÉSTAMO
        // ==============================
        public Prestamos CrearPrestamo(int clienteId, decimal monto, int meses)
        {
            using (var db = DbContextFactory.Create())
            {
                var cliente = db.Clientes.FirstOrDefault(c => c.Id == clienteId);
                ValidarSolicitudPrestamo(cliente, monto, meses);

                decimal tasa = LoanCalculator.ObtenerTasaAnual(meses);
                decimal interes = LoanCalculator.CalcularInteresSimple(monto, tasa, meses);
                decimal montoTotal = LoanCalculator.CalcularMontoTotal(monto, interes);

                var nuevoPrestamo = new Prestamos
                {
                    ClienteId = clienteId,
                    Monto = monto,
                    Meses = meses,
                    InteresGenerado = interes,
                    MontoTotal = montoTotal,
                    FechaPrestamo = DateTime.Now
                };

                db.Prestamos.Add(nuevoPrestamo);
                db.SaveChanges();
                return nuevoPrestamo;
            }
        }

        // ==============================
        // TABLA DE AMORTIZACIÓN
        // ==============================
        public List<LoanCalculator.AmortizacionItem> ObtenerTablaAmortizacion(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                var prestamo = db.Prestamos.FirstOrDefault(p => p.Id == prestamoId);
                if (prestamo == null)
                    throw new Exception("Préstamo no encontrado.");

                var cliente = db.Clientes.FirstOrDefault(c => c.Id == prestamo.ClienteId);
                if (cliente == null)
                    throw new Exception("Cliente no encontrado.");

                decimal tasa = CalcularTasaPersonalizada(cliente, prestamo.Meses);

                return LoanCalculator.GenerarTablaAmortizacion(prestamo.Monto, prestamo.Meses, tasa);
            }
        }

        // ==============================
        // TASA PERSONALIZADA
        // ==============================
        private decimal CalcularTasaPersonalizada(Clientes cliente, int meses)
        {
            decimal tasaBase = 0.10m;

            if (cliente.EsMoroso == true)
                tasaBase += 0.05m;

            if (cliente.Sueldo < 20000)
                tasaBase += 0.03m;

            if (cliente.Sueldo > 50000)
                tasaBase -= 0.02m;

            if (meses > 12)
                tasaBase += 0.02m;

            return tasaBase;
        }

        // ==============================
        // MONTO ACTUAL
        // ==============================
        public decimal ObtenerMontoActual(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                var ultimoPago = db.Pagos
                    .Where(p => p.PrestamoId == prestamoId && p.NuevoMonto.HasValue)
                    .OrderByDescending(p => p.FechaPago)
                    .FirstOrDefault();

                if (ultimoPago != null)
                    return ultimoPago.NuevoMonto.Value;

                var prestamo = db.Prestamos.FirstOrDefault(p => p.Id == prestamoId);
                if (prestamo == null)
                    throw new Exception("Préstamo no encontrado.");

                return prestamo.Monto;
            }
        }

        // ==============================
        // MESES
        // ==============================
        public int ObtenerMesesPagados(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                return db.Pagos.Count(p => p.PrestamoId == prestamoId);
            }
        }

        public int ObtenerMesesRestantes(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                var prestamo = db.Prestamos.FirstOrDefault(p => p.Id == prestamoId);
                if (prestamo == null)
                    throw new Exception("Préstamo no encontrado.");

                int pagados = db.Pagos.Count(p => p.PrestamoId == prestamoId);
                int restantes = prestamo.Meses - pagados;
                return restantes <= 0 ? 1 : restantes;
            }
        }

        // ==============================
        // INTERESES ACUMULADOS
        // ==============================
        public decimal ObtenerInteresesAcumulados(int prestamoId)
        {
            using (var db = DbContextFactory.Create())
            {
                return db.Pagos
                    .Where(p => p.PrestamoId == prestamoId && p.InteresPagado.HasValue)
                    .Select(p => p.InteresPagado.Value)
                    .DefaultIfEmpty(0m)
                    .Sum();
            }
        }

        // ==============================
        // DETALLE DE PAGO
        // ==============================
        public LoanCalculator.PagoCalculado ObtenerDetallePago(int prestamoId, decimal abonoExtra = 0m)
        {
            decimal montoAnterior = ObtenerMontoActual(prestamoId);
            int mesesRestantes = ObtenerMesesRestantes(prestamoId);
            decimal interesesAcumulados = ObtenerInteresesAcumulados(prestamoId);

            return LoanCalculator.CalcularPagoDelMes(montoAnterior, mesesRestantes, interesesAcumulados, abonoExtra);
        }

        // ==============================
        // REGISTRAR PAGO
        // ==============================
        public void RegistrarPago(int prestamoId, decimal abonoExtra, bool pagoRealizado, int mesNumero)
        {
            using (var db = DbContextFactory.Create())
            {
                var prestamo = db.Prestamos.FirstOrDefault(p => p.Id == prestamoId);
                if (prestamo == null)
                    throw new Exception("Préstamo no encontrado.");

                var detallePago = ObtenerDetallePago(prestamoId, abonoExtra);

                if (!pagoRealizado)
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
                        var cliente = db.Clientes.FirstOrDefault(c => c.Id == prestamo.ClienteId);
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
                    MontoAnterior = detallePago.MontoAnterior,
                    InteresPagado = detallePago.InteresAPagar,
                    MontoAbonado = detallePago.CapitalPagado,
                    NuevoMonto = detallePago.NuevoMontoAdeudado,
                    FechaPago = DateTime.Now
                });

                db.SaveChanges();
            }
        }
    }
}
