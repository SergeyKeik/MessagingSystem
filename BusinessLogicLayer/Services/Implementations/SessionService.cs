using BusinessLogicLayer.Dto;
using BusinessLogicLayer.Exceptions.NotFound;
using BusinessLogicLayer.Extensions;
using BusinessLogicLayer.Mapping;
using DataAccessLayer;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services.Implementations;

public class SessionService : ISessionService
{
    private readonly DatabaseContext _context;

    public SessionService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<SessionDto> LoginAsync(string login, string password)
    {
        var user = _context.Accounts.FirstOrDefault(account => account.Login == login && account.Password == password);
        if (user == null)
        {
            throw new EntityNotFoundException("No such user");
        }

        var session = new Session(Guid.NewGuid(), user.Id);
        _context.Add(session);

        await _context.SaveChangesAsync();

        return session.AsDto();
    }

    public async Task<SessionDto> LogoutAsync(Guid sessionId)
    {
        var session = await _context.Sessions.GetEntityAsync(sessionId);
        _context.Remove(session);

        await _context.SaveChangesAsync();

        return session.AsDto();
    }
}