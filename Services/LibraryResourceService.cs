using Newtonsoft.Json;
using NaLib.Models;

namespace NaLib.Services;
public class LibraryResourceService
{
    private readonly IRepository<LibraryResource> _LibraryResourceRepository;
    private readonly IRepository<BorrowHistory> _BorrowHistoryRepository;
    public LibraryResourceService(IRepository<LibraryResource> LibraryResourceRepository, IRepository<BorrowHistory> BorrowHistoryRepository)
    {
        _LibraryResourceRepository = LibraryResourceRepository;
        _BorrowHistoryRepository = BorrowHistoryRepository;
    }

    public void AddResource(LibraryResource Resource)
    {
        _LibraryResourceRepository.Add(Resource);
    }

    public bool ResourceExists(LibraryResource Entity)
    {
        return _LibraryResourceRepository.Exists(Entity);
    }

    public string GetAllResources()
    {
        return JsonConvert.SerializeObject(_LibraryResourceRepository.GetAll());
    }

    public void Checkout(CheckingPayload Entity)
    {
        _BorrowHistoryRepository.Add(new BorrowHistory{ResourceId = Entity.BookNumber , MemberId = Entity.MemberId});
    }

    public void CheckIn(CheckingPayload Entity)
    {
        _BorrowHistoryRepository.Update(new BorrowHistory { ResourceId = Entity.BookNumber, MemberId = Entity.MemberId });
    }
}