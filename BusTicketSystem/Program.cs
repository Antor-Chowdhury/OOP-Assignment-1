using System;
using BusTicketSystem.Models;
using BusTicketSystem.Services;

namespace BusTicketSystem
{
    class Program
    {
        static IUserService userService = new UserService();
        static IBusService busService = new BusService();
        static IScheduleService scheduleService = new ScheduleService();
        static BookingService bookingService = new BookingService();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("============================================");
                Console.WriteLine("    BUS TICKET BOOKING & BILLING SYSTEM    ");
                Console.WriteLine("============================================");
                Console.WriteLine("  1.  Create User");
                Console.WriteLine("  2.  Display All Users");
                Console.WriteLine("  3.  Create Bus");
                Console.WriteLine("  4.  Display All Buses");
                Console.WriteLine("  5.  Create Schedule");
                Console.WriteLine("  6.  Display All Schedules");
                Console.WriteLine("  7.  Display Schedule Details");
                Console.WriteLine("  8.  Book Ticket");
                Console.WriteLine("  9.  Display User Invoices");
                Console.WriteLine("  10. Process Invoice Payment");
                Console.WriteLine("  11. Display User Tickets");
                Console.WriteLine("  0.  Exit");
                Console.WriteLine("============================================");
                Console.Write("  Select option: ");

                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1": CreateUser(); break;
                    case "2": DisplayAllUsers(); break;
                    case "3": CreateBus(); break;
                    case "4": DisplayAllBuses(); break;
                    case "5": CreateSchedule(); break;
                    case "6": DisplayAllSchedules(); break;
                    case "7": DisplayScheduleDetails(); break;
                    case "8": BookTicket(); break;
                    case "9": DisplayUserInvoices(); break;
                    case "10": ProcessPayment(); break;
                    case "11": DisplayUserTickets(); break;
                    case "0": running = false; break;
                    default:
                        Console.WriteLine("  Invalid option. Please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\n  Press any key to return to menu...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("\n  Thank you for using Bus Ticket System. Goodbye!");
        }


        static void CreateUser()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("              CREATE USER                   ");
            Console.WriteLine("============================================");
            Console.Write("  Full Name : "); string name = Console.ReadLine();
            Console.Write("  Email     : "); string email = Console.ReadLine();
            Console.Write("  Mobile    : "); string mobile = Console.ReadLine();

            User user = userService.CreateUser(name, email, mobile);
            Console.WriteLine("\n  User created successfully!");
            Console.WriteLine("  --------------------------------");
            user.DisplayInfo();
            Console.WriteLine("  --------------------------------");
        }

        static void DisplayAllUsers()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("               ALL USERS                    ");
            Console.WriteLine("============================================");

