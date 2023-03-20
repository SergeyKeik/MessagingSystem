using BusinessLogicLayer.Dto;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Mapping;

public static class SessionMapping
{
    public static SessionDto AsDto(this Session session)
        => new SessionDto(session.SessionId, session.AccountId);
}