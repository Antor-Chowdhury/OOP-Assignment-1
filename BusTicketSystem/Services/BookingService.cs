using System;
using System.Collections.Generic;
using BusTicketSystem.Models;

namespace BusTicketSystem.Services
{
    public class BookingService : ITicketService, IInvoiceService
    {
        private List<Ticket> _tickets;
        private List<Invoice> _invoices;
        private int _nextTicketId;
        private int _nextInvoiceId;

        public BookingService()
        {
            _tickets = new List<Ticket>();
            _invoices = new List<Invoice>();
            _nextTicketId = 1;
            _nextInvoiceId = 1;
        }

        public Ticket BookTicket(User user, Schedule schedule, int seatNumber)
        {
            Bus bus = schedule.AssignedBus;

            if (seatNumber < 1 || seatNumber > bus.TotalSeats)
            {
                Console.WriteLine($"  Invalid seat. Must be between 1 and {bus.TotalSeats}.");
                return null;
            }

            if (!bus.IsSeatAvailable(seatNumber))
            {
                Console.WriteLine($"  Seat {seatNumber} is already reserved.");
                return null;
            }

            Ticket newTicket = new Ticket(_nextTicketId, user, schedule, seatNumber);
            _tickets.Add(newTicket);
            _nextTicketId++;

            user.AddBooking(newTicket);

            bus.ReserveSeat(seatNumber);

            return newTicket;
        }

        public Invoice GenerateInvoice(Ticket ticket)
        {
            Invoice newInvoice = new Invoice(_nextInvoiceId, ticket, ticket.User, ticket.Schedule.TicketPrice);
            _invoices.Add(newInvoice);
            _nextInvoiceId++;
            return newInvoice;
        }

        public void ProcessPayment(int invoiceId)
        {
            Invoice invoice = null;

            foreach (Invoice inv in _invoices)
            {
                if (inv.InvoiceId == invoiceId)
                {
                    invoice = inv;
                    break;
                }
            }

            if (invoice == null)
            {
                Console.WriteLine("  Invoice not found.");
                return;
            }

            if (invoice.Status == PaymentStatus.Paid)
            {
                Console.WriteLine("  This invoice is already paid.");
                return;
            }

            invoice.MarkAsPaid();
            Console.WriteLine("  Payment successful! Invoice marked as Paid.");
        }

        public List<Invoice> GetUserInvoices(int userId)
        {
            List<Invoice> userInvoices = new List<Invoice>();
            foreach (Invoice invoice in _invoices)
            {
                if (invoice.User.Id == userId)
                {
                    userInvoices.Add(invoice);
                }
            }
            return userInvoices;
        }

        public List<Ticket> GetUserTickets(int userId)
        {
            List<Ticket> userTickets = new List<Ticket>();
            foreach (Ticket ticket in _tickets)
            {
                if (ticket.User.Id == userId)
                {
                    userTickets.Add(ticket);
                }
            }
            return userTickets;
        }

        public void DisplayUserInvoices(int userId)
        {
            List<Invoice> invoices = GetUserInvoices(userId);

            if (invoices.Count == 0)
            {
                Console.WriteLine("  No invoices found for this user.");
                return;
            }

            foreach (Invoice invoice in invoices)
            {
                Console.WriteLine("  --------------------------------");
                invoice.DisplayInfo();
            }
            Console.WriteLine("  --------------------------------");
        }

        public void DisplayUserTickets(int userId)
        {
            List<Ticket> tickets = GetUserTickets(userId);

            if (tickets.Count == 0)
            {
                Console.WriteLine("  No tickets found for this user.");
                return;
            }

            foreach (Ticket ticket in tickets)
            {
                Console.WriteLine("  --------------------------------");
                ticket.DisplayInfo();
            }
            Console.WriteLine("  --------------------------------");
        }
    }
}