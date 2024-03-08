namespace HouseLib.Repository
{
  public interface IRepository<T> where T : class
  {
    public T GetById(int id);
    public bool Update(T t);
    public bool Add(T t);
    public bool Delete(int id);
    public IList<T> Take(int nb);
    public IList<T> All();

  }
}