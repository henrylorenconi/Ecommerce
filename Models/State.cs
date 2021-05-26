using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Required(ErrorMessage = "O campo de status do pedido é requerido!")]
        [MaxLength(50, ErrorMessage = "O campo deve conter no máximo 50 caracteres!")]
        [Display(Name = "Status do pedido")]
        [Index("State_Description_Index", IsUnique = true)]
        public string Description { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}