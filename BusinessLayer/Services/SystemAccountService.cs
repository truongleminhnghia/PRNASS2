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
        private readonly ISystemAccountRepository _systemAccountRepository;
        private readonly IMapper _mapper;

        public SystemAccountService(ISystemAccountRepository systemAccountRepository, IMapper mapper)
        {
            _systemAccountRepository = systemAccountRepository;
            _mapper = mapper;
        }
        public async Task<SystemAccountResponse> CreateAccount(SystemAccountRequest request)
        {
            bool isExisting = await _systemAccountRepository.CheckEmail(request.AccountEmail);
            if (isExisting) // Nếu email đã tồn tại
            {
                throw new Exception("Email already exists");
            }
            var account = await _systemAccountRepository.SaveAccount(_mapper.Map<SystemAccount>(request));
            if (account != null)
            {
                return _mapper.Map<SystemAccountResponse>(account);
            }
            throw new Exception("Failed to create account");
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var result = await _systemAccountRepository.UpdateStatus(id);
            if (result)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<SystemAccountResponse>> GetAll()
        {
            var accounts = await _systemAccountRepository.GetAll();
            if (accounts == null)
            {
                throw new Exception("List empty!");
            }
            return _mapper.Map<IEnumerable<SystemAccountResponse>>(accounts);
        }

        public async Task<SystemAccountResponse> GetById(int id)
        {
            var result = await _systemAccountRepository.GetById(id);
            if (result != null)
            {
                return _mapper.Map<SystemAccountResponse>(result);
            }
            throw new Exception("Account do not exist");
        }

        public async Task<bool> Update(int id, SystemAccountRequest request)
        {
            var account = await _systemAccountRepository.GetById(id);
            if (account == null)
            {
                return false; // Hoặc throw new Exception("Account not found");
            }
            if (request.AccountName != null)
            {
                account.AccountName = request.AccountName;

            }
            if (request.AccountEmail != null)
            {
                account.AccountEmail = request.AccountEmail;

            }
            if (request.AccountStatus != null)
            {
                account.AccountStatus = request.AccountStatus;

            }
            if (request.AccountRole != null)
            {
                account.AccountRole = request.AccountRole;

            }
            await _systemAccountRepository.Update(id, account);
            return true;
        }
    }
}
