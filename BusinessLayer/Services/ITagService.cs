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
        Task<TagResponse> SaveTag(string tagName);
        Task<TagResponse?> GetById(int id);
        Task<TagResponse?> GetByName(string name);
        Task<IEnumerable<TagResponse>> GetAll();
    }
}
