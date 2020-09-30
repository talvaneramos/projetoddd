using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        //atributo
        private readonly DataContext dataContext;

        //construtor com entrada de argumentos
        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual void Insert(T obj)
        {
            dataContext.Entry(obj).State = EntityState.Added;
            dataContext.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            dataContext.Entry(obj).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public virtual void Delete(T obj)
        {
            dataContext.Entry(obj).State = EntityState.Deleted;
            dataContext.SaveChanges();
        }

        public virtual List<T> GetAll()
        {
            return dataContext.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return dataContext.Set<T>().Find(id);
        }
    }
}
