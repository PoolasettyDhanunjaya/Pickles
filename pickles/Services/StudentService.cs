using MongoDB.Driver;
using StudentMVP.Models;

namespace pickles.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDB:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
            _students = database.GetCollection<Student>(config["MongoDB:CollectionName"]);
        }

        public async Task<List<Student>> GetAllAsync() => await _students.Find(student => true).ToListAsync();

        public async Task CreateAsync(Student student) => await _students.InsertOneAsync(student);
    }
}
