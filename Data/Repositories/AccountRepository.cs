   using System.Collections.Generic;
   using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

   namespace Data.Repositories
   {
       public class AccountRepository : IAccountRepository
       {
           private readonly AppDbContext _context;

           public AccountRepository(AppDbContext context)
           {
               _context = context;
           }

           public async Task<ACCOUNT> GetAccountByUsernameAsync(string username)
           {
               return await _context.ACCOUNTs.FindAsync(username);
           }

           public async Task<IEnumerable<ACCOUNT>> GetAllAccountsAsync()
           {
               return await _context.ACCOUNTs.ToListAsync();
           }

           public async Task AddAccountAsync(ACCOUNT account)
           {
               await _context.ACCOUNTs.AddAsync(account);
               await _context.SaveChangesAsync();
           }

           public async Task UpdateAccountAsync(ACCOUNT account)
           {
               _context.ACCOUNTs.Update(account);
               await _context.SaveChangesAsync();
           }

           public async Task DeleteAccountAsync(string username)
           {
               var account = await _context.ACCOUNTs.FindAsync(username);
               if (account != null)
               {
                   _context.ACCOUNTs.Remove(account);
                   await _context.SaveChangesAsync();
               }
           }
       }
   }
   