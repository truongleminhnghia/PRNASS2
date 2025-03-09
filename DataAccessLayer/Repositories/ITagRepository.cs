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
        Task<List<Tag>> GetAllAsync();
        Task<Tag?> GetByIdAsync(int id);
        Task<Tag> CreateAsync(Tag tag);
        Task<Tag> UpdateAsync(int id, Tag tag);
        Task<List<Tag>> GetByArticleIdAsync(int articleId);
        //Task<bool> DeleteAsync(int id);

    }
}
