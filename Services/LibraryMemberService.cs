using NaLib.Models;

namespace NaLib.Services;
public class LibraryMemberService
{
    private readonly IRepository<LibraryMember> _LibraryMemberRepository;

    public LibraryMemberService(IRepository<LibraryMember> LibraryMemberRepository)
    {
        _LibraryMemberRepository = LibraryMemberRepository;
    }

    public void AddMember(LibraryMember Member)
    {
        _LibraryMemberRepository.Add(Member);
    }

    public bool MemberExists(LibraryMember Member)
    {
        return _LibraryMemberRepository.Exists(Member);
    }
}