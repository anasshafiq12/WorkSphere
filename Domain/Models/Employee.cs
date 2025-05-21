using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime JoinDate { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public decimal PerMonthSalary {  get; set; }
        public decimal TotalSalaryTaken { get;set; }
    }

}
