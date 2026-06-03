using BusTicketSystem.Models;
using System.Collections.Generic;

namespace BusTicketSystem.Services
{
    public interface IBusService
    {
        Bus CreateBus(string coachNumber, BusClass classification);
        Bus GetBusById(int id);
        List<Bus> GetAllBuses();
    }
}