using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class ShipDao
    {
        SachDbContext db = null;
        public ShipDao()
        {
            db = new SachDbContext();
        }
        public IEnumerable<ShippingType> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ShippingType> model = db.ShippingType;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TypeShip.Contains(searchString));

            }
            return model.OrderByDescending(x => x.Cost).ToPagedList(page, pageSize);

        }
      
        public bool AddShip(ShippingType entity)
        {
            try
            {
                var ship = new ShippingType();
                ship.ID = entity.ID;
                ship.TypeShip = entity.TypeShip;
                ship.Cost = entity.Cost;
                ship.Time = entity.Time;
                db.ShippingType.Add(ship);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ShippingType FindID(long id)
        {
            return db.ShippingType.Find(id);
        }

        public bool EditShip(ShippingType entity)
        {
            try
            {
                var ship = FindID(entity.ID);
                ship.ID = entity.ID;
                ship.TypeShip = entity.TypeShip;
                ship.Cost = entity.Cost;
                ship.Time = entity.Time;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Deleteship(long id)
        {
            try
            {
                var slide = db.ShippingType.Find(id);
                db.ShippingType.Remove(slide);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //public ShippingType ViewDetail(int id)
        //{
        //    return db.ShippingType.Find(id);
        //}
        public List<string> Listsearch(string search)
        {
            return db.ShippingType.Where(x => x.TypeShip.Contains(search)).Select(x => x.TypeShip).ToList();
        }
        public List<ShippingType> ListAll()
        {
            return db.ShippingType.ToList();
        }
    }
}
