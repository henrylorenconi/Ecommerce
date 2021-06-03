using ECommerce.Models;
using System;

namespace ECommerce.Classes
{
    public class DBHelper
    {
        private static Response SaveChanges(EcommerceContext db)
        {
            try
            {
                db.SaveChanges();
                return new Response
                {
                    Succeeded = true,
                };
            }
            catch (Exception ex)
            {
                var response = new Response
                {
                    Succeeded = false
                };

                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("_Index")) 
                {
                    response.Message = "O registro esta duplicado!";
                }
                throw;
            }
        }

    }
}