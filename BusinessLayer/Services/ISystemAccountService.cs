using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ISystemAccountService
    {
        Task<SystemAccountResponse> SaveAccount(SystemAccountRequest accountRequest);
        Task<SystemAccountResponse?> GetById(int id);
        Task<IEnumerable<SystemAccountResponse>> GetAll();
        Task<IEnumerable<SystemAccountResponse>> GetFilteredAccounts(string status, string searchTerm, string role);
        Task<bool> Update(int id, SystemAccountRequest accountRequest);
        Task<bool> UpdateStatus(int id);
        Task<bool> CheckEmail(string email);
    }
}
