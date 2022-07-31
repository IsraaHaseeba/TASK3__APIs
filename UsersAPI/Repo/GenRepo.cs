using NPOI.SS.Formula.Functions;
using UsersAPI.Models;

namespace UsersAPI.Repo
{


    public interface IGenRepo<T> where T : class, IBaseModel 
    {
        public List<T> getAll();
        public T Get(int id);
        public void Delete(int id);
        public Task<T> Add(T t);
        public Task<T> update(T t);
    }


    public class GenRepo<T>: IGenRepo<T> where T: class, IBaseModel
    {
        public UserContext _context;


        public GenRepo(UserContext context)
        {
            _context = context;
        }

        public  List<T>? getAll()
        {
            return _context.Set<T>().ToList();
        }

        public  T Get(int id)
        {
            return _context.Find<T>(id);
        }

        public async void Delete(int id)
        {
            _context.Remove<T>(Get(id));
            await _context.SaveChangesAsync();
        }

        public async Task<T> update(T model)
        {
            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<T> Add(T t)
        {
            await _context.Set<T>().AddAsync(t);
            await _context.SaveChangesAsync();
            return t;
        }

    }


}
