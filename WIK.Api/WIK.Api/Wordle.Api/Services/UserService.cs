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

        public async Task<User?> AddUser(string username, string password)
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
                await _db.SaveChangesAsync();
            }
            else 
            {
                user = null;
            }
            
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
        public async Task<string[]> getTopUsers()
        {
            string[] strUsers = new string[10];
            for (int i = 0; i < 10; i++)
            {
                strUsers[i] = " , , ";
            }
            var users = await _db.Users.OrderByDescending(c => c.Wins + c.Loses).Take(10).ToArrayAsync();
            int count = 0;
            foreach (var user in users)
            { 
                strUsers[count] = $"{user.Username},{user.Wins},{user.Loses}";
                count++;
            }

            return strUsers;
        }
        public async Task<bool> checkUsername(string username) 
        {
            User? user = await _db.Users.FirstOrDefaultAsync(user => user.Username == username);
            return user != null;
        } 
    }
}