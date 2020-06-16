using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaraPiasokownicaNetFramework.Models
{
    [Table("dbo.Employee")]
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}