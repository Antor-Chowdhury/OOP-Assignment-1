using System;

namespace BusTicketSystem.Models
{
    public class Schedule
    {
        public int ScheduleId { get; private set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public decimal TicketPrice { get; set; }

        public Bus AssignedBus { get; set; }

        public Schedule(int scheduleId, string departureCity, string arrivalCity, DateTime departureDateTime, decimal ticketPrice, Bus assignedBus)
        {
            ScheduleId = scheduleId;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            DepartureDateTime = departureDateTime;
            TicketPrice = ticketPrice;
            AssignedBus = assignedBus;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"  Schedule Id : {ScheduleId}");
            Console.WriteLine($"  Route : {DepartureCity} --> {ArrivalCity}");
            Console.WriteLine($"  Departure : {DepartureDateTime.ToString("dd MMM yyyy HH:mm")}");
            Console.WriteLine($"  Price : {TicketPrice:C}");
            Console.WriteLine($"  Bus : {AssignedBus.CoachNumber} ({AssignedBus.Classification})");
        }
    }
}