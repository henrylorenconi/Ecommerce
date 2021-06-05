using ECommerce.Models;
using System;
using System.Linq;

namespace ECommerce.Classes
{
    public class DBHelper
    {
        public static Response SaveChanges(EcommerceContext db)
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
                else if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "Não é possivel remover o registro, porque existem dados ralcionados a ele!";
                }
                else 
                {
                    response.Message = "Não foi possível salvar os dados";             
                }
                return response;
            }
        }

        public static int GetState(string description, EcommerceContext db)
        {
            var state = db.States.Where(s => s.Description == description).FirstOrDefault();
            if (state == null) 
            {
                state = new State
                {
                    Description = description
                };

                db.States.Add(state);
                db.SaveChanges();
            
            }

            return state.StateId;
        }
    }
}