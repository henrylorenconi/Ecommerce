using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "O campo de Cliente é obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "Você deve selecionar um cliente!")]
        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }

        [Display(Name = "Companhia")]
        [Required(ErrorMessage = "O campo Companhia é obrigatório!")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O campo de Estado é obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "Você deve selecionar um estado para o pedido!")]
        [Display(Name = "Estado do pedido")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "O campo de Data é obrigatório!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Anotações")]
        public string Remarks { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual State State { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}