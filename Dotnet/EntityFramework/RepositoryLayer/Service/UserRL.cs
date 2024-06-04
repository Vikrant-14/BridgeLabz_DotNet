using Microsoft.Extensions.Primitives;
using ModelLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        private readonly ApplicationContext _context;

        public UserRL(ApplicationContext context)
        {
            this._context = context;
        }
        public UserEntity AddUser(UserML model)
        {
            UserEntity userEntity = new UserEntity();   
            userEntity.Name = model.Name;

            _context.Users.Add(userEntity);
            _context.SaveChanges();

            return userEntity;
        }

        public UserEntity UpdateUser(string name, UserML model)
        {
            var userEntity = _context.Users.Where( u =>  u.Name == name).FirstOrDefault();

            if (userEntity != null)
            {
                userEntity.Name = model.Name;
                _context.SaveChanges();
            }

            return userEntity;
        }

        public UserEntity GetUserByName(string name)
        {
            var userEntity = _context.Users.Where( u => u.Name == name).FirstOrDefault();

            return userEntity;
        }

        public List<UserEntity> GetAllUsers()
        {
            return _context.Users.ToList<UserEntity>();
        }

        public UserEntity DeleteUser(int id)
        {
            var userEntity = _context.Users.Where( u => u.Id == id ).FirstOrDefault();

            if (userEntity != null)
            {
                _context.Users.Remove(userEntity);
                _context.SaveChanges();
            }

            return userEntity;
        }
    }
}
