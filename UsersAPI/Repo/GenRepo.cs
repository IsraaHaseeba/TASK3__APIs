using AutoMapper;
using AutoMapper.QueryableExtensions;
using NPOI.SS.Formula.Functions;
using UsersAPI.Models;
using UsersAPI.ViewModels;

namespace UsersAPI.Repo
{


    public interface IGenRepo<T> where T : class, IBaseModel 
    {
        public Task<List<TVM>> getAll<TVM>();
        //public Task<List<TVM>> Search<TVM>(int page, int size, string textToSearch);
        public TVM Get<TVM>(int id) where TVM : class, IBaseModel;
        public Task Delete(int id);
        public Task<T> Add(T t);
        public Task<T> update(T t);
    }


    public class GenRepo<T>: IGenRepo<T> where T: class, IBaseModel
    {
        public UserContext _context;
        public IMapper _imapper;
        

        public GenRepo(UserContext context, IMapper imapper)
        {
            _context = context;
            _imapper = imapper;
        }

        public async Task<List<TVM>>? getAll<TVM>()
        {
            return _context.Set<T>().ProjectTo<TVM>(_imapper.ConfigurationProvider).ToList();
        }
        public TVM ?Get<TVM>(int id) where TVM : class, IBaseModel
        {
            return _context.Set<T>().ProjectTo<TVM>(_imapper.ConfigurationProvider).FirstOrDefault(c => c.Id == id);
        }

        public async Task Delete(int id)
        {
            var _temp = _context.Set<T>().FirstOrDefault(c => c.Id == id);
            _context.Remove<T>(_temp);
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
