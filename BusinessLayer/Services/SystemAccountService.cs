using AutoMapper;
using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class SystemAccountService : ISystemAccountService
    {
        private readonly ISystemAccountRepository _repository;
        private readonly IMapper _mapper;

        public SystemAccountService(ISystemAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SystemAccountResponse> SaveAccount(SystemAccountRequest accountRequest)
        {
            var account = _mapper.Map<SystemAccount>(accountRequest);
            var savedAccount = await _repository.SaveAccount(account);
            return _mapper.Map<SystemAccountResponse>(savedAccount);
        }

        public async Task<SystemAccountResponse?> GetById(int id)
        {
            var account = await _repository.GetById(id);
            return account == null ? null : _mapper.Map<SystemAccountResponse>(account);
        }

        public async Task<IEnumerable<SystemAccountResponse>> GetAll()
        {
            var accounts = await _repository.GetAll();
            return _mapper.Map<IEnumerable<SystemAccountResponse>>(accounts);
        }

        public async Task<IEnumerable<SystemAccountResponse>> GetFilteredAccounts(string status, string searchTerm, string role)
        {
            var accounts = await _repository.GetAll();

            if (!string.IsNullOrEmpty(status))
            {
                accounts = accounts.Where(a => a.AccountStatus == status);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accounts = accounts.Where(a => a.AccountName.Contains(searchTerm) || a.AccountEmail.Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(role))
            {
                accounts = accounts.Where(a => a.AccountRole == role);
            }

            return _mapper.Map<IEnumerable<SystemAccountResponse>>(accounts.OrderBy(a => a.AccountName));
        }

        public async Task<bool> Update(int id, SystemAccountRequest accountRequest)
        {
            var account = _mapper.Map<SystemAccount>(accountRequest);
            return await _repository.Update(id, account);
        }

        public async Task<bool> UpdateStatus(int id)
        {
            return await _repository.UpdateStatus(id);
        }

        public async Task<bool> CheckEmail(string email)
        {
            return await _repository.CheckEmail(email);
        }
    }
}
