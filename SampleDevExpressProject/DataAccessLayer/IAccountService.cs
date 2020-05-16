using System.Collections.Generic;
using SampleDevExpressProject.Models.Account;

namespace SampleDevExpressProject.DataAccessLayer
{
    public interface IAccountService
    {
        List<Account> GetAccounts();
        void DeleteRecords(string selectedRowIds);
        void AddNewRecord(Account obj);
        void UpdateRecord(Account obj);
        object GetById(long id);
    }
}