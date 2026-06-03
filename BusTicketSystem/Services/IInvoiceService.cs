using BusTicketSystem.Models;
using System.Collections.Generic;

namespace BusTicketSystem.Services
{
    public interface IInvoiceService
    {
        Invoice GenerateInvoice(Ticket ticket);
        void ProcessPayment(int invoiceId);
        List<Invoice> GetUserInvoices(int userId);
    }
}