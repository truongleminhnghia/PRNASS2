﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models.Responses;

namespace BusinessLayer.Services
{
    public interface INewsTagService
    {
        Task<List<NewsTagResponse>> GetTagsByArticleIdAsync(int articleId);
    }
}
