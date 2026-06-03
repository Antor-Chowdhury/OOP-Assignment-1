using System;
using System.Collections.Generic;
using BusTicketSystem.Models;

namespace BusTicketSystem.Services
{
    public class BusService : IBusService
    {
        private List<Bus> _buses;
        private int _nextId;

        public BusService()
        {
            _buses = new List<Bus>();
            _nextId = 1;
        }

        public Bus CreateBus(string coachNumber, BusClass classification)
        {
            Bus newBus = new Bus(_nextId, coachNumber, classification);
            _buses.Add(newBus);
            _nextId++;
            return newBus;
        }

        public Bus GetBusById(int id)
        {
            foreach (Bus bus in _buses)
            {
                if (bus.BusId == id)
                {
                    return bus;
                }
            }
            return null;
        }

        public List<Bus> GetAllBuses()
        {
            return _buses;
        }

        public void DisplayAllBuses()
        {
            if (_buses.Count == 0)
            {
                Console.WriteLine("  No buses found.");
                return;
            }

            foreach (Bus bus in _buses)
            {
                Console.WriteLine("  --------------------------------");
                bus.DisplayInfo();
            }
            Console.WriteLine("  --------------------------------");
        }
    }
}