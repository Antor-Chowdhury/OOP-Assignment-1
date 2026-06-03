using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace BusTicketSystem.Models
{
    public enum BusClass
    {
        Business,
        Economy
    }

    public class Bus
    {
        public int BusId { get; private set; }
        public string CoachNumber { get; private set; }
        public BusClass Classification { get; set; }
        public int TotalSeats { get; private set; }
        private List<int> _reservedSeats;


        public Bus(int busId, string coachNumber, BusClass classification)
        {
            BusId = busId;
            CoachNumber = coachNumber;
            Classification = classification;
            _reservedSeats = new List<int>();

            if (classification == BusClass.Business)
            {
                TotalSeats = 30;
            }
            else
            {
                TotalSeats = 50;
            }

        }
        public bool IsSeatAvailable(int seatNumber)
        {
            if (seatNumber < 1 || seatNumber > TotalSeats)
            {
                return false;
            }
            return !_reservedSeats.Contains(seatNumber);
        }

        public void ReserveSeat(int seatNumber)
        {
            if (_reservedSeats.Contains(seatNumber))
            {
                throw new InvalidOperationException("Seat is already reserved.");
            }
            _reservedSeats.Add(seatNumber);
        }

        public List<int> GetAvailableSeats()
        {
            List<int> available = new List<int>();
            for (int i = 1; i <= TotalSeats; i++)
            {
                if (!_reservedSeats.Contains(i))
                {
                    available.Add(i);
                }

            }
            return available;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"  Bus ID  : {BusId}");
            Console.WriteLine($"  Coach No  : {CoachNumber}");
            Console.WriteLine($"  Class  : {Classification}");
            Console.WriteLine($"  Total Seats  : {TotalSeats}");
            Console.WriteLine($"  Reserved  : {_reservedSeats.Count}");
            Console.WriteLine($"  Available  : {TotalSeats - _reservedSeats.Count}");
        }
    }
}