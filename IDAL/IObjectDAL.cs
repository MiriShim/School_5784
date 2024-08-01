namespace IDAL;



public interface IObjectDAL
{
    public bool Add(object entity);
    public object Get(int id);
    public List<object> GetAll();
    public bool Update(object entity);
    public bool Delete(int id);

}
