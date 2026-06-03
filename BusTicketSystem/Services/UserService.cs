using System;
using System.Collections.Generic;
using BusTicketSystem.Models;

namespace BusTicketSystem.Services
{
    public class UserService : IUserService
    {
        private List<User> _users;
        private int _nextId;

        public UserService()
        {
            _users = new List<User>();
            _nextId = 1;
        }

        public User CreateUser(string fullName, string email, string mobileNumber)
        {
            User newUser = new User(_nextId, fullName, email, mobileNumber);
            _users.Add(newUser);
            _nextId++;
            return newUser;
        }

        public User GetUserById(int id)
        {
            foreach (User user in _users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public void DisplayAllUsers()
        {
            if (_users.Count == 0)
            {
                Console.WriteLine("  No users found.");
                return;
            }

            foreach (User user in _users)
            {
                Console.WriteLine("  --------------------------------");
                user.DisplayInfo();
            }
            Console.WriteLine("  --------------------------------");
        }
    }
}