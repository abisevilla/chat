using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Entities;
namespace WebApp.Interfaces
{
   public interface IUserRepository
    {

        void AddUser(User user);
        bool VerifyUser(User user);

        Task<List<User>> GetUsers();
    }
}
