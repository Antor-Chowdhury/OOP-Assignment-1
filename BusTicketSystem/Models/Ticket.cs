using System;

namespace BusTicketSystem.Models
{
    public class Ticket
    {
        public int TicketId { get; private set; }
        public User User { get; set; }
        public Schedule Schedule { get; set; }
        public int SeatNumber { get; set; }
        public DateTime BookingDate { get; private set; }

        public Ticket(int ticketId, User user, Schedule schedule, int seatNumber)
        {
            TicketId = ticketId;
            User = user;
            Schedule = schedule;
            SeatNumber = seatNumber;
            BookingDate = DateTime.Now;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"  Ticket ID  : {TicketId}");
            Console.WriteLine($"  Passenger  : {User.FullName}");
            Console.WriteLine($"  Route  : {Schedule.DepartureCity} -> {Schedule.ArrivalCity}");
            Console.WriteLine($"  Departure  : {Schedule.DepartureDateTime.ToString("dd MMM yyyy HH:mm")}");
            Console.WriteLine($"  Seat No  : {SeatNumber}");
            Console.WriteLine($"  Booked On  : {BookingDate.ToString("dd MMM yyyy")}");
        }
    }
}