using Microsoft.EntityFrameworkCore;
using UstamOgretiyorBize.Exceptions;

namespace UstamOgretiyorBize.Extensions;

public static class RepoExtensions
{
    public static T FindOneOrThrow<T>(this DbSet<T> repository, int id) where T : class
    {
        var entity = repository.Find(id);

        if (null == entity)
        {
            throw new HttpException(typeof(T).Name + " Not found",StatusCodes.Status404NotFound);
        }

        return entity;
    }
}