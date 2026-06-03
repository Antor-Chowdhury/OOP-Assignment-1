using System;

namespace BusTicketSystem.Models
{
    public enum PaymentStatus
    {
        Unpaid,
        Paid
    }

    public class Invoice
    {
        public int InvoiceId { get; private set; }
        public Ticket Ticket { get; set; }
        public User User { get; set; }
        public decimal AmountDue { get; private set; }
        public DateTime GeneratedDate { get; private set; }
        public PaymentStatus Status { get; private set; }

        public Invoice(int invoiceId, Ticket ticket, User user, decimal amountDue)
        {
            InvoiceId = invoiceId;
            Ticket = ticket;
            User = user;
            AmountDue = amountDue;
            GeneratedDate = DateTime.Now;
            Status = PaymentStatus.Unpaid;
        }

        public void MarkAsPaid()
        {
            Status = PaymentStatus.Paid;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"  Invoice ID  : {InvoiceId}");
            Console.WriteLine($"  Ticket ID  : {Ticket.TicketId}");
            Console.WriteLine($"  User ID  : {User.Id}");
            Console.WriteLine($"  Passenger  : {User.FullName}");
            Console.WriteLine($"  Amount Due  : {AmountDue:C}");
            Console.WriteLine($"  Generated  : {GeneratedDate.ToString("dd MMM yyyy")}");
            Console.WriteLine($"  Status  : {Status}");
        }
    }
}