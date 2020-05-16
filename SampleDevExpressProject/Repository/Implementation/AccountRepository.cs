using System;
using System.Collections.Generic;
using SampleDevExpressProject.Models.Account;

namespace SampleDevExpressProject.Repository.Implementation
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public Account GetById(int id)
        {
            return QueryFirstOrDefault<Account>("SELECT * FROM Account WHERE Id = @Id", new { id });
        }

        public List<Account> GetAll()
        {
            return Query<Account>("SELECT * FROM Account ORDER BY Name");
        }

        public void DeleteAccounts(List<long> selectedIds)
        {
            foreach (var id in selectedIds)
            {
                const string deleteQuery = @"DELETE FROM Account Where Id = @id";
                Execute(deleteQuery, new { id });
            }
        }

        public void AddNewRecord(Account account)
        {
            const string insertQuery = @"INSERT INTO Account (Code, Name, Surname, Address, Town, Country, Telephone, TaxNumber, TCKNumber, Email, WebAddress, AccountType, Created) 
                        VALUES (@Code, @Name, @Surname, @Address, @Town, @Country, @Telephone, @TaxNumber, @TCKNumber, @Email, @WebAddress, @AccountType, @Created) ";
            Execute(insertQuery, new
            {
                account.Code,
                account.Name,
                account.Surname,
                account.Address,
                account.Town,
                account.Country,
                account.Telephone,
                account.TaxNumber,
                account.TCKNumber,
                account.Email,
                account.WebAddress,
                account.AccountType,
                Created = DateTime.Now
            });
        }

        public void UpdateRecord(Account account)
        {
            const string updateQuery = @"UPDATE Account 
                                        SET Code = @Code, Name =  @Name, Surname= @Surname, Address = @Address, 
                                        Town = @Town, Country = @Country, Telephone = @Telephone, TaxNumber = @TaxNumber,
                                        TCKNumber = @TCKNumber, Email = @Email, WebAddress = @WebAddress, AccountType = @AccountType, Updated = @Updated
                                        WHERE Id = @Id";
            Execute(updateQuery, new
            {
                account.Code,
                account.Name,
                account.Surname,
                account.Address,
                account.Town,
                account.Country,
                account.Telephone,
                account.TaxNumber,
                account.TCKNumber,
                account.Email,
                account.WebAddress,
                account.AccountType,
                Updated = DateTime.Now,
                account.Id
            });
        }

    }
}