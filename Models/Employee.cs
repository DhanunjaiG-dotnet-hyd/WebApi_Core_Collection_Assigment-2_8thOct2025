using System.ComponentModel.DataAnnotations;

namespace WebApi_Core_Collection.Models
{
    public class Employee
    {
        [Required(ErrorMessage ="ID Field is Mandatory")]
        public int Id { get; set; }

        [StringLength(30,MinimumLength =3, ErrorMessage ="")]
        public string Name { get; set; }

        public string Department {  get; set; }

        [RegularExpression(@"\d{10}$",ErrorMessage ="Mobile Number should be only numbers and length of 10")]
        public string MobileNo { get; set; }

        [EmailAddress(ErrorMessage ="Email Id Should be in correct Format")]
        public string Email {  get; set; }
    }
}
