namespace IBL;

public interface  IBL<TDTO>
{
    int AddNew(TDTO entity);
    List<TDTO> GetAll();
}
