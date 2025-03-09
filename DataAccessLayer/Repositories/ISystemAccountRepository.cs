using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface ISystemAccountRepository
    {
        public Task<SystemAccount> SaveAccount(SystemAccount account);
        public Task<SystemAccount?> GetById(int id);
        public Task<IEnumerable<SystemAccount>> GetAll();
        public Task<bool> Update(int id, SystemAccount account);
        public Task<bool> UpdateStatus(int id);
        public Task<bool> CheckEmail(string email);
    }
}
