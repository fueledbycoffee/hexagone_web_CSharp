using BlogMeImFamous.DAL;
using BlogMeImFamous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogMeImFamous.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
    public class UserService : IUserService
    {
        BlogContext context;
        public UserService()
        {
            context = new BlogContext();
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public User GetById(int id)
        {
            var temp = context.Users.FirstOrDefault(u => u.Id == id);
            return temp;
        }
    }
}
