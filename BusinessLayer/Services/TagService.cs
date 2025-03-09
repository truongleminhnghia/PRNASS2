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
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<TagResponse> CreateAsync(TagRequest tagRequest)
        {
            try
            {
                var tag = _mapper.Map<Tag>(tagRequest);
                var createdTag = await _tagRepository.CreateAsync(tag);
                return _mapper.Map<TagResponse>(createdTag);
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể tạo tag", ex);
            }
        }

        public async Task<List<TagResponse>> GetAllAsync()
        {
            try
            {
                var tags = await _tagRepository.GetAllAsync();
                return _mapper.Map<List<TagResponse>>(tags);
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể lấy danh sách tag", ex);
            }
        }

        public async Task<TagResponse?> GetByIdAsync(int id)
        {
            try
            {
                var tag = await _tagRepository.GetByIdAsync(id);
                return _mapper.Map<TagResponse>(tag);
            }
            catch (Exception ex)
            {
                throw new Exception($"Không thể lấy tag với ID {id}", ex);
            }
        }

        public async Task<TagResponse> UpdateAsync(int id, TagRequest tagRequest)
        {
            try
            {
                var existingTag = await _tagRepository.GetByIdAsync(id);
                if (existingTag == null)
                {
                    return null; // Trả về null nếu không tìm thấy
                }

                _mapper.Map(tagRequest, existingTag);
                var updatedTag = await _tagRepository.UpdateAsync(id, existingTag);
                return _mapper.Map<TagResponse>(updatedTag);
            }
            catch (Exception ex)
            {
                throw new Exception($"Không thể cập nhật tag với ID {id}", ex);
            }
        }
        public async Task<List<TagResponse>> GetTagsByArticleIdAsync(int articleId)
        {
            var tags = await _tagRepository.GetByArticleIdAsync(articleId);
            return _mapper.Map<List<TagResponse>>(tags);
        }
    }
}
