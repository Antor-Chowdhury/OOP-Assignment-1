using System;

namespace BusTicketSystem.Models
{
    public abstract class Person
    {
        private int _id;
        private string _fullName;
        private string _email;

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Full name can't be empty.");
                _fullName = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (!value.Contains("@"))
                    throw new ArgumentException("Invalid email format.");
                _email = value;
            }
        }

        public Person(int id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;

        }

        public abstract void DisplayInfo();
    }
}