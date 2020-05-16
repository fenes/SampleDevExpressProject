using System.Collections.Generic;
using SampleDevExpressProject.Models.Account;

namespace SampleDevExpressProject.Repository
{
    public interface IAccountRepository
    {
        Account GetById(int id);
        List<Account> GetAll();
        void DeleteAccounts(List<long> selectedIds);
        void AddNewRecord(Account account);
        void UpdateRecord(Account account);
    }
}