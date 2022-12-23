using System;
using System.Globalization;

namespace DataFormatTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            //Criando um novo DateTime
            //DateTime data = new DateTime();
            //Pegando a data Atual
            //var data = DateTime.Now;
            //Data Especifico
            // var data = new DateTime(2022, 12, 23, 11, 49, 00);
            // System.Console.WriteLine(data);
            //Valores Separados
            // System.Console.WriteLine(data.Year);
            // System.Console.WriteLine(data.Month);
            // System.Console.WriteLine(data.Day);
            // System.Console.WriteLine(data.DayOfWeek);
            // System.Console.WriteLine((int)data.DayOfWeek);
            // System.Console.WriteLine(data.DayOfYear);

            // var date = DateTime.Now;
            //formatação completa
            //var formatado = String.Format("{0:dd/MM/yyyy hh:mm:ss ff z}", date);
            //shortdatetime
            // var formatado = String.Format("{0:t}", date);
            // System.Console.WriteLine(formatado);
            // formatado = String.Format("{0:d}", date);
            // System.Console.WriteLine(formatado);
            // formatado = String.Format("{0:T}", date);
            // System.Console.WriteLine(formatado);
            // formatado = String.Format("{0:D}", date);
            // System.Console.WriteLine(formatado);
            // formatado = String.Format("{0:f}", date);
            // System.Console.WriteLine(formatado);
            // formatado = String.Format("{0:g}", date);
            // System.Console.WriteLine(formatado);
            // formatado = String.Format("{0:r}", date);
            // System.Console.WriteLine(formatado);
            // formatado = String.Format("{0:R}", date);
            // System.Console.WriteLine(formatado);
            // formatado = String.Format("{0:s}", date);
            // System.Console.WriteLine(formatado);
            // formatado = String.Format("{0:u}", date);
            // System.Console.WriteLine(formatado);
            //Adicionando Valor
            // System.Console.WriteLine(date.AddDays(2));
            // System.Console.WriteLine(date.AddMonths(1));
            // System.Console.WriteLine(date.AddYears(1));
            // System.Console.WriteLine(date.AddHours(1));

            // var date = DateTime.Now;

            // if (date.Date == DateTime.Now.Date)
            // {
            //     System.Console.WriteLine("É igual");
            // }

            // var br = new CultureInfo("pt-BR");
            // var pt = new CultureInfo("pt-PT");
            // var en = new CultureInfo("en-US");
            // var de = new CultureInfo("de-DE");
            // var atual = CultureInfo.CurrentCulture;

            // System.Console.WriteLine(DateTime.Now.ToString("d", de));

            // var utcDate = DateTime.UtcNow;
            // System.Console.WriteLine(utcDate);
            // System.Console.WriteLine(utcDate.ToLocalTime());

            // var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
            // System.Console.WriteLine(timezoneAustralia);

            // var horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezoneAustralia);
            // System.Console.WriteLine(horaAustralia);

            // var timezones = TimeZoneInfo.GetSystemTimeZones();
            // foreach (var timezone in timezones)
            // {
            //     System.Console.WriteLine(timezone.Id);
            //     System.Console.WriteLine(timezone);
            //     System.Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezone));
            //     System.Console.WriteLine("______________________________");
            // }

            // var timeSpan = new TimeSpan();
            // System.Console.WriteLine(timeSpan);
            // var timeSpan = new TimeSpan(1);
            // System.Console.WriteLine(timeSpan);
            // var timeSpan = new TimeSpan(30, 14, 00);
            // System.Console.WriteLine(timeSpan);
            // System.Console.WriteLine(timeSpan.Days);

            System.Console.WriteLine(DateTime.DaysInMonth(2024, 2));

            if (IsWeekend(DateTime.Now.DayOfWeek))
            {
                System.Console.WriteLine("Fim de semana");
            }
            else
            {
                System.Console.WriteLine("Semana");
            }
            //Horario de verão
            System.Console.WriteLine(DateTime.Now.IsDaylightSavingTime());

        }

        static bool IsWeekend(DayOfWeek today)
        {
            return today == DayOfWeek.Sunday || today == DayOfWeek.Saturday;
        }
    }
}