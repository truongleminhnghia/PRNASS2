using DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class NewsTagRepository : INewsTagRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsTagRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
