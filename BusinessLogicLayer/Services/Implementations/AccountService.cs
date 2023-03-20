using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Exceptions.AuthorizationException;
using BusinessLogicLayer.Extensions;
using BusinessLogicLayer.Mapping;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly DatabaseContext _context;

    public AccountService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<AccountDto> CreateAccountAsync(string login, string password, Guid department)
    {
        var accountDepartment = await _context.Departments.GetEntityAsync(department);
        var account = new Account(Guid.NewGuid(), login, password, accountDepartment);
        accountDepartment.Members.Add(account);
        _context.Departments.Update(accountDepartment);

        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        return account.AsDto();
    }

    public async Task<AccountDto> AddSubordinateAsync(Guid accountId, Guid subordinateId)
    {
        var supervisor = await _context.Accounts.GetEntityAsync(accountId);

        var subordinate = await _context.Accounts.GetEntityAsync(subordinateId);

        if (supervisor.Department.Id != subordinate.Department.Id)
        {
            throw new OperationIsNotAuthorizedException("Wrong department");
        }

        if (subordinate.Supervisor != null)
        {
            subordinate.Supervisor.Subordinates.Remove(subordinate);

            _context.Accounts.Update(subordinate.Supervisor);
        }

        subordinate.Supervisor = supervisor;
        supervisor.Subordinates.Add(subordinate);

        _context.Accounts.Update(supervisor);
        _context.Accounts.Update(subordinate);

        await _context.SaveChangesAsync();

        return subordinate.AsDto();
    }

    public async Task<AccountDto?> FindUserAsync(string login, string password)
    {
        var user = _context.Accounts.FirstOrDefault(
            user => user.Login.Equals(login) && user.Password.Equals(password));
        return user?.AsDto();
    }
}