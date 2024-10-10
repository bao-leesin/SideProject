using System;

namespace Data.Entities
{
    public class ACCOUNT
    {
        // Parameterless constructor required by EF
        public ACCOUNT() { }

        // Constructor with parameters
        public ACCOUNT(string username, string password)
        {
            USERNAME = username;
            PASSWORD = password;
        }

        // Primary key
        public string USERNAME { get; set; }

        // Properties
        public string PASSWORD { get; set; }
    }
}
