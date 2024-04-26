using DataImpact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImpact.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int Id);
        Task<List<User?>> GetAllUsersAsync();
        Task<List<Role>> GetRolesAsync();
        Task<bool> SavePersonalInfoAsync(PersonalInfoModel personalInfo);
        Task<int> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(int Id, User user);
        Task<bool> DeleteUserAsync(int Id);
    }
}
