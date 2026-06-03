using BusTicketSystem.Models;
using System;
using System.Collections.Generic;

namespace BusTicketSystem.Services
{
    public interface IScheduleService
    {
        Schedule CreateSchedule(string departureCity, string arrivalCity, DateTime departureDateTime, decimal ticketPrice, Bus assignedBus);
        Schedule GetScheduleById(int id);
        List<Schedule> GetAllSchedules();
    }
}