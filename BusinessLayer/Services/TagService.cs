using AutoMapper;
using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TagResponse> SaveTag(string tagName)
        {
            var tag = new Tag { TagName = tagName };
            var savedTag = await _repository.SaveTag(tag);
            return _mapper.Map<TagResponse>(savedTag);
        }

        public async Task<TagResponse?> GetById(int id)
        {
            var tag = await _repository.GetById(id);
            return tag == null ? null : _mapper.Map<TagResponse>(tag);
        }

        public async Task<TagResponse?> GetByName(string name)
        {
            var tag = await _repository.GetByName(name);
            return tag == null ? null : _mapper.Map<TagResponse>(tag);
        }

        public async Task<IEnumerable<TagResponse>> GetAll()
        {
            var tags = await _repository.GetAll();
            return _mapper.Map<IEnumerable<TagResponse>>(tags);
        }
    }
}
