using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //generic constraint
    //class : referans tip olabilir demek
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() : new'lenebilir olmalı (IEntity new'lenemeyeceği için kullanıyoruz)
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //filter = null filtre vermeyebilir
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //Aşağıdaki koda gerek yok
        //List<T> GetAllByCategory(int categoryId);
    }
}
