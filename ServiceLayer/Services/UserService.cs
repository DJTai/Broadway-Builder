﻿using DataAccessLayer;
using ServiceLayer.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    /// <summary>
    /// The UserService class deals with how users are managed such as
    /// Creating, Reading, Updating, and Deleting a user
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Readonly limits the field to the only thing that can set it is its constructor.
        /// Private and readonly gives the benefit of not accidentally changing the
        /// field from another part of that class after it is initialized.
        /// </summary>
        private readonly BroadwayBuilderContext _dbContext;

        /// <summary>
        /// Initializes the BroadwayBuilderContext to an instance of the context passed as an argument
        /// </summary>
        /// <param name="context"></param>
        public UserService(BroadwayBuilderContext context)
        {
            this._dbContext = context;
        }

        /// <summary>
        /// CreateUser is a method in the UserService class.
        /// The user gets created in the database.
        /// Safe to assume User will always be valid due to front-end data validation
        /// </summary>
        /// <param name="user">The user that we want to create</param>
        public void CreateUser(User user)
        {
            user.DateCreated = DateTime.Now;
            _dbContext.Users.Add(user);
        }

        /// <summary>
        /// GetUser is a method in the UserSerivce class.
        /// </summary>
        /// <param name="username">The username we want to retrieve</param>
        /// <returns>The user that was obtained using the username</returns>
        public User GetUser(string username)
        {
            var user = _dbContext.Users
                .Where(o => o.Username == username)
                .FirstOrDefault();

            if (user == null)
            {
                throw new UserNotFoundException($"User with email {username} not found");
            }

            return user;
        }

        public User GetUser(int id)
        {
            var user = _dbContext.Users
                .Where(o => o.UserId == id)
                .FirstOrDefault();

            if (user == null)
            {
                throw new UserNotFoundException($"User with id {id} not found");
            }

            return user;
        }

        public User GetUser(User user)
        {
            return _dbContext.Users.Find(user.UserId);
        }

        public User GetUserByToken(string token)
        {
            var user = _dbContext.Sessions
                .Where(o => o.Token == token)
                .Select(o => o.User)
                .FirstOrDefault();

            if (user == null)
            {
                throw new UserNotFoundException($"User with token {token} not found");
            }

            return user;
        }

        /// <summary>
        /// UpdateUser is a method in the UserService class. 
        /// The user gets updated in the database.
        /// </summary>
        /// <param name="user">The user we want to update</param>
        /// <returns>The updated user</returns>
        public User UpdateUser(User user)
        {
            User userToUpdate = _dbContext.Users.Find(user.UserId);
            // If the user found is not null, update the user attributes
            if (userToUpdate != null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.StreetAddress = user.StreetAddress;
                userToUpdate.StateProvince = user.StateProvince;
                userToUpdate.Country = user.Country;
                userToUpdate.City = user.City;
                userToUpdate.IsEnabled = user.IsEnabled;
            }
            return userToUpdate;

        }

        /// <summary>
        /// DeleteUser is a method in the UserService class.
        /// The user gets deleted from the database.
        /// </summary>
        /// <param name="user">The user we want to delete</param>
        public void DeleteUser(User user)
        {
            User UserToDelete = _dbContext.Users.Find(user.UserId);
            // If the user found is not null, delete the user
            if (UserToDelete != null)
            {
                _dbContext.Users.Remove(UserToDelete);
            }
        }

        
        public void DeleteUser(string user)
        {
            User UserToDelete = _dbContext.Users.Find(user);
            // If the user found is not null, delete the user
            if (UserToDelete != null)
            {
                _dbContext.Users.Remove(UserToDelete);
            }
        }

        /// <summary>
        /// EnableAccount is a method in the UserService class.
        /// Enables an account of the user.
        /// </summary>
        /// <param name="user">The user whos account we want to enable</param>
        public User EnableAccount(User user)
        {
            User UserToEnable = _dbContext.Users.Find(user.UserId);
            if (UserToEnable != null)
            {
                UserToEnable.IsEnabled = true;
            }
            return UserToEnable;
        }

        /// <summary>
        /// DisableAccount is a method in the UserService class.
        /// Disables the user account using the dbContext
        /// </summary>
        /// <param name="user">The user that we want to disable</param>
        public User DisableAccount(User user)
        {
            User UserToDisable = _dbContext.Users.Find(user.UserId);
            if (UserToDisable != null)
            {
                UserToDisable.IsEnabled = false;
            }
            return UserToDisable;
        }

        /// <summary>
        /// AddUserPermission is a method in the UserService class.
        /// Adds a permission to a specific user.
        /// </summary>
        /// <param name="user">The user who we will be adding a permission to</param>
        /// <param name="role">The permission we will be adding to a user</param>
        public void AddUserRole(int userId, DataAccessLayer.Enums.RoleEnum role)
        {
            _dbContext.UserRoles.Add(new UserRole()
            {
                UserId = userId,
                RoleId = role,
                IsEnabled = true,
                DateCreated = DateTime.UtcNow,
            });
        }

        public List<DataAccessLayer.Enums.RoleEnum> GetUserRoles(int userId)
        {
            return _dbContext.UserRoles
                .Where(o => o.UserId == userId)
                .Select(o => o.RoleId)
                .ToList();
        }

        public bool HasUserRole(int userId, DataAccessLayer.Enums.RoleEnum role)
        {
            return _dbContext.UserRoles.Where(o => o.UserId == userId && o.RoleId == role).Any();
        }

        /// <summary>
        /// DeleteUserPermission is a method in the UserService class.
        /// This method removes the permission 
        /// </summary>
        /// <param name="user">The user whos permission we want to remove</param>
        /// <param name="permission">The permission to be removed from the user</param>
        public void DeleteUserRole(UserRole userRole)
        {
            UserRole roleToDelete = _dbContext.UserRoles.Find(userRole.UserId, userRole.RoleId);
            if (roleToDelete != null)
            {
                _dbContext.UserRoles.Remove(roleToDelete);
            }
        }

        public IQueryable<User> GetAllUsers()
        {
            return _dbContext.Users;
        }

        public void RemoveUserRole(int userId, DataAccessLayer.Enums.RoleEnum role)
        {
            var userRoleEntity = _dbContext.UserRoles
                .Where(o => o.UserId == userId && o.RoleId == role)
                .FirstOrDefault();

            if (userRoleEntity != null)
            {
                _dbContext.UserRoles.Remove(userRoleEntity);
            }         
        }
    }
}
