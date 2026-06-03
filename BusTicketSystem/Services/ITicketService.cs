using BusTicketSystem.Models;
using System.Collections.Generic;

namespace BusTicketSystem.Services
{
    public interface ITicketService
    {
        Ticket BookTicket(User user, Schedule schedule, int seatNumber);
        List<Ticket> GetUserTickets(int userId);
    }
}