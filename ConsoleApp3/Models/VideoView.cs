using MongoDB.Bson;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class VideoView
    {
        public List<string> Tags { get; set; } = new List<string>();

        public ObjectId Id { get; set; }

        public ObjectId OwnerId { get; set; }

        public string Title { get; set; }

        public double Length { get; set; }
    }
}

