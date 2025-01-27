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
    public void Update(T obj)
    {
        context.Set<T>().Update(obj);
        context.SaveChanges();
    }
    public void Remove(T obj)
    {
        context.Set<T>().Remove(obj);
        context.SaveChanges();
    }
    public T? GetBy(Func<T, bool> predicate)
    {
        return context.Set<T>()?.FirstOrDefault(predicate);
    }
}

