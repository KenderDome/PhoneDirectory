using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Shared.Entities
{
    public class EmployeeType
    {
        public int EmployeeTypeId { get; set; }
        public EmployeeTitle Title { get; set; }
        public int DisplayOrder { get; set; }
        public List<Employee>? Employee { get; set; }

    }

}
