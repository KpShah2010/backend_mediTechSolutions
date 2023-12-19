using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface IUser
    {
        Task<User> CreateUserAsync(User user);
        Task<List<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> DeleteUserByIdAsync(int id);
        Task<User> UpdateUserByIdAsync(int id, User user);
    }
}