using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Classes
{
    public class MovementsHelper : IDisposable
    {
        private static EcommerceContext db = new EcommerceContext();
        public void Dispose()
        {
            db.Dispose();
        }

        public static Response NewOrder(NewOrderView view, string UserName)
        {
            using (var transaction = db.Database.BeginTransaction()) { 
                
            }
        }
    }
}