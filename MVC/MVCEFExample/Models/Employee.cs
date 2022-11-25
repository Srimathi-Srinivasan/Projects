using System.ComponentModel.DataAnnotations;

namespace MVCEFExample.Models
{
    public class Employee
    {
        [Key]
        public int Eid { get; set; }

        [Required(ErrorMessage ="Ename is Mandatory")]
        public string Ename { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Date of Joining")]
        public DateTime Doj { get; set; }

        [DataType(DataType.Currency,ErrorMessage="Please enter valid data")]
        [Range(10000,100000,ErrorMessage="Range should be between 10000 and 100000")]
        public float Salary { get; set; }

        [Required(ErrorMessage ="*")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Please enter valid email address")]

        public string Email { get; set; }

        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage="Passwords donot match")]
        public string confirmPassword { get; set; }
    }
}
