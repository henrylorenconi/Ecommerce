using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "O campo E-mail é requerido!")]
        [MaxLength(256, ErrorMessage = "O campo deve conter no máximo 256 caracteres!")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo deve conter no máximo 50 caracteres!")]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo Sobrenome deve conter no máximo 50 caracteres!")]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatório!")]
        [MaxLength(20, ErrorMessage = "O campo Telefone deve conter no máximo 20 caracteres!")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O campo Endereço é obrigatório!")]
        [MaxLength(200, ErrorMessage = "O campo Endereço deve conter no máximo 200 caracteres!")]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Required(ErrorMessage = "O campo Departamento é obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "Você deve selecionar um Departamento!")]
        [Display(Name = "Departmento")]
        public int DepartamentsId { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "Você deve selecionar uma Cidade!")]
        [Display(Name = "Cidade")]
        public int CityId { get; set; }

        [Display(Name = "Cliente")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public virtual Departaments Department { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        public virtual ICollection<CompanyCustomer> CompanyCustomers { get; set; }

    }
}