using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // Get all users
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        // Add user
        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        // Get by id
        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }
    }
}
