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
    public class SystemAccountRepository : ISystemAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> UpdateStatus(int id)
        {
            var account = await _context.SystemAccounts.FirstOrDefaultAsync(a => a.AccountID == id);
            if (account == null)
            {
                return false;
            }
            account.AccountStatus = "NO_ACTIVE";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SystemAccount>> GetAll()
        {
            return await _context.SystemAccounts.ToListAsync();
        }

        public async Task<SystemAccount?> GetById(int id)
        {
            return await _context.SystemAccounts.FirstOrDefaultAsync(s => s.AccountID == id);
        }

        public async Task<SystemAccount> SaveAccount(SystemAccount account)
        {
            _context.SystemAccounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<bool> Update(int id, SystemAccount account)
        {
            var accountExisting = await _context.SystemAccounts.FirstOrDefaultAsync(a => a.AccountID == id);
            if (accountExisting == null)
            {
                return false;
            }
            _context.Entry(accountExisting).CurrentValues.SetValues(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckEmail(string email)
        {
            return await _context.SystemAccounts.AnyAsync(s => s.AccountEmail == email);
        }
    }
}
