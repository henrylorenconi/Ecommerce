using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class City
    {
        [Key]
        [Display(Name = "ID da Cidade")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        [Display(Name = "Cidade")]
        public String Name { get; set; }

        [Required(ErrorMessage = "O campo Região é obrigatório!")]
        [Display(Name = "Região")]
        [Range(1, double.MaxValue, ErrorMessage = "Selecione uma Região!")]
        public int DepartamentsId { get; set; }

        public virtual Departaments Departament { get; set; }

        public virtual ICollection<Company> Company { get; set; }

        public virtual ICollection<User> User { get; set; }

        public virtual ICollection<WareHouse> WareHouse { get; set; }
        
        public virtual ICollection<Customer> Customer { get; set; }
    }
}