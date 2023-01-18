using CommonLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ChannelRepository : IRepository<Channel>
    {
        private readonly DataContext _context;

        public ChannelRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Channel>> Get()
        {
            return await _context.Channels.ToListAsync();
        }

        public async Task<Channel> Post(Channel entity)
        {
            _context.Channels.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Channel?> Put(int id, Channel entity)
        {
            var rep = await _context.Channels.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (rep != null)
                return null;

            _context.Attach(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Channel?> Delete(int id)
        {
            var rep = await _context.Channels.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (rep != null)
                return null;

            _context.Channels.Remove(rep);
            await _context.SaveChangesAsync();

            return rep;
        }
    }
}
