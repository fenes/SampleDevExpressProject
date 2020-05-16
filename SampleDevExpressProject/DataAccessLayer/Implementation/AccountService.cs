using System.Collections.Generic;
using System.Linq;
using SampleDevExpressProject.Models.Account;
using SampleDevExpressProject.Repository;

namespace SampleDevExpressProject.DataAccessLayer.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository accountRepository)
        {
            _repository = accountRepository;
        }

        public List<Account> GetAccounts()
        {
            return _repository.GetAll();
        }

        public void DeleteRecords(string selectedRowIds)
        {
            List<long> selectedIds = selectedRowIds.Split(',').ToList().ConvertAll(long.Parse);
            _repository.DeleteAccounts(selectedIds);
        }

        public void AddNewRecord(Account obj)
        {
            _repository.AddNewRecord(obj);
        }

        public void UpdateRecord(Account obj)
        {
            _repository.UpdateRecord(obj);
        }

        public object GetById(long id)
        {
            return _repository.GetById((int)id);
        }
    }
}