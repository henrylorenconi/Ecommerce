using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required(ErrorMessage = "O campo Pedido é obrigatório!")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "O campo de Produtos deve estar preenchido!")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "O campo de Produto deve estar preenchido!")]
        [MaxLength(200, ErrorMessage = "O campo de Produto deve conter no máximo 200 caracteres!")]
        [Display(Name = "Produto")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo de Imposto deve ser preenchido!")]
        [Range(0, double.MaxValue, ErrorMessage = "Selecione o valor da taxa!")]
        [Display(Name = "Imposto")]
        public double TaxRate { get; set; }

        [Required(ErrorMessage = "O campo de Valor é obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "Selecione o valor!")]
        [Display(Name = "Valor")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O campo de Quantidade deve ser preenchido!")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "Selecione a quantidade!")]
        [Display(Name = "Quantidade")]
        public double Quantity { get; set; }

        public virtual Orders Order { get; set; }

        public virtual Product Product { get; set; }

    }
}