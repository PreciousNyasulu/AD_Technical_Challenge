using NaLib;

namespace NaLib;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();

    void Add(T Entity);

    bool Exists(T Entity);

    IEnumerable<T> Get(T Entity);

    IEnumerable<T> Update(T Entity);
}