using ModelLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public UserEntity AddUser(UserML model);
        public UserEntity UpdateUser(string name, UserML model);
        public List<UserEntity> GetAllUsers();
        public UserEntity GetUserByName(string name);
        public UserEntity DeleteUser(int id);


    }
}
