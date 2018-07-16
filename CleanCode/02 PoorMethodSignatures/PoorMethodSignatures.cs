using System;
using System.Linq;

namespace CleanCode.PoorMethodSignatures
{
    public class PoorMethodSignatures
    {
        private UserService userService;

        public PoorMethodSignatures()
        {
            this.userService = new UserService();
        }

        public void userLogin(string username, string password)
        {
            var user = userService.login(username, password);
        }

        public void getUser(string username)
        {
            var anotherUser = userService.getUserByUsername(username);
        }
    }

    public class UserService
    {
        private UserDbContext _dbContext = new UserDbContext();

        public User getUserByUsername(string username)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Username == username);
        }

        public User login(string username, string password)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
                user.LastLogin = DateTime.Now;
            return user;
        }
    }

    public class UserDbContext : DbContext
    {
        public IQueryable<User> Users { get; set; }
    }

    public class DbSet<T>
    {
    }

    public class DbContext
    {
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
