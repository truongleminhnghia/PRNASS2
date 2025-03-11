using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public interface ITagRepository
    {
        Task<Tag> SaveTag(Tag tag);
        Task<Tag?> GetById(int id);
        Task<Tag?> GetByName(string name);
        Task<IEnumerable<Tag>> GetAll();
    }
}
