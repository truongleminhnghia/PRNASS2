using AutoMapper;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NewsTagService : INewsTagService
    {
        private readonly INewsTagRepository _newsTagRepository;
        private readonly IMapper _mapper;

        public NewsTagService(INewsTagRepository newsTagRepository, IMapper mapper)
        {
            _newsTagRepository = newsTagRepository;
            _mapper = mapper;
        }
    }
}
