using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ECommerce.Models
{
    public class WareHouse
    {
        [Key]
        [Display(Name = "ID do Armazém")]
        public int WareHouseId { get; set; }

        [Display(Name = "Companhia")]
        [Required(ErrorMessage = "O campo Companhia é obrigatório!")]
        [Index("WareHouse_CompanyId_Name_Index", 1, IsUnique = true)]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "O campo Armazém é obrigatório!")]
        [MaxLength(250, ErrorMessage = "O campo recebe no máximo 250 caracteres!")]
        [Display(Name = "Armazém")]
        [Index("WareHouse_CompanyId_Name_Index", 2, IsUnique = true)]
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

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "O campo depatamento é obrigatório!")]
        public int DepartamentsId { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "O campo cidade é obrigatório!")]
        public int CityId { get; set; }
        public virtual Departaments Departaments { get; set; }

        public virtual City Cities { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}