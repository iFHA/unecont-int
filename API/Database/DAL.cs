using Microsoft.EntityFrameworkCore;

namespace API.Database;
public class DAL<T> where T : class
{
    protected readonly Context context;

    public DAL(Context context)
    {
        this.context = context;
    }
    public IEnumerable<T> List()
    {
        return this.context.Set<T>().ToList();
    }

    public void Add(T obj)
    {
        context.Set<T>().Add(obj);
        context.SaveChanges();
    }
    public async Task AddRangeAsync(ICollection<T> collection)
    {

        await using (var transaction = await context.Database.BeginTransactionAsync())
        {
            try
            {
                string tableName = GetTableName();
                await context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT [{tableName}] ON");

                await context.Set<T>().AddRangeAsync(collection);
                await context.SaveChangesAsync();

                await context.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT [{tableName}] OFF");

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
    public void Update(T obj)
    {
        context.Set<T>().Update(obj);
        context.SaveChanges();
    }
    public void Delete(T obj)
    {
        context.Set<T>().Remove(obj);
        context.SaveChanges();
    }
    public async Task DeleteAll()
    {
        string tableName = GetTableName();
        await context.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE {tableName}");
        context.SaveChanges();
    }
    public T? GetBy(Func<T, bool> predicate)
    {
        return context.Set<T>()?.FirstOrDefault(predicate);
    }
    private string GetTableName()
    {
        var entityType = context.Model.FindEntityType(typeof(T));
        if (entityType == null)
            throw new InvalidOperationException($"O tipo {typeof(T).Name} não está configurado no modelo.");

        return entityType.GetTableName();

    }
}

