﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(100, ErrorMessage = "The filed {0} must be maximun {1} characters length")]
        [Display(Name = "Produto")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(0, double.MaxValue, ErrorMessage = "The {0} must be between {1} and {2}")]
        [Display(Name = "Imposto")]
        public double TaxRate { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "You must enter values in {0} between {1} and {2}")]
        [Display(Name = "Valor")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "You must enter values in {0} between {1} and {2}")]
        [Display(Name = "Quantidade")]
        public double Quantity { get; set; }

        public virtual Orders Order { get; set; }

        public virtual Product Product { get; set; }

    }
}