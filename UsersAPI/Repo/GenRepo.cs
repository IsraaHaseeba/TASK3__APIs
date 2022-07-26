using NPOI.SS.Formula.Functions;
using UsersAPI.Models;

namespace UsersAPI.Repo
{


    public interface IGenRepo<T> where T : class, IBaseModel 
    {
        public List<T> getAll();
        public T Get(int id);
        public void Delete(int id);
        public T Add(T t);
        public T update(T t);
    }


    public class GenRepo<T>: IGenRepo<T> where T: class, IBaseModel
    {
        public UserContext _context;


        public GenRepo(UserContext context)
        {
            _context = context;
        }

        public List<T>? getAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return _context.Find<T>(id);
        }

        public void Delete(int id)
        {
            _context.Remove<T>(Get(id));
            _context.SaveChanges();
        }

        public T update(T model)
        {
            _context.Set<T>().Update(model);
            _context.SaveChanges();
            return model;
        }
        public T Add(T t)
        {
            _context.Add<T>(t);
            _context.SaveChanges();
            return t;
        }

    }


}
