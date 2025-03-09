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

        public async Task<List<Tag>> GetAllAsync()
        {
            try
            {
                return await _context.Tags.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy danh sách Tags: {ex.Message}");
                return new List<Tag>();
            }
        }

        public async Task<Tag?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Tags.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi lấy Tag theo ID: {ex.Message}");
                return null;
            }
        }

        public async Task<Tag> CreateAsync(Tag tag)
        {
            try
            {
                _context.Tags.Add(tag);
                await _context.SaveChangesAsync();
                return tag;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo Tag: {ex.Message}");
                return null;
            }
        }

        public async Task<Tag> UpdateAsync(int id, Tag tag)
        {
            try
            {
                var existingTag = await _context.Tags.FindAsync(id);
                if (existingTag == null) return null;

                existingTag.TagName = tag.TagName;
                existingTag.Note = tag.Note;

                await _context.SaveChangesAsync();
                return existingTag;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật Tag: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var existingTag = await _context.Tags.FindAsync(id);
                if (existingTag == null) return false;

                _context.Tags.Remove(existingTag);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa Tag: {ex.Message}");
                return false;
            }
        }

        public async Task<List<Tag>> GetTagsByIdsAsync(List<int> tagIds)
        {
            try
            {
                return await _context.Tags.Where(t => tagIds.Contains(t.TagID)).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách Tags theo ID: {ex.Message}");
                return new List<Tag>();
            }
        }
        public async Task<List<Tag>> GetByArticleIdAsync(int articleId)
        {
            try
            {
                return await _context.NewsTags
                    .Where(nt => nt.NewsArticleID == articleId)
                    .Include(nt => nt.Tag)
                    .Select(nt => nt.Tag)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách Tags theo Article ID: {ex.Message}");
                return new List<Tag>();
            }
        }
    }
}
