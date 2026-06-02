using System;
using System.Collections.Generic;

namespace BusTicketSystem.Models
{
    public class User : Person
    {
        private string _mobileNumber;

        public string MobileNumber
        {
            get { return _mobileNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Mobile number cannot be empty.");
                _mobileNumber = value;
            }
        }

        public List<Ticket> Bookings
        { get; private set; }

        public User(int id, string fullName, string email, string mobileNumber) : base(id, fullName, email)
        {
            MobileNumber = mobileNumber;
            Bookings = new List<Ticket>();
        }

        public void AddBooking(Ticket ticket)
        {
            Bookings.Add(ticket);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"  User ID  : {Id}");
            Console.WriteLine($"  Name  : {FullName}");
            Console.WriteLine($"  Mobile  : {MobileNumber}");
            Console.WriteLine($"  Email  : {Email}");
            Console.WriteLine($"  Bookings  : {Bookings.Count}");
        }
    }
}