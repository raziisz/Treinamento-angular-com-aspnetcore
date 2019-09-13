using System.Collections.Generic;
using System.Linq;

namespace Project.Api.Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;

        }
        public void Adicionar(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
                        _context.SaveChanges();
        }

        public TEntity ObterPorId(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}