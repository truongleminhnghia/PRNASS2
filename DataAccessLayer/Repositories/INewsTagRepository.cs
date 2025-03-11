using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public interface INewsTagRepository
    {
        public Task<NewsTag> Save(NewsTag newsTag);
        public Task<NewsTag> GetById(int id);
        public Task<IEnumerable<NewsTag>> GetAll();
        public Task Delete(int id);
        public Task Update(NewsTag newsTag);
    }
}
