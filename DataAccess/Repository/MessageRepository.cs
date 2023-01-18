using CommonLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MessageRepository : IRepository<Message>
    {
        private readonly DataContext _context;

        public MessageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> Get()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<Message> Post(Message entity)
        {
            _context.Messages.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Message?> Put(int id, Message entity)
        {
            var rep = await _context.Messages.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (rep != null)
                return null;

            _context.Attach(entity).State= EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Message?> Delete(int id)
        {
            var rep = await _context.Messages.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (rep != null)
                return null;

            _context.Messages.Remove(rep);
            await _context.SaveChangesAsync();

            return rep;
        }
    }
}
