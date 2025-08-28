using DataAccess.Db;
using DataAccess.InterfacesRepository;
using Models;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader entity)
        {
            entity.LastUpdate = DateTime.UtcNow;
            _db.OrderHeaders.Update(entity);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(o=>o.Id==id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                    orderFromDb.LastUpdate = DateTime.UtcNow;
                }
            }
        }

        public void UpdateStripePaymentId(int id, string sessionId, string pamentIntentId)
        {
            var orderFromDb = _db.OrderHeaders.FirstOrDefault(o => o.Id == id);
            if (orderFromDb != null)
            {
                if (!string.IsNullOrEmpty(sessionId))
                {
                    orderFromDb.SessionId = sessionId;
                }
                if (!string.IsNullOrEmpty(pamentIntentId))
                {
                    orderFromDb.PaymentIntentId = pamentIntentId;
                    orderFromDb.OrderDate=DateTime.Now;
                }
                orderFromDb.LastUpdate= DateTime.UtcNow;
            }
        }

        
    }
}
