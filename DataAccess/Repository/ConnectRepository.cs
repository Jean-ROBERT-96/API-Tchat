using CommonLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ConnectRepository : IConnectRepository
    {
        private readonly DataContext _context;

        public ConnectRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User?> Get(string mail, string pass)
        {
            var user = await _context.Users.Where(x => x.Mail == mail).LastOrDefaultAsync();
            if (user == null || user.Password != pass)
                return null;

            return user;
        }
    }
}
