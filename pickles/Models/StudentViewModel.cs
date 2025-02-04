using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentMVP.Models
{
    public class Student
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }
    }
}
