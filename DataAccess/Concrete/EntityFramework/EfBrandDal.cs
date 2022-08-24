using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (SampleDatabase context = new SampleDatabase())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        { 
             using (SampleDatabase context=new SampleDatabase())
        {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();


            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using(SampleDatabase context = new SampleDatabase())
            {
                return filter == null ? context.Set<Brand>().ToList() :
                    context.Set<Brand>().Where(filter).ToList();
            }
            
        }

        public Brand GetById(Expression<Func<Brand, bool>> filter)
        {
            using (SampleDatabase context = new SampleDatabase())
            {
                

                return  context.Set<Brand>().SingleOrDefault(filter);
            }
           
        }

        public void Update(Brand entity)
        {
            using (SampleDatabase context = new SampleDatabase())
            {
                var updatedEntity = context.Entry(entity);
               updatedEntity.State = EntityState.Modified;
                context.SaveChanges();


            }
        }

       
    }
}
