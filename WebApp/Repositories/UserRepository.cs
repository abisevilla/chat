using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Interfaces;
using WebApp.Entities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChangesAsync();
        }

        public bool VerifyUser(User user)
        {
            _context.Users.FirstOrDefault(u => u.NickName == user.NickName);
            return true;
        }

        public async Task <List<User>> GetUsers()
        {
            var users =  await _context.Users.ToListAsync();
            return users;

        }

    }
}