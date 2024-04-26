using DataImpact.Interfaces;
using DataImpact.Models;
using DataImpact.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;

namespace DataImpact.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SavePersonalInfoAsync(PersonalInfoModel personalInfo)
        {
            try
            {
                var personalInfoEntity = new PersonalInfoModel
                {
                    // Map properties from PersonalInfoModel to PersonalInfo entity
                };
                _dbContext.PersonalInfo.Add(personalInfo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc
                return false;
            }

            //Map PersonalInfoModel to your Entity Model(e.g., PersonalInfo entity)
            //var personalInfoEntity = new PersonalInfoModel
            //{

            //};
            //Add personalInfoEntity to the context and save changes
        }

        public async Task<int> CreateUserAsync(User user)
        {
            // Implement the logic to save the user data to the database
            // Return the ID of the newly created user or an appropriate response
            // Example using Entity FrameworkCore:
            var newUser = new User
            {
                // Map propeties from UserModel to User Entity
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return newUser.Id;
        }

        public async Task<User?> GetUserByIdAsync(int Id)
        {
            // Implement the logic to save the user data to the database
            // Example using Entity FrameworkCore:
            var user = await _dbContext.Users.FindAsync(Id);

            // Check if the user was found in the database
            if (user == null) 
            {
                // Map propeties from UserModel to User Entity
                return MapUserEntityToModel(user);
            }

            // Handle the case when the user with the specified ID was not found
            // You can throw an exception, retrun a default user, or handle it as per application's requirements
            // For now, returning null as an example
            return null;
        }

        public async Task<List<User?>> GetAllUsersAsync()
        {
            // Implement the logic to save the user data to the database
            // Example using Entity FrameworkCore:
            var users = await _dbContext.Users.ToListAsync();
            // Map propeties from UserModel to User Entity
            return users.Select(MapUserEntityToModel).ToList();
        }

        public async Task<bool> UpdateUserAsync(int Id, User user)
        {
            // Implement the logic to save the user data to the database
            // Example using Entity FrameworkCore:
            var existingUser = await _dbContext.Users.FindAsync(Id);

            if (existingUser != null) 
            {
                // Map propeties from User to existingUser entity
                await _dbContext.SaveChangesAsync();
                return true; //Update Successful!
            }
            return false; // User with the provided Id not found
        }

        public async Task<bool> DeleteUserAsync(int Id)
        {
            // Implement the logic to save the user data to the database
            // Example using Entity FrameworkCore:
            var existingUser = await _dbContext.Users.FindAsync(Id);

            if (existingUser != null)
            {
                // Map propeties from User to existingUser entity
                _dbContext.Users.Remove(existingUser);
                await _dbContext.SaveChangesAsync();
                return true; //Deletion Successful!
            }
            return false; // User with provided Id not found
        }

        private User? MapUserEntityToModel(User userEntity)
        {
            if (userEntity == null)
            {
                return null;
            }
            return new User
            {
                Id = userEntity.Id,
                //Map othere properties from UserEntity to User
                // For example: Name = userEntity.Name
            };
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _dbContext.Roles.ToListAsync();
        }

       
    }
}
