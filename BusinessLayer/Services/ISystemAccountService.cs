using BusinessLayer.Models.Requests;
using BusinessLayer.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ISystemAccountService
    {
        public Task<SystemAccountResponse> CreateAccount(SystemAccountRequest request);
        public Task<SystemAccountResponse> GetById(int id);
        public Task<IEnumerable<SystemAccountResponse>> GetAll();
        public Task<bool> DeleteAccount(int id);
        public Task<bool> Update(int id, SystemAccountRequest request);
        public Task<string?> ResetPassword(int id);
            

    }
}
