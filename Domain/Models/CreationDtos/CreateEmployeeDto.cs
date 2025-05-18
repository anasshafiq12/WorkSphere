using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CreationDtos
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime JoinDate { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
    }
}
