public interface IRepository<T>
{
    void Add(T item);
    List<T> GetAll();
    List<T> Find(Func<T, bool> predicate);
}