using MediTechSolution_mainProject.API.Model;

namespace MediTechSolution_mainProject.API.Services.Interfaces
{
    public interface INews
    {
        Task<News> CreateNewsAsync(News news);
        Task<List<News>> GetAllNewsAsync();
        Task<News> GetNewsByIdAsync(int id);
        Task<News> DeleteNewsAsync(int id);
    }
}