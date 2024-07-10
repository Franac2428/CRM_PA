using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace DataAccess.Implementations
{
    public class DALGenericoImpl<TEntity> : IDALGenerico<TEntity> where TEntity : class
    {
        private CrmContext _crm;

        public DALGenericoImpl(CrmContext crm)
        {
            _crm = crm;
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _crm.Add(entity);
                _crm.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public TEntity GetById(int id)
        {

            return _crm.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _crm.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _crm.Set<TEntity>().Attach(entity);
                _crm.Set<TEntity>().Remove(entity);
                _crm.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _crm.Entry(entity).State = EntityState.Modified;
                _crm.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
