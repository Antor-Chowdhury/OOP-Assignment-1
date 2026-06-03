using BusTicketSystem.Models;
using System.Collections.Generic;

namespace BusTicketSystem.Services
{
    public interface IUserService
    {
        User CreateUser(string fullName, string email, string mobileNumber);
        User GetUserById(int id);
        List<User> GetAllUsers();
    }
}