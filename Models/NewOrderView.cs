using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class NewOrderView
    {
        [Required(ErrorMessage = "O campo cliente é obrigatório!")]
        [Range(1, double.MaxValue, ErrorMessage = "Você deve selecionar um Cliente!")]
        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "O campo Data deve ser preenchido!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Anotações")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Display(Name = "Detalhes")]
        public List<OrderDetailTmp> Details { get; set; }

        //[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double TotalQuantity { get { return Details == null ? 0 : Details.Sum(d => d.Quantity); } }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal TotalValue { get { return Details == null ? 0 : Details.Sum(d => d.Value); } }



    }
}