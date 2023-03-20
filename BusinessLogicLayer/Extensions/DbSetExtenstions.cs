using BusinessLogicLayer.Exceptions.NotFound;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Extensions;

public static class DbSetExtensions
{
    public static async Task<T> GetEntityAsync<T>(this DbSet<T> set, Guid id)
        where T : class
    {
        var entity = await set.FindAsync(id);

        if (entity is null)
            throw new EntityNotFoundException("Entity was not found");

        return entity;
    }
}