namespace NaLib.Models;
public class LibraryResource
{
    public int ResourceId { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public int TotalCopies { get; set; }

    public int AvailableCopies { get; set; }

    public string? ISBN { get; set; }

    public int PublicationYear { get; set; }

    public string? Genre { get; set; }

    public string? Publisher { get; set; }

    public string? Description { get; set; }
}
