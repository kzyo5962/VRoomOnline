using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using vroom.Extensions;

namespace vroom.Models
{
    public class Bike
    {
        public int Id { get; set; }

        public Make Make { get; set; }

        [RegularExpression(@"^[1-9]*$", ErrorMessage = "Select Make")]
        public int MakeID { get; set; }

        public Model Model { get; set; }
        [RegularExpression(@"^[1-9]*$", ErrorMessage = "Select Mode")]
        public int ModelID { get; set; }

        [Required(ErrorMessage = "Provide Year")]
        [YearRangeTillDate(1700, ErrorMessage = "Invalid Year")]
        public int Year { get; set; }


        [Required(ErrorMessage = "Provide Mileage")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Mileage")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Provide Features")]
        public string Features { get; set; }

        [Required(ErrorMessage = "Provide Seller Name")]
        public string SellerName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "Provide Seller Email")]
        public string SellerEmail { get; set; }

        [Required(ErrorMessage = "Provide Seller Phone")]
        public string SellerPhone { get; set; }

        [Required(ErrorMessage = "Provide Price")]
        [DisplayFormat(DataFormatString = "{0:n0}", ApplyFormatInEditMode = true)]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid Price")]
        public int Price { get; set; }

        [RegularExpression(@"^[A-Za-z]*$", ErrorMessage = "Select Currency")]
        public string Currency { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
