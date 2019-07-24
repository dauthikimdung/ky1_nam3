using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Model.Model;

namespace Model.DAO
{
   public class OrderDao
    {
        SachDbContext db = null;
        public OrderDao()
        { 
            db=new SachDbContext();

        }
        public Order FindID(long id)
        {
            return db.Order.Where(x=>x.ID==id).SingleOrDefault();
        }
        public IEnumerable<Order> ListAll(int page,int pagesize)
        {
            return db.Order.OrderByDescending(x => x.CreateDate).ToPagedList(page,pagesize);
        }
       public IEnumerable<OrderModel> ListAllPage( string searching,int page,int pageSize)
        {

            var model = (from a in db.Order
                         join b in db.ShippingType
                         on a.ShipTypeID equals b.ID
                         join c in db.User
                         on a.Shiper equals c.ID
                         select new OrderModel()
                         {
                             order=a,
                             TypeShip = b.TypeShip,
                             NameShipper=c.Name
                   } );

               
            if(!string.IsNullOrEmpty(searching))
            {
                model = model.Where(x => x.order.ShipName.Contains(searching));
            }
            return model.OrderByDescending(x => x.order.CreateDate).ToPagedList(page, pageSize);


        }
        public bool AddOrder(Order entity)
        {
            var order = new Order();
            try
            {
                order.ID = entity.ID;
                order.ShipName = entity.ShipName;
                order.CreatID = entity.CreatID;
                order.Shiper = entity.Shiper;
                order.ShipAdress = entity.ShipAdress;
                order.ShipEmail = entity.ShipEmail;
                order.ShipMobile = entity.ShipMobile;
                order.ShipTypeID = entity.ShipTypeID;
                order.CouponSerial = entity.CouponSerial;
                order.CreateDate = entity.CreateDate;
                order.CreatID = entity.CreatID;
                order.Status = entity.Status;
                order.TotalPrice = entity.TotalPrice;
                order.ShippedDate = entity.ShippedDate;
                db.Order.Add(order);
                db.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool EditOrder(Order entity)
        {
            var order = new Order();
            try
            {
                
                order = FindID(entity.ID);
                order.Shiper = entity.Shiper;
                order.ShipTypeID = entity.ShipTypeID;
                order.ShippedDate = entity.ShippedDate;
                
                db.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var bk = db.Order.Find(id);
                db.Order.Remove(bk);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
        // tong doanh thu theo thang
        public decimal? Sum (int month,int year)
        {
            return db.Order.Where(x => x.CreateDate.Value.Month == month && x.CreateDate.Value.Year == year).Sum(x => x.TotalPrice);
        }
        public IEnumerable<Order> TakeInMonthOfYear(int? Month, int? Year, int page, int pagesize)
        {
            return db.Order.Where(x => x.ShippedDate.Value.Month == Month && x.ShippedDate.Value.Year == Year).OrderByDescending(x => x.CreateDate).ToPagedList(page,pagesize);
        }
        public List<string> Listsearch(string search)
        {
            return db.Order.Where(x => x.ShipName.Contains(search)).Select(x => x.ShipName).ToList();
        }
        //public bool ChangeStatus(int id)
        //{
        //    var k = db.Order.Find(id);
        //    k.Status = !k.Status;
        //    db.SaveChanges();
        //    return (bool)k.Status;
        //}
    }
}
