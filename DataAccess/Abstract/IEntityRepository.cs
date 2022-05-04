using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity,new() // Generic consraint (Kısıtlama) Sadece IEntity referansları yazılabilir. New() ile IEntity'i de eleriz -interface new'lenemez-.
    {
        //DataAccess operasyonlarında ortak olacak kodlar
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
