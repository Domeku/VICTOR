using System.Collections.Generic;
using System.Linq;
using REPORTES.Calculations;
using REPORTES.DTOs;

namespace REPORTES.Services
{
    public class ReporteService
    {
        public List<ReporteAmortizacionDto> ObtenerTablaAmortizacion(decimal monto, int meses)
        {
            return LoanCalculator.GenerarTablaAmortizacion(monto, meses)
                .Select(x => new ReporteAmortizacionDto
                {
                    Mes = x.Mes,
                    Cuota = x.Cuota,
                    Interes = x.Interes,
                    Capital = x.Capital,
                    Saldo = x.Saldo
                })
                .ToList();
        }

        public ReporteClienteDto ObtenerDetalleCliente(int clienteId)
        {
            using (var db = DbContextFactory.Create())
            {
                var data = (from c in db.Clientes
                            join p in db.Prestamos on c.Id equals p.ClienteId
                            where c.Id == clienteId
                            select new ReporteClienteDto
                            {
                                ClienteId = c.Id,
                                NombreCompleto = c.NombreCompleto,
                                Correo = c.Correo,
                                Telefono = c.Telefono,
                                Direccion = c.Direccion,
                                Garantia = c.Garantia,
                                Sueldo = c.Sueldo,
                                EsMoroso = c.EsMoroso ?? false,
                                MontoPrestado = p.Monto,
                                InteresGenerado = p.InteresGenerado ?? 0m,
                                MontoTotal = p.MontoTotal ?? 0m,
                                Meses = p.Meses
                            }).FirstOrDefault();

                return data;
            }
        }

        public ReporteFinancieroDto ObtenerResumenFinanciero()
        {
            using (var db = DbContextFactory.Create())
            {
                return new ReporteFinancieroDto
                {
                    TotalPrestado = db.Prestamos
                        .Select(p => p.Monto)
                        .DefaultIfEmpty(0m)
                        .Sum(),

                    TotalGanancia = db.Prestamos
                        .Where(p => p.InteresGenerado != null)
                        .Select(p => p.InteresGenerado.Value)
                        .DefaultIfEmpty(0m)
                        .Sum()
                };
            }
        }

        public List<ReporteMoraDto> ObtenerMorasPorCliente()
        {
            using (var db = DbContextFactory.Create())
            {
                var consulta = from c in db.Clientes
                               join p in db.Prestamos on c.Id equals p.ClienteId
                               join m in db.Moras on p.Id equals m.PrestamoId
                               select new ReporteMoraDto
                               {
                                   Cliente = c.NombreCompleto,
                                   CantidadMoras = m.Cantidad ?? 0
                               };

                return consulta.ToList();
            }
        }

        public List<ReporteMorosoDto> ObtenerClientesMorosos()
        {
            using (var db = DbContextFactory.Create())
            {
                return db.Clientes
                    .Where(c => c.EsMoroso == true)
                    .Select(c => new ReporteMorosoDto
                    {
                        ClienteId = c.Id,
                        NombreCompleto = c.NombreCompleto,
                        Correo = c.Correo,
                        Telefono = c.Telefono
                    })
                    .ToList();
            }
        }
    }
}
