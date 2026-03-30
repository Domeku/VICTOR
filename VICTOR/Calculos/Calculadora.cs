using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaPrestamos.Calculos
{
    public static class Calculadora
    {
        public static decimal TasaPorPlazo(int meses)
        {
            if (meses <= 12) return 0.1325m;
            if (meses <= 24) return 0.15m;
            return 0.30m;
        }

        public static decimal TasaMensual(decimal tasaAnual)
        {
            return Math.Round(
                (decimal)Math.Pow((double)(1 + tasaAnual), 1.0 / 12.0) - 1, 8);
        }

        public static decimal Interes(decimal monto, decimal tasa, int meses)
        {
            return Math.Round(monto * tasa * (meses / 12m), 2);
        }

        public static decimal MontoTotal(decimal monto, decimal interes)
        {
            return Math.Round(monto + interes, 2);
        }

        public static decimal CuotaMensual(decimal monto, decimal tasa, int meses)
        {
            if (meses <= 0)
                throw new ArgumentException("El plazo debe ser mayor a cero.");

            decimal tem = TasaMensual(tasa);
            if (tem == 0) return Math.Round(monto / meses, 2);

            decimal pot = (decimal)Math.Pow((double)(1 + tem), meses);
            return Math.Round(monto * (tem * pot) / (pot - 1), 2);
        }

        public static decimal Mora(decimal cuota)
        {
            return Math.Round(cuota * 0.10m, 2);
        }

        // Fila de amortización
        public class FilaTabla
        {
            public int Mes { get; set; }
            public decimal SaldoInicial { get; set; }
            public decimal Cuota { get; set; }
            public decimal InteresDelMes { get; set; }
            public decimal AbonoCapital { get; set; }
            public decimal SaldoFinal { get; set; }
            public int MesesRestantes { get; set; }
            public decimal InteresAcumulado { get; set; }
            public decimal TEM { get; set; }
            public decimal TEA { get; set; }
        }

        public static List<FilaTabla> TablaAmortizacion(
            decimal monto, int meses, decimal tasa)
        {
            var tabla = new List<FilaTabla>();
            decimal saldo = monto;
            decimal tem = Math.Round(tasa / 12, 8);
            decimal pot = (decimal)Math.Pow(1 + (double)tem, meses);
            decimal cuota = Math.Round(monto * (tem * pot) / (pot - 1), 2);

            for (int i = 1; i <= meses; i++)
            {
                decimal interes = Math.Round(saldo * tem, 2);
                decimal capital = Math.Round(cuota - interes, 2);
                saldo = Math.Round(saldo - capital, 2);

                tabla.Add(new FilaTabla
                {
                    Mes = i,
                    SaldoInicial = saldo + capital,
                    Cuota = cuota,
                    InteresDelMes = interes,
                    AbonoCapital = capital,
                    SaldoFinal = saldo < 0 ? 0 : saldo,
                    MesesRestantes = meses - i,
                    InteresAcumulado = tabla.Sum(f => f.InteresDelMes) + interes,
                    TEM = tem,
                    TEA = tasa
                });
            }
            return tabla;
        }

        // Detalle pago mensual
        public class DetalleMes
        {
            public decimal SaldoAntes { get; set; }
            public decimal Cuota { get; set; }
            public decimal Interes { get; set; }
            public decimal Capital { get; set; }
            public decimal SaldoDespues { get; set; }
            public int MesesPendientes { get; set; }
            public decimal InteresAcumulado { get; set; }
            public decimal TEM { get; set; }
            public decimal TEA { get; set; }
        }

        public static DetalleMes CalcularMes(
            decimal saldo, int mesesRestantes,
            decimal interesAcumulado, decimal abonoExtra = 0m)
        {
            if (mesesRestantes <= 0) mesesRestantes = 1;

            decimal tasa = TasaPorPlazo(mesesRestantes);
            decimal tem = TasaMensual(tasa);
            decimal cuota = CuotaMensual(saldo, tasa, mesesRestantes);
            decimal interes = Math.Round(saldo * tem, 2);
            decimal capital = Math.Round(cuota - interes, 2) + abonoExtra;
            decimal nuevoSaldo = Math.Round(saldo - capital, 2);

            return new DetalleMes
            {
                SaldoAntes = saldo,
                Cuota = cuota,
                Interes = interes,
                Capital = capital,
                SaldoDespues = nuevoSaldo < 0 ? 0 : nuevoSaldo,
                MesesPendientes = Math.Max(mesesRestantes - 1, 0),
                InteresAcumulado = Math.Round(interesAcumulado + interes, 2),
                TEM = tem,
                TEA = tasa
            };
        }
    }
}