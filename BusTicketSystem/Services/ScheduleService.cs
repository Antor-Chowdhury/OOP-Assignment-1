using System;
using System.Collections.Generic;
using BusTicketSystem.Models;

namespace BusTicketSystem.Services
{
    public class ScheduleService : IScheduleService
    {
        private List<Schedule> _schedules;
        private int _nextId;

        public ScheduleService()
        {
            _schedules = new List<Schedule>();
            _nextId = 1;
        }

        public Schedule CreateSchedule(string departureCity, string arrivalCity, DateTime departureDateTime, decimal ticketPrice, Bus assignedBus)
        {
            Schedule newSchedule = new Schedule(_nextId, departureCity, arrivalCity, departureDateTime, ticketPrice, assignedBus);
            _schedules.Add(newSchedule);
            _nextId++;
            return newSchedule;
        }

        public Schedule GetScheduleById(int id)
        {
            foreach (Schedule schedule in _schedules)
            {
                if (schedule.ScheduleId == id)
                {
                    return schedule;
                }
            }
            return null;
        }

        public List<Schedule> GetAllSchedules()
        {
            return _schedules;
        }

        public void DisplayAllSchedules()
        {
            if (_schedules.Count == 0)
            {
                Console.WriteLine("  No schedules found.");
                return;
            }

            foreach (Schedule schedule in _schedules)
            {
                Console.WriteLine("  --------------------------------");
                schedule.DisplayInfo();
            }
            Console.WriteLine("  --------------------------------");
        }
    }
}