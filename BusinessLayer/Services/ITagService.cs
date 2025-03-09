using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Internal;
using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;

namespace BusinessLayer.Services
{
    public interface ITagService
    {
        Task<TagResponse> CreateAsync(TagRequest tagRequest);
        Task<List<TagResponse>> GetAllAsync();
        Task<TagResponse?> GetByIdAsync(int id);
        Task<TagResponse> UpdateAsync(int id, TagRequest tagRequest);
        Task<List<TagResponse>> GetTagsByArticleIdAsync(int articleId);
        //Task<bool> DeleteAsync(int id);
    }
}
