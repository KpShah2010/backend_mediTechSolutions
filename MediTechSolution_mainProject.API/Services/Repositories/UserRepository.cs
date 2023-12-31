﻿using MediTechSolution_mainProject.API.Data;
using MediTechSolution_mainProject.API.Model;
using MediTechSolution_mainProject.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediTechSolution_mainProject.API.Services.Repositories
{
    public class UserRepository : IUser
    {
        private readonly ApplicatinDbContext applicatinDbContext;

        public UserRepository(ApplicatinDbContext applicatinDbContext)
        {
            this.applicatinDbContext = applicatinDbContext;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await applicatinDbContext.Users.AddAsync(user);
            await applicatinDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserByIdAsync(int id)
        {
            var existingId = await applicatinDbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(existingId == null) 
            {
                return null;
            }

            applicatinDbContext.Users.Remove(existingId);
            await applicatinDbContext.SaveChangesAsync();

            return existingId;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await applicatinDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var existingId = await applicatinDbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            return existingId;
        }

        public async Task<User> UpdateUserByIdAsync(int id, User user)
        {
            var existingId = await applicatinDbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingId == null)
            {
                return null;
            }

            existingId.Fname = user.Fname;
            existingId.Email = user.Email;
            existingId.Lname = user.Lname;
            existingId.Username = user.Username;
            existingId.State = user.State;
            existingId.City = user.City;
            existingId.Country = user.Country;
            existingId.Gender = user.Gender;
            existingId.ProfileImage = user.ProfileImage;

            await applicatinDbContext.SaveChangesAsync();
            return existingId;
        }
    }
}
