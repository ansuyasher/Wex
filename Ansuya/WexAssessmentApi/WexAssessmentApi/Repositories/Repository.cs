using System.Collections.Concurrent;
using WexAssessmentApi.Models;

namespace WexAssessmentApi.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ConcurrentDictionary<int,T> _store = new ConcurrentDictionary<int,T>();
        private int _currentId = 0;
        public virtual Task AddAsync(T entity)
        {
            var id = System.Threading.Interlocked.Increment(ref _currentId);
            var property = typeof(T).GetProperty("Id");
            if (property != null)
            {
                property.SetValue(entity, id, null);
            }
            _store[id]= entity;
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync(int id)
        {
            _store.TryRemove(id,out _); 
            return Task.CompletedTask;
        }

        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(_store.Values.AsEnumerable());
        }

        public virtual Task<T> GetByIdAsync(int id)
        {
            _store.TryGetValue(id, out T entity);
            return Task.FromResult(entity);
        }

        public virtual Task UpdateAsync(T entity)
        {
            var property = typeof(T).GetProperty("Id");
            if (property != null)
            {
                var id = (int)property.GetValue(entity);
                if (_store.ContainsKey(id))
                {
                    _store[id] = entity;
                }
            }
            return Task.CompletedTask;
        }
    }
}
