using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Company
    {
        [Key]
        [Display(Name = "Empresa")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo recebe no máximo 50 caracteres!")]
        [Display(Name = "Nome")]
        [Index("Departament_Name_Index", IsUnique = true)]
        public String Name { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo recebe no máximo 50 caracteres!")]
        [Display(Name = "Telefone")]
        //[Index("Departament_Name_Index", IsUnique = true)]  
        [DataType(DataType.PhoneNumber)]
        public String Phone { get; set; }

        [Required(ErrorMessage = "O campo endereço é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O campo recebe no máximo 100 caracteres!")]
        [Display(Name = "Endereço")]
        public String Address { get; set; }

        [Display(Name = "Imagem")]
        [DataType(DataType.ImageUrl)]
        public String Logo { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "O campo depatamento é obrigatório!")]
        public int DepartamentsId { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo cidade é obrigatório!")]
        public int CityId { get; set; }


        public virtual Departaments Departaments { get; set; }

        public virtual City Cities { get; set; }

        public virtual ICollection<User> User { get; set; }

        public virtual ICollection<Category> Category { get; set; }

        public virtual ICollection<Tax> Taxes { get; set; }

        public virtual ICollection<Product> Product { get; set; }

        public virtual ICollection<WareHouse> WareHouse { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
    }
}