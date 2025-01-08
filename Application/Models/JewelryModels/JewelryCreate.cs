using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.JewelryModels
{
    public class JewelryCreate : CreateModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Created Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Created Price must be greater than 0")]
        public decimal CreatedPrice { get; set; }

        [Required(ErrorMessage = "Material is required")]
        public string Material { get; set; } = string.Empty;

        [Required(ErrorMessage = "Weight is required")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Weight must be greater than 0")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Supplier is required")]
        public string? Supplier { get; set; }
        public string? Description { get; set; }
        public string? Note { get; set; }
        public string? Color { get; set; }
        public string? Gemstone {  get; set; }
        [RegularExpression(@"^[SMLXL]+$", ErrorMessage = "Size must be one of the following: S, M, L, XL")]
        public string? Size { get; set; }
        public string? CertificateNumber { get; set; }
        public string? Origin { get; set; }
    }
}
