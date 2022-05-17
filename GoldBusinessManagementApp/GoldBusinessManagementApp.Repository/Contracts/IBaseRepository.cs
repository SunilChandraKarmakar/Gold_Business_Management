namespace GoldBusinessManagementApp.Repository.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int? id);
        Task<ICollection<T>> GetAll();
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