            List<User> users = userService.GetAllUsers();
            if (users.Count == 0)
            {
                Console.WriteLine("  No users found.");
                return;
            }
            foreach (User user in users)
            {
                Console.WriteLine("  --------------------------------");
                user.DisplayInfo();
            }
            Console.WriteLine("  --------------------------------");
        }

        static void CreateBus()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("               CREATE BUS                   ");
            Console.WriteLine("============================================");
            Console.Write("  Coach Number : "); string coach = Console.ReadLine();
            Console.WriteLine("  Bus Class    : 1 = Business (30 seats)");
            Console.WriteLine("               : 2 = Economy  (50 seats)");
            Console.Write("  Select       : "); string classInput = Console.ReadLine();

            BusClass classification = BusClass.Economy;
            if (classInput == "1")
            {
                classification = BusClass.Business;
            }

            Bus bus = busService.CreateBus(coach, classification);
            Console.WriteLine("\n  Bus created successfully!");
            Console.WriteLine("  --------------------------------");
            bus.DisplayInfo();
            Console.WriteLine("  --------------------------------");
        }

        static void DisplayAllBuses()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("               ALL BUSES                    ");
            Console.WriteLine("============================================");
            List<Bus> buses = busService.GetAllBuses();
            if (buses.Count == 0)
            {
                Console.WriteLine("  No buses found.");
                return;
            }
            foreach (Bus bus in buses)
            {
                Console.WriteLine("  --------------------------------");
                bus.DisplayInfo();
            }
            Console.WriteLine("  --------------------------------");
        }

        static void CreateSchedule()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("             CREATE SCHEDULE                ");
            Console.WriteLine("============================================");

            Console.WriteLine("  -- Available Buses --");
            List<Bus> buses = busService.GetAllBuses();
            if (buses.Count == 0)
            {
                Console.WriteLine("  No buses found. Please create a bus first.");
                return;
            }
            foreach (Bus b in buses)
            {
                Console.WriteLine("  --------------------------------");
                b.DisplayInfo();
            }
            Console.WriteLine("  --------------------------------");

            Console.Write("  Enter Bus ID       : ");
            int busId = int.Parse(Console.ReadLine());
            Bus bus = busService.GetBusById(busId);

            if (bus == null)
            {
                Console.WriteLine("  Bus not found.");
                return;
            }

            Console.Write("  Departure City     : "); string from = Console.ReadLine();
            Console.Write("  Arrival City       : "); string to = Console.ReadLine();
            Console.Write("  Date & Time        : ");
            Console.Write("  (dd/MM/yyyy HH:mm) : ");
            DateTime dateTime = DateTime.ParseExact(Console.ReadLine(),
                                "dd/MM/yyyy HH:mm", null);
            Console.Write("  Ticket Price       : "); decimal price = decimal.Parse(Console.ReadLine());

            Schedule schedule = scheduleService.CreateSchedule(from, to, dateTime, price, bus);
            Console.WriteLine("\n  Schedule created successfully!");
            Console.WriteLine("  --------------------------------");
            schedule.DisplayInfo();
            Console.WriteLine("  --------------------------------");
        }

        static void DisplayAllSchedules()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("             ALL SCHEDULES                  ");
            Console.WriteLine("============================================");
            List<Schedule> schedules = scheduleService.GetAllSchedules();
            if (schedules.Count == 0)
            {
                Console.WriteLine("  No schedules found.");
                return;
            }
            foreach (Schedule s in schedules)
            {
                Console.WriteLine("  --------------------------------");
                s.DisplayInfo();
            }
            Console.WriteLine("  --------------------------------");
        }

        static void DisplayScheduleDetails()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("           SCHEDULE DETAILS                 ");
            Console.WriteLine("============================================");

            List<Schedule> schedules = scheduleService.GetAllSchedules();
            if (schedules.Count == 0)
            {
                Console.WriteLine("  No schedules found.");
                return;
            }
            foreach (Schedule s in schedules)
            {
                Console.WriteLine("  --------------------------------");
                s.DisplayInfo();
            }
            Console.WriteLine("  --------------------------------");

            Console.Write("\n  Enter Schedule ID : ");
            int id = int.Parse(Console.ReadLine());
            Schedule schedule = scheduleService.GetScheduleById(id);

            if (schedule == null)
            {
                Console.WriteLine("  Schedule not found.");
                return;
            }

            Console.WriteLine("\n  -- Schedule Info --");
            Console.WriteLine("  --------------------------------");
            schedule.DisplayInfo();
            Console.WriteLine("  --------------------------------");

            Console.WriteLine("\n  -- Bus Info --");
            Console.WriteLine("  --------------------------------");
            schedule.AssignedBus.DisplayInfo();
            Console.WriteLine("  --------------------------------");

            Console.WriteLine("\n  -- Available Seats --");
            List<int> seats = schedule.AssignedBus.GetAvailableSeats();
            Console.Write("  Seats : ");
            foreach (int seat in seats)
            {
                Console.Write(seat + " ");
            }
            Console.WriteLine();
        }

        static void BookTicket()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("              BOOK TICKET                   ");
            Console.WriteLine("============================================");

            Console.WriteLine("  -- Available Users --");
            List<User> users = userService.GetAllUsers();
            if (users.Count == 0)
            {
                Console.WriteLine("  No users found. Please create a user first.");
                return;
            }
            foreach (User u in users)
            {
                Console.WriteLine("  --------------------------------");
                u.DisplayInfo();
            }
            Console.WriteLine("  --------------------------------");
            Console.Write("  Enter User ID     : ");
            int userId = int.Parse(Console.ReadLine());
            User user = userService.GetUserById(userId);

            if (user == null)
            {
                Console.WriteLine("  User not found.");
                return;
            }

            Console.WriteLine("\n  -- Available Schedules --");
            List<Schedule> schedules = scheduleService.GetAllSchedules();
            if (schedules.Count == 0)
            {
                Console.WriteLine("  No schedules found. Please create a schedule first.");
                return;
            }
            foreach (Schedule s in schedules)
            {
                Console.WriteLine("  --------------------------------");
                s.DisplayInfo();
            }
            Console.WriteLine("  --------------------------------");
            Console.Write("  Enter Schedule ID : ");
            int scheduleId = int.Parse(Console.ReadLine());
            Schedule schedule = scheduleService.GetScheduleById(scheduleId);

            if (schedule == null)
            {
                Console.WriteLine("  Schedule not found.");
                return;
            }

            Console.WriteLine("\n  -- Available Seats --");
            List<int> seats = schedule.AssignedBus.GetAvailableSeats();
            Console.Write("  Seats : ");
            foreach (int seat in seats)
            {
                Console.Write(seat + " ");
            }
            Console.WriteLine();

            Console.Write("\n  Enter Seat Number : ");
            int seatNumber = int.Parse(Console.ReadLine());

            Ticket ticket = bookingService.BookTicket(user, schedule, seatNumber);

            if (ticket == null) return;

            Console.WriteLine("\n  Ticket booked successfully!");
            Console.WriteLine("  --------------------------------");
            ticket.DisplayInfo();
            Console.WriteLine("  --------------------------------");

            Invoice invoice = bookingService.GenerateInvoice(ticket);
            Console.WriteLine("\n  Invoice generated automatically!");
            Console.WriteLine("  --------------------------------");
            invoice.DisplayInfo();
            Console.WriteLine("  --------------------------------");
        }

        static void DisplayUserInvoices()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("             USER INVOICES                  ");
            Console.WriteLine("============================================");
            Console.Write("  Enter User ID : ");
            int userId = int.Parse(Console.ReadLine());
            bookingService.DisplayUserInvoices(userId);
        }

        static void ProcessPayment()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("            PROCESS PAYMENT                 ");
            Console.WriteLine("============================================");
            Console.Write("  Enter User ID    : ");
            int userId = int.Parse(Console.ReadLine());

            Console.WriteLine("\n  -- Your Invoices --");
            bookingService.DisplayUserInvoices(userId);

            Console.Write("  Enter Invoice ID : ");
            int invoiceId = int.Parse(Console.ReadLine());
            bookingService.ProcessPayment(invoiceId);
        }

        static void DisplayUserTickets()
        {
            Console.WriteLine("============================================");
            Console.WriteLine("             USER TICKETS                   ");
            Console.WriteLine("============================================");
            Console.Write("  Enter User ID : ");
            int userId = int.Parse(Console.ReadLine());
            bookingService.DisplayUserTickets(userId);
        }
    }
}