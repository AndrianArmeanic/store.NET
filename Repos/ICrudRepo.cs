namespace StoreApplication.Repos
{
    public interface ICrudRepo<T>: IReadManyRepo<T>, IReadOneRepo<T>, ICreateRepo<T>, IUpdateRepo<T>, IDeleteRepo<T>
    {
    }
}
