using BusinessLayer.Interface;
using ModelLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL userRL;

        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public UserEntity AddUser(UserML model)
        {
           return userRL.AddUser(model);
        }

        public UserEntity UpdateUser(string name, UserML model)
        {
            return userRL.UpdateUser(name, model);
        }

        public List<UserEntity> GetAllUsers()
        {
            return userRL.GetAllUsers();
        }

        public UserEntity GetUserByName(string name)
        {
            return userRL.GetUserByName(name);
        }

        public UserEntity DeleteUser(int id)
        {
            return userRL.DeleteUser(id);
        }
    }
}
