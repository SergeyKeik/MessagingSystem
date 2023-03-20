using BusinessLogicLayer.Dto;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services;

public interface ISessionService
{
    Task<SessionDto> LoginAsync(string login, string password);
    Task<SessionDto> LogoutAsync(Guid sessionId);
}