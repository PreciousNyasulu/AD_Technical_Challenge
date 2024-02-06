using NaLib.Models;
using System.Data;
using Dapper;
using NaLib.Services;
using System.Collections;

namespace NaLib;
public class LibraryResourceRepository : IRepository<LibraryResource>
{
    Repository _Repository = new Repository();
    private readonly IDbConnection connection;

    public LibraryResourceRepository()
    {
        connection = _Repository.Connection;
    }

    public void Add(LibraryResource Entity)
    {
        if (Exists(Entity))
        {
            return;
        }
        
        connection.Open();
        connection.Execute(
                "INSERT INTO public.library_resources (resource_id, title, author, total_copies, available_copies, isbn, publication_year, genre, publisher, description) VALUES(nextval('library_resources_resource_id_seq'::regclass), @Title, @Author, @TotalCopies, @AvailableCopies, @ISBN , @PublicationYear, (SELECT id FROM book_genres WHERE name = @Genre), @Publisher, @Description)",
                new LibraryResource { Title = Entity.Title, Author = Entity.Author, TotalCopies = Entity.TotalCopies, AvailableCopies = Entity.AvailableCopies, ISBN = Entity.ISBN, PublicationYear = Entity.PublicationYear, Genre = Entity.Genre, Publisher = Entity.Publisher, Description = Entity.Description }
            );
        connection.Close();
    }

    public bool Exists(LibraryResource Entity)
    {
        IEnumerable<LibraryResource> Resource = Get(Entity);
        return Resource.ToList().Count > 0;
    }

    public IEnumerable<LibraryResource> Get(LibraryResource Entity)
    {
        connection.Open();
        IEnumerable<LibraryResource> LibraryResource = connection.Query<LibraryResource>(
                "SELECT r.resource_id, r.title, r.author, r.total_copies, r.available_copies, r.isbn, r.publication_year, (select name from book_genres bg where r.genre=bg.id), r.publisher, r.description FROM public.library_resources r WHERE r.isbn = @ISBN or r.title = @TITLE", 
                new LibraryResource { ISBN = Entity.ISBN, Title = Entity.Title }
            );
        connection.Close();
        return LibraryResource;
    }

    public IEnumerable<LibraryResource> GetAll()
    {
        connection.Open();
        IEnumerable<LibraryResource> libraryResources = connection.Query<LibraryResource>("SELECT r.resource_id, r.title, r.author, r.total_copies, r.available_copies, r.isbn, r.publication_year, (select name as genre from book_genres bg where r.genre=bg.id), r.publisher, r.description FROM public.library_resources r");
        connection.Close();
        return libraryResources;
    }

    public IEnumerable<LibraryResource> Update(LibraryResource Entity)
    {
        try
        {
            connection.Open();

            int affectedRows = connection.Execute(
                "UPDATE public.library_resources SET title = @Title, author = @Author, total_copies = @TotalCopies, " +
                "available_copies = @AvailableCopies, publication_year = @PublicationYear, genre = @Genre, " +
                "publisher = @Publisher, description = @Description WHERE isbn = @ISBN",
                new
                LibraryResource
                {
                    Title = Entity.Title,
                    Author = Entity.Author,
                    TotalCopies = Entity.TotalCopies,
                    AvailableCopies = Entity.AvailableCopies,
                    PublicationYear = Entity.PublicationYear,
                    Genre = Entity.Genre,
                    Publisher = Entity.Publisher,
                    Description = Entity.Description,
                    ISBN = Entity.ISBN
                });

            if (affectedRows > 0)
            {
                return new List<LibraryResource> { Entity };
            }
            else
            {
                return Enumerable.Empty<LibraryResource>();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating library resource.", ex);
        }
        finally
        {
            connection.Close();
        }
    }

}