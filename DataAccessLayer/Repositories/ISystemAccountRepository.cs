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
        Task<SystemAccount> SaveAccount(SystemAccount account);
        Task<SystemAccount?> GetById(int id);
        Task<IEnumerable<SystemAccount>> GetAll();
        Task<bool> Update(int id, SystemAccount account);
        Task<bool> UpdateStatus(int id);
        Task<bool> CheckEmail(string email);
    }
}
