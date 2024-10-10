using Data.Entities;
using System.Collections.Generic;
   using System.Threading.Tasks;

   namespace Data.Repositories
   {
       public interface IAccountRepository
       {
           Task<ACCOUNT> GetAccountByUsernameAsync(string username);
           Task<IEnumerable<ACCOUNT>> GetAllAccountsAsync();
           Task AddAccountAsync(ACCOUNT account);
           Task UpdateAccountAsync(ACCOUNT account);
           Task DeleteAccountAsync(string username);
       }
   }
   