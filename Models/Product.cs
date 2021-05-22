using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "ID do Produto")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "O campo distribuidora é obrigatório!")]
        [Display(Name = "Distribuidora")]
        [Index("Product_Description_CompanyId_Index", 1, IsUnique = true)]
        [Index("Product_Barcode_CompanyId_Index", 1, IsUnique = true)]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma distribuidora!")]
        public int CompanyId { get; set; }

        [MaxLength(100, ErrorMessage = "O campo recebe no máximo 50 caracteres!")]
        [Required(ErrorMessage = "O campo descrição é obrigatório!")]
        [Display(Name = "Produto")]
        [Index("Product_Description_CompanyId_Index", 2, IsUnique = true)]
        public String Description { get; set; }

        [MaxLength(13, ErrorMessage = "O campo recebe no máximo 13 caracteres!")]
        [Required(ErrorMessage = "O campo código de barras é obrigatório!")]
        [Display(Name = "Código de barras")]
        [Index("Product_Barcode_CompanyId_Index", 2, IsUnique = true)]
        public String Barcode { get; set; }

        [Required(ErrorMessage = "O campo de taxa é obrigatório!")]
        [Display(Name = "Taxa")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma Taxa!")]
        public int TaxId { get; set; }

        [Required(ErrorMessage = "O campo de categorias é obrigatório!")]
        [Display(Name = "Categoria")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma categoria!")]
        public int CategoryId { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo de valor é obrigatório!")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public String Image { get; set; }

        [NotMapped]
        [Display(Name = "Imagem")]
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Anotações")]
        [DataType(DataType.MultilineText)]
        public String Remarks { get; set; }

        public virtual Company Company { get; set; }

        public virtual Tax Tax { get; set; }

        public virtual Category Category { get; set; }
    }
}