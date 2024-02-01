using NaLib;

namespace NaLib;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
}