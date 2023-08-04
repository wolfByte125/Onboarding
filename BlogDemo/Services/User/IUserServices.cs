using BlogDemo.DTOs.UserDTOs;
using BlogDemo.Models;

namespace BlogDemo.Services.UserServices
{
    public interface IUserServices
    {
        Task<User> AddUser(AddUserDTOs userDTO);
        Task<User> DeleteUser(int id, string name);
        Task<User> GetUser(int id, string name);
        Task<List<User>> GetUsers();
        Task<User> UpdateUser(UpdateUserDTO userDTO);
    }
}
