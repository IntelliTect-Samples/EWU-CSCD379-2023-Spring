using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class UserService
    {
        private readonly AppDbContext _db;
        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User> AddUser(string username, string password)
        {
            User? user = await _db.Users.FirstOrDefaultAsync(user => user.Username == username);

            if (user == null)
            {
                user = new()
                {
                    Username = username,
                    Password = password
                };
                _db.Users.Add(user);
            }
            await _db.SaveChangesAsync();
            return user;
        }
        public async Task<User?> GetUser(string username, string password)
        {
            return await _db.Users.FirstOrDefaultAsync(user => user.Username == username && user.Password == password);
        }

        public async Task<User?> UpdateUserScore(string username, bool win) 
        {
            User? user = await _db.Users.FirstOrDefaultAsync(user => user.Username == username);
            if (user != null) 
            { 
                user.Wins  += win ? 1 : 0;
                user.Loses += win ? 0 : 1;
            }
            await _db.SaveChangesAsync();
            return user;
        }
    }
}