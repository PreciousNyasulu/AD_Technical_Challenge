namespace NaLib.Models;
public class BorrowHistory
{
    public int BorrowId{ get; set; }
    public int MemberId{ get; set; }	
    public int ResourceId { get; set; }
    public DateTime BorrowDate	{ get; set; }
    public DateTime ReturnDate { get; set; }
}