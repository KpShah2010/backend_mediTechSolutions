using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class AddNewsRepository : INews
    {
        private readonly ApplicatinDbContext dbContext;

        public AddNewsRepository(ApplicatinDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<News> CreateNewsAsync(News news)
        {
            await dbContext.News.AddAsync(news);
            await dbContext.SaveChangesAsync();

            return news;
        }

        public async Task<News> DeleteNewsAsync(int id)
        {
            var existingId = await dbContext.News.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            dbContext.News.Remove(existingId);
            await dbContext.SaveChangesAsync();

            return existingId;
        }

        public async Task<List<News>> GetAllNewsAsync()
        {
            return await dbContext.News.ToListAsync();
        }

        public async Task<News> GetNewsByIdAsync(int id)
        {
            var existingId = await dbContext.News.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            return existingId;
        }

        public async Task<News> UpdateNewsAsync(int id, News news)
        {
            var existingId = await dbContext.News.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            existingId.Title = news.Title;
            existingId.Description = news.Description;
            existingId.Image = news.Image;

            await dbContext.SaveChangesAsync();
            return existingId;
        }
    }
}