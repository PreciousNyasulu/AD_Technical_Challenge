using NaLib.Models;

namespace NaLib.Services;
public class LibraryResourceService
{
    private readonly IRepository<LibraryResource> _LibraryResourceRepository;

    public LibraryResourceService(IRepository<LibraryResource> LibraryResourceRepository)
    {
        _LibraryResourceRepository = LibraryResourceRepository;
    }

    public void AddResource(LibraryResource Resource)
    {
        _LibraryResourceRepository.Add(Resource);
    }

    public bool ResourceExists(LibraryResource Entity)
    {
        return _LibraryResourceRepository.Exists(Entity);
    }
}