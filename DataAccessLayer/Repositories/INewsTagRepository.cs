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
        Task AddTagsToArticleAsync(int articleId, List<int> tagIds);
        Task RemoveTagsFromArticleAsync(int articleId);
        Task<List<Tag>> GetTagsByArticleIdAsync(int articleId);
    }
}
