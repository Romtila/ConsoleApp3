using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class User : IHasId
    {
        public List<string> Tags { get; set; } = new List<string>();

        public ObjectId Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
