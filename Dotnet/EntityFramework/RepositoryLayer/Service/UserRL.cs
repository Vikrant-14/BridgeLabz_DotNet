using Microsoft.Extensions.Primitives;
using ModelLayer;
using RepositoryLayer.Context;
using RepositoryLayer.CustomException;
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
            try
            {
                UserEntity userEntity = new UserEntity();   
                userEntity.Name = model.Name;

                _context.Users.Add(userEntity);
                _context.SaveChanges();

                return userEntity;
            }
            catch(UserException u) 
            {
                throw new UserException("Error Occured while Adding User.");
            }

        }

        public UserEntity UpdateUser(string name, UserML model)
        {
            var userEntity = _context.Users.Where( u =>  u.Name == name).FirstOrDefault();

            if (userEntity != null)
            {
                userEntity.Name = model.Name;
                _context.SaveChanges();
            }
            else
            {
                throw new UserException("No such user found");
            }

            return userEntity;
        }

        public UserEntity GetUserByName(string name)
        {
            var userEntity = _context.Users.Where( u => u.Name == name).FirstOrDefault();

            if( userEntity == null)
            {
                throw new UserException("No such user exists");
            }

            return userEntity;
        }

        public List<UserEntity> GetAllUsers()
        {
            var result =  _context.Users.ToList<UserEntity>();

            if( result == null )
            {
                throw new UserException("No Users Exists in the Database");
            }

            return result;
        }

        public UserEntity DeleteUser(int id)
        {
            var userEntity = _context.Users.Where( u => u.Id == id ).FirstOrDefault();

            if (userEntity != null)
            {
                _context.Users.Remove(userEntity);
                _context.SaveChanges();
            }
            else{
                throw new UserException("No user was found to be deleted");
            }

            return userEntity;
        }
    }
}
