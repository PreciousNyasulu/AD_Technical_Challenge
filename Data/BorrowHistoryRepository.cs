using NaLib.Models;
using System.Data;
using Dapper;
using NaLib.Services;
using System.Collections;

namespace NaLib.Data;

public class BorrowHistoryRepository : IRepository<BorrowHistory>
{
    Repository _repository = new Repository();
    private readonly IDbConnection connection;

    public BorrowHistoryRepository()
    {
        connection = _repository.Connection;
    }

    public void Add(BorrowHistory Entity)
    {
        connection.Open();
        connection.Execute("INSERT INTO public.borrow_history (borrow_id, member_id, resource_id, borrow_date, return_date) VALUES(nextval('borrow_history_borrow_id_seq'::regclass), @MemberId, (SELECT resource_id from library_resources where isbn = @ResourceId), NOW(), NULL)",new BorrowHistory{MemberId = Entity.MemberId, ResourceId = Entity.ResourceId});
        connection.Close();
    }

    public bool Exists(BorrowHistory Entity)
    {
        connection.Open();
        return Get(Entity).Count() > 0;
    }

    public IEnumerable<BorrowHistory> Get(BorrowHistory Entity)
    {
        connection.Open();

        return connection.Query<BorrowHistory>("SELECT borrow_id, member_id, resource_id, borrow_date, return_date FROM public.borrow_history where MemberId = @MemberId or ResourceId = @ResourceId", new BorrowHistory { MemberId = Entity.MemberId, ResourceId = Entity.ResourceId });
    }

    public IEnumerable<BorrowHistory> GetAll()
    {
        connection.Open();
        return connection.Query<BorrowHistory>("SELECT borrow_id, member_id, resource_id, borrow_date, return_date FROM public.borrow_history");
    }

    public IEnumerable<BorrowHistory> Update(BorrowHistory Entity)
    {
        connection.Open();
        return connection.Query<BorrowHistory>("UPDATE public.borrow_history SET return_date=@ReturnDate WHERE ResourceId=@ResourceId and MemberId = @MemberId",new BorrowHistory{ ResourceId = Entity.ResourceId, MemberId = Entity.MemberId, ReturnDate = DateTime.Now });
    }
}
