using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Tax
    {
        [Key]
        [Display(Name = "ID da Taxa")]
        public int TaxId { get; set; }

        [MaxLength(100, ErrorMessage = "O campo recebe no máximo 50 caracteres!")]
        [Required(ErrorMessage = "O campo descrição é obrigatório!")]
        [Display(Name = "Descrição da taxa")]
        [Index("Category_Description_CompanyId_Index", 2, IsUnique = true)]
        public String Description { get; set; }

        [Display(Name = "Imposto")]
        [Required(ErrorMessage = "O campo de taxa é obrigatório!")]
        //[Range(0, 1, ErrorMessage = "Apenas valores de 0 a 1!")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public double Rate { get; set; }

        [Required(ErrorMessage = "O campo distribuidora é obrigatório!")]
        [Display(Name = "Distribuidora")]
        [Index("Category_Description_CompanyId_Index", 1, IsUnique = true)]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma distribuidora!")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}