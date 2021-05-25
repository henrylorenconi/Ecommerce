using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Inventory
    {
        [Key]
        [Required(ErrorMessage = "O campo Estoque ID é obrigatório!")]
        public int InventoryId { get; set; }

        [Required(ErrorMessage = "O campo Produto ID é obrigatório!")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "O campo Armazém ID é obrigatório!")]
        public int WareHouseId { get; set; }
        

        public double Stock { get; set; }

        public virtual Product Product { get; set; }
        public virtual WareHouse WareHouse { get; set; }
    }
}