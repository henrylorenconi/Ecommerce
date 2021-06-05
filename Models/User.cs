using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class User
    {
        [Key]
        [Display(Name = "Empresa")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigatório!")]
        [MaxLength(250, ErrorMessage = "O campo recebe no máximo 250 caracteres!")]
        [Display(Name = "E-mail do usuário")]
        [DataType(DataType.EmailAddress)]
        [Index("User_UserName_Index", IsUnique = true)]
        public String UserName { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo recebe no máximo 50 caracteres!")]
        [Display(Name = "Nome")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "O campo sobrenome é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo recebe no máximo 50 caracteres!")]
        [Display(Name = "Sobrenome")]
        public String LastName { get; set; }


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
        public String Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "O campo depatamento é obrigatório!")]
        public int DepartamentsId { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo cidade é obrigatório!")]
        public int CityId { get; set; }

        [Display(Name = "Companhia")]
        [Required(ErrorMessage = "O campo Companhia é obrigatório!")]
        public int CompanyId { get; set; }

        [Display(Name = "Usuário")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public virtual Departaments Departaments { get; set; }

        public virtual City Cities { get; set; }

        public virtual Company Company { get; set; }
    }
}
