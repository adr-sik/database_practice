using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mas_project.DTO
{
    internal class EmployeeDTO
    {
        public int TemporaryId { get; set; }
        public DateTime TemporaryIdExpiryDate { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime DateOfEmployment { get; set; }
    }
}
