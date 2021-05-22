using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "ID da categoria")]
        public int CategoryId { get; set; }

        [MaxLength(100, ErrorMessage = "O campo recebe no máximo 50 caracteres!")]
        [Required(ErrorMessage = "O campo categoria é obrigatório!")]
        [Display(Name = "Categoria")]
        [Index("Category_Description_CompanyId_Index", 2, IsUnique = true)]
        public String Description { get; set; }

        [Required(ErrorMessage = "O campo distribuidora é obrigatório!")]
        [Index("Category_Description_CompanyId_Index", 1, IsUnique = true)]
        [Display(Name = "Distribuidora")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma distribuidora!")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Product> Product { get; set; }

    }
}