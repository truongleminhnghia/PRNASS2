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
        public async Task<SystemAccount> SaveAccount(SystemAccount account)
        {
            _context.SystemAccounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<SystemAccount?> GetById(int id)
        {
            return await _context.SystemAccounts.FindAsync(id);
        }

        public async Task<IEnumerable<SystemAccount>> GetAll()
        {
            return await _context.SystemAccounts.ToListAsync();
        }

        public async Task<bool> Update(int id, SystemAccount account)
        {
            var existingAccount = await _context.SystemAccounts.FindAsync(id);
            if (existingAccount == null)
            {
                return false;
            }

            existingAccount.AccountName = account.AccountName;
            existingAccount.AccountEmail = account.AccountEmail;
            existingAccount.AccountRole = account.AccountRole;
            existingAccount.AccountPassword = account.AccountPassword;
            existingAccount.AccountStatus = account.AccountStatus;

            _context.SystemAccounts.Update(existingAccount);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStatus(int id)
        {
            var existingAccount = await _context.SystemAccounts.FindAsync(id);
            if (existingAccount == null)
            {
                return false;
            }

            existingAccount.AccountStatus = "IN_ACTIVE";
            _context.Entry(existingAccount).Property(x => x.AccountStatus).IsModified = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckEmail(string email)
        {
            return await _context.SystemAccounts.AnyAsync(a => a.AccountEmail == email);
        }
    }
}
