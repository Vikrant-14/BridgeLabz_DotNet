using ModelLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public  interface IUserBL
    {
            public UserEntity AddUser(UserML model);
            public UserEntity UpdateUser(string name, UserML model);
            public List<UserEntity> GetAllUsers();
            public UserEntity GetUserByName(string name);
            public UserEntity DeleteUser(int id);
    }
}
