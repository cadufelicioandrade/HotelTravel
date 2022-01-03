using HotelTravelMemories.Data.Context;
using HotelTravelMemories.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTravelMemories.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {

        protected HotelContext _hotelContext;

        public BaseRepository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }

        public void Add(TEntity entity)
        {
            try
            {
                _hotelContext.Set<TEntity>().Add(entity);
                _hotelContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = this.GetById(id);

                if (entity is null)
                    return false;

                _hotelContext.Set<TEntity>().Remove(entity);
                _hotelContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TEntity> GetAll()
        {
            try
            {
                return _hotelContext.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                return _hotelContext.Set<TEntity>().Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                _hotelContext.Set<TEntity>().Update(entity);
                _hotelContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
