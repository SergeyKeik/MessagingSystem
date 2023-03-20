using BusinessLogicLayer.Dto;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services;

public interface IAccountService
{
    Task<AccountDto> CreateAccountAsync(string login, string password, Guid department);
    Task<AccountDto> AddSubordinateAsync(Guid accountId, Guid subordinateId);

    Task<AccountDto?> FindUserAsync(string login, string password);
}