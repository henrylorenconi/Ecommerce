using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class OrderDetailTmp
    {
        [Key]
        public int OrderDetailTmpId { get; set; }

        [Required(ErrorMessage = "O campo de Usuário é obrigatório!")]
        [MaxLength(256, ErrorMessage = "O campo deve conter no máximo 256 caracteres!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo de produto é obrigatório!")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "O campo de Produto é requerido!")]
        [MaxLength(200, ErrorMessage = "O campo deve conter no máximo 200 caracteres!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo de Imposto deve ser preenchido!")]
        [Range(0, double.MaxValue, ErrorMessage = "Selecione o valor da taxa!")]
        public double TaxRate { get; set; }


        [Required(ErrorMessage = "O campo de Valor é obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "Selecione o valor!")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O campo de Quantidade deve ser preenchido!")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "Selecione a quantidade!")]
        public double Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Value { get { return Price * (decimal)Quantity; } }

        public virtual Product Product { get; set; }
    }
}