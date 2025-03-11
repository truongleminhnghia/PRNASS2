using Azure;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> SaveTag(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> GetById(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<Tag?> GetByName(string name)
        {
            return await _context.Tags.FirstOrDefaultAsync(t => t.TagName == name);
        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            return await _context.Tags.ToListAsync();
        }
    }
}
